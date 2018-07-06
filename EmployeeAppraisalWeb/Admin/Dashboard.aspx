<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Admin_Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Earnings stats widgets -->
    <div class="row-fluid">

        <div class="span4" >
            <div class="widget">
                <div class="navbar" >
                    <div class="navbar-inner" >
                        <h6>Total Employee</h6>
                        <asp:imagebutton ID="imgAddEmp" ImageUrl="../img/Add2.png" runat="server" style="height:30px; float:right;" OnClick="imgAddEmp_Click"></asp:imagebutton>
                    </div>
                </div>
                <div class="well body" style="margin-top:-34px; background-color: #FAFAFA;">
                    <ul class="stats-details">
                        <li>
                            <img src="img/employee.png" height="200" width="200"/>
                            <%--<strong>Total Employees of our TrackMyWork.</strong>
                            <span>latest update on <asp:Label ID="Label1" runat="server"></asp:Label></span>--%>
                        </li>
                        <li>
                            <div class="number">
                                <span><asp:Label ID="lblEmp" runat="server" style="font-size:45px; margin-top:40px; margin-right:40px;"></asp:Label></span>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="span4" >
            <div class="widget">
                <div class="navbar" >
                    <div class="navbar-inner" >
                        <h6>Total Clients</h6>
                        <asp:imagebutton ID="Imagebutton1" ImageUrl="../img/Add2.png" runat="server" style="height:30px; float:right;" OnClick="Imagebutton1_Click"></asp:imagebutton>
                    </div>
                </div>
                <div class="well body" style="margin-top:-34px; background-color: #FAFAFA;">
                    <ul class="stats-details">
                        <li>
                            <img src="img/community.png" style="height:140px;" width="200"/>
                            <%--<strong>Total Clients of our TrackMyWork.</strong>
                            <span>latest update on <asp:Label ID="Label2" runat="server"></asp:Label></span>--%>
                        </li>
                        <li>
                            <div class="number">
                                <span><asp:Label ID="lblClient" runat="server" style="font-size:45px; margin-top:40px; margin-right:40px;"></asp:Label></span>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="span4" >
            <div class="widget">
                <div class="navbar" >
                    <div class="navbar-inner" >
                        <h6>Total Projects</h6>
                        <asp:imagebutton ID="Imagebutton2" ImageUrl="../img/Add2.png" runat="server" style="height:30px; float:right;" OnClick="Imagebutton2_Click"></asp:imagebutton>
                    </div>
                </div>
                <div class="well body" style="margin-top:-34px; background-color: #FAFAFA;">
                    <ul class="stats-details">
                        <li>
                            <img src="img/web-consulting-big.png" height="200" width="200"/>
                            <%--<strong>Total Projects of our TrackMyWork.</strong>
                            <span>latest update on <asp:Label ID="Label3" runat="server"></asp:Label></span>--%>
                        </li>
                        <li>
                            <div class="number">
                                <span><asp:Label ID="lblPro" runat="server" style="font-size:45px; margin-top:40px; margin-right:40px;"></asp:Label></span>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <div>
        <asp:Chart ID="ChartProject" runat="server" Height="400" Width="500">
            <Titles>
                <asp:Title Name="ProjectModule"></asp:Title>
            </Titles>
            <Series>
                <asp:Series Name="Module" ></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea" BorderWidth="0"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    <!-- /earnings stats widgets -->
</asp:Content>

