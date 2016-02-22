<%@ Page Title="Buttons" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="Bootstrap.Form" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h2>Basic form</h2>
                <form action="#" method="post">
                    <div class="form-group">
                        <label for="email">Email Address</label>
                        <input type="email" class="form-control" id="email" />
                    </div>
                    <div class="form-group">
                        <label for="password">Password</label>
                        <input type="password" class="form-control" id="password" />
                    </div>
                    <div class="form-group">
                        <label for="file">File</label>
                        <input type="file" id="file" />
                    </div>
                    <div class="form-group">
                        <input type="submit" id="submit" class="btn btn-default" value="Submit" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>