using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class Home : System.Web.UI.Page
{
    ServiceClient ViewServiceObject = new ServiceClient();
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
                int session = Convert.ToInt32(Session["ClientID"].ToString());
                string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                string MACAddress = GetMacAddress();
                AddErrorLog(ref ex, PageName, "Client", session, 0, MACAddress);
                ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
            }
        }
    }

    private void BindData()
    {
        try
        {
            rptViewOurServices.DataSource = ViewServiceObject.Viewservice();
            rptViewOurServices.DataBind();

            var dc = new DataClassesDataContext();
            int UserCnt = dc.tblClients.Count(ob => ob.IsActive == true);
            lblUserCount.Text = UserCnt.ToString();

            int ProCnt = dc.tblProjects.Count(ob => ob.IsActive == true);
            lblProjects.Text = ProCnt.ToString();

            int feedback = dc.tblFeedbacks.Count();
            lblfeedback.Text = feedback.ToString();

            int Services = dc.tblCategories.Count();
            lblServices.Text = Services.ToString();

            rptViewProject.DataSource = ViewServiceObject.ProjectStatus();
            rptViewProject.DataBind();
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

    protected void btnSubscribe_Click(object sender, EventArgs e)
    {
        try
        {
            bool CheckEmail = ViewServiceObject.SubscribeEmailCheck(txtSubEmail.Text);
            if (CheckEmail == false)
            {
                errorSubscribe.Text = "Email already Subscribed";
                errorSubscribe.Visible = true;
                PanelUnSubscribe.Visible = true;
                PanelSubscribe.Visible = false;
            }
            else
            {
                ViewServiceObject.Subscribe(txtSubEmail.Text);
                errorSubscribe.Text = "Your Email Subscribed Successfully..";
                errorSubscribe.Visible = true;
                txtSubEmail.Text = "";
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

    protected void txtSubEmail_TextChanged(object sender, EventArgs e)
    {
        try
        {
            bool CheckEmail = ViewServiceObject.SubscribeEmailCheck(txtSubEmail.Text);
            if (CheckEmail == false)
            {
                errorSubscribe.Text = "Email already Subscribed";
                errorSubscribe.Visible = true;
                PanelUnSubscribe.Visible = true;
                PanelSubscribe.Visible = false;
            }
            else
            {
                PanelUnSubscribe.Visible = false;
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

    protected void btnUnSubscribe_Click(object sender, EventArgs e)
    {
        try
        {
            bool CheckEmail = ViewServiceObject.SubscribeEmailCheck(txtSubEmail.Text);
            if (CheckEmail == true)
            {
                errorSubscribe.Text = "Email already Subscribed";
                errorSubscribe.Visible = true;
                PanelUnSubscribe.Visible = true;
                PanelSubscribe.Visible = false;
            }
            else
            {
                ViewServiceObject.UnSubscribe(txtSubEmail.Text);
                errorSubscribe.Text = "Your Email UnSubscribed Successfully..";
                errorSubscribe.Visible = true;
                txtSubEmail.Text = "";
                PanelUnSubscribe.Visible = false;
                PanelSubscribe.Visible = true;
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

    protected void lnkService_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Services.aspx");
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

    protected void rptViewProject_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ViewProject")
            {
                Session["ViewProjectID"] = e.CommandArgument;
                Response.Redirect("AboutProject.aspx");
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