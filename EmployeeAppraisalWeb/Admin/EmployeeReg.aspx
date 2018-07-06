<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeReg.aspx.cs" Inherits="Admin_EmployeeReg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        span {
            font-size: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Employee form elements -->
    <asp:Panel ID="errorEmail" runat="server" class="alert alert-error alert-dismissable fade in" Visible="false">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Opps!</strong> Email already exist!!!!!
    </asp:Panel>
    <div id="divPage" runat="server" class="col-md-12">
        <div style="margin-bottom: 1px;">
            <div class="navbar-inner">
                <h6>Add New Employee</h6>
            </div>
        </div>
        <div style="border: 1px solid #CAC8C8; display: inline-block; width: 100%; padding: 20px;">

            <div class="col-md-6 control-group">
                <span>Employee First Name:</span>
                <div class="controls">
                    <asp:TextBox ID="txtEfname" runat="server" class="form-control" required="" MaxLength="20" pattern="[A-Za-z\s_]+" oninvalid="this.setCustomValidity('Accept Alphabet Only')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6 control-group">
                <span>Employee Last Name:</span>
                <div class="controls">
                    <asp:TextBox ID="txtElname" runat="server" class="form-control" required="" MaxLength="20" pattern="[A-Za-z\s_]+"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6 control-group">
                <span>Employee EmailID:</span>
                <div class="controls">
                    <asp:TextBox ID="txtEmail" type="email" runat="server" class="form-control" required="" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6 control-group">
                <span>Contact No:</span>
                <div class="controls">
                    <asp:TextBox ID="txtEcno" type="number" runat="server" class="form-control" required="" min="999999999" max="9999999999999" oninvalid="this.setCustomValidity('Please Enter Valid Contact Number')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6 control-group">
                <span>Employee Gender:</span>
                <div class="controls">
                    <asp:DropDownList ID="ddGender" class="form-control" runat="server" required="">
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="1">Male</asp:ListItem>
                        <asp:ListItem Value="2">Female</asp:ListItem>
                        <asp:ListItem Value="3">Other</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-md-6 control-group">
                <span>Employee Password:</span>
                <div class="controls">
                    <asp:TextBox ID="txtEpwd" runat="server" type="password" class="form-control" required="" pattern="(?=^.{8,}$).*$" title="Password must be 8 letter"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6 group-control" style="float:left;">
                <div class="controls">
                    <asp:Button ID="btnInsert" runat="server" Text="Insert" class="btn  btn-primary form-control" BackColor="#4d4d4d" Style="width: 25%; margin-right: 10px; margin-left:-508px;" OnClick="btnInsert_Click" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn  btn-primary form-control" BackColor="#4d4d4d" Style="width: 25%;" OnClick="btnReset_Click"/>
                </div>
            </div>

        </div>
    </div>
    <!-- /Employee form elements -->
    <div id="divError" class="text-center col-md-12" runat="server" visible="false">
        <h1>You Can't Access this Page. You don't have Permission.</h1>
        <h3>Please contact to Admin.</h3>
    </div>

</asp:Content>

