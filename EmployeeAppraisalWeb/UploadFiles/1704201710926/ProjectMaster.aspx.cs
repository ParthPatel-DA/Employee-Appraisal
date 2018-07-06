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
        BindData();
    }

    private void BindData()
    {
        //var DC = new DataClassesDataContext();
        //var strNew = (from objModule in DC.tblModules
        //              join objTask in DC.tblTasks
        //              on objModule.ModuleID equals objTask.ModuleID
        //              where objModule.ProjectID == 1
        //              group objTask by objTask.ModuleID into grpProject
        //              //select grpProject
        //              select new
        //              {
        //                  ModuleName = (from obj in DC.tblModules where obj.ModuleID == grpProject.Key select obj.Description).Take(1).Single(),

        //                  TotalTask = grpProject.ToList().Count
        //              });

        //var strNew = from objModule in DC.tblModules
        //             join objTask in DC.tblTasks
        //             on objModule.ModuleID equals objTask.ModuleID
        //             where objModule.ProjectID == 1
        //             select new
        //             {
        //                 TotalTask = from objM in DC.tblModules
        //                             join objT in DC.tblTasks
        //                             on objM.ModuleID equals objT.ModuleID
        //                             where objM.ModuleID == objModule.ModuleID
        //                             group objT by objT.ModuleID into grp
        //                             select new
        //                             {
        //                                 Total = grp.ToList().Count
        //                             },
        //                 ModuleDesc = from objM in DC.tblModules
        //                              join objT in DC.tblTasks
        //                              on objM.ModuleID equals objT.ModuleID
        //                              where objM.ModuleID == objModule.ModuleID
        //                              group objT by objT.ModuleID into grp
        //                              select new
        //                              {

        //                              },
        //                 TaskDesc = objTask.Description,
        //                 objModule.ModuleID,
        //                 objTask.TaskID
        //             };
        //var NoTasks = (from mod in DC.tblModules
        //               join task in DC.tblTasks on mod.ModuleID equals task.ModuleID
        //               where mod.ProjectID == 1
        //               select task.TaskID).Count();
        //var TaskNames = (from mod in DC.tblModules
        //                 join task in DC.tblTasks on mod.ModuleID equals task.ModuleID
        //                 where mod.ProjectID == 1
        //                 select task);
        //var ModuleNames = (from mod in DC.tblModules
        //                   join task in DC.tblTasks on mod.ModuleID equals task.ModuleID
        //                   where mod.ProjectID == 1
        //                   select mod);

        //List<NewProject> lstNewProject = new List<NewProject>();
        //lstNewProject.Add();

        //foreach(var grp in strNew)
        //{
        //    foreach (var task in grp)
        //    {
        //        List<string> Tasks = new List<string>();
        //    }
        //}

        //DC.SubmitChanges();
        Session["ProjectID"] = 1;
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
            if (ModuleID.Value != "")
            {
                lnkNewTask.Text = ProjectObject.BindTotalTask(Convert.ToInt32(ModuleID.Value)).ToString();
            }
        }

    }

    protected void LnkTask_Click(object sender, EventArgs e)
    {

    }

    protected void LnkNewTask_Click(object sender, EventArgs e)
    {



    }

    protected void rptNew_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int ID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "OpenPanelAddTask")
        {
            Panel pnl = (Panel)e.Item.FindControl("PanelAddTask");
            Repeater rpt = (Repeater)e.Item.FindControl("rptTask");
            HiddenField hdn = (HiddenField)e.Item.FindControl("hdnCnt");
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
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
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
}