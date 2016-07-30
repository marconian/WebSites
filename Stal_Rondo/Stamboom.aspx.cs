using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Stamboom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HorseData horseList = new HorseData();
        horseList.property = 1;


        // mainlist
        BulletedList list = new BulletedList();
        list.DisplayMode = BulletedListDisplayMode.HyperLink;
        list.CssClass = "nav nav-pills nav-stacked";
        list.ID = "horseslist";

        foreach (DataRow horse in horseList.OwnHorses.Rows)
        {
            string HorseID = horse["HorseID"].ToString();
            string FatherID = horse["FatherID"].ToString();
            string MotherID = horse["MotherID"].ToString();
            string Name = horse["Name"].ToString();
            string Picture = horse["Image"].ToString();
            string Description = horse["Description"].ToString();

            List<Navlist> navtabs = new List<Navlist>();
            navtabs.Add(new Navlist() { urltext = "general", title = "Algemeen", context = ModalTabs.tabGeneral(HorseID, Description) });
            navtabs.Add(new Navlist() { urltext = "performance", title = "Prestaties", context = ModalTabs.tabPerformance(HorseID) });
            navtabs.Add(new Navlist() { urltext = "gallery", title = "Gallerij", context = ModalTabs.tabGallery(HorseID) });
            navtabs.Add(new Navlist() { urltext = "father", title = "Vader", context = ModalTabs.tabFather(HorseID, FatherID) });
            navtabs.Add(new Navlist() { urltext = "mother", title = "Moeder", context = ModalTabs.tabMother(HorseID, MotherID) });
            navtabs.Add(new Navlist() { urltext = "decendants", title = "Afstammelingen", context = ModalTabs. tabDecendants(HorseID) });

            //modal objects
            Panel infopanel = new Panel();
            Panel modaldialog = new Panel();
            Panel modalcontent = new Panel();
            Panel modalheader = new Panel();
            Panel modalbody = new Panel();
            Panel modalfooter = new Panel();

            //modal screen
            infopanel.ID = HorseID;
            infopanel.CssClass = "modal fade";
            infopanel.Attributes.Add("role", "dialog");

            modaldialog.CssClass = "modal-dialog";
            modalcontent.CssClass = "modal-content";
            modalheader.CssClass = "modal-header";
            modalbody.CssClass = "modal-body";
            modalfooter.CssClass = "modal-footer";

            infopanel.Controls.Add(modaldialog);
            modaldialog.Controls.Add(modalcontent);
            modalcontent.Controls.Add(modalheader);
            modalcontent.Controls.Add(modalbody);
            modalcontent.Controls.Add(modalfooter);

            //modal-header
            HtmlGenericControl headerbutton = new HtmlGenericControl("button");
            headerbutton.Attributes.Add("class", "close");
            headerbutton.Attributes.Add("data-dismiss", "modal");
            headerbutton.InnerHtml = "&times;";

            HtmlGenericControl headertitle = new HtmlGenericControl("h4");
            headertitle.Attributes.Add("class", "modal-title");
            headertitle.InnerText = Name;

            modalheader.Controls.Add(headerbutton);
            modalheader.Controls.Add(headertitle);

            //modal-body
            Panel bodycontainer = new Panel();
            bodycontainer.CssClass = "container-fluid";
            modalbody.Controls.Add(bodycontainer);

            //picture row
            Panel bodypicrow = new Panel();
            Panel bodypiccol = new Panel();
            bodypicrow.CssClass = "row";
            bodypiccol.CssClass = "col-sm-12";

            Image basepic = new Image();
            basepic.CssClass = "img-thumbnail";
            basepic.ImageUrl = "img/" + Picture;

            bodycontainer.Controls.Add(bodypicrow);
            bodypicrow.Controls.Add(bodypiccol);
            bodypiccol.Controls.Add(basepic);

            //navigation row
            Panel bodynavrow = new Panel();
            Panel bodynavcol = new Panel();
            Panel bodytabcontent = new Panel();
            bodynavrow.CssClass = "row";
            bodynavcol.CssClass = "col-sm-12";
            bodytabcontent.CssClass = "tab-content";

            HtmlGenericControl modalnav = new HtmlGenericControl("ul");
            modalnav.Attributes.Add("class", "nav nav-pills nav-justified");

            bodycontainer.Controls.Add(bodynavrow);
            bodynavrow.Controls.Add(bodynavcol);
            bodynavcol.Controls.Add(modalnav);

            int i = 0;
            foreach (Navlist nav in navtabs)
            {
                HtmlGenericControl navtab = new HtmlGenericControl("li");
                if (i == 0) { i = 1; navtab.Attributes.Add("class", "active"); }
                navtab.InnerHtml = "<a data-toggle='pill' href='#MainContent_" + nav.urltext + HorseID + "'>" + nav.title + "</a>";
                modalnav.Controls.Add(navtab);
                bodytabcontent.Controls.Add(nav.context);    

            }

            bodynavcol.Controls.Add(bodytabcontent);
            


            horsesinfo.Controls.Add(infopanel);

            //item list
            ListItem item = new ListItem(Name);
            item.Attributes.Add("data-toggle", "modal");
            item.Attributes.Add("data-target", "#" + infopanel.ClientID);
            list.Items.Add(item);


        }

        horselist.Controls.Add(list);

    }
}

public class Navlist : IEquatable<Navlist>
{
    public string urltext { get; set; }
    public string title { get; set; }
    public Panel context { get; set; }

    public bool Equals(Navlist other)
    {
        throw new NotImplementedException();
    }
}
