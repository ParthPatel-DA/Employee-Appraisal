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

public partial class Services : System.Web.UI.Page
{
    ServiceClient ServiceObject = new ServiceClient();
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
        if (!IsPostBack)
        {
            try
            {
                BindData();
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

    private void BindData()
    {
        try
        {
            rptservice.DataSource = ServiceObject.Viewservice();
            rptservice.DataBind();
            foreach (RepeaterItem Item in rptservice.Items)
            {
                HiddenField hdn = (HiddenField)Item.FindControl("hdnCategory");
                Repeater rpt = (Repeater)Item.FindControl("rptSubservice");
                rpt.DataSource = ServiceObject.ViewSubservice(Convert.ToInt32(hdn.Value));
                rpt.DataBind();
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