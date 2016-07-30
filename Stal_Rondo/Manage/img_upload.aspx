<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="img_upload.aspx.cs" Inherits="Manage_img_upload" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Beheer Inventaris</h1>
    </div>
    <div class="container">
        <div class="form-group">
            <label class="control-label col-sm-2" for="rb">Selecteer Pony: </label>
            <div class="col-sm-10">
                <asp:DropDownList ID="rb" class="form-control" runat="server"></asp:DropDownList>
                
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="description">Beschrijving: </label>
            <div class="col-sm-10">
                <asp:TextBox ID="description" class="form-control" Rows="5" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="description">Afbeelding: </label>
            <div class="col-sm-10">
                <asp:FileUpload runat="server" ID="imgInput" />
            </div>
        </div>
        <div class="form-group">
                <asp:Button id="upload" CssClass="btn btn-default" text="Toevoegen" runat="server" OnClick="UploadIMGtoGallery" />
            <div id="errorbox" runat="server"></div>
        </div>

    </div>



</asp:Content>