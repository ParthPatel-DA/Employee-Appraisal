<%@ Page Title="" Language="C#" MasterPageFile="~/ClientHeadMaster.master" AutoEventWireup="true" CodeFile="FeedBack.aspx.cs" Inherits="FeedBack" EnableEventValidation="false" ValidateRequest="false" %>

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
    <link href="Client_Temp/FeedBack/css/style.css" rel="stylesheet" />
    <!-- /css files -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container feedback" style="height: 100%; width: 100%; margin-top: 0px; margin-bottom: 20px;">
                <h1 class="header-w3ls">Feedback Form</h1>
                <div class="content-w3ls" style="height: 900px; width: 1000px;">
                    <div class="form-w3ls">
                        <div class="content-wthree1">
                            <div class="grid-agileits1">
                                <div class="col-md-12">
                                    <div class="col-md-6 header">
                                        <asp:Label ID="lblEmail" class="header" runat="server">Email Address <span>:</span></asp:Label>
                                    </div>
                                    <div class="col-md-6" style="margin-top: 20px; margin-left: -18px;">
                                        <asp:TextBox ID="txtEmail" class="form-control" runat="server" AutoPostBack="true" type="email" placeholder="mail@example.com" title="Please enter a Valid Email Address" required="" Style="font-size: 14px; border: 1px solid #fff; color: #fff; height: 35px; width: 250px;" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-12" style="margin-top: 30px;">
                                    <div class="col-md-6 header">
                                        <asp:Label ID="lblName" class="header" runat="server">Customer Name <span>:</span></asp:Label>
                                    </div>
                                    <div class="col-md-6" style="margin-top: 20px; margin-left: -18px;">
                                        <asp:TextBox ID="txtName" class="form-control" runat="server" placeholder="Customer Name" title="Please enter your Full Name" required="" pattern="[a-zA-Z ]+" Style="font-size: 14px; border: 1px solid #fff; color: #fff; height: 35px; width: 250px;"></asp:TextBox>
                                    </div>
                                </div>


                            </div>
                            <div class="grid-agileits2">
                                <div class="col-md-12" style="">
                                    <div class="col-md-6 header">
                                        <asp:Label ID="lblProduct" class="header" runat="server">Products You like <span>:</span></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6" id="select" style="margin-top: 20px; margin-left: -2px;">
                                    <asp:DropDownList ID="ddProduct" runat="server" Style="font-size: 14px; border: 1px solid #fff; color: #fff; height: 35px; width: 250px; border-radius: 5px;">
                                        <asp:ListItem Value="Products">Products</asp:ListItem>
                                        <asp:ListItem Value="Products">Products</asp:ListItem>
                                        <asp:ListItem Value="Products">Products</asp:ListItem>
                                        <asp:ListItem Value="Products">Products</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-12" style="margin-top: 30px;">
                                    <div class="col-md-6 header">
                                        <asp:Label ID="Label1" class="header" runat="server">Organization <span>:</span></asp:Label>
                                    </div>
                                    <div class="col-md-6" style="margin-top: 20px; margin-left: -18px;">
                                        <asp:TextBox ID="txtOrgn" class="form-control" runat="server" placeholder="Organization" title="Please enter your Organization" required="" pattern="[a-zA-Z ]+" Style="font-size: 14px; border: 1px solid #fff; color: #fff; height: 35px; width: 250px;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="col-md-12 content-wthree2" style="margin-top: 30px; margin-left: 10px;">
                        <div class="grid-w3layouts1">
                            <div class="w3-agile1">
                                <label class="rating">Ratings for Company<span>:</span></label>
                                <ul style="margin-top:-70px;">
                                    <li>
                                        <input type="radio" id="aoption" name="selector1" value="very high" runat="server" />
                                        <div style="margin-top: 2px;">
                                            <label for="aoption">very high</label>
                                        </div>
                                        <div class="check"></div>
                                    </li>
                                    <li>
                                        <input type="radio" id="boption" name="selector1" value="high" runat="server" />
                                        <label for="boption">high</label>
                                        <div class="check">
                                            <div class="inside"></div>
                                        </div>
                                    </li>
                                    <li>
                                        <input type="radio" id="coption" name="selector1" value="medium" runat="server" />
                                        <label for="coption">medium</label>
                                        <div class="check">
                                            <div class="inside"></div>
                                        </div>
                                    </li>
                                    <li>
                                        <input type="radio" id="doption" name="selector1" value="low" runat="server" />
                                        <label for="doption">low</label>
                                        <div class="check"></div>
                                    </li>
                                    <li>
                                        <input type="radio" id="eoption" name="selector1" value="very low" runat="server" />
                                        <label for="eoption">very low</label>
                                        <div class="check">
                                            <div class="inside"></div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="grid-w3layouts2" style="margin-top: 0px; margin-left: 10px;">
                            <div class="w3-agile2">
                                <label class="rating">Ratings for Support <span>:</span></label>
                                <ul style="margin-top:-70px;" >
                                    <li>
                                        <input type="radio" id="foption" name="selector2" value="Very good" runat="server" />
                                        <label for="foption">Very good</label>
                                        <div class="check"></div>
                                    </li>
                                    <li>
                                        <input type="radio" id="goption" name="selector2" value="good" runat="server" />
                                        <label for="goption">good</label>
                                        <div class="check">
                                            <div class="inside"></div>
                                        </div>
                                    </li>
                                    <li>
                                        <input type="radio" id="hoption" name="selector2" value="average" runat="server" />
                                        <label for="hoption">average</label>
                                        <div class="check">
                                            <div class="inside"></div>
                                        </div>
                                    </li>
                                    <li>
                                        <input type="radio" id="ioption" name="selector2" value="fair" runat="server" />
                                        <label for="ioption">fair</label>
                                        <div class="check">
                                            <div class="inside"></div>
                                        </div>
                                    </li>
                                    <li>
                                        <input type="radio" id="joption" name="selector2" value="poor" runat="server" />
                                        <label for="joption">poor</label>
                                        <div class="check">
                                            <div class="inside"></div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="col-md-12 content-wthree3">
                        <div class="col-md-12">
                            <div class="col-md-12 enquiry" style="margin-left: 10px;">
                                <asp:Label ID="lblEnquiry" class="enquiry" runat="server">Customer Enquiry <span>:</span></asp:Label>
                            </div>
                            <div class="col-md-12 message" style="margin-left: -278px; margin-top: 15px;">
                                <asp:TextBox ID="txtEnquiry" class="form-control" runat="server" TextMode="MultiLine" placeholder="Your Queries" title="Please enter Your Queries" Style="background-color: #333; font-size: 14px; border: 1px solid #fff; color: #fff; height: 150px; padding: 15px; width: 147%;" required="" pattern="[a-zA-Z ]+"></asp:TextBox>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </div>
                    <div class="content-wthree4">
                        <div class="col-md-12" style="margin-left: 10px; margin-top: 80px;">
                            <asp:Button ID="btnSubmit" class="register" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>
                        <div class="col-md-12" style="margin-top: -50px; margin-left: 470px;">
                            <asp:Button ID="btnReset" class="reset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                        </div>
                        <div class="clear"></div>
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

