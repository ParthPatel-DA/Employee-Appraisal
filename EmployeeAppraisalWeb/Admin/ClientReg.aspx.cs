using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;

public partial class Admin_ClientReg : System.Web.UI.Page
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
            //Response.Write(Session["AdminID"]);
            if (Session["AdminID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            var DC = new DataClassesDataContext();
            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsUpdate == false)
            {
                divPage.Visible = false;
                divPage.Visible = true;
            }
            else if(AdminData.IsInsert == false)
            {
                divPage.Visible = false;
                divPage.Visible = true;
            }
            if (!IsPostBack)
            {
                BindData();
                FillCountryDropDown();
            }
            else
            {
                //txtPassword.Text = ViewState["txtPassword"].ToString();
            }

            if (Request.QueryString["InquiryID"] != null)
            {
                var dc = new DataClassesDataContext();
                tblInquiry Data = (from obj in dc.tblInquiries
                                   where obj.InquiryID == Convert.ToInt32(Request.QueryString["InquiryID"])
                                   select obj).Single();
                txtname.Text = Data.Name;
                txtCNO.Text = Data.ContactNo;
                txtEmail.Text = Data.EmailID;
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void FillCountryDropDown()
    {
        try
        {
            ddCountryName.DataSource = objClient.GetCountry();
            ddCountryName.DataValueField = "ID";
            ddCountryName.DataTextField = "Name";
            ddCountryName.DataBind();
            ddCountryName.Items.Insert(0, new ListItem("Select a Country", ""));
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void BindData()
    {
        try
        {
            objClient.ClientRegBindData();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    //Password Decrypt
    private string Decryptdata(string encryptpwd)
    {
        string decryptpwd = string.Empty;
        UTF8Encoding encodepwd = new UTF8Encoding();
        Decoder Decode = encodepwd.GetDecoder();
        byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
        int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        char[] decoded_char = new char[charCount];
        Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        decryptpwd = new String(decoded_char);
        return decryptpwd;
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
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        if (CheckForInternetConnection() == true)
        {


            try
            {
                bool CheckEmail = objClient.EmailCkecking(txtEmail.Text, "");
                if (CheckEmail == false)
                {
                    errorEmail.Visible = true;
                }
                else
                {
                    string Name = txtname.Text;
                    string ContactNo = txtCNO.Text;
                    string EmaiID = txtEmail.Text;
                    string Password = txtPassword.Text;
                    string CompanyName = txtComName.Text;
                    string WebsiteURL = txtComUrl.Text;
                    string Address = txtAddress.Text;
                    string Landmark = txtLandMark.Text;
                    int City = Convert.ToInt32(ddCityName.SelectedValue);
                    int Zipcode = Convert.ToInt32(txtZipCode.Text);
                    objClient.ClientRegistration(Name, EmaiID, Password, ContactNo, CompanyName, WebsiteURL, Address, Landmark, City, Zipcode, Convert.ToInt32(Session["AdminID"]));

                    //EmailSend To Client
                    var DC = new DataClassesDataContext();
                    IList<string> vc;
                    tblClient CID = (from obj in DC.tblClients
                                     orderby obj.ClientID descending
                                     select obj).First();
                    tblClient Client = ((from obj in DC.tblClients
                                         where obj.ClientID == CID.ClientID
                                         select obj).Single());
                    DateTime now = DateTime.Now;
                    MailMessage Msg = new MailMessage("trackmyworkindia@gmail.com", CID.EmailID);
                    Msg.Subject = "Client Registration";
                    //Msg.Body = "<html><head></head><body><table><tr><td>Your E-Mail :</td><td>" + CID.EmailID + "</td><br></tr><tr><td>Your password :</td><td>" + Decryptdata(Client.Password) + "</td></tr></table></body></html>";
                    Msg.Body = "<!DOCTYPE html><html><head><title>Track My Work</title> <meta charset=\"utf - 8\"><meta name=\"viewport\" content=\"width = device - width, initial - scale = 1\"><meta http-equiv=\"X - UA - Compatible\" content=\"IE = edge\" /><style type=\"text / css\"> /* CLIENT-SPECIFIC STYLES */ body, table, td, a{-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;} /* Prevent WebKit and Windows mobile changing default text sizes */ table, td{mso-table-lspace: 0pt; mso-table-rspace: 0pt;} /* Remove spacing between tables in Outlook 2007 and up */ img{-ms-interpolation-mode: bicubic;} /* Allow smoother rendering of resized image in Internet Explorer */ /* RESET STYLES */ img{border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none;} table{border-collapse: collapse !important;} body{height: 100% !important; margin: 0 !important; padding: 0 !important; width: 100% !important;} /* iOS BLUE LINKS */ a[x-apple-data-detectors] { color: inherit !important; text-decoration: none !important; font-size: inherit !important; font-family: inherit !important; font-weight: inherit !important; line-height: inherit !important; } /* MOBILE STYLES */ @media screen and (max-width: 525px) { /* ALLOWS FOR FLUID TABLES */ .wrapper { width: 100% !important; max-width: 100% !important; } /* ADJUSTS LAYOUT OF LOGO IMAGE */ .logo img { margin: 0 auto !important; } /* USE THESE CLASSES TO HIDE CONTENT ON MOBILE */ .mobile-hide { display: none !important; } .img-max { max-width: 100% !important; width: 100% !important; height: auto !important; } /* FULL-WIDTH TABLES */ .responsive-table { width: 100% !important; } /* UTILITY CLASSES FOR ADJUSTING PADDING ON MOBILE */ .padding { padding: 10px 5% 15px 5% !important; } .padding-meta { padding: 30px 5% 0px 5% !important; text-align: center; } .no-padding { padding: 0 !important; } .section-padding { padding: 50px 15px 50px 15px !important; } /* ADJUST BUTTONS ON MOBILE */ .mobile-button-container { margin: 0 auto; width: 100% !important; } .mobile-button { padding: 15px !important; border: 0 !important; font-size: 16px !important; display: block !important; } } /* ANDROID CENTER FIX */ div[style*=\"margin: 16px 0; \"] { margin: 0 !important; }</style></head><body style=\"margin: 0 !important; padding: 0 !important; \"><!-- HIDDEN PREHEADER TEXT --><div style=\"display: none; font - size: 1px; color: #fefefe; line-height: 1px; font-family: Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;\"> Entice the open with some amazing preheader text. Use a little mystery and get those subscribers to read through...</div><!-- HEADER --><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"> <tr> <td align=\"center\" style=\" background:#008bff;\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 500px;\" class=\"wrapper\"> <tr style=\" background:#008bff;\"> <td align=\"center\" valign=\"top\" style=\"padding: 15px 0;\" class=\"logo\"> <h1 style=\"color:white; background:#008bff; font-family:calibri; font-size:40px;\">Track My Work</h1> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td bgcolor=\"#ffffff\" align=\"center\" style=\"padding: 70px 15px 70px 15px;\" class=\"section-padding\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 500px;\" class=\"responsive-table\"> <tr> <td> <!-- HERO IMAGE --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td> <!-- COPY --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td align=\"center\" style=\"font-size: 25px; font-family: Helvetica, Arial, sans-serif; color: #333333; padding-top: 30px;\" class=\"padding\">Your Email id is</td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0 0 0; font-size: 16px; line-height: 25px; font-family: Helvetica, Arial, sans-serif; color: #666666;\" class=\"padding\">" + CID.EmailID + "</td> </tr> <tr> <td align=\"center\" style=\"font-size: 25px; font-family: Helvetica, Arial, sans-serif; color: #333333; padding-top: 30px;\" class=\"padding\">Your Password is</td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0 0 0; font-size: 16px; line-height: 25px; font-family: Helvetica, Arial, sans-serif; color: #666666;\" class=\"padding\">"+ Decryptdata(Client.Password) + "</td> </tr> </table> </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0px; background:#424242; color:white;\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <!-- UNSUBSCRIBE COPY --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"max-width: 500px;\" class=\"responsive-table\"> <tr> <td align=\"center\" style=\"font-size: 12px; line-height: 18px; font-family: Helvetica, Arial, sans-serif; color:white;\"> <b>Track My Work</b> by:- Renown Infosys <span style=\"font-family: Arial, sans-serif; font-size: 12px; color:white;\">&nbsp;&nbsp;</span> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr></table></body></html>";
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
                    vc = new string[] { Client.Password };

                    if (Request.QueryString["InquiryID"] != null)
                    {
                        tblInquiry data = (from ob in DC.tblInquiries
                                           where ob.InquiryID == Convert.ToInt32(Request.QueryString["InquiryID"])
                                           select ob).Single();
                        data.IsRead = true;
                        DC.SubmitChanges();

                        var ClientID = (from obj in DC.tblClients
                                        orderby obj.ClientID descending
                                        select obj.ClientID).First();
                        if (ClientID != 0)
                        {
                            Response.Redirect("Project.aspx?ClientInquiry=" + ClientID.ToString());
                        }
                    }
                    else
                    {
                        Response.Redirect("ClientReg.aspx");
                    }
                    ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Successfully Submitted');window.location ='ClientReg.aspx'</script>");
                }
            }
            catch (Exception ex)
            {
                int session = Convert.ToInt32(Session["AdminID"].ToString());
                string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                string MACAddress = GetMacAddress();
                AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
                ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Please Check your Internet Connection');", true);
        }
    }

    protected void ddCountryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddStateName.DataSource = objClient.GetState(Convert.ToInt32(ddCountryName.SelectedValue));
            ddStateName.DataValueField = "ID";
            ddStateName.DataTextField = "Name";
            ddStateName.DataBind();
            ddStateName.Items.Insert(0, new ListItem("Select a State", " "));
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void ddStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddCityName.DataSource = objClient.GetCity(Convert.ToInt32(ddStateName.SelectedValue));
            ddCityName.DataValueField = "ID";
            ddCityName.DataTextField = "Name";
            ddCityName.DataBind();
            ddCityName.Items.Insert(0, new ListItem("Select a City", " "));
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        try
        {
            bool CheckEmail = objClient.EmailCkecking(txtEmail.Text, "");
            if (CheckEmail == false)
            {
                errorEmail.Visible = true;
            }
            else
            {
                errorEmail.Visible = false;
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("clientReg.aspx");
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}