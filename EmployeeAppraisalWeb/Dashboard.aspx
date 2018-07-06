<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="EmployeeAppraisalWeb_ClientDashbord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-12" style="border: 0px solid; margin-top: 10px; padding: 30px;">
        <div class="row">
            <div class="col-md-3 col-xs-12" style="border: 0px solid; float: right;">
                <div class="col-md-12" style="border: 1px solid #808080; box-shadow: 0px 0px 10px #000000; font-size: 13px; padding-top: 20px; padding-bottom: 10px;">
                    <div class="row col-md-12" style="padding: 0px;">
                        <div class="col-md-7" style="padding-left: 20px; border: 0px solid;">
                            <asp:Label ID="Label10" runat="server" Text="Skill"></asp:Label>
                        </div>
                        <div class="col-md-5" style="padding: 0px; border: 0px solid; margin-top: 5px;">
                            <div class="progress" style="height: 10px;">
                                <div id="divSkillPoint" runat="server" class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row col-md-12" style="padding: 0px;">
                        <div class="col-md-7" style="padding-left: 20px; border: 0px solid;">
                            <asp:Label ID="Label8" runat="server" Text="Quality"></asp:Label>
                        </div>
                        <div class="col-md-5" style="padding: 0px; border: 0px solid; margin-top: 5px;">
                            <div class="progress" style="height: 10px;">
                                <div id="divQualityPoint" runat="server" class="progress-bar progress-bar-striped active" role="progressbar"
                                    aria-valuenow="40" aria-valuemin="0" aria-valuemax="100">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row col-md-12" style="padding: 0px;">
                        <div class="col-md-7" style="padding-left: 20px; border: 0px solid;">
                            <asp:Label ID="Label7" runat="server" Text="Avialability"></asp:Label>
                        </div>
                        <div class="col-md-5" style="padding: 0px; border: 0px solid; margin-top: 5px;">
                            <div class="progress" style="height: 10px;">
                                <div id="divAvialabilityPoint" runat="server" class="progress-bar progress-bar-striped active" role="progressbar"
                                    aria-valuenow="40" aria-valuemin="0" aria-valuemax="100">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row col-md-12" style="padding: 0px;">
                        <div class="col-md-7" style="padding-left: 20px; border: 0px solid;">
                            <asp:Label ID="Label6" runat="server" Text="Co-operation"></asp:Label>
                        </div>
                        <div class="col-md-5" style="padding: 0px; border: 0px solid; margin-top: 5px;">
                            <div class="progress" style="height: 10px;">
                                <div id="divCooperationPoint" runat="server" class="progress-bar progress-bar-striped active" role="progressbar"
                                    aria-valuenow="40" aria-valuemin="0" aria-valuemax="100">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row col-md-12" style="padding: 0px;">
                        <div class="col-md-7" style="padding-left: 20px; border: 0px solid;">
                            <asp:Label ID="Label5" runat="server" Text="Communication Point"></asp:Label>
                        </div>
                        <div class="col-md-5" style="padding: 0px; border: 0px solid; margin-top: 5px;">
                            <div class="progress" style="height: 10px;">
                                <div id="divCommunicationPoint" runat="server" class="progress-bar progress-bar-striped active" role="progressbar"
                                    aria-valuenow="40" aria-valuemin="0" aria-valuemax="100">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div id="divMaster" runat="server" class="col-md-9" style="border: 0px solid;" visible="true">
                <asp:LinkButton ID="lnkProject" runat="server" Style="color: #aaaaaa;" OnClick="lnkProject_Click">
                    <div class="col-md-12" style="border: 1px solid #aaaaaa; height: 157px; margin-bottom: 30px; padding: 10px 15px 10px 15px;">
                        <asp:Label ID="Label1" runat="server" Text="Project Manager" Style="font-weight: bolder; color: #aaaaaa;"></asp:Label>
                        <hr style="margin-top: 5px; margin-bottom: -3px; border: 1px dotted #aaaaaa;" />
                        <hr style="margin-top: 5px; border: 1px dotted #aaaaaa;" />

                        <div id="divProject" runat="server" class="col-md-12" style="padding: 0px;" visible="false">
                            <%--<div class="col-md-12" style="margin-bottom: 10px;">
                                <asp:Literal ID="ltrProjectName" runat="server"></asp:Literal>
                                <asp:HiddenField ID="hdnProject" runat="server" />
                                <hr style="border: 1px solid #aaaaaa; margin-top: 5px; margin-bottom: 0px;" />
                            </div>
                            <div class="col-md-12 text-justify" style="height: 70px; font-size: 13px; overflow-y: scroll;">
                                <asp:Literal ID="ltrProjectDesc" runat="server"></asp:Literal>
                            </div>--%>
                            <div class="col-md-12">
                                <asp:Literal ID="ltrProject" runat="server"></asp:Literal>
                            </div>
                        </div>

                        <div id="divProjectStatus" runat="server" class="col-md-12" style="padding: 0px;" visible="false">
                            <div class="col-md-12" style="margin-bottom: 10px;">
                                No Work For You as Project Manager...
                            </div>
                        </div>
                    </div>
                </asp:LinkButton>
                <asp:LinkButton ID="lnkModule" runat="server" Style="color: #aaaaaa;" OnClick="lnkModule_Click">
                    <div class="col-md-12" style="border: 1px solid #aaaaaa; height: 157px; margin-bottom: 30px; padding: 10px 15px 10px 15px;">
                        <asp:Label ID="Label4" runat="server" Text="Team Leader" Style="font-weight: bolder; color: #aaaaaa;"></asp:Label>
                        <hr style="margin-top: 5px; margin-bottom: -3px; border: 1px dotted #aaaaaa;" />
                        <hr style="margin-top: 5px; border: 1px dotted #aaaaaa;" />
                        <div id="divModule" runat="server" class="col-md-12" style="padding: 0px;" visible="false">
                            <%--<div class="col-md-12" style="margin-bottom: 10px;">
                                <asp:Literal ID="ltrModuleName" runat="server"></asp:Literal>
                                <asp:HiddenField ID="hdnModule" runat="server" />
                                <hr style="border: 1px solid #aaaaaa; margin-top: 5px; margin-bottom: 0px;" />
                            </div>
                            <div class="col-md-12 text-justify" style="height: 50px; font-size: 13px; overflow-y: scroll;">
                                <asp:Literal ID="ltrModuleDesc" runat="server"></asp:Literal>
                            </div>--%>
                            <div class="col-md-12">
                                <asp:Literal ID="ltrModule" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div id="divModuleStatus" runat="server" class="col-md-12" style="padding: 0px;" visible="false">
                            <div class="col-md-12" style="margin-bottom: 10px;">
                                No Work For You as Team Leader...
                            </div>
                        </div>
                    </div>
                </asp:LinkButton>
                <asp:LinkButton ID="lnkTask" runat="server" OnClick="lnkTask_Click" Style="color: #aaaaaa;">
                    <div class="col-md-12" style="border: 1px solid #aaaaaa; height: 157px; margin-bottom: 30px; padding: 10px 15px 10px 15px;">
                        <asp:Label ID="Label9" runat="server" Text="Employee" Style="font-weight: bolder; color: #aaaaaa;"></asp:Label>
                        <hr style="margin-top: 5px; margin-bottom: -3px; border: 1px dotted #aaaaaa;" />
                        <hr style="margin-top: 5px; border: 1px dotted #aaaaaa;" />
                        <div class="col-md-12" style="padding: 0px;">
                            <div class="col-md-12" style="font-size: 13px;">
                                <asp:Literal ID="ltrTask" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </asp:LinkButton>
            </div>
            <div id="divSub" runat="server" class="col-md-9" style="border: 0px solid;" visible="false">
                <asp:LinkButton ID="LinkButton1" runat="server" Style="color: #aaaaaa;" OnClick="lnkProject_Click">
                    <div class="col-md-12" style="border: 1px solid #aaaaaa; min-height: 532px; margin-bottom: 30px; padding: 10px 15px 10px 15px;">
                        <asp:Label ID="ltrPersonType" runat="server" Style="font-weight: bolder; color: #aaaaaa;"></asp:Label>
                        <asp:Button ID="Button1" CssClass="pull-right" runat="server" Text="Back" style="font-size: 12px; font-weight: bolder; background-color: #aaaaaa; color: #fff; border: 0px; padding: 3px 10px 3px 10px;" OnClick="Button1_Click" />
                        <hr style="margin-top: 5px; margin-bottom: -3px; border: 1px dotted #aaaaaa;" />
                        <hr style="margin-top: 5px; border: 1px dotted #aaaaaa;" />

                        <div id="div1" runat="server" class="col-md-12" style="padding: 0px;">
                            <asp:Repeater ID="rptProject" runat="server" OnItemCommand="rptProject_ItemCommand">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkProjectID" runat="server" CommandName="ViewProject" CommandArgument='<%# Eval("ProjectID") %>' Style="color: #aaaaaa;">
                                        <div class="col-md-12" style="margin-bottom: 30px;">
                                            <div class="col-md-12" style="border: 1px solid; border-left: 5px solid; border-left-color: #0094ff; padding: 10px 20px 20px 20px;">
                                                <div class="col-md-9" style="padding: 0px; margin-bottom: 10px;">
                                                    <h4 Style="font-weight: bolder; color: #aaaaaa;">
                                                        <asp:Literal ID="ltrProjectName" runat="server" Text='<%# Eval("Title") %>'></asp:Literal></h4>
                                                </div>
                                                <div class="col-md-3" style="padding: 0px; text-align: right; font-size: 10px;">
                                                    <asp:Literal ID="ltrProjectStatus" runat="server"></asp:Literal>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="col-md-12" style="padding: 0px; margin-bottom: 10px;">
                                                            <h5>Category Name :
                                                    <asp:Literal ID="ltrCategoryName" runat="server"></asp:Literal><asp:HiddenField ID="hdnCategoryID" runat="server" Value='<%# Eval("CategoryID") %>' />
                                                            </h5>
                                                        </div>
                                                        <div class="col-md-12" style="padding: 0px; margin-bottom: 10px;">
                                                            <h5>Language Name :
                                                    <asp:Literal ID="ltrLanguageName" runat="server"></asp:Literal><asp:HiddenField ID="hdnLanguageID" runat="server" Value='<%# Eval("LanguageID") %>' />
                                                            </h5>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="col-md-12" style="padding: 0px; margin-bottom: 10px; text-align: right;">
                                                            <h5>Assign Date :
                                                    <asp:Literal ID="ltrAssignDate" runat="server" Text='<%# Convert.ToDateTime(Eval("AssignDate")).ToShortDateString() %>'></asp:Literal></h5>
                                                        </div>

                                                        <div class="col-md-12" style="padding: 0px; margin-bottom: 10px; text-align: right;">
                                                            <h5>Deadline Date :
                                                    <asp:Literal ID="ltrDeadlineDate" runat="server" Text='<%# Convert.ToDateTime(Eval("DeadlineDate")).ToShortDateString() %>'></asp:Literal></h5>
                                                        </div>
                                                    </div>
                                                </div>
                                                <hr style="border: 1px solid; margin-top: 5px;" />
                                                <div class="col-md-12 text-justify" style="font-size: 12px; padding: 0px;">
                                                    <asp:Literal ID="ltrDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </asp:LinkButton>
            </div>
            <div class="col-md-3 col-xs-12" style="border: 0px solid; float: right; margin-top: 30px;">
                <div class="col-md-12 text-center" style="border: 1px solid #aaaaaa; background-color: #aaaaaa; color: #fff; font-weight: bolder; padding: 5px;">Notification</div>
                <div class="col-md-12" style="border: 1px solid #aaaaaa; padding: 0px; height: 260px; overflow-y: scroll; overflow-x: hidden;">
                    <asp:Repeater ID="rptNotification" runat="server">
                        <ItemTemplate>
                            <div class="col-md-12" style="border: 0px solid #aaaaaa; border-width: 0px 0px 1px 0px; padding: 5px 0px 5px 0px;">
                                <div class="col-md-12"><strong><%# Eval("Title") %></strong></div>
                                <div class="col-md-12 text-justify" style="font-size: 13px;"><%# Eval("Description") %></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

