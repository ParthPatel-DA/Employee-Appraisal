using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var DC = new DataClassesDataContext();
            //Session["PersonType"] = "TeamLeader";
            if (Session["PersonType"].ToString() == "ProjectManager")
            {
                ltrPersonType.Text = "Project Manager";
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
            }
            else if(Session["PersonType"].ToString() == "TeamLeader")
            {
                ltrPersonType.Text = "Team Leader";
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
            }
        }
    }
    
    protected void rptProject_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "ViewProject")
        {
            //Session["PersonType"] = "ProjectManager";
            Session["ProjectID"] = e.CommandArgument;
            Response.Redirect("ProjectMaster.aspx");
        }
    }
}