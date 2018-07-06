using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EmployeeAppraisalServiceReference;

public partial class Contactus : System.Web.UI.Page
{
    ServiceClient objContact = new ServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)Master.FindControl("panelContactus")).Visible = false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objContact.AddInquiry(txtFirstName.Text + " " + txtLastName.Text, txtEmail.Text, txtContactNo.Text, txtDescription.Text);
        ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Successfully Submitted');window.location ='Default.aspx'</script>");
    }
}