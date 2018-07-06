<%@ Page Title="" Language="C#" MasterPageFile="~/ClientHeadMaster.master" AutoEventWireup="true" CodeFile="TrackProject.aspx.cs" Inherits="TrackProject" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        /*Card CSS*/
        .card {
            box-shadow: 0px 0px 8px rgba(0,0,0,0.2);
            transition: 0.3s;
            border-radius: 5px;
        }

            .card:hover {
                box-shadow: 0px 0px 16px #008bff;
            }

        .container1 {
            padding: 2px 16px;
        }
    </style>

    <%--<style>
        
        /*Slider*/

        /* Slideshow container */
        .slideshow-container {
            /*max-width: 800px;*/
            width: 1200px;
            position: relative;
            margin: auto;
            margin-top: 50px;
        }

        /* Next & previous buttons */
        .prev, .next {
            cursor: pointer;
            position: absolute;
            top: 50%;
            width: auto;
            padding: 16px;
            margin-top: -22px;
            color: white;
            font-weight: bold;
            font-size: 18px;
            transition: 0.6s ease;
            border-radius: 0 3px 3px 0;
        }

        /* Position the "next button" to the right */
        .next {
            right: 0;
            border-radius: 3px 0 0 3px;
        }

            /* On hover, add a black background color with a little bit see-through */
            .prev:hover, .next:hover {
                background-color: rgba(0,0,0,0.8);
            }

        /* Caption text */
        .textslide {
            color: #f2f2f2;
            font-size: 100px;
            padding: 8px 12px;
            position: absolute;
            bottom: 8px;
            width: 100%;
            text-align: center;
        }

        /* Number text (1/3 etc) */
        .numbertextslide {
            color: #f2f2f2;
            font-size: 12px;
            padding: 8px 12px;
            position: absolute;
            top: 0;
        }

        /* The dots/bullets/indicators */
        .dot {
            cursor: pointer;
            height: 13px;
            width: 13px;
            margin: 0 2px;
            background-color: #bbb;
            border-radius: 50%;
            display: inline-block;
            transition: background-color 0.6s ease;
        }

            .activedot, .dot:hover {
                background-color: #717171;
            }

        /* Fading animation */
        .fadeslide {
            -webkit-animation-name: fade;
            -webkit-animation-duration: 1.5s;
            animation-name: fade;
            animation-duration: 1.5s;
        }

        @-webkit-keyframes fade {
            from {
                opacity: .4;
            }

            to {
                opacity: 1;
            }
        }

        @keyframes fade {
            from {
                opacity: .4;
            }

            to {
                opacity: 1;
            }
        }

        /* On smaller screens, decrease text size */
        @media only screen and (max-width: 300px) {
            .prev, .next, .text {
                font-size: 11px;
            }
        }
    </style>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">

        <%--<asp:Panel ID="PanelProjectView" runat="server" Style="margin-bottom: 65px;">
        <div class="slideshow-container">
            <asp:Repeater ID="rptProjectView" runat="server" OnItemCommand="rptProjectView_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkSelectProject" runat="server" CommandName="TrackProject" CommandArgument='<%# Eval("ProjectID") %>'>

                        <div class="mySlides fadeslide">
                            <div class="numbertextslide">
                                <%# Container.ItemIndex + 1 %> /
                                <asp:Literal ID="ltrItemCount" runat="server"></asp:Literal>
                            </div>
                            <img src="http://www.1366x768.net/large/201111/1267.jpg" style="width: 100%; height: 500px;" />
                            <div class="textslide"><%# Eval("Title") %></div>
                        </div>
                    </asp:LinkButton>

                    <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
                    <a class="next" onclick="plusSlides(1)">&#10095;</a>
                </ItemTemplate>
            </asp:Repeater>

        </div>

        <br />
        <div style="text-align: center;">

            <asp:Repeater ID="rptSlider" runat="server">
                <ItemTemplate>
                    <span class="dot" onclick="currentSlide()"></span>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <script>
            var slideIndex = 1;
            showSlides(slideIndex);

            function plusSlides(n) {
                showSlides(slideIndex += n);
            }

            function currentSlide(n) {
                showSlides(slideIndex = n);
            }

            function showSlides(n) {
                var i;
                var slides = document.getElementsByClassName("mySlides");
                var dots = document.getElementsByClassName("dot");
                if (n > slides.length) { slideIndex = 1 }
                if (n < 1) { slideIndex = slides.length }
                for (i = 0; i < slides.length; i++) {
                    slides[i].style.display = "none";
                }
                for (i = 0; i < dots.length; i++) {
                    dots[i].className = dots[i].className.replace(" activedot", "");
                }
                slides[slideIndex - 1].style.display = "block";
                dots[slideIndex - 1].className += " activedot";
            }
        </script>
    </asp:Panel>--%>
        <asp:Panel ID="PanelProject" runat="server" Style="margin-top: 100px;">
            <div class="container" style="margin-bottom: 50px;">
                <h3 class="head">Your Projects</h3>
                <p class="urna">You can see your project and track the project.</p>
            </div>
            <asp:Repeater ID="rptProject" runat="server" OnItemCommand="rptProject_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkProject" runat="server" Style="color: #333;" CommandName="TrackProject" CommandArgument='<%# Eval("ProjectID") %>'>
                        <div class="col-md-12" style="border: 0px solid; margin-bottom: 60px;">
                            <div class="card container" style="padding: 0px; height: 100px;">
                                <div class="col-md-2 text-center" style="background-color: #008bff; color: #fff; padding: 30px; border-radius: 5px 0px 0px 5px; height: 100px;">
                                    <asp:Label ID="lblDays" runat="server" Text="" Style="color: #212121; text-transform: capitalize; font-family: 'Sanchez', serif;">
                                        <asp:HiddenField ID="hdnDays" runat="server" Value='<%# Eval("DeadlineDate") %>' />
                                    </asp:Label>
                                </div>
                                <div class="col-md-10">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-6 text-center" style="padding: 30px;">
                                        <h3 class="head"><%# Eval("Title") %></h3>
                                    </div>
                                    <div class="col-md-5" style="padding: 20px; padding-left: 90px;">
                                        <div class="col-md-12">
                                            <asp:Label ID="lblProjectAssignDate" runat="server" Text="Assign date" Style="font-size: 18px; color: #212121; font-family: 'Sanchez', serif;">Assign Date <span style="margin-left:33px; margin-right:20px;">:</span></asp:Label>
                                            <asp:Label ID="lblADate" runat="server" Text='<%# Eval("AssignDate") %>' Style="font-size: 18px;"></asp:Label>
                                        </div>
                                        <div class="col-md-12">
                                            <asp:Label ID="lblDeadLineDate" runat="server" Text="Assign date" Style="font-size: 18px; color: #212121; font-family: 'Sanchez', serif;">DeadLine Date <span style="margin-left:10px; margin-right:20px;">:</span></asp:Label>
                                            <asp:Label ID="lblDDate" runat="server" Text='<%# Eval("DeadLineDate") %>' Style="font-size: 18px;"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>

        </asp:Panel>
        <asp:Panel ID="PanelProjectStatus" runat="server" Visible="false">
            <div class="table-responsive" style="margin-top: 20px;">

                <div class="container">
                    <h1 style="font-size: 1.8em; color: #212121; text-transform: capitalize; font-family: 'Sanchez', serif; text-align: center; margin-top: 82px;">
                        <asp:Literal ID="ltrProjectName" runat="server"></asp:Literal>
                    </h1>
                    <p class="urna">Your Project status</p>
                    <asp:LinkButton ID="lnkBack" runat="server" Style="margin-top: 30px; margin-bottom: 20px;" OnClick="lnkBack_Click"><h1 style="text-align:center; font-size:14px; margin-left:-10px; color:#999; margin-top:10px;"><< Back</h1></asp:LinkButton>
                </div>
                <div id="StatusBar" class="container-fluid">
                    <div class="card" style="height: 100%; width: 95%; margin-top: 50px; margin-left: 30px; margin-bottom: 100px; padding-bottom: 20px;">
                        <div style="float: right; margin-top:50px; margin-right:40px;">
                            <asp:Label ID="lblTrackDays" runat="server" Text="" Style="color: #212121; text-transform: capitalize; font-family: 'Sanchez', serif;">
                            </asp:Label>
                        </div>
                        <div class="container">
                            <div style="margin-top: 50px; margin-left: 3px;">
                                <h3 style="font-size: 1.8em; color: #212121; text-transform: capitalize; font-family: 'Sanchez', serif;">Project Detail :</h3>
                            </div>
                        </div>
                        <div style="margin-top: 20px; margin-left: 90px;">
                            <div>
                                <asp:Label ID="lblTitle" runat="server" Style="font-size: 20px; color: #212121; font-family: 'Sanchez', serif;">Project Title <span style="margin-left:35px; margin-right:10px;">:</span></asp:Label>
                                <asp:Literal ID="ltrProTitle" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="margin-top: 5px; margin-left: 90px;">
                            <div>
                                <asp:Label ID="lblProDescription" runat="server" Style="font-size: 20px; color: #212121; font-family: 'Sanchez', serif;">Description <span style="margin-left:42px; margin-right:10px;">:</span></asp:Label>
                                <asp:Literal ID="ltrProDescription" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="margin-top: 5px; margin-left: 90px;">
                            <div>
                                <asp:Label ID="lblAssignDate" runat="server" Style="font-size: 20px; color: #212121; font-family: 'Sanchez', serif;">Assign Date <span style="margin-left:35px; margin-right:10px;">:</span></asp:Label>
                                <asp:Literal ID="ltrAssignDate" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="margin-top: 5px; margin-left: 90px;">
                            <div>
                                <asp:Label ID="lblDeadDate" runat="server" Style="font-size: 20px; color: #212121; font-family: 'Sanchez', serif;">DeadLine Date <span style="margin-left:10px; margin-right:10px;">:</span></asp:Label>
                                <asp:Literal ID="ltrDeadLineDate" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="container">
                            <div style="margin-top: 50px; margin-left: 3px; margin-bottom: -10px;">
                                <h2 style="font-size: 1.8em; color: #212121; text-transform: capitalize; font-family: 'Sanchez', serif;">Project Status :</h2>
                            </div>
                        </div>
                        <div class="container" style="padding: 20px; margin-left: 70px;">
                            <asp:Repeater ID="rptProjectTracking" runat="server">
                                <ItemTemplate>
                                    <div style="margin-top: 20px;">
                                        <asp:Label ID="lblModule" runat="server" Text='<%# Eval("Title") %>'></asp:Label><asp:HiddenField ID="hdnModuleID" runat="server" Value='<%# Eval("ModuleID") %>' />
                                    </div>
                                    <div class="progress" style="margin-top: 8px; margin-right: 60px;">
                                        <asp:Panel ID="PanelStatus" runat="server" class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" Style="width: 20%; height: 20px;">
                                            <asp:Literal ID="ltrProStatus" runat="server" Text=""></asp:Literal>
                                        </asp:Panel>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>

</asp:Content>

