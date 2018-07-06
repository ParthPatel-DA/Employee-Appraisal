using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class EmpChPass : System.Web.UI.Page
{
    ServiceClient ObjectEmployee = new ServiceClient();
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
            if (Session["EmpID"] == null)
            {
                Response.Redirect("ClientLogin.aspx");
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private string EncryptPass(string password)
    {
        string strmsg = string.Empty;
        byte[] encode = new byte[password.Length];
        encode = Encoding.UTF8.GetBytes(password);

        strmsg = Convert.ToBase64String(encode);

        return strmsg;
    }
    protected void txtCurPass_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            tblEmployee EmpPass = DC.tblEmployees.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmpID"]));

            if (EmpPass.Password != EncryptPass(txtCurPass.Text))
            {
                errorPassword.Text = "Invalid Current Password!!";
                errorPassword.Visible = true;
            }
            else
            {
                errorPassword.Visible = false;
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            tblEmployee EmpPass = DC.tblEmployees.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmpID"]));

            if (EmpPass.Password != EncryptPass(txtCurPass.Text))
            {
                errorPassword.Text = "Invalid Current Password!!";
                errorPassword.Visible = true;
            }
            else
            {
                errorPassword.Visible = false;
                if (txtNewPass.Text == txtComNewPass.Text)
                {
                    EmpPass.Password = EncryptPass(txtNewPass.Text);
                    DC.SubmitChanges();
                    ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Password Changed Successfully');window.location ='EmployeeProfile.aspx'</script>");
                }
                else
                {
                    errorPassword.Text = "New Password and Confirm doesn't Match!!";
                    errorPassword.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}