using System;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Linq;
using Microsoft.Win32;

/// <summary>
/// Collection of controllers for getting image attributes.
/// </summary>
public class imgHandler : imgBase
{
    // parameters
    internal string _fileName;
    internal string _identifier;
    internal byte[] _bitmap;
    internal Image _imgdata;

    // methods
    /// <summary>
    /// Returns the filename of the file.
    /// </summary>
    /// <remarks>
    /// Filename must be set first.
    /// </remarks>
    public string filename
    {
        get { return this._fileName; }
        set { this._fileName = value; }
    }

    /// <summary>
    /// Returns the format of the file.
    /// </summary>
    public ImageFormat fileformat
    {
        get {
            if (!string.IsNullOrEmpty(_fileName))
            {
                return GetImageFormat(_fileName);
            }
            else { return null; }
            
        }
    }

    /// <summary>
    /// Returns the extentions of the file.
    /// </summary>
    public string extention
    {
        get
        {
            if (imgdata != null)
            {
                return GetDefaultExtension(imgdata.RawFormat);
            }
            else { return null; }

        }
    }

    /// <summary>
    /// Returns a unique name for the file.
    /// </summary>
    /// <remarks>
    /// Set value will be added to the beginning of the name.
    /// </remarks>
    public string newname
    {
        get
        {
            if (!string.IsNullOrEmpty(this._identifier))
            {
                return RandomNumber(this._identifier);
            }
            else
            {
                return RandomNumber();
            }
        }
        set
        {
            this._identifier = value;
        }
    }

    /// <summary>
    /// Returns the image object.
    /// </summary>
    /// <remarks>
    /// Image or bitmap must be set first.
    /// </remarks>
    public Image imgdata
    {
        get
        {
            if (this._bitmap != null && this._imgdata == null)
            {
                return ByteToImage(this._bitmap);
            }
            else
            {
                return _imgdata;
            }
        }
        set
        {
            this._imgdata = value;
        }
    }

    /// <summary>
    /// Returns the binary of the image object.
    /// </summary>
    /// <remarks>
    /// Image or bitmap must be set first.
    /// </remarks>
    public byte[] bitmap
    {
        get
        {
            if (this._imgdata != null && this._bitmap == null)
            {
                return ImageToByte(this._imgdata, fileformat);
            }
            else
            {
                return _bitmap;
            }
        }
        set
        {
            this._bitmap = value;
        }
    }

    /// <summary>
    /// Resize the image to the specified width and height.
    /// </summary>
    /// <param name="image">The image to resize.</param>
    /// <param name="width">The width to resize to.</param>
    /// <param name="height">The height to resize to.</param>
    /// <returns>The resized image.</returns>
    public static Bitmap ResizeImage(Image image, int width, int height)
    {
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);

        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        using (var graphics = Graphics.FromImage(destImage))
        {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }
        }

        //Image img = destImage;

        return destImage;
    }

    /// <summary>
    /// Crop the image to the specified width and height.
    /// </summary>
    /// <param name="image">The image to crop.</param>
    /// <param name="cropArea">The measures to crop to.</param>
    /// <returns>The cropped image.</returns>
    public static Image cropImage(Image image, Rectangle cropArea)
    {
        Bitmap bmpImage = new Bitmap(image);
        return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
    }

}


/// <summary>
/// Base class for imgHandler
/// </summary>
public abstract class imgBase
{
    protected ImageFormat GetImageFormat(string fileName)
    {
        string extension = Path.GetExtension(fileName);
        if (string.IsNullOrEmpty(extension))
            throw new ArgumentException(
                string.Format("Unable to determine file extension for fileName: {0}", fileName));

        switch (extension.ToLower())
        {
            case @".bmp":
                return ImageFormat.Bmp;

            case @".gif":
                return ImageFormat.Gif;

            case @".ico":
                return ImageFormat.Icon;

            case @".jpg":
            case @".jpeg":
                return ImageFormat.Jpeg;

            case @".png":
                return ImageFormat.Png;

            case @".tif":
            case @".tiff":
                return ImageFormat.Tiff;

            case @".wmf":
                return ImageFormat.Wmf;

            default:
                throw new NotImplementedException();
        }
    }

    public string GetDefaultExtension(ImageFormat imageformat)
    {
        string result;
        RegistryKey key;
        object value;

        ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == imageformat.Guid);
        string mimeType = codec.MimeType;

        key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + mimeType, false);
        value = key != null ? key.GetValue("Extension", null) : null;
        result = value != null ? value.ToString() : string.Empty;

        return result;
    }

    public string RandomNumber()
    {
        Random rNumber = new Random();
        string rnd_str = rNumber.Next(1000000).ToString();
        string today = DateTimeOffset.Now.ToString("yyyyMMdd");

        StringBuilder rnd = new StringBuilder();
        rnd.Append(today + rnd_str);
        string rnd_name = rnd.ToString();
        return rnd_name;
    }

    public string RandomNumber(string identifier)
    {
        Random rNumber = new Random();
        string rnd_str = rNumber.Next(1000000).ToString();
        string today = DateTimeOffset.Now.ToString("yyyyMMdd");

        StringBuilder rnd = new StringBuilder();
        rnd.Append(identifier + today + rnd_str);
        string rnd_name = rnd.ToString();
        return rnd_name;
    }

    protected byte[] ImageToByte(Image imgIn, ImageFormat fileFormat)
    {
        MemoryStream ms = new MemoryStream();
        imgIn.Save(ms, fileFormat);
        return ms.ToArray();
    }

    protected Image ByteToImage(byte[] byteArrayIn)
    {
        MemoryStream ms = new MemoryStream(byteArrayIn);
        Image returnImage = Image.FromStream(ms);
        return returnImage;
    }
}