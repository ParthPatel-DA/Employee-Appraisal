<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ViewFeedBack.aspx.cs" Inherits="Admin_ViewFeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="table-responsive">
        <!-- Table with toolbar -->
        <div class="widget">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>FeedBack List</h6>
                </div>
            </div>

            <div class="table-overflow">
                <div class="table-responsive">
                    <asp:Repeater ID="rptFeedBack" runat="server" OnItemCommand="rptFeedBack_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered table-checks" style="width:100%">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Client Name</th>
                                        <th>EmailID</th>
                                        <th>Project Name</th>
                                        <th>FeedBack Point</th>
                                        <th>Description</th>
                                        <th>FeedBack Date</th>
                                        <th>Read</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Literal ID="ltrClientName" runat="server" Text='<%# Eval("ClientID") %>'></asp:Literal>
                                </td>
                                <td><%# Eval("EmailID") %></td>
                                <td>
                                    <asp:Literal ID="ltrProjectName" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Literal>
                                </td>
                                <td><%# Eval("FeedBackPoint") %></td>
                                <td><%# Eval("Description") %></td>
                                <td><%# Eval("CreatedOn") %></td>
                                <td>
                                        <center><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl='<%# "img/" + Eval("IsRead") + ".png" %>' Style="width: 25px;" CommandName="Read" CommandArgument='<%# Eval("FeedBackID") %>' /></center>
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

    <div class="table-responsive">
        <!-- Table with toolbar -->
        <div class="widget">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>FeedBack</h6>
                </div>
            </div>

            <div class="table-overflow">
                <div class="table-responsive">
                    <asp:Repeater ID="rptReadFeedBack" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered table-checks" style="width:100%">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Client Name</th>
                                        <th>EmailID</th>
                                        <th>Project Name</th>
                                        <th>FeedBack Point</th>
                                        <th>Description</th>
                                        <th>FeedBack Date</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Literal ID="ltrClientName" runat="server" Text='<%# Eval("ClientID") %>'></asp:Literal>
                                </td>
                                <td><%# Eval("EmailID") %></td>
                                <td>
                                    <asp:Literal ID="ltrProjectName" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Literal>
                                </td>
                                <td><%# Eval("FeedBackPoint") %></td>
                                <td><%# Eval("Description") %></td>
                                <td><%# Eval("CreatedOn") %></td>
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


