<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModuleDetail.aspx.cs" Inherits="ModuleDetail" EnableEventValidation="false" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Client_Temp/css/style.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="Admin/ckeditor_4.6.2_basic/ckeditor.js"></script>
    <link href="Admin/css/font-awesome.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="" style="width: 100%;">
                <div class="col-md-12" style="border: 0px solid #008BFF; border-width: 0px 0px 1px 10px; border-bottom-color: #EDEDED; height: 150px;">
                    <%--<button type="button" style="float: right; font-size: 10px; background-color: transparent; border: 0px solid;"><i class="glyphicon glyphicon-resize-full"></i></button>--%>
                    <%--<h4 class="modal-title"><%# Eval("Description") %></h4>--%>
                    <h6 style="margin-left: 5px;">User Story 11</h6>
                    <asp:TextBox ID="txtModuleName" runat="server" Style="width: 100%; font-size: 20px; border: 0px solid #dcdcdc; margin-top: 5px; padding-left: 5px;" Text=""></asp:TextBox>
                    <div class="col-md-3" style="margin-top: 15px; margin-left: -7px; border: 0px solid;">

                        <asp:LinkButton ID="lnkbtnModuleAssign" runat="server" OnClick="lnkbtnModuleAssign_Click">
                            <asp:Image ID="imgTeamLeader" runat="server" ImageUrl="img/notassigned-user.svg" Width="25px" Height="25px" Style="margin-top: -4px; margin-left: -2px; margin-right: -3px;" />
                            <asp:Label ID="lblTeamLeader" runat="server" Text="Unassigned" Style="margin-left: 5px;"></asp:Label>
                        </asp:LinkButton>
                        <asp:DropDownList ID="ddTeamLeader" runat="server" Width="250px" Height="30px" Style="margin-left: -2px;" Visible="false"></asp:DropDownList>
                    </div>
                    <div class="col-md-1" style="border: 0px solid; margin-top: 15px;">
                        <asp:LinkButton ID="lnkbtnMsg" runat="server">
                            <i class="glyphicon glyphicon-envelope" style="color: #d74811;"></i>
                            <asp:Label ID="Label1" runat="server" Text="0" Style="margin-left: 5px;"></asp:Label>
                        </asp:LinkButton>
                    </div>
                    <div class="col-md-6" style="border: 0px solid; margin-top: 15px;">
                        <asp:LinkButton ID="lnkbtnAddSkill" runat="server" Style="background-color: #abd0f8; font-size: 12px; padding: 3px;" OnClick="lnkbtnAddSkill_Click">Add Skill</asp:LinkButton>
                        <asp:TextBox ID="txtAddSkill" runat="server" list="browsers" name="browser" Style="background-color: #abd0f8; font-size: 12px; padding: 3px; border: 0px solid;" Visible="false" OnTextChanged="txtAddSkill_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <datalist id="browsers">
                            <asp:Repeater ID="rptAddSkill" runat="server">
                                <ItemTemplate>
                                    <option value='<%# Eval("SkillName") %>'></option>
                                </ItemTemplate>
                            </asp:Repeater>
                        </datalist>
                    </div>
                    <div class="col-md-2" style="border: 0px solid; margin-top: 15px;">
                        <asp:Button ID="btnSave" runat="server" Text="Save" Style="font-size: 12px; background-color: #397fee; color: #fff; font-weight: bolder; border: 0px solid; padding: 3px 20px 3px 20px; float: right;" OnClick="btnSave_Click" />
                    </div>

                </div>
                <div class="col-md-12">
                    <div style="background-color: #eeeeee; margin: -16px -15px 0px -15px; padding: 25px 15px 25px 15px;">
                        <div class="container-fluid">
                            <div class="col-md-12">
                                <div class="col-md-5" style="border: 0px solid;">
                                    <div style="border: 0px solid; border-radius: 15px; width: 15px; height: 15px; background-color: #e51c1c; float: left; margin-top: 7px; margin-right: 10px;"></div>
                                    <asp:Label ID="Label3" runat="server" Text="State : " Width="130px"></asp:Label>
                                    <asp:DropDownList ID="ddState" runat="server" Width="250px" Height="30px" Style="background-color: #eeeeee; border: 0px solid;">
                                        <asp:ListItem Value="1">New</asp:ListItem>
                                        <asp:ListItem Value="2">Active</asp:ListItem>
                                        <asp:ListItem Value="3">Resolve</asp:ListItem>
                                        <asp:ListItem Value="4">Closed</asp:ListItem>
                                    </asp:DropDownList><br />
                                    <div style="border: 0px solid; border-radius: 15px; width: 15px; height: 15px; background-color: #eeeeee; float: left; margin-top: 7px; margin-right: 10px;"></div>
                                    <asp:Label ID="Label4" runat="server" Text="Deadline Date : " Width="130px"></asp:Label>
                                    <asp:LinkButton ID="lnkDDate" runat="server" style="margin-left: 5px; color: #000;" OnClick="lnkDDate_Click"><asp:Label ID="lblDDate" runat="server" Text="" Width="250px"></asp:Label></asp:LinkButton>
                                    <asp:TextBox ID="txtDDate" runat="server" type="date" Width="250px" Height="30px" Style="background-color: #eeeeee; border: 0px solid;" Visible="false"></asp:TextBox>
                                    <%--<div style="border: 0px solid; border-radius: 15px; width: 15px; height: 15px; background-color: #e51c1c; float: left; margin-top: 7px; margin-right: 10px;"></div>--%>
                                    <%--<asp:Label ID="Label4" runat="server" Text="Phase : " Width="100px"></asp:Label>
                                                                <asp:DropDownList ID="DropDownList2" runat="server" Width="250px" Height="30px" Style="background-color: #eeeeee; border: 0px solid;">
                                                                    <asp:ListItem Value="1"></asp:ListItem>
                                                                    <asp:ListItem Value="1"></asp:ListItem>
                                                                    <asp:ListItem Value="1"></asp:ListItem>
                                                                    <asp:ListItem Value="1"></asp:ListItem>
                                                                </asp:DropDownList>--%>
                                </div>
                                <div class="col-md-5" style="border: 0px solid; margin-top: 0px;">
                                    <asp:Label ID="Label5" runat="server" Text="Project Name : " Width="150px"></asp:Label>
                                    <asp:Label ID="lblProName" runat="server" Text=''></asp:Label>
                                    <%--<asp:DropDownList ID="DropDownList3" runat="server" Width="250px" Height="30px" Style="background-color: #eeeeee; border: 0px solid;"></asp:DropDownList>--%><br />
                                </div>
                                <div class="col-md-2" style="border: 0px solid; margin-top: -10px; padding-bottom: 30px;">
                                    <asp:Label ID="Label6" runat="server" Text="Updated just now" Style="float: right; margin-right: -28px; font-size: 14px; color: #808080;"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="margin: -16px -15px 0px -15px; padding: 55px 15px 30px 0px; overflow: scroll; height: 397px; margin-top: 0px;">
                        <div class="container-fluid">
                            <div class="col-md-12">
                                <div class="col-md-5" style="border: 0px solid;">
                                    <asp:LinkButton ID="lnkbtnDesc" runat="server" Width="100%" Style="font-weight: bolder; color: #5a5a5a; border: 0px solid; border-bottom: 1px solid; padding-bottom: 2px; border-bottom-color: #808080;">Description</asp:LinkButton>
                                    <%--<hr style="background-color: #808080; margin-top: 5px;" />--%>
                                    <div style="margin-top: 15px;">
                                        <%--<asp:TextBox ID="TextBox3" class="" runat="server" Width="100%"></asp:TextBox>--%>
                                        <asp:Panel ID="Panel1" runat="server" Visible="true">
                                            <asp:TextBox ID="txtCkEditor" class="ckeditor" runat="server" TextMode="MultiLine" Style="background: #fff; border: 0px solid; width: 10px;"></asp:TextBox>
                                        </asp:Panel>
                                    </div>
                                    <asp:LinkButton ID="lnkbtnDiscussion" runat="server" Width="100%" Style="font-weight: bolder; color: #5a5a5a; border: 0px solid; border-bottom: 1px solid; padding-bottom: 2px; border-bottom-color: #808080; margin-top: 5px;">Discussion</asp:LinkButton>
                                </div>
                                <div class="col-md-4" style="border: 0px solid;">
                                    <asp:LinkButton ID="lnkbtnPlanning" runat="server" Width="100%" Style="font-weight: bolder; color: #5a5a5a; border: 0px solid; border-bottom: 1px solid; padding-bottom: 2px; border-bottom-color: #808080;">Planning</asp:LinkButton>
                                    <%--<hr style="background-color: #808080; margin-top: 5px;" />--%>
                                    <asp:Label ID="Label7" runat="server" Text="Priority" Style="font-size: 14px; color: #808080;"></asp:Label>
                                    <asp:DropDownList ID="ddPriority" runat="server" Style="background-color: transparent; border: 0px solid; width: 100%; height: 30px;">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="1">1</asp:ListItem>
                                        <asp:ListItem Value="2">2</asp:ListItem>
                                        <asp:ListItem Value="3">3</asp:ListItem>
                                        <asp:ListItem Value="4">4</asp:ListItem>
                                        <asp:ListItem Value="5">5</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="Label8" runat="server" Text="Risk" Style="font-size: 14px; color: #808080;"></asp:Label>
                                    <asp:DropDownList ID="ddRisk" runat="server" Style="background-color: transparent; border: 0px solid; width: 100%; height: 30px;">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="1">1 - High</asp:ListItem>
                                        <asp:ListItem Value="2">2 - Medium</asp:ListItem>
                                        <asp:ListItem Value="3">3 - Low</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div class="col-md-3" style="border: 0px solid;">
                                    <asp:LinkButton ID="lnkbtnRelatedWork" runat="server" Width="100%" Style="font-weight: bolder; color: #5a5a5a; border: 0px solid; border-bottom: 1px solid; padding-bottom: 2px; border-bottom-color: #808080;">Related Work</asp:LinkButton>
                                    <%--<hr style="background-color: #808080; margin-top: 5px;" />--%>
                                    <asp:Label ID="lblTask" runat="server" Text="Task(2)" Style="font-size: 14px; color: #808080;"></asp:Label>
                                    <div style="width: 100%;">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
