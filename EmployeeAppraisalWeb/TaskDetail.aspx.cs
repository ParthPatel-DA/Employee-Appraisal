using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ionic.Zip;
using EmployeeAppraisalServiceReference;
using System.IO;
using System.Net.NetworkInformation;

public partial class ModuleDetail : System.Web.UI.Page
{
    ServiceClient ProjectObject = new ServiceClient();
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
            var DC = new DataClassesDataContext();
            if (Session["EmpID"] == null)
            {
                Response.Redirect("ClientLogin.aspx");
            }
            if (!IsPostBack)
            {
                //Session["TaskID"] = 1;

                tblTask Data = DC.tblTasks.Single(ob => ob.TaskID == Convert.ToInt32(Session["TaskID"]));
                tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == Data.ModuleID);
                tblProject ProjectData = DC.tblProjects.Single(ob => ob.ProjectID == ModuleData.ProjectID);
                lblProName.Text = ProjectData.Title;
                txtTaskName.Text = Data.Title;
                ltrTaskID.Text = Data.TaskID.ToString();
                rptAddSkill.DataSource = ProjectObject.ViewSkill();
                rptAddSkill.DataBind();
                if (Data.State == 1)
                {
                    ddState.SelectedIndex = 0;
                }
                else if (Data.State == 2)
                {
                    ddState.SelectedIndex = 1;
                }
                else if (Data.State == 3)
                {
                    ddState.SelectedIndex = 2;
                }
                else if (Data.State == 4)
                {
                    ddState.SelectedIndex = 3;
                }
                else
                {
                    ddState.SelectedIndex = 0;
                }

                if (Data.Priority == 1)
                {
                    ddPriority.SelectedIndex = 1;
                }
                else if (Data.Priority == 2)
                {
                    ddPriority.SelectedIndex = 2;
                }
                else if (Data.Priority == 3)
                {
                    ddPriority.SelectedIndex = 3;
                }
                else if (Data.Priority == 4)
                {
                    ddPriority.SelectedIndex = 4;
                }
                else if (Data.Priority == 5)
                {
                    ddPriority.SelectedIndex = 5;
                }
                else
                {
                    ddPriority.SelectedIndex = 0;
                }

                if (Data.Risk == 1)
                {
                    ddRisk.SelectedIndex = 1;
                }
                else if (Data.Risk == 2)
                {
                    ddRisk.SelectedIndex = 2;
                }
                else if (Data.Risk == 3)
                {
                    ddRisk.SelectedIndex = 3;
                }
                else
                {
                    ddRisk.SelectedIndex = 0;
                }
                if (Data.DeadlineDate == null)
                {
                    lblDDate.Text = "Select Deadline Date";
                }
                else
                {
                    lblDDate.Text = Convert.ToDateTime(Data.DeadlineDate).ToShortDateString();
                }

                txtCkEditor.Text = Data.Description;

                lblModuleName.Text = ModuleData.Title;
                ltrModuleDescription.Text = ModuleData.Description;
                ltrModuleAssignDate.Text = Convert.ToDateTime(ModuleData.AssignDate).ToShortDateString();
                ltrModuleDeadlineDate.Text = Convert.ToDateTime(ModuleData.DeadlineDate).ToShortDateString();

