<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IVATest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>IVA Test</h1>
        <p class="lead">A search page that searches IVA oData API 2.0, displays the search results and when a result is clicked/selected, displays an embedded video player using IVA Free Video API</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Enter Search Text</h2>
            <p>
                <asp:TextBox ID="SearchText" runat="server" Height="23px" Width="229px"></asp:TextBox>
                
            </p>
            <p>
                <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="Button1_Click" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Results</h2>
            <p>
                Click to view video.</p>
            <p>
                <asp:ListBox ID="SearchResultsListBox" runat="server" Height="153px" OnSelectedIndexChanged="SearchResultsListBox_Click" Width="238px"></asp:ListBox>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Player</h2>
            <p>
                <IFRAME id="frame1" src=""  runat="server">
            </p>
            <p>
                
            </p>
        </div>
    </div>

</asp:Content>
