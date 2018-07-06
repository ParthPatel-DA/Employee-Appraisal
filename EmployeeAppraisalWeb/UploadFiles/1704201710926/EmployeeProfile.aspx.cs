using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EmployeeAppraisalServiceReference;

public partial class EmployeeProfile : System.Web.UI.Page
{
    ServiceClient objEmployee = new ServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        Session["EmpID"] = 2;
        var Data = objEmployee.BindEmpProfile(Convert.ToInt32(Session["EmployeeID"]));
        lblname.Text = Data.FirstName + " " + Data.LastName;
        lbldob.Text = Convert.ToDateTime(Data.DOB).ToShortDateString();
        lblcontact.Text = Data.ContactNo;
        lblemail.Text = Data.EmailID;
        lbladdress.Text = Data.Address + "" + Data.Landmark;
        hdnEmpID.Value = Data.EmpID.ToString();
        ImgProfile.ImageUrl = "Admin/EmpUpload/" + Data.ProfilePic;
        if (Data.ProfilePic == null)
        {
            ImgProfile.ImageUrl = "Admin/img/user-icon.png";
        }

        if (Data.Gender == null)
        {
            lblgender.Text = "Male";
        }
        else if (Data.Gender == 1)
        {
            lblgender.Text = "Male";
        }
        else
        {
            lblgender.Text = "Female";
        }
        HiddenField1.Value = Data.ProfilePic;

        rptSkills.DataSource = objEmployee.ViewEmpSkill(Convert.ToInt32(hdnEmpID.Value));
        rptSkills.DataBind();

        rptAddSkill.DataSource = objEmployee.ViewSkill();
        rptAddSkill.DataBind();

        var DC = new DataClassesDataContext();
        var str = (from T in DC.tblTeams
                   join TM in DC.tblTeamMembers
                   on T.TeamID equals TM.TeamID
                   join P in DC.tblProjects 
                   on T.ProjectID equals P.ProjectID
                   where TM.EmpID == Convert.ToInt32(Session["EmployeeID"])
                   select P);

        rptMyProject.DataSource = str;
        rptMyProject.DataBind();

        var Data2 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmployeeID"]));
        divSkillPoint.Style.Add("width", Data2.Skills.ToString() + "%");

        var Data3 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmployeeID"]));
        divQualityPoint.Style.Add("width", Data3.Quality.ToString() + "%");

        var Data4 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmployeeID"]));
        divAvialabilityPoint.Style.Add("width", Data4.Avialibility.ToString() + "%");

        var Data5 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmployeeID"]));
        divCooperationPoint.Style.Add("width", Data5.Cooperation.ToString() + "%");

        var Data6 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmployeeID"]));
        divCommunicationPoint.Style.Add("width", Data6.Communication.ToString() + "%");

        var Data7 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmployeeID"]));
        divClientFeedbackPoint.Style.Add("width", Data7.ClientFeedback.ToString() + "%");
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        lnkEdit.Visible = false;
        lblgender.Visible = false;
        lbldob.Visible = false;
        lblcontact.Visible = false;
        lblemail.Visible = false;
        lbladdress.Visible = false;
        lblname.Visible = false;

        btnUpdate.Visible = true;
        ddgen.Visible = true;
        txtdob.Visible = true;
        txtcontact.Visible = true;
        txtemail.Visible = true;
        txtaddress.Visible = true;
        txtFname.Visible = true;
        txtLname.Visible = true;
        flpImg.Visible = true;

        var Data = objEmployee.BindEmpProfile(Convert.ToInt32(Session["EmployeeID"]));
        txtFname.Text = Data.FirstName;
        txtLname.Text = Data.LastName;
        txtdob.Text = Convert.ToDateTime(Data.DOB).ToShortDateString();
        txtcontact.Text = Data.ContactNo;
        txtemail.Text = Data.EmailID;
        txtaddress.Text = Data.Address + "" + Data.Landmark;
        if (Data.Gender == null)
        {
            ddgen.SelectedIndex = 0;
        }
        else if (Data.Gender == 1)
        {
            ddgen.SelectedIndex = 0;
        }
        else
        {
            ddgen.SelectedIndex = 1;
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        var filename = "";
        if (flpImg.HasFile)
        {
            string strPic = flpImg.FileName;
            var path = Server.MapPath("~/Admin/EmpUpload");
            DateTime date = DateTime.Now;
            string strdate = date.ToString();

            var charsToRemove = new string[] { "%", "-", ":", " ", "\\" };
            foreach (var c in charsToRemove)
            {
                strdate = strdate.Replace(c, string.Empty);
                strPic = strPic.Replace(c, string.Empty);
            }
            //filename = strdate + strPic;
            filename = strPic;
            flpImg.SaveAs(path + "\\" + filename);
        }
        else
        {
            filename = HiddenField1.Value;
        }

        var Data = objEmployee.UpdateEmpProfile(Convert.ToInt32(Session["EmployeeID"]), txtFname.Text, txtLname.Text, Convert.ToInt32(ddgen.SelectedValue),Convert.ToDateTime(txtdob.Text), txtcontact.Text, txtemail.Text, txtaddress.Text, filename);
        BindData();
        Response.Redirect("EmployeeProfile.aspx");
    }

    protected void txtAddSkill_TextChanged(object sender, EventArgs e)
    {
        objEmployee.AddEmpSkill(Convert.ToInt32(Session["EmployeeID"]), txtAddSkill.Text);
        BindData();
        txtAddSkill.Text = "";
        panelAddSkill.Visible = false;
    }

    protected void AddSkill_Click(object sender, EventArgs e)
    {
        panelAddSkill.Visible = true;
    }

    protected void rptSkills_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int ID = Convert.ToInt32(e.CommandArgument);
        if(e.CommandName == "DeleteSkill")
        {
            objEmployee.DelEmpSkill(Convert.ToInt32(Session["EmployeeID"]), ID);
        }
        BindData();
    }

}