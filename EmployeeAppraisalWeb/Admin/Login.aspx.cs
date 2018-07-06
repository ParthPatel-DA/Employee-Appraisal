using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class Admin_Adlogin : System.Web.UI.Page
{
    ServiceClient LoginObject = new ServiceClient();
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
            Panel2.Visible = false;
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            try
            {
                IList<int> Login = LoginObject.AdminLogin(txtmail.Text, txtpass.Text);
                int cnt = Login[0];

                if (cnt > 0)
                {
                    //ScriptManager.RegisterStartupScript(Page, GetType(), "Store_Data", "<script>Store_Data()</script>", false);
                    Session["AdminID"] = Login[1];
                    Response.Redirect("Dashboard.aspx");
                }
            }
            catch (Exception Ex)
            {
                mailer.Visible = true;
                palLogin.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkFogetPwd_Click(object sender, EventArgs e)
    {
        try
        {
            palLogin.Visible = false;
            Panel2.Visible = true;
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnGetCode_Click(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = true;
            IList<int> Data = LoginObject.SendCode(txtCodeEmail.Text);
            int cnt = Data[0];
            string vc = Data[1].ToString();

            try
            {
                if (cnt > 0)
                {
                    Session["VCode"] = vc;
                    Label1.Text = Session["VCode"].ToString();
                    btnGetCode.Visible = false;
                    Panel6.Visible = true;
                    errorEmailCode.Visible = false;
                }
                else
                {
                    errorEmailCode.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                errorEmailCode.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnCheking_Click(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = true;
            Panel6.Visible = true;
            if (Session["VCode"].ToString() == txtCode.Text)
            {
                Panel2.Visible = false;
                Panel8.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnsub_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtrpass.Text == txtrepass.Text)
            {
                string AdminID = LoginObject.ChangePwd(txtCodeEmail.Text, txtrpass.Text);

                if (AdminID == null)
                {

                }
                else
                {
                    Session["AdminID"] = AdminID;
                    Response.Redirect("EmpGrid.aspx");
                }
            }
            else
            {
                errorMissMatch.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}