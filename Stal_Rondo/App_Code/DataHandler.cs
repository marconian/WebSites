using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public class HorseInfo : DataHandler
{
    internal int _horseID;
    internal int _fatherID;
    internal int _motherID;

    public int horseID
    {
        set { this._horseID = value; }
    }

    //public DataTable Father
    //{
    //    get { return getData("[horses]", "[HorseID]", _fatherID); }
    //}

    //public DataTable Mother
    //{
    //    get { return getData("[horses]", "[HorseID]", _motherID); }
    //}

    public DataTable Name
    {
        get
        {
            if (_horseID > 0)
            {
                return getData("[horses]", "[HorseID]", _horseID);
            }
            else
            {
                return null;
            }
        }
    }

}

public class HorseData : DataHandler
{
    internal int _sex;
    internal int _property;

    public int sex
    {
        set { this._sex = value; }
    }

    public int property
    {
        set { this._property = value; }
    }

    public DataTable AllHorses
    {
        get
        {
            return getData("[horses]");
        }
    }

    public DataTable OwnHorses
    {
        get
        {
            if (_property == 1)
            {
                return getData("[horses]", "[State]", _property);
            }
            else
            {
                return null;
            }
        }
    }

    public DataTable Stallions
    {
        get
        {
            return getData("[horses]", "[Sex]", 1);
        }
    }

    public DataTable Mares
    {
        get
        {
            return getData("[horses]", "[Sex]", 2);
        }
    }
}


/// <summary>
/// Summary description for DataHandler
/// </summary>
public abstract class DataHandler
{
    protected static DataTable getData(string TableName)
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["Stal_Rondo"].ConnectionString;
        SqlConnection conn = new SqlConnection(ConnectionString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM " + TableName, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        try
        {
            conn.Open();
            da.Fill(dt);
        }
        catch (SqlException ex)
        {
            string error = "Execute exception issue: " + ex;
        }
        catch (IndexOutOfRangeException ex)
        {
            string error = "Data not available. Issue: " + ex;
        }
        catch (InvalidOperationException ex)
        {
            string error = "Connection Exception issue: " + ex;
        }
        finally
        {
            conn.Close();
        }

        return dt;

    }
    protected static DataTable getData(string TableName, string RowName, int RowID)
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["Stal_Rondo"].ConnectionString;
        SqlConnection conn = new SqlConnection(ConnectionString);
        
        string cmdString = "SELECT * FROM " + TableName + " WHERE " + RowName + " = @RowID";
        SqlCommand cmd = new SqlCommand(cmdString, conn);
        cmd.Parameters.Add("@RowID", SqlDbType.Int);
        cmd.Parameters["@RowID"].Value = RowID;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        try
        {
            conn.Open();
            da.Fill(dt);
        }
        catch (SqlException ex)
        {
            string error = "Execute exception issue: " + ex;
        }
        catch (IndexOutOfRangeException ex)
        {
            string error = "Data not available. Issue: " + ex;
        }
        catch (InvalidOperationException ex)
        {
            string error = "Connection Exception issue: " + ex;
        }
        finally
        {
            conn.Close();
        }

