using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;

public partial class ModuleDetail : System.Web.UI.Page
{
    ServiceClient ProjectObject = new ServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        var DC = new DataClassesDataContext();
        tblTask Data = DC.tblTasks.Single(ob => ob.TaskID == Convert.ToInt32(Session["TaskID"]));
        tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == Data.ModuleID);
        tblProject ProjectData = DC.tblProjects.Single(ob => ob.ProjectID == ModuleData.ProjectID);
        lblProName.Text = ProjectData.Title;
        txtTaskName.Text = Data.Title;
        rptAddSkill.DataSource = ProjectObject.ViewSkill();
        rptAddSkill.DataBind();
        if(Data.State == 1)
        {
            ddState.SelectedIndex = 0;
        }
        else if (Data.State == 2)
        {
            ddState.SelectedIndex = 1;
        }
        else if (Data.State == 3)
        {
            ddState.SelectedIndex = 2;
        }
        else if (Data.State == 4)
        {
            ddState.SelectedIndex = 3;
        }
        else
        {
            ddState.SelectedIndex = 0;
        }

        if (Data.Priority == 1)
        {
            ddPriority.SelectedIndex = 1;
        }
        else if (Data.Priority == 2)
        {
            ddPriority.SelectedIndex = 2;
        }
        else if (Data.Priority == 3)
        {
            ddPriority.SelectedIndex = 3;
        }
        else if (Data.Priority == 4)
        {
            ddPriority.SelectedIndex = 4;
        }
        else if (Data.Priority == 5)
        {
            ddPriority.SelectedIndex = 5;
        }
        else
        {
            ddPriority.SelectedIndex = 0;
        }

        if (Data.Risk == 1)
        {
            ddRisk.SelectedIndex = 1;
        }
        else if (Data.Risk == 2)
        {
            ddRisk.SelectedIndex = 2;
        }
        else if (Data.Risk == 3)
        {
            ddRisk.SelectedIndex = 3;
        }
        else
        {
            ddRisk.SelectedIndex = 0;
        }

        //lblDDate.Text = Convert.ToDateTime(Data.DeadlineDate).ToShortDateString();
        //txtCkEditor.Text = Data.Description;


    }

    protected void lnkbtnModuleAssign_Click(object sender, EventArgs e)
    {
        //lnkbtnModuleAssign.Visible = false;
        //ddTeamLeader.DataSource = ProjectObject.GetTeamLeader(Convert.ToInt32(Session["ProjectID"]),Convert.ToInt32(Session["ModuleID"]));
        //ddTeamLeader.DataValueField = "EmpID";
        //ddTeamLeader.DataTextField = "FirstName";
        //ddTeamLeader.DataBind();
        //ddTeamLeader.Items.Insert(0, new ListItem("Select Team Leader", ""));
        //ddTeamLeader.Visible = true;
    }

    protected void lnkbtnAddSkill_Click(object sender, EventArgs e)
    {
        lnkbtnAddSkill.Visible = false;
        txtAddSkill.Visible = true;
        txtAddSkill.Focus();
    }

    protected void txtAddSkill_TextChanged(object sender, EventArgs e)
    {
        
    }
   
    protected void lnkDDate_Click(object sender, EventArgs e)
    {
        lnkDDate.Visible = false;
        txtDDate.Visible = true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectMaster.aspx");
    }
}