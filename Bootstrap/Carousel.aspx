<%@ Page Title="Carousel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carousel.aspx.cs" Inherits="Bootstrap.Carousel" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <div id="mySlider" class="carousel slide" data-ride="carousel">
                    <!-- indicators dot nav -->
                    <ol class="carousel-indicators">
                        <li data-target="#mySlider" data-slide-to="0" class="active"></li>
                        <li data-target="#mySlider" data-slide-to="1"></li>
                        <li data-target="#mySlider" data-slide-to="2"></li>
                        <li data-target="#mySlider" data-slide-to="3"></li>
                        <li data-target="#mySlider" data-slide-to="4"></li>
                    </ol>
                    
                    <div class="carousel-inner" role="listbox">
                        <div class="item active">
                            <img src="Content/images/car%201.jpg" alt="The perfect swimming pool" />
                            <div class="carousel-caption">
                                <h1>The perfect pool</h1>
                            </div>
                        </div>
                        <div class="item">
                            <img src="Content/images/car%202.jpg" alt="Mower on golf green" />
                            <div class="carousel-caption">
                                <h1>The last green</h1>
                            </div>
                        </div>
                        <div class="item">
                            <img src="Content/images/car%203.jpg" alt="Balloons flying high" />
                            <div class="carousel-caption">
                                <h1>High fliers</h1>
                            </div>
                        </div>
                        <div class="item">
                            <img src="Content/images/car%204.jpg" alt="A cat lying down" />
                            <div class="carousel-caption">
                                <h1>Such innocence!</h1>
                            </div>
                        </div>
                        <div class="item">
                            <img src="Content/images/car%205.jpg" alt="Sunset over water" />
                            <div class="carousel-caption">
                                <h1>Sun down</h1>
                            </div>
                        </div>
                    </div>
                    
                    <a class="left carousel-control" href="#mySlider" role="button" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#mySlider" role="button" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
