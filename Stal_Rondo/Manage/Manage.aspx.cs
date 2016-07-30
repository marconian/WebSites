using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Manage_Manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if(Horses.HorseNames().Rows.Count == 0)
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
        FatherName.DataSource = Horses.ParentNames(1);
        FatherName.DataTextField = "Name";
        FatherName.DataValueField = "HorseID";
        FatherName.DataBind();
        FatherName.Items.Insert(0, new ListItem(string.Empty, string.Empty));

        MotherName.DataSource = Horses.ParentNames(2);
        MotherName.DataTextField = "Name";
        MotherName.DataValueField = "HorseID";
        MotherName.DataBind();
        MotherName.Items.Insert(0, new ListItem(string.Empty, string.Empty));

        update.Visible = false;
    }
    protected void rb_SelectedIndexChanged(object sender, EventArgs e)
    {
        string HorseID = Request.Form["ctl00$MainContent$rb"];
        if(HorseID == "0")
        {
            rb.SelectedValue = HorseID.ToString();
            insert.Visible = true;
            update.Visible = false;
        }
        else
        {
            DataTable dt = Horses.HorseData(Convert.ToInt32(HorseID));

            rb.SelectedValue = HorseID.ToString();
            update.Visible = true;
            insert.Visible = false;
            HorseName.Text = dt.Rows[0].Field<string>("Name");
            sex.SelectedValue = dt.Rows[0].Field<int>("Sex").ToString();
            BirthDate.Text = dt.Rows[0].Field<DateTime>("BirthDate").ToString("yyyy-MM-dd");

            if (dt.Rows[0].Field<int>("FatherID") != 0)
            {
                FatherName.SelectedValue = dt.Rows[0].Field<int>("FatherID").ToString();
            }
            if (dt.Rows[0].Field<int>("MotherID") != 0)
            {
                MotherName.SelectedValue = dt.Rows[0].Field<int>("MotherID").ToString();
            }

            description.Text = dt.Rows[0].Field<string>("Description");
        }
        //errorbox.InnerHtml = Request.Form["ctl00$MainContent$rb"];


    }
    protected void UpdateHorseDetails(object sender, EventArgs e)
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["Stal_Rondo"].ConnectionString;
        SqlConnection conn = new SqlConnection(ConnectionString);
        SqlCommand cmd = new SqlCommand("[dbo].[UPDATE_HORSE]", conn);
        /*SqlCommand cmd = new SqlCommand(@"
            UPDATE [horses] SET [Name]=@Name,[FatherID]=@FatherID,[MotherID]=@MotherID,[Sex]=@Sex,[BirthDate]=@BirthDate,[Description]=@Description WHERE [HorseID]=@ID", conn);*/

        cmd.Parameters.AddWithValue("@id", Request.Form["ctl00$MainContent$rb"]);
        cmd.Parameters.AddWithValue("@name", Request.Form["ctl00$MainContent$HorseName"]);
        cmd.Parameters.AddWithValue("@fatherid", Request.Form["ctl00$MainContent$FatherName"]);
        cmd.Parameters.AddWithValue("@motherid", Request.Form["ctl00$MainContent$MotherName"]);
        cmd.Parameters.AddWithValue("@sex", Request.Form["ctl00$MainContent$sex"]);
        cmd.Parameters.AddWithValue("@birthdate", Request.Form["ctl00$MainContent$BirthDate"]);
        cmd.Parameters.AddWithValue("@description", Request.Form["ctl00$MainContent$description"]);
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
        rb.SelectedValue = Request.Form["ctl00$MainContent$rb"].ToString();
        //errorbox.InnerHtml = "Gelukt! ** Update **";
    }

    protected void InsertHorseDetails(object sender, EventArgs e)
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["Stal_Rondo"].ConnectionString;
        SqlConnection conn = new SqlConnection(ConnectionString);
        SqlCommand cmd = new SqlCommand("[dbo].[ADD_HORSE]", conn);
        
        cmd.Parameters.AddWithValue("@name", Request.Form["ctl00$MainContent$HorseName"]);
        cmd.Parameters.AddWithValue("@fatherid", Request.Form["ctl00$MainContent$FatherName"]);
        cmd.Parameters.AddWithValue("@motherid", Request.Form["ctl00$MainContent$MotherName"]);
        cmd.Parameters.AddWithValue("@sex", Request.Form["ctl00$MainContent$sex"]);
        cmd.Parameters.AddWithValue("@birthdate", Request.Form["ctl00$MainContent$BirthDate"]);
        cmd.Parameters.AddWithValue("@description", Request.Form["ctl00$MainContent$description"]);
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
            if(conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        rb.SelectedValue = "0";
        //errorbox.InnerHtml = "Gelukt! ** Toevoegen **";
    }
}