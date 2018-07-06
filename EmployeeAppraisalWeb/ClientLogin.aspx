<%@ Page Title="" Language="C#" MasterPageFile="~/ClientFrameLogin.master" AutoEventWireup="true" CodeFile="ClientLogin.aspx.cs" Inherits="ClientLogin" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Popular Login Form Responsive, Login form web template, Sign up Web Templates, Flat Web Templates, Login Sign up Responsive web template, Smart phone Compatible web template, free web designs for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
    <!-- Custom Theme files -->
    <link href="Client_Temp/Login/css/style.css" rel="stylesheet" />
    <!-- //Custom Theme files -->
    <!-- web-font -->
    <link href='//fonts.googleapis.com/css?family=Roboto+Condensed:400,700' rel='stylesheet' type='text/css' />
    <!-- //web-font -->
    <!-- pop-up-box -->
    <script src="Client_Temp/Login/js/jquery-2.2.3.min.js"></script>
    <!-- //pop-up-box -->
    <style>
        .lnk {
            color: #ff6a00;
        }

            .lnk:hover {
                color: #fff;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- login starts here -->
    <div>
        <div id="home" style="height: 790px;">
            <div class="banner1-info">
                <div class="container">
                    <asp:Panel ID="Panellogin" runat="server" Visible="true">
                        <div class="login agile" style="margin-top: 80px;">
                            <div class="w3agile-border">
                                <form method="post">
                                    <div class="login-main login-agileits">
                                        <h1>Login</h1>

                                        <p>Email</p>
                                        <asp:TextBox ID="txtLoginEmail" type="email" runat="server" placeholder="example@gmail.com" required=""></asp:TextBox>
                                        <p>Password</p>
                                        <asp:TextBox ID="txtLoginPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                        <center><asp:Label ID="errorLogin" runat="server" Text="Invalid EmailID or Password" Visible="false" style="color:#ff6a00; font-size:18px;"></asp:Label></center>
                                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                                        <br />
                                        <center><asp:LinkButton ID="lkforgetpass" runat="server" class="sign-in popup-top-anim lnk" OnClick="lkforgetpass_Click">Forget Password?</asp:LinkButton></center>
                                        <%--<div class="social-btns w3l">
                                            <a class="fa" href="#">Facebook</a>
                                            <a class="g" href="#">Google</a>
                                        </div>--%>
                                        <div style="margin-top:30px;">
                                            <center><asp:Label ID="Label5" runat="server" Text="Not a member yet ? " style="color: #fff; font-weight: bolder; "></asp:Label><asp:LinkButton ID="LinkButton1" runat="server" class="sign-in popup-top-anim lnk" OnClick="LinkButton1_Click">Sign Up Now !</asp:LinkButton></center>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="Panelforgetpass" runat="server" Visible="true" Style="margin-top: 130px;">
                        <div class="login agile">
                            <div class="w3agile-border">
                                <div class="login-main login-agileits">
                                    <h1>Forget Password</h1>
                                    <form method="post">
                                        <p>Email</p>
                                        <asp:TextBox ID="txtForPassEmail" type="email" runat="server" placeholder="example@gmail.com" required=""></asp:TextBox>
                                        <center><asp:Label ID="errorForEmail" runat="server" Text="You are not Registered user Check Your Email" Visible="false" style="color:#ff6a00; font-size:18px;"></asp:Label></center>
                                        <asp:Button ID="btncode" runat="server" Text="Give Me Code" Visible="true" OnClick="btncode_Click" />

                                        <asp:TextBox ID="txtcode" runat="server" placeholder="Enter Code" required="" Visible="false"></asp:TextBox>
                                        <center><asp:Label ID="errorCode" runat="server" Text="Invalid Code Chack Your Email" Visible="false" style="color:#ff6a00; font-size:18px;"></asp:Label></center>

                                        <asp:Button ID="btnsubmit" runat="server" Text="Verify" OnClick="btnsubmit_Click" Visible="false" />

                                    </form>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="Panelchangpass" runat="server" Visible="true">
                        <div class="login agile">
                            <div class="w3agile-border">
                                <div class="login-main login-agileits">
                                    <h1>Forget Password</h1>
                                    <form method="post">
                                        <p>New Password</p>
                                        <asp:TextBox ID="txtNewPwd" runat="server" placeholder="New Password" TextMode="Password" required="" type="Password" pattern="(?=^.{8,}$).*$" title="Password must be 8 letter"></asp:TextBox>
                                        <p>Conform Password</p>
                                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" placeholder="Conform Password" required=""></asp:TextBox>
                                    </form>
                                    <center><asp:Label ID="errorChangePassword" runat="server" Text="Invalid Password !" Visible="false" style="color:#ff6a00; font-size:18px;"></asp:Label></center>
                                    <asp:Button ID="btnchandpass" runat="server" Text="Change Password" OnClick="btnchandpass_Click" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                    <!-- //Sign Up -->

                    <asp:Panel ID="PanelSignUp" runat="server" Visible="true">
                        <div class="login agile">
                            <div class="w3agile-border">
                                <div class="login-main login-agileits">
                                    <h1>Sign Up</h1>
                                    <form action="#" method="post">
                                        <p>First Name</p>
                                        <asp:TextBox ID="txtRegFname" runat="server" placeholder="First Name" required="" MaxLength="20" pattern="[a-zA-Z]+" title="Accept alphabet only"></asp:TextBox>
                                        <p>Last Name</p>
                                        <asp:TextBox ID="txtRegLname" runat="server" placeholder="Last Name" required="" MaxLength="20" pattern="[a-zA-Z]+"></asp:TextBox>
                                        <p>Email</p>
                                        <asp:TextBox ID="txtRegEmail" type="email" runat="server" placeholder="example@gmail.com" required="" OnTextChanged="txtRegEmail_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <div style="margin-bottom: 30px;">
                                            <center><asp:Label ID="errorEmail" runat="server" Text="Email already Exist..." Visible="false" style="color:#ff6a00; font-size:18px; margin-bottom:50px;"></asp:Label></center>
                                        </div>
                                        <p>Password</p>
                                        <asp:TextBox ID="txtRegPassword" runat="server" TextMode="Password" placeholder="Password" required="" pattern="(?=^.{8,}$).*$" title="Password must be 8 letter"></asp:TextBox>
                                        <p>Contact No</p>
                                        <asp:TextBox ID="txtRegCNO" runat="server" placeholder="Contact No" required="" min="999999999" max="9999999999999" type="number" oninvalid="this.setCustomValidity('Please Enter Valid Contact Number')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                                        <asp:CheckBox ID="chkEmployee" runat="server" /><asp:Label ID="lblEmp" runat="server" Style="color: #ff6a00; font-size: 15px; margin-left: 10px;">I am Employee.</asp:Label>
                                        <asp:Button ID="btnsignup" runat="server" Text="Sign Up" OnClick="btnsignup_Click" />
                                    </form>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="PanelVerifyEmail" runat="server" Visible="true" Style="margin-top: 130px;">
                        <div class="login agile">
                            <div class="w3agile-border">
                                <div class="login-main login-agileits">
                                    <h1>Email Verification</h1>
                                    <form method="post">
                                        <p>Verification Code</p>
                                        <asp:TextBox ID="txtVerificationCode" runat="server" placeholder="Enter Code" required=""></asp:TextBox>
                                        <div style="margin-bottom: 30px;">
                                            <center><asp:Label ID="lblverify" runat="server" Text="Invalid Code Check Your Email" Visible="false" style="color:#ff6a00; font-size:18px; margin-bottom:50px;"></asp:Label></center>
                                        </div>

                                        <center><font style="color:#fff";>If you can not recived code ? </font><asp:LinkButton ID="lnkSendCodeAgain" runat="server" style="color:#ff6a00; font-size:18px; margin-top:50px;" OnClick="lnkSendCodeAgain_Click">Send Code Again</asp:LinkButton></center>

                                        <asp:Button ID="btnSubmitCode" runat="server" Text="Verify Email" OnClick="btnSubmitCode_Click" />

                                    </form>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <!-- //Sign Up -->

                </div>
            </div>
        </div>
    </div>
    <!-- //login ends here -->

    <script src="Client_Temp/Ljs/jquery.magnific-popup.js" type="text/javascript"></script>
</asp:Content>

