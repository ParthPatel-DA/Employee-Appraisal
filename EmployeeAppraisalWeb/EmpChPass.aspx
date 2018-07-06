<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmpChPass.aspx.cs" Inherits="EmpChPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Panel ID="PanelChangePass" runat="server">
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
</asp:Content>

