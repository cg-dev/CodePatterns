<%@ Page Title="Images" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Image.aspx.cs" Inherits="Bootstrap.Image" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-xs-6">
                <img src="Content/images/robot.jpg" class="img-responsive" />
                <p>Uses img-responsive</p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <img src="Content/images/robot.jpg" class="img-responsive img-circle" />
                <p>Uses img-circle</p>
            </div>
            <div class="col-md-4">
                <img src="Content/images/robot.jpg" class="img-responsive img-rounded" />
                <p>Uses img-rounded</p>
            </div>
            <div class="col-md-4">
                <img src="Content/images/robot.jpg" class="img-responsive img-thumbnail" />
                <p>Uses img-thumbnail</p>
            </div>
        </div>
    </div>
</asp:Content>