        return dt;

    }
    protected static DataTable getData(string TableName, string RowName, string RowValue)
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["Stal_Rondo"].ConnectionString;
        SqlConnection conn = new SqlConnection(ConnectionString);
        
        string cmdString = "SELECT * FROM " + TableName + " WHERE " + RowName + " = @RowID";
        SqlCommand cmd = new SqlCommand(cmdString, conn);
        cmd.Parameters.Add("@RowID", SqlDbType.NVarChar);
        cmd.Parameters["@RowID"].Value = RowValue;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        try
        {
            conn.Open();
            da.Fill(dt);
        }
        catch (SqlException ex)
        {
            string error = "Execute exception issue: " + ex;
        }
        catch (IndexOutOfRangeException ex)
        {
            string error = "Data not available. Issue: " + ex;
        }
        catch (InvalidOperationException ex)
        {
            string error = "Connection Exception issue: " + ex;
        }
        finally
        {
            conn.Close();
        }

        return dt;
    }

    public static string ListHorses()
    {
        DataTable dt = getData("[horses]", "[State]", 1);
        StringBuilder builtString = new StringBuilder();
        builtString.Append("<ul class='nav nav-pills nav-stacked'>");
        int i = 0;
        string HorseRow = null;
        string classActive = null;
        foreach (DataRow row in dt.Rows)
        {
            i++;

            if (i == 1) { classActive = null; }
            else { classActive = null; }

            HorseRow = "<li class='" + classActive + "'><a data-toggle='modal' data-target='#" + row["HorseID"].ToString() + "'>" + row["Name"].ToString() + "</a></li>";

            builtString.Append(HorseRow);
        }
        builtString.Append("</ul>");

        string Horse = builtString.ToString();
        return Horse;
    }

    public static string ModalHorses()
    {
        DataTable dt = getData("[horses]", "[State]", 1);
        StringBuilder builtString = new StringBuilder();

        string ModalRow = null;

        foreach (DataRow row in dt.Rows)
        {
            int RowValue = Convert.ToInt32(row["HorseID"]);
            ModalRow = @"

            <div id='" + row["HorseID"].ToString() + @"' class='modal fade' role='dialog'>
                <div class='modal-dialog'>

                    <!-- Modal content-->
                    <div class='modal-content'>
                        <div class='modal-header'>
                            <button type='button' class='close' data-dismiss='modal'>&times;</button>
                            <h4 class='modal-title'>" + row["Name"].ToString() + @"</h4>
                        </div>
                        <div class='modal-body'>
                            <div class='container-fluid'>
                                <div class='row'>
                                    <div class='col-sm-12'>
                                        <img src='img/" + row["Image"].ToString() + @"' class='img-thumbnail' />
                                    </div>
                                </div>
                                <div class='row'>
                                    <div class='col-sm-12'>
                                        <ul class='nav nav-pills nav-justified'>
                                            <li class='active'><a data-toggle='pill' href='#general" + RowValue.ToString() + @"'>Algemeen</a></li>
                                            <li><a data-toggle='pill' href='#performance" + RowValue.ToString() + @"'>Prestaties</a></li>
                                            <li><a data-toggle='pill' href='#gallery" + RowValue.ToString() + @"'>Gallerij</a></li>
                                            <li><a data-toggle='pill' href='#father" + RowValue.ToString() + @"'>Vader</a></li>
                                            <li><a data-toggle='pill' href='#mother" + RowValue.ToString() + @"'>Moeder</a></li>
                                            <li><a data-toggle='pill' href='#decendants" + RowValue.ToString() + @"'>Afstammelingen</a></li>
                                        </ul>
                                        <div class='tab-content'>
                                            <div id='general" + RowValue.ToString() + @"' class='tab-pane fade in active'>"
                                                + row["Description"].ToString() +
                                            @"</div>
                                            <div id='performance" + RowValue.ToString() + @"' class='tab-pane fade'>
                                                <ul class='list-group'>";

            builtString.Append(ModalRow);

            DataTable dt_Performance = getData("[Performance]", "[HorseID]", RowValue);

            foreach (DataRow row_perf in dt_Performance.Rows)
            {
                ModalRow = @"
                                                    <li class='list-group-item'>
                                                        <div class='row'>
                                                            <div class='col-sm-2'>"
                                                                + row_perf["Year"].ToString() +
                                                            @"</div>
                                                            <div class='col-sm-4'>"
                                                                + row_perf["Location"].ToString() +
                                                            @"</div>
                                                            <div class='col-sm-4'>"
                                                                + row_perf["Description"].ToString() +
                                                            @"</div>
                                                            <div class='col-sm-2'>"
                                                                + row_perf["Type"].ToString() +
                                                            @"</div>
                                                        </div>
                                                    </li>
                                                ";
                builtString.Append(ModalRow);

            }


            ModalRow = @"
                                                </ul>
                                            </div>
                                            <div id='gallery" + RowValue.ToString() + @"' class='tab-pane fade'>

                                                <div id='SlideShow' class='carousel slide' data-ride='carousel'>
                                                    <ol class='carousel-indicators'>
                                                        <li data-target='#SlideShow' data-slide-to='0' class='active'></li>
                                                        <li data-target='#SlideShow' data-slide-to='1'></li>
                                                    </ol>
        
                                                    <div class='carousel-inner' role='listbox'>
                                                        <div class='item active'>
                                                            <img src='img/Casperhofs_Freddy.jpg' alt='Casperhof's Freddy' class='img-thumbnail' />
                                                        </div>

                                                        <div class='item'>
                                                            <img src='img/Springstars_Alexia.jpg' alt='Casperhof's Freddy' class='img-thumbnail' />
                                                        </div>
                                                    </div>

                                                    <a class='left carousel-control' href='#SlideShow' role='button' data-slide='prev'>
                                                        <span class='glyphicon glyphicon-chevron-left' aria-hidden='true'></span>
                                                        <span class='sr-only'>Vorige</span>
                                                    </a>
                                                    <a class='right carousel-control' href='#SlideShow' role='button' data-slide='next'>
                                                        <span class='glyphicon glyphicon-chevron-right' aria-hidden='true'></span>
                                                        <span class='sr-only'>Volgende</span>
                                                    </a>
	                                            </div>  
                                            </div>
                                            <div id='father" + RowValue.ToString() + @"' class='tab-pane fade'>
                                                <div class='row'>
                                                    <div class='col-sm-3'>
                                                        <a href='#' class='thumbnail'>
                                                            <img src='img/Wolbergs_Bart.jpg' />
                                                        </a>
                                                    </div>
                                                    <div class='col-sm-9'>
                                                        Informatie over de vader...
                                                        <br />
                                                        <a href='#'>Meer informatie...</a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id='mother" + RowValue.ToString() + @"' class='tab-pane fade'>
                                                <div class='row'>
                                                    <div class='col-sm-3'>
                                                        <img src='img/Turfhorst_Mandy.jpg' class='img-thumbnail' />
                                                    </div>
                                                    <div class='col-sm-9'>
                                                        Informatie over de moeder...
                                                        <br />
                                                        <a href='#'>Meer informatie...</a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id='decendants" + RowValue.ToString() + @"' class='tab-pane fade'>";

            builtString.Append(ModalRow);


            DataTable dt_Offspring = getData("[horses]", "[FatherID]", RowValue);

            foreach (DataRow row_off in dt_Offspring.Rows)
            {
                ModalRow = @"
                                                <div class='row'>
                                                    <div class='col-sm-3'>
                                                        <img src='img/" + row_off["Image"].ToString() + @"' class='img-thumbnail' />
                                                    </div>
                                                    <div class='col-sm-9'>
                                                        <h4>" + row_off["Name"].ToString() + @"</h4>
                                                        " + row_off["Description"].ToString() + @"
                                                    </div>
                                                </div>";
                builtString.Append(ModalRow);

            }


            ModalRow = @"
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class='modal-footer'>
                            <button type='button' class='btn btn-default' data-dismiss='modal'>Close</button>
                        </div>
                    </div>
                </div>
            </div>";

            builtString.Append(ModalRow);
        }


        string Modal = builtString.ToString();
        return Modal;
    }
}