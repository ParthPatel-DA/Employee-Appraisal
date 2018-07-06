using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using EmployeeAppraisalServiceReference;

public partial class Services : System.Web.UI.Page
{
    ServiceClient ServiceObject = new ServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        rptservice.DataSource = ServiceObject.Viewservice();
        rptservice.DataBind();
        foreach(RepeaterItem Item in rptservice.Items)
        {
            HiddenField hdn = (HiddenField)Item.FindControl("hdnCategory");
            Repeater rpt = (Repeater)Item.FindControl("rptSubservice");
            rpt.DataSource = ServiceObject.ViewSubservice(Convert.ToInt32(hdn.Value));
            rpt.DataBind();
        }
    }
}