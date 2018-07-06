<%@ Page Title="" Language="C#" MasterPageFile="~/ClientHeadMaster.master" AutoEventWireup="true" CodeFile="AboutProject.aspx.cs" Inherits="AboutProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        /*Card CSS*/
        .card {
         
            transition: 0.3s;
            width: 800px;
           
        }

        .container1 {
            padding: 2px 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-top: 40px;">
        <div class="card" style="height: 500px; margin-left: 250px; margin-bottom: 100px;">
            <div class="container1">
                <div class="col-lg-12" style="text-align: center; margin-top: 30px;">
                    <h3 class="head">
                        <asp:Literal ID="ltrtitle" runat="server"></asp:Literal>
                    </h3>
                    <p class="urna"></p>
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="col-md-12" style="margin-top: 50px;">
                            <asp:Image ID="imgProject" runat="server" class="img-responsive" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="col-md-12" style="margin-top: 50px; margin-left: -50px;">
                            <div class="col-sm-6">
                                <asp:Label ID="Label7" runat="server" Text="Category:"></asp:Label>
                            </div>
                            <div class="col-sm-6">
                                <asp:Literal ID="ltrCategory" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="col-md-12" style="margin-top: 10px; margin-left: -50px;">
                            <div class="col-sm-6">
                                <asp:Label ID="Label5" runat="server" Text="Description:"></asp:Label>
                            </div>
                            <div class="col-sm-6">
                                <asp:Literal ID="ltrDes" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="col-md-12" style="margin-top: 10px; margin-left: -50px;">
                            <div class="col-sm-6">
                                <asp:Label ID="Label1" runat="server" Text="Modules:"></asp:Label>
                            </div>
                            <div class="col-sm-6">
                                <asp:Repeater ID="rptModule" runat="server">
                                    <ItemTemplate>
                                        <asp:Literal ID="ltrModules" runat="server" Text='<%#Eval("Title") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

