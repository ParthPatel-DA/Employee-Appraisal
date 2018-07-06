<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ViewPostProject.aspx.cs" Inherits="Admin_OnlineProject" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="table-responsive">
        <!-- Table with toolbar -->
        <div class="widget">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Online Project</h6>
                </div>
            </div>

            <div class="table-overflow">
                <div class="table-responsive">
                    <asp:Repeater ID="rptOnlineProject" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered table-checks">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Client Name</th>
                                        <th>Category Name</th>
                                        <th>Title</th>
                                        <th>Description</th>
                                        <th>Posted Date</th>
                                        <th>DeadLine Date</th>
                                        <th>Assign</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:HiddenField ID="hdnClientName" runat="server" Value='<%#Eval("ClientID") %>' />
                                    <asp:Literal ID="ltrClient" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdnCategory" runat="server" Value='<%#Eval("CategoryID") %>' />
                                    <asp:Literal ID="ltrCategory" runat="server"></asp:Literal>
                                </td>
                                <td><%# Eval("Title") %></td>
                                <td><%# Eval("Description") %></td>
                                <td><%# Convert.ToDateTime(Eval("CreateOn")).ToShortDateString() %></td>
                                <td><%# Convert.ToDateTime(Eval("DeadlineDate")).ToShortDateString() %></td>
                                <td>
                                    <asp:Button ID="btnAssign" class="btn-danger" runat="server" Text="Assign" CommandName="AssignProject" PostBackUrl='<%# "~/Admin/Project.aspx?PostProjectID=" +  Eval("ProjectID") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

