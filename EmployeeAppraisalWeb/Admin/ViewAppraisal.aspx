<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ViewAppraisal.aspx.cs" Inherits="Admin_ViewAppraisal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-12" style="margin-left:-14px;">
        <asp:Button ID="btnAppraial" class="btn-danger" runat="server" Text="Appraisal" style="height:30px; width:150px;" OnClick="btnAppraial_Click" />
        <asp:Button ID="btnFinalAppraisal" class="btn-danger" runat="server" Text="Final Appraisal Point" style="height:30px; width:150px;" OnClick="btnFinalAppraisal_Click" />
    </div>
    <div class="widget" style="margin-top:70px;">
        <asp:Panel ID="PanelAppraisal" runat="server">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Appraisal</h6>
                    <div style="float: right; margin-top: 3px; margin-bottom: 3px; margin-right: 5px;">
                        <asp:Button ID="btnGenerate" class="btn-danger" runat="server" Text="Generate Appraisal" OnClick="btnGenerate_Click" />
                    </div>
                </div>

            </div>

            <div class="table-overflow">
                <div class="table-responsive">
                    <asp:Repeater ID="rptViewAppraisal" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered table-checks">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Employee Name</th>
                                        <th>Skills</th>
                                        <th>Quality</th>
                                        <th>Availibility</th>
                                        <th>Deadlines</th>
                                        <th>Communication</th>
                                        <th>Co-operation</th>
                                        <th>Client FeedBack</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:HiddenField ID="hdnEmpID" runat="server" Value='<%# Eval("EmpID") %>' />
                                    <asp:Literal ID="ltrEmpName" runat="server"></asp:Literal>
                                </td>
                                <td><%# Eval("Skills") %></td>
                                <td><%# Eval("Quality") %></td>
                                <td><%# Eval("Avialibility") %></td>
                                <td><%# Eval("Deadlines") %></td>
                                <td><%# Eval("Communication") %></td>
                                <td><%# Eval("Cooperation") %></td>
                                <td><%# Eval("ClientFeedback") %></td>

                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelFinalPoint" runat="server" Visible="false">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Final Appraisal Point</h6>
                </div>

            </div>

            <div class="table-overflow">
                <div class="table-responsive">
                    <asp:Repeater ID="rptFinalPoint" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered table-checks">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Employee Name</th>
                                        <th>Appraisal Point</th>
                                        <th>Appraisal Date</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:HiddenField ID="hdnEmpID" runat="server" Value='<%# Eval("EmpID") %>' />
                                    <asp:Literal ID="ltrEmpName" runat="server"></asp:Literal>
                                </td>
                                <td><%# Eval("AppraisalPoint") %></td>
                                <td><%# Eval("AppraisalDate") %></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

