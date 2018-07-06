using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    ServiceClient NotObject = new ServiceClient();

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
            if (Session["AdminID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindData();
            }

            var dc = new DataClassesDataContext();
            var Admin = (from ob in dc.tblAdmins
                         where ob.AdminID == Convert.ToInt32(Session["AdminID"])
                         select new
                         {
                             Uname = ob.FirstName + " " + ob.LastName
                         }).SingleOrDefault();
            int dayStatus = DateTime.Now.Hour;
            if (dayStatus > 0 && dayStatus <= 8)
            {
                litHeaderUserName.Text = "Good Night, " + Admin.Uname;
            }
            else if (dayStatus > 8 && dayStatus <= 12)
            {
                litHeaderUserName.Text = "Good Morning, " + Admin.Uname;
            }
            else if (dayStatus > 12 && dayStatus <= 17)
            {
                litHeaderUserName.Text = "Good Afternoon, " + Admin.Uname;
            }
            else if (dayStatus > 17 && dayStatus <= 20)
            {
                litHeaderUserName.Text = "Good Evening, " + Admin.Uname;
            }
            else
            {
                litHeaderUserName.Text = "Good Night, " + Admin.Uname;
            }
            lblDate.Text = DateTime.Now.Date.ToShortDateString();
            lblDay.Text = DateTime.Now.ToString("dddd"); ;
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
        }
    }

    private void BindData()
    {
        try
        {
            var dc = new DataClassesDataContext();
            var Admin = (from ob in dc.tblAdmins
                         where ob.AdminID == Convert.ToInt32(Session["AdminID"])
                         select new
                         {
                             Uname = ob.FirstName + " " + ob.LastName
                         }).SingleOrDefault();
            lblUsername.Text = Admin.Uname;

            var str = (from obj in dc.tblNotificationDetails
                       join obj2 in dc.tblNotifications
                       on obj.NotificationID equals obj2.NotificationID
                       where obj.PersonID == Convert.ToInt32(Session["AdminID"]) && obj.IsAdmin == true
                       select obj2);

            rptNotify.DataSource = str;
            rptNotify.DataBind();


            int UserCnt = dc.tblClients.Count(ob => ob.IsActive == true);
            lblPNewUser.Text = UserCnt.ToString();
            lbluser.Text = UserCnt.ToString();

            int ordcnt = dc.tblPostProjects.Count();
            lblNewOrder.Text = ordcnt.ToString();
            lblorder.Text = ordcnt.ToString();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
        }
    }

    protected void lnkNewAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminReg.aspx");
    }

    protected void lnkNewEmp_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeReg.aspx");
    }

    protected void lnkNewClient_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClientReg.aspx");
    }

    protected void lnkViewAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminGrid.aspx");
    }

    protected void lnkViewEmp_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmpGrid.aspx");
    }

    protected void lnkViewPostProject_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewPostProject.aspx");
    }

    protected void lnkAddCatLang_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddData.aspx");
    }

    protected void lnkAddSkill_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddSkill.aspx");
    }

    protected void lnkAddProject_Click(object sender, EventArgs e)
    {
        Response.Redirect("Project.aspx");
    }

    protected void lnkViewProject_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewProject.aspx");
    }

    protected void lnkViewInquiry_Click(object sender, EventArgs e)
    {
        Response.Redirect("Inquiry.aspx");
    }

    protected void lnkTrackProject_Click(object sender, EventArgs e)
    {
        Response.Redirect("TrackProject.aspx");
    }

    protected void lnkCMSPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("CMSPage.aspx");
    }


    protected void lnkChPwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePwd.aspx");
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session["AdminID"] = null;
        Response.Redirect("Login.aspx");
    }


    protected void lnkVerifyEmp_Click(object sender, EventArgs e)
    {
        Response.Redirect("VerifyEmployee.aspx");
    }

    protected void lnkViewClient_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClientGrid.aspx");
    }

    protected void lnkViewFeedBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewFeedBack.aspx");
    }

    protected void lnkAssignProject_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssignProject.aspx");
    }


    protected void ViewAppraisal_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewAppraisal.aspx");
    }
}
