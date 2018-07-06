using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeeAppraisalWeb_ClientDashbord : System.Web.UI.Page
{
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
        ((LinkButton)Master.FindControl("lnkDB")).Visible = false;
            var DC = new DataClassesDataContext();
            int cntProjectData = (from obj in DC.tblProjects
                                  where obj.ManagerID == Convert.ToInt32(Session["EmpID"]) && (obj.IsComplete == false || obj.IsComplete == null)
                                  select obj).Count();
            if (cntProjectData > 0)
            {
                ltrProject.Text = cntProjectData + " Projects";
                //tblProject ProjectData = (from obj in DC.tblProjects
                //                          where obj.ManagerID == Convert.ToInt32(Session["EmpID"]) && (obj.IsComplete == false || obj.IsComplete == null)
                //                          select obj).Single();
                //ltrProjectName.Text = ProjectData.Title;
                //ltrProjectDesc.Text = ProjectData.Description;
                //hdnProject.Value = ProjectData.ProjectID.ToString();
                divProject.Visible = true;
                divProjectStatus.Visible = false;
            }
            else
            {
                lnkProject.Enabled = false;
                divProject.Visible = false;
                divProjectStatus.Visible = true;
            }
            int cntModuleData = (from obj in DC.tblProjects
                                 join obj1 in DC.tblModules
                                 on obj.ProjectID equals obj1.ProjectID
                                 join obj2 in DC.tblTeamModules
                                 on obj1.ModuleID equals obj2.ModuleID
                                 orderby obj.ProjectID ascending
                                 where obj1.State != 4 && obj2.EmpID == Convert.ToInt32(Session["EmpID"])
                                 select obj).Count();
            if (cntModuleData > 0)
            {
                ltrModule.Text = cntModuleData + " Projects";
                //tblProject ModuleData = (from obj in DC.tblProjects
                //                         join obj1 in DC.tblModules
                //                         on obj.ProjectID equals obj1.ProjectID
                //                         join obj2 in DC.tblTeamModules
                //                         on obj1.ModuleID equals obj2.ModuleID
                //                         orderby obj.ProjectID ascending
                //                         where obj1.State != 4 && obj2.EmpID == Convert.ToInt32(Session["EmpID"])
                //                         select obj).First();
                //ltrModuleName.Text = ModuleData.Title;
                //ltrModuleDesc.Text = ModuleData.Description;
                //hdnModule.Value = ModuleData.ProjectID.ToString();
                divModule.Visible = true;
                divModuleStatus.Visible = false;
            }
            else
            {
                lnkModule.Enabled = false;
                divModule.Visible = false;
                divModuleStatus.Visible = true;
            }
            int cntTotalTask = (from obj in DC.tblTasks
                                join obj2 in DC.tblTeamMembers
                                on obj.TaskID equals obj2.TaskID
                                where obj2.EmpID == Convert.ToInt32(Session["EmpID"]) && obj.TaskID == obj2.TaskID && obj.State != 4 && (obj.IsActive == true || obj.IsActive == null)
                                select obj).Count();
            if (cntTotalTask > 0)
            {
                ltrTask.Text = cntTotalTask + " Tasks";
            }
            else
            {
                lnkTask.Enabled = false;
                ltrTask.Text = "No Task For You.";
            }
            int cnt = (from ob in DC.tblEmpAppraisals
                       where ob.EmpID == Convert.ToInt32(Session["EmpID"])
                       select ob).Count();

            if (cnt > 0)
            {
                var Data2 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmpID"]));
                divSkillPoint.Style.Add("width", Data2.Skills.ToString() + "%");

                var Data3 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmpID"]));
                divQualityPoint.Style.Add("width", Data3.Quality.ToString() + "%");

                var Data4 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmpID"]));
                divAvialabilityPoint.Style.Add("width", Data4.Avialibility.ToString() + "%");

                var Data5 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmpID"]));
                divCooperationPoint.Style.Add("width", Data5.Cooperation.ToString() + "%");

                var Data6 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmpID"]));
                divCommunicationPoint.Style.Add("width", Data6.Communication.ToString() + "%");

                //var Data7 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmpID"]));
                //divClientFeedbackPoint.Style.Add("width", Data7.ClientFeedback.ToString() + "%");
            }
            IQueryable<tblNotification> str = (from obj in DC.tblNotificationDetails
                                               join obj2 in DC.tblNotifications
                                               on obj.NotificationID equals obj2.NotificationID
                                               where obj.PersonID == Convert.ToInt32(Session["EmpID"]) && (obj.IsAdmin == false || obj.IsAdmin == null)
                                               select obj2);

            rptNotification.DataSource = str;
            rptNotification.DataBind();
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

    protected void lnkProject_Click(object sender, EventArgs e)
    {
        try
        {
            Session["PersonType"] = "ProjectManager";
            ltrPersonType.Text = "Project Manager";
            divMaster.Visible = false;
            divSub.Visible = true;
            var DC = new DataClassesDataContext();
            IQueryable<tblProject> ProjectData = from obj in DC.tblProjects
                                                 where obj.ManagerID == Convert.ToInt32(Session["EmpID"]) && (obj.IsComplete == false || obj.IsComplete == null)
                                                 select obj;
            rptProject.DataSource = ProjectData;
            rptProject.DataBind();
            foreach (RepeaterItem item in rptProject.Items)
            {
                HiddenField hdnCategoryID = (HiddenField)item.FindControl("hdnCategoryID");
                HiddenField hdnLanguageID = (HiddenField)item.FindControl("hdnLanguageID");
                Literal ltrCategoryName = (Literal)item.FindControl("ltrCategoryName");
                Literal ltrLanguageName = (Literal)item.FindControl("ltrLanguageName");
                Literal ltrProjectStatus = (Literal)item.FindControl("ltrProjectStatus");
                Literal ltrAssignDate = (Literal)item.FindControl("ltrAssignDate");
                Literal ltrDeadlineDate = (Literal)item.FindControl("ltrDeadlineDate");
                ltrCategoryName.Text = (from obj in DC.tblCategories
                                        where obj.CategoryID == Convert.ToInt32(hdnCategoryID.Value)
                                        select obj.CategoryName).Single();
                int cntLan = (from obj in DC.tblLanguages
                              where obj.LanguageID == Convert.ToInt32(hdnLanguageID.Value)
                              select obj.LanguageName).Count();
                if (cntLan > 0)
                {
                    ltrLanguageName.Text = (from obj in DC.tblLanguages
                                            where obj.LanguageID == Convert.ToInt32(hdnLanguageID.Value)
                                            select obj.LanguageName).Single();
                }
                else
                {
                    ltrLanguageName.Text = "---";
                }
                TimeSpan Time = Convert.ToDateTime(ltrDeadlineDate.Text) - DateTime.Now;
                if (Convert.ToInt32(Time.TotalDays) > 0)
                {
                    ltrProjectStatus.Text = Convert.ToInt32(Time.TotalDays).ToString() + " Days Left";
                }
                else
                {
                    ltrProjectStatus.Text = "Completed";
                }
            }
            //Session["ProjectID"] = hdnProject.Value;
            //Response.Redirect("ProjectMaster.aspx");
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

    protected void lnkModule_Click(object sender, EventArgs e)
    {
        try
        {
            Session["PersonType"] = "TeamLeader";
            ltrPersonType.Text = "Team Leader";
            divSub.Visible = true;
            divMaster.Visible = false;
            var DC = new DataClassesDataContext();
            IQueryable<tblProject> ProjectData = (from obj in DC.tblProjects
                                                  join obj1 in DC.tblModules
                                                  on obj.ProjectID equals obj1.ProjectID
                                                  join obj2 in DC.tblTeamModules
                                                  on obj1.ModuleID equals obj2.ModuleID
                                                  orderby obj.ProjectID ascending
                                                  where obj1.State != 4 && obj2.EmpID == Convert.ToInt32(Session["EmpID"])
                                                  select obj).Distinct();
            rptProject.DataSource = ProjectData;
            rptProject.DataBind();
            foreach (RepeaterItem item in rptProject.Items)
            {
                HiddenField hdnCategoryID = (HiddenField)item.FindControl("hdnCategoryID");
                HiddenField hdnLanguageID = (HiddenField)item.FindControl("hdnLanguageID");
                Literal ltrCategoryName = (Literal)item.FindControl("ltrCategoryName");
                Literal ltrLanguageName = (Literal)item.FindControl("ltrLanguageName");
                Literal ltrProjectStatus = (Literal)item.FindControl("ltrProjectStatus");
                Literal ltrAssignDate = (Literal)item.FindControl("ltrAssignDate");
                Literal ltrDeadlineDate = (Literal)item.FindControl("ltrDeadlineDate");
                ltrCategoryName.Text = (from obj in DC.tblCategories
                                        where obj.CategoryID == Convert.ToInt32(hdnCategoryID.Value)
                                        select obj.CategoryName).Single();
                int cntLan = (from obj in DC.tblLanguages
                              where obj.LanguageID == Convert.ToInt32(hdnLanguageID.Value)
                              select obj.LanguageName).Count();
                if (cntLan > 0)
                {
                    ltrLanguageName.Text = (from obj in DC.tblLanguages
                                            where obj.LanguageID == Convert.ToInt32(hdnLanguageID.Value)
                                            select obj.LanguageName).Single();
                }
                else
                {
                    ltrLanguageName.Text = "---";
                }
                TimeSpan Time = Convert.ToDateTime(ltrDeadlineDate.Text) - DateTime.Now;
                if (Convert.ToInt32(Time.TotalDays) > 0)
                {
                    ltrProjectStatus.Text = Convert.ToInt32(Time.TotalDays).ToString() + " Days Left";
                }
                else
                {
                    ltrProjectStatus.Text = "Completed";
                }
            }
            //Session["ProjectID"] = hdnModule.Value;
            //Response.Redirect("ProjectMaster.aspx");
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

    protected void lnkTask_Click(object sender, EventArgs e)
    {
        try
        {
            Session["PersonType"] = "Employee";
            Response.Redirect("ProjectMaster.aspx");
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

    protected void rptProject_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ViewProject")
            {
                //Session["PersonType"] = "ProjectManager";
                Session["ProjectID"] = e.CommandArgument;
                Response.Redirect("ProjectMaster.aspx");
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Dashboard.aspx");
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