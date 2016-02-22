<%@ Page Title="Navigation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Navigation.aspx.cs" Inherits="Bootstrap.Navigation" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <p>Tabbed navigation</p>
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#">Home</a></li>
                    <li><a href="#">Profile</a></li>
                    <li><a href="#">Messages</a></li>
                </ul>
                <p>Pills navigation</p>
                <ul class="nav nav-pills">
                    <li><a href="#">Home</a></li>
                    <li class="active"><a href="#">Profile</a></li>
                    <li><a href="#">Messages</a></li>
                    <li><a href="#" class="dropdown-toggle" data-toggle="dropdown">Dropdown <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="#">Item 1</a></li>
                            <li><a href="#">Item 2</a></li>
                            <li><a href="#">Item 3</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>