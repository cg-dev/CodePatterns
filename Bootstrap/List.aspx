<%@ Page Title="Buttons" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Bootstrap.List" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row">
            <div class="col-xs-3">
                <ul class="list-group">
                    <li class="list-group-item active"><span class="badge">14</span>Apple</li>
                    <li class="list-group-item disabled">Orange</li>
                    <li class="list-group-item list-group-item-success">Banana</li>
                    <li class="list-group-item">Mango</li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>