<%@ Page Title="Collapse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Collapse.aspx.cs" Inherits="Bootstrap.Collapse" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <button class="btn btn-primary" data-toggle="collapse" data-target="#content">Click Me!</button>
                <div class="collapse" id="content">
                    <div class="well">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse at magna sit amet lorem mollis iaculis et in nulla. 
                        In tristique orci et eros mattis venenatis. Vestibulum tincidunt placerat elementum. Vivamus cursus hendrerit quam, 
                        rutrum suscipit elit pharetra eu. Donec volutpat, augue at pulvinar pharetra, velit augue finibus nisi, vel vestibulum 
                        nibh urna a leo. Duis tincidunt sodales est id ultricies. Donec faucibus sapien a nisl feugiat tincidunt. Interdum et 
                        malesuada fames ac ante ipsum primis in faucibus. Vivamus rhoncus ipsum ut risus ultricies, a placerat mauris congue. 
                        Aenean viverra, tellus sit amet aliquam vulputate, ante tortor tempor lorem, ut eleifend ligula ligula nec ligula. Suspendisse 
                        eget urna id lorem sagittis vulputate. Mauris dapibus velit nulla, quis condimentum justo commodo in. In vel tincidunt ante. 
                        Phasellus vulputate, tortor vel pellentesque tincidunt, justo ex commodo odio, vel bibendum ligula mauris et mi. In efficitur 
                        est ut libero elementum vulputate. Nulla ac placerat quam.
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
