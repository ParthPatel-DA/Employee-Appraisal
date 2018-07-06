<%@ Page Title="" Language="C#" MasterPageFile="~/ClientHeadMaster.master" AutoEventWireup="true" CodeFile="Contactus.aspx.cs" Inherits="Contactus" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="bootstrap/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- banner1 -->
    <div class="banner1">
        <div class="container">
            <h3>Contact Us</h3>
        </div>
    </div>
    <!-- //banner1 -->
    <!-- mail -->
    <div class="mail">
        <div class="container">
            <div class="agileinfo_mail_grids">
                <div class="col-md-6 agileinfo_mail_grid_left">
                    <div class="container">
                        <div class="agileinfo_footer_grids">
                            <div class="col-md-12 agileinfo_footer_grid">
                                <div class="col-md-12 agileinfo_footer_grid">
                                    <h3 style="font-size: 30px; margin-bottom: 50px;">Contact Information</h3>
                                    <ul class="agileinfo_footer_grid_list">
                                        <li style="font-size: 14px;"><i class="glyphicon glyphicon-map-marker"></i>Bhagyoday Socity,<span>Palanpur Patia,</span><span>Rander Road,</span><span>Surat 395009</span></li>
                                        <li style="font-size: 14px;"><i class="glyphicon glyphicon-envelope"></i><a href="mailto:trackmyworkindia@gmail.com">trackmyworkindia@gmail.com</a></li>
                                        <li style="font-size: 14px;"><i class="glyphicon glyphicon-earphone"></i>+918469520590</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="col-md-12 agileinfo_footer_grid">
                        <h3 style="font-size: 30px;">Contact Us</h3>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtFirstName" class="form-control" runat="server" placeholder="Enter First Name" Style="margin-top: 20px;" required="" pattern="[a-zA-Z]+"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtLastName" class="form-control" runat="server" placeholder="Enter Last Name" Style="margin-top: 20px;" required="" pattern="[a-zA-Z]+"></asp:TextBox>
                    </div>
                    <div class="col-md-12">
                        <asp:TextBox ID="txtEmail" class="form-control" runat="server" type="email" placeholder="Enter Email" Style="margin-top: 20px;" required=""></asp:TextBox>
                    </div>
                    <div class="col-md-12">
                        <asp:TextBox ID="txtContactNo" class="form-control" runat="server" type="number" placeholder="Enter Contact Number" Style="margin-top: 20px;" required="" MaxLength="15" pattern="[\+]\d{2}\d{10,15}"></asp:TextBox>
                    </div>
                    <div class="col-md-12">
                        <asp:TextBox ID="txtDescription" class="form-control" runat="server" placeholder="Enter Description" TextMode="MultiLine" Style="margin-top: 20px;" required="" pattern="[a-zA-Z_\.\ ]+"></asp:TextBox>
                    </div>
                    <div class="col-md-12 contact-right wow zoomIn" data-wow-duration="2s" data-wow-delay="0.5s" style="margin-left: -40px; margin-top: 20px; float: left; margin-bottom: 50px;">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Style="margin-left: 39px;" OnClick="btnSubmit_Click" />
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>

            <div class="col-md-12 agileinfo_mail_grid_right" style="margin-top: 30px;">
                <div class="col-md-11 agileinfo_footer_grid">
                    <h3 style="font-size: 30px;">Find Our Address</h3>
                </div>
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3719.5809207482926!2d72.7934740149357!3d21.20880068590116!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3be04e80b02b6d01%3A0x7e1416caa92cb786!2sRander+Rd%2C+Surat%2C+Gujarat!5e0!3m2!1sen!2sin!4v1490252954636" width="600" height="450" frameborder="0" style="border: 0" allowfullscreen></iframe>
            </div>
        </div>
    </div>
    <!-- //mail -->
</asp:Content>
