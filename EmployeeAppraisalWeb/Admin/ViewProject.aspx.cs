using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class ProjectGrid : System.Web.UI.Page
{
    ServiceClient ViewProjectObject = new ServiceClient();
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
            rptProRunning.DataSource = ViewProjectObject.ViewProject();
            rptProRunning.DataBind();
            foreach (RepeaterItem Item in rptProRunning.Items)
            {
                //---------for Category show-------------

                string CategoryName = "---";
                HiddenField Category = (HiddenField)Item.FindControl("hidCategory");
                if (Category.Value != "")
                {
                    CategoryName = ViewProjectObject.ViewCategory(Convert.ToInt32(Category.Value));
                }
                Literal ltrCategory = (Literal)Item.FindControl("ltrCategory");
                ltrCategory.Text = CategoryName;

                //--------for Category show----------------

                //---------for Language show---------------

                string LanguageName = "---";
                HiddenField Language = (HiddenField)Item.FindControl("hidLanguage");
                if (Language.Value != "")
                {
                    LanguageName = ViewProjectObject.ViewLanguage(Convert.ToInt32(Language.Value));
                }
                Literal ltrLanguage = (Literal)Item.FindControl("ltrLanguage");
                ltrLanguage.Text = LanguageName;

                //---------for Language show----------------

                //---------for Client show------------------

                string ClientName = "---";
                HiddenField Client = (HiddenField)Item.FindControl("hidClient");
                if (Client.Value != "")
                {
                    ClientName = ViewProjectObject.ViewClient(Convert.ToInt32(Client.Value));
                }
                Literal ltrClient = (Literal)Item.FindControl("ltrClient");
                ltrClient.Text = ClientName;

                //---------for Client show------------------

                //---------for Maneger show------------------

                string ManagerName = "---";
                HiddenField Manager = (HiddenField)Item.FindControl("hidManager");
                if (Manager.Value != "")
                {
                    ManagerName = ViewProjectObject.ViewManager(Convert.ToInt32(Manager.Value));
                }
                Literal ltrManager = (Literal)Item.FindControl("ltrManager");
                ltrManager.Text = ManagerName;

                //---------for Manger show------------------

                //---------for Duration show------------------

                string Duration = "---";
                string PanddingDays = "---";
                HiddenField hdnCreatedOn = (HiddenField)Item.FindControl("hdnCreatedOn");
                HiddenField hdnAssignDay = (HiddenField)Item.FindControl("hdnAssignDay");
                HiddenField hdnDeadLine = (HiddenField)Item.FindControl("hdnDeadLine");
                if (hdnAssignDay.Value != "")
                {
                    TimeSpan Days = Convert.ToDateTime(hdnDeadLine.Value) - Convert.ToDateTime(hdnAssignDay.Value);
                    Duration = Convert.ToInt32(Days.TotalDays).ToString();
                    TimeSpan PanddingDay = Convert.ToDateTime(hdnDeadLine.Value) - DateTime.Now;
                    PanddingDays = Convert.ToInt32(PanddingDay.TotalDays).ToString();
                }
                else if (hdnAssignDay.Value == "")
                {
                    TimeSpan Days = Convert.ToDateTime(hdnDeadLine.Value) - Convert.ToDateTime(hdnCreatedOn.Value);
                    Duration = Convert.ToInt32(Days.TotalDays).ToString();
                }
                Literal ltrDuration = (Literal)Item.FindControl("ltrDuration");
                Literal ltrPanddingDays = (Literal)Item.FindControl("lblPanddingDays");
                ltrDuration.Text = Duration + " Days";
                ltrPanddingDays.Text = PanddingDays + " Days";

                //---------for Duration show------------------

            }


            reptprgpanding.DataSource = ViewProjectObject.ViewProjectPandding();
            reptprgpanding.DataBind();
            foreach (RepeaterItem Item in reptprgpanding.Items)
            {
                string CategoryName = "---";
                HiddenField Category = (HiddenField)Item.FindControl("hidCategory");
                if (Category.Value != "")
                {
                    CategoryName = ViewProjectObject.ViewCategory(Convert.ToInt32(Category.Value));
                }
                Literal ltrCategory = (Literal)Item.FindControl("ltrCategory");
                ltrCategory.Text = CategoryName;
                string ClientName = "---";
                HiddenField Client = (HiddenField)Item.FindControl("hidClient");
                if (Client.Value != "")
                {
                    ClientName = ViewProjectObject.ViewClient(Convert.ToInt32(Client.Value));
                }
                Literal ltrClient = (Literal)Item.FindControl("ltrClient");
                ltrClient.Text = ClientName;
                string Duration = "---";
                string PanddingDays = "---";
                HiddenField hdnCreatedOn = (HiddenField)Item.FindControl("hdnCreatedOn");
                HiddenField hdnAssignDay = (HiddenField)Item.FindControl("hdnAssignDay");
                HiddenField hdnDeadLine = (HiddenField)Item.FindControl("hdnDeadLine");
                if (hdnAssignDay.Value != "")
                {
                    TimeSpan Days = Convert.ToDateTime(hdnDeadLine.Value) - Convert.ToDateTime(hdnAssignDay.Value);
                    Duration = Convert.ToInt32(Days.TotalDays).ToString();
                    TimeSpan PanddingDay = Convert.ToDateTime(hdnDeadLine.Value) - DateTime.Now;
                    PanddingDays = Convert.ToInt32(PanddingDay.TotalDays).ToString();
                }
                else if (hdnAssignDay.Value == "")
                {
                    TimeSpan Days = Convert.ToDateTime(hdnDeadLine.Value) - Convert.ToDateTime(hdnCreatedOn.Value);
                    Duration = Convert.ToInt32(Days.TotalDays).ToString();
                }
                Literal ltrDuration = (Literal)Item.FindControl("ltrDuration");
                Literal ltrPanddingDays = (Literal)Item.FindControl("lblPanddingDays");
                ltrDuration.Text = Duration + " Days";
                ltrPanddingDays.Text = PanddingDays + " Days";

            }

            reptprjcomplete.DataSource = ViewProjectObject.ViewProjectComplete();
            reptprjcomplete.DataBind();
            foreach (RepeaterItem Item in reptprjcomplete.Items)
            {
                var DC = new DataClassesDataContext();
                string ManagerName = "---";
                HiddenField Manager = (HiddenField)Item.FindControl("hidManager");
                Literal ltrPoint = (Literal)Item.FindControl("ltrPoint");
                HiddenField hdnProjectID = (HiddenField)Item.FindControl("hdnProjectID");
                int cnt = DC.tblFeedbacks.Count(ob => ob.ProjectID == Convert.ToInt32(hdnProjectID.Value));
                if (cnt > 0)
                {
                    tblFeedback Point = DC.tblFeedbacks.Single(ob => ob.ProjectID == Convert.ToInt32(hdnProjectID.Value));
                    ltrPoint.Text = Convert.ToString(Point.FeedBackPoint);
                }
                else
                {
                    ltrPoint.Text = "---";
                }

                if (Manager.Value != "")
                {
                    ManagerName = ViewProjectObject.ViewManager(Convert.ToInt32(Manager.Value));
                }
                Literal ltrManager = (Literal)Item.FindControl("ltrManager");
                ltrManager.Text = ManagerName;

                string CategoryName = "---";
                HiddenField Category = (HiddenField)Item.FindControl("hidCategory");
                if (Category.Value != "")
                {
                    CategoryName = ViewProjectObject.ViewCategory(Convert.ToInt32(Category.Value));
                }
                Literal ltrCategory = (Literal)Item.FindControl("ltrCategory");
                ltrCategory.Text = CategoryName;
                string ClientName = "---";
                HiddenField Client = (HiddenField)Item.FindControl("hidClient");
                if (Client.Value != "")
                {
                    ClientName = ViewProjectObject.ViewClient(Convert.ToInt32(Client.Value));
                }
                Literal ltrClient = (Literal)Item.FindControl("ltrClient");
                ltrClient.Text = ClientName;
                string Duration = "---";
                string PanddingDays = "---";
                HiddenField hdnCreatedOn = (HiddenField)Item.FindControl("hdnCreatedOn");
                HiddenField hdnAssignDay = (HiddenField)Item.FindControl("hdnAssignDay");
                HiddenField hdnDeadLine = (HiddenField)Item.FindControl("hdnDeadLine");
                if (hdnAssignDay.Value != "")
                {
                    TimeSpan Days = Convert.ToDateTime(hdnDeadLine.Value) - Convert.ToDateTime(hdnAssignDay.Value);
                    Duration = Convert.ToInt32(Days.TotalDays).ToString();
                    TimeSpan PanddingDay = Convert.ToDateTime(hdnDeadLine.Value) - DateTime.Now;
                    PanddingDays = Convert.ToInt32(PanddingDay.TotalDays).ToString();
                }
                else if (hdnAssignDay.Value == "")
                {
                    TimeSpan Days = Convert.ToDateTime(hdnDeadLine.Value) - Convert.ToDateTime(hdnCreatedOn.Value);
                    Duration = Days.TotalDays.ToString();
                }
                Literal ltrDuration = (Literal)Item.FindControl("ltrDuration");
                Literal ltrPanddingDays = (Literal)Item.FindControl("lblPanddingDays");
                ltrDuration.Text = Convert.ToInt32(Duration) + " Days";
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

    protected void rptProRunning_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            ViewProjectObject.ProjectActive(ID, e.CommandName);
            BindData();

            if (e.CommandName == "Track")
            {
                Session["TrackProjectID"] = e.CommandArgument;
                Response.Redirect("TrackProject.aspx");
            }
            if (e.CommandName == "Modal")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
                ddProjetctManager.DataSource = ViewProjectObject.BindEmployee(Convert.ToInt32(e.CommandArgument));
                ddProjetctManager.DataTextField = "FirstName";
                ddProjetctManager.DataValueField = "EmpID";
                ddProjetctManager.DataBind();
                ddProjetctManager.Items.Insert(0, new ListItem("Select a Project Manager", " "));
                hdnProjectID.Value = e.CommandArgument.ToString();
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

    protected void reptprgpanding_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            int ProjectID = Convert.ToInt32(e.CommandArgument);
            string MID = ViewProjectObject.GetManager(ProjectID);
            if (MID != "0")
            {
                //Response.Redirect("Project.aspx");
                int ID = Convert.ToInt32(e.CommandArgument);
                ViewProjectObject.ProjectActive(ID, e.CommandName);
                BindData();
            }
            else
            {
                Response.Redirect("AssignProject.aspx");
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

    protected void btnAddSkill_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            //ProjectName
            tblProject ProjectName = (from ob in DC.tblProjects
                                      where ob.ProjectID == Convert.ToInt32(hdnProjectID.Value)
                                      select ob).Single();

            //NotificationCancel
            tblNotification NotificationCancel = new tblNotification();
            NotificationCancel.Title = "Assign Project Manager";
            NotificationCancel.Description = "You are cancelled Project Manager for" + " " + ProjectName.Title;
            NotificationCancel.CreatedOn = DateTime.Now;
            NotificationCancel.CreatedBy = Convert.ToInt32(Session["AdminID"]);
            DC.tblNotifications.InsertOnSubmit(NotificationCancel);
            DC.SubmitChanges();
            tblNotification NIDCancel = (from obID in DC.tblNotifications
                                         orderby obID.NotificationID descending
                                         select obID).First();

            tblNotificationDetail DetailCancel = new tblNotificationDetail();
            DetailCancel.NotificationID = NIDCancel.NotificationID;
            DetailCancel.PersonID = Convert.ToInt32(ProjectName.ManagerID);
            DetailCancel.IsAdmin = false;
            DetailCancel.IsRead = false;
            DetailCancel.IsNotify = false;
            DC.tblNotificationDetails.InsertOnSubmit(DetailCancel);
            DC.SubmitChanges();


            //Change Project Manager
            ViewProjectObject.AssignProject(Convert.ToInt32(hdnProjectID.Value), Convert.ToInt32(ddProjetctManager.SelectedValue), Convert.ToInt32(Session["AdminID"]));

            //Notification
            tblNotification Notification = new tblNotification();
            Notification.Title = "Project Manager Cancelling";
            Notification.Description = "You are selected Project Manager for" + " " + ProjectName.Title;
            Notification.CreatedOn = DateTime.Now;
            Notification.CreatedBy = Convert.ToInt32(Session["AdminID"]);
            DC.tblNotifications.InsertOnSubmit(Notification);
            DC.SubmitChanges();

            tblNotification NID = (from obID in DC.tblNotifications
                                   orderby obID.NotificationID descending
                                   select obID).First();

            tblNotificationDetail Detail = new tblNotificationDetail();
            Detail.NotificationID = NID.NotificationID;
            Detail.PersonID = Convert.ToInt32(ddProjetctManager.SelectedValue);
            Detail.IsAdmin = false;
            Detail.IsRead = false;
            Detail.IsNotify = false;
            DC.tblNotificationDetails.InsertOnSubmit(Detail);
            DC.SubmitChanges();
            Response.Redirect("ViewProject.aspx");
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

    protected void reptprjcomplete_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Download")
            {
                Response.Redirect("ProjectDetail.aspx");
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
}