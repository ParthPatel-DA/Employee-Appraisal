using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EmployeeAppraisalServiceReference;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;

public partial class PostProject : System.Web.UI.Page
{
    ServiceClient objPostOroject = new ServiceClient();
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
            PanelUser.Visible = true;

            if (!IsPostBack)
            {
                fillDrop();
            }
            if (Session["ClientID"] != null)
            {
                PanelUser.Visible = false;
                PanelProDes.Visible = true;
                PanelChoice.Visible = false;
                PanelInquiry.Visible = false;
                Session.Remove("PostProject");
                Session.Remove("PostProjectReg");

                //if (Session["PostProject"] != null)
                //{
                //    if (Session["PostProject"].ToString() == "True")
                //    {
                //        PanelUser.Visible = false;
                //        PanelProDes.Visible = true;
                //        PanelChoice.Visible = false;
                //        PanelInquiry.Visible = false;
                //        Session.Remove("PostProject");
                //    }
                //}
                //else if (Session["PostProjectReg"] != null)
                //{
                //    if (Session["PostProjectReg"].ToString() == "True")
                //    {
                //        PanelUser.Visible = false;
                //        PanelProDes.Visible = true;
                //        PanelChoice.Visible = false;
                //        PanelInquiry.Visible = false;
                //        Session.Remove("PostProjectReg");
                //    }
                //}
                //else
                //{
                //    PanelProDes.Visible = false;
                //    PanelChoice.Visible = false;
                //    PanelInquiry.Visible = false;
                //}
            }
            else
            {
                PanelUser.Visible = true;
                PanelProDes.Visible = false;
                PanelInquiry.Visible = false;
                PanelChoice.Visible = false;
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

    public void fillDrop()
    {
        try
        {
            ddProCtg.DataSource = objPostOroject.GetCatDrop();
            ddProCtg.DataValueField = "CategoryID";
            ddProCtg.DataTextField = "categoryName";
            ddProCtg.DataBind();
            ddProCtg.Items.Insert(0, new ListItem("Select a Category of Work", " "));
            ddProCtg.Items.Add(new ListItem("Others", "-1"));
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

    protected void lnkUser_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ClientID"] != null)
            {
                PanelProDes.Visible = true;
                PanelUser.Visible = false;
                PanelInquiry.Visible = false;
                PanelChoice.Visible = false;
            }
            else
            {
                Session["PostProject"] = "True";
                Response.Redirect("ClientLogin.aspx");
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

    protected void lnkNew_Click(object sender, EventArgs e)
    {
        try
        {
            PanelUser.Visible = false;
            PanelChoice.Visible = true;
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

    protected void lnkReg_Click(object sender, EventArgs e)
    {
        try
        {
            Session["PostProjectReg"] = "True";
            Response.Redirect("ClientLogin.aspx");
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

    protected void lnkInquiry_Click(object sender, EventArgs e)
    {
        try
        {
            PanelInquiry.Visible = true;
            PanelUser.Visible = false;
            PanelChoice.Visible = false;
            PanelProDes.Visible = false;
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
    protected void btnInqSubmit_Click(object sender, EventArgs e)
    {
        if (CheckForInternetConnection() == true)
        {
            try
            {
                objPostOroject.AddInquiry(txtFName.Text + " " + txtLName.Text, txtInqEmail.Text, txtInqMNO.Text, txtProjInq.Text);
                //ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Inquiry Successfully Submitted');window.location ='Default.aspx'</script>");

                //EmailSend To User
                var DC = new DataClassesDataContext();
                //IList<string> vc;
                tblInquiry InquiryID = (from obj in DC.tblInquiries
                                        orderby obj.InquiryID descending
                                        select obj).First();
                tblInquiry Client = (from obj in DC.tblInquiries
                                     where obj.EmailID == InquiryID.EmailID
                                     select obj).Single();
                DateTime now = DateTime.Now;
                MailMessage Msg = new MailMessage("trackmyworkindia@gmail.com", InquiryID.EmailID);
                Msg.Subject = "Inquiry";
                //Msg.Body = "<html><head></head><body><table><tr><td>Your E-Mail :</td><td>" + InquiryID.EmailID + "</td><br></tr><tr><p><td>" + "Your inquiry Successfull recieved and inquiry under process" + "</td></p></tr></table></body></html>";
                Msg.Body = "<!DOCTYPE html><html><head><title>Track My Work</title> <meta charset=\"utf - 8\"><meta name=\"viewport\" content=\"width = device - width, initial - scale = 1\"><meta http-equiv=\"X - UA - Compatible\" content=\"IE = edge\" /><style type=\"text / css\"> /* CLIENT-SPECIFIC STYLES */ body, table, td, a{-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;} /* Prevent WebKit and Windows mobile changing default text sizes */ table, td{mso-table-lspace: 0pt; mso-table-rspace: 0pt;} /* Remove spacing between tables in Outlook 2007 and up */ img{-ms-interpolation-mode: bicubic;} /* Allow smoother rendering of resized image in Internet Explorer */ /* RESET STYLES */ img{border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none;} table{border-collapse: collapse !important;} body{height: 100% !important; margin: 0 !important; padding: 0 !important; width: 100% !important;} /* iOS BLUE LINKS */ a[x-apple-data-detectors] { color: inherit !important; text-decoration: none !important; font-size: inherit !important; font-family: inherit !important; font-weight: inherit !important; line-height: inherit !important; } /* MOBILE STYLES */ @media screen and (max-width: 525px) { /* ALLOWS FOR FLUID TABLES */ .wrapper { width: 100% !important; max-width: 100% !important; } /* ADJUSTS LAYOUT OF LOGO IMAGE */ .logo img { margin: 0 auto !important; } /* USE THESE CLASSES TO HIDE CONTENT ON MOBILE */ .mobile-hide { display: none !important; } .img-max { max-width: 100% !important; width: 100% !important; height: auto !important; } /* FULL-WIDTH TABLES */ .responsive-table { width: 100% !important; } /* UTILITY CLASSES FOR ADJUSTING PADDING ON MOBILE */ .padding { padding: 10px 5% 15px 5% !important; } .padding-meta { padding: 30px 5% 0px 5% !important; text-align: center; } .no-padding { padding: 0 !important; } .section-padding { padding: 50px 15px 50px 15px !important; } /* ADJUST BUTTONS ON MOBILE */ .mobile-button-container { margin: 0 auto; width: 100% !important; } .mobile-button { padding: 15px !important; border: 0 !important; font-size: 16px !important; display: block !important; } } /* ANDROID CENTER FIX */ div[style*=\"margin: 16px 0; \"] { margin: 0 !important; }</style></head><body style=\"margin: 0 !important; padding: 0 !important; \"><!-- HIDDEN PREHEADER TEXT --><div style=\"display: none; font - size: 1px; color: #fefefe; line-height: 1px; font-family: Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;\"> Entice the open with some amazing preheader text. Use a little mystery and get those subscribers to read through...</div><!-- HEADER --><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"> <tr> <td align=\"center\" style=\" background:#008bff;\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 500px;\" class=\"wrapper\"> <tr style=\" background:#008bff;\"> <td align=\"center\" valign=\"top\" style=\"padding: 15px 0;\" class=\"logo\"> <h1 style=\"color:white; background:#008bff; font-family:calibri; font-size:40px;\">Track My Work</h1> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td bgcolor=\"#ffffff\" align=\"center\" style=\"padding: 70px 15px 70px 15px;\" class=\"section-padding\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 500px;\" class=\"responsive-table\"> <tr> <td> <!-- HERO IMAGE --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td> <!-- COPY --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td align=\"center\" style=\"font-size: 25px; font-family: Helvetica, Arial, sans-serif; color: #333333; padding-top: 30px;\" class=\"padding\">Your Email id is</td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0 0 0; font-size: 16px; line-height: 25px; font-family: Helvetica, Arial, sans-serif; color: #666666;\" class=\"padding\">"+ InquiryID.EmailID +"</td> </tr> <tr> <td align=\"center\" style=\"font-size: 25px; font-family: Helvetica, Arial, sans-serif; color: #333333; padding-top: 30px;\" class=\"padding\">Your Inquiry Successfully Submitted</td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0 0 0; font-size: 16px; line-height: 25px; font-family: Helvetica, Arial, sans-serif; color: #666666;\" class=\"padding\"></td> </tr> </table> </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0px; background:#424242; color:white;\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <!-- UNSUBSCRIBE COPY --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"max-width: 500px;\" class=\"responsive-table\"> <tr> <td align=\"center\" style=\"font-size: 12px; line-height: 18px; font-family: Helvetica, Arial, sans-serif; color:white;\"> <b>Track My Work</b> by:- Renown Infosys <span style=\"font-family: Arial, sans-serif; font-size: 12px; color:white;\">&nbsp;&nbsp;</span> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr></table></body></html>";
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
                //vc = new string[] { Admin.Password };
                Response.Redirect("Default.aspx");
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
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            string strPic = FileContent.FileName;
            var Filename = "";
            if (FileContent.HasFile)
            {
                var path = Server.MapPath("ContentUpload");
                DateTime date = DateTime.Now;
                string strdate = date.ToString();

                var charsToRemove = new string[] { "%", "-", ":", " ", "/" };
                foreach (var c in charsToRemove)
                {
                    strdate = strdate.Replace(c, string.Empty);
                    strPic = strPic.Replace(c, string.Empty);
                }
                Filename = strdate + strPic;
                FileContent.SaveAs(path + "/" + Filename);
            }

            string CategoryID;

            if (ddProCtg.SelectedValue == "-1")
            {
                CategoryID = null;
            }
            else if (ddSubCategory.SelectedValue == "-1")
            {
                CategoryID = ddProCtg.SelectedValue;
            }
            else if (ddOtherCat.SelectedValue == "-1")
            {
                CategoryID = ddSubCategory.SelectedValue;
            }
            else
            {
                if (ddSubCategory.SelectedValue == null)
                {
                    CategoryID = ddProCtg.SelectedValue;
                }
                else if (ddOtherCat.SelectedValue == null)
                {
                    CategoryID = ddSubCategory.SelectedValue;
                }
                else
                {
                    CategoryID = ddOtherCat.SelectedValue;
                }
            }

            DateTime DeadLineDate = DateTime.Now.AddDays(Convert.ToInt32(txtProjectPlan.Text));
            string Date = Convert.ToDateTime(DeadLineDate).ToString("dddd, MMMM dd, yyyy h:mm:ss tt");
            objPostOroject.AddPostProject(Convert.ToInt32(Session["ClientID"]), CategoryID, txtTitle.Text, txtProDesc.Text, Filename, Convert.ToDateTime(Date), 1);
            ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Successfully Submitted');window.location ='Default.aspx'</script>");
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


    protected void btnVSubmit_Click(object sender, EventArgs e)
    {

    }


    protected void ddProCtg_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddProCtg.SelectedValue == "-1")
            {
                PanelProDes.Visible = true;
                ddSubCategory.Visible = false;
                ddOtherCat.Visible = false;
                PanelChoice.Visible = false;
                PanelUser.Visible = false;
                PanelInquiry.Visible = false;
                txtTitle.Focus();
            }
            else
            {
                var Category = objPostOroject.GetSubCategory(Convert.ToInt32(ddProCtg.SelectedValue)); ;

                if (objPostOroject.CountContentTrans() > 0)
                {
                    ddSubCategory.Visible = true;
                    txtProDesc.Attributes.Remove("placeholder");
                    txtProDesc.Attributes.Add("placeholder", "Description about from which language to another language");
                    ddSubCategory.DataSource = Category;
                    ddSubCategory.DataValueField = "CategoryID";
                    ddSubCategory.DataTextField = "categoryName";
                    ddSubCategory.DataBind();
                    ddSubCategory.Items.Insert(0, new ListItem("Select a Sub Category of Work", "0"));
                    if (ddProCtg.SelectedItem.Text == "Content Writing" || ddProCtg.SelectedItem.Text == "Content Translation")
                    {
                        ddSubCategory.Items.Add(new ListItem("Other", "-1"));
                    }
                    PanelUser.Visible = false;
                    PanelProDes.Visible = true;
                    PanelChoice.Visible = false;
                    PanelInquiry.Visible = false;
                }
                else
                {
                    ddSubCategory.DataSource = Category;
                    ddSubCategory.DataValueField = "CategoryID";
                    ddSubCategory.DataTextField = "CategoryName";
                    ddSubCategory.DataBind();
                    ddSubCategory.Items.Insert(0, new ListItem("Select a Sub Category of Work", "0"));
                    PanelUser.Visible = false;
                    PanelProDes.Visible = true;
                    PanelChoice.Visible = false;
                    PanelInquiry.Visible = false;
                    ddSubCategory.Visible = true;
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

    protected void ddSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var Category = objPostOroject.GetSubCategory(Convert.ToInt32(ddSubCategory.SelectedValue)); ;

            if (Category != null)
            {
                ddOtherCat.DataSource = Category;
                ddOtherCat.DataValueField = "CategoryID";
                ddOtherCat.DataTextField = "CategoryName";
                ddOtherCat.DataBind();
                ddOtherCat.Items.Insert(0, new ListItem("Select a Another Category of Work", "0"));
                if (ddSubCategory.SelectedItem.Text != "Mobile")
                {
                    ddOtherCat.Items.Add(new ListItem("Other", "-1"));
                }
                PanelInquiry.Visible = false;
                ddSubCategory.Visible = true;
                ddOtherCat.Visible = true;
                PanelUser.Visible = false;
                PanelProDes.Visible = true;
                PanelChoice.Visible = false;
            }
            else if (ddSubCategory.SelectedValue == "-1")
            {
                txtTitle.Focus();
                PanelInquiry.Visible = false;
                ddSubCategory.Visible = true;
                ddOtherCat.Visible = false;
                PanelUser.Visible = false;
                PanelProDes.Visible = true;
                PanelChoice.Visible = false;
            }
            else
            {
                txtTitle.Text = ddSubCategory.SelectedItem.Text;
                PanelInquiry.Visible = false;
                ddSubCategory.Visible = true;
                ddOtherCat.Visible = false;
                PanelUser.Visible = false;
                PanelProDes.Visible = true;
                PanelChoice.Visible = false;
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

    protected void ddOtherCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddOtherCat.SelectedValue == "-1")
            {
                txtTitle.Focus();
                PanelInquiry.Visible = false;
                ddSubCategory.Visible = true;
                ddOtherCat.Visible = true;
                PanelUser.Visible = false;
                PanelProDes.Visible = true;
                PanelChoice.Visible = false;
            }
            else
            {
                txtTitle.Text = ddOtherCat.SelectedItem.Text;
                PanelInquiry.Visible = false;
                ddSubCategory.Visible = true;
                ddOtherCat.Visible = true;
                PanelUser.Visible = false;
                PanelProDes.Visible = true;
                PanelChoice.Visible = false;
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
}