                int cnt = DC.tblTeamMembers.Count(ob => ob.TaskID == Convert.ToInt32(ltrTaskID.Text));
                if (cnt > 0)
                {
                    tblTeamMember TeamMemberData = DC.tblTeamMembers.Single(ob => ob.TaskID == Convert.ToInt32(ltrTaskID.Text));
                    if (TeamMemberData.EmpID == null)
                    {
                        lblEmployee.Text = "Unassigned";
                    }
                    else
                    {
                        int cntEmp = DC.tblEmployees.Count(ob => ob.EmpID == TeamMemberData.EmpID);
                        if (cntEmp > 0)
                        {
                            tblEmployee EmpData = DC.tblEmployees.Single(ob => ob.EmpID == TeamMemberData.EmpID);
                            lblEmployee.Text = EmpData.FirstName + " " + EmpData.LastName;
                            if (EmpData.ProfilePic != null)
                            {
                                imgEmployee.ImageUrl = "Admin/EmpUpload/" + EmpData.ProfilePic;
                            }
                            else
                            {
                                imgEmployee.ImageUrl = "img/notassigned-user.svg";
                            }
                        }
                        else
                        {
                            lblEmployee.Text = "Unassigned";
                            imgEmployee.ImageUrl = "img/notassigned-user.svg";
                        }
                    }
                }
                else
                {
                    lblEmployee.Text = "Unassigned";
                    imgEmployee.ImageUrl = "img/notassigned-user.svg";
                }

                hdnTaskFile.Value = ModuleData.TaskFile;
                if (hdnTaskFile.Value == null)
                {
                    divTaskFile.Visible = false;
                }

