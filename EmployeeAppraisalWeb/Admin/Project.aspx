<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Project.aspx.cs" Inherits="Admin_AssignProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .group-control {
            padding: 10px 20px 10px 20px;
        }

        span {
            font-size: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Add Project -->
    <div id="divPage" runat="server" class="col-md-12">
        <div style="margin-bottom: 1px;">
            <div class="navbar-inner">
                <h6>Add Project</h6>
            </div>
        </div>
        <div style="border: 1px solid #CAC8C8; display: inline-block; width: 100%; padding: 20px;">

            <div class="col-md-6 group-control">
                <span>Project Name :</span>
                <div class="controls">
                    <asp:TextBox ID="txtPname" runat="server" Style="width: 100%;" required="" pattern="^[A-Za-z\s\. ]+$" oninvalid="this.setCustomValidity('Accept Alphabet Only')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6 group-control">
                <span>Client :</span>
                <div class="controls">
                    <asp:DropDownList ID="ddClient" class="form-control" runat="server" required="">
                        <asp:ListItem Value="">Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-6 group-control">
                <span>Category
                    <asp:Label ID="lblOther" runat="server" Text="Other" Visible="false" Style="color: #ff0000;"></asp:Label>:</span>
                <div class="controls">
                    <asp:DropDownList ID="ddCategory" class="form-control" runat="server" required="" AutoPostBack="True" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged">
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-6 group-control">
                <span>Language :</span>
                <div class="controls">
                    <asp:DropDownList ID="ddLanguage" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddLanguage_SelectedIndexChanged">
                        <asp:ListItem Value="">Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-6 group-control">
                <span>Days :</span>
                <div class="controls">
                    <asp:TextBox ID="txtDays" runat="server" type="number" Style="width: 100%;" required="" min="1" max="1825" pattern="[1-9][0-9]{0,2}" oninvalid="this.setCustomValidity('Please Enter Days of Project Plan between 7 to 1825 days(5 Years)')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-12 group-control">
                <span>Description :</span>
                <div class="controls">
                    <asp:TextBox ID="txtDes" class="form" runat="server" Style="width: 100%; height: 150px;" TextMode="MultiLine" required=""></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4 group-control">
                <div class="controls">
                    <asp:Button ID="btnAddProject" runat="server" Text="Add Project" class="btn  btn-primary form-control" BackColor="#4d4d4d" Style="margin-bottom: 10px;" OnClick="btnAddProject_Click" />
                </div>
            </div>


        </div>
    </div>
    <!-- /Add Project -->
    <div id="divError" class="text-center col-md-12" runat="server" visible="false">
        <h1>You Can't Access this Page. You don't have Permission.</h1>
        <h3>Please contact to Admin.</h3>
    </div>
</asp:Content>

