<%@ WebHandler Language="C#" Class="galleryimg" %>

using System;
using Microsoft.Win32;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public class galleryimg : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        if (!string.IsNullOrEmpty(context.Request.Params["img"]))
        {
            string img = context.Request.Params["img"];
            //string img = "20151106710657";

            string ConnectionString = ConfigurationManager.ConnectionStrings["Stal_Rondo"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Gallery] WHERE ImgID = @ImgID", conn);
            cmd.Parameters.Add("@ImgID", SqlDbType.BigInt).Value = img;
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                da.Fill(dt);
            }
            catch(SqlException ex)
            {
                string error = "Execute exception issue: " + ex;
            }
            catch(InvalidOperationException ex)
            {
                string error = "Connection Exception issue: " + ex;
            }
            finally
            {
                conn.Close();
            }

            imgHandler picture = new imgHandler();
            picture.bitmap = dt.Rows[0].Field<byte[]>("Data");
            picture.filename = dt.Rows[0].Field<Int64>("ImgID").ToString() + picture.extention;

            context.Response.ContentType = dt.Rows[0].Field<string>("Type");
            context.Response.AddHeader("content-disposition", @"attachment;filename=" + picture.filename);
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.BufferOutput = false;

            int newWidth = 600;
            int newHeight = Convert.ToInt32((double)picture.imgdata.Height / (double)picture.imgdata.Width * newWidth);         
            Image iSource = imgHandler.ResizeImage(picture.imgdata, newWidth, newHeight);
            MemoryStream ms = new MemoryStream();
            iSource.Save(ms, picture.fileformat);
            byte[] data = ms.ToArray();
            ms.Dispose();
            iSource.Dispose();

            context.Response.BinaryWrite(data);
            context.Response.End();
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }
}