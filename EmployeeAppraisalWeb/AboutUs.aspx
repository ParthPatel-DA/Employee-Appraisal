<%@ Page Title="" Language="C#" MasterPageFile="~/ClientHeadMaster.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="bootstrap/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- banner1 -->
    <div class="banner1">
        <div class="container">
            <h3>About Us</h3>
        </div>
    </div>
    <!-- //banner1 -->
    <!-- about -->
    <div class="about">
        <div class="container">
            <div class="col-md-6 w3_about_grid">
                <h3>Brief Description about <span>TrackMyWork</span></h3>
                <p>
                    <i>“TrackMyWork” is a user-friendly web application in which clients can give different types of project requirments. Clients can have the facility of project tracking and see the status of project.
                    </i>
                    The Organization can get requirements from the client and manage the working on the project online. The Project manager has the job of allocating the project team and also the team members.
                    The Team members will logon the system and look for their tasks. Once completed they will upload the completion report and the task completion status online.
                    The client can logon the system and track the project status. The system will show the real-time status of the project on-hand which will help the project manager in taking right decisions about the deadline prediction.
                    The application will work on Internet thereby favoring geographically isolated offices of an organization to work simultaneously online on the same project.
                    Ultimately, the website give the opportunity to use the service and help the company to evaluate employee appraisal using feedback and rating.
                </p>
            </div>
            <div class="col-md-6 w3_about_grid">
                <img src="Client_Temp/images/16.jpg" class="img-responsive" style="display: block; width: 100%; height: auto; margin-top: 120px;" />
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
    <!-- //about -->
    <!-- team -->
    <div class="team">
        <div class="container">
            <h3 class="head">Meet Our Team</h3>
            <p class="urna"></p>
            <div class="agile_team_grids">
                <asp:Repeater ID="rptAboutus" runat="server">
                    <ItemTemplate>
                        <div class="col-md-3 agile_team_grid">
                            <div class="agile_team_grid_main">
                                <asp:Image ID="imgEmp" class="img-responsive" alt=" " runat="server"/>
                                <asp:HiddenField ID="hdnImage" runat="server" Value='<%# Eval("EmpID") %>' />
                                <div class="p-mask">
                                    <ul class="social-icons">
                                        <li><asp:LinkButton runat="server" class="icon-button twitter"><i class="icon-twitter"></i><span></span></asp:LinkButton></li>
                                        <li style="margin-left: 10px;"><asp:LinkButton runat="server" class="icon-button google"><i class="icon-google"></i><span></span></asp:LinkButton></li>
                                        <%--<li><asp:LinkButton runat="server" class="icon-button v"><i class="icon-v"></i><span></span></asp:LinkButton></li>
                                        <li><asp:LinkButton runat="server" class="icon-button pinterest"><i class="pinterest"></i><span></span></asp:LinkButton></li>--%>
                                    </ul>
                                </div>
                            </div>
                            <div class="agile_team_grid1">
                                <h3>
                                    <asp:Label ID="lblname" runat="server" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>'></asp:Label></h3>
                                    <asp:HiddenField ID="hdfgen" runat="server" Value='<%# Eval("Gender") %>'></asp:HiddenField>
                                <p><asp:Label ID="lblGen" runat="server"></asp:Label></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>


                <%-- <div class="col-md-3 agile_team_grid">
                    <div class="agile_team_grid_main">
                        <img src="Client_Temp/images/17.jpg" alt=" " class="img-responsive" />
                        <div class="p-mask">
                            <ul class="social-icons">
                                <li><a href="#" class="icon-button twitter"><i class="icon-twitter"></i><span></span></a></li>
                                <li><a href="#" class="icon-button google"><i class="icon-google"></i><span></span></a></li>
                                <li><a href="#" class="icon-button v"><i class="icon-v"></i><span></span></a></li>
                                <li><a href="#" class="icon-button pinterest"><i class="pinterest"></i><span></span></a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="agile_team_grid1">
                        <h3>Linda Carl</h3>
                        <p>Business Women</p>
                    </div>
                </div>--%>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <!-- //team -->

</asp:Content>

