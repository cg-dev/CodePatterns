<%@ Page Title="Buttons" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Button.aspx.cs" Inherits="Bootstrap.Button" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row">
            <div class="col-xs-6">
                <p>Anchor tag defind as a default button <a class="btn btn-default" href="#">link</a></p>
                <p>Button defined as a default button <button class="btn btn-default"> Button </button> (used to run javascript)</p>
                <p>Input button defined as a default button <input class="btn btn-default" type="button" value="Input" /> (used in forms)</p>
                <p>Submit button defined as a default button <input class="btn btn-default" type="submit" value="Submit" /> (used in forms)</p>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-6">
                <p>Button defined as a default button <button class="btn btn-default"> Button </button></p>
                <p>Button defined as a primary button <button class="btn btn-primary"> Button </button></p>
                <p>Button defined as a sucess button <button class="btn btn-success"> Button </button></p>
                <p>Button defined as a danger button <button class="btn btn-danger"> Button </button></p>
                <p>Button defined as a warning button <button class="btn btn-warning"> Button </button></p>
                <p>Button defined as an info button <button class="btn btn-info"> Button </button></p>
                <p>Button defined as a link button <button class="btn btn-link"> Button </button></p>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-6">
                <p>Button defined as a default button <button class="btn btn-default"> Button </button></p>
                <p>Button defined as a large button <button class="btn btn-default btn-lg"> Button </button></p>
                <p>Button defined as a small button <button class="btn btn-default btn-sm"> Button </button></p>
                <p>Button defined as an extra small button <button class="btn btn-default btn-xs"> Button </button></p>
            </div>
        </div>
    </div>
</asp:Content>