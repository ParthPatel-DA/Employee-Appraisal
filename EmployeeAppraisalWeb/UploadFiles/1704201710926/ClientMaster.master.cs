using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClientMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lnkLogin.Visible = true;
        lnkLogout.Visible = false;
        lnkTrackProject.Visible = false;
        if (Session["EmpID"] != null)
        {
            lnkLogin.Visible = false;
            lnkLogout.Visible = true;
            lnkTrackProject.Visible = true;
        }
        else if (Session["ClientID"] != null)
        {
            lnkLogin.Visible = false;
            lnkLogout.Visible = true;
            lnkTrackProject.Visible = true;
        }
        else
        {
            lnkLogin.Visible = true;
            lnkLogout.Visible = false;
            lnkTrackProject.Visible = false;
        }
    }

    protected void lnkLogin_Click(object sender, EventArgs e)
    {
        if (Session["PostProjectreg"] != null)
        {
            Session.Remove("PostProjectReg");
            Response.Redirect("ClientLogin.aspx");
        }
        else
        {
            Response.Redirect("ClientLogin.aspx");
        }
    }


    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Default.aspx");
    }

    protected void lnkTrackProject_Click(object sender, EventArgs e)
    {
        Response.Redirect("TrackProject.aspx");
    }
}
