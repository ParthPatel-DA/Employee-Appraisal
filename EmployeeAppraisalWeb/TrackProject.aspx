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

    <%--BackButton--%>
    <style>
        .btn-back {
            float: left;
            margin-left: -60px;
            margin-top: 50px;
            margin-bottom: -20px;
        }

            .btn-back:hover {
                background-color: #008bff;
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

    <%--Profile--%>
    <style>
        .Profie-Lable {
            font-size: 1.5em;
            font-family: 'Sanchez', serif;
            color: #212121;
            margin-left: 20px;
        }

        .btn-Profile {
            outline: none;
            border: 1px solid #FFFFFF;
            color: #fff;
            font-size: 14px;
            padding: 10px 0;
            width: 50%;
            background: rgb(212, 175, 55);
        }

            .btn-Profile:hover {
                background: #008BFF;
                color: #fff;
            }

        .fileContainer {
            overflow: hidden;
            position: relative;
            cursor: pointer;
            padding: 10px;
            margin-left: 2px;
        }

            .fileContainer [type=file] {
                cursor: inherit;
                display: block;
                font-size: 999px;
                filter: alpha(opacity=0);
                min-height: 100%;
                min-width: 100%;
                opacity: 0;
                position: absolute;
                right: 0;
                text-align: right;
                top: 0;
            }
    </style>
    <script type="text/javascript">
        function showimagepreview(input) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $("#<%=ImgImage.ClientID%>").attr('src', e.target.result);
                    $("#<%=btnUpdate.ClientID%>").removeAttr("style");
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
        function AddModalHeight() {
            $(".modal-body").css("height", "400px");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">

        <asp:Panel ID="PanelUserProfle" runat="server">
            <div class="container" style="margin-top: 50px; margin-bottom: 0px;">
                <h3 class="head">Your Profile</h3>
                <p class="urna">You can see your Profile.</p>
            </div>
            <div class="col-md-12" style="margin-top: 30px; margin-left: 100px; margin-bottom: 50px;">
                <div class="col-md-2" style="height: 100%; margin-top: 20px;">
                    <asp:Image ID="ImgImage" class="img-circle" runat="server" Style="height: 200px; width: 200px;" />
                    <asp:HiddenField ID="hdnImage" runat="server" />
                    <asp:Panel ID="PanelUploader" runat="server" Visible="false">
                        <label class="fileContainer" style="font-size: 16px; font-family: 'Sanchez', serif; color: #0CBBC8;">
                        <i class="fa fa-edit" style="color: #0CBBC8;"></i> Edit Picture
                        <asp:FileUpload ID="FileProfile" class="form-control" runat="server" onchange="showimagepreview(this)" Style="margin-top: 10px;"/>
                    </label>
                    <%--<asp:FileUpload ID="FileProfile" runat="server" Style="margin-top: 10px;" Visible="false" />--%>
                    </asp:Panel>
                </div>
                <div class="col-md-7" style="margin-top: 20px; margin-bottom: 20px;">
                    <div class="col-md-12" style="margin-bottom: 10px;">
                        <div class="col-md-5">
                            <asp:Label class="Profie-Lable" runat="server" Text="Name">Name<span style="margin-left:136px;">:</span></asp:Label>
                        </div>
                        <div class="col-md-7">
                            <asp:Label ID="lblName" class="Profie-Lable" runat="server" Text="Name" Style="font-family:Calibri; color : #999; margin-left: -40px;"></asp:Label>
                            <asp:TextBox ID="txtName" class="form-control" runat="server" Style="width: 60%;" placeholder="Enter Your Name" Visible="false" MaxLength="30" pattern="[A-Za-z\s_]+" title="Accept Alphabet Only"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12" style="margin-bottom: 10px;">
                        <div class="col-md-5">
                            <asp:Label class="Profie-Lable" runat="server" Text="Email">Email<span style="margin-left:137px;">:</span></asp:Label>
                        </div>
                        <div class="col-md-7">
                            <asp:Label ID="lblEmail" class="Profie-Lable" runat="server" Text="Name" Style="font-family:Calibri; color: #999; margin-left: -40px;"></asp:Label>
                            <asp:TextBox ID="txtEmail" class="form-control" runat="server" Style="width: 60%;" placeholder="Enter Your Email" Visible="false" type="email" AutoPostBack="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12" style="margin-bottom: 10px;">
                        <div class="col-md-5">
                            <asp:Label class="Profie-Lable" runat="server" Text="Contact No.">Contact No.<span style="margin-left:70px;">:</span></asp:Label>
                        </div>
                        <div class="col-md-7">
                            <asp:Label ID="lblCNO" class="Profie-Lable" runat="server" Text="Name" Style="font-family:Calibri; color: #999; margin-left: -40px;"></asp:Label>
                            <asp:TextBox ID="txtCNO" class="form-control" runat="server" Style="width: 60%;" placeholder="Enter Your Contact Number" Visible="false" type="number" min="999999999" max="9999999999999" oninvalid="this.setCustomValidity('Please Enter Valid Contact Number')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12" style="margin-bottom: 10px;">
                        <div class="col-md-5">
                            <asp:Label class="Profie-Lable" runat="server" Text="Email">Company Name<span style="margin-left:20px;">:</span></asp:Label>
                        </div>
                        <div class="col-md-7">
                            <asp:Label ID="lblComName" class="Profie-Lable" runat="server" Text="Name" Style="font-family:Calibri; color: #999; margin-left: -40px;"></asp:Label>
                            <asp:TextBox ID="txtComName" class="form-control" runat="server" Style="width: 60%;" placeholder="Enter Your Company Name" Visible="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-5">
                            <asp:Label class="Profie-Lable" runat="server" Text="Email">Company URL<span style="margin-left:36px;">:</span></asp:Label>
                        </div>
                        <div class="col-md-7">
                            <asp:LinkButton ID="lnkURl" runat="server"><asp:Label ID="lblURL" class="Profie-Lable" runat="server" Text="Name" Style="font-family:Calibri; color: #999; margin-left: -40px;"></asp:Label></asp:LinkButton>
                            <asp:TextBox ID="txtURl" class="form-control" runat="server" Style="width: 60%;" placeholder="Enter Your Company URL" Visible="false"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-3" style="margin-top: 60px;">
                    <div style="margin-bottom: 15px;">
                        <asp:Button CssClass="btn-Profile" ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                    </div>
                    <div style="margin-bottom: 15px;">
                        <asp:Button CssClass="btn-Profile" ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click" />
                    </div>
                    <div>
                        <asp:Button CssClass="btn-Profile" ID="btnChPass" runat="server" Text="Change Password" OnClick="btnChPass_Click" />
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelChangePass" runat="server" Visible="false">
            <div class="container" style="margin-top: 50px; margin-bottom: 0px;">
                <h3 class="head">Change Password</h3>
                <p class="urna">You can see Change Your Password.</p>
            </div>
            <div class="card container" style="padding: 0px; height: 100%; width: 700px; margin-top: 50px; margin-bottom: 90px;">
                <div class="col-md-12" style="margin-top: 50px; margin-left: 10px; margin-bottom: 20px;">
                    <div class="col-md-6">
                        <asp:Label ID="Label1" CssClass="Profie-Lable" runat="server" Text="Label">Current Password<span style="margin-left:26px;">:</span></asp:Label>
                    </div>
                    <div class="col-md-6" style="margin-left: -40px;">
                        <asp:TextBox ID="txtCurPass" class="form-control" runat="server" type="Password" Style="width: 80%;" placeholder="Enter Your Current Password" required="" AutoPostBack="true" OnTextChanged="txtCurPass_TextChanged"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12" style="margin-top: 20px; margin-left: 10px; margin-bottom: 20px;">
                    <div class="col-md-6">
                        <asp:Label ID="Label2" CssClass="Profie-Lable" runat="server" Text="Label">New Password<span style="margin-left:64px;">:</span></asp:Label>
                    </div>
                    <div class="col-md-6" style="margin-left: -40px;">
                        <asp:TextBox ID="txtNewPass" class="form-control" runat="server" Style="width: 80%;" placeholder="Enter New Password" required="" type="Password" pattern="(?=^.{8,}$).*$" title="Password must be 8 letter"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12" style="margin-top: 20px; margin-left: 10px; margin-bottom: 50px;">
                    <div class="col-md-6">
                        <asp:Label ID="Label3" CssClass="Profie-Lable" runat="server" Text="Label">Confirm Password<span style="margin-left:20px;">:</span></asp:Label>
                    </div>
                    <div class="col-md-6" style="margin-left: -40px;">
                        <asp:TextBox ID="txtComNewPass" class="form-control" runat="server" Style="width: 80%;" placeholder="Enter New Password" required="" type="Password" pattern="(?=^.{8,}$).*$" title="Password must be 8 letter"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12" style="margin-bottom: 15px;">
                    <div class="col-md-7" style="margin-left: 40px;">
                        <asp:Label ID="errorPassword" runat="server" Text="Invalid EmailID or Password" Visible="false" Style="color: #ff6a00; font-size: 18px;"></asp:Label>
                    </div>
                    <div>
                        <asp:Button CssClass="btn-Profile" ID="btnSubmit" runat="server" Text="Submit" Style="float: right; margin-right: 108px; margin-bottom: 30px; width: 15%;" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>

        </asp:Panel>

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
                                            <asp:Label ID="lblDeadlineDate" runat="server" Text="Assign date" Style="font-size: 18px; color: #212121; font-family: 'Sanchez', serif;">DeadLine Date <span style="margin-left:10px; margin-right:20px;">:</span></asp:Label>
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
                    <%--<asp:LinkButton ID="lnkBack" runat="server" Style="margin-top: 30px; margin-bottom: 20px;" OnClick="lnkBack_Click"><h1 style="text-align:center; font-size:14px; margin-left:-10px; color:#999; margin-top:10px;"><< Back</h1></asp:LinkButton>--%>
                    <asp:Button ID="btnBack" class="btn btn-default btn-back" runat="server" Text="Back" Style="" OnClick="btnBack_Click" />
                </div>
                <div id="StatusBar" class="container-fluid">
                    <div class="card" style="height: 100%; width: 95%; margin-top: 50px; margin-left: 30px; margin-bottom: 100px; padding-bottom: 20px;">
                        <div style="float: right; margin-top: 50px; margin-right: 40px;">
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

