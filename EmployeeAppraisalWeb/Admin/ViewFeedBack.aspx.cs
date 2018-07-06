using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class Admin_ViewFeedBack : System.Web.UI.Page
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
            if (Session["AdminID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindFeedBack();
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

    private void BindFeedBack()
    {
        try
        {
            var DC = new DataClassesDataContext();

            //IsRead == False
            IQueryable<tblFeedback> Data = (from ob in DC.tblFeedbacks
                                            where ob.IsRead == null || ob.IsRead == false
                                            select ob);

            rptFeedBack.DataSource = Data;
            rptFeedBack.DataBind();
            foreach (RepeaterItem item in rptFeedBack.Items)
            {
                Literal ltrClient = (Literal)item.FindControl("ltrClientName");
                Literal ltrProject = (Literal)item.FindControl("ltrProjectName");

                //ClientName
                string ClientName = objFeedBack.GetClientNamePostedProject(Convert.ToInt32(ltrClient.Text));
                ltrClient.Text = ClientName;

                //ProjectName
                string ProjectName = (from obj in DC.tblProjects
                                      where obj.ProjectID == Convert.ToInt32(ltrProject.Text)
                                      select obj.Title).Single();
                ltrProject.Text = ProjectName;
            }

            //IsRead == True
            IQueryable<tblFeedback> DataRead = (from ob in DC.tblFeedbacks
                                                where ob.IsRead == true
                                                select ob);

            rptReadFeedBack.DataSource = DataRead;
            rptReadFeedBack.DataBind();
            foreach (RepeaterItem item in rptReadFeedBack.Items)
            {
                Literal ltrClient = (Literal)item.FindControl("ltrClientName");
                Literal ltrProject = (Literal)item.FindControl("ltrProjectName");

                //ClientName
                string ClientName = objFeedBack.GetClientNamePostedProject(Convert.ToInt32(ltrClient.Text));
                ltrClient.Text = ClientName;

                //ProjectName
                string ProjectName = (from obj in DC.tblProjects
                                      where obj.ProjectID == Convert.ToInt32(ltrProject.Text)
                                      select obj.Title).Single();
                ltrProject.Text = ProjectName;
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

    protected void rptFeedBack_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Read")
            {
                var DC = new DataClassesDataContext();
                tblFeedback result = (from u in DC.tblFeedbacks
                                      where u.FeedbackID == Convert.ToInt32(e.CommandArgument)
                                      select u).Single();
                if (result.IsRead == true)
                {
                    result.IsRead = false;
                }
                else
                {
                    result.IsRead = true;
                }
                DC.SubmitChanges();
            }
            BindFeedBack();
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
