<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddSkill.aspx.cs" Inherits="Admin_AddSkill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Add Category, Language & Skill form elements -->
    <div id="divPage" runat="server">
        <div class="col-md-13">
            <div class="col-md-12">
                <asp:Panel ID="errorSkill" runat="server" class="alert alert-error alert-dismissable fade in" Visible="false">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Opps!</strong> Skill already exist!!!!!
                </asp:Panel>
                <div style="margin-bottom: 1px;">
                    <div class="navbar-inner">
                        <h6>Add New Skill</h6>
                    </div>
                </div>
                <div style="border: 1px solid #CAC8C8; display: inline-block; width: 100%; padding: 20px; margin-bottom: 40px;">
                    <div class="col-md-7 control-group">
                        <span>Supper skill:</span>
                        <div class="controls">
                            <asp:DropDownList ID="ddSuperSkill" class="form-control" runat="server" Style="width: 100%;">
                                <asp:ListItem Value="0">select</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-7 control-group">
                        <span>Skill Name:</span>
                        <div class="controls">
                            <asp:TextBox ID="txtSkillName" class="form-control" runat="server" Style="width: 100%;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12 group-control">
                        <div class="controls">
                            <asp:Button ID="btnAddSkill" runat="server" Text="Add" class="btn  btn-primary " BackColor="#4d4d4d" Style="width: 15%; margin-right: 10px;" OnClick="btnAddSkill_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-12">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>View Skill</h6>
                </div>
            </div>
            <asp:Repeater ID="rptAddSkill" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped table-bordered dataTable" id="data-table" aria-describedby="data-table_info">
                        <thead>
                            <tr role="row">
                                <th class="sorting" role="columnheader" tabindex="0" aria-controls="data-table" rowspan="1" colspan="1" aria-label="First Name: activate to sort column ascending" style="cursor: pointer;">Skill Name</th>
                            </tr>
                        </thead>
                        <tbody role="alert" aria-live="polite" aria-relevant="all">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="odd">
                        <td><%# Eval("SkillName") %></td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="even">
                        <td><%# Eval("SkillName") %></td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </tbody>
                </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <!-- /Add Category, Language & Skill form elements -->
    <div id="divError" class="text-center col-md-12" runat="server" visible="false">
        <h1>You Can't Access this Page. You don't have Permission.</h1>
        <h3>Please contact to Admin.</h3>
    </div>
</asp:Content>

