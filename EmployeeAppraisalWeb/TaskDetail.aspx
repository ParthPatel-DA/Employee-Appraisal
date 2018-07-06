<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaskDetail.aspx.cs" Inherits="ModuleDetail" EnableEventValidation="false" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Client_Temp/css/style.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="Admin/ckeditor_4.6.2_basic/ckeditor.js"></script>
    <link href="Admin/css/font-awesome.css" rel="stylesheet" />
    <style>
        #btnClose {
            background-color: transparent;
            border: 0px solid;
            color: #E6CB29;
            margin-top: 10px;
        }
    </style>

    <style>
        input[type=range] {
            -webkit-appearance: none;
            width: 100%;
            margin: 13.8px 0;
        }

            input[type=range]:focus {
                outline: none;
            }

            input[type=range]::-webkit-slider-runnable-track {
                width: 100%;
                height: 6.4px;
                cursor: pointer;
                background: #E6CB29;
                border-radius: 1.3px;
            }

            input[type=range]::-webkit-slider-thumb {
                /*box-shadow: 1px 1px 1px #000000, 0px 0px 1px #0d0d0d;*/
                border: 1px solid #000000;
                height: 20px;
                width: 10px;
                border-radius: 4px;
                background: #ded3d3;
                cursor: pointer;
                -webkit-appearance: none;
                margin-top: -7px;
            }

            input[type=range]:focus::-webkit-slider-runnable-track {
                background: #367ebd;
            }

            input[type=range]::-moz-range-track {
                width: 100%;
                height: 8.4px;
                cursor: pointer;
                box-shadow: 1px 1px 1px #000000, 0px 0px 1px #0d0d0d;
                background: #3071a9;
                border-radius: 1.3px;
                border: 0.2px solid #010101;
            }

            input[type=range]::-moz-range-thumb {
                box-shadow: 1px 1px 1px #000000, 0px 0px 1px #0d0d0d;
                border: 1px solid #000000;
                height: 36px;
                width: 16px;
                border-radius: 3px;
                background: #fff0ff;
                cursor: pointer;
            }

            input[type=range]::-ms-track {
                width: 100%;
                height: 8.4px;
                cursor: pointer;
                background: transparent;
                border-color: transparent;
                color: transparent;
            }

            input[type=range]::-ms-fill-lower {
                background: #2a6495;
                border: 0.2px solid #010101;
                border-radius: 2.6px;
                box-shadow: 1px 1px 1px #000000, 0px 0px 1px #0d0d0d;
            }

            input[type=range]::-ms-fill-upper {
                background: #3071a9;
                border: 0.2px solid #010101;
                border-radius: 2.6px;
                box-shadow: 1px 1px 1px #000000, 0px 0px 1px #0d0d0d;
            }

            input[type=range]::-ms-thumb {
                box-shadow: 1px 1px 1px #000000, 0px 0px 1px #0d0d0d;
                border: 1px solid #000000;
                height: 36px;
                width: 16px;
                border-radius: 3px;
                background: #fff0ff;
                cursor: pointer;
                height: 8.4px;
            }

            input[type=range]:focus::-ms-fill-lower {
                background: #3071a9;
            }

            input[type=range]:focus::-ms-fill-upper {
                background: #367ebd;
            }
    </style>

    <style>
        .fileContainer {
            overflow: hidden;
            position: relative;
            cursor: pointer;
            padding: 10px;
            margin-left: 2px;
        }

            .fileContainer [type=file] {
                cursor: inherit;
                display: block;
                font-size: 999px;
                filter: alpha(opacity=0);
                min-height: 100%;
                min-width: 100%;
                opacity: 0;
                position: absolute;
                right: 0;
                text-align: right;
                top: 0;
            }
    </style>


    <%----------------------------------------------------------------------------------------------------------------------------------%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="" style="width: 100%;">
                <div class="col-md-12" style="border: 0px solid #E6CB29; border-width: 0px 0px 1px 10px; border-bottom-color: #EDEDED; height: 150px;">
                    <asp:Button ID="btnClose" class="close" runat="server" Text="&times;" OnClick="btnClose_Click" />
                    <%--<button type="button" style="float: right; font-size: 10px; background-color: transparent; border: 0px solid;"><i class="glyphicon glyphicon-resize-full"></i></button>--%>
                    <%--<h4 class="modal-title"><%# Eval("Description") %></h4>--%>
                    <h6 style="margin-left: 5px;">User Story
                        <asp:Literal ID="ltrTaskID" runat="server"></asp:Literal></h6>
                    <asp:TextBox ID="txtTaskName" runat="server" Style="width: 100%; font-size: 20px; border: 0px solid #dcdcdc; margin-top: 5px; padding-left: 5px;" Text=""></asp:TextBox>
                    <div class="col-md-3" style="margin-top: 15px; margin-left: -7px; border: 0px solid;">

                        <asp:LinkButton ID="lnkbtnModuleAssign" runat="server" Style="color: #d9bb08;" OnClick="lnkbtnModuleAssign_Click">
                            <asp:Image ID="imgEmployee" runat="server" Width="25px" Height="25px" Style="margin-top: -4px; margin-left: -2px; margin-right: -3px;" />
                            <asp:Label ID="lblEmployee" runat="server" Style="margin-left: 5px;"></asp:Label>
                        </asp:LinkButton>
                        <asp:DropDownList ID="ddEmployee" runat="server" Width="250px" Height="30px" Style="margin-left: -2px;" Visible="false"></asp:DropDownList>
                    </div>
                    <div class="col-md-1" style="border: 0px solid; margin-top: 15px;">
                        <asp:LinkButton ID="lnkbtnMsg" runat="server">
                            <i class="glyphicon glyphicon-envelope" style="color: #d74811;"></i>
                            <asp:Label ID="Label1" runat="server" Text="0" Style="margin-left: 5px;"></asp:Label>
                        </asp:LinkButton>
                    </div>
                    <div class="col-md-6" style="border: 0px solid; margin-top: 15px;">
                        <asp:LinkButton ID="lnkbtnAddSkill" runat="server" Style="background-color: #ffea74; color: #7d6c02; font-size: 12px; padding: 3px;" OnClick="lnkbtnAddSkill_Click">Add Skill</asp:LinkButton>
                        <asp:TextBox ID="txtAddSkill" runat="server" list="browsers" name="browser" Style="background-color: #ffea74; font-size: 12px; padding: 3px; border: 0px solid;" Visible="false" OnTextChanged="txtAddSkill_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <datalist id="browsers">
                            <asp:Repeater ID="rptAddSkill" runat="server">
                                <ItemTemplate>
                                    <option value='<%# Eval("SkillName") %>'></option>
                                </ItemTemplate>
                            </asp:Repeater>
                        </datalist>
                    </div>
                    <div class="col-md-2" style="border: 0px solid; margin-top: 15px;">
                        <asp:Button ID="btnSave" runat="server" Text="Save" Style="font-size: 12px; background-color: #E6CB29; color: #fff; font-weight: bolder; border: 0px solid; padding: 3px 20px 3px 20px; float: right;" OnClick="btnSave_Click" />
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
                                    <asp:LinkButton ID="lnkDDate" runat="server" Style="margin-left: 5px; color: #000;" OnClick="lnkDDate_Click">
                                        <asp:Label ID="lblDDate" runat="server" Text="" Width="250px"></asp:Label>
                                    </asp:LinkButton>
                                    <asp:TextBox ID="txtDDate" runat="server" type="date" Width="250px" Height="30px" Style="background-color: #eeeeee; border: 0px solid;" Visible="false"></asp:TextBox>
                                    <asp:Label ID="errorDDate" runat="server" Visible="false" Style="color: #cb0909; font-size: 15px; font-weight: bolder;"></asp:Label>
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
                                    <h3 style="padding: 0px; font-weight: 600; margin: 0px; padding-top: 5px;">
                                        <asp:Label ID="Label5" runat="server" Text="Project Name : " Width="180px"></asp:Label>
                                        <asp:Label ID="lblProName" runat="server" Text=''></asp:Label></h3>
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
                                    <asp:LinkButton ID="lnkbtnDiscussion" runat="server" Width="100%" Style="font-weight: bolder; color: #5a5a5a; border: 0px solid; border-bottom: 1px solid; padding-bottom: 2px; border-bottom-color: #808080; margin-top: 5px;">Completed Work Uploading</asp:LinkButton>
                                    <label class="fileContainer text-center" style="font-size: 16px; font-family: 'Sanchez', serif; color: #0CBBC8; width: 100%;border: 2px solid #808080; padding: 50px; font-size: 25px; margin-top: 20px; border-radius: 5px; height: 150px; color: #808080;">
                                        Tap For Upload Files . . .
                                        <asp:FileUpload ID="fileUploadTask" runat="server" AllowMultiple="true" Width="100%" Height="170px" style="border: 1px solid; margin-top: 20px;" />
                                        <%--<asp:FileUpload ID="fileUploadTask" class="form-control" runat="server" Style="margin-top: 10px;" />--%>
                                    </label>

                                    <asp:Button ID="Button1" CssClass="btn btn-success pull-right" runat="server" Text="Upload" OnClick="Button1_Click" Visible="true" Style="margin-top: 20px; background-color: #E6CB29; border-color: #E6CB29; border-radius: 0px;" />
                                </div>
                                <asp:Panel ID="PanelPlanning" runat="server">
                                    <div class="col-md-4" style="border: 0px solid;">
                                        <asp:LinkButton ID="lnkbtnPlanning" runat="server" Width="100%" Style="font-weight: bolder; color: #5a5a5a; border: 0px solid; border-bottom: 1px solid; padding-bottom: 2px; border-bottom-color: #808080;">Planning</asp:LinkButton>
                                        <%--<hr style="background-color: #808080; margin-top: 5px;" />--%>
                                        <div style="margin-top: 10px;">
                                            <asp:Label ID="Label7" runat="server" Text="Priority" Style="font-size: 16px; color: #808080;"></asp:Label>
                                        </div>
                                        <asp:DropDownList ID="ddPriority" runat="server" Style="background-color: transparent; border: 0px solid; width: 100%; height: 30px;">
                                            <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                        </asp:DropDownList>
                                        <div style="margin-top: 10px;">
                                            <asp:Label ID="Label8" runat="server" Text="Risk" Style="font-size: 16px; color: #808080;"></asp:Label>
                                        </div>
                                        <asp:DropDownList ID="ddRisk" runat="server" Style="background-color: transparent; border: 0px solid; width: 100%; height: 30px;">
                                            <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="1">1 - High</asp:ListItem>
                                            <asp:ListItem Value="2">2 - Medium</asp:ListItem>
                                            <asp:ListItem Value="3">3 - Low</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </asp:Panel>
                                <div class="col-md-3" style="border: 0px solid; padding-bottom: 31px;">
                                    <div id="PanelAppraisal" runat="server">
                                        <asp:LinkButton ID="LinkButton1" runat="server" Width="100%" Style="font-weight: bolder; color: #5a5a5a; border: 0px solid; border-bottom: 1px solid; padding-bottom: 2px; border-bottom-color: #808080;">Employee Appraisal</asp:LinkButton>
                                        <div class="col-md-12" style="margin-top: 8px; margin-left: -30px;">
                                            <div class="col-md-5" style="margin-top: 7px;">
                                                <asp:Label ID="Label2" runat="server" Text="Quality" Style="font-size: 14px; color: #808080; margin-top: 10px;"></asp:Label>
                                            </div>
                                            <div class="col-md-7">
                                                <%--<input type="range" name="rngQuality" min="1" max="5" value="1" style="cursor: pointer;" />--%>
                                                <asp:TextBox ID="rngQuality" type="range" runat="server" min="1" max="5" Text="1" Style="cursor: pointer;"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="margin-top: 8px; margin-left: -30px;">
                                            <div class="col-md-5" style="margin-top: 7px;">
                                                <asp:Label ID="Label9" runat="server" Text="Avialibility" Style="font-size: 14px; color: #808080; margin-top: 10px;"></asp:Label>
                                            </div>
                                            <div class="col-md-7">
                                                <%--<input type="range" name="rngAva" min="1" max="5" value="1" style="cursor: pointer;" />--%>
                                                <asp:TextBox ID="rngAvialibility" type="range" runat="server" min="1" max="5" Text="1" Style="cursor: pointer;"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="margin-top: 8px; margin-left: -30px;">
                                            <div class="col-md-5" style="margin-top: 7px;">
                                                <asp:Label ID="Label11" runat="server" Text="Communication" Style="font-size: 14px; color: #808080; margin-top: 10px;"></asp:Label>
                                            </div>
                                            <div class="col-md-7">
                                                <%--<input type="range" name="rngComm" min="1" max="5" value="1" style="cursor: pointer;" />--%>
                                                <asp:TextBox ID="rngCommunication" type="range" runat="server" min="1" max="5" Text="1" Style="cursor: pointer;"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="margin-top: 8px; margin-left: -30px;">
                                            <div class="col-md-5" style="margin-top: 7px;">
                                                <asp:Label ID="Label12" runat="server" Text="Cooperation" Style="font-size: 14px; color: #808080; margin-top: 10px;"></asp:Label>
                                            </div>
                                            <div class="col-md-7">
                                                <%--<input type="range" name="rngCoop" min="1" max="5" value="1" style="cursor: pointer;" />--%>
                                                <asp:TextBox ID="rngCooperation" type="range" runat="server" min="1" max="5" Text="1" Style="cursor: pointer;"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-7" style="border: 0px solid; margin-top: 65px;">
                                    <asp:LinkButton ID="lnkbtnRelatedWork" runat="server" Width="100%" Style="font-weight: bolder; color: #5a5a5a; border: 0px solid; border-bottom: 1px solid; padding-bottom: 2px; border-bottom-color: #808080;">Related Work</asp:LinkButton>
                                    <%--<hr style="background-color: #808080; margin-top: 5px;" />--%>
                                    <div class="col-md-12" style="width: 100%; padding: 0px; margin-top: 20px;">
                                        <div style="border: 1px solid #808080; border-width: 1px 1px 1px 0px; margin-bottom: 15px;">
                                            <div class="container-fluid" style="border: 1px solid #808080; border-width: 0px 0px 0px 7px; border-left-color: #008BFF; min-height: 45px; background: #fff; padding: 10px; font-size: 13px; padding-left: 10px; height: 221px; overflow-y: scroll;">
                                                <asp:LinkButton ID="LinkButton12" runat="server" OnClick="LinkButton12_Click" Style="color: #838383;">
                                                    <div class="col-md-12">
                                                        <h3 style="margin-top: 5px; margin-bottom: 5px;">
                                                            <asp:Label ID="lblModuleName" runat="server" Style="margin-bottom: 20px; color: #000;"></asp:Label></h3>
                                                    </div>
                                                    <div class="col-md-6">

                                                        <h4>Assign Date :
                                                            <asp:Literal ID="ltrModuleAssignDate" runat="server"></asp:Literal></h4>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <h4 class="pull-right">Deadline Date :
                                                            <asp:Literal ID="ltrModuleDeadlineDate" runat="server"></asp:Literal></h4>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <hr style="border: 1px solid; margin-top: 5px;" />
                                                    </div>
                                                    <div style="padding: 0px 20px 0px 20px;">
                                                        <p class="text-justify">
                                                            <asp:Literal ID="ltrModuleDescription" runat="server"></asp:Literal>
                                                        </p>
                                                    </div>

                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <asp:LinkButton ID="LinkButton3" runat="server" Width="100%" Style="font-weight: bolder; color: #5a5a5a; border: 0px solid; border-bottom: 1px solid; padding-bottom: 2px; border-bottom-color: #808080; margin-top: 10px; margin-bottom: 20px;">Task Files</asp:LinkButton>
                                    <div id="divTaskFile" runat="server" class="col-md-12" style="margin-bottom: 10px;">
                                        <asp:LinkButton ID="lnkTaskFile" runat="server" OnClick="lnkTaskFile_Click">
                                            <div class="col-md-12 text-center" style="background-color: #eeeeee;">
                                                <h4>
                                                    <asp:Label ID="lblTaskFileName" runat="server" Text='Download Task File For Startting Up Work.'></asp:Label></h4>
                                                <asp:HiddenField ID="hdnTaskFile" runat="server" />
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <asp:Label ID="lblFileName" runat="server" Text="Label" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
