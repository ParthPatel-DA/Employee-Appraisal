<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="TrackProject.aspx.cs" Inherits="Admin_TrackProject" EnableEventValidation="false" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

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
                    <h4 class="modal-title">Project Tracking :</h4>
                </div>
                <asp:chart id="ChartTack" runat="server" height="300px" width="1000px">
                    <Titles>
                        <asp:Title Name="titleTrack" ShadowOffset="3"></asp:Title>
                    </Titles>
                    <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
                    </Legends>
                    <Series>
                        <asp:Series Name="SeriesModule"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderWidth="0"></asp:ChartArea>
                    </ChartAreas>
                </asp:chart>
            </div>

        </div>
    </div>
    <!-- \Modal -->

    <div class="col-md-12">
        <asp:linkbutton id="lnkPDF" runat="server" onclick="lnkPDF_Click">
        <div style="float: left; margin-left: -13px; margin-bottom: 20px; border: 1px solid #bbbbbb; padding: 10px; border-radius: 0px; color: #808080; padding-left: 15px; padding-right: 15px;">
            <span class="glyphicon glyphicon-save"></span>
            Genrate PDF Report
        </div>
        </asp:linkbutton>

        <asp:linkbutton id="lnkTrack" runat="server" onclick="lnkTrack_Click">
        <div style="float: right; border: 1px solid #bbbbbb; padding: 10px; border-radius: 0px; color: #808080; padding-left: 15px; padding-right: 15px;">
            <img src="../img/TMWTBl.png" style="height: 30px; width: 13px; margin-right: 5px;" />
            Track Project
        </div>
        </asp:linkbutton>
        <%--<asp:Button ID="btnmodule" runat="server" Text="Add Module" class="btn" Style="border: none; width: 125px; height: 42px; float: right; margin: -25px 20px 10px 0px; opacity: 0;" OnClick="btnmodule_Click" />--%>
    </div>

    <asp:panel id="PanelPDF" runat="server">
        <h2>Project Name :
        <asp:Literal ID="ltrProjectName" runat="server"></asp:Literal></h2>

        <h4>Manager Name : 
            <asp:Literal ID="ltrManager" runat="server"></asp:Literal>
            <%--Om Patel<small> (1001)</small>--%></h4>

        <hr style="border: 1px solid #c6c6c6; margin-top: 10px;" />
        <asp:Repeater ID="rptTrackModule" runat="server">
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
                                                    <th>Duration</th>
                                                    <th>Duration Left</th>
                                                    <th>Status</th>
                                                    <th>Submitted Date</th>
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
                                        <td><%# Eval("AssignDate") %></td>
                                        <td>
                                            <asp:HiddenField ID="hdnCreatedOn" runat="server" Value='<%# Eval("CreatedOn") %>' />
                                            <asp:HiddenField ID="hdnAssignDay" runat="server" Value='<%# Eval("AssignDate") %>' />
                                            <asp:HiddenField ID="hdnDeadLine" runat="server" Value='<%# Eval("DeadlineDate") %>' />
                                            <asp:Literal ID="ltrDuration" runat="server"></asp:Literal></td>
                                        <td>
                                            <asp:Literal ID="ltrDurationLeft" runat="server"></asp:Literal></td>
                                        </td>
                                    <td style="text-align: center;">
                                        <asp:HiddenField ID="hdnIsActive" runat="server" Value='<%# Eval("IsActive") %>' />
                                        <asp:HiddenField ID="hdnIsComplete" runat="server" Value='<%# Eval("IsComplete") %>' />
                                        <asp:Literal ID="ltrStatus" runat="server"></asp:Literal>
                                    </td>
                                        <td style="text-align: center;">
                                            <asp:Literal ID="ltrSubmitionDate" runat="server" Text='<%# Eval("SubmitionDate") %>'></asp:Literal>
                                        </td>
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
    </asp:panel>
</asp:Content>

