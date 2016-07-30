using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

/// <summary>
/// Tabs for horse information page
/// </summary>
public class ModalTabs
{

    /// <summary>
    /// Tab filler for the general information tab
    /// </summary>
    /// <param name="HorseID">ID of the horse.</param>
    /// <param name="Description">Description of the horse.</param>
    /// <returns>Returns the general tab HttpControl for the horse information page.</returns>
    public static Panel tabGeneral(string HorseID, string Description)
    {
        Panel container = new Panel();
        container.CssClass = "tab-pane fade in active";
        container.ID = "general" + HorseID;

        HtmlGenericControl content = new HtmlGenericControl("div");
        content.InnerText = Description;

        container.Controls.Add(content);
        return container;
    }

    /// <summary>
    /// Tab filler for the performance information tab
    /// </summary>
    /// <param name="HorseID">ID of the horse.</param>
    /// <returns>Returns the performance tab HttpControl for the horse information page.</returns>
    public static Panel tabPerformance(string HorseID)
    {
        DataTable dt_Performance = Horses.getData("[Performance]", "[HorseID]", HorseID);
        Panel container = new Panel();
        container.CssClass = "tab-pane fade in";
        container.ID = "performance" + HorseID;
        HtmlGenericControl content = new HtmlGenericControl("ul");
        content.Attributes.Add("class", "list-group");

        foreach (DataRow row_perf in dt_Performance.Rows)
        {
            HtmlGenericControl contentrow = new HtmlGenericControl("li");
            contentrow.Attributes.Add("class", "list-group-item");
            contentrow.InnerHtml = @"
                <div class='row'>
                    <div class='col-sm-2'>" + row_perf["Year"].ToString() + @"</div>
                    <div class='col-sm-4'>" + row_perf["Location"].ToString() + @"</div>
                    <div class='col-sm-4'>" + row_perf["Description"].ToString() + @"</div>
                    <div class='col-sm-2'>" + row_perf["Type"].ToString() + @"</div>
                </div>";
            content.Controls.Add(contentrow);
        }
        container.Controls.Add(content);
        return container;
    }

    /// <summary>
    /// Tab filler for the gallery information tab
    /// </summary>
    /// <param name="HorseID">ID of the horse.</param>
    /// <returns>Returns the gallery tab HttpControl for the horse information page.</returns>
    public static Panel tabGallery(string HorseID)
    {
        DataTable dt = Horses.getData("[Gallery]", "[HorseID]", HorseID);
        Panel container = new Panel();
        container.CssClass = "tab-pane fade in";
        container.ID = "gallery" + HorseID;

        HtmlGenericControl content = new HtmlGenericControl("div");
        content.Attributes.Add("class", "SlideShow");


        foreach (DataRow row in dt.Rows)
        {
            string ImgID = row.Field<Int64>("ImgID").ToString();
            HtmlGenericControl photocontainer = new HtmlGenericControl("div");
            photocontainer.Attributes.Add("class", "photo");
            //photo.Attributes.Add("style", "background-image: url(/galleryimg.ashx?img=" + ImgID + ")");
            Image gallImg = new Image();
            gallImg.CssClass = "thumbnail";
            gallImg.ImageUrl = "/galleryimg.ashx?img=" + ImgID;
            photocontainer.Controls.Add(gallImg);
            content.Controls.Add(photocontainer);

        }

        container.Controls.Add(content);
        return container;
    }

