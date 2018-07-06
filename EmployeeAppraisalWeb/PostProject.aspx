<%@ Page Title="" Language="C#" MasterPageFile="~/ClientHeadMaster.master" AutoEventWireup="true" CodeFile="PostProject.aspx.cs" Inherits="PostProject" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--<!-- our works -->--%>
    <div class="treatments" style="margin-bottom: 70px;">
        <div class="container  steps">
            <h3 class="head">Request For Project</h3>
            <p class="urna"></p>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container">
                    <asp:Panel ID="PanelUser" runat="server">
                        <asp:LinkButton ID="lnkUser" runat="server" OnClick="lnkUser_Click">
                            <center>
                                <div class="col-md-2"></div>
                                <div class="col-md-3">
                                    <div style="border: 1px solid #bbbbbb; padding: 10px; border-radius: 5px; box-shadow: 0px 0px 10px #bbbbbb;" >
                                        <img src="css/img/check--user-icon-27676.png" style="height: 60px; width: 60px;" />
                                        I am exiting user. . .
                                    </div>
                                </div>
                        </asp:LinkButton>
                        <div class="col-md-2"></div>
                        <asp:LinkButton ID="lnkNew" runat="server" OnClick="lnkNew_Click">
                                <div class="col-md-3">
                                    <div style="border: 1px solid #bbbbbb; padding: 10px; border-radius: 5px; box-shadow: 0px 0px 10px #bbbbbb;">
                                        <img src="css/img/7-512.png" style="height: 60px; width: 60px;"/>
                                        I am new user...
                                    </div>
                                </div>
                        </asp:LinkButton>
                        </center>
                    </asp:Panel>

                    <asp:Panel ID="PanelChoice" runat="server">
                        <asp:LinkButton ID="lnkInquiry" runat="server" OnClick="lnkInquiry_Click">
                            <center>
                                <div class="col-md-2"></div>
                                <div class="col-md-3">
                                    <div style="border: 1px solid #bbbbbb; padding: 10px; border-radius: 5px; box-shadow: 0px 0px 10px #bbbbbb;">
                                        <img src="css/img/question-512.png" style="height: 60px; width: 60px;" />
                                        For Inquiry...
                                    </div>
                                </div>
                        </asp:LinkButton>
                        <div class="col-md-2"></div>
                        <asp:LinkButton ID="lnkReg" runat="server" OnClick="lnkReg_Click">
                                <div class="col-md-3">
                                    <div style="border: 1px solid #bbbbbb; padding: 10px; border-radius: 5px; box-shadow: 0px 0px 10px #bbbbbb;">
                                        <img src="css/img/7-512.png" style="height: 60px; width: 60px;" />
                                        For Register...
                                    </div>
                                </div>
                        </asp:LinkButton>
                        </center>
                       
                    </asp:Panel>

                    <asp:Panel ID="PanelInquiry" runat="server">

                        <div class="container">
                            <h2 style="margin-top: 30px;"><font style="background-color: #0CBBC8; padding: 15px; border-radius: 50%; padding-top: 7px; padding-bottom: 7px; margin-right: 10px; font-size: 20px; color: #ffffff;">1</font>Name</h2>
                            <div class="col-md-12">
                                <div class="col-md-3 container">
                                    <div class="group-control" style="padding-top: 20px; margin-left: 10px;">
                                        <div class="controls container">
                                            <asp:TextBox ID="txtFName" class="form-control" runat="server" type="text" Style="width: 200px; margin-top: 8px;" placeholder="Enter Your First Name" MaxLength="20" required="" pattern="[a-zA-Z]+" oninvalid="this.setCustomValidity('Accept Alphabet only')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 container">
                                    <div class="group-control" style="padding-top: 20px; margin-left: 10px;">
                                        <div class="controls container">
                                            <asp:TextBox ID="txtLName" class="form-control" type="text" runat="server" Style="width: 200px; margin-top: 8px;" placeholder="Enter Your Last Name" MaxLength="20" required="" pattern="[a-zA-Z]+" oninvalid="this.setCustomValidity('Accept Alphabet only')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="container">
                            <h2 style="margin-top: 30px;"><font style="background-color: #0CBBC8; padding: 15px; border-radius: 50%; padding-top: 7px; padding-bottom: 7px; margin-right: 10px; font-size: 20px; color: #ffffff;">2</font>Contact Detail</h2>
                            <div class="col-md-12">
                                <div class="col-md-3 container">
                                    <div class="group-control" style="padding-top: 20px; margin-left: 10px;">
                                        <div class="controls container">
                                            <asp:TextBox ID="txtInqEmail" class="form-control" type="email" runat="server" Style="width: 200px; margin-top: 8px;" placeholder="Enter Your Email" required="" oninvalid="this.setCustomValidity('Enter Your Proper Email')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 container">
                                    <div class="group-control" style="padding-top: 20px; margin-left: 10px;">
                                        <div class="controls container">
                                            <asp:TextBox ID="txtInqMNO" class="form-control" runat="server" Style="width: 200px; margin-top: 8px;" placeholder="Enter Your Mobile Number" type="number" required="" min="999999999" max="9999999999999" oninvalid="this.setCustomValidity('Please Enter Valid Contact Number')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="container">
                            <h2 style="margin-top: 30px;"><font style="background-color: #0CBBC8; padding: 15px; border-radius: 50%; padding-top: 7px; padding-bottom: 7px; margin-right: 10px; font-size: 20px; color: #ffffff;">3</font>Describe Your Project Here...</h2>
                            <div class="group-control" style="padding-top: 20px; margin-left: 40px;">
                                <div class="controls container">
                                    <asp:TextBox ID="txtProjInq" class="form-control" runat="server" Style="width: 60%; margin-top: 8px;" Rows="3" placeholder="Description About Your Project" TextMode="MultiLine" required="" pattern="[a-zA-Z ]+" oninvalid="this.setCustomValidity('Enter Project Description')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="controls container" style="margin-top: 40px;">
                            <div class="col-md-6 contact-right wow zoomIn" data-wow-duration="2s" data-wow-delay="0.5s">
                                <asp:Button ID="btnInqSubmit" runat="server" Text="Submit" Style="margin-left: 39px;" OnClick="btnInqSubmit_Click" />
                            </div>
                        </div>
                    </asp:Panel>

                    <%--<asp:Panel ID="PanelLogin" runat="server" Style="margin-top: -40px;">
                        <center>
                            <div style="border: 0px solid; width: 40%; display: inline-block;">
                                <div class="col-md-12">
                                    <div class="group-control" style="padding-top: 30px;">
                                        <font style="font-size: 15px; float: left; font-style: inherit;">Email Address:</font>
                                        <div class="controls">
                                            <asp:TextBox ID="txtEmail" class="form-control" runat="server" Style="margin-top: 5px;"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="group-control" style="padding-top: 30px;">
                                        <font style="font-size: 15px; float: left; font-style: inherit;">Password:</font>
                                        <div class="controls">
                                            <asp:TextBox ID="txtPassword" class="form-control" Type="password"  runat="server" Style="margin-top: 5px;"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="group-control">
                                        <div class="controls container" style="margin-top: 40px;">
                                            <div class="col-md-6 contact-right wow zoomIn" data-wow-duration="2s" data-wow-delay="0.5s">
                                                <asp:Button ID="btnLogin" runat="server" Text="Login" Style="float: left; margin-left: -28px; margin-top: 0px;" OnClick="btnLogin_Click" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="group-control">
                                        
                                    </div>
                                </div>
                            </div>
                        </center>
                    </asp:Panel>--%>

                    <%--<div class="col-md-12">
                        <asp:Panel ID="PanelReg" runat="server" Visible="false" Style="margin-top: -60px;">
                            <div class="col-md-4">
                                <div class="group-control" style="padding-top: 30px;">
                                    <font style="font-size: 15px; font-style: inherit;">User Name:</font>
                                    <div class="controls">
                                        <asp:TextBox ID="txtUName" class="form-control" runat="server" Style="width: 80%; margin-top: 5px;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="group-control" style="padding-top: 30px;">
                                    <font style="font-size: 15px; font-style: inherit;">Email Address:</font>
                                    <div class="controls">
                                        <asp:TextBox ID="txtEmailAdd" class="form-control" runat="server" Style="width: 80%; margin-top: 5px;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="group-control" style="padding-top: 30px;">
                                    <font style="font-size: 15px; font-style: inherit;">Password:</font>
                                    <div class="controls">
                                        <asp:TextBox ID="txtPassReg" class="form-control" runat="server" Style="width: 80%; margin-top: 5px;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="group-control" style="padding-top: 30px;">
                                    <font style="font-size: 15px; font-style: inherit;">Contact No:</font>
                                    <div class="controls">
                                        <asp:TextBox ID="txtRegCNO" class="form-control" runat="server" Style="width: 80%; margin-top: 5px;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="group-control" style="padding-top: 30px;">
                                    <font style="font-size: 15px; font-style: inherit;">Company Name:</font>
                                    <div class="controls">
                                        <asp:TextBox ID="txtComName" class="form-control" runat="server" Style="width: 80%; margin-top: 5px;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="group-control" style="padding-top: 30px;">
                                    <font style="font-size: 15px; font-style: inherit;">Company Logo:</font>
                                    <div class="controls">
                                        <asp:FileUpload ID="imgComLogo" class="form-control" runat="server" Style="width: 80%; margin-top: 5px;" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="group-control" style="padding-top: 30px;">
                                    <font style="font-size: 15px; font-style: inherit;">WebsiteURL:</font>
                                    <div class="controls">
                                        <asp:TextBox ID="txtWebURL" class="form-control" runat="server" Style="width: 80%; margin-top: 5px;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="group-control" style="padding-top: 30px;">
                                    <font style="font-size: 15px; font-style: inherit;">Landmark:</font>
                                    <div class="controls">
                                        <asp:TextBox ID="txtLandmark" class="form-control" runat="server" Style="width: 80%; margin-top: 5px;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="group-control" style="padding-top: 30px;">
                                    <font style="font-size: 15px; font-style: inherit;">Zipcode:</font>
                                    <div class="controls">
                                        <asp:TextBox ID="txtZipCode" class="form-control" runat="server" Style="width: 80%; margin-top: 5px;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="group-control" style="padding-top: 30px;">
                                    <font style="font-size: 15px; font-style: inherit;">Country:</font>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddCountry" runat="server" class="form-control" Style="width: 80%; margin-top: 8px;">
                                            <asp:ListItem>contry</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="group-control" style="padding-top: 30px;">
                                    <font style="font-size: 15px; font-style: inherit;">State:</font>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddState" runat="server" class="form-control" Style="width: 80%; margin-top: 8px;">
                                            <asp:ListItem>state</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="group-control" style="padding-top: 30px;">
                                    <font style="font-size: 15px; font-style: inherit;">city:</font>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddCity" runat="server" class="form-control" Style="width: 80%; margin-top: 8px;">
                                            <asp:ListItem>city</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="controls container" style="margin-top: 40px;">
                                <div class="col-md-6 contact-right wow zoomIn" data-wow-duration="2s" data-wow-delay="0.5s">
                                    <asp:Button ID="btnSubmitReg" runat="server" Text="Submit" Style="float: left; margin-left: -15px; margin-top: 40px;" OnClick="btnSubmitReg_Click" />
                                </div>
                            </div>
                        </asp:Panel>

                    </div>--%>
                </div>

                <%--<asp:Panel ID="PanelVerification" runat="server">
                    <center>
                            <div style="border: 0px solid; width: 40%; display: inline-block;">
                                <div class="col-md-12">
                                    <div class="group-control" style="padding-top: 30px;">
                                        <font style="font-size: 15px; float: left; font-style: inherit;">Verification Code:</font>
                                        <div class="controls">
                                            <asp:TextBox ID="TextBox1" class="form-control" runat="server" Style="margin-top: 5px;"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="group-control">
                                        <div class="controls container" style="margin-top: 40px;">
                                            <div class="col-md-6 contact-right wow zoomIn" data-wow-duration="2s" data-wow-delay="0.5s">
                                                <asp:Button ID="btnVSubmit" runat="server" Text="Submit" Style="float: left; margin-left: -28px; margin-top: 0px;" OnClick="btnVSubmit_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </center>
                </asp:Panel>--%>

                <div>
                    <asp:Panel ID="PanelProDes" runat="server">
                        <div class="container">
                            <h2><font style="background-color: #0CBBC8; padding: 15px; border-radius: 50%; padding-top: 7px; padding-bottom: 7px; margin-right: 10px; font-size: 20px; color: #ffffff;">1</font>What type of work do you require ?</h2>
                        </div>
                        <div class="group-control" style="padding-top: 20px; margin-left: 90px;">
                            <div class="controls container">
                                <asp:DropDownList ID="ddProCtg" runat="server" class="form-control" Style="width: 60%; margin-top: 8px;" AutoPostBack="true" OnSelectedIndexChanged="ddProCtg_SelectedIndexChanged" required="" oninvalid="this.setCustomValidity('Please Select Category')" onchange="try{setCustomValidity('')}catch(e){}">
                                    <asp:ListItem>Select a category of work</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="group-control" style="padding-top: 20px; margin-left: 90px;">
                            <div class="controls container">
                                <asp:DropDownList ID="ddSubCategory" runat="server" Visible="false" class="form-control" Style="width: 60%; margin-top: 8px;" AutoPostBack="true" OnSelectedIndexChanged="ddSubCategory_SelectedIndexChanged" required="" oninvalid="this.setCustomValidity('Please Select Sub Category')" onchange="try{setCustomValidity('')}catch(e){}">
                                    <asp:ListItem>Select a Sub Category of Your Work</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="group-control" style="padding-top: 20px; margin-left: 90px;">
                            <div class="controls container">
                                <asp:DropDownList ID="ddOtherCat" runat="server" Visible="false" class="form-control" Style="width: 60%; margin-top: 8px;" AutoPostBack="true" required="" oninvalid="this.setCustomValidity('Please Select Sub Category')" onchange="try{setCustomValidity('')}catch(e){}" OnSelectedIndexChanged="ddOtherCat_SelectedIndexChanged">
                                    <asp:ListItem>Select a Another Category of Your Work</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div>
                            <div class="container">
                                <h2 style="margin-top: 30px;"><font style="background-color: #0CBBC8; padding: 15px; border-radius: 50%; padding-top: 7px; padding-bottom: 7px; margin-right: 10px; font-size: 20px; color: #ffffff;">2</font>What is the title of project ?</h2>
                            </div>
                            <div class="group-control" style="padding-top: 20px; margin-left: 90px;">
                                <div class="controls container">
                                    <asp:TextBox ID="txtTitle" class="form-control" runat="server" Style="width: 60%; margin-top: 8px;" placeholder="Title of your project" required="" pattern="[A-Za-z\s_\.]+" MaxLength="30" oninvalid="this.setCustomValidity('Accept Alphabet Only')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div>
                            <div class="container">
                                <h2 style="margin-top: 30px;"><font style="background-color: #0CBBC8; padding: 15px; border-radius: 50%; padding-top: 7px; padding-bottom: 7px; margin-right: 10px; font-size: 20px; color: #ffffff;">3</font>Describe your project here...</h2>
                            </div>
                            <div class="group-control" style="padding-top: 20px; margin-left: 90px;">
                                <div class="controls container">
                                    <asp:TextBox ID="txtProDesc" class="form-control" runat="server" Style="width: 60%; margin-top: 8px;" Rows="3" placeholder="Description about your project" TextMode="MultiLine" required="" pattern="[a-zA-Z_\.\ ]{20,100}" oninvalid="this.setCustomValidity('Please Enter The Project Description')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div id="FileUpload">
                            <div class="container">
                                <h2 style="margin-top: 30px;"><font style="background-color: #0CBBC8; padding: 15px; border-radius: 50%; padding-top: 7px; padding-bottom: 7px; margin-right: 10px; font-size: 20px; color: #ffffff;">4</font>Upload Content File [Optional]...</h2>
                            </div>
                            <div class="group-control" style="padding-top: 20px; margin-left: 90px;">
                                <div class="controls container">
                                    <label class="fileContainer" style="font-size: 20px; font-family: 'Sanchez', serif; color: #0CBBC8;">
                                        <i class="fa fa-upload" style="color: #0CBBC8;"></i>Browse Your File....
                                        <asp:FileUpload ID="FileContent" class="form-control" onchange="showimagepreview(this)" runat="server" />
                                    </label>
                                    <%--<asp:FileUpload ID="FileContent" runat="server" class="form-control" Style="width: 60%; margin-top: 8px;" Rows="3" />--%>
                                </div>
                            </div>
                        </div>

                        <div>

                            <div class="container">
                                <h2 style="margin-top: 30px;"><font style="background-color: #0CBBC8; padding: 15px; border-radius: 50%; padding-top: 7px; padding-bottom: 7px; margin-right: 10px; font-size: 20px; color: #ffffff;">5</font>How many days of your Project Plan?</h2>
                            </div>
                            <div class="group-control" style="padding-top: 20px; margin-left: 90px;">
                                <div class="controls container">
                                    <asp:TextBox ID="txtProjectPlan" class="form-control" runat="server" type="number" Style="width: 60%; margin-top: 8px;" placeholder="Enter Days of Project Plan" required="" min="1" max="1825" pattern="[1-9][0-9]{0,2}" oninvalid="this.setCustomValidity('Please Enter Days of Project Plan between 7 to 1825 days(5 Years)')" onchange="try{setCustomValidity('')}catch(e){}"></asp:TextBox>
                                </div>
                            </div>

                            <%--<div class="group-control" style="padding-top: 20px; margin-left: 90px;">
                                <div class="controls container">
                                    <div class="col-md-2">
                                        <asp:DropDownList ID="ddDay" runat="server" class="form-control" Style="margin-top: 8px;" required="" oninvalid="this.setCustomValidity('Please Select Day')" onchange="try{setCustomValidity('')}catch(e){}">
                                            <asp:ListItem Value="">Day</asp:ListItem>
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                            <asp:ListItem Value="7">7</asp:ListItem>
                                            <asp:ListItem Value="8">8</asp:ListItem>
                                            <asp:ListItem Value="9">9</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="11">11</asp:ListItem>
                                            <asp:ListItem Value="12">12</asp:ListItem>
                                            <asp:ListItem Value="13">13</asp:ListItem>
                                            <asp:ListItem Value="14">14</asp:ListItem>
                                            <asp:ListItem Value="15">15</asp:ListItem>
                                            <asp:ListItem Value="16">16</asp:ListItem>
                                            <asp:ListItem Value="17">17</asp:ListItem>
                                            <asp:ListItem Value="18">18</asp:ListItem>
                                            <asp:ListItem Value="19">19</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="21">21</asp:ListItem>
                                            <asp:ListItem Value="22">22</asp:ListItem>
                                            <asp:ListItem Value="23">23</asp:ListItem>
                                            <asp:ListItem Value="24">24</asp:ListItem>
                                            <asp:ListItem Value="25">25</asp:ListItem>
                                            <asp:ListItem Value="26">26</asp:ListItem>
                                            <asp:ListItem Value="27">27</asp:ListItem>
                                            <asp:ListItem Value="28">28</asp:ListItem>
                                            <asp:ListItem Value="29">29</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="31">31</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:DropDownList ID="ddMonth" runat="server" class="form-control" Style="margin-top: 8px;" required="" oninvalid="this.setCustomValidity('Please Select Month')" onchange="try{setCustomValidity('')}catch(e){}">
                                            <asp:ListItem Value="">Month</asp:ListItem>
                                            <asp:ListItem Value="1">Jan</asp:ListItem>
                                            <asp:ListItem Value="2">Feb</asp:ListItem>
                                            <asp:ListItem Value="3">Mar</asp:ListItem>
                                            <asp:ListItem Value="4">Apr</asp:ListItem>
                                            <asp:ListItem Value="5">May</asp:ListItem>
                                            <asp:ListItem Value="6">Jun</asp:ListItem>
                                            <asp:ListItem Value="7">Jul</asp:ListItem>
                                            <asp:ListItem Value="8">Aug</asp:ListItem>
                                            <asp:ListItem Value="9">Sep</asp:ListItem>
                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                            <asp:ListItem Value="11">Nov</asp:ListItem>
                                            <asp:ListItem Value="12">Dec</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:DropDownList ID="ddYear" runat="server" class="form-control" Style="margin-top: 8px;" required="" oninvalid="this.setCustomValidity('Please Select Year')" onchange="try{setCustomValidity('')}catch(e){}">
                                            <asp:ListItem Value="">Year</asp:ListItem>
                                            <asp:ListItem Value="1">2017</asp:ListItem>
                                            <asp:ListItem Value="2">2018</asp:ListItem>
                                            <asp:ListItem Value="3">2019</asp:ListItem>
                                            <asp:ListItem Value="4">2020</asp:ListItem>
                                            <asp:ListItem Value="5">2021</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6"></div>
                                </div>
                            </div>--%>

                            <div class="controls container" style="margin-top: 40px;">
                                <div class="col-md-6 contact-right wow zoomIn" data-wow-duration="2s" data-wow-delay="0.5s">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Style="margin-left: 39px;" OnClick="btnSubmit_Click" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </ContentTemplate>
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="btnLogin" />--%>
                <%--<asp:PostBackTrigger ControlID="btnSubmitReg" />--%>
                <%--<asp:PostBackTrigger ControlID="btnVSubmit" />--%>
                <asp:PostBackTrigger ControlID="btnSubmit" />
                <asp:PostBackTrigger ControlID="ddSubCategory" />
                <asp:AsyncPostBackTrigger ControlID="txtTitle" />
                <asp:PostBackTrigger ControlID="btnInqSubmit" />
                <asp:PostBackTrigger ControlID="lnkUser" />
                <asp:PostBackTrigger ControlID="lnkNew" />
                <asp:PostBackTrigger ControlID="lnkReg" />
                <asp:PostBackTrigger ControlID="lnkInquiry" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <!--//our works -->

</asp:Content>

