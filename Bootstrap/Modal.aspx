<%@ Page Title="Modal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modal.aspx.cs" Inherits="Bootstrap.Modal" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalContent">Click Me!</button>
                <div class="modal fade" id="modalContent" tabindex="-1">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h3>A Title</h3>
                            </div>
                            <div class="modal-body">
                                <p>Some stuff to appear in the body of the modal form</p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Hide Me!</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
