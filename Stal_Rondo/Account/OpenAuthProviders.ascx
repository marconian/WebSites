<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OpenAuthProviders.ascx.cs" Inherits="OpenAuthProviders" %>

<div id="socialLoginList">
    <h4>Log in met een andere dienst.</h4>
    <hr />
    <asp:ListView runat="server" ID="providerDetails" ItemType="System.String"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <p>
                <button type="submit" class="btn btn-default" name="provider" value="<%#: Item %>"
                    title="Inloggen met je <%#: Item %>-account.">
                    <%#: Item %>
                </button>
            </p>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                <p>Er zijn geen externe diensten voor verificatie ingesteld. Zie <a href="http://go.microsoft.com/fwlink/?LinkId=252803">dit artikel</a> voor meer informatie over het opzetten van een ASP.NET applicatie om inloggen via externe diensten te ondersteunen.</p>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</div>