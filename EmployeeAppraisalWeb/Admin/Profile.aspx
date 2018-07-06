<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Admin_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-info" style="border: 1px solid #C7C7C7;">
        <div class="panel-heading active" style="background-color: #F4F4F4; border: 0px solid #C7C7C7; border-width: 0px 0px 1px 0px;">
            <h2 class="panel-title" style="font-size: 20px; color: #555555;"><b><i>Profile</i></b></h2>
        </div>
        <div class="panel-body">
            <div class="row" style="padding: 50px;">
                <div class="col-md-3 col-lg-3" align="center">
                    <img alt="User Pic" src="img/user-icon.png" class="img-circle img-responsive">
                </div>
                <div class=" col-md-9 col-lg-9 ">
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-2">Name :</div>
                        <div class="col-md-1"></div>
                        <div class="col-md-6">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-2">UserID :</div>
                        <div class="col-md-1"></div>
                        <div class="col-md-6"></div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-2">ContactNo :</div>
                        <div class="col-md-1"></div>
                        <div class="col-md-6">Abc</div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-2">Permissions :</div>
                        <div class="col-md-1"></div>
                        <div class="col-md-6">Abc</div>
                    </div>
                    <hr />
                    <div style="margin-top:50px;">
                        <a href="#" class="btn" style="background-color: #5B9BB4; color: #ffffff; border: 1px solid #47869E; font-weight: bold; border-radius: 0px; height:35px; font-size: 15px; padding: 9px; margin-right: 10px; margin-left:50px;">My Sales Performance</a>
                    <a href="#" class="btn btn-primary" style="background-color: #5B9BB4; color: #ffffff; border: 1px solid #47869E; font-weight: bold; border-radius: 0px; height:35px; font-size: 15px; padding: 9px;">Team Sales Performance</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-footer" style="height: 50px;">
            <a href="edit.html" data-original-title="Edit this user" data-toggle="tooltip" type="button" class="btn btn-sm btn-warning pull-right"><i class="glyphicon glyphicon-edit"></i></a>
        </div>

    </div>
</asp:Content>

