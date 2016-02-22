<%@ Page Title="Buttons" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InlineForm.aspx.cs" Inherits="Bootstrap.InlineForm" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row table-bordered">
            <div class="col-xs-12">
                <h2>Inline form</h2>
                <form action="#" method="post" class="form-inline">
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
                        <input type="file" id="file" class="btn btn-default" />
                    </div>
                    <div class="form-group">
                        <input type="submit" id="submit" class="btn btn-default" value="Submit" />
                    </div>
                </form>
            </div>
        </div>
        <div class="row table-bordered">
            <div class="col-xs-12">
                <h2>Horizontal form</h2>
                <form action="#" method="post" class="form-horizontal">
                    <div class="form-group">
                        <label for="email" class="col-sm-2 control-label">Email Address</label>
                        <div class="col-sm-10">
                            <input type="email" class="form-control" id="email" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="password" class="col-sm-2 control-label">Password</label>
                        <div class="col-sm-10">
                            <input type="password" class="form-control" id="password" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="file" class="col-sm-2 control-label">File</label>
                        <div class="col-sm-10">
                            <input type="file" id="file" class="btn btn-default" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-10 col-sm-push-2">
                            <input type="submit" id="submit" class="btn btn-default" value="Submit" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>