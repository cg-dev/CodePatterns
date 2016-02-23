<%@ Page Title="Simple page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Simple.aspx.cs" Inherits="Bootstrap.Simple" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <header>
            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1"
                            aria-expanded="false">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="#">Brand</a>
                    </div>

                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                        <ul class="nav navbar-nav">
                            <li class="active"><a href="#">Link <span class="sr-only">(current)</span></a></li>
                            <li><a href="#">Link</a></li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dropdown <span class="caret"></span></a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">Action</a></li>
                                    <li><a href="#">Another action</a></li>
                                    <li><a href="#">Something else here</a></li>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="#">Separated link</a></li>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="#">One more separated link</a></li>
                                </ul>
                            </li>
                        </ul>
                        <form class="navbar-form navbar-left" role="search">
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Search">
                            </div>
                            <button type="submit" class="btn btn-default">Submit</button>
                        </form>
                        <ul class="nav navbar-nav navbar-right">
                            <li><a href="#">Link</a></li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dropdown <span class="caret"></span></a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">Action</a></li>
                                    <li><a href="#">Another action</a></li>
                                    <li><a href="#">Something else here</a></li>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="#">Separated link</a></li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                    <!-- /.navbar-collapse -->
                </div>
                <!-- /.container-fluid -->
            </nav>
        </header>

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
        
        <div class="row">
            <section class="col-md-8">
                <h1>Page Title</h1>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse at magna sit amet lorem mollis iaculis et in nulla. 
                    In tristique orci et eros mattis venenatis. Vestibulum tincidunt placerat elementum. Vivamus cursus hendrerit quam, 
                    rutrum suscipit elit pharetra eu. Donec volutpat, augue at pulvinar pharetra, velit augue finibus nisi, vel vestibulum 
                    nibh urna a leo. Duis tincidunt sodales est id ultricies. Donec faucibus sapien a nisl feugiat tincidunt. Interdum et 
                    malesuada fames ac ante ipsum primis in faucibus. Vivamus rhoncus ipsum ut risus ultricies, a placerat mauris congue. 
                    Aenean viverra, tellus sit amet aliquam vulputate, ante tortor tempor lorem, ut eleifend ligula ligula nec ligula. 
                    Suspendisse eget urna id lorem sagittis vulputate. Mauris dapibus velit nulla, quis condimentum justo commodo in. In 
                    vel tincidunt ante. Phasellus vulputate, tortor vel pellentesque tincidunt, justo ex commodo odio, vel bibendum ligula 
                    mauris et mi. In efficitur est ut libero elementum vulputate. Nulla ac placerat quam.
                </p>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse at magna sit amet lorem mollis iaculis et in nulla. 
                    In tristique orci et eros mattis venenatis. Vestibulum tincidunt placerat elementum. Vivamus cursus hendrerit quam, 
                    rutrum suscipit elit pharetra eu. Donec volutpat, augue at pulvinar pharetra, velit augue finibus nisi, vel vestibulum 
                    nibh urna a leo. Duis tincidunt sodales est id ultricies. Donec faucibus sapien a nisl feugiat tincidunt. Interdum et 
                    malesuada fames ac ante ipsum primis in faucibus. Vivamus rhoncus ipsum ut risus ultricies, a placerat mauris congue. 
                    Aenean viverra, tellus sit amet aliquam vulputate, ante tortor tempor lorem, ut eleifend ligula ligula nec ligula. 
                    Suspendisse eget urna id lorem sagittis vulputate. Mauris dapibus velit nulla, quis condimentum justo commodo in. In 
                    vel tincidunt ante. Phasellus vulputate, tortor vel pellentesque tincidunt, justo ex commodo odio, vel bibendum ligula 
                    mauris et mi. In efficitur est ut libero elementum vulputate. Nulla ac placerat quam.
                </p>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse at magna sit amet lorem mollis iaculis et in nulla. 
                    In tristique orci et eros mattis venenatis. Vestibulum tincidunt placerat elementum. Vivamus cursus hendrerit quam, 
                    rutrum suscipit elit pharetra eu. Donec volutpat, augue at pulvinar pharetra, velit augue finibus nisi, vel vestibulum 
                    nibh urna a leo. Duis tincidunt sodales est id ultricies. Donec faucibus sapien a nisl feugiat tincidunt. Interdum et 
                    malesuada fames ac ante ipsum primis in faucibus. Vivamus rhoncus ipsum ut risus ultricies, a placerat mauris congue. 
                    Aenean viverra, tellus sit amet aliquam vulputate, ante tortor tempor lorem, ut eleifend ligula ligula nec ligula. 
                    Suspendisse eget urna id lorem sagittis vulputate. Mauris dapibus velit nulla, quis condimentum justo commodo in. In 
                    vel tincidunt ante. Phasellus vulputate, tortor vel pellentesque tincidunt, justo ex commodo odio, vel bibendum ligula 
                    mauris et mi. In efficitur est ut libero elementum vulputate. Nulla ac placerat quam.
                </p>
            </section>
            <aside class="col-md-4 my-sidebar">
                <div class="panel panel-default">
                    <div class="panel-heading">Pools</div>
                    <div class="panel-body">
                        <img src="Content/images/car%201.jpg" alt="The perfect pool" class="img-responsive"/>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">Golf</div>
                    <div class="panel-body">
                        <img src="Content/images/car%202.jpg" alt="Golf gree being mowed" class="img-responsive"/>
                    </div>
                </div>
            </aside>
        </div>
        
        <div class="row">
            <footer class="col-sm-12">
                <p class="text-center">&copy; copyright 2016</p>
            </footer>
        </div>
    </div>
</asp:Content>
