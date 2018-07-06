<%@ Page Title="Assign Project" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AssignProject.aspx.cs" Inherits="Admin_Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .modal {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            z-index: 1050;
            display: none;
            overflow: hidden;
            -webkit-overflow-scrolling: touch;
            outline: 0;
        }
    </style>
    <script type="text/javascript">
        function SetUniqueRadioButton(nameregex, current) {
            re = new RegExp(nameregex);
            for (i = 0; i < document.forms[0].elements.length; i++) {
                elm = document.forms[0].elements[i]
                if (elm.type == 'radio') {
                    if (re.test(elm.name)) {
                        elm.checked = false;
                    }
                }
            }
            current.checked = true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divPage" runat="server">
        <!-- Modal -->
        <div id="myModal" class="modal fade" role="dialog" style="background-color: transparent; border: 0px solid; margin-bottom: 7%;">
            <div class="modal-dialog" style="width: 60%; margin-left: 430px;">

                <!-- Modal content-->
                <div class="modal-content" style="border-radius: 0px; height: 400px;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Project Skill :</h4>
                    </div>
                    <asp:HiddenField ID="hdnProjectID" runat="server" />
                    <div class="modal-body" style="overflow: scroll; max-height: 300px; min-height: 300px;">
                        <asp:Repeater ID="rptSkill" runat="server">
                            <ItemTemplate>
                                <div class="col-md-3">
                                    <div class="col-md-1">
                                        <asp:CheckBox ID="chkSkill" class="checkbox" runat="server" Text='<%# Eval("SkillID") %>' Style="font-size: 0px;" />
                                    </div>
                                    <div class="col-md-10" style="margin-top: 10px;">
                                        <%# Eval("SkillName") %>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnAddSkill" class="btn btn-default" runat="server" Text="Add Skill" OnClick="btnAddSkill_Click" />
                    </div>
                </div>

            </div>
        </div>
        <!-- \Modal -->


        <div style="display: inline-block; margin-bottom: 30px; width: 100%;">
            <div class="col-md-12" style="margin-top: 20px;">
                <div style="margin-bottom: 1px;">
                    <div class="navbar-inner">
                        <h6>Assign Project</h6>
                    </div>
                </div>
            </div>
            <!-- View Project -->
            <div class="col-md-6">
                <div style="margin-bottom: 1px;">
                    <div class="navbar-inner">
                        <h6>Project Detail</h6>
                    </div>
                </div>
                <div style="border: 1px solid #CAC8C8; display: inline-block; width: 100%; overflow: scroll; overflow-x: hidden; padding: 20px; max-height: 400px; min-height: 400px;">
                    <asp:Repeater ID="rptProjectAss" runat="server" OnItemCommand="rptProjectAss_ItemCommand">
                        <ItemTemplate>
                            <div style="width: 100%; display: inline-block; margin: 17px;">
                                <div style="width: 10%; float: left; background-color: #c6c6c6; padding: 9px; margin-top: 1px; margin-left: 1px; border: 0px solid #808080; border-width: 0px 1px 0px 0px;">
                                    <center><asp:RadioButton ID="chkProjectAssign" runat="server" GroupName="Project" AutoPostBack="true" OnCheckedChanged="chkProjectAssign_OnCheckedChanged" visible="false" style="font-size: 0px;" Text='<%# Eval("ProjectID") %>'></asp:RadioButton>
                                    <asp:Button ID="btnProjectAssign" runat="server" formnovalidate="formnovalidate" style="height: 13px; margin-top: 0px; font-size: 0px;" CommandName="Skill" CommandArgument='<%# Eval("ProjectID") %>'></asp:Button></center>
                                </div>
                                <div style="width: 90%; background-color: #F8F8F8; padding: 10px; padding-left: 50px; border: 1px solid #808080;">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ProjectID") %>' />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <!-- /View Project -->

            <!-- View Employee -->
            <div class="col-md-6">
                <div style="margin-bottom: 1px;">
                    <div class="navbar-inner">
                        <h6>Employee Detail</h6>
                    </div>
                </div>
                <div style="border: 1px solid #CAC8C8; display: inline-block; width: 100%; overflow: scroll; overflow-x: hidden; padding: 20px; max-height: 400px; min-height: 400px;">

                    <asp:Repeater ID="rptEmployeeList" runat="server" OnItemDataBound="rptEmployeeList_ItemDataBound">
                        <ItemTemplate>
                            <div style="width: 100%; display: inline-block; margin: 17px;">
                                <div style="width: 10%; float: left; background-color: #c6c6c6; padding: 9px; margin-top: 1px; margin-left: 1px; border: 0px solid #808080; border-width: 0px 1px 0px 0px;">
                                    <center>
                                    <%--<input type="radio" name="rdEmployee" runat="server" value='<%# Eval("EmpID") %>' style="font-size: 20px;" />--%>
                                    <asp:RadioButton ID="rdEmployee" GroupName="Employee" runat="server" Text='<%# Eval("EmpID") %>' style="font-size: 0px;"></asp:RadioButton>
                                </center>
                                </div>
                                <div style="width: 90%; background-color: #F8F8F8; padding: 10px; padding-left: 50px; border: 1px solid #808080;">
                                    <%# Eval("FirstName") + " " + Eval("LastName") %>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <!-- /View Employee -->
            <asp:Button ID="btnAssignProject" runat="server" Text="Assign Project" class="btn  btn-primary form-control" BackColor="#4d4d4d" Style="margin-bottom: 10px; width: 30%; margin-top: 20px; margin-left: 20px;" OnClick="btnAssignProject_Click" />
        </div>
    </div>
    <div id="divError" class="text-center col-md-12" runat="server" visible="false">
        <h1>You Can't Access this Page. You have don't Permission.</h1>
        <h3>Please contact to Admin.</h3>
    </div>
</asp:Content>
