<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Home" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <link href="Services/css/style.css" rel="stylesheet" />

    <script src="Client_Temp/js/js/jquery-1.11.3.min.js" type="text/javascript"></script>
    <script src="Client_Temp/js/js/jssor.slider-22.2.10.mini.js" type="text/javascript"></script>
    <style>
        /* jssor slider loading skin oval css */

        .jssorl-oval img {
            animation-name: jssorl-oval;
            animation-duration: 1.2s;
            animation-iteration-count: infinite;
            animation-timing-function: linear;
        }

        @keyframes jssorl-oval {
            from {
                transform: rotate(0deg);
            }

            to {
                transform: rotate(360deg);
            }
        }

        .jssorb05 {
            position: absolute;
        }

            .jssorb05 div, .jssorb05 div:hover, .jssorb05 .av {
                position: absolute;
                /* size of bullet elment */
                width: 16px;
                height: 16px;
                background: url('Client_Temp/js/img/b05.png') no-repeat;
                cursor: pointer;
            }

            .jssorb05 div {
                background-position: -7px -7px;
            }

                .jssorb05 div:hover, .jssorb05 .av:hover {
                    background-position: -37px -7px;
                }

            .jssorb05 .av {
                background-position: -67px -7px;
            }

            .jssorb05 .dn, .jssorb05 .dn:hover {
                background-position: -97px -7px;
            }


        .jssora22l, .jssora22r {
            display: block;
            position: absolute;
            /* size of arrow element */
            width: 40px;
            height: 58px;
            cursor: pointer;
            background: url('Client_Temp/js/img/a22.png') center center no-repeat;
            overflow: hidden;
        }

        .jssora22l {
            background-position: -10px -31px;
        }

        .jssora22r {
            background-position: -70px -31px;
        }

        .jssora22l:hover {
            background-position: -130px -31px;
        }

        .jssora22r:hover {
            background-position: -190px -31px;
        }

        .jssora22l.jssora22ldn {
            background-position: -250px -31px;
        }

        .jssora22r.jssora22rdn {
            background-position: -310px -31px;
        }

        .jssora22l.jssora22lds {
            background-position: -10px -31px;
            opacity: .3;
            pointer-events: none;
        }

        .jssora22r.jssora22rds {
            background-position: -70px -31px;
            opacity: .3;
            pointer-events: none;
        }
    </style>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {

            var jssor_1_options = {
                $AutoPlay: true,
                $SlideDuration: 800,
                $SlideEasing: $Jease$.$OutQuint,
                $ArrowNavigatorOptions: {
                    $Class: $JssorArrowNavigator$
                },
                $BulletNavigatorOptions: {
                    $Class: $JssorBulletNavigator$
                }
            };

            var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);

            /*responsive code begin*/
            /*you can remove responsive code if you don't want the slider scales while window resizing*/
            function ScaleSlider() {
                var refSize = jssor_1_slider.$Elmt.parentNode.clientWidth;
                if (refSize) {
                    refSize = Math.min(refSize, 1920);
                    jssor_1_slider.$ScaleWidth(refSize);
                }
                else {
                    window.setTimeout(ScaleSlider, 30);
                }
            }
            ScaleSlider();
            $(window).bind("load", ScaleSlider);
            $(window).bind("resize", ScaleSlider);
            $(window).bind("orientationchange", ScaleSlider);
            /*responsive code end*/
        });
    </script>

    <style>
        .Services-grid {
            border: 0px solid #0094ff;
            height: 250px;
            padding: 40px 20px 40px 20px;
            color: #333;
        }

            .Services-grid:hover {
                background-color: #a3d5f8;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--slider-->
    <div id="jssor_1" style="position: relative; margin: 0 auto; top: 0px; left: 0px; width: 1500px; height: 600px; overflow: hidden; visibility: hidden;">
        <!-- Loading Screen -->
        <div data-u="loading" class="jssorl-oval" style="position: absolute; top: 0px; left: 0px; text-align: center; background-color: rgba(0,0,0,0.7);">
            <img style="margin-top: -19.0px; position: relative; top: 50%; width: 38px; height: 38px;" src="img/oval.svg" />
        </div>
        <div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 1500px; height: 600px; overflow: hidden;">
            <div>
                <img data-u="image" src="Client_Temp/images/banner.jpg" />
                <%--<div style="position:absolute;top:85px;left:100px;width:600px;height:120px;z-index:0;background-color:rgba(0,0,0,0.5);">
                    <div style="position:absolute;top:15px;left:15px;width:500px;height:40px;z-index:0;font-size:30px;color:#ffffff;line-height:40px;">Build Application with anything</div>
                    <div style="position:absolute;top:60px;left:15px;width:570px;height:40px;z-index:0;font-size:22px;color:#ffffff;line-height:38px;">Android App, Native App, Hybrid App, Web App</div>
                </div>
                <div style="position:absolute;top:370px;left:100px;width:600px;height:120px;z-index:0;background-color:rgba(255,255,255,0.5);">
                    <div style="position:absolute;top:15px;left:15px;width:500px;height:40px;z-index:0;font-size:30px;color:#000000;line-height:40px;">Always Deliver More Than Expected</div>
                    <div style="position:absolute;top:60px;left:15px;width:500px;height:40px;z-index:0;font-size:22px;color:#000000;line-height:38px;">windows, android,Blackberry, mac, ios</div>
                </div>--%>
            </div>
            <div>
                <img data-u="image" src="Client_Temp/images/contentwriting.png" />
                <%--<div style="position:absolute;top:85px;left:100px;width:600px;height:120px;z-index:0;background-color:rgba(0,0,0,0.5);">
                    <div style="position:absolute;top:15px;left:15px;width:500px;height:40px;z-index:0;font-size:30px;color:#ffffff;line-height:40px;">Build your Application in IOS</div>
                    <div style="position:absolute;top:60px;left:15px;width:570px;height:40px;z-index:0;font-size:22px;color:#ffffff;line-height:38px;">macOS, watchOS, ios, tvOS </div>
                </div>
                <div style="position:absolute;top:370px;left:100px;width:600px;height:120px;z-index:0;background-color:rgba(255,255,255,0.5);">
                    <div style="position:absolute;top:15px;left:15px;width:500px;height:40px;z-index:0;font-size:30px;color:#000000;line-height:40px;">Always Deliver More Than Expected</div>
                    <div style="position:absolute;top:60px;left:15px;width:500px;height:40px;z-index:0;font-size:22px;color:#000000;line-height:38px;">windows, android,Blackberry, mac, ios</div>
                </div>--%>
            </div>
            <div>
                <img data-u="image" src="Client_Temp/images/devlopment.jpg" />
                <%--<div style="position:absolute;top:85px;left:100px;width:600px;height:120px;z-index:0;background-color:rgba(0,0,0,0.5);">
                    <div style="position:absolute;top:15px;left:15px;width:500px;height:40px;z-index:0;font-size:30px;color:#ffffff;line-height:40px;">Build your Website anything</div>
                    <div style="position:absolute;top:60px;left:15px;width:570px;height:40px;z-index:0;font-size:22px;color:#ffffff;line-height:38px;">ASP.NET Website, PHP, Windows, Linux</div>
                </div>
                <div style="position:absolute;top:370px;left:100px;width:600px;height:120px;z-index:0;background-color:rgba(255,255,255,0.5);">
                    <div style="position:absolute;top:15px;left:15px;width:500px;height:40px;z-index:0;font-size:30px;color:#000000;line-height:40px;">Always Deliver More Than Expected</div>
                    <div style="position:absolute;top:60px;left:15px;width:500px;height:40px;z-index:0;font-size:22px;color:#000000;line-height:38px;">Web Designing,Graphics ,Business Graphics</div>
                </div>--%>
            </div>
        </div>
        <!-- Bullet Navigator -->
        <div data-u="navigator" class="jssorb05" style="bottom: 16px; right: 16px;" data-autocenter="1">
            <!-- bullet navigator item prototype -->
            <div data-u="prototype" style="width: 16px; height: 16px;"></div>
        </div>
        <!-- Arrow Navigator -->
        <span data-u="arrowleft" class="jssora22l" style="top: 0px; left: 8px; width: 40px; height: 58px;" data-autocenter="2"></span>
        <span data-u="arrowright" class="jssora22r" style="top: 0px; right: 8px; width: 40px; height: 58px;" data-autocenter="2"></span>
    </div>
    <!--slider-->

    <!-- steps -->
    <div class="steps">
        <div class="container">
            <h3 class="head">Project Categories</h3>
            <p class="urna">We provide solutions in all genre of software industry.</p>
            <div class="wthree_steps_grids">
                <div class="col-md-4 wthree_steps_grid">
                    <div class="wthree_steps_grid1 wthree_steps_grid1_after">
                        <div class="wthree_steps_grid1_sub">
                            <span class="glyphicon fa fa-cogs" aria-hidden="true"></span>
                        </div>
                    </div>
                    <h4>Development</h4>
                    <p>Your project partner for all your software needs. we serves the best IT nees.</p>
                </div>
                <div class="col-md-4 wthree_steps_grid">
                    <div class="wthree_steps_grid1 wthree_steps_grid1_after">
                        <div class="wthree_steps_grid1_sub">
                            <span class="glyphicon fa fa-desktop" aria-hidden="true"></span>
                        </div>
                    </div>
                    <h4>Designing & Report</h4>
                    <p>Joins hand with us and making your company or brand.</p>
                </div>
                <div class="col-md-4 wthree_steps_grid">
                    <div class="wthree_steps_grid1">
                        <div class="wthree_steps_grid1_sub">
                            <span class="glyphicon fa fa-pencil-square-o" aria-hidden="true"></span>
                        </div>
                    </div>
                    <h4>Content Writing</h4>
                    <p>Give a new look to your technical project by using our professional content writing skills.</p>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <!-- //steps -->

    <!-- count-down -->
    <div class="count">
        <div class="container">
            <div class="col-md-3 agile_count_grid">
                <div class="agile_count_grid_left">
                    <span class="glyphicon glyphicon-thumbs-up" aria-hidden="true"></span>
                </div>
                <div class="agile_count_grid_right">
                    <p class="counter">
                        <asp:Label ID="lblProjects" runat="server" Text=""></asp:Label>
                    </p>
                </div>
                <div class="clearfix"></div>
                <h3>Creative Work</h3>
            </div>
            <div class="col-md-3 agile_count_grid">
                <div class="agile_count_grid_left">
                    <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                </div>
                <div class="agile_count_grid_right">
                    <p class="counter">
                        <asp:Label ID="lblUserCount" runat="server" Text=""></asp:Label>
                    </p>
                </div>
                <div class="clearfix"></div>
                <h3>Happy Clients</h3>
            </div>
            <div class="col-md-3 agile_count_grid">
                <div class="agile_count_grid_left">
                    <span class="glyphicon glyphicon-heart-empty" aria-hidden="true"></span>
                </div>
                <div class="agile_count_grid_right">
                    <p class="counter">
                        <asp:Label ID="lblfeedback" runat="server" Text=""></asp:Label>
                    </p>
                </div>
                <div class="clearfix"></div>
                <h3>Good FeedBack</h3>
            </div>
            <div class="col-md-3 agile_count_grid">
                <div class="agile_count_grid_left">
                    <span class="glyphicon glyphicon-list" aria-hidden="true"></span>
                </div>
                <div class="agile_count_grid_right">
                    <p class="counter">
                        <asp:Label ID="lblServices" runat="server" Text=""></asp:Label>
                    </p>
                </div>
                <div class="clearfix"></div>
                <h3>Suported Areas</h3>
            </div>
            <div class="clearfix"></div>
            <!-- Starts-Number-Scroller-Animation-JavaScript -->
            <script src="js/waypoints.min.js"></script>
            <script src="js/counterup.min.js"></script>
            <script>
                jQuery(document).ready(function ($) {
                    $('.counter').counterUp({
                        delay: 20,
                        time: 1000
                    });
                });
            </script>
            <!-- //Starts-Number-Scroller-Animation-JavaScript -->
        </div>
    </div>
    <!-- //count-down -->

    <!-- our projects -->
    <div class="work">
        <h3 class="head">Our Projects</h3>
        <p class="urna">Have a glinpse of our successfully executed and acdaimed project of our customer.</p>
        <div class="agileits_work_grids">
            <ul id="flexiselDemo1">
                <asp:Repeater ID="rptViewProject" runat="server" OnItemCommand="rptViewProject_ItemCommand">
                    <ItemTemplate>
                        <li>
                            <div class="agileits_work_grid view view-sixth">
                                <img src="Client_Temp/images/<%# Eval("Image") %>" alt=" " class="img-responsive" />
                                <div class="mask">
                                    <asp:Label ID="lblProjectName" class="container" runat="server" Style="color: #fff; font-size: 20px;" Text='<%# Eval("Title") %>'></asp:Label><br />
                                    <asp:LinkButton ID="lnkViewPro" class="info" runat="server" style="margin-top: 40px;" CommandArgument='<%# Eval("ProjectID") %>' CommandName="ViewProject">Read More</asp:LinkButton>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <script type="text/javascript">
                $(window).load(function () {
                    $("#flexiselDemo1").flexisel({
                        visibleItems: 4,
                        animationSpeed: 1000,
                        autoPlay: true,
                        autoPlaySpeed: 3000,
                        pauseOnHover: true,
                        enableResponsiveBreakpoints: true,
                        responsiveBreakpoints: {
                            portrait: {
                                changePoint: 480,
                                visibleItems: 1
                            },
                            landscape: {
                                changePoint: 640,
                                visibleItems: 2
                            },
                            tablet: {
                                changePoint: 768,
                                visibleItems: 3
                            }
                        }
                    });
                });
            </script>
            <script type="text/javascript" src="Client_Temp/js/jquery.flexisel.js"></script>
        </div>
    </div>
    <!-- //our projects -->

    <!-- our servises -->
    <div id="services" class="services-list">
        <div class="container">
            <h3 class="head">Our Services</h3>
            <p class="urna">Upgrade your technical base by selecting from our broad rang of services.</p>
            <div class="services-gds">

                <asp:Repeater ID="rptViewOurServices" runat="server">
                    <ItemTemplate>
                        <%--<div class="col-md-4 list-gds list-gds-<%# Container.ItemIndex+1 %> text-center wow bounceInUp" data-wow-duration="1.5s" data-wow-delay="0s">
                            <span class="glyphicon glyphicon-collapse-down" aria-hidden="true"></span>
                            <asp:LinkButton ID="lnkService" runat="server" Style="font-size: 30px;" OnClick="lnkService_Click"><%# Eval("CategoryName") %></asp:LinkButton>
                            <p></p>
                        </div>--%>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lnkService_Click">
                        <div class="col-md-4 Services-grid">
                            <center><span class="glyphicon glyphicon-collapse-down" aria-hidden="true" style="color: #0094ff; font-size: 40px; margin-bottom: 30px;"></span><br />
                            <h2><%# Eval("CategoryName") %></h2></center>
                        </div>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <!-- //our servises -->

    <!-- newsletter -->
    <div class="newsletter">
        <div class="container">
            <div class="col-md-6 w3agile_newsletter_left">
                <h3>Subscribe to Newsletter</h3>
                <p>
                    Subscribe to our newsletter and stay updated on the latest developments and special days. 
                    The TrackMyWork newsletter keeps you informed on new types of projects, financial tips and much more.
                </p>
            </div>
            <div class="col-md-6 w3agile_newsletter_right">
                <form action="#" method="post">
                    <asp:TextBox ID="txtSubEmail" runat="server" type="email" OnTextChanged="txtSubEmail_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:Panel ID="PanelSubscribe" runat="server">
                        <asp:Button ID="btnSubscribe" runat="server" Text="Subscribe" OnClick="btnSubscribe_Click" />
                    </asp:Panel>
                    <asp:Panel ID="PanelUnSubscribe" runat="server" Visible="false">
                        <asp:Button ID="btnUnSubscribe" runat="server" Text="UnSubscribe" OnClick="btnUnSubscribe_Click" />
                    </asp:Panel>
                    <div class="col-md-6 w3agile_newsletter_left" style="margin-top: 50px; margin-bottom: 30px;">
                        <center><asp:Label ID="errorSubscribe" runat="server" Text="Email already subscribed..." Visible="false" style="color:#fff; font-size:18px; margin-bottom:50px;"></asp:Label></center>
                    </div>
                </form>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
    <!-- //newsletter -->
</asp:Content>

