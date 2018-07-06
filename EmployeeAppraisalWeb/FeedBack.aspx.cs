using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Mail;

public partial class FeedBack : System.Web.UI.Page
{
    ServiceClient objFeedBack = new ServiceClient();
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
            string Point = txtRate.Value;
            if (!IsPostBack)
            {
                var DC = new DataClassesDataContext();
                int cnt = (from ob in DC.tblClients
                           where ob.ClientID == Convert.ToUInt32(Session["ClientID"])
                           select ob).Count();
                if (cnt > 0)
                {
                    tblClient Data = (from ob in DC.tblClients
                                      where ob.ClientID == Convert.ToUInt32(Session["ClientID"])
                                      select ob).Single();
                    txtEmail.Text = Data.EmailID;
                    txtName.Text = Data.ClientName;
                    txtOrgn.Text = Data.CompanyName;
                    ddProduct.DataSource = objFeedBack.BindClientProject(Data.ClientID);
                    ddProduct.DataValueField = "ProjectID";
                    ddProduct.DataTextField = "Title";
                    ddProduct.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    //protected void txtEmail_TextChanged(object sender, EventArgs e)
    //{
    //    var Data = objFeedBack.GetClientDetail(txtEmail.Text);
    //    txtName.Text = Data.ClientName;
    //    txtOrgn.Text = Data.CompanyName;
    //    ddProduct.DataSource = objFeedBack.BindClientProject(Data.ClientID);
    //    ddProduct.DataValueField = "ProjectID";
    //    ddProduct.DataTextField = "Title";
    //    ddProduct.DataBind();
    //}
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (CheckForInternetConnection()==true)
        {
            try
            {
                var DC = new DataClassesDataContext();
                int ProjectID;
                if (ddProduct.SelectedValue != null)
                {
                    ProjectID = Convert.ToInt32(ddProduct.SelectedValue);
                }
                else
                {
                    ProjectID = 0;
                }

                //if (txtRate.Value == "5")
                //{
                //    Point = 5;
                //}
                //else if (txtRate.Value == "4")
                //{
                //    Point = 4;
                //}
                //else if (txtRate.Value == "3")
                //{
                //    Point = 3;
                //}
                //else if (txtRate.Value == "2")
                //{
                //    Point = 2;
                //}
                //else if (txtRate.Value == "1")
                //{
                //    Point = 1;
                //}
                //else
                //{
                //    Point = 5;
                //}

                int Point = Convert.ToInt32(txtRate.Value);

                int count = DC.tblFeedbacks.Count(ob => ob.ClientID == Convert.ToInt32(Session["ClientID"]) && ob.ProjectID == Convert.ToInt32(ddProduct.SelectedValue));
                if(count > 0)
                {
                    tblFeedback FeedbackPoint = (from ob in DC.tblFeedbacks
                                                 where ob.ClientID == Convert.ToInt32(Session["ClientID"]) && ob.ProjectID == Convert.ToInt32(ddProduct.SelectedValue)
                                                 select ob).Single();
                    FeedbackPoint.FeedBackPoint = Point;
                    DC.SubmitChanges();
                    ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('FeedBack Successfully Submitted');window.location ='Default.aspx'</script>");
                }
                else
                {
                    bool obj = objFeedBack.GiveFeedback(txtEmail.Text, ProjectID, Point, txtEnquiry.Text);
                    if (obj == true)
                    {

                        //IList<string> vc;
                        tblFeedback FeedbackID = (from ob in DC.tblFeedbacks
                                                  orderby ob.FeedbackID descending
                                                  select ob).First();
                        tblFeedback Client = (from ob in DC.tblFeedbacks
                                              where ob.EmailID == FeedbackID.EmailID
                                              select ob).Single();
                        DateTime now = DateTime.Now;
                        MailMessage Msg = new MailMessage("trackmyworkindia@gmail.com", FeedbackID.EmailID);
                        Msg.Subject = "feedback";
                        //Msg.Body = "<html><head></head><body><table><tr><td>Your E-Mail :</td><td>" + InquiryID.EmailID + "</td><br></tr><tr><p><td>" + "Your inquiry Successfull recieved and inquiry under process" + "</td></p></tr></table></body></html>";
                        Msg.Body = "<!DOCTYPE html><html><head><title>Track My Work</title> <meta charset=\"utf - 8\"><meta name=\"viewport\" content=\"width = device - width, initial - scale = 1\"><meta http-equiv=\"X - UA - Compatible\" content=\"IE = edge\" /><style type=\"text / css\"> /* CLIENT-SPECIFIC STYLES */ body, table, td, a{-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;} /* Prevent WebKit and Windows mobile changing default text sizes */ table, td{mso-table-lspace: 0pt; mso-table-rspace: 0pt;} /* Remove spacing between tables in Outlook 2007 and up */ img{-ms-interpolation-mode: bicubic;} /* Allow smoother rendering of resized image in Internet Explorer */ /* RESET STYLES */ img{border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none;} table{border-collapse: collapse !important;} body{height: 100% !important; margin: 0 !important; padding: 0 !important; width: 100% !important;} /* iOS BLUE LINKS */ a[x-apple-data-detectors] { color: inherit !important; text-decoration: none !important; font-size: inherit !important; font-family: inherit !important; font-weight: inherit !important; line-height: inherit !important; } /* MOBILE STYLES */ @media screen and (max-width: 525px) { /* ALLOWS FOR FLUID TABLES */ .wrapper { width: 100% !important; max-width: 100% !important; } /* ADJUSTS LAYOUT OF LOGO IMAGE */ .logo img { margin: 0 auto !important; } /* USE THESE CLASSES TO HIDE CONTENT ON MOBILE */ .mobile-hide { display: none !important; } .img-max { max-width: 100% !important; width: 100% !important; height: auto !important; } /* FULL-WIDTH TABLES */ .responsive-table { width: 100% !important; } /* UTILITY CLASSES FOR ADJUSTING PADDING ON MOBILE */ .padding { padding: 10px 5% 15px 5% !important; } .padding-meta { padding: 30px 5% 0px 5% !important; text-align: center; } .no-padding { padding: 0 !important; } .section-padding { padding: 50px 15px 50px 15px !important; } /* ADJUST BUTTONS ON MOBILE */ .mobile-button-container { margin: 0 auto; width: 100% !important; } .mobile-button { padding: 15px !important; border: 0 !important; font-size: 16px !important; display: block !important; } } /* ANDROID CENTER FIX */ div[style*=\"margin: 16px 0; \"] { margin: 0 !important; }</style></head><body style=\"margin: 0 !important; padding: 0 !important; \"><!-- HIDDEN PREHEADER TEXT --><div style=\"display: none; font - size: 1px; color: #fefefe; line-height: 1px; font-family: Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;\"> Entice the open with some amazing preheader text. Use a little mystery and get those subscribers to read through...</div><!-- HEADER --><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"> <tr> <td align=\"center\" style=\" background:#008bff;\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 500px;\" class=\"wrapper\"> <tr style=\" background:#008bff;\"> <td align=\"center\" valign=\"top\" style=\"padding: 15px 0;\" class=\"logo\"> <h1 style=\"color:white; background:#008bff; font-family:calibri; font-size:40px;\">Track My Work</h1> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td bgcolor=\"#ffffff\" align=\"center\" style=\"padding: 70px 15px 70px 15px;\" class=\"section-padding\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 500px;\" class=\"responsive-table\"> <tr> <td> <!-- HERO IMAGE --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td> <!-- COPY --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td align=\"center\" style=\"font-size: 25px; font-family: Helvetica, Arial, sans-serif; color: #333333; padding-top: 30px;\" class=\"padding\">Your Email id is</td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0 0 0; font-size: 16px; line-height: 25px; font-family: Helvetica, Arial, sans-serif; color: #666666;\" class=\"padding\">" + FeedbackID.EmailID + "</td> </tr> <tr> <td align=\"center\" style=\"font-size: 25px; font-family: Helvetica, Arial, sans-serif; color: #333333; padding-top: 30px;\" class=\"padding\">Your Feedback Successfully Submitted.. Thank You For Your Valuable Feedback..</td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0 0 0; font-size: 16px; line-height: 25px; font-family: Helvetica, Arial, sans-serif; color: #666666;\" class=\"padding\"></td> </tr> </table> </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0px; background:#424242; color:white;\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <!-- UNSUBSCRIBE COPY --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"max-width: 500px;\" class=\"responsive-table\"> <tr> <td align=\"center\" style=\"font-size: 12px; line-height: 18px; font-family: Helvetica, Arial, sans-serif; color:white;\"> <b>Track My Work</b> by:- Renown Infosys <span style=\"font-family: Arial, sans-serif; font-size: 12px; color:white;\">&nbsp;&nbsp;</span> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr></table></body></html>";
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
                        ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('FeedBack Successfully Submitted');window.location ='Default.aspx'</script>");
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Oops! Something goes wrong...');window.location ='FeedBack.aspx'</script>");
                    }
                }

                //ManagerAppraisal
                tblEmployee Manager = (from ob in DC.tblEmployees
                                       join ob2 in DC.tblProjects
                                       on ob.EmpID equals ob2.ManagerID
                                       where ob2.ProjectID == Convert.ToInt32(ddProduct.SelectedValue)
                                       select ob).Single();
                int cnt = (from ob in DC.tblEmpAppraisals
                           where ob.EmpID == Manager.EmpID
                           select ob).Count();
                if (cnt > 0)
                {
                    tblEmpAppraisal Appraisal = (from ob in DC.tblEmpAppraisals
                                                 where ob.EmpID == Manager.EmpID
                                                 select ob).Single();
                    Appraisal.ClientFeedback += Convert.ToInt32(Point);

                }
                else
                {
                    tblEmpAppraisal Appraisal = new tblEmpAppraisal();
                    Appraisal.EmpID = Manager.EmpID;
                    Appraisal.Skills = Convert.ToDecimal(0.0);
                    Appraisal.Quality = Convert.ToDecimal(0.0);
                    Appraisal.Avialibility = Convert.ToDecimal(0.0);
                    Appraisal.Deadlines = Convert.ToDecimal(0.0);
                    Appraisal.Communication = Convert.ToDecimal(0.0);
                    Appraisal.Cooperation = Convert.ToDecimal(0.0);
                    Appraisal.ClientFeedback = Convert.ToDecimal(Point);
                    Appraisal.CreatedOn = DateTime.Now;
                    DC.tblEmpAppraisals.InsertOnSubmit(Appraisal);
                    DC.SubmitChanges();
                }

                //TeamLeader
                IQueryable<tblEmployee> TeamMember = (from ob in DC.tblEmployees
                                                      join ob2 in DC.tblTeamModules
                                                      on ob.EmpID equals ob2.EmpID
                                                      join ob3 in DC.tblModules
                                                      on ob2.ModuleID equals ob3.ModuleID
                                                      where ob3.ProjectID == Convert.ToInt32(ddProduct.SelectedValue)
                                                      select ob);

                foreach (tblEmployee data in TeamMember)
                {
                    int cntEmp = (from ob in DC.tblEmpAppraisals
                                  where ob.EmpID == data.EmpID
                                  select ob).Count();
                    if (cntEmp > 0)
                    {
                        tblEmpAppraisal Appraisal = (from ob in DC.tblEmpAppraisals
                                                     where ob.EmpID == data.EmpID
                                                     select ob).Single();
                        Appraisal.ClientFeedback += Convert.ToInt32(Point);

                    }
                    else
                    {
                        tblEmpAppraisal Appraisal = new tblEmpAppraisal();
                        Appraisal.EmpID = data.EmpID;
                        Appraisal.Skills = Convert.ToDecimal(0.0);
                        Appraisal.Quality = Convert.ToDecimal(0.0);
                        Appraisal.Avialibility = Convert.ToDecimal(0.0);
                        Appraisal.Deadlines = Convert.ToDecimal(0.0);
                        Appraisal.Communication = Convert.ToDecimal(0.0);
                        Appraisal.Cooperation = Convert.ToDecimal(0.0);
                        Appraisal.ClientFeedback = Convert.ToDecimal(Point);
                        Appraisal.CreatedOn = DateTime.Now;
                        DC.tblEmpAppraisals.InsertOnSubmit(Appraisal);
                        DC.SubmitChanges();
                    }
                }

                //Employee
                IQueryable<tblEmployee> Employee = (from ob in DC.tblEmployees
                                                    join ob2 in DC.tblTeamMembers
                                                    on ob.EmpID equals ob2.EmpID
                                                    join ob3 in DC.tblTasks
                                                    on ob2.TaskID equals ob3.TaskID
                                                    join ob4 in DC.tblModules
                                                    on ob3.ModuleID equals ob4.ModuleID
                                                    where ob4.ProjectID == Convert.ToInt32(ddProduct.SelectedValue)
                                                    select ob);

                foreach (tblEmployee data in Employee)
                {
                    int cntEmp = (from ob in DC.tblEmpAppraisals
                                  where ob.EmpID == data.EmpID
                                  select ob).Count();
                    if (cntEmp > 0)
                    {
                        tblEmpAppraisal Appraisal = (from ob in DC.tblEmpAppraisals
                                                     where ob.EmpID == data.EmpID
                                                     select ob).Single();
                        Appraisal.ClientFeedback += Convert.ToInt32(Point);

                    }
                    else
                    {
                        tblEmpAppraisal Appraisal = new tblEmpAppraisal();
                        Appraisal.EmpID = data.EmpID;
                        Appraisal.Skills = Convert.ToDecimal(0.0);
                        Appraisal.Quality = Convert.ToDecimal(0.0);
                        Appraisal.Avialibility = Convert.ToDecimal(0.0);
                        Appraisal.Deadlines = Convert.ToDecimal(0.0);
                        Appraisal.Communication = Convert.ToDecimal(0.0);
                        Appraisal.Cooperation = Convert.ToDecimal(0.0);
                        Appraisal.ClientFeedback = Convert.ToDecimal(Point);
                        Appraisal.CreatedOn = DateTime.Now;
                        DC.tblEmpAppraisals.InsertOnSubmit(Appraisal);
                        DC.SubmitChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                int session = Convert.ToInt32(Session["ClientID"].ToString());
                string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                string MACAddress = GetMacAddress();
                AddErrorLog(ref ex, PageName, "Client", session, 0, MACAddress);
                ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Please Check your Internet Connection');", true);
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            txtEmail.Text = " ";
            txtEnquiry.Text = " ";
            txtName.Text = " ";
            txtOrgn.Text = " ";
            ddProduct.SelectedValue = " ";

        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}