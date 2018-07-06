using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class ClientLogin : System.Web.UI.Page
{
    ServiceClient objClient = new ServiceClient();
    public static string GetMacAddress()
    {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            // Only consider Ethernet network interfaces
            if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            {
                return nic.GetPhysicalAddress().ToString();
            }
        }
        return null;
    }
    public void AddErrorLog(ref Exception strException, string PageName, string UserType, int UserID, int AdminID, string MACAddress = null)
    {
        var DC = new DataClassesDataContext();
        //Insert record in ErrorLog
        tblError objError = new tblError();
        objError.PageName = PageName;
        objError.Description = strException.Message.ToString();
        objError.CreatedOn = Convert.ToDateTime(DateTime.Now);
        objError.UserType = UserType;
        if (UserID != 0)
        {
            objError.UserID = UserID;
        }
        else
        {
            objError.UserID = null;
        }
        if (AdminID != 0)
        {
            objError.AdminID = AdminID;
        }
        else
        {
            objError.AdminID = null;
        }
        if (MACAddress != null)
        {
            objError.MacAddress = MACAddress;
        }
        else
        {
            objError.MacAddress = null;
        }
        DC.tblErrors.InsertOnSubmit(objError);
        DC.SubmitChanges();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Panellogin.Visible = true;
            Panelforgetpass.Visible = false;
            Panelchangpass.Visible = false;
            PanelSignUp.Visible = false;
            PanelVerifyEmail.Visible = false;

            if (Session["PostProjectReg"] != null)
            {
                if (Session["PostProjectReg"].ToString() == "True")
                {
                    PanelSignUp.Visible = true;
                    Panellogin.Visible = false;
                    Panelforgetpass.Visible = false;
                    Panelchangpass.Visible = false;
                    PanelVerifyEmail.Visible = false;
                    chkEmployee.Visible = false;
                    lblEmp.Visible = false;
                }
            }
            if (Session["EmailID"] != null)
            {
                PanelSignUp.Visible = false;
                PanelVerifyEmail.Visible = true;
                Panellogin.Visible = false;
                Panelforgetpass.Visible = false;
                Panelchangpass.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
    public static bool CheckForInternetConnection()
    {
        try
        {
            using (var client = new WebClient())
            {
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
        }
        catch
        {
            return false;
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            IList<string> vc = objClient.MailToPerson(txtLoginEmail.Text);
            string Code;
            string Check;
            try
            {
                Session["vc"] = vc[0];
                Check = vc[1];
            }
            catch (Exception Ex)
            {
                Code = null;
                Check = null;
            }


            if (vc != null && (Check == "NotVerify" || Session["vc"] != null))
            {
                Session["EmailID"] = txtLoginEmail.Text;
                PanelVerifyEmail.Visible = true;
                Panellogin.Visible = false;
                PanelSignUp.Visible = false;
                Panelchangpass.Visible = false;
                Panelforgetpass.Visible = false;
            }
            else
            {


                if (Session["PostProject"] != null)
                {
                    IList<string> Login = objClient.ClientLogin(txtLoginEmail.Text, txtLoginPassword.Text);
                    if (Login != null)
                    {
                        if (Login[0] == "Employee")
                        {
                            errorLogin.Text = "You are employee you can't post the project";
                            errorLogin.Visible = true;
                        }

                        else if (Login[0] == "Client")
                        {
                            Session["ClientID"] = Login[1];
                            Response.Redirect("PostProject.aspx");
                        }
                    }
                    else
                    {
                        errorLogin.Text = "Your EmailID and Password is invalid";
                        errorLogin.Visible = true;
                    }
                }
                else
                {
                    IList<string> Login = objClient.ClientLogin(txtLoginEmail.Text, txtLoginPassword.Text);
                    if (Login != null)
                    {
                        if (Login[0] == "Employee")
                        {
                            Session["EmpID"] = Login[1];
                            Response.Redirect("Dashboard.aspx");
                        }
                        else if (Login[0] == "Client")
                        {
                            Session["ClientID"] = Login[1];
                            Response.Redirect("TrackProject.aspx");
                        }
                    }
                    else
                    {
                        errorLogin.Text = "Your EmailID and Password is invalid";
                        errorLogin.Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            Panellogin.Visible = false;
            PanelSignUp.Visible = true;
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lkforgetpass_Click(object sender, EventArgs e)
    {
        try
        {
            Panellogin.Visible = false;
            Panelforgetpass.Visible = true;
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btncode_Click(object sender, EventArgs e)
    {
        try
        {
            txtcode.Visible = true;
            btnsubmit.Visible = true;
            btncode.Visible = false;
            Panelforgetpass.Visible = true;
            var EmailChecking = objClient.EmailCkecking(txtForPassEmail.Text, "Login");
            if (EmailChecking == true)
            {
                string vc;

                DateTime now = DateTime.Now;
                vc = now.ToString();
                vc = vc.GetHashCode().ToString().Trim('-');
                MailMessage Msg = new MailMessage("trackmyworkindia@gmail.com", txtForPassEmail.Text);
                Msg.Subject = "Email Verification";
                //Msg.Body = "<html><head></head><body><table><tr><td>Your E-Mail :</td><td>" + txtForPassEmail.Text + "</td></tr><tr><td>Your Code :</td><td>" + vc + "</td></tr></table></body></html>";
                Msg.Body = "<!DOCTYPE html><html><head><title>Track My Work</title> <meta charset=\"utf - 8\"><meta name=\"viewport\" content=\"width = device - width, initial - scale = 1\"><meta http-equiv=\"X - UA - Compatible\" content=\"IE = edge\" /><style type=\"text / css\"> /* CLIENT-SPECIFIC STYLES */ body, table, td, a{-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;} /* Prevent WebKit and Windows mobile changing default text sizes */ table, td{mso-table-lspace: 0pt; mso-table-rspace: 0pt;} /* Remove spacing between tables in Outlook 2007 and up */ img{-ms-interpolation-mode: bicubic;} /* Allow smoother rendering of resized image in Internet Explorer */ /* RESET STYLES */ img{border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none;} table{border-collapse: collapse !important;} body{height: 100% !important; margin: 0 !important; padding: 0 !important; width: 100% !important;} /* iOS BLUE LINKS */ a[x-apple-data-detectors] { color: inherit !important; text-decoration: none !important; font-size: inherit !important; font-family: inherit !important; font-weight: inherit !important; line-height: inherit !important; } /* MOBILE STYLES */ @media screen and (max-width: 525px) { /* ALLOWS FOR FLUID TABLES */ .wrapper { width: 100% !important; max-width: 100% !important; } /* ADJUSTS LAYOUT OF LOGO IMAGE */ .logo img { margin: 0 auto !important; } /* USE THESE CLASSES TO HIDE CONTENT ON MOBILE */ .mobile-hide { display: none !important; } .img-max { max-width: 100% !important; width: 100% !important; height: auto !important; } /* FULL-WIDTH TABLES */ .responsive-table { width: 100% !important; } /* UTILITY CLASSES FOR ADJUSTING PADDING ON MOBILE */ .padding { padding: 10px 5% 15px 5% !important; } .padding-meta { padding: 30px 5% 0px 5% !important; text-align: center; } .no-padding { padding: 0 !important; } .section-padding { padding: 50px 15px 50px 15px !important; } /* ADJUST BUTTONS ON MOBILE */ .mobile-button-container { margin: 0 auto; width: 100% !important; } .mobile-button { padding: 15px !important; border: 0 !important; font-size: 16px !important; display: block !important; } } /* ANDROID CENTER FIX */ div[style*=\"margin: 16px 0; \"] { margin: 0 !important; }</style></head><body style=\"margin: 0 !important; padding: 0 !important; \"><!-- HIDDEN PREHEADER TEXT --><div style=\"display: none; font - size: 1px; color: #fefefe; line-height: 1px; font-family: Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;\"> Entice the open with some amazing preheader text. Use a little mystery and get those subscribers to read through...</div><!-- HEADER --><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"> <tr> <td align=\"center\" style=\" background:#008bff;\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 500px;\" class=\"wrapper\"> <tr style=\" background:#008bff;\"> <td align=\"center\" valign=\"top\" style=\"padding: 15px 0;\" class=\"logo\"> <h1 style=\"color:white; background:#008bff; font-family:calibri; font-size:40px;\">Track My Work</h1> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td bgcolor=\"#ffffff\" align=\"center\" style=\"padding: 70px 15px 70px 15px;\" class=\"section-padding\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 500px;\" class=\"responsive-table\"> <tr> <td> <!-- HERO IMAGE --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td> <!-- COPY --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td align=\"center\" style=\"font-size: 25px; font-family: Helvetica, Arial, sans-serif; color: #333333; padding-top: 30px;\" class=\"padding\">Your Email id is</td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0 0 0; font-size: 16px; line-height: 25px; font-family: Helvetica, Arial, sans-serif; color: #666666;\" class=\"padding\">" + txtForPassEmail.Text + "</td> </tr> <tr> <td align=\"center\" style=\"font-size: 25px; font-family: Helvetica, Arial, sans-serif; color: #333333; padding-top: 30px;\" class=\"padding\">Your Verification Code is</td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0 0 0; font-size: 16px; line-height: 25px; font-family: Helvetica, Arial, sans-serif; color: #666666;\" class=\"padding\">" + vc + "</td> </tr> </table> </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0px; background:#424242; color:white;\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <!-- UNSUBSCRIBE COPY --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"max-width: 500px;\" class=\"responsive-table\"> <tr> <td align=\"center\" style=\"font-size: 12px; line-height: 18px; font-family: Helvetica, Arial, sans-serif; color:white;\"> <b>Track My Work</b> by:- Renown Infosys <span style=\"font-family: Arial, sans-serif; font-size: 12px; color:white;\">&nbsp;&nbsp;</span> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr></table></body></html>";

                Msg.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                NetworkCredential MyCredentials = new NetworkCredential("trackmyworkindia@gmail.com", "TMW2016open");
                smtp.Credentials = MyCredentials;
                smtp.Send(Msg);
                //Panel6.Visible = true;
                Session["VCode"] = vc;
                //Label2.Text = Session["VCode"].ToString();
                //Button2.Visible = false;
                Panelforgetpass.Visible = true;
                Panellogin.Visible = false;
                errorForEmail.Visible = false;

            }
            else
            {
                errorForEmail.Text = "You are not Registered user Check Your Email";
                errorForEmail.Visible = true;
                Panelforgetpass.Visible = true;
                btncode.Visible = true;
                Panelchangpass.Visible = false;
                PanelSignUp.Visible = false;
                Panellogin.Visible = false;
                txtcode.Visible = false;
                btnsubmit.Visible = false;
                errorCode.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["VCode"].ToString() == txtcode.Text)
            {
                Panelforgetpass.Visible = false;
                Panellogin.Visible = false;
                Panelchangpass.Visible = true;
                errorCode.Visible = false;
            }
            else
            {
                Panelforgetpass.Visible = true;
                errorCode.Visible = true;
                Panellogin.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnchandpass_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNewPwd.Text == txtConfirmPassword.Text)
            {
                objClient.ForgetChangePwd(txtForPassEmail.Text, txtNewPwd.Text);
                Panelchangpass.Visible = false;
                Panellogin.Visible = true;
                ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Password Changed Successfully');window.location ='ClientLogin.aspx'</script>");
            }
            else
            {
                errorChangePassword.Text = "Password don't match. Please enter same password.";
                errorChangePassword.Visible = true;
                Panellogin.Visible = false;
                Panelchangpass.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnsignup_Click(object sender, EventArgs e)
    {
        if (CheckForInternetConnection() == true)
        {
            try
            {
                bool CheckEmail = objClient.EmailCkecking(txtRegEmail.Text, "");
                if (CheckEmail == false)
                {
                    errorEmail.Text = "Email Already Exist..";
                    errorEmail.Visible = true;
                    PanelSignUp.Visible = true;
                    Panellogin.Visible = false;
                    Panelchangpass.Visible = false;
                    Panelforgetpass.Visible = false;
                    PanelVerifyEmail.Visible = false;
                }
                else
                {
                    if (chkEmployee.Checked == true)
                    {
                        if (Session["PostProjectReg"] == null)
                        {
                            if (CheckEmail == false)
                            {
                                errorEmail.Visible = false;
                            }
                            else
                            {
                                objClient.EmployeeRegistration(txtRegFname.Text, txtRegLname.Text, txtRegEmail.Text, txtRegPassword.Text, txtRegCNO.Text, Convert.ToInt32(null), null);
                            }
                            //var dc = new DataClassesDataContext();
                            //tblEmployee EmpData = (from obj in dc.tblEmployees
                            //                       orderby obj.EmpID descending
                            //                       select obj).First();
                            //tblEmpAppraisal EmpAppraisal = new tblEmpAppraisal();
                            //EmpAppraisal.EmpID = EmpData.EmpID;
                            //EmpAppraisal.Skills = Convert.ToDecimal(0.0);
                            //EmpAppraisal.Quality = Convert.ToDecimal(0.0);
                            //EmpAppraisal.Avialibility = Convert.ToDecimal(0.0);
                            //EmpAppraisal.Deadlines = Convert.ToDecimal(0.0);
                            //EmpAppraisal.Communication = Convert.ToDecimal(0.0);
                            //EmpAppraisal.Cooperation = Convert.ToDecimal(0.0);
                            //EmpAppraisal.ClientFeedback = Convert.ToDecimal(0.0);
                            //EmpAppraisal.CreatedBy = 1;
                            //EmpAppraisal.CreatedOn = DateTime.Now;
                            //dc.tblEmpAppraisals.InsertOnSubmit(EmpAppraisal);
                            //dc.SubmitChanges();
                        }
                    }
                    else
                    {
                        Session["EmailID"] = txtRegEmail.Text;
                        if (Session["PostProjectReg"] != null)
                        {

                            if (CheckEmail == false)
                            {
                                errorEmail.Visible = false;
                            }
                            else
                            {
                                objClient.ClientRegistration(txtRegFname.Text + " " + txtRegLname.Text, txtRegEmail.Text, txtRegPassword.Text, txtRegCNO.Text, null, null, null, null, Convert.ToInt32(null), Convert.ToInt32(null), Convert.ToInt32(null));
                                IList<string> Data = objClient.MailToPerson(txtRegEmail.Text);
                                Session["vc"] = Data[0];
                                PanelSignUp.Visible = false;
                                PanelVerifyEmail.Visible = true;
                                Panellogin.Visible = false;
                                Panelforgetpass.Visible = false;
                                Panelchangpass.Visible = false;
                            }
                        }
                        else
                        {
                            objClient.ClientRegistration(txtRegFname.Text + " " + txtRegLname.Text, txtRegEmail.Text, txtRegPassword.Text, txtRegCNO.Text, null, null, null, null, Convert.ToInt32(null), Convert.ToInt32(null), Convert.ToInt32(null));
                            IList<string> Data = objClient.MailToPerson(txtRegEmail.Text);
                            Session["vc"] = Data[0];
                            PanelSignUp.Visible = false;
                            PanelVerifyEmail.Visible = true;
                            Panellogin.Visible = false;
                            Panelforgetpass.Visible = false;
                            Panelchangpass.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //int session = Convert.ToInt32(Session["ClientID"].ToString());
                string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                string MACAddress = GetMacAddress();
                AddErrorLog(ref ex, PageName, "Client", 0, 0, MACAddress);
                ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Please Check your Internet Connection');", true);
            PanelSignUp.Visible = true;
            PanelVerifyEmail.Visible = false;
            Panellogin.Visible = false;
            Panelforgetpass.Visible = false;
            Panelchangpass.Visible = false;
        }
    }
    protected void btnSubmitCode_Click(object sender, EventArgs e)
    {
        try
        {
            string PersonType = objClient.GetPersonType(Session["EmailID"].ToString());

            if (PersonType == "Employee")
            {
                if (Session["vc"].ToString() == txtVerificationCode.Text)
                {
                    Session["EmpID"] = objClient.VerifyPerson(Session["EmailID"].ToString());
                    Session.Remove("EmailID");
                    ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Register and Verify Successfully');window.location ='Dashboard.aspx'</script>");
                }
                else
                {
                    lblverify.Text = "Your Verification code is invalid.";
                    lblverify.Visible = true;
                }
            }
            else if (PersonType == "Client")
            {
                if (Session["vc"].ToString() == txtVerificationCode.Text)
                {
                    if (Session["PostProjectReg"] != null || Session["PostProject"] != null)
                    {
                        Session["ClientID"] = objClient.VerifyPerson(Session["EmailID"].ToString());
                        Session.Remove("EmailID");
                        ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Register and Verify Successfully');window.location ='PostProject.aspx'</script>");
                    }
                    else
                    {
                        Session["ClientID"] = objClient.VerifyPerson(Session["EmailID"].ToString());
                        Session.Remove("EmailID");
                        ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Register and Verify Successfully');window.location ='Default.aspx'</script>");
                    }
                }
                else
                {
                    lblverify.Text = "Your Verification code is invalid.";
                    lblverify.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkSendCodeAgain_Click(object sender, EventArgs e)
    {
        try
        {
            string Person = objClient.GetPersonType(Session["EmailID"].ToString());
            objClient.MailToPerson(Session["EmailID"].ToString());
            if (Person == "Employee")
            {
                objClient.MailToPerson(Session["EmailID"].ToString());
            }
            else if (Person == "Client")
            {
                objClient.MailToPerson(Session["EmailID"].ToString());
            }
            else
            {
                lblverify.Text = "Invalid EmailID.";
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }


    protected void txtRegEmail_TextChanged(object sender, EventArgs e)
    {
        try
        {
            bool CheckEmail = objClient.EmailCkecking(txtRegEmail.Text, "");
            if (CheckEmail == false)
            {
                errorEmail.Text = "Email Already Exist..";
                errorEmail.Visible = true;
                PanelSignUp.Visible = true;
                Panellogin.Visible = false;
                Panelchangpass.Visible = false;
                Panelforgetpass.Visible = false;
                PanelVerifyEmail.Visible = false;
            }
            else
            {
                errorEmail.Visible = false;
                PanelSignUp.Visible = true;
                Panellogin.Visible = false;
                Panelchangpass.Visible = false;
                Panelforgetpass.Visible = false;
                PanelVerifyEmail.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}
