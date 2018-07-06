<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="EmpGrid.aspx.cs" Inherits="Admin_empgrid" EnableEventValidation="false" ValidateRequest="false" %>

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

    <div class="table-responsive">
        <!-- Table with toolbar -->
        <div class="widget">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Employee Table</h6>
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
                           <%-- <tr role="row">
                                <th rowspan="1" colspan="1" style="cursor: pointer;"></th>
                            </tr>--%>
                            <tr>
                                <th>
                                    <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox3" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck" CommandArgument='<%# Eval("EmpID") %>' ></asp:CheckBox></span></div></center>
                                </th>
                                <th>Image</th>
                                <th>User Name</th>
                                <th>EmailID</th>
                                <th>Gender</th>
                                <th>ContactNo</th>
                                <th>Address</th>
                                <th>CreatedBy</th>
                                <th>CreatedOn</th>
                                <asp:PlaceHolder ID="PlaceHolderActiveHeader" runat="server">
                                    <th>Delete</th>
                                </asp:PlaceHolder>
                            </tr>
                        </thead>
                        <asp:Repeater ID="rptEmp" runat="server" OnItemCommand="rptEmp_ItemCommand">

                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox4" runat="server" class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                    </td>
                                    <td>
                                        <asp:Image ID="Image2" class="img-responsive img-circle" runat="server" ImageUrl='<%# "~/Admin/EmpUpload/" + Eval("ProfilePic") %>' Width="100px" Height="100px" Style="margin-right: 10px;" />
                                        <asp:HiddenField ID="hdnImage" runat="server" Value='<%# Eval("ProfilePic") %>' />
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("EmpID") %>' />
                                        <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="UserIDLabel" runat="server" Text='<%# Eval("EmailID") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblContactNo" runat="server" Text='<%# Eval("ContactNo") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>' /><br />
                                        <asp:Label ID="lblLandmark" runat="server" Text='<%# Eval("Landmark") %>' />
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("CreatedBy") %>' />
                                        <asp:Literal ID="ltrCBy" runat="server" Text="---"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Convert.ToDateTime(Eval("CreatedOn")).ToShortDateString() %>' />
                                    </td>
                                    <asp:PlaceHolder ID="PlaceHolderActive" runat="server">
                                        <td>
                                            <center><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="img/remove.png" Style="width: 35px;" CommandName="Active" CommandArgument='<%# Eval("EmpID") %>' /></center>
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
</asp:Content>

