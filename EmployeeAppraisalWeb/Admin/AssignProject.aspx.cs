using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class Admin_Project : System.Web.UI.Page
{
    ServiceClient ProjectObject = new ServiceClient();
    static int ProjectID, EmpID;
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
            var DC = new DataClassesDataContext();
            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsInsert == false)
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
            var DC = new DataClassesDataContext();
            //Skills
            IQueryable<tblSkill> Skill = from ob in DC.tblSkills
                                         select ob;
            rptSkill.DataSource = Skill;
            rptSkill.DataBind();

            //var strProject = from obj in DC.tblProjects
            //                 where obj.IsActive == false
            //                 select new
            //                 {
            //                     obj.ProjectID,
            //                     obj.Title
            //                 };
            rptProjectAss.DataSource = ProjectObject.BindProject();
            rptProjectAss.DataBind();
            foreach (RepeaterItem Item in rptProjectAss.Items)
            {
                CheckBox chk = (CheckBox)Item.FindControl("chkProjectAssign");
                Button btn = (Button)Item.FindControl("btnProjectAssign");
                if (chk.Text != "")
                {
                    int cnt = ProjectObject.CountProjectSkill(Convert.ToInt32(chk.Text));
                    if (cnt > 0)
                    {
                        chk.Visible = true;
                        btn.Visible = false;
                    }
                    else
                    {
                        chk.Visible = false;
                        btn.Visible = true;
                    }

                }
            }

            //rptSkill.DataSource = ProjectObject.BindProject();
            //rptSkill.DataBind();
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

    protected void rptProjectAss_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            //int ID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Skill")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
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

    protected void chkProjectAssign_OnCheckedChanged(object sender, EventArgs e)
    {
        try
        {
            RadioButton chk = (RadioButton)sender;
            if (chk.Checked)
            {
                rptEmployeeList.DataSource = ProjectObject.BindEmployee(Convert.ToInt32(chk.Text));
                rptEmployeeList.DataBind();
            }
            ProjectID = Convert.ToInt32(chk.Text);
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

    protected void btnAssignProject_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            foreach (RepeaterItem item in rptEmployeeList.Items)
            {
                RadioButton rd = (RadioButton)item.FindControl("rdEmployee");
                if (rd.Checked)
                {
                    EmpID = Convert.ToInt32(rd.Text);
                }
            }




            //Assign Project Manager
            bool acknow = ProjectObject.AssignProject(ProjectID, EmpID, Convert.ToInt32(Session["AdminID"]));
            //ProjectName
            tblProject ProjectName = (from ob in DC.tblProjects
                                      where ob.ProjectID == ProjectID
                                      select ob).Single();
            //Notification
            tblNotification Notification = new tblNotification();
            Notification.Title = "Assign Project Manager";
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
            Detail.PersonID = EmpID;
            Detail.IsAdmin = false;
            Detail.IsRead = false;
            Detail.IsNotify = false;
            DC.tblNotificationDetails.InsertOnSubmit(Detail);
            DC.SubmitChanges();



            Response.Redirect("ViewProject.aspx");
            //Response.Write(acknow);
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

    protected void rptEmployeeList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;

            RadioButton rdo = (RadioButton)e.Item.FindControl("rdEmployee");
            string script =
               "SetUniqueRadioButton('rptEmployeeList.*Employee',this)";
            rdo.Attributes.Add("onclick", script);
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
            foreach (RepeaterItem item in rptSkill.Items)
            {
                CheckBox chkSkill = (CheckBox)item.FindControl("chkSkill");
                if (chkSkill.Checked)
                {
                    tblProjectXSkill Skill = new tblProjectXSkill();
                    Skill.ProjectID = Convert.ToInt32(hdnProjectID.Value);
                    Skill.SkillID = Convert.ToInt32(chkSkill.Text);
                    Skill.CreatedOn = DateTime.Now;
                    Skill.CreatedBy = Convert.ToInt32(Session["AdminID"]);
                    DC.tblProjectXSkills.InsertOnSubmit(Skill);
                    DC.SubmitChanges();

                }
            }
            Response.Redirect("AssignProject.aspx");
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