using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.IO;

public partial class Manage_temp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["Stal_Rondo"].ConnectionString;
        SqlConnection conn = new SqlConnection(ConnectionString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Gallery]", conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        foreach(DataRow row in dt.Rows)
        {
            string ImgID = row["ImgID"].ToString();
            Image IMG = new Image();
            IMG.ImageUrl = "~/Manage/galleryimg.ashx?img=" + ImgID;
            IMG.Visible = true;
            IMG.ID = ImgID;
            placeholder.Controls.Add(IMG);
            

        }

    }
}