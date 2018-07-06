<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AdminGrid.aspx.cs" Inherits="Admin_empgrid" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        //function fnGetData ()   {    
        //    alert(window.localStorage.getItem("UserID"));
        //    alert(window.localStorage.getItem("Password"));
        //}   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<input id="Button1" type="button" value="button" onclick="fnGetData();" />--%>
    <div id="divPage" runat="server" class="col-md-12">
        <div class="table-responsive">
            <!-- Table with toolbar -->
            <div class="widget">
                <div style="margin-bottom: 1px;">
                    <div class="navbar-inner">
                        <h6>Admin Table</h6>
                    </div>
                </div>
                <ul class="toolbar">
                    <%--<li><a href="#" title=""><i class="icon-heart"></i><span>Upload file</span></a></li>--%>
                    <%--<li><a href="#" title=""><i class="icon-download-alt"></i><span>Download file</span></a></li>
                    <li><a href="#" title=""><i class="icon-cog"></i><span>Settings</span></a></li>--%>
                </ul>
                <div class="table-overflow">
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered dataTable" id="data-table" aria-describedby="data-table_info">
                            <thead>
                                <tr>
                                    <th>
                                        <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="checkRow" runat="server"  class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                    </th>
                                    <th>Image</th>
                                    <th>User Name</th>
                                    <th>UserID</th>
                                    <th>ContactNo</th>
                                    <th>CreatedBy</th>
                                    <th>CreatedOn</th>
                                    <asp:PlaceHolder ID="PlaceHolderUpdateHeader" runat="server">
                                        <th>Insert</th>
                                        <th>Update</th>
                                        <th>Delete</th>
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolderDeleteHeader" runat="server">
                                        <th>Delete Admin</th>
                                    </asp:PlaceHolder>
                                </tr>
                            </thead>
                            <asp:Repeater ID="rptViewAdmin" runat="server" OnItemCommand="Repeater1_ItemCommand">

                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox2" runat="server" class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                        </td>
                                        <td>
                                            <asp:Image ID="Image2" class="img-responsive img-circle" runat="server" ImageUrl='<%# "~/Admin/Upload/" + Eval("Image") %>' Width="100px" Height="100px" Style="margin: 10px;" />
                                            <asp:HiddenField ID="hdnImage" runat="server" Value='<%# Eval("Image") %>'/>
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("AdminID") %>' />
                                            <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="UserIDLabel" runat="server" Text='<%# Eval("EmailID") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ContactNo") %>' />
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("CreatedBy") %>' />
                                            <asp:Literal ID="LtrCBy" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Convert.ToDateTime(Eval("CreatedOn")).ToShortDateString() %>' />
                                        </td>

                                        <asp:PlaceHolder ID="PlaceHolderUpdate" runat="server">
                                            <td>
                                                <center><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "img/" + Eval("IsInsert") + ".png" %>' Style="width: 25px;" CommandName="Insert" CommandArgument='<%# Eval("AdminID") %>' /></center>
                                            </td>
                                            <td>
                                                <center><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl='<%# "img/" + Eval("IsUpdate") + ".png" %>' Style="width: 25px;" CommandName="Update" CommandArgument='<%# Eval("AdminID") %>' /></center>
                                            </td>
                                            <td>
                                                <center><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl='<%# "img/" + Eval("IsDelete") + ".png" %>' Style="width: 25px;" CommandName="Delete" CommandArgument='<%# Eval("AdminID") %>' /></center>
                                            </td>
                                        </asp:PlaceHolder>

                                        <asp:PlaceHolder ID="PlaceHolderDelete" runat="server">
                                            <td>
                                                <center><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="img/remove.png" AlternateText="" Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("AdminID") %>' /></center>
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
            <!-- /table with toolbar -->
        </div>
    </div>
    <div id="divError" class="text-center col-md-12" runat="server" visible="false">
        <h1>You Can't Access this Page. You don't have Permission.</h1>
        <h3>You are not Super Admin.</h3>
    </div>
</asp:Content>

