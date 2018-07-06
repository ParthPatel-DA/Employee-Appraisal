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

    protected void lnkService_Click(object sender, EventArgs e)
    {
        Response.Redirect("Services.aspx");
    }
}