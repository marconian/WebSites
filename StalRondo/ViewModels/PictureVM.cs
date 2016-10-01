using StalRondo.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace StalRondo.ViewModels
{
    public class PictureVM
    {
        public Picture Picture { get; set; }
        public Image ImgFile {
            get {
                if (Picture.Data == null) return null;

                return ImgBase.ByteToImage(Picture.Data);
            }
        }
    }
}