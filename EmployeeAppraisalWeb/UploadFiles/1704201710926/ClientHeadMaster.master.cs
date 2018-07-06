using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;

public partial class ClientHeadMaster : System.Web.UI.MasterPage
{
    ServiceClient objNews = new ServiceClient();
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

    protected void btnSubscribe_Click(object sender, EventArgs e)
    {
        bool CheckEmail = objNews.SubscribeEmailCheck(txtSubEmail.Text);
        if (CheckEmail == false)
        {
            errorSubscribe.Text = "Email already Subscribed";
            errorSubscribe.Visible = true;
            PanelUnSubscribe.Visible = true;
            PanelSubscribe.Visible = false;
        }
        else
        {
            objNews.Subscribe(txtSubEmail.Text);
            errorSubscribe.Text = "Your Email Subscribed Successfully..";
            errorSubscribe.Visible = true;
            txtSubEmail.Text = "";
        }
    }

    protected void txtSubEmail_TextChanged(object sender, EventArgs e)
    {
        bool CheckEmail = objNews.SubscribeEmailCheck(txtSubEmail.Text);
        if (CheckEmail == false)
        {
            errorSubscribe.Text = "Email already Subscribed";
            errorSubscribe.Visible = true;
            PanelUnSubscribe.Visible = true;
            PanelSubscribe.Visible = false;
        }
        else
        {
            PanelUnSubscribe.Visible = false;
        }
    }

    protected void btnUnSubscribe_Click(object sender, EventArgs e)
    {
        bool CheckEmail = objNews.SubscribeEmailCheck(txtSubEmail.Text);
        if (CheckEmail == true)
        {
            errorSubscribe.Text = "Email already Subscribed";
            errorSubscribe.Visible = true;
            PanelUnSubscribe.Visible = true;
            PanelSubscribe.Visible = false;
        }
        else
        {
            objNews.UnSubscribe(txtSubEmail.Text);
            errorSubscribe.Text = "Your Email UnSubscribed Successfully..";
            errorSubscribe.Visible = true;
            txtSubEmail.Text = "";
            PanelUnSubscribe.Visible = false;
            PanelSubscribe.Visible = true;
        }


    }

    protected void lnkTrackProject_Click(object sender, EventArgs e)
    {
        Response.Redirect("TrackProject.aspx");
    }
}
