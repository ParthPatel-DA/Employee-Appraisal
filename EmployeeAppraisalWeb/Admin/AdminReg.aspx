<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AdminReg.aspx.cs" Inherits="AdminReg" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <style>
        span {
            font-size: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Form elements -->
    <asp:Panel ID="errorEmail" runat="server" class="alert alert-error alert-dismissable fade in" Visible="false">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Opps!</strong> Email already exist!!!!!
    </asp:Panel>
    <form method="post">
        <div id="divPage" runat="server" class="col-md-12">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Add New Admin</h6>
                </div>
            </div>
            <div style="border: 1px solid #CAC8C8; display: inline-block; width: 100%; padding: 20px;">

                <div class="col-md-6 control-group">
                    <span>Admin First Name:</span>
                    <div class="controls">
                        <asp:TextBox ID="txtfnm" class="form-control" runat="server" Style="width: 100%;" required="" MaxLength="20" pattern="^[A-Za-z]+$" oninvalid="this.setCustomValidity('Accept Alphabet Only')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6 control-group">
                    <span>Admin Last Name:</span>
                    <div class="controls">
                        <asp:TextBox ID="txtlnm" class="form-control" runat="server" Style="width: 100%;" required="" MaxLength="20" pattern="^[A-Za-z]+$" oninvalid="this.setCustomValidity('Accept Alphabet Only')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6 control-group">
                    <span>Admin EmailID:</span>
                    <div class="controls">
                        <asp:TextBox ID="txtEmailID" type="email" class="form-control" runat="server" Style="width: 100%;" AutoPostBack="true" required="" OnTextChanged="txtEmailID_TextChanged"></asp:TextBox>
                    </div>
                    <%--<div style="margin-bottom: 30px;">
                    <center><asp:Label ID="errorEmail" runat="server" Text="Email already Exist..." Visible="false" style="color:#ff6a00; font-size:18px; margin-bottom:50px;"></asp:Label></center>
                </div>--%>
                </div>

                <div class="col-md-6 control-group">
                    <span>Admin Password:</span>
                    <div class="controls">
                        <asp:TextBox ID="txtpass" class="form-control" runat="server" TextMode="password" Style="width: 100%;" required="" pattern="(?=^.{5,}$).*$" title="Password must be 5 letter"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6 control-group">
                    <span>ContactNo:</span>
                    <div class="controls">
                        <asp:TextBox ID="txtcno" class="form-control" runat="server" Style="width: 100%;" required="" type="number" min="999999999" max="9999999999999" oninvalid="this.setCustomValidity('Please Enter Valid Contact Number')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6 control-group">
                    <span>Admin Profile Image:</span>
                    <div class="controls">
                        <asp:FileUpload ID="FileUpload1" runat="server" Style="width: 100%;" />
                    </div>
                </div>
                <div class="col-md-12 control-group">
                    <div class="col-md-6 ">
                        <span>Admin Permissions:</span>
                        <div class="controls">
                            <asp:CheckBox ID="Chkisinsert" runat="server" /><font style="font-size: 14px; margin-right: 10px;"> IsInsert</font>
                            <asp:CheckBox ID="Chkisupdate" runat="server" /><font style="font-size: 14px; margin-right: 10px;"> IsUpdate</font>
                            <asp:CheckBox ID="Chkisdelete" runat="server" /><font style="font-size: 14px; margin-right: 10px;"> IsDelete</font><br />

                        </div>
                    </div>

                    <div class="col-md-6 ">
                        <span>Admin Type:</span>
                        <div class="controls">
                            <asp:CheckBox ID="Chkissupper" runat="server" /><font style="font-size: 14px; margin-right: 10px;"> IsSupper</font>
                        </div>
                    </div>

                </div>

                <div class="col-md-6 group-control">
                    <div class="controls">
                        <asp:Button ID="btninsert" runat="server" Text="Insert" class="btn  btn-primary " BackColor="#4d4d4d" Style="width: 25%; margin-right: 10px;" OnClick="btninsert_Click1" />
                        <asp:Button ID="btnreset" runat="server" Text="Reset" class="btn btn-primary " BackColor="#4d4d4d" Style="width: 25%;" OnClick="btnreset_Click" formnovalidate/>
                    </div>
                </div>


            </div>
        </div>
    </form>
    <!-- /form elements -->
    <div id="divError" class="text-center col-md-12" runat="server" visible="false">
        <h1>You Can't Access this Page. You have no Permission.</h1>
        <h3>Please contact to Admin.</h3>
    </div>
</asp:Content>
