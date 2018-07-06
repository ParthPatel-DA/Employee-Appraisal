<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ClientGrid.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="table-responsive">
        <!-- Table with toolbar -->
        <div class="widget">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Client Table</h6>
                </div>
            </div>
            <ul class="toolbar">
                <%--<li><a href="#" title=""><i class="icon-heart"></i><span>Upload file</span></a></li>--%>
                <%--<li><a href="#" title=""><i class="icon-download-alt"></i><span>Download file</span></a></li>
                <li><a href="#" title=""><i class="icon-cog"></i><span>Settings</span></a></li>--%>
            </ul>
            <div class="table-overflow">
                <div class="table-responsive">
                    <asp:Repeater ID="rptClient" runat="server">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered dataTable" id="data-table" aria-describedby="data-table_info">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Image</th>
                                        <th>Client Name</th>
                                        <th>EmailID</th>
                                        <th>ContactNo</th>
                                        <th>Company Name</th>
                                        <th>CreatedBy</th>
                                        <th>CreatedOn</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Image ID="imgClient" class="img-responsive img-circle" runat="server" ImageUrl='<%# "~/ClientUpload/" + Eval("ImageName") %>' Width="100px" Height="100px" Style="margin: 10px;" />
                                    <asp:HiddenField ID="hdnImage" runat="server" Value='<%# Eval("ImageName") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ClientName" runat="server" Text='<%# Eval("ClientName") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="EmailID" runat="server" Text='<%# Eval("EmailID") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ContactNo" runat="server" Text='<%# Eval("ContactNo") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ComName" runat="server" Text='<%# Eval("CompanyName") %>' />
                                </td>
                                <td>
                                    <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("CreatedBy") %>' />
                                    <asp:Literal ID="LtrCBy" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Label ID="Createdon" runat="server" Text='<%# Convert.ToDateTime(Eval("CreatedOn")).ToShortDateString() %>'/>
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
        <!-- /table with toolbar -->
    </div>
</asp:Content>

