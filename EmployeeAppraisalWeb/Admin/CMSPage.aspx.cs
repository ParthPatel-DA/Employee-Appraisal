using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class Admin_CMSPage : System.Web.UI.Page
{
    ServiceClient CMSObject = new ServiceClient();
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
            if (!IsPostBack)
            {
                ddCMSList.DataSource = CMSObject.CMSFillDD();
                ddCMSList.DataValueField = "CMSID";
                ddCMSList.DataTextField = "Title";
                ddCMSList.DataBind();
                ddCMSList.Items.Insert(0, new ListItem("Select CMS Page", ""));
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

    protected void ddCMSList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Panel1.Visible = false;
            btnSaveCMS.Visible = false;
            btnEditCMS.Visible = true;
            CMSObject.CMSFillDD();
            txtTitle.Text = ddCMSList.SelectedItem.Text;

            txtCkEditor.Text = CMSObject.CMSFillEdit(Convert.ToInt32(ddCMSList.SelectedValue));
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

    protected void txtTitle_TextChanged(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = false;
            var DC = new DataClassesDataContext();
            int cnt = (from ob in DC.tblCMs
                       where ob.Title == txtTitle.Text
                       select ob).Count();
            if (cnt > 0)
            {
                errorCMS.Visible = true;
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

    protected void btnSaveCMS_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            int cnt = (from ob in DC.tblCMs
                       where ob.Title == txtTitle.Text
                       select ob).Count();
            if (cnt > 0)
            {
                errorCMS.Visible = true;
            }
            else
            {
                //Session["AdminID"] = 1;
                CMSObject.CMSInsert(txtTitle.Text, txtCkEditor.Text, Convert.ToInt32(Session["AdminID"]));
                Response.Redirect("CMSPage.aspx");
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

    protected void btnEditCMS_Click(object sender, EventArgs e)
    {
        try
        {
            CMSObject.CMSEdit(txtTitle.Text, txtCkEditor.Text, Convert.ToInt32(ddCMSList.SelectedValue));
            Response.Redirect("CMSPage.aspx");
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