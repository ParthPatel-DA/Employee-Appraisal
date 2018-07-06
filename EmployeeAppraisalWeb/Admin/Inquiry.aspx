<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Inquiry.aspx.cs" Inherits="Admin_Inquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Inquiries :</h1>
    <div style="margin-bottom: 1px;">
        <div class="navbar-inner">
            <h6>Inquiry Table</h6>
        </div>
    </div>
    <div class="table-overflow" style="border: 1px solid #c6c6c6;">
        <div class="table-responsive">
            <asp:Repeater ID="rptInqiry" runat="server">
                <HeaderTemplate>
                    <table class="table table-bordered table-checks" style="border: 0px;">
                        <thead>
                            <tr>
                                <th>
                                    <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="chkMultiselect" runat="server"  class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                </th>
                                <th style="min-width: 110px;">Person Name</th>
                                <th>EmailID</th>
                                <th>Mobile Number</th>
                                <th>Description</th>
                                <th>Apply</th>
                                <th>Reply</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="Chkselect" runat="server"  class="styled" style="opacity: 0;"></asp:CheckBox></span></div></center>
                        </td>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("EmailID") %></td>
                        <td><%# Eval("ContactNo") %></td>
                        <td><%# Eval("Description") %></td>
                        <td>
                            <asp:Button ID="btnApply" runat="server" Text="Apply" class="btn  btn-primary form-control" PostBackUrl='<%# "~/Admin/ClientReg.aspx?InquiryID=" + Eval("InquiryID") %>' BackColor="#4d4d4d" style="margin-right: 10px; padding-left: 10px; padding-right: 20px;" />
                        </td>
                        <td><a href='mailto:<%# Eval("EmailID") %>?subject=Reply for Inquiry&body=Hello Admin,'>Reply</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

