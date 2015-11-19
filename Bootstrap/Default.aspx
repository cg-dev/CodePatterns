<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bootstrap2._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h1>Hello World!</h1>
    <div class="container">
        <!--To keep columns on one line, their class numbers should add up to 12-->
        <!--Row with two equal columns-->
        <div class="row">
            <div class="col-sm-6">Left column (1:1)</div>
            <div class="col-sm-6">Right column</div>
        </div>
        <!--Row with two columns split 1:2-->
        <div class="row">
            <div class="col-sm-4">Left column (1:2)</div>
            <div class="col-sm-8">Right column</div>
        </div>
        <!--Row with two columns split 1:3-->
        <div class="row">
            <div class="col-sm-3">Left column (1:3)</div>
            <div class="col-sm-9">Right column</div>
        </div>
        <!--Row with three equal columns-->
        <div class="row">
            <div class="col-md-4">Column left (1:1:1)</div>
            <div class="col-md-4">Column middle</div>
            <div class="col-md-4">Column right</div>
        </div>
        <!--Row with three columns divided in 1:4:1 ratio-->
        <div class="row">
            <div class="col-md-2">Column left (1:4:1)</div>
            <div class="col-md-8">Column middle</div>
            <div class="col-md-2">Column right</div>
        </div>
        <!--Row with three columns divided unevenly-->
        <div class="row">
            <div class="col-md-3">Column left (3:7:2)</div>
            <div class="col-md-7">Column middle</div>
            <div class="col-md-2">Column right</div>
        </div>
    </div>
    <p>The end....</p>

</asp:Content>
