using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_img_upload : System.Web.UI.Page
{
    imgHandler picture = new imgHandler();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Horses.HorseNames().Rows.Count == 0)
        {
            errorbox.InnerHtml = "Niets in lijst!";
        }
        else
        {
            rb.DataSource = Horses.HorseNames();
            rb.DataTextField = "Name";
            rb.DataValueField = "HorseID";
            rb.DataBind();
            rb.Items.Insert(0, new ListItem(string.Empty, "0"));
        }
    }

    protected void UploadIMGtoGallery(object sender, EventArgs e)
    {
        picture.filename = imgInput.PostedFile.FileName;
        picture.imgdata = System.Drawing.Image.FromStream(imgInput.PostedFile.InputStream);
        string ConnectionString = ConfigurationManager.ConnectionStrings["Stal_Rondo"].ConnectionString;
        SqlConnection conn = new SqlConnection(ConnectionString);
        SqlCommand cmd = new SqlCommand("[dbo].[UPLOAD_IMG]", conn);

        cmd.Parameters.AddWithValue("@imgid", Convert.ToInt64(picture.newname));
        cmd.Parameters.AddWithValue("@description", Request.Form["ctl00$MainContent$Description"]);
        cmd.Parameters.AddWithValue("@horseid", Request.Form["ctl00$MainContent$rb"]);
        cmd.Parameters.AddWithValue("@data", picture.bitmap);
        cmd.Parameters.AddWithValue("@size", imgInput.PostedFile.InputStream.Length);
        cmd.Parameters.AddWithValue("@type", imgInput.PostedFile.ContentType);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}