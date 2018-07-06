<%@ Page Title="" Language="C#" MasterPageFile="~/ClientHeadMaster.master" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div>
            <h1 style="margin-top: 50px; margin-bottom: 40px; margin-left: 30px;">Browse All Categories</h1>
        </div>

        <div style="margin-top: 40px; margin-left: 30px;">
            <div class="agileinfo_footer_grid">
                <asp:repeater id="rptservice" runat="server">
                    <ItemTemplate>
                        <div class="col-md-5" style="margin-top: 30px;">
                            <asp:HiddenField ID="hdnCategory" runat="server" value='<%# Eval("CategoryID") %>'></asp:HiddenField>
                            <h3><%# Eval("CategoryName") %></h3>
                        </div>
                        <div class="col-md-12">
                            <asp:Repeater id="rptSubservice" runat="server">
                                <ItemTemplate>
                                    <div class="col-md-3" style="margin-bottom:10px;">
                                        <div class="agileinfo_footer_grid_nav">
                                            <div class="li"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span> <a href="PostProject.aspx"><%# Eval("CategoryName") %></a></div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                </ItemTemplate>
                </asp:repeater>
            </div>
        </div>
    </div>
</asp:Content>
