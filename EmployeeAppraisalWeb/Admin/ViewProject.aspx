<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ViewProject.aspx.cs" Inherits="ProjectGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog" style="background-color: transparent; border: 0px solid; margin-bottom: 7%;">
        <div class="modal-dialog" style="width: 40%; margin-left: 630px;">

            <!-- Modal content-->
            <div class="modal-content" style="border-radius: 0px;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Project Manager :</h4>
                </div>
                <asp:HiddenField ID="hdnProjectID" runat="server" />
                <div class="modal-body" style="">
                    <asp:DropDownList ID="ddProjetctManager" runat="server"></asp:DropDownList>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAddSkill" class="btn btn-default" runat="server" Text="Add" OnClick="btnAddSkill_Click" />
                </div>
            </div>

        </div>
    </div>
    <!-- \Modal -->



    <!-- View All Project (Running Project) -->
    <div class="table-responsive" style="margin-top: 20px;">
        <!-- Table with toolbar -->
        <div class="widget">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Project List (Running Project)</h6>
                </div>
            </div>
            <ul class="toolbar">
                <%--<li><a href="#" title=""><i class="icon-heart"></i><span>Upload file</span></a></li>--%>
                <li>
                    <asp:LinkButton ID="lnkDloadRunPro" runat="server"><i class="icon-download-alt"></i><span>Download file</span></asp:LinkButton>
                </li>
                <li><a href="#" title=""><i class="icon-cog"></i><span>Settings</span></a></li>
            </ul>
            <div class="table-overflow" style="border: 1px solid #c6c6c6;">
                <div class="table-responsive">
                    <asp:Repeater ID="rptProRunning" runat="server" OnItemCommand="rptProRunning_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered table-checks" style="border: 0px;">
                                <thead>
                                    <tr>
                                        <th>
                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="checkRow" runat="server"  class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                        </th>
                                        <th>Track</th>
                                        <th style="min-width: 110px;">Project Name</th>
                                        <th>Category</th>
                                        <th>Language</th>
                                        <th>Client</th>
                                        <th>Manager</th>
                                        <th>Duration</th>
                                        <th style="min-width: 120px;">Pandding Days</th>
                                        <th>Status</th>
                                        <th>Active</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td>
                                    <center><asp:ImageButton ID="imgbtnIsTMW" runat="server" ImageUrl="../img/TMWTBl.png" style="width: 12px; height: 30px;" CommandName="Track" CommandArgument='<%# Eval("ProjectID") %>' ></asp:ImageButton><%--<img src="../img/TMWTBl.png" style="width: 12px; height: 30px;" />--%></center>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkTitle" runat="server" Style="color: #333" CommandName="Modal" CommandArgument='<%# Eval("ProjectID") %>'><%# Eval("Title") %></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hidCategory" runat="server" Value='<%# Eval("CategoryID") %>' />
                                    <asp:Literal ID="ltrCategory" runat="server" Text="---"></asp:Literal>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hidLanguage" runat="server" Value='<%# Eval("LanguageID") %>' />
                                    <asp:Literal ID="ltrLanguage" runat="server" Text="---"></asp:Literal>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hidClient" runat="server" Value='<%# Eval("ClientID") %>' />
                                    <asp:Literal ID="ltrClient" runat="server" Text="---"></asp:Literal>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hidManager" runat="server" Value='<%# Eval("ManagerID") %>' />
                                    <asp:Literal ID="ltrManager" runat="server" Text="---"></asp:Literal>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdnCreatedOn" runat="server" Value='<%# Eval("CreatedOn") %>' />
                                    <asp:HiddenField ID="hdnAssignDay" runat="server" Value='<%# Eval("AssignDate") %>' />
                                    <asp:HiddenField ID="hdnDeadLine" runat="server" Value='<%# Eval("DeadlineDate") %>' />
                                    <asp:Literal ID="ltrDuration" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblPanddingDays" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Label ID="lblStatus" runat="server" Text="NotComplet" />
                                </td>
                                <td>
                                    <center><asp:ImageButton ID="imgbtnIsActive" runat="server" ImageUrl='<%# "img/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("ProjectID") %>' /></center>
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
    <!-- /View All Project (Running Project) -->
    <hr style="border: 1px solid #c6c6c6; margin-top: -10px;" />

    <!-- View All Project (Pending Project) -->
    <div class="table-responsive" style="margin-top: 20px;">
        <!-- Table with toolbar -->
        <div class="widget">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Project List (Pending Project)</h6>
                </div>
            </div>
            <ul class="toolbar">

                <li>
                    <asp:LinkButton ID="lnkDloadPendPro" runat="server"><i class="icon-download-alt"></i><span>Download file</span></asp:LinkButton>
                </li>
                <li><a href="#" title=""><i class="icon-cog"></i><span>Settings</span></a></li>
            </ul>
            <div class="table-overflow" style="border: 1px solid #c6c6c6;">
                <div class="table-responsive">
                    <asp:Repeater ID="reptprgpanding" runat="server" OnItemCommand="reptprgpanding_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered table-checks" style="border: 0px;">
                                <thead>
                                    <tr>
                                        <th>
                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox1" runat="server"  class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                        </th>
                                        <th style="min-width: 110px;">Project Name</th>
                                        <th>Category</th>
                                        <th>Client</th>
                                        <th>Duration</th>
                                        <th style="min-width: 110px;">Starting Date</th>
                                        <th style="min-width: 115px;">Padding Days</th>
                                        <th>Active</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox1" runat="server"  class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                </td>
                                <td>
                                    <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>' />
                                </td>
                                <td>
                                    <asp:HiddenField ID="hidCategory" runat="server" Value='<%# Eval("CategoryID") %>' />
                                    <asp:Literal ID="ltrCategory" runat="server" Text="---"></asp:Literal></td>
                                <td>
                                    <asp:HiddenField ID="hidClient" runat="server" Value='<%# Eval("ClientID") %>' />
                                    <asp:Literal ID="ltrClient" runat="server" Text="---"></asp:Literal>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdnAssignDay" runat="server" Value='<%# Eval("AssignDate") %>' />
                                    <asp:HiddenField ID="hdnDeadLine" runat="server" Value='<%# Eval("DeadlineDate") %>' />
                                    <asp:HiddenField ID="hdnCreatedOn" runat="server" Value='<%# Eval("CreatedOn") %>' />
                                    <asp:Literal ID="ltrDuration" runat="server"></asp:Literal></td>
                                <td><%# Convert.ToDateTime(Eval("CreatedOn")).ToShortDateString() %></td>
                                <td>
                                    <asp:Literal ID="lblPanddingDays" runat="server"></asp:Literal></td>
                                <td>
                                    <center><asp:ImageButton ID="imgbtnIsActiveFalse" runat="server" ImageUrl='<%# "img/" + Eval("IsActive") + ".png" %>'  Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("ProjectID") %>' /></center>
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
    <!-- /View All Project (Pending Project) -->
    <hr style="border: 1px solid #c6c6c6; margin-top: -10px;" />

    <!-- View All Project (Completed Project) -->
    <div class="table-responsive" style="margin-top: 20px;">
        <!-- Table with toolbar -->
        <div class="widget">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Project List (Completed Project)</h6>
                </div>
            </div>
            <ul class="toolbar">

                <li>
                    <asp:LinkButton ID="lnkDloadCompPro" runat="server"><i class="icon-download-alt"></i><span>Download file</span></asp:LinkButton>
                </li>
                <li><a href="#" title=""><i class="icon-cog"></i><span>Settings</span></a></li>
            </ul>
            <div class="table-overflow" style="border: 1px solid #c6c6c6;">
                <asp:Repeater ID="reptprjcomplete" runat="server" OnItemCommand="reptprjcomplete_ItemCommand" >
                    <HeaderTemplate>
                        <div class="table-responsive">
                            <table class="table table-bordered table-checks" style="border: 0px;">
                                <thead>
                                    <tr>
                                        <th>
                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox2" runat="server"  class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                        </th>
                                        <th style="min-width: 110px;">Project Name</th>
                                        <th>Category</th>
                                        <th>Client</th>
                                        <th>Manager</th>
                                        <th>Duration</th>
                                        <th style="min-width: 110px;">Starting Date</th>
                                        <th style="min-width: 115px;">Complition Date</th>
                                        <th style="min-width: 105px;">Work Quality</th>
                                        <th>View</th>
                                    </tr>
                                </thead>
                                <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox2" runat="server"  class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                            </td>
                            <td>
                                <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>' />
                            </td>
                            <td>
                                <asp:HiddenField ID="hidCategory" runat="server" Value='<%# Eval("CategoryID") %>' />
                                <asp:Literal ID="ltrCategory" runat="server" Text="---"></asp:Literal></td>
                            <td>
                                <asp:HiddenField ID="hidClient" runat="server" Value='<%# Eval("ClientID") %>' />
                                <asp:Literal ID="ltrClient" runat="server" Text="---"></asp:Literal>
                            </td>
                            <td>
                                <asp:HiddenField ID="hidManager" runat="server" Value='<%# Eval("ManagerID") %>' />
                                <asp:Literal ID="ltrManager" runat="server" Text="---"></asp:Literal></td>
                            <td>
                                <asp:HiddenField ID="hdnCreatedOn" runat="server" Value='<%# Eval("CreatedOn") %>' />
                                <asp:HiddenField ID="hdnAssignDay" runat="server" Value='<%# Eval("AssignDate") %>' />
                                <asp:HiddenField ID="hdnDeadLine" runat="server" Value='<%# Eval("DeadlineDate") %>' />
                                <asp:Literal ID="ltrDuration" runat="server"></asp:Literal></td>
                            <td><%# Convert.ToDateTime(Eval("AssignDate")).ToShortDateString() %></td>
                            <td><%# Convert.ToDateTime(Eval("CreatedOn")).ToShortDateString() %></td>
                            <td>
                                <asp:Literal ID="ltrPoint" runat="server"></asp:Literal>
                                <asp:HiddenField ID="hdnProjectID" runat="server" Value='<%# Eval("ProjectID") %>' />
                            </td>
                            <td><asp:Button runat="server" class="btn-danger" Text="View" CommandName="Download" PostBackUrl='<%# "~/Admin/ProjectDetail.aspx?ProjectID=" + Eval("ProjectID") %>' ></asp:Button></td>
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
    <!-- /View All Project (Completed Project) -->
    <%--<hr style="border: 1px solid #c6c6c6; margin-top: -10px;" />--%>
</asp:Content>

