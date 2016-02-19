<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bootstrap2._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container-fluid">
        <h1>CodePatterns <small>Learning To Control Layout With Bootstrap</small></h1>
        <button class="btn btn-success" onclick="$(this).hide();">Click me!</button>
        <!--To keep columns on one line, their class numbers should add up to 12-->
        <!--Row with two equal columns-->
        <div class="row">
            <div class="col-md-6">Left column (6:6)</div>
            <div class="col-md-6">Right column</div>
        </div>
        <!--Row with two columns split 1:5-->
        <div class="row">
            <div class="col-md-2">Left column (2:10)</div>
            <div class="col-md-10 hidden-md"> <%--Can be hidden for medium sized screens--%>
                Right column
                    <div class="row">
                        <div class="col-md-6">Inner Left column (6:6)</div>
                        <div class="col-md-6">Inner Right column</div>
                    </div>
            </div>
        </div>
        <!--Row with two columns split 2:5:5-->
        <div class="row">
            <div class="col-md-2">Left column (2:5:5)</div>
            <div class="col-md-5">Middle column</div>
            <div class="col-md-5">
                <span class="glyphicon glyphicon-music"></span> Music icon
            </div>
        </div>
    </div>
</asp:Content>