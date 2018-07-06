<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectManager.aspx.cs" Inherits="Dashboard" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .divProjectManager, .divTeamLeader, .divEmployee {
            color: #008BFF;
        }

            .divProjectManager:hover, .divTeamLeader:hover, .divEmployee:hover {
                color: #FFF;
                background: #008BFF;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="col-md-12" style="margin-top: 50px; margin-bottom: 100px;">
            <div class="col-md-12" style="border: 2px solid #808080; padding: 30px;">
                <div class="col-md-12" style="margin-bottom: 10px;">
                    <h2><asp:Literal ID="ltrPersonType" runat="server"></asp:Literal></h2>
                </div>
                <hr style="border: 1px solid #808080; margin-left: 10px; margin-right: 10px; margin-bottom: 30px;" />
                <asp:Repeater ID="rptProject" runat="server" OnItemCommand="rptProject_ItemCommand">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkProjectID" runat="server" CommandName="ViewProject" CommandArgument='<%# Eval("ProjectID") %>' style="color: #656565;">
                            <div class="col-md-12" style="margin-bottom: 30px;">
                                <div class="col-md-12" style="border: 1px solid; border-left: 5px solid; border-left-color: #d15801; padding: 10px 20px 20px 20px;">
                                    <div class="col-md-9" style="padding: 0px; margin-bottom: 10px;">
                                        <h3>
                                            <asp:Literal ID="ltrProjectName" runat="server" Text='<%# Eval("Title") %>'></asp:Literal></h3>
                                    </div>
                                    <div class="col-md-3" style="padding: 0px; text-align: right;">
                                        <asp:Literal ID="ltrProjectStatus" runat="server"></asp:Literal>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="col-md-12" style="padding: 0px; margin-bottom: 10px;">
                                                <h4>Category Name :
                                                    <asp:Literal ID="ltrCategoryName" runat="server"></asp:Literal><asp:HiddenField ID="hdnCategoryID" runat="server" Value='<%# Eval("CategoryID") %>' />
                                                </h4>
                                            </div>
                                            <div class="col-md-12" style="padding: 0px; margin-bottom: 10px;">
                                                <h4>Language Name :
                                                    <asp:Literal ID="ltrLanguageName" runat="server"></asp:Literal><asp:HiddenField ID="hdnLanguageID" runat="server" Value='<%# Eval("LanguageID") %>' />
                                                </h4>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-12" style="padding: 0px; margin-bottom: 10px; text-align: right;">
                                                <h4>Assign Date :
                                                    <asp:Literal ID="ltrAssignDate" runat="server" Text='<%# Convert.ToDateTime(Eval("AssignDate")).ToShortDateString() %>'></asp:Literal></h4>
                                            </div>

                                            <div class="col-md-12" style="padding: 0px; margin-bottom: 10px; text-align: right;">
                                                <h4>Deadline Date :
                                                    <asp:Literal ID="ltrDeadlineDate" runat="server" Text='<%# Convert.ToDateTime(Eval("DeadlineDate")).ToShortDateString() %>'></asp:Literal></h4>
                                            </div>
                                        </div>
                                    </div>
                                    <hr style="border: 1px solid; margin-top: 5px;" />
                                    <div class="col-md-12 text-justify">
                                        <asp:Literal ID="ltrDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

</asp:Content>

