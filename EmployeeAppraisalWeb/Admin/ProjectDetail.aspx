<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectDetail.aspx.cs" Inherits="Admin_ProjectDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-12">
        <asp:LinkButton ID="lnkTrack" runat="server" OnClick="lnkTrack_Click">
        <div style="float: right; border: 1px solid #bbbbbb; padding: 10px; border-radius: 0px; color: #808080; padding-left: 15px; padding-right: 15px;">
            <%--<img src="../img/TMWTBl.png" style="height: 30px; width: 13px; margin-right: 5px;" />--%>
            <span class="glyphicon glyphicon-save"></span>
            Download
        </div>
        </asp:LinkButton>
        <%--<asp:Button ID="btnmodule" runat="server" Text="Add Module" class="btn" Style="border: none; width: 125px; height: 42px; float: right; margin: -25px 20px 10px 0px; opacity: 0;" OnClick="btnmodule_Click" />--%>
    </div>

    <asp:Panel ID="PanelPDF" runat="server">
        <h2>Project Name :
        <asp:Literal ID="ltrProjectName" runat="server"></asp:Literal></h2>

        <h4>Manager Name : 
            <asp:Literal ID="ltrManager" runat="server"></asp:Literal>
            <%--Om Patel<small> (1001)</small>--%></h4>

        <hr style="border: 1px solid #c6c6c6; margin-top: 10px;" />
        <asp:Repeater ID="rptModule" runat="server">
            <ItemTemplate>
                <h4><%# Container.ItemIndex + 1 %>. Module Name :
                <asp:Literal ID="ltrModuleName" runat="server" Text='<%# Eval("Title") %>'></asp:Literal></h4>
                <h5>Team Leader Name :
                    <asp:Literal ID="ltrTeamLeader" runat="server"></asp:Literal><%--Ram Patel<small> (1001)--%></small></h5>
                <asp:HiddenField ID="hdnModuleID" runat="server" Value='<%# Eval("ModuleID") %>' />
                <div class="table-responsive" style="margin-top: 20px;">
                    <!-- Table with toolbar -->
                    <div class="widget">
                        <div style="margin-bottom: 1px;">
                            <div class="navbar-inner">
                                <h6>Task List of
                                <asp:Literal ID="ltrTaskModuleName" runat="server" Text='<%# Eval("Title") %>'></asp:Literal></h6>
                            </div>
                        </div>
                        <div class="table-overflow" style="border: 1px solid #c6c6c6;">
                            <asp:Repeater ID="rptTrackTask" runat="server">
                                <HeaderTemplate>
                                    <div class="table-responsive">
                                        <table class="table table-bordered table-checks" style="border: 0px;">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="checkRow" runat="server"  class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                                    </th>
                                                    <th style="min-width: 90px;">Task Name</th>
                                                    <th>Employee Name</th>
                                                    <th style="min-width: 100px;">Assign Date</th>
                                                    <th>Submitted Date</th>
                                                    <th>Completion</th>
                                                    <%--<th>Duration Left</th>
                                                    <th>Status</th>--%>
                                                    
                                                    <%--<th>View</th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="checkRow" runat="server"  class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                        </td>
                                        <td><%# Eval("Title") %></td>
                                        <td>
                                            <asp:HiddenField ID="hdnTaskID" runat="server" Value='<%# Eval("TaskID") %>' />
                                            <asp:Literal ID="ltrEmp" runat="server"></asp:Literal>
                                        </td>
                                        <td><%# Convert.ToDateTime(Eval("AssignDate")).ToShortDateString() %></td>
                                        <td>
                                            <asp:Literal ID="ltrSubmitionDate" runat="server" Text='<%# Convert.ToDateTime(Eval("SubmitionDate")).ToShortDateString() %>'></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hdnCreatedOn" runat="server" Value='<%# Eval("CreatedOn") %>' />
                                            <asp:HiddenField ID="hdnAssignDay" runat="server" Value='<%# Eval("AssignDate") %>' />
                                            <asp:HiddenField ID="hdnSubDate" runat="server" Value='<%# Eval("SubmitionDate") %>' />
                                            <asp:Literal ID="ltrDuration" runat="server"></asp:Literal></td>
                                        <%--<td>
                                            <asp:Literal ID="ltrDurationLeft" runat="server"></asp:Literal></td>
                                        </td>
                                    <td>
                                        <asp:HiddenField ID="hdnIsActive" runat="server" Value='<%# Eval("IsActive") %>' />
                                        <asp:HiddenField ID="hdnIsComplete" runat="server" Value='<%# Eval("IsComplete") %>' />
                                        <asp:Literal ID="ltrStatus" runat="server"></asp:Literal>
                                    </td>--%>
                                        
                                        <%--<td></td>--%>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                            </table>
                        </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <!-- /table with toolbar -->
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
</asp:Content>