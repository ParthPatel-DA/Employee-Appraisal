using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using EmployeeAppraisalServiceReference;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;

public partial class AdminReg : System.Web.UI.Page
{
    ServiceClient objAdmin = new ServiceClient();
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
            bool IsInsert = false;
            if (Session["AdminID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindData();
            }
            var DC = new DataClassesDataContext();
            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsInsert == IsInsert)
            {
                divPage.Visible = false;
                divError.Visible = true;
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

    private void BindData()
    {
        try
        {
            //var DC = new DataClassesDataContext();
            //var Admin = from Ob in DC.tblAdmins select Ob;
            objAdmin.AdminRegBindData();
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
    protected void btninsert_Click1(object sender, EventArgs e)
    {
        try
        {
            bool CheckEmail = objAdmin.EmailCkecking(txtEmailID.Text, "");
            if (CheckEmail == false)
            {
                errorEmail.Visible = true;
            }
            else
            {
                var DC = new DataClassesDataContext();
                string strPic = FileUpload1.FileName;
                var filename = "";
                if (FileUpload1.HasFile)
                {
                    var path = Server.MapPath("~/Admin/Upload");
                    DateTime date = DateTime.Now;
                    string strdate = date.ToString();

                    var charsToRemove = new string[] { "%", "-", ":", " ", "/" };
                    foreach (var c in charsToRemove)
                    {
                        strdate = strdate.Replace(c, string.Empty);
                        strPic = strPic.Replace(c, string.Empty);
                    }
                    filename = strdate + strPic;
                    FileUpload1.SaveAs(path + "/" + filename);
                }
                string FirstName = txtfnm.Text;
                string LastName = txtlnm.Text;
                string EmaiID = txtEmailID.Text;
                string Password = txtpass.Text;
                string ContactNo = txtcno.Text;
                string Image = filename;

                objAdmin.AdminRegistration(FirstName, LastName, EmaiID, Password, ContactNo, Image, Chkisinsert.Checked, Chkisupdate.Checked, Chkisdelete.Checked, Convert.ToInt32(Session["AdminID"]), Chkissupper.Checked);


                //EmailSend To Admin
                IList<string> vc;
                tblAdmin AdminID = (from obj in DC.tblAdmins
                                    orderby obj.AdminID descending
                                    select obj).First();
                tblAdmin Admin = ((from obj in DC.tblAdmins
                                   where obj.AdminID == AdminID.AdminID
                                   select obj).Single());
                DateTime now = DateTime.Now;
                MailMessage Msg = new MailMessage("trackmyworkindia@gmail.com", AdminID.EmailID);
                Msg.Subject = "Admin Registration";
                Msg.Body = "<html><head></head><body><table><tr><td>Your E-Mail :</td><td>" + AdminID.EmailID + "</td><br></tr><tr><td>Your password :</td><td>" + Decryptdata(Admin.Password) + "</td></tr></table></body></html>";
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
                vc = new string[] { Admin.Password };
                ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Successfully Submitted');window.location ='AdminReg.aspx'</script>");
                //Response.Redirect("AdminReg.aspx");
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

    protected void txtEmailID_TextChanged(object sender, EventArgs e)
    {
        try
        {
            bool CheckEmail = objAdmin.EmailCkecking(txtEmailID.Text, "");
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

    protected void btnreset_Click(object sender, EventArgs e)
    {
        try
        {
            //txtfnm.Text = "";
            //txtlnm.Text = "";
            //txtEmailID.Text = "";
            //txtpass.Text = "";
            //txtcno.Text = "";
            //Chkisinsert.Checked = false;
            //Chkisupdate.Checked = false;
            //Chkisdelete.Checked = false;
            //Chkissupper.Checked = false;
            Response.Redirect("AdminReg.aspx");
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
