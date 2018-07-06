using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;

public partial class Home : System.Web.UI.Page
{
    ServiceClient ViewServiceObject = new ServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        rptViewOurServices.DataSource = ViewServiceObject.Viewservice();
        rptViewOurServices.DataBind();

        var dc = new DataClassesDataContext();
        int UserCnt = dc.tblClients.Count(ob => ob.IsActive == true);
        lblUserCount.Text = UserCnt.ToString();

        int ProCnt = dc.tblProjects.Count(ob => ob.IsActive == true);
        lblProjects.Text = ProCnt.ToString();

        int feedback = dc.tblFeedbacks.Count();
        lblfeedback.Text = feedback.ToString();

        int Services = dc.tblCategories.Count();
        lblServices.Text = Services.ToString();

        rptViewProject.DataSource = ViewServiceObject.ProjectStatus();
        rptViewProject.DataBind();
        
    }

    protected void btnSubscribe_Click(object sender, EventArgs e)
    {
        bool CheckEmail = ViewServiceObject.SubscribeEmailCheck(txtSubEmail.Text);
        if (CheckEmail == false)
        {
            errorSubscribe.Text = "Email already Subscribed";
            errorSubscribe.Visible = true;
            PanelUnSubscribe.Visible = true;
            PanelSubscribe.Visible = false;
        }
        else
        {
            ViewServiceObject.Subscribe(txtSubEmail.Text);
            errorSubscribe.Text = "Your Email Subscribed Successfully..";
            errorSubscribe.Visible = true;
            txtSubEmail.Text = "";
        }
    }

    protected void txtSubEmail_TextChanged(object sender, EventArgs e)
    {
        bool CheckEmail = ViewServiceObject.SubscribeEmailCheck(txtSubEmail.Text);
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
        bool CheckEmail = ViewServiceObject.SubscribeEmailCheck(txtSubEmail.Text);
        if (CheckEmail == true)
        {
            errorSubscribe.Text = "Email already Subscribed";
            errorSubscribe.Visible = true;
            PanelUnSubscribe.Visible = true;
            PanelSubscribe.Visible = false;
        }
        else
        {
            ViewServiceObject.UnSubscribe(txtSubEmail.Text);
            errorSubscribe.Text = "Your Email UnSubscribed Successfully..";
            errorSubscribe.Visible = true;
            txtSubEmail.Text = "";
            PanelUnSubscribe.Visible = false;
            PanelSubscribe.Visible = true;
        }

    }

    protected void lnkService_Click(object sender, EventArgs e)
    {
        Response.Redirect("Services.aspx");
    }

    protected void rptViewProject_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "ViewProject")
        {
            Session["ViewProjectID"] = e.CommandArgument;
            Response.Redirect("AboutProject.aspx");
        }
    }
}