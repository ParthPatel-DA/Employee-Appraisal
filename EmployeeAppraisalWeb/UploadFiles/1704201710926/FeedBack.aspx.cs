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
        if(ddProduct.SelectedValue != null)
        {
            ProjectID = Convert.ToInt32(ddProduct.SelectedValue);
        }
        else
        {
            ProjectID = 0;
        }
        float Point,APoint,BPoint;
        if (aoption.Checked)
        {
            APoint = 5;
        }
        else if(boption.Checked)
        {
            APoint = 4;
        }
        else if(coption.Checked)
        {
            APoint = 3;
        }
        else if(doption.Checked)
        {
            APoint = 2;
        }
        else if (eoption.Checked)
        {
            APoint = 1;
        }
        else 
        {
            APoint = 5;
        }
        if(foption.Checked)
        {
            BPoint = 5;
        }
        else if(goption.Checked)
        {
            BPoint = 4;
        }
        else if(hoption.Checked)
        {
            BPoint = 3;
        }
        else if(ioption.Checked)
        {
            BPoint = 2;
        }
        else if(joption.Checked)
        {
            BPoint = 1;
        }
        else
        {
            BPoint = 5;
        }
        Point = APoint + BPoint / 2;
        bool obj = objFeedBack.GiveFeedback(txtEmail.Text, ProjectID, Point, txtEnquiry.Text);
        if(obj == true)
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('FeedBack Successfully Submitted');window.location ='Default.aspx'</script>");
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Oops! Something goes wrong...');window.location ='FeedBack.aspx'</script>");
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