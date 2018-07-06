using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;
public partial class FeedBack : System.Web.UI.Page
{
    ServiceClient objFeedBack = new ServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtRate.Value = "5";
        }
    }

    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        var Data = objFeedBack.GetClientDetail(txtEmail.Text);
        txtName.Text = Data.ClientName;
        txtOrgn.Text = Data.CompanyName;
        ddProduct.DataSource = objFeedBack.BindClientProject(Data.ClientID);
        ddProduct.DataValueField = "ProjectID";
        ddProduct.DataTextField = "Title";
        ddProduct.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int ProjectID;
        if (ddProduct.SelectedValue != null)
        {
            ProjectID = Convert.ToInt32(ddProduct.SelectedValue);
        }
        else
        {
            ProjectID = 0;
        }

        //if (txtRate.Value == "5")
        //{
        //    Point = 5;
        //}
        //else if (txtRate.Value == "4")
        //{
        //    Point = 4;
        //}
        //else if (txtRate.Value == "3")
        //{
        //    Point = 3;
        //}
        //else if (txtRate.Value == "2")
        //{
        //    Point = 2;
        //}
        //else if (txtRate.Value == "1")
        //{
        //    Point = 1;
        //}
        //else
        //{
        //    Point = 5;
        //}
       
        int Point = Convert.ToInt32(txtRate.Value);


        bool obj = objFeedBack.GiveFeedback(txtEmail.Text, ProjectID, Point, txtEnquiry.Text);
        if (obj == true)
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('FeedBack Successfully Submitted');window.location ='Default.aspx'</script>");
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Oops! Something goes wrong...');window.location ='FeedBack.aspx'</script>");
        }

        var DC = new DataClassesDataContext();
        IQueryable<tblEmpAppraisal> datas = (from ob1 in DC.tblEmpAppraisals
                                             join ob2 in DC.tblTeamMembers
                                                 on ob1.EmpID equals ob2.EmpID
                                             join ob3 in DC.tblTeams
                                             on ob2.TeamID equals ob3.TeamID
                                             where ob3.ProjectID == ProjectID
                                             select ob1);

        foreach (tblEmpAppraisal data in datas)
        {
            data.ClientFeedback = Convert.ToDecimal(Point);
            DC.SubmitChanges();
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtEmail.Text = " ";
        txtEnquiry.Text = " ";
        txtName.Text = " ";
        txtOrgn.Text = " ";
        ddProduct.SelectedValue = " ";
    }
}