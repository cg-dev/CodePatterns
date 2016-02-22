<%@ Page Title="Jumbotrons & wells" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dropdown.aspx.cs" Inherits="Bootstrap.Dropdown" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <div class="dropdown">
                    <button class="btn btn-default dropdown-toggle" type="button" id="dropdownmenu" data-toggle="dropdown">
                        Dropdown
                        <span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" aria-labelledby="dropdown">
                       <li><a href="#">Menu item one</a></li> 
                       <li><a href="#">Menu item two</a></li> 
                       <li><a href="#">Menu item three</a></li> 
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>