                if (Session["PersonType"].ToString() != "")
                {
                    if (Session["PersonType"].ToString() == "Employee")
                    {
                        lnkbtnModuleAssign.Enabled = false;
                        rngQuality.Attributes.Add("disabled", "false");
                        rngAvialibility.Attributes.Add("disabled", "false");
                        rngCommunication.Attributes.Add("disabled", "false");
                        rngCooperation.Attributes.Add("disabled", "false");
                        ddPriority.Attributes.Add("disabled", "false");
                        ddRisk.Attributes.Add("disabled", "false");
                        lnkbtnAddSkill.Visible = false;
                        LinkButton12.Enabled = false;
                        ddState.Items.RemoveAt(0);
                        //rngQuality.Attributes.CssStyle.Add("")
                        //PanelPlanning.Visible = false;
                    }
                    else if (Session["PersonType"].ToString() == "ProjectManager")
                    {
                        lnkbtnModuleAssign.Enabled = false;
                        rngQuality.Attributes.Add("disabled", "false");
                        rngAvialibility.Attributes.Add("disabled", "false");
                        rngCommunication.Attributes.Add("disabled", "false");
                        rngCooperation.Attributes.Add("disabled", "false");
                        ddPriority.Attributes.Add("disabled", "false");
                        ddRisk.Attributes.Add("disabled", "false");
                        lnkbtnAddSkill.Visible = false;
                        ddState.Enabled = false;
                        //ddState.Items.RemoveAt(1);
                    }
                }
            }
            if (Session["errorDDate"] != null)
            {
                tblTask errorTask = DC.tblTasks.Single(ob => ob.TaskID == Convert.ToInt32(ltrTaskID.Text));
                tblModule errorModule = DC.tblModules.Single(ob => ob.ModuleID == errorTask.ModuleID);
                errorDDate.Text = "Please Enter Date Between " + Convert.ToDateTime(errorTask.AssignDate).ToShortDateString() + " and " + Convert.ToDateTime(errorModule.DeadlineDate).ToShortDateString() + ".";
                errorDDate.Visible = true;
                Session["errorDDate"] = null;
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

    protected void lnkbtnModuleAssign_Click(object sender, EventArgs e)
    {
        try
        {
            lnkbtnModuleAssign.Visible = false;
            ddEmployee.DataSource = ProjectObject.GetTeamLeader(Convert.ToInt32(Session["ProjectID"]), Convert.ToInt32(Session["ModuleID"]));
            ddEmployee.DataValueField = "EmpID";
            ddEmployee.DataTextField = "FirstName";
            ddEmployee.DataBind();
            ddEmployee.Items.Insert(0, new ListItem("Select Team Leader", ""));
            ddEmployee.Visible = true;
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

    protected void lnkbtnAddSkill_Click(object sender, EventArgs e)
    {
        try
        {
            lnkbtnAddSkill.Visible = false;
            txtAddSkill.Visible = true;
            txtAddSkill.Focus();
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

    }

    protected void lnkDDate_Click(object sender, EventArgs e)
    {
        try
        {
            lnkDDate.Visible = false;
            txtDDate.Visible = true;
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            tblTask TaskData = DC.tblTasks.Single(ob => ob.TaskID == Convert.ToInt32(ltrTaskID.Text));
            tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == TaskData.ModuleID);
            tblTeamModule TeamModuleData = DC.tblTeamModules.Single(ob => ob.ModuleID == Convert.ToInt32(TaskData.ModuleID));
            int cntTeamMember = DC.tblTeamMembers.Count(ob => ob.TaskID == Convert.ToInt32(ltrTaskID.Text));
            if (cntTeamMember > 0)
            {
                tblTeamMember NewTeamMember = DC.tblTeamMembers.Single(ob => ob.TaskID == Convert.ToInt32(ltrTaskID.Text));
                if (ddEmployee.SelectedValue != "")
                {
                    NewTeamMember.EmpID = Convert.ToInt32(ddEmployee.SelectedValue);
                    tblNotification NotificationCancel = new tblNotification();
                    NotificationCancel.Title = "Team Leader Cancelling";
                    NotificationCancel.Description = "You are cancel Employee for" + " " + TaskData.Title + " " + "work in" + " " + lblProName.Text;
                    NotificationCancel.CreatedOn = DateTime.Now;
                    NotificationCancel.CreatedBy = Convert.ToInt32(Session["EmpID"]);
                    DC.tblNotifications.InsertOnSubmit(NotificationCancel);
                    DC.SubmitChanges();
                    tblNotification NID = (from obID in DC.tblNotifications
                                           orderby obID.NotificationID descending
                                           select obID).First();
                    tblNotificationDetail DetailCancel = new tblNotificationDetail();
                    DetailCancel.NotificationID = NID.NotificationID;
                    DetailCancel.PersonID = TeamModuleData.EmpID;
                    DetailCancel.IsAdmin = false;
                    DetailCancel.IsRead = false;
                    DetailCancel.IsNotify = false;
                    DC.tblNotificationDetails.InsertOnSubmit(DetailCancel);
                }
                tblNotification Notification = new tblNotification();
                Notification.Title = "Assign Team Leader";
                Notification.Description = "You are selected Employee for" + " " + TaskData.Title + " " + "work in" + " " + lblProName.Text;
                Notification.CreatedOn = DateTime.Now;
                Notification.CreatedBy = Convert.ToInt32(Session["EmpID"]);
                DC.tblNotifications.InsertOnSubmit(Notification);
                DC.SubmitChanges();
                tblNotification NID2 = (from obID in DC.tblNotifications
                                       orderby obID.NotificationID descending
                                       select obID).First();
                tblNotificationDetail Detail = new tblNotificationDetail();
                Detail.NotificationID = NID2.NotificationID;
                Detail.PersonID = TeamModuleData.EmpID;
                Detail.IsAdmin = false;
                Detail.IsRead = false;
                Detail.IsNotify = false;
                DC.tblNotificationDetails.InsertOnSubmit(Detail);
            }
            else
            {
                if (ddEmployee.SelectedValue != "")
                {
                    tblTeamMember NewTeamMember = new tblTeamMember();
                    NewTeamMember.EmpID = Convert.ToInt32(ddEmployee.SelectedValue);
                    NewTeamMember.TaskID = Convert.ToInt32(ltrTaskID.Text);
                    NewTeamMember.TeamID = Convert.ToInt32(TeamModuleData.TeamID);
                    NewTeamMember.CreatedOn = DateTime.Now;
                    NewTeamMember.CreatedBy = Convert.ToInt32(Session["EmpID"]);
                    DC.tblTeamMembers.InsertOnSubmit(NewTeamMember);
                    DC.SubmitChanges();
                    tblNotification Notification = new tblNotification();
                    Notification.Title = "Assign Team Leader";
                    Notification.Description = "You are selected Employee for" + " " + TaskData.Title + " " + "work in" + " " + lblProName.Text;
                    Notification.CreatedOn = DateTime.Now;
                    Notification.CreatedBy = Convert.ToInt32(Session["EmpID"]);
                    DC.tblNotifications.InsertOnSubmit(Notification);
                    DC.SubmitChanges();
                    tblNotification NID = (from obID in DC.tblNotifications
                                           orderby obID.NotificationID descending
                                           select obID).First();
                    tblNotificationDetail Detail = new tblNotificationDetail();
                    Detail.NotificationID = NID.NotificationID;
                    Detail.PersonID = TeamModuleData.EmpID;
                    Detail.IsAdmin = false;
                    Detail.IsRead = false;
                    Detail.IsNotify = false;
                    DC.tblNotificationDetails.InsertOnSubmit(Detail);
                }
            }
            TaskData.Title = txtTaskName.Text;
            TaskData.Description = txtCkEditor.Text;
            //tblModule ModuleData1 = DC.tblModules.Single(ob => ob.ModuleID == ModuleData.ModuleID);
            tblProject ProjectData = DC.tblProjects.Single(ob => ob.ProjectID == ModuleData.ProjectID);
            if (txtDDate.Text != "")
            {
                if (Convert.ToDateTime(txtDDate.Text) < ModuleData.DeadlineDate && Convert.ToDateTime(txtDDate.Text) > TaskData.AssignDate)
                {
                    if (txtDDate.Text == "")
                    {
                        if (lblDDate.Text != "Select Deadline Date")
                        {
                            TaskData.DeadlineDate = Convert.ToDateTime(lblDDate.Text);
                        }
                    }
                    else
                    {
                        TaskData.DeadlineDate = Convert.ToDateTime(txtDDate.Text);
                    }
                }
                else
                {
                    Session["errorDDate"] = true;
                }
            }
            if (ddPriority.SelectedValue != "")
            {
                TaskData.Priority = Convert.ToInt32(ddPriority.SelectedValue);
            }
            if (ddRisk.SelectedValue != "")
            {
                TaskData.Risk = Convert.ToInt32(ddRisk.SelectedValue);
            }
            TaskData.State = Convert.ToInt32(ddState.SelectedValue);
            //int cnt = DC.tblTeamMembers.Count(ob => ob.TaskID == Convert.ToInt32(ltrTaskID.Text));
            if ((DC.tblTeamMembers.Count(ob => ob.TaskID == Convert.ToInt32(ltrTaskID.Text)) > 0))
            {
                tblTeamMember MemberData = DC.tblTeamMembers.Single(ob => ob.TaskID == Convert.ToInt32(ltrTaskID.Text));
                int cntEmpAppraisal = DC.tblEmpAppraisals.Count(ob => ob.EmpID == MemberData.EmpID);
                if (MemberData.EmpID != null)
                {
                    if (cntEmpAppraisal > 0)
                    {
                        tblEmpAppraisal EmpAppraisalData = DC.tblEmpAppraisals.Single(ob => ob.EmpID == MemberData.EmpID);
                        EmpAppraisalData.Quality = EmpAppraisalData.Quality + Convert.ToDecimal(rngQuality.Text);
                        EmpAppraisalData.Avialibility = EmpAppraisalData.Avialibility + Convert.ToDecimal(rngAvialibility.Text);
                        EmpAppraisalData.Communication = EmpAppraisalData.Communication + Convert.ToDecimal(rngCommunication.Text);
                        EmpAppraisalData.Cooperation = EmpAppraisalData.Cooperation + Convert.ToDecimal(rngCooperation.Text);
                    }
                    else
                    {
                        int cntAppraisal = DC.tblTeamMembers.Count(ob => ob.TaskID == Convert.ToInt32(ltrTaskID.Text));
                        if (cntAppraisal > 0)
                        {
                            tblEmpAppraisal EmpAppraisalData = new tblEmpAppraisal();
                            EmpAppraisalData.EmpID = MemberData.EmpID;
                            EmpAppraisalData.Quality = Convert.ToDecimal(rngQuality.Text);
                            EmpAppraisalData.Avialibility = Convert.ToDecimal(rngAvialibility.Text);
                            EmpAppraisalData.Communication = Convert.ToDecimal(rngCommunication.Text);
                            EmpAppraisalData.Cooperation = Convert.ToDecimal(rngCooperation.Text);
                            EmpAppraisalData.Skills = Convert.ToDecimal(0.0);
                            EmpAppraisalData.Deadlines = Convert.ToDecimal(0.0);
                            EmpAppraisalData.CreatedOn = DateTime.Now;
                            EmpAppraisalData.CreatedBy = Convert.ToInt32(Session["EmpID"]);
                            DC.tblEmpAppraisals.InsertOnSubmit(EmpAppraisalData);
                        }
                    }
                }
            }


            DC.SubmitChanges();
            Response.Redirect("TaskDetail.aspx");
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

    protected void btnClose_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("ProjectMaster.aspx");
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

    protected void LinkButton12_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            tblTask TaskData = DC.tblTasks.Single(ob => ob.TaskID == Convert.ToInt32(ltrTaskID.Text));
            tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == TaskData.ModuleID);
            Session["ModuleID"] = ModuleData.ModuleID;
            Response.Redirect("ModuleDetail.aspx");
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            if (fileUploadTask.HasFiles)
            {
                tblTask TaskData = DC.tblTasks.Single(ob => ob.TaskID == Convert.ToInt32(ltrTaskID.Text));
                if (TaskData.SubmittedFile == null)
                {
                    string FolderName = DateTime.Now.ToString("ddMMyyyyHmmss");
                    string folderPath = Server.MapPath("UploadTaskFile/" + FolderName + "/");

                    //check whether directory (folder) exists.
                    if (!Directory.Exists(folderPath))
                    {
                        //if directory (folder) does not exists. create it.
                        Directory.CreateDirectory(folderPath);
                    }
                    foreach (HttpPostedFile uploadedfile in fileUploadTask.PostedFiles)
                    {
                        //uploadedfile.SaveAs(System.IO.Path.Combine(Server.MapPath(folderPath), uploadedfile.FileName));
                        uploadedfile.SaveAs(folderPath + Path.GetFileName(uploadedfile.FileName));
                        lblFileName.Text += string.Format("<br />{0}", uploadedfile.FileName);
                    }
                    TaskData.SubmittedFile = FolderName;
                }
                else
                {
                    foreach (HttpPostedFile uploadedfile in fileUploadTask.PostedFiles)
                    {
                        //uploadedfile.SaveAs(System.IO.Path.Combine(Server.MapPath(folderPath), uploadedfile.FileName));
                        uploadedfile.SaveAs(Server.MapPath("UploadTaskFile/" + TaskData.SubmittedFile + "/") + Path.GetFileName(uploadedfile.FileName));
                        lblFileName.Text += string.Format("<br />{0}", uploadedfile.FileName);
                    }
                }
            }
            DC.SubmitChanges();
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

    protected void lnkTaskFile_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            tblTask TaskData = DC.tblTasks.Single(ob => ob.TaskID == Convert.ToInt32(ltrTaskID.Text));
            tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == TaskData.ModuleID);
            tblProject ProjectData = DC.tblProjects.Single(ob => ob.ProjectID == ModuleData.ProjectID);
            Response.Clear();
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "filename=" + ProjectData.Title + "_Supporting_TaskFile" + ".zip");
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(Server.MapPath("UploadFiles/") + @hdnTaskFile.Value);
                zip.Save(Response.OutputStream);
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
}