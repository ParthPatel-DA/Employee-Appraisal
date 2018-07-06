using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EmployeeAppraisalServiceReference;

public partial class ProjectMaster : System.Web.UI.Page
{
    ServiceClient ProjectObject = new ServiceClient();
    public class NewProject
    {
        public int ModuleID { set; get; }
        public int TaskID { set; get; }
        public string ModuleDesc { set; get; }
        public string TaskDesc { set; get; }
        public string TotalTask { set; get; }
    }

    static int cnt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpID"] == null)
        {
            Response.Redirect("ClientLogin.aspx");
        }
        if (!IsPostBack)
        {
            BindPersonType();
            BindData();
        }
    }

    private void BindPersonType()
    {
        if (Session["PersonType"] != null)
        {
            if (Session["PersonType"].ToString() == "ProjectManager")
            {
                lnkPersonType.Text = "Project Manager";
            }
            else if (Session["PersonType"].ToString() == "TeamLeader")
            {
                lnkPersonType.Text = "Team Leader";
            }
            else if (Session["PersonType"].ToString() == "Employee")
            {
                lnkPersonType.Text = "Employee";
            }
        }
        else
        {
            lnkPersonType.Text = "Select Person Type";
        }
        BindData();
    }

    private void BindData()
    {
        if (Session["PersonType"] != null)
        {
            if (Session["PersonType"].ToString() == "ProjectManager")
            {
                divSection1.Visible = true;
                divSection2.Visible = false;
                divAddModule.Visible = false;
                //Session["ProjectID"] = 3;
                IList<string> ProjectDetail = ProjectObject.GetProjectDetail(Convert.ToInt32(Session["ProjectID"]));
                hdnProjectID.Value = ProjectDetail[0];
                lblProjectName.Text = ProjectDetail[1];
                Session["ProjectName"] = ProjectDetail[1];

                rptNew.DataSource = ProjectObject.BindNewProject(Convert.ToInt32(Session["ProjectID"]));
                rptNew.DataBind();

                foreach (RepeaterItem Item in rptNew.Items)
                {
                    HiddenField ModuleID = (HiddenField)Item.FindControl("hdnModuleID");
                    LinkButton lnkNewTask = (LinkButton)Item.FindControl("LnkNewTask");
                    LinkButton LnkDelete = (LinkButton)Item.FindControl("LnkDelete");
                    if (Session["PersonType"].ToString() == "TeamLeader")
                    {
                        LnkDelete.Visible = false;
                    }
                    if (ModuleID.Value != "")
                    {
                        lnkNewTask.Text = ProjectObject.BindTotalTask(Convert.ToInt32(ModuleID.Value)).ToString();
                        if (lnkNewTask.Text == "0")
                        {
                            lnkNewTask.Visible = false;
                        }
                    }
                }

                var DC = new DataClassesDataContext();
                IQueryable<tblModule> ModuleData = from obj in DC.tblModules
                                                   where obj.ProjectID == Convert.ToInt32(Session["ProjectID"]) && obj.State == 2 && (obj.IsActive == true || obj.IsActive == null)
                                                   select obj;

                rptActive.DataSource = ModuleData;
                rptActive.DataBind();
                divActive.Attributes.Add("padding-top", "20px");

                foreach (RepeaterItem Item in rptActive.Items)
                {
                    HiddenField ModuleID = (HiddenField)Item.FindControl("hdnModuleID");
                    LinkButton lnkNewTask = (LinkButton)Item.FindControl("LnkNewTask");
                    LinkButton LnkDelete = (LinkButton)Item.FindControl("LnkDelete");
                    if (Session["PersonType"].ToString() == "TeamLeader")
                    {
                        LnkDelete.Visible = false;
                    }
                    if (ModuleID.Value != "")
                    {
                        lnkNewTask.Text = ProjectObject.BindTotalTask(Convert.ToInt32(ModuleID.Value)).ToString();
                        if (lnkNewTask.Text == "0")
                        {
                            lnkNewTask.Visible = false;
                        }
                    }
                }

                IQueryable<tblModule> ResolveModuleData = from obj in DC.tblModules
                                                          where obj.ProjectID == Convert.ToInt32(Session["ProjectID"]) && obj.State == 3 && (obj.IsActive == true || obj.IsActive == null)
                                                          select obj;

                rptResolve.DataSource = ResolveModuleData;
                rptResolve.DataBind();

                foreach (RepeaterItem Item in rptResolve.Items)
                {
                    HiddenField ModuleID = (HiddenField)Item.FindControl("hdnModuleID");
                    LinkButton lnkNewTask = (LinkButton)Item.FindControl("LnkNewTask");
                    LinkButton LnkDelete = (LinkButton)Item.FindControl("LnkDelete");
                    if (Session["PersonType"].ToString() == "TeamLeader")
                    {
                        LnkDelete.Visible = false;
                    }
                    if (ModuleID.Value != "")
                    {
                        lnkNewTask.Text = ProjectObject.BindTotalTask(Convert.ToInt32(ModuleID.Value)).ToString();
                        if (lnkNewTask.Text == "0")
                        {
                            lnkNewTask.Visible = false;
                        }
                    }
                }


                IQueryable<tblModule> CloseModuleData = from obj in DC.tblModules
                                                        where obj.ProjectID == Convert.ToInt32(Session["ProjectID"]) && obj.State == 4 && (obj.IsActive == true || obj.IsActive == null)
                                                        select obj;

                rptClose.DataSource = CloseModuleData;
                rptClose.DataBind();

                foreach (RepeaterItem Item in rptClose.Items)
                {
                    HiddenField ModuleID = (HiddenField)Item.FindControl("hdnModuleID");
                    LinkButton lnkNewTask = (LinkButton)Item.FindControl("LnkNewTask");
                    LinkButton LnkDelete = (LinkButton)Item.FindControl("LnkDelete");
                    if (Session["PersonType"].ToString() == "TeamLeader")
                    {
                        LnkDelete.Visible = false;
                    }
                    if (ModuleID.Value != "")
                    {
                        lnkNewTask.Text = ProjectObject.BindTotalTask(Convert.ToInt32(ModuleID.Value)).ToString();
                        if (lnkNewTask.Text == "0")
                        {
                            lnkNewTask.Visible = false;
                        }
                    }
                }




            }
            else if (Session["PersonType"].ToString() == "TeamLeader")
            {
                divSection1.Visible = true;
                divSection2.Visible = false;
                lnkAddModule.Visible = false;
                //Session["ProjectID"] = 2;
                IList<string> ProjectDetail = ProjectObject.GetProjectDetail(Convert.ToInt32(Session["ProjectID"]));
                hdnProjectID.Value = ProjectDetail[0];
                lblProjectName.Text = ProjectDetail[1];
                Session["ProjectName"] = ProjectDetail[1];

                var DC = new DataClassesDataContext();
                IQueryable<tblModule> ModuleData = (from obj in DC.tblModules
                                                    join obj1 in DC.tblTeamModules
                                                    on obj.ModuleID equals obj1.ModuleID
                                                    where obj.ModuleID == obj1.ModuleID && obj.State == 1 && (obj.IsActive == true || obj.IsActive == null) && obj.ProjectID == Convert.ToInt32(ProjectDetail[0])
                select obj);
                rptNew.DataSource = ModuleData;
                rptNew.DataBind();

                foreach (RepeaterItem Item in rptNew.Items)
                {
                    HiddenField ModuleID = (HiddenField)Item.FindControl("hdnModuleID");
                    LinkButton lnkNewTask = (LinkButton)Item.FindControl("LnkNewTask");
                    LinkButton LnkDelete = (LinkButton)Item.FindControl("LnkDelete");
                    if (Session["PersonType"].ToString() == "TeamLeader")
                    {
                        LnkDelete.Visible = false;
                    }
                    if (ModuleID.Value != "")
                    {
                        lnkNewTask.Text = ProjectObject.BindTotalTask(Convert.ToInt32(ModuleID.Value)).ToString();
                        if (lnkNewTask.Text == "0")
                        {
                            lnkNewTask.Visible = false;
                        }
                    }
                }

                IQueryable<tblModule> ActiveModuleData = (from obj in DC.tblModules
                                                          join obj1 in DC.tblTeamModules
                                                          on obj.ModuleID equals obj1.ModuleID
                                                          where obj.ModuleID == obj1.ModuleID && obj.State == 2 && (obj.IsActive == true || obj.IsActive == null) && obj.ProjectID == Convert.ToInt32(ProjectDetail[0])
                                                          select obj);
                rptActive.DataSource = ActiveModuleData;
                rptActive.DataBind();
                divActive.Attributes.Add("padding-top", "0px");

                foreach (RepeaterItem Item in rptActive.Items)
                {
                    HiddenField ModuleID = (HiddenField)Item.FindControl("hdnModuleID");
                    LinkButton lnkNewTask = (LinkButton)Item.FindControl("LnkNewTask");
                    LinkButton LnkDelete = (LinkButton)Item.FindControl("LnkDelete");
                    if (Session["PersonType"].ToString() == "TeamLeader")
                    {
                        LnkDelete.Visible = false;
                    }
                    if (ModuleID.Value != "")
                    {
                        lnkNewTask.Text = ProjectObject.BindTotalTask(Convert.ToInt32(ModuleID.Value)).ToString();
                        if (lnkNewTask.Text == "0")
                        {
                            lnkNewTask.Visible = false;
                        }
                    }
                }

                IQueryable<tblModule> ResolveModuleData = (from obj in DC.tblModules
                                                           join obj1 in DC.tblTeamModules
                                                           on obj.ModuleID equals obj1.ModuleID
                                                           where obj.ModuleID == obj1.ModuleID && obj.State == 3 && (obj.IsActive == true || obj.IsActive == null) && obj.ProjectID == Convert.ToInt32(ProjectDetail[0])
                                                           select obj);
                rptResolve.DataSource = ResolveModuleData;
                rptResolve.DataBind();
                divResolve.Attributes.Add("padding-top", "0px");

                foreach (RepeaterItem Item in rptResolve.Items)
                {
                    HiddenField ModuleID = (HiddenField)Item.FindControl("hdnModuleID");
                    LinkButton lnkNewTask = (LinkButton)Item.FindControl("LnkNewTask");
                    LinkButton LnkDelete = (LinkButton)Item.FindControl("LnkDelete");
                    if (Session["PersonType"].ToString() == "TeamLeader")
                    {
                        LnkDelete.Visible = false;
                    }
                    if (ModuleID.Value != "")
                    {
                        lnkNewTask.Text = ProjectObject.BindTotalTask(Convert.ToInt32(ModuleID.Value)).ToString();
                        if (lnkNewTask.Text == "0")
                        {
                            lnkNewTask.Visible = false;
                        }
                    }
                }

                IQueryable<tblModule> CloseModuleData = (from obj in DC.tblModules
                                                         join obj1 in DC.tblTeamModules
                                                         on obj.ModuleID equals obj1.ModuleID
                                                         where obj.ModuleID == obj1.ModuleID && obj.State == 4 && (obj.IsActive == true || obj.IsActive == null) && obj.ProjectID == Convert.ToInt32(ProjectDetail[0])
                                                         select obj);
                rptClose.DataSource = CloseModuleData;
                rptClose.DataBind();
                divClose.Attributes.Add("padding-top", "0px");

                foreach (RepeaterItem Item in rptClose.Items)
                {
                    HiddenField ModuleID = (HiddenField)Item.FindControl("hdnModuleID");
                    LinkButton lnkNewTask = (LinkButton)Item.FindControl("LnkNewTask");
                    LinkButton LnkDelete = (LinkButton)Item.FindControl("LnkDelete");
                    if (Session["PersonType"].ToString() == "TeamLeader")
                    {
                        LnkDelete.Visible = false;
                    }
                    if (ModuleID.Value != "")
                    {
                        lnkNewTask.Text = ProjectObject.BindTotalTask(Convert.ToInt32(ModuleID.Value)).ToString();
                        if (lnkNewTask.Text == "0")
                        {
                            lnkNewTask.Visible = false;
                        }
                    }
                }

            }
            else if (Session["PersonType"].ToString() == "Employee")
            {
                divSection1.Visible = false;
                divSection2.Visible = true;
                lnkAddModule.Visible = false;
                var DC = new DataClassesDataContext();
                var ActiveTaskData = from obj in DC.tblTasks
                                     join obj2 in DC.tblTeamMembers
                                     on obj.TaskID equals obj2.TaskID
                                     where obj2.EmpID == Convert.ToInt32(Session["EmpID"]) && obj.TaskID == obj2.TaskID && obj.State == 2 && (obj.IsActive == true || obj.IsActive == null)
                                     select obj;
                rptActiveEmp.DataSource = ActiveTaskData;
                rptActiveEmp.DataBind();

                var ResolveTaskData = from obj in DC.tblTasks
                                      join obj2 in DC.tblTeamMembers
                                      on obj.TaskID equals obj2.TaskID
                                      where obj2.EmpID == Convert.ToInt32(Session["EmpID"]) && obj.TaskID == obj2.TaskID && obj.State == 3 && (obj.IsActive == true || obj.IsActive == null)
                                      select obj;
                rptResolveEmp.DataSource = ResolveTaskData;
                rptResolveEmp.DataBind();

                var CloseTaskData = from obj in DC.tblTasks
                                    join obj2 in DC.tblTeamMembers
                                    on obj.TaskID equals obj2.TaskID
                                    where obj2.EmpID == Convert.ToInt32(Session["EmpID"]) && obj.TaskID == obj2.TaskID && obj.State == 4 && (obj.IsActive == true || obj.IsActive == null)
                                    select obj;
                rptCloseEmp.DataSource = CloseTaskData;
                rptCloseEmp.DataBind();

            }
        }
    }

    protected void LnkTask_Click(object sender, EventArgs e)
    {

    }

    protected void rptNew_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var DC = new DataClassesDataContext();
        int ID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "OpenPanelViewTask")
        {
            Panel pnl = (Panel)e.Item.FindControl("PanelAddTask");
            Repeater rpt = (Repeater)e.Item.FindControl("rptTask");
            HiddenField hdn = (HiddenField)e.Item.FindControl("hdnCnt");
            TextBox txtTask = (TextBox)e.Item.FindControl("txtAddTask");
            rpt.DataSource = ProjectObject.GetTaskList(Convert.ToInt32(e.CommandArgument));
            rpt.DataBind();

            if (hdn.Value == "0")
            {
                pnl.Visible = true;
                hdn.Value = "1";
            }
            else if (hdn.Value == "1")
            {
                pnl.Visible = false;
                hdn.Value = "0";
            }



        }
        else if (e.CommandName == "View")
        {
            Session["ModuleID"] = e.CommandArgument;
            Response.Redirect("ModuleDetail.aspx");
            //Response.Write(e.CommandArgument);
            //var Data = ProjectObject.BindProjectModule(Convert.ToInt32(e.CommandArgument));
            //lblProName.Text = Session["ProjectName"].ToString();
            //txtModuleName.Text = Data.Description;
            //foreach(RepeaterItem item in rptDetail.Items)
            //{
            //    Label lbl = (Label)item.FindControl("lblProjectName");
            //    lbl.Text = Session["ProjectName"].ToString();
            //}

            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
        }
        else if (e.CommandName == "EditModuleName")
        {
            TextBox txtModuleTitle = (TextBox)e.Item.FindControl("txtModuleTitle");
            Label lblModuleTitle = (Label)e.Item.FindControl("lblModuleTitle");
            HiddenField hdnModuleID = (HiddenField)e.Item.FindControl("hdnModuleID");
            if (txtModuleTitle.Text != lblModuleTitle.Text)
            {
                tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == Convert.ToInt32(hdnModuleID.Value));
                ModuleData.Title = txtModuleTitle.Text;
                DC.SubmitChanges();
                txtModuleTitle.Visible = false;
                lblModuleTitle.Visible = true;
            }
            else
            {
                txtModuleTitle.Visible = true;
                lblModuleTitle.Visible = false;
            }
            
        }
        else if (e.CommandName == "OpenPanelAddTask")
        {
            //hdnAddTaskModuleID.Value = e.CommandArgument.ToString();
            ViewState["myModuleID"] = e.CommandArgument;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);

        }
        else if(e.CommandName == "DeleteModule")
        {
            HiddenField hdnModuleID = (HiddenField)e.Item.FindControl("hdnModuleID");
            tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == Convert.ToInt32(hdnModuleID.Value));
            ModuleData.IsActive = false;
            DC.SubmitChanges();
        }
        
    }



    protected void rptDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "ClickImage")
        {

            //Image img = (Image)FindControl("imgTeamLeader");
            LinkButton lnk = (LinkButton)e.Item.FindControl("lnkbtnModuleAssign");
            //Label lbl = (Label)FindControl("lblTeamLeader");
            //DropDownList dd = (DropDownList)FindControl("ddTeamLeader");
            //img.Visible = false;
            //lbl.Visible = false;
            //dd.Visible = true;
            lnk.Visible = false;
        }
    }

    protected void lnkAddModule_Click(object sender, EventArgs e)
    {
        divAddModule.Visible = true;
        txtAddModuleName.Focus();
    }

    protected void txtAddModuleName_TextChanged(object sender, EventArgs e)
    {
        ProjectObject.AddModule(txtAddModuleName.Text, Convert.ToInt32(hdnProjectID.Value), Convert.ToInt32(Session["EmpID"]));
        var DC = new DataClassesDataContext();
        tblModule ModuleData = (from obj in DC.tblModules
                                orderby obj.ModuleID descending
                                select obj).First();
        tblTeam TeamData = new tblTeam();
        TeamData.ProjectID = Convert.ToInt32(Session["ProjectID"]);
        TeamData.Description = txtAddModuleName.Text;
        TeamData.CreatedOn = DateTime.Now;
        TeamData.CreatedBy = Convert.ToInt32(Session["EmpID"]);
        TeamData.ModuleID = ModuleData.ModuleID;
        DC.tblTeams.InsertOnSubmit(TeamData);
        DC.SubmitChanges();
        Response.Redirect("ProjectMaster.aspx");
    }

    protected void txtAddTask_TextChanged(object sender, EventArgs e)
    {
        Response.Redirect("ModuleDetail.aspx");
    }

    protected void btnAddTask_Click(object sender, EventArgs e)
    {
        //int id = Convert.ToInt32(hdnAddTaskModuleID.Value);
        ProjectObject.AddTask(Convert.ToInt32(ViewState["myModuleID"]), txtAddTask.Text, Convert.ToInt32(Session["EmpID"]));
        Response.Redirect("ProjectMaster.aspx");
    }

    protected void lnkPersonType_Click(object sender, EventArgs e)
    {

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModalPerson').modal({backdrop:'static', keyboard: false});", true);
    }

    protected void btnSelectPerson_Click(object sender, EventArgs e)
    {
        if (rdProjectManager.Checked)
        {
            Session["PersonType"] = "ProjectManager";
        }
        else if (rdTeamLeader.Checked)
        {
            Session["PersonType"] = "TeamLeader";
        }
        else if (rdEmployee.Checked)
        {
            Session["PersonType"] = "Employee";
        }
        BindPersonType();

    }

    protected void rptActive_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var DC = new DataClassesDataContext();
        int ID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "OpenPanelViewTask")
        {
            Panel pnl = (Panel)e.Item.FindControl("PanelAddTask");
            Repeater rpt = (Repeater)e.Item.FindControl("rptTask");
            HiddenField hdn = (HiddenField)e.Item.FindControl("hdnCnt");
            TextBox txtTask = (TextBox)e.Item.FindControl("txtAddTask");
            rpt.DataSource = ProjectObject.GetTaskList(Convert.ToInt32(e.CommandArgument));
            rpt.DataBind();

            if (hdn.Value == "0")
            {
                pnl.Visible = true;
                hdn.Value = "1";
            }
            else if (hdn.Value == "1")
            {
                pnl.Visible = false;
                hdn.Value = "0";
            }



        }
        else if (e.CommandName == "View")
        {
            Session["ModuleID"] = e.CommandArgument;
            Response.Redirect("ModuleDetail.aspx");
            //Response.Write(e.CommandArgument);
            //var Data = ProjectObject.BindProjectModule(Convert.ToInt32(e.CommandArgument));
            //lblProName.Text = Session["ProjectName"].ToString();
            //txtModuleName.Text = Data.Description;
            //foreach(RepeaterItem item in rptDetail.Items)
            //{
            //    Label lbl = (Label)item.FindControl("lblProjectName");
            //    lbl.Text = Session["ProjectName"].ToString();
            //}

            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
        }
        else if (e.CommandName == "EditModuleName")
        {
            TextBox txtModuleTitle = (TextBox)e.Item.FindControl("txtModuleTitle");
            Label lblModuleTitle = (Label)e.Item.FindControl("lblModuleTitle");
            HiddenField hdnModuleID = (HiddenField)e.Item.FindControl("hdnModuleID");
            if (txtModuleTitle.Text != lblModuleTitle.Text)
            {
                tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == Convert.ToInt32(hdnModuleID.Value));
                ModuleData.Title = txtModuleTitle.Text;
                DC.SubmitChanges();
                txtModuleTitle.Visible = false;
                lblModuleTitle.Visible = true;
            }
            else
            {
                txtModuleTitle.Visible = true;
                lblModuleTitle.Visible = false;
            }
        }
        else if (e.CommandName == "OpenPanelAddTask")
        {
            //hdnAddTaskModuleID.Value = e.CommandArgument.ToString();
            ViewState["myModuleID"] = e.CommandArgument;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);

        }
        else if (e.CommandName == "DeleteModule")
        {
            HiddenField hdnModuleID = (HiddenField)e.Item.FindControl("hdnModuleID");
            tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == Convert.ToInt32(hdnModuleID.Value));
            ModuleData.IsActive = false;
            DC.SubmitChanges();
        }
    }

    protected void rptClose_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var DC = new DataClassesDataContext();
        int ID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "OpenPanelViewTask")
        {
            Panel pnl = (Panel)e.Item.FindControl("PanelAddTask");
            Repeater rpt = (Repeater)e.Item.FindControl("rptTask");
            HiddenField hdn = (HiddenField)e.Item.FindControl("hdnCnt");
            TextBox txtTask = (TextBox)e.Item.FindControl("txtAddTask");
            rpt.DataSource = ProjectObject.GetTaskList(Convert.ToInt32(e.CommandArgument));
            rpt.DataBind();

            if (hdn.Value == "0")
            {
                pnl.Visible = true;
                hdn.Value = "1";
            }
            else if (hdn.Value == "1")
            {
                pnl.Visible = false;
                hdn.Value = "0";
            }



        }
        else if (e.CommandName == "View")
        {
            Session["ModuleID"] = e.CommandArgument;
            Response.Redirect("ModuleDetail.aspx");
            //Response.Write(e.CommandArgument);
            //var Data = ProjectObject.BindProjectModule(Convert.ToInt32(e.CommandArgument));
            //lblProName.Text = Session["ProjectName"].ToString();
            //txtModuleName.Text = Data.Description;
            //foreach(RepeaterItem item in rptDetail.Items)
            //{
            //    Label lbl = (Label)item.FindControl("lblProjectName");
            //    lbl.Text = Session["ProjectName"].ToString();
            //}

            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
        }
        else if (e.CommandName == "EditModuleName")
        {
            TextBox txtModuleTitle = (TextBox)e.Item.FindControl("txtModuleTitle");
            Label lblModuleTitle = (Label)e.Item.FindControl("lblModuleTitle");
            HiddenField hdnModuleID = (HiddenField)e.Item.FindControl("hdnModuleID");
            if (txtModuleTitle.Text != lblModuleTitle.Text)
            {
                tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == Convert.ToInt32(hdnModuleID.Value));
                ModuleData.Title = txtModuleTitle.Text;
                DC.SubmitChanges();
                txtModuleTitle.Visible = false;
                lblModuleTitle.Visible = true;
            }
            else
            {
                txtModuleTitle.Visible = true;
                lblModuleTitle.Visible = false;
            }
        }
        else if (e.CommandName == "OpenPanelAddTask")
        {
            //hdnAddTaskModuleID.Value = e.CommandArgument.ToString();
            ViewState["myModuleID"] = e.CommandArgument;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);

        }
        else if (e.CommandName == "DeleteModule")
        {
            HiddenField hdnModuleID = (HiddenField)e.Item.FindControl("hdnModuleID");
            tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == Convert.ToInt32(hdnModuleID.Value));
            ModuleData.IsActive = false;
            DC.SubmitChanges();
        }
    }

    protected void rptResolve_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var DC = new DataClassesDataContext();
        int ID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "OpenPanelViewTask")
        {
            Panel pnl = (Panel)e.Item.FindControl("PanelAddTask");
            Repeater rpt = (Repeater)e.Item.FindControl("rptTask");
            HiddenField hdn = (HiddenField)e.Item.FindControl("hdnCnt");
            TextBox txtTask = (TextBox)e.Item.FindControl("txtAddTask");
            rpt.DataSource = ProjectObject.GetTaskList(Convert.ToInt32(e.CommandArgument));
            rpt.DataBind();

            if (hdn.Value == "0")
            {
                pnl.Visible = true;
                hdn.Value = "1";
            }
            else if (hdn.Value == "1")
            {
                pnl.Visible = false;
                hdn.Value = "0";
            }



        }
        else if (e.CommandName == "View")
        {
            Session["ModuleID"] = e.CommandArgument;
            Response.Redirect("ModuleDetail.aspx");
            //Response.Write(e.CommandArgument);
            //var Data = ProjectObject.BindProjectModule(Convert.ToInt32(e.CommandArgument));
            //lblProName.Text = Session["ProjectName"].ToString();
            //txtModuleName.Text = Data.Description;
            //foreach(RepeaterItem item in rptDetail.Items)
            //{
            //    Label lbl = (Label)item.FindControl("lblProjectName");
            //    lbl.Text = Session["ProjectName"].ToString();
            //}

            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
        }
        else if (e.CommandName == "EditModuleName")
        {
            TextBox txtModuleTitle = (TextBox)e.Item.FindControl("txtModuleTitle");
            Label lblModuleTitle = (Label)e.Item.FindControl("lblModuleTitle");
            HiddenField hdnModuleID = (HiddenField)e.Item.FindControl("hdnModuleID");
            if (txtModuleTitle.Text != lblModuleTitle.Text)
            {
                tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == Convert.ToInt32(hdnModuleID.Value));
                ModuleData.Title = txtModuleTitle.Text;
                DC.SubmitChanges();
                txtModuleTitle.Visible = false;
                lblModuleTitle.Visible = true;
            }
            else
            {
                txtModuleTitle.Visible = true;
                lblModuleTitle.Visible = false;
            }
        }
        else if (e.CommandName == "OpenPanelAddTask")
        {
            //hdnAddTaskModuleID.Value = e.CommandArgument.ToString();
            ViewState["myModuleID"] = e.CommandArgument;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);

        }
        else if (e.CommandName == "DeleteModule")
        {
            HiddenField hdnModuleID = (HiddenField)e.Item.FindControl("hdnModuleID");
            tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == Convert.ToInt32(hdnModuleID.Value));
            ModuleData.IsActive = false;
            DC.SubmitChanges();
        }
    }

    protected void rptActiveEmp_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            Session["TaskID"] = e.CommandArgument;
            Response.Redirect("TaskDetail.aspx");
        }
    }

    protected void rptTask_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var DC = new DataClassesDataContext();
        if (e.CommandName == "View")
        {
            Session["TaskID"] = e.CommandArgument;
            Response.Redirect("TaskDetail.aspx");
        }
        else if(e.CommandName == "Delete")
        {
            tblTask TaskData = DC.tblTasks.Single(ob => ob.TaskID == Convert.ToInt32(e.CommandArgument));
            TaskData.IsActive = false;
            DC.SubmitChanges();
        }
    }
}