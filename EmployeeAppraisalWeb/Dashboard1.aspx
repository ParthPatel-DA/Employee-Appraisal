<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/ClientFrame.master" AutoEventWireup="true" CodeFile="Dashboard1.aspx.cs" Inherits="EmployeeAppraisalWeb_ClientDashbord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-12" style="border: 0px solid; margin-top: 10px; padding: 30px;">
        <div class="row">
            <div class="col-md-3 col-xs-12" style="border: 0px solid; float: right;">
                <div class="col-md-12" style="border: 1px solid #808080; box-shadow: 0px 0px 10px #000000; font-size: 13px; padding-top: 20px; padding-bottom: 10px;">
                    <div class="row col-md-12" style="padding: 0px;">
                        <div class="col-md-7" style="padding-left: 20px; border: 0px solid;">
                            <asp:Label ID="Label10" runat="server" Text="Skill"></asp:Label>
                        </div>
                        <div class="col-md-5" style="padding: 0px; border: 0px solid; margin-top: 5px;">
                            <div class="progress" style="height: 10px;">
                                <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 60%;">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row col-md-12" style="padding: 0px;">
                        <div class="col-md-7" style="padding-left: 20px; border: 0px solid;">
                            <asp:Label ID="Label8" runat="server" Text="Quality"></asp:Label>
                        </div>
                        <div class="col-md-5" style="padding: 0px; border: 0px solid; margin-top: 5px;">
                            <div class="progress" style="height: 10px;">
                                <div class="progress-bar progress-bar-striped active" role="progressbar"
                                    aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 80%;">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row col-md-12" style="padding: 0px;">
                        <div class="col-md-7" style="padding-left: 20px; border: 0px solid;">
                            <asp:Label ID="Label7" runat="server" Text="Avialability"></asp:Label>
                        </div>
                        <div class="col-md-5" style="padding: 0px; border: 0px solid; margin-top: 5px;">
                            <div class="progress" style="height: 10px;">
                                <div class="progress-bar progress-bar-striped active" role="progressbar"
                                    aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 70%;">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row col-md-12" style="padding: 0px;">
                        <div class="col-md-7" style="padding-left: 20px; border: 0px solid;">
                            <asp:Label ID="Label6" runat="server" Text="Co-operation"></asp:Label>
                        </div>
                        <div class="col-md-5" style="padding: 0px; border: 0px solid; margin-top: 5px;">
                            <div class="progress" style="height: 10px;">
                                <div class="progress-bar progress-bar-striped active" role="progressbar"
                                    aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 65%;">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row col-md-12" style="padding: 0px;">
                        <div class="col-md-7" style="padding-left: 20px; border: 0px solid;">
                            <asp:Label ID="Label5" runat="server" Text="Client FeedBack"></asp:Label>
                        </div>
                        <div class="col-md-5" style="padding: 0px; border: 0px solid; margin-top: 5px;">
                            <div class="progress" style="height: 10px;">
                                <div class="progress-bar progress-bar-striped active" role="progressbar"
                                    aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 75%;">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-9" style="border: 0px solid;">
                <div class="col-md-12" style="border: 1px solid #aaaaaa; height: 200px; margin-bottom: 30px; padding: 10px 15px 10px 15px;">
                    <asp:Label ID="Label1" runat="server" Text="Project Manager" Style="font-weight: bolder; color: #aaaaaa;"></asp:Label>
                    <hr style="margin-top: 5px; margin-bottom: -3px; border: 1px dotted #aaaaaa;" />
                    <hr style="margin-top: 5px; border: 1px dotted #aaaaaa;" />
                    <div class="col-md-12" style="padding: 0px;">
                        <div class="col-md-12" style="margin-bottom: 10px;">
                            Vivekanand College
                            <hr style="border: 1px solid #aaaaaa; margin-top: 5px; margin-bottom: 0px;" />
                        </div>
                        <div class="col-md-12 text-justify" style="height: 70px; font-size: 13px; overflow-y: scroll;">
                            Vivekanand College works on the footsteps of Swami Vivekanand by providing a supportive environment for innovation. High standards in teaching are achieved and a quality research is promoted to push knowledge frontiers and evolve technologies for development. Our aim is when a student comes out of the institution he should recollect that he had the benefit of progressive education system. As he now enters a stage where he can give back to society, make his own contributions and make it count. At Vivekanand College we facilitate our students with both best education and the necessary skill sets to ensure that they become good and worthy citizens of a great country aiding in its overall progress and development.
                        </div>
                    </div>
                </div>
                <div class="col-md-12" style="border: 1px solid #aaaaaa; height: 170px; margin-bottom: 30px; padding: 10px 15px 10px 15px;">
                    <asp:Label ID="Label4" runat="server" Text="Team Leader" Style="font-weight: bolder; color: #aaaaaa;"></asp:Label>
                    <hr style="margin-top: 5px; margin-bottom: -3px; border: 1px dotted #aaaaaa;" />
                    <hr style="margin-top: 5px; border: 1px dotted #aaaaaa;" />
                    <div class="col-md-12" style="padding: 0px;">
                        <div class="col-md-12" style="margin-bottom: 10px;">
                            Student Zone
                            <hr style="border: 1px solid #aaaaaa; margin-top: 5px; margin-bottom: 0px;" />
                        </div>
                        <div class="col-md-12 text-justify" style="height: 50px; font-size: 13px; overflow-y: scroll;">
                            Vivekanand College works on the footsteps of Swami Vivekanand by providing a supportive environment for innovation. High standards in teaching are achieved and a quality research is promoted to push knowledge frontiers and evolve technologies for development. Our aim is when a student comes out of the institution he should recollect that he had the benefit of progressive education system. As he now enters a stage where he can give back to society, make his own contributions and make it count. At Vivekanand College we facilitate our students with both best education and the necessary skill sets to ensure that they become good and worthy citizens of a great country aiding in its overall progress and development.
                        </div>
                    </div>
                </div>
                <div class="col-md-12" style="border: 1px solid #aaaaaa; height: 100px; margin-bottom: 30px; padding: 10px 15px 10px 15px;">
                    <asp:Label ID="Label9" runat="server" Text="Employee" Style="font-weight: bolder; color: #aaaaaa;"></asp:Label>
                    <hr style="margin-top: 5px; margin-bottom: -3px; border: 1px dotted #aaaaaa;" />
                    <hr style="margin-top: 5px; border: 1px dotted #aaaaaa;" />
                    <div class="col-md-12" style="padding: 0px;">
                        <div class="col-md-12" style="font-size: 13px;">5 Tasks</div>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-xs-12" style="border: 0px solid; float: right; margin-top: 30px;">
                <div class="col-md-12 text-center" style="border: 1px solid #aaaaaa; background-color: #aaaaaa; color: #fff; font-weight: bolder; padding: 5px;">Notification</div>
                <div class="col-md-12" style="border: 1px solid #aaaaaa; padding: 0px; height: 260px; overflow-y: scroll; overflow-x: hidden;">
                    <div class="col-md-12" style="border: 0px solid #aaaaaa; border-width: 0px 0px 1px 0px; padding: 5px 0px 5px 0px;">
                        <div class="col-md-12"><strong>Project Notification</strong></div>
                        <div class="col-md-12 text-justify" style="font-size: 13px;">You are Selected Project Manager for Vivekanand College Web Application Project.</div>
                    </div>
                    <div class="col-md-12" style="border: 0px solid #aaaaaa; border-width: 0px 0px 1px 0px; padding: 5px 0px 5px 0px;">
                        <div class="col-md-12"><strong>Module Notification</strong></div>
                        <div class="col-md-12 text-justify" style="font-size: 13px;">You are Selected Team Leader for Student Zone Module in Vivekanand College Web Application Project.</div>
                    </div>
                    <div class="col-md-12" style="border: 0px solid #aaaaaa; border-width: 0px 0px 1px 0px; padding: 5px 0px 5px 0px;">
                        <div class="col-md-12"><strong>Task Notification</strong></div>
                        <div class="col-md-12 text-justify" style="font-size: 13px;">You are Selected Developer for Login Task in Vivekanand College Web Application Project.</div>
                    </div>
                    <div class="col-md-12" style="border: 0px solid #aaaaaa; border-width: 0px 0px 1px 0px; padding: 5px 0px 5px 0px;">
                        <div class="col-md-12"><strong>Notification 1</strong></div>
                        <div class="col-md-12 text-justify" style="font-size: 13px;">fvbdhs fu vfyhd fdufv fv ih hduhdgdfidf gdudfu dfdfhd figdu fhuidfh</div>
                    </div>
                    <div class="col-md-12" style="border: 0px solid #aaaaaa; border-width: 0px 0px 1px 0px; padding: 5px 0px 5px 0px;">
                        <div class="col-md-12"><strong>Notification 1</strong></div>
                        <div class="col-md-12 text-justify" style="font-size: 13px;">fvbdhs fu vfyhd fdufv fv ih hduhdgdfidf gdudfu dfdfhd figdu fhuidfh</div>
                    </div>
                </div>
            </div>

        </div>

    </div>
</asp:Content>

