using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EmployeeAppraisalServiceReference;

public partial class PostProject : System.Web.UI.Page
{
    ServiceClient objPostOroject = new ServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        PanelUser.Visible = true;

        if (!IsPostBack)
        {
            fillDrop();
        }
        if(Session["ClientID"] != null)
        {
            PanelUser.Visible = false;
            PanelProDes.Visible = true;
            PanelChoice.Visible = false;
            PanelInquiry.Visible = false;
            Session.Remove("PostProject");
            Session.Remove("PostProjectReg");

            //if (Session["PostProject"] != null)
            //{
            //    if (Session["PostProject"].ToString() == "True")
            //    {
            //        PanelUser.Visible = false;
            //        PanelProDes.Visible = true;
            //        PanelChoice.Visible = false;
            //        PanelInquiry.Visible = false;
            //        Session.Remove("PostProject");
            //    }
            //}
            //else if (Session["PostProjectReg"] != null)
            //{
            //    if (Session["PostProjectReg"].ToString() == "True")
            //    {
            //        PanelUser.Visible = false;
            //        PanelProDes.Visible = true;
            //        PanelChoice.Visible = false;
            //        PanelInquiry.Visible = false;
            //        Session.Remove("PostProjectReg");
            //    }
            //}
            //else
            //{
            //    PanelProDes.Visible = false;
            //    PanelChoice.Visible = false;
            //    PanelInquiry.Visible = false;
            //}
        }
        else
        {
            PanelUser.Visible = true;
            PanelProDes.Visible = false;
            PanelInquiry.Visible = false;
            PanelChoice.Visible = false;
        }
        
    }

    public void fillDrop()
    {
        ddProCtg.DataSource = objPostOroject.GetCatDrop();
        ddProCtg.DataValueField = "CategoryID";
        ddProCtg.DataTextField = "categoryName";
        ddProCtg.DataBind();
        ddProCtg.Items.Insert(0, new ListItem("Select a Category of Work", " "));
        ddProCtg.Items.Add(new ListItem("Others", "-1"));

    }

    protected void lnkUser_Click(object sender, EventArgs e)
    {
        if (Session["ClientID"] != null)
        {
            PanelProDes.Visible = true;
            PanelUser.Visible = false;
            PanelInquiry.Visible = false;
            PanelChoice.Visible = false;
        }
        else
        {
            Session["PostProject"] = "True";
            Response.Redirect("ClientLogin.aspx");
        }
    }

    protected void lnkNew_Click(object sender, EventArgs e)
    {

        PanelUser.Visible = false;
        PanelChoice.Visible = true;
    }

    protected void lnkReg_Click(object sender, EventArgs e)
    {
        Session["PostProjectReg"] = "True";
        Response.Redirect("ClientLogin.aspx");
    }

    protected void lnkInquiry_Click(object sender, EventArgs e)
    {
        PanelInquiry.Visible = true;
        PanelUser.Visible = false;
        PanelChoice.Visible = false;
        PanelProDes.Visible = false;
    }

    protected void btnInqSubmit_Click(object sender, EventArgs e)
    {
        objPostOroject.AddInquiry(txtFName.Text + " " + txtLName.Text, txtInqEmail.Text, txtInqMNO.Text, txtProjInq.Text);
        //ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Inquiry Successfully Submitted');window.location ='Default.aspx'</script>");
        Response.Redirect("Default.aspx");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var DC = new DataClassesDataContext();
        string strPic = FileContent.FileName;
        var Filename = "";
        if (FileContent.HasFile)
        {
            var path = Server.MapPath("~/ContentUpload");
            DateTime date = DateTime.Now;
            string strdate = date.ToString();

            var charsToRemove = new string[] { "%", "-", ":", " " };
            foreach (var c in charsToRemove)
            {
                strdate = strdate.Replace(c, string.Empty);
                strPic = strPic.Replace(c, string.Empty);
            }
            Filename = strdate + strPic;
            FileContent.SaveAs(path + "/" + Filename);
        }

        string CategoryID;

        if (ddProCtg.SelectedValue == "-1")
        {
            CategoryID = null;
        }
        else if(ddSubCategory.SelectedValue == "-1")
        {
            CategoryID = ddProCtg.SelectedValue;
        }
        else if(ddOtherCat.SelectedValue == "-1")
        {
            CategoryID = ddSubCategory.SelectedValue;
        }
        else
        {
            if (ddSubCategory.SelectedValue == null)
            {
                CategoryID = ddProCtg.SelectedValue;
            }
            else if (ddOtherCat.SelectedValue == null)
            {
                CategoryID = ddSubCategory.SelectedValue;
            }
            else
            {
                CategoryID = ddOtherCat.SelectedValue;
            }
        }

        DateTime DeadLineDate = DateTime.Now.AddDays(Convert.ToInt32(txtProjectPlan.Text));
        string Date = Convert.ToDateTime(DeadLineDate).ToString("dddd, MMMM dd, yyyy h:mm:ss tt");
        objPostOroject.AddPostProject(1, CategoryID, txtTitle.Text, txtProDesc.Text, Filename, Convert.ToDateTime(Date), 1);
        ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Successfully Submitted');window.location ='Default.aspx'</script>");
    }


    protected void btnVSubmit_Click(object sender, EventArgs e)
    {

    }



    protected void ddProCtg_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddProCtg.SelectedValue == "-1")
        {
            PanelProDes.Visible = true;
            ddSubCategory.Visible = false;
            ddOtherCat.Visible = false;
            PanelChoice.Visible = false;
            PanelUser.Visible = false;
            PanelInquiry.Visible = false;
            txtTitle.Focus();
        }
        else
        {
            var Category = objPostOroject.GetSubCategory(Convert.ToInt32(ddProCtg.SelectedValue)); ;

            if (objPostOroject.CountContentTrans() > 0)
            {
                ddSubCategory.Visible = true;
                txtProDesc.Attributes.Remove("placeholder");
                txtProDesc.Attributes.Add("placeholder", "Description about from which language to another language");
                ddSubCategory.DataSource = Category;
                ddSubCategory.DataValueField = "CategoryID";
                ddSubCategory.DataTextField = "categoryName";
                ddSubCategory.DataBind();
                ddSubCategory.Items.Insert(0, new ListItem("Select a Sub Category of Work", "0"));
                if(ddProCtg.SelectedItem.Text == "Content Writing" || ddProCtg.SelectedItem.Text == "Content Translation")
                {
                    ddSubCategory.Items.Add(new ListItem("Other", "-1"));
                }
                PanelUser.Visible = false;
                PanelProDes.Visible = true;
                PanelChoice.Visible = false;
                PanelInquiry.Visible = false;
            }
            else
            {
                ddSubCategory.DataSource = Category;
                ddSubCategory.DataValueField = "CategoryID";
                ddSubCategory.DataTextField = "CategoryName";
                ddSubCategory.DataBind();
                ddSubCategory.Items.Insert(0, new ListItem("Select a Sub Category of Work", "0"));
                PanelUser.Visible = false;
                PanelProDes.Visible = true;
                PanelChoice.Visible = false;
                PanelInquiry.Visible = false;
                ddSubCategory.Visible = true;
            }
        }
    }

    protected void ddSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        var Category = objPostOroject.GetSubCategory(Convert.ToInt32(ddSubCategory.SelectedValue)); ;

        if (Category != null)
        {
            ddOtherCat.DataSource = Category;
            ddOtherCat.DataValueField = "CategoryID";
            ddOtherCat.DataTextField = "CategoryName";
            ddOtherCat.DataBind();
            ddOtherCat.Items.Insert(0, new ListItem("Select a Another Category of Work", "0"));
            if(ddSubCategory.SelectedItem.Text != "Mobile")
            {
                ddOtherCat.Items.Add(new ListItem("Other", "-1"));
            }
            PanelInquiry.Visible = false;
            ddSubCategory.Visible = true;
            ddOtherCat.Visible = true;
            PanelUser.Visible = false;
            PanelProDes.Visible = true;
            PanelChoice.Visible = false;
        }
        else if (ddSubCategory.SelectedValue == "-1")
        {
            txtTitle.Focus();
            PanelInquiry.Visible = false;
            ddSubCategory.Visible = true;
            ddOtherCat.Visible = false;
            PanelUser.Visible = false;
            PanelProDes.Visible = true;
            PanelChoice.Visible = false;
        }
        else
        {
            txtTitle.Text = ddSubCategory.SelectedItem.Text;
            PanelInquiry.Visible = false;
            ddSubCategory.Visible = true;
            ddOtherCat.Visible = false;
            PanelUser.Visible = false;
            PanelProDes.Visible = true;
            PanelChoice.Visible = false;
        }
    }

    protected void ddOtherCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddOtherCat.SelectedValue == "-1")
        {
            txtTitle.Focus();
            PanelInquiry.Visible = false;
            ddSubCategory.Visible = true;
            ddOtherCat.Visible = true;
            PanelUser.Visible = false;
            PanelProDes.Visible = true;
            PanelChoice.Visible = false;
        }
        else
        {
            txtTitle.Text = ddOtherCat.SelectedItem.Text;
            PanelInquiry.Visible = false;
            ddSubCategory.Visible = true;
            ddOtherCat.Visible = true;
            PanelUser.Visible = false;
            PanelProDes.Visible = true;
            PanelChoice.Visible = false;
        }

    }
}