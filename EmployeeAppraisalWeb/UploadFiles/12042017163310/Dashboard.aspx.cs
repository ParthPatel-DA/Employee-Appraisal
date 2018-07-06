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
        if(Session["EmpID"] == null)
        {
            Response.Redirect("ClientLogin.aspx");
        }
    }

    protected void lnkProjectManager_Click(object sender, EventArgs e)
    {
        Session["PersonType"] = "ProjectManager";
        Response.Redirect("ProjectManager.aspx");
    }

    protected void lnkTeamLeader_Click(object sender, EventArgs e)
    {
        Session["PersonType"] = "TeamLeader";
        Response.Redirect("ProjectManager.aspx");
    }

    protected void lnkEmployee_Click(object sender, EventArgs e)
    {
        Session["PersonType"] = "Employee";
        Response.Redirect("ProjectMaster.aspx");
    }
}