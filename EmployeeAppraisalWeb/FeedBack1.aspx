<%@ Page Title="" Language="C#" MasterPageFile="~/ClientHeadMaster.master" AutoEventWireup="true" CodeFile="FeedBack1.aspx.cs" Inherits="FeedBack" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Feedback Form Flat Responsive widget Template :: w3layouts</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Feedback Form Widget Responsive, Login form web template,Flat Pricing tables,Flat Drop downs  Sign up Web Templates, Flat Web Templates, Login signup Responsive web template, Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- font files -->
    <link href="//fonts.googleapis.com/css?family=Abel" rel="stylesheet" />
    <link href="//fonts.googleapis.com/css?family=Raleway:100,200,300,400,500,600,700,800,900" rel="stylesheet" />
    <!-- /font files -->
    <!-- css files -->
    <%--<link href="Client_Temp/FeedBack/css/style.css" rel="stylesheet" />--%>
    <!-- /css files -->
    <%--<style>
        * {
            margin-left: 10px;
            padding-left: 10px;
            font-family: roboto;
        }

        div.stars {
            width: 270px;
            display: inline-block;
        }

        input.star {
            display: none;
        }

        label.star {
            float: right;
            padding: 5px;
            font-size: 30px;
            color: #444;
            transition: all .2s;
        }

        input.star:checked ~ label.star:before {
            content: '\f005';
            color: #FD4;
            transition: all .25s;
        }

        input.star-5:checked ~ label.star:before {
            color: #FE7;
            text-shadow: 0 0 20px #952;
        }

        input.star-1:checked ~ label.star:before {
            color: #F62;
        }

        label.star:hover {
            transform: rotate(-15deg) scale(1.3);
        }

        label.star:before {
            content: '\f006';
            font-family: FontAwesome;
        }
    </style>--%>
    <style>
        span {
            font-size: 14px;
            color: #808080;
        }

        input[type="text"], input[type="email"] {
            width: 90%;
        }

        .register {
            background-color: #D4AF37;
            width: 20%;
            margin-right: 10px;
            margin-left: 251px;
            float: left;
            height: 50px;
            border: none;
            cursor: pointer;
            color: #fff;
            letter-spacing: 1px;
            outline: none;
            font-size: 17px;
            font-weight: normal;
            text-transform: uppercase;
            transition: all 0.5s ease-in-out;
            -webkit-transition: all 0.5s ease-in-out;
            -moz-transition: all 0.5s ease-in-out;
            -o-transition: all 0.5s ease-in-out;
            font-family: 'Abel', sans-serif;
        }

            .register:hover {
                background-color: #008BFF;
                color: #fff;
            }

        .reset {
            background-color: #D4AF37;
            width: 20%;
            float: left;
            height: 50px;
            border: none;
            cursor: pointer;
            color: #fff;
            letter-spacing: 1px;
            outline: none;
            font-size: 17px;
            font-weight: normal;
            text-transform: uppercase;
            transition: all 0.5s ease-in-out;
            -webkit-transition: all 0.5s ease-in-out;
            -moz-transition: all 0.5s ease-in-out;
            -o-transition: all 0.5s ease-in-out;
            font-family: 'Abel', sans-serif;
        }

            .reset:hover {
                background-color: #008BFF;
                color: #fff;
            }

        input[type=radio].css-checkbox {
            position: absolute;
            z-index: -1000;
            left: -1000px;
            overflow: hidden;
            clip: rect(0 0 0 0);
            height: 1px;
            width: 1px;
            margin: -1px;
            padding: 0;
            border: 0;
        }

            input[type=radio].css-checkbox + label.css-label {
                padding-left: 55px;
                height: 20px;
                display: inline-block;
                line-height: 20px;
                background-repeat: no-repeat;
                background-position: 0 0;
                font-size: 14px;
                vertical-align: middle;
                cursor: pointer;
            }

            input[type=radio].css-checkbox:checked + label.css-label {
                background-position: 0 -50px;
            }

        label.css-label {
            background-image: url(http://csscheckbox.com/checkboxes/u/csscheckbox_19d5eb832f07f6f252882981adff713c.png);
            -webkit-touch-callout: none;
            -webkit-user-select: none;
            -khtml-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }
    </style>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            var v = $("#<%=txtRate.ClientID %>").val();
            //alert(v);
            $("input[name=starC][value=" + v + "]").attr('checked', 'checked');

            $('input:radio[name="star"]').change(function () {
                //alert($("input[type=radio]:checked").val());
                $("#<%=txtRate.ClientID %>").val($("input[type=radio]:checked").val());
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container feedback" style="height: 100%; width: 100%; margin-top: 90px; margin-bottom: 90px;">
                <div class="col-md-12">
                    <div class="container" style="border: 1px solid; padding-top: 50px; padding-bottom: 50px;">
                        <h1 class="header-w3ls text-center" style="margin-bottom: 30px;">Feedback Form</h1>
                        <div class="col-md-12" style="margin-top: 30px;">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <span>Email Address : </span>
                                    <asp:TextBox ID="txtEmail" class="form-control" runat="server" AutoPostBack="true" type="email" placeholder="mail@example.com" title="Please enter a Valid Email Address" required="" Style="font-size: 14px; border: 1px solid #808080; color: #808080;" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <span>Project Name : </span>
                                    <asp:DropDownList ID="ddProduct" class="form-control" runat="server" Style="font-size: 14px; border: 1px solid #808080; color: #808080; width: 90%; border-radius: 5px;">
                                        <asp:ListItem Value="Products">Products</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <span>Customer Name : </span>
                                    <asp:TextBox ID="txtName" class="form-control" runat="server" placeholder="Customer Name" title="Please enter your Full Name" required="" pattern="[a-zA-Z ]+" Style="font-size: 14px; border: 1px solid #808080; color: #808080; width: 90%;"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <span>Organization : </span>
                                    <asp:TextBox ID="txtOrgn" class="form-control" runat="server" placeholder="Organization" title="Please enter your Organization" required="" pattern="[a-zA-Z ]+" Style="font-size: 14px; border: 1px solid #808080; color: #808080; width: 90%;"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <span>Ratings for Company : </span>
                                    <div class="cont">
                                        <div class="stars" style="margin-left: 0px;">
                                            <input type="radio" name="star-5" id="radio2" class="css-checkbox"/><label for="radio2" class="css-label radGroup1">Option 2</label>
                                            <input class="star star-5" id="star-5" type="radio" name="star" value="5" />
                                            <label class="star star-5" for="star-5"></label>
                                            <input class="star star-5" id="star-4" type="radio" name="star" value="4" />
                                            <label class="star star-4" for="star-4"></label>
                                            <input class="star star-5" id="star-3" type="radio" name="star" value="3" />
                                            <label class="star star-3" for="star-3"></label>
                                            <input class="star star-5" id="star-2" type="radio" name="star" value="2" />
                                            <label class="star star-2" for="star-2"></label>
                                            <input class="star star-5" id="star-1" type="radio" name="star" value="1" />
                                            <label class="star star-1" for="star-1"></label>
                                            <input type="hidden" id="txtRate" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <span>Customer Enquiry : </span>
                                    <asp:TextBox ID="txtEnquiry" class="form-control" runat="server" TextMode="MultiLine" placeholder="Your Queries" title="Please enter Your Queries" Style="font-size: 14px; border: 1px solid #808080; color: #808080; height: 150px; padding: 15px; width: 95%;" required="" pattern="[a-zA-Z ]+"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12" style="margin-top: 30px;">
                                <asp:Button ID="btnSubmit" class="register" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnReset" class="reset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
            <asp:PostBackTrigger ControlID="btnReset" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

