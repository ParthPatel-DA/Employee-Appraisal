using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class EmployeeProfile : System.Web.UI.Page
{
    ServiceClient objEmployee = new ServiceClient();
    public static string GetMacAddress()
    {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            // Only consider Ethernet network interfaces
            if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            {
                return nic.GetPhysicalAddress().ToString();
            }
        }
        return null;
    }
    public void AddErrorLog(ref Exception strException, string PageName, string UserType, int UserID, int AdminID, string MACAddress = null)
    {
        var DC = new DataClassesDataContext();
        //Insert record in ErrorLog
        tblError objError = new tblError();
        objError.PageName = PageName;
        objError.Description = strException.Message.ToString();
        objError.CreatedOn = Convert.ToDateTime(DateTime.Now);
        objError.UserType = UserType;
        if (UserID != 0)
        {
            objError.UserID = UserID;
        }
        else
        {
            objError.UserID = null;
        }
        if (AdminID != 0)
        {
            objError.AdminID = AdminID;
        }
        else
        {
            objError.AdminID = null;
        }
        if (MACAddress != null)
        {
            objError.MacAddress = MACAddress;
        }
        else
        {
            objError.MacAddress = null;
        }
        DC.tblErrors.InsertOnSubmit(objError);
        DC.SubmitChanges();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["EmpID"] == null)
            {
                Response.Redirect("ClientLogin.aspx");
            }
            if (!IsPostBack)
            {
                BindData();
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void BindData()
    {
        try
        {
            var Data = objEmployee.BindEmpProfile(Convert.ToInt32(Session["EmpID"]));
            lblname.Text = Data.FirstName + " " + Data.LastName;
            if (Data.DOB != null)
            {
                lbldob.Text = Convert.ToDateTime(Data.DOB).ToShortDateString();
            }
            else
            {
                lbldob.Text = " ";
            }
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
                       where TM.EmpID == Convert.ToInt32(Session["EmpID"])
                       select P);

            rptMyProject.DataSource = str;
            rptMyProject.DataBind();

            //Appraisal
            int cnt = (from ob in DC.tblEmpAppraisals
                       where ob.EmpID == Convert.ToInt32(Session["EmpID"])
                       select ob).Count();

            if (cnt > 0)
            {
                var Data2 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmpID"]));
                divSkillPoint.Style.Add("width", Data2.Skills.ToString() + "%");

                var Data3 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmpID"]));
                divQualityPoint.Style.Add("width", Data3.Quality.ToString() + "%");

                var Data4 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmpID"]));
                divAvialabilityPoint.Style.Add("width", Data4.Avialibility.ToString() + "%");

                var Data5 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmpID"]));
                divCooperationPoint.Style.Add("width", Data5.Cooperation.ToString() + "%");

                var Data6 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmpID"]));
                divCommunicationPoint.Style.Add("width", Data6.Communication.ToString() + "%");

                var Data7 = DC.tblEmpAppraisals.Single(ob => ob.EmpID == Convert.ToInt32(Session["EmpID"]));
                divClientFeedbackPoint.Style.Add("width", Data7.ClientFeedback.ToString() + "%");
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        try
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

            var Data = objEmployee.BindEmpProfile(Convert.ToInt32(Session["EmpID"]));
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
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            var filename = "";
            if (flpImg.HasFile)
            {
                string strPic = flpImg.FileName;
                var path = Server.MapPath("~/Admin/EmpUpload");
                DateTime date = DateTime.Now;
                string strdate = date.ToString();

                var charsToRemove = new string[] { "%", "-", ":", " ", "\\", "/" };
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

            var Data = objEmployee.UpdateEmpProfile(Convert.ToInt32(Session["EmpID"]), txtFname.Text, txtLname.Text, Convert.ToInt32(ddgen.SelectedValue), Convert.ToDateTime(txtdob.Text), txtcontact.Text, txtemail.Text, txtaddress.Text, filename);
            BindData();
            Response.Redirect("EmployeeProfile.aspx");
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void txtAddSkill_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();

            tblSkill SkillID = (from ob in DC.tblSkills
                                where ob.SkillName == txtAddSkill.Text
                                select ob).Single();
            int Skill = (from ob in DC.tblEmpXSkills
                         join obj in DC.tblSkills
                         on ob.SkillID equals obj.SkillID
                         where ob.EmpID == Convert.ToInt32(Session["EmpID"]) && ob.SkillID == SkillID.SkillID
                         select ob).Count();
            if (Skill > 0)
            {
                erroSkill.Text = "Skill already exist!!";
                erroSkill.Visible = true;
            }
            else
            {
                erroSkill.Visible = false;
                objEmployee.AddEmpSkill(Convert.ToInt32(Session["EmpID"]), txtAddSkill.Text);
                txtAddSkill.Text = "";
                panelAddSkill.Visible = false;


                BindData();

                //Employee Appraisal
                int cnt = (from obj in DC.tblEmpAppraisals
                           where obj.EmpID == Convert.ToInt32(Session["EmpID"])
                           select obj).Count();
                if (cnt > 0)
                {
                    tblEmpAppraisal data = (from obj in DC.tblEmpAppraisals
                                            where obj.EmpID == Convert.ToInt32(Session["EmpID"])
                                            select obj).SingleOrDefault();
                    data.Skills = data.Skills.Value + 1;
                    DC.SubmitChanges();
                }
                else
                {
                    tblEmployee EmpData = (from obj in DC.tblEmployees
                                           where obj.EmpID == Convert.ToInt32(Session["EmpID"])
                                           select obj).First();
                    tblEmpAppraisal EmpAppraisal = new tblEmpAppraisal();
                    EmpAppraisal.EmpID = EmpData.EmpID;
                    EmpAppraisal.Skills = Convert.ToDecimal(1.0);
                    EmpAppraisal.Quality = Convert.ToDecimal(0.0);
                    EmpAppraisal.Avialibility = Convert.ToDecimal(0.0);
                    EmpAppraisal.Deadlines = Convert.ToDecimal(0.0);
                    EmpAppraisal.Communication = Convert.ToDecimal(0.0);
                    EmpAppraisal.Cooperation = Convert.ToDecimal(0.0);
                    EmpAppraisal.ClientFeedback = Convert.ToDecimal(0.0);
                    EmpAppraisal.CreatedBy = Convert.ToInt32(Session["EmpID"]);
                    EmpAppraisal.CreatedOn = DateTime.Now;
                    DC.tblEmpAppraisals.InsertOnSubmit(EmpAppraisal);
                }

                DC.SubmitChanges();
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void AddSkill_Click(object sender, EventArgs e)
    {
        try
        {
            panelAddSkill.Visible = true;
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptSkills_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "DeleteSkill")
            {
                objEmployee.DelEmpSkill(Convert.ToInt32(Session["EmpID"]), ID);

                var DC = new DataClassesDataContext();
                int cnt = (from obj in DC.tblEmpAppraisals
                           where obj.EmpID == Convert.ToInt32(Session["EmpID"])
                           select obj).Count();

                if (cnt > 0)
                {
                    tblEmpAppraisal data = (from obj in DC.tblEmpAppraisals
                                            where obj.EmpID == Convert.ToInt32(Session["EmpID"])
                                            select obj).SingleOrDefault();
                    data.Skills = data.Skills.Value - 1;

                }
                else
                {
                    tblEmpAppraisal Skill = new tblEmpAppraisal();
                    Skill.EmpID = Convert.ToInt32(Session["EmpID"]);
                    Skill.Skills = Convert.ToDecimal(-1.0);
                    Skill.Quality = Convert.ToDecimal(0.0);
                    Skill.Avialibility = Convert.ToDecimal(0.0);
                    Skill.Deadlines = Convert.ToDecimal(0.0);
                    Skill.Communication = Convert.ToDecimal(0.0);
                    Skill.Cooperation = Convert.ToDecimal(0.0);
                    Skill.ClientFeedback = Convert.ToDecimal(0.0);
                    Skill.CreatedOn = DateTime.Now;
                    DC.tblEmpAppraisals.InsertOnSubmit(Skill);
                }
                DC.SubmitChanges();
            }
            BindData();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

}