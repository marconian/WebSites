<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Manage_Manage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Beheer Inventaris</h1>
    </div>
    <div class="container">
        <div class="form-group">
            <label class="control-label col-sm-2" for="rb">Selecteer: </label>
            <div class="col-sm-10">
                <asp:DropDownList ID="rb" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rb_SelectedIndexChanged"></asp:DropDownList>
                
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="HorseName">Naam: </label>
            <div class="col-sm-10">
                <asp:TextBox ID="HorseName" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="FatherName">Vader: </label>
            <div class="col-sm-10">
                <asp:DropDownList ID="FatherName" class="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="MotherName">Moeder: </label>
            <div class="col-sm-10">
                <asp:DropDownList ID="MotherName" class="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
                <label class="control-label col-sm-2" for="sex">Geslacht: </label>
                <div class="col-sm-10">
                    <asp:RadioButtonList ID="sex" runat="server">
                        <asp:ListItem Text="Hengst" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Merrie" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="BirthDate">Geboortedatum: </label>
            <div class="col-sm-10">
                <asp:TextBox ID="BirthDate" class="form-control" textmode="Date" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="description">Beschrijving:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="description" class="form-control" Rows="5" runat="server" TextMode="MultiLine"></asp:TextBox>
                 <div id="errorbox" runat="server"></div>
            </div>
        </div>
        <div class="form-group">
            <asp:Button id="insert" class="btn btn-default" text="Toevoegen" runat="server" OnClick="InsertHorseDetails" />
            <asp:Button id="update" class="btn btn-default" text="Bijwerken" runat="server" OnClick="UpdateHorseDetails" />
            <asp:Button id="delete" class="btn btn-default" text="Verwijderen" runat="server" OnClick="DeleteHorseDetails" />
        </div>
    </div>
</asp:Content>