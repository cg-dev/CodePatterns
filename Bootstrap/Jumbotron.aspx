<%@ Page Title="Jumbotrons & wells" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Jumbotron.aspx.cs" Inherits="Bootstrap.Jumbotron" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <div class="jumbotron">
                    <p>Hello there. This a jumbotron, did it catch your eye?</p>
                </div>
                
                <div class="well">
                    <p>This is a paragraph inside a well.</p>
                </div>
                <p>This is an ordinary paragraph.</p>
            </div>
        </div>
    </div>
</asp:Content>