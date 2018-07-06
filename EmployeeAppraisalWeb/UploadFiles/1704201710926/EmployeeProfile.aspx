<%@ Page Title="" Language="C#" MasterPageFile="~/ClientFrame.master" AutoEventWireup="true" CodeFile="EmployeeProfile.aspx.cs" Inherits="EmployeeProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <style>
        .card {
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
            transition: 0.3s;
            width: 90%;
            border-radius: 5px;
        }

            .card:hover {
                box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
            }

        img {
            border-radius: 5px 5px 0 0;
        }

        .container1 {
            padding: 2px 16px;
            margin-top: 20px;
            padding-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- single -->

    <div class="single">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelEmpProfile" runat="server">
            <ContentTemplate>
                <div class="container">
                    <div class="col-md-8 w3agile_single_left">
                        <div class="w3agile_single_left1">
                            <div class="card col-md-12" style="width: 100%;">
                                <div class="col-md-6" style="text-align: center; margin-top: 20px; margin-bottom: 30px;">
                                    <asp:Image ID="ImgProfile" class="img-responsive card" runat="server" alt="Avatar" Style="width: 100%"></asp:Image>
                                    <asp:Label ID="lblname" class="form-conrtol" runat="server" Visible="true" Style="font-size: 30px; color: #008BFF;"></asp:Label>
                                    <asp:FileUpload ID="flpImg" runat="server" class="pull-left" Visible="false" Style="margin-top: 5px;" />
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:HiddenField ID="hdnEmpID" runat="server" />
                                    <asp:TextBox ID="txtFname" class="input" runat="server" placeholder="FirstName" Visible="false" Style="margin-top: 10px; width: 100%"></asp:TextBox>
                                    <asp:TextBox ID="txtLname" class="input" runat="server" placeholder="LastName" Visible="false" Style="margin-top: 10px; width: 100%"></asp:TextBox>
                                </div>
                                <div class="col-md-6" style="margin-top: 40px;">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="Gender:" Style="font-size: 18px; color: #008BFF;"></asp:Label>
                                        <asp:Label ID="lblgender" runat="server" Text="female" Visible="true" Style="font-size: 18px; color: #999;"></asp:Label>
                                        <asp:DropDownList ID="ddgen" runat="server" class="input" Visible="false" Style="width: 300px;">
                                            <asp:ListItem Value="1" Text="Male" Selected="True" />
                                            <asp:ListItem Value="2" Text="Female" />
                                        </asp:DropDownList>
                                        <br />
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label2" runat="server" Text="DOB:" Style="font-size: 18px; color: #008BFF;"></asp:Label>
                                        <asp:Label ID="lbldob" runat="server" Text="2/6/1997" Visible="true" Style="font-size: 18px; color: #999;"></asp:Label>
                                        <asp:TextBox ID="txtdob" class="input" runat="server" TextMode="Date" placeholder="Date of Birth" Style="width: 300px;" Visible="false"></asp:TextBox>
                                        <br />
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label5" runat="server" Text="Contact:" Style="font-size: 18px; color: #008BFF;"></asp:Label>
                                        <asp:Label ID="lblcontact" runat="server" Text="8469520590" Visible="true" Style="font-size: 18px; color: #999;"></asp:Label>
                                        <asp:TextBox ID="txtcontact" class="input" runat="server" placeholder="Contact" Style="width: 300px; margin-bottom: 10px;" Visible="false"></asp:TextBox>
                                        <br />
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label4" runat="server" Text="Email:" Style="font-size: 18px; color: #008BFF;"></asp:Label>
                                        <asp:Label ID="lblemail" runat="server" Text="trackmyworkindia@gmail.com" Visible="true" Style="font-size: 18px; color: #999;"></asp:Label>
                                        <asp:TextBox ID="txtemail" class="input" runat="server" placeholder="EmailID" Style="width: 300px; margin-bottom: 10px;" Visible="false"></asp:TextBox>
                                        <br />
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label3" runat="server" Text="Address:" Style="font-size: 18px; color: #008BFF;"></asp:Label>
                                        <asp:Label ID="lbladdress" runat="server" Text="surat" Visible="true" Style="font-size: 18px; color: #999;"></asp:Label>
                                        <asp:TextBox ID="txtaddress" class="input" runat="server" placeholder="Address" Style="width: 300px; margin-bottom: 10px;" Visible="false"></asp:TextBox>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-12">
                                    <ul>
                                        <li><span class="glyphicon glyphicon-user" aria-hidden="true"></span><a href="#">Admin</a></li>
                                        <li><span class="glyphicon glyphicon-envelope" aria-hidden="true"></span><a href="#">2 Comments</a></li>
                                        <li><span class="glyphicon glyphicon-heart" aria-hidden="true"></span><a href="#">50 Likes</a></li>
                                        <li><span class="glyphicon glyphicon-tag" aria-hidden="true"></span><a href="#">3 Tags</a></li>
                                        <li>
                                            <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click"><span class="glyphicon glyphicon-pencil" aria-hidden="true" visible="true"></span>Edit</asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:Button ID="btnUpdate" runat="server" class="form-control" Style="background-color: #008BFF; color: #fff;" Text="Update" Visible="false" OnClick="btnUpdate_Click" />
                                        </li>
                                    </ul>
                                </div>
                                <h4>qui dolorem eum fugiat quo voluptas</h4>
                                <p>
                                    Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe 
						            eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum 
						            hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur 
						            aut perferendis doloribus asperiores repellat.At vero eos et accusamus 
						            et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum
						            deleniti atque corrupti quos dolores et quas molestias excepturi sint 
						            occaecati cupiditate non provident, similique sunt in culpa qui 
						            officia deserunt mollitia animi, id est laborum et dolorum fuga. 
						            Et harum quidem rerum facilis est et expedita distinctio. Nam libero 
						            tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo 
						            minus id quod maxime placeat facere possimus, omnis voluptas assumenda 
						            est, omnis dolor repellendus.
                                </p>
                            </div>
                        </div>
                        <!-- my projects -->
                        <div class="work">
                            <h3 class="head">My Projects</h3>
                            <p class="urna">Have a glinpse of my successfully executed and acdaimed project .</p>
                            <div class="agileits_work_grids">
                                <ul id="flexiselDemo1">
                                    <asp:Repeater ID="rptMyProject" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <div class="agileits_work_grid view view-sixth">
                                                    <img src="Client_Temp/images/<%# Eval("Image") %>" alt=" " class="img-responsive" />
                                                    <div class="mask">
                                                        <asp:Label ID="lblProjectName" runat="server" Style="color: #fff;" Text='<%# Eval("Title") %>'></asp:Label><br />
                                                        <a href="single.html" style="margin-top: 40px;" class="info">Read More</a>
                                                    </div>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                                <script type="text/javascript">
                                    $(window).load(function () {
                                        $("#flexiselDemo1").flexisel({
                                            visibleItems: 3,
                                            animationSpeed: 1000,
                                            autoPlay: true,
                                            autoPlaySpeed: 3000,
                                            pauseOnHover: true,
                                            enableResponsiveBreakpoints: true,
                                            responsiveBreakpoints: {
                                                portrait: {
                                                    changePoint: 480,
                                                    visibleItems: 1
                                                },
                                                landscape: {
                                                    changePoint: 640,
                                                    visibleItems: 2
                                                },
                                                tablet: {
                                                    changePoint: 768,
                                                    visibleItems: 3
                                                }
                                            }
                                        });

                                    });
                                </script>
                                <script type="text/javascript" src="Client_Temp/js/jquery.flexisel.js"></script>
                            </div>
                        </div>
                        <!-- //my projects -->
                    </div>

                    <div class="col-md-4 w3agile_single_right">
                        <div class="agileits_categories" style="margin-top: -10px;">
                            <h4>Appraisal</h4>
                            <ul>
                                <li style="margin-top: -30px;"><a href="#"><span>
                                    <div class="progress" style="width: 200px; margin-bottom: -20px;">
                                        <div id="divSkillPoint" runat="server" class="progress-bar progress-bar-inverse"></div>
                                    </div>
                                </span>Skill</a><span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span>
                                </li>
                                <li><a href="#"><span>
                                    <div class="progress" style="width: 200px; margin-bottom: -20px;">
                                        <div id="divQualityPoint" runat="server" class="progress-bar progress-bar-inverse"></div>
                                    </div>
                                </span>Quality</a><span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></li>
                                <li><a href="#"><span>
                                    <div class="progress" style="width: 200px; margin-bottom: -20px;">
                                        <div id="divAvialabilityPoint" runat="server"  class="progress-bar progress-bar-inverse"></div>
                                    </div>
                                </span>Avialability</a><span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></li>
                                <li><a href="#"><span>
                                    <div class="progress" style="width: 200px; margin-bottom: -20px;">
                                        <div id="divCooperationPoint" runat="server"  class="progress-bar progress-bar-inverse"></div>
                                    </div>
                                </span>Cooperation</a><span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></li>
                                <li><a href="#"><span>
                                    <div class="progress" style="width: 200px; margin-bottom: -20px;">
                                        <div id="divCommunicationPoint" runat="server"  class="progress-bar progress-bar-inverse"></div>
                                    </div>
                                </span>Communication</a><span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></li>
                                <li><a href="#"><span>
                                    <div class="progress" style="width: 200px; margin-bottom: -20px;">
                                        <div id="divClientFeedbackPoint" runat="server" class="progress-bar progress-bar-inverse"></div>
                                    </div>
                                </span>ClientFeedback</a><span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></li>
                            </ul>
                        </div>
                        <div class="agileits_categories" style="margin-top: 40px;">
                            <h4>Categoies</h4>
                            <asp:Repeater ID="rptCategory" runat="server">
                                <ItemTemplate>
                                    <ul>
                                        <li>
                                            <%--<asp:linkbutton runat="server"><%# Eval("SkillName") %><span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></asp:linkbutton>--%>
                                            <%-- <%# Eval("SkillName") %>--%>
                                        </li>
                                    </ul>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="agileits_tags" style="margin-top: 40px;">
                            <h4>Skills</h4>
                            <div class="agileits_categories" style="margin-top: -20px; margin-bottom: 10px;">
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="AddSkill" runat="server" OnClick="AddSkill_Click">Add Skill<span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></asp:LinkButton></li>
                                </ul>
                            </div>
                            <asp:Panel ID="panelAddSkill" runat="server" Visible="false" Style="margin-bottom: 10px;">
                                <asp:TextBox ID="txtAddSkill" runat="server" list="browsers" name="browser" OnTextChanged="txtAddSkill_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <datalist id="browsers">
                                    <asp:Repeater ID="rptAddSkill" runat="server">
                                        <ItemTemplate>
                                            <option value='<%# Eval("SkillName") %>'></option>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </datalist>
                            </asp:Panel>

                            <asp:Repeater ID="rptSkills" runat="server" OnItemCommand="rptSkills_ItemCommand">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <asp:LinkButton ID="lnkDelSkill" runat="server" CommandName="DeleteSkill" CommandArgument='<%# Eval("SkillID") %>'><%# Eval("SkillName") %><span> &times</span></asp:LinkButton>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="agileits_categories agileits_archives" style="margin-top: 40px;">
                            <h4>Archives</h4>
                            <ul>
                                <li>20 July 2016<span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></li>
                                <li>22 July 2016<span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></li>
                                <li>25 July 2016<span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></li>
                                <li>28 July 2016<span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></li>
                                <li>2 August 2016<span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></li>
                                <li>12 August 2016<span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="txtAddSkill" />
                <asp:PostBackTrigger ControlID="lnkEdit" />
                <asp:PostBackTrigger ControlID="btnUpdate" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <!-- //single -->
</asp:Content>

