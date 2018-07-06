<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="VerifyEmployee.aspx.cs" Inherits="Admin_VerifyEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divPage" runat="server" class="table-responsive">
        <!-- Table with toolbar -->
        <div class="widget">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Verify Employee</h6>
                </div>
            </div>

            <div class="table-overflow">
                <div class="table-responsive">
                    <table class="table table-striped table-bordered dataTable" id="data-table" aria-describedby="data-table_info">
                        <thead>
                            <tr>
                                <th></th>
                                <th>Employee Name</th>
                                <th>Email</th>
                                <th>Contact Number</th>
                                <th>Registration Date</th>
                                <th>Verify</th>
                                <asp:PlaceHolder ID="PlaceHolderDeleteHeader" runat="server">
                                    <th>Delete</th>
                                </asp:PlaceHolder>
                            </tr>
                        </thead>
                        <asp:Repeater ID="rptVerifyEmployee" runat="server" OnItemCommand="rptVerifyEmployee_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td></td>
                                    <td><%# Eval("FirstName") + " " + Eval("LastName") %></td>
                                    <td><%# Eval("EmailID") %></td>
                                    <td><%# Eval("ContactNo") %></td>
                                    <td><%# Convert.ToDateTime(Eval("CreatedOn")).ToShortDateString() %></td>
                                    <td>
                                        <center><asp:Button ID="btnVerify" class="btn-danger" runat="server" Text="Verify" CommandName="Email" CommandArgument='<%# Eval("EmpID") %>' /></center>
                                    </td>
                                    <asp:PlaceHolder ID="PlaceHolderDelete" runat="server">
                                        <td>
                                            <center><asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="img/remove.png" Style="width: 35px;" CommandName="Delete" CommandArgument='<%# Eval("EmpID") %>' /></center>
                                        </td>
                                    </asp:PlaceHolder>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                </div>
            </div>
        </div>
    </div>

    <div id="divError" class="text-center col-md-12" runat="server" visible="false">
        <h1>You Can't Access this Page. You don't have  Permission.</h1>
        <h3>Please contact to Admin.</h3>
    </div>
</asp:Content>

