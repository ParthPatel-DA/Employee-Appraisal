<%@ Page Title="" Language="C#" MasterPageFile="~/ClientFrame.master" AutoEventWireup="true" CodeFile="ProjectMaster.aspx.cs" Inherits="ProjectMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="Admin/ckeditor_4.6.2_basic/ckeditor.js"></script>
    <link href="Admin/css/font-awesome.css" rel="stylesheet" />

    <style>
        .dropbtn {
            float: right;
        }

        .dropdown-content {
            display: none;
            position: absolute;
            right: 0;
            background-color: #f9f9f9;
            min-width: 160px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
        }

            .dropdown-content a {
                color: black;
                padding: 12px 16px;
                text-decoration: none;
                display: block;
            }

                .dropdown-content a:hover {
                    background-color: #f1f1f1;
                }

        .dropdown:hover .dropdown-content {
            display: block;
        }

        .dropdown:hover .dropbtn {
        }

        .lnkViewTask {
            margin-top: 10px;
            border: 1px solid #808080;
            border-width: 0px 0px 0px 7px;
            border-left-color: #e6cb29;
            background: #fff;
            padding: 2px;
            font-size: 13px;
            padding-left: 10px;
            padding-right: 10px;
            color: black;
        }

            .lnkViewTask:hover {
                background: #efefef;
            }
    </style>

    <!-- PopupBox -->
    <style>
    </style>
    <!-- /PopupBox -->



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="banner2">
                <div class="w3l_banner_info" style="padding: 1em 0;">
                    <h1 style="color: #fff; padding-left: 10px; margin-top: 5px;">Board For
                    <asp:LinkButton ID="LinkButton13" runat="server" Style="color: #fff;">Project Manager</asp:LinkButton>
                        <hr style="background: #808080; border: 1px inset #808080; margin-top: 5px;" />
                        <asp:Button ID="Button1" runat="server" Text="Backlog" Style="background-color: transparent; border: #808080; color: #acacac; font-size: 18px; margin-left: 10px;" />
                        <asp:Button ID="Button2" runat="server" Text="Board" Style="background-color: transparent; border: #808080; color: #e6cb29; font-weight: bolder; font-size: 18px;" />
                </div>
            </div>

            <div style="margin-bottom: 20px; margin-top: 20px;">

                <h3 style="margin-left: 10px;">Project Name :
                    <asp:Label ID="lblProjectName" runat="server" Text="Label"></asp:Label>
                    <asp:HiddenField ID="hdnProjectID" runat="server" />
                </h3>
                <table style="width: 100%; margin-top: 30px;" border="0">
                    <tr>
                        <td style="padding: 3px; width: 25%;">
                            <div style="width: 100%;">New</div>
                        </td>
                        <td style="padding: 3px; width: 25%;">
                            <div style="width: 100%;">Active</div>
                        </td>
                        <td style="padding: 2px; width: 25%;">
                            <div style="width: 100%;">Resolved</div>
                        </td>
                        <td style="padding: 2px; width: 25%;">
                            <div style="width: 100%;">Closed</div>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%; min-height: 600px;" border="0">
                    <tr>
                        <td style="padding: 10px; width: 24%; background: #efefef; border: 2px inset #acacac; border-width: 2px 0px 0px 0px;">
                            <div>
                                <div style="padding: 0px; padding-bottom: 0px; padding-top: 0px; background: #fff; width: 140px; font-size: 15px; color: #808080; margin-bottom: 30px;">
                                    <img src="img/Add.png" style="width: 30px; margin-right: 10px; float: left;" /><div style="padding: 4px;">New Module</div>
                                </div>
                                <asp:Repeater ID="rptNew" runat="server" OnItemCommand="rptNew_ItemCommand">
                                    <ItemTemplate>

                                        <div style="border: 1px solid #808080; border-width: 1px 1px 1px 0px; margin-bottom: 15px;">
                                            <div style="border: 1px solid #808080; border-width: 0px 0px 0px 7px; border-left-color: #008BFF; min-height: 45px; background: #fff; padding: 10px; font-size: 13px; padding-left: 10px;">
                                                <asp:LinkButton ID="LinkButton12" runat="server" CommandName="View" CommandArgument='<%# Eval("ModuleID") %>' OnClientClick="">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title") %>' Style="font-size: 15px; margin-bottom: 20px; color: #000;"></asp:Label>
                                                    <asp:HiddenField ID="hdnModuleID" runat="server" Value='<%# Eval("ModuleID") %>' />
                                                </asp:LinkButton>
                                                <div class="dropdown" style="float: right;">
                                                    <button class="dropbtn" style="">•••</button>
                                                    <ul class="dropdown-content" style="margin-top: 23px; left: 0;">
                                                        <li style="list-style: none;">
                                                            <asp:LinkButton ID="LnkOpen" runat="server"><i class="icon-eye-open"></i>Open</asp:LinkButton></li>
                                                        <li style="list-style: none;">
                                                            <asp:LinkButton ID="LnkTitle" runat="server"><i class="icon-pencil"></i>Add Title</asp:LinkButton></li>
                                                        <li style="list-style: none;">
                                                            <asp:LinkButton ID="LnkAddTask" runat="server"><i class="icon-plus"></i>Add Task</asp:LinkButton></li>
                                                        <li style="list-style: none;">
                                                            <asp:LinkButton ID="LnkDelete" runat="server"><i class="icon-trash"></i>Delete</asp:LinkButton></li>
                                                    </ul>
                                                </div>
                                                <br />
                                                <asp:HiddenField ID="hdnCnt" runat="server" Value="0" />
                                                <div style="margin-top: 10px; margin-bottom: 5px;">
                                                    <asp:LinkButton ID="LnkNewTask" class="lnkViewTask" runat="server" OnClick="LnkNewTask_Click" Text='' CommandArgument='<%# Eval("ModuleID") %>' CommandName="OpenPanelAddTask"></asp:LinkButton>
                                                </div>
                                            </div>

                                            <asp:Panel ID="PanelAddTask" runat="server" Visible="false">
                                                <div style="background: #fff; border: 1px solid #808080; border-width: 0px 0px 0px 1px; padding: 15px;">
                                                    <hr style="margin-top: -15px;" />
                                                    <div style="background: #fff; width: 140px; font-size: 15px; color: #2a2a2a; width: 100%;">

                                                        <asp:LinkButton ID="LinkButton11" runat="server"><img src="img/Add2.png" style="width: 30px; float: left;" /><div style="padding: 4px;">New Task</div></asp:LinkButton>
                                                        <div style="margin: 5px; margin-left: 25px; border: 0px solid;">
                                                            <div style="margin-bottom: 15px; margin-left: 7px;">
                                                                <asp:TextBox ID="TextBox2" runat="server" Visible="false"></asp:TextBox>
                                                            </div>
                                                            <asp:Repeater ID="rptTask" runat="server">
                                                                <ItemTemplate>
                                                                    <div style="margin-bottom: 15px; margin-left: 7px; width: 100%;">
                                                                        <asp:LinkButton ID="LinkButton1" class="lnkViewTask" runat="server" OnClick="LnkNewTask_Click" Text='<%# Eval("Description") %>'>
                                                                        </asp:LinkButton>
                                                                        <div class="dropdown" style="float: right;">
                                                                            <button class="dropbtn" style="background-color: transparent; border: 0px solid;">•••</button>
                                                                            <ul class="dropdown-content" style="margin-top: 18px; left: 0;">
                                                                                <li style="list-style: none;">
                                                                                    <asp:LinkButton ID="LinkButton4" runat="server"><i class="icon-eye-open"></i>Open</asp:LinkButton></li>
                                                                                <li style="list-style: none;">
                                                                                    <asp:LinkButton ID="LinkButton5" runat="server"><i class="icon-pencil"></i>Add Title</asp:LinkButton></li>
                                                                                <li style="list-style: none;">
                                                                                    <asp:LinkButton ID="LinkButton7" runat="server"><i class="icon-trash"></i>Delete</asp:LinkButton></li>
                                                                            </ul>
                                                                        </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </td>
                        <td style="width: 1%;"></td>
                        <td style="padding: 10px; width: 24%; background: #efefef; border: 2px inset #acacac; border-width: 2px 0px 0px 0px;">
                            <div>
                            </div>
                        </td>
                        <td style="width: 1%;"></td>
                        <td style="padding: 10px; width: 24%; background: #efefef; border: 2px inset #acacac; border-width: 2px 0px 0px 0px;">
                            <div>
                            </div>
                        </td>
                        <td style="width: 1%;"></td>
                        <td style="padding: 10px; width: 24%; background: #efefef; border: 2px inset #acacac; border-width: 2px 0px 0px 0px;">
                            <div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>




            <%--PopupBox--%>
            
            <%--/PopupBox--%>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>