    /// <summary>
    /// Tab filler for the father information tab
    /// </summary>
    /// <param name="HorseID">ID of the horse.</param>
    /// <param name="FatherID">ID of the father.</param>
    /// <returns>Returns the father tab HttpControl for the horse information page.</returns>
    public static Panel tabFather(string HorseID, string FatherID)
    {
        DataTable dt_Father = Horses.getData("[horses]", "[HorseID]", FatherID);
        string Image = ""; string Description = "";

        Panel container = new Panel();
        container.CssClass = "tab-pane fade in";
        container.ID = "father" + HorseID;

        if (dt_Father.Rows.Count > 0)
        {
            Image = dt_Father.Rows[0].Field<string>("Image");
            Description = dt_Father.Rows[0].Field<string>("Description");

            HtmlGenericControl content = new HtmlGenericControl("div");
            HtmlGenericControl imgdiv = new HtmlGenericControl("div");
            HtmlGenericControl infodiv = new HtmlGenericControl("div");
            content.Attributes.Add("class", "row");
            imgdiv.Attributes.Add("class", "col-sm-3");
            infodiv.Attributes.Add("class", "col-sm-9");

            HyperLink imglink = new HyperLink();
            Image profilepic = new Image();
            profilepic.ImageUrl = "img/" + Image;
            profilepic.Width = 100;

            imglink.NavigateUrl = "#";
            imglink.Attributes.Add("class", "thumbnail");
            imglink.Controls.Add(profilepic);
            imgdiv.Controls.Add(imglink);

            infodiv.InnerHtml = Description;
            content.Controls.Add(imgdiv);
            content.Controls.Add(infodiv);

            //content.InnerHtml = @"
            //        <div class='col-sm-3'>
            //            <a href='#' class='thumbnail'>
            //                <img src='img/Wolbergs_Bart.jpg' />
            //            </a>
            //        </div>
            //        <div class='col-sm-9'>
            //            Informatie over de vader...
            //            <br />
            //            <a href='#'>Meer informatie...</a>
            //        </div>";

            container.Controls.Add(content);
        }

        return container;
    }
    /// <summary>
    /// Tab filler for the mother information tab
    /// </summary>
    /// <param name="HorseID">ID of the horse.</param>
    /// <param name="MotherID">ID of the mother.</param>
    /// <returns>Returns the mother tab HttpControl for the horse information page.</returns>

    public static Panel tabMother(string HorseID, string MotherID)
    {
        DataTable dt_Mother = Horses.getData("[horses]", "[HorseID]", MotherID);
        string Image = ""; string Description = "";

        Panel container = new Panel();
        container.CssClass = "tab-pane fade in";
        container.ID = "mother" + HorseID;

        if (dt_Mother.Rows.Count > 0)
        {
            Image = dt_Mother.Rows[0].Field<string>("Image");
            Description = dt_Mother.Rows[0].Field<string>("Description");

            HtmlGenericControl content = new HtmlGenericControl("div");
            HtmlGenericControl imgdiv = new HtmlGenericControl("div");
            HtmlGenericControl infodiv = new HtmlGenericControl("div");
            content.Attributes.Add("class", "row");
            imgdiv.Attributes.Add("class", "col-sm-3");
            infodiv.Attributes.Add("class", "col-sm-9");

            HyperLink imglink = new HyperLink();
            Image profilepic = new Image();
            profilepic.ImageUrl = "img/" + Image;
            profilepic.Width = 100;

            imglink.NavigateUrl = "#";
            imglink.Attributes.Add("class", "thumbnail");
            imglink.Controls.Add(profilepic);
            imgdiv.Controls.Add(imglink);

            infodiv.InnerHtml = Description;
            content.Controls.Add(imgdiv);
            content.Controls.Add(infodiv);

            container.Controls.Add(content);
        }

        return container;
    }
    /// <summary>
    /// Tab filler for the decendants information tab
    /// </summary>
    /// <param name="HorseID">ID of the horse.</param>
    /// <returns>Returns the decendants tab HttpControl for the horse information page.</returns>

    public static Panel tabDecendants(string HorseID)
    {
        DataTable dt_Offspring = Horses.getData("[horses]", "[FatherID]", HorseID);
        Panel container = new Panel();
        container.CssClass = "tab-pane fade in";
        container.ID = "decendants" + HorseID;

        foreach (DataRow row_off in dt_Offspring.Rows)
        {
            HtmlGenericControl contentrow = new HtmlGenericControl("div");
            contentrow.Attributes.Add("class", "row");
            contentrow.InnerHtml = @"
                        <div class='col-sm-3'>
                            <img src='img/" + row_off["Image"].ToString() + @"' class='img-thumbnail' />
                        </div>
                        <div class='col-sm-9'>
                            <h4>" + row_off["Name"].ToString() + @"</h4>
                            " + row_off["Description"].ToString() + @"
                        </div>";
            container.Controls.Add(contentrow);
        }
        return container;
    }
}