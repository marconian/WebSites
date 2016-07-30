<%@ Page Title="Stamboom" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Stamboom.aspx.cs" Inherits="Stamboom" %>

<asp:Content ContentPlaceHolderID="BaseContent" runat="server">
    <style type="text/css">
        .photo
        {
            background-color: #fff
            /*width: 100%;
            height: 450px;*/;
            /*background-position: center;
            background-repeat: no-repeat;
            border-top: 1px solid #aaa;
            border-bottom: 1px solid #aaa;*/
        }
    </style>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $('.SlideShow').jqxScrollView({
                width: "100%",
                height: 450,
                slideDuration: 4000,
                slideShow: true,
                buttonsOffset: [0, -400]
            });
        });

    </script>
    <asp:SqlDataSource ID="Sql_Horses" runat="server" ConnectionString="<%$ ConnectionStrings:Stal_Rondo %>" ProviderName="<%$ ConnectionStrings:Stal_Rondo.ProviderName %>" SelectCommand="SELECT [Name] FROM [horses]"></asp:SqlDataSource>
    <div class="page-header">
        <h1>Overzicht Hengsten</h1>
    </div>
    
    <div class="container">
        <div id="horselist" runat="server"></div>
        <div id="horsesinfo" runat="server"></div>
    </div>

</asp:Content>