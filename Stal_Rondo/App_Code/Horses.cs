using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// Base class for Horses Base Class
/// </summary>
public class Horses
{
    public static DataTable getData(string TableName)
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["Stal_Rondo"].ConnectionString;
        SqlConnection conn = new SqlConnection(ConnectionString);

        conn.Open();
        string cmdString = "SELECT * FROM " + TableName;
        SqlCommand cmd = new SqlCommand(cmdString, conn);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();

        return dt;

    }
    public static DataTable getData(string TableName, string RowName, int RowID)
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["Stal_Rondo"].ConnectionString;
        SqlConnection conn = new SqlConnection(ConnectionString);

        conn.Open();
        string cmdString = "SELECT * FROM " + TableName + " WHERE " + RowName + " = @RowID";
        SqlCommand cmd = new SqlCommand(cmdString, conn);
        cmd.Parameters.Add("@RowID", SqlDbType.Int);
        cmd.Parameters["@RowID"].Value = RowID;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();

        return dt;

    }
    public static DataTable getData(string TableName, string RowName, string RowValue)
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["Stal_Rondo"].ConnectionString;
        SqlConnection conn = new SqlConnection(ConnectionString);

        conn.Open();
        string cmdString = "SELECT * FROM " + TableName + " WHERE " + RowName + " = @RowID";
        SqlCommand cmd = new SqlCommand(cmdString, conn);
        cmd.Parameters.Add("@RowID", SqlDbType.NVarChar);
        cmd.Parameters["@RowID"].Value = RowValue;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();

        return dt;

    }

    public static DataTable HorseNames()
    {
        DataTable dt = getData("[horses]");
        return dt;
    }

    public static DataTable ParentNames(int Sex)
    {
        DataTable dt = getData("[horses]", "[Sex]", Sex);
        return dt;
    }

    public static DataTable HorseData(int HorseID)
    {
        DataTable dt = getData("[horses]", "[HorseID]", HorseID);

        return dt;
    }
}