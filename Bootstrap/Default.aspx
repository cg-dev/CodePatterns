<%@ Page Title="Bootstrap - The Responsive Grid" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bootstrap._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
              <h1>This is a header <small>Secondary text</small></h1>
                <p class="lead">This is a leading paragraph</p>
                <p>This is a normal paragraph</p>
                <p><small>This might be fine print</small></p>
            </div>
            <div class="col-xs-12">
                You can <mark>highlight</mark> text using <mark>mark</mark>
                <del>This text is crossed out</del>
                <s>Stricken text</s>
            </div>
            <div class="col-xs-12">
                <p class="text-left">Left aligned text</p>
                <p class="text-center">Centred text</p>
                <p class="text-right">Right aligned text</p>
                <p class="text-justify">Justified text</p>
            </div>
            <div class="col-xs-12">
                <p class="text-lowercase">THIS IS TYPED IN UPPERCASE BUT SHOULD APPEAR AS LOWERCASE.</p>
                <p class="text-uppercase">This was typed in lower case. But guess what!</p>
                <blockquote class="blockquote-reverse">
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse at magna sit amet lorem mollis iaculis et in nulla. 
                        In tristique orci et eros mattis venenatis. Vestibulum tincidunt placerat elementum. Vivamus cursus hendrerit quam, 
                        rutrum suscipit elit pharetra eu. Donec volutpat, augue at pulvinar pharetra, velit augue finibus nisi, vel vestibulum 
                        nibh urna a leo. Duis tincidunt sodales est id ultricies. Donec faucibus sapien a nisl feugiat tincidunt. Interdum et 
                        malesuada fames ac ante ipsum primis in faucibus. Vivamus rhoncus ipsum ut risus ultricies, a placerat mauris congue. 
                        Aenean viverra, tellus sit amet aliquam vulputate, ante tortor tempor lorem, ut eleifend ligula ligula nec ligula. Suspendisse 
                        eget urna id lorem sagittis vulputate. Mauris dapibus velit nulla, quis condimentum justo commodo in. In vel tincidunt ante. 
                        Phasellus vulputate, tortor vel pellentesque tincidunt, justo ex commodo odio, vel bibendum ligula mauris et mi. In efficitur 
                        est ut libero elementum vulputate. Nulla ac placerat quam.</p>
                    <footer>Someone famous</footer>
                </blockquote>
            </div>
        </div>
    </div>
</asp:Content>