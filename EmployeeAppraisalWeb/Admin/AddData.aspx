<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddData.aspx.cs" Inherits="Admin_AddData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Add Category, Language & Skill form elements -->
    <div id="divPage" runat="server" class="col-md-12" style="margin-bottom: 40px;">
        <div style="margin-bottom: 1px;">
            <div class="navbar-inner">
                <h6>Add Category & Language</h6>
            </div>
        </div>
        <div style="border: 1px solid #CAC8C8; display: inline-block; width: 100%; padding: 20px;">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="errorCategory" runat="server" class="alert alert-error alert-dismissable fade in" Visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <strong>Opps!</strong> Category already exist!!!!!
                    </asp:Panel>
                    <asp:Panel ID="errorLanguage" runat="server" class="alert alert-error alert-dismissable fade in" Visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <strong>Opps!</strong> Language already exist!!!!!
                    </asp:Panel>
                    <div class="col-md-6 control-group">
                        <span>Category :</span>
                        <div class="controls">
                            <asp:DropDownList ID="ddCategory" runat="server" class="span12 form-control" Style="margin-bottom: 20px; width: 40%;" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:PlaceHolder ID="phSubCategory" runat="server" ></asp:PlaceHolder>
                            <asp:PlaceHolder ID="phAnotherCategory" runat="server" ></asp:PlaceHolder>--%>
                            <asp:DropDownList ID="ddSubCategory" runat="server" class="span12 form-control" Visible="false" Style="margin-bottom: 20px; width: 40%;" OnSelectedIndexChanged="ddSubCategory_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddAnotherCategory" runat="server" class="span12 form-control" Visible="false" Style="margin-bottom: 20px; width: 40%;" AutoPostBack="true" OnSelectedIndexChanged="ddAnotherCategory_SelectedIndexChanged">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddNewCategory" runat="server" class="span12 form-control" Visible="false" Style="margin-bottom: 20px; width: 40%;" AutoPostBack="true" OnSelectedIndexChanged="NewCategory_SelectedIndexChanged">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddNewSubCategory" runat="server" class="span12 form-control" Visible="false" Style="margin-bottom: 20px; width: 40%;" AutoPostBack="true" OnSelectedIndexChanged="ddNewSubCategory_SelectedIndexChanged">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:LinkButton ID="lnkNewCategory" runat="server" OnClick="lnkNewCategory_Click">Add New Category</asp:LinkButton>
                            <asp:TextBox ID="txtCategory" runat="server" class="span12 form-control" Style="margin-bottom: 20px; width: 40%;" placeholder="Enter Category Name" Visible="false"></asp:TextBox><br />
                            <asp:Button ID="btnSubmitCategory" runat="server" Text="Add Category" class="btn  btn-primary form-control" BackColor="#4d4d4d" Style="width: 50%; margin-right: 10px;" Visible="false" OnClick="btnSubmitCategory_Click" />
                        </div>
                    </div>

                    <div class="col-md-6 control-group">
                        <span>Language :</span>
                        <div class="controls">
                            <asp:DropDownList ID="ddLanguage" runat="server" class="span12 form-control" Style="margin-bottom: 20px; width: 40%;" OnSelectedIndexChanged="ddLanguage_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddSubLanguage" runat="server" class="span12 form-control" Style="margin-bottom: 20px; width: 40%;" Visible="false" AutoPostBack="true">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:LinkButton ID="lnkNewLanguage" runat="server" OnClick="lnkNewLanguage_Click" Visible="false">Add New Language</asp:LinkButton>
                            <asp:TextBox ID="txtLanguage" runat="server" class="span12 form-control" Style="margin-bottom: 20px; width: 40%;" placeholder="Enter Language Name" Visible="false"></asp:TextBox><br />
                            <asp:Button ID="btnSubmitLanguage" runat="server" Text="Add Language" class="btn  btn-primary form-control" BackColor="#4d4d4d" Style="width: 50%; margin-right: 10px;" Visible="false" OnClick="btnSubmitLanguage_Click" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSubmitCategory" />
                    <asp:PostBackTrigger ControlID="btnSubmitLanguage" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <!-- /Add Category, Language & Skill form elements -->
    <div id="divError" class="text-center col-md-12" runat="server" visible="false">
        <h1>You Can't Access this Page. You don't have  Permission.</h1>
        <h3>Please contact to Admin.</h3>
    </div>
</asp:Content>

