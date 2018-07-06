using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;

public partial class TrackProject : System.Web.UI.Page
{
    ServiceClient objProject = new ServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindProject();
        }
    }

    private void BindProject()
    {
        //SliderProject
        //rptProjectView.DataSource = objProject.BindClientProject(Convert.ToInt32(Session["ClientID"]));
        //rptProjectView.DataBind();

        //TotalProject
        //int cnt = rptProjectView.Items.Count;
        //foreach (RepeaterItem item in rptProjectView.Items)
        //{
        //    Literal ltr = (Literal)item.FindControl("ltrItemCount");
        //    ltr.Text = cnt.ToString();
        //}

        //SliderButton
        //rptSlider.DataSource = objProject.BindClientProject(Convert.ToInt32(Session["ClientID"]));
        //rptSlider.DataBind();

        //Project
        rptProject.DataSource = objProject.BindClientProject(Convert.ToInt32(Session["ClientID"]));
        rptProject.DataBind();
        foreach(RepeaterItem item in rptProject.Items)
        {
            Label lblADate = (Label)item.FindControl("lblADate");
            Label lblDDate = (Label)item.FindControl("lblDeadDate");
            Label lblDays = (Label)item.FindControl("lblDays");
            HiddenField hdnDays = (HiddenField)item.FindControl("hdnDays");
            lblADate.Text = Convert.ToDateTime(lblADate.Text).ToShortDateString();
            lblDDate.Text = Convert.ToDateTime(lblDDate.Text).ToShortDateString();
            TimeSpan Days = Convert.ToDateTime(hdnDays.Value) - DateTime.Now;
            if(Days.TotalDays > 0 )
            {
                lblDays.Text = Convert.ToInt32(Days.TotalDays).ToString() + " " + "Days left to complete";
            }
            else
            {
                lblDays.Text = "Completed";
            }
        }
    }


    protected void rptProjectView_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if (e.CommandName == "TrackProject")
        //{
        //    Session["ProjectID"] = e.CommandArgument;
        //    var Data = objProject.GetProjectDetail(Convert.ToInt32(Session["ProjectID"]));
        //    ltrProjectName.Text = Data[1];
        //    rptProjectTracking.DataSource = objProject.BindNewProject(Convert.ToInt32(Session["ProjectID"]));
        //    rptProjectTracking.DataBind();
        //    PanelProjectStatus.Visible = true;
        //    //PanelProjectView.Visible = false;
        //}
    }

    protected void lnkBack_Click(object sender, EventArgs e)
    {
        //PanelProjectView.Visible = true;
        PanelProject.Visible = true;
        PanelProjectStatus.Visible = false;
        BindProject();
    }

    protected void lnkProject_Click(object sender, EventArgs e)
    {
        PanelProjectStatus.Visible = true;
        PanelProject.Visible = false;
    }

    protected void rptProject_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "TrackProject")
        {
            Session["ProjectID"] = e.CommandArgument;
            var Data = objProject.GetProjectDetail(Convert.ToInt32(Session["ProjectID"]));
            ltrProjectName.Text = Data[1];
            rptProjectTracking.DataSource = objProject.BindNewProject(Convert.ToInt32(Session["ProjectID"]));
            rptProjectTracking.DataBind();
            foreach(RepeaterItem item in rptProjectTracking.Items)
            {
                HiddenField hdnModuleID = (HiddenField)item.FindControl("hdnModuleID");
                Panel PanelStatus = (Panel)item.FindControl("PanelStatus");
                Literal ltrProStatus = (Literal)item.FindControl("ltrProStatus");
                int Per = objProject.GetProjectPoint(Convert.ToInt32(hdnModuleID.Value));
                PanelStatus.Style.Add("width", Per.ToString() + "%");
                ltrProStatus.Text = Per.ToString() + "%";
            }
            PanelProjectStatus.Visible = true;
        }
    }
}