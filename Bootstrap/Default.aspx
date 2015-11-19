<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bootstrap2._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <h1>Learning To Control Layout With Bootstrap</h1>
        <!--To keep columns on one line, their class numbers should add up to 12-->
        <!--Row with two equal columns-->
        <div class="row">
            <div class="col-sm-6">Left column (6:6)</div>
            <div class="col-sm-6">Right column</div>
        </div>
        <!--Row with two columns split 1:2-->
        <div class="row">
            <div class="col-sm-4">Left column (4:8)</div>
            <div class="col-sm-8">Right column</div>
        </div>
        <!--Row with two columns split 1:3-->
        <div class="row">
            <div class="col-sm-3">Left column (3:9)</div>
            <div class="col-sm-9">Right column</div>
        </div>
        <!--Row with three equal columns-->
        <div class="row">
            <div class="col-md-4">Column left (4:4:4)</div>
            <div class="col-md-4">Column middle</div>
            <div class="col-md-4">Column right</div>
        </div>
        <!--Row with three columns divided in 1:4:1 ratio-->
        <div class="row">
            <div class="col-md-2">Column left (2:8:2)</div>
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
</asp:Content>