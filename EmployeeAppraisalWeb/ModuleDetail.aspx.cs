using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Ionic.Zip;
using EmployeeAppraisalServiceReference;
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
                var Data = ProjectObject.BindProjectModule(Convert.ToInt32(Session["ModuleID"]));

                lblProName.Text = Session["ProjectName"].ToString();
                txtModuleName.Text = Data.Title;
                ltrModuleID.Text = Data.ModuleID.ToString();
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
                lblTask.Text = ProjectObject.BindTotalTask(Convert.ToInt32(Data.ModuleID)).ToString();
                rptTaskList.DataSource = ProjectObject.GetTaskList(Convert.ToInt32(Data.ModuleID));
                rptTaskList.DataBind();
                rptTaskFile.DataSource = ProjectObject.GetTaskList(Convert.ToInt32(Data.ModuleID));
                rptTaskFile.DataBind();
                foreach (RepeaterItem item in rptTaskFile.Items)
                {
                    HiddenField hdn = (HiddenField)item.FindControl("hdnSubmittedFile");
                    if (hdn.Value == "")
                    {
                        item.Visible = false;
                    }
                }
                int cnt = DC.tblTeamModules.Count(ob => ob.ModuleID == Convert.ToInt32(ltrModuleID.Text));
                if (cnt > 0)
                {
                    tblTeamModule ModuleData = DC.tblTeamModules.Single(ob => ob.ModuleID == Convert.ToInt32(ltrModuleID.Text));
                    if (ModuleData.EmpID == null)
                    {
                        lblTeamLeader.Text = "Unassigned";
                    }
                    else
                    {
                        int cntEmp = DC.tblEmployees.Count(ob => ob.EmpID == ModuleData.EmpID);
                        if (cntEmp > 0)
                        {
                            tblEmployee EmpData = DC.tblEmployees.Single(ob => ob.EmpID == ModuleData.EmpID);
                            lblTeamLeader.Text = EmpData.FirstName + " " + EmpData.LastName;
                            if (EmpData.ProfilePic != null)
                            {
                                imgTeamLeader.ImageUrl = "Admin/EmpUpload/" + EmpData.ProfilePic;
                            }
                            else
                            {
                                imgTeamLeader.ImageUrl = "img/notassigned-user.svg";
                            }
                        }
                        else
                        {
                            lblTeamLeader.Text = "Unassigned";
                            imgTeamLeader.ImageUrl = "img/notassigned-user.svg";
                        }

                    }
                }
                else
                {
                    lblTeamLeader.Text = "Unassigned";
                    imgTeamLeader.ImageUrl = "img/notassigned-user.svg";
                }

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
                    ddState.Items.RemoveAt(0);
                    //rngQuality.Attributes.CssStyle.Add("")
                    //PanelPlanning.Visible = false;
                }

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
                    ddState.Items.RemoveAt(0);
                    //rngQuality.Attributes.CssStyle.Add("")
                    //PanelPlanning.Visible = false;
                }
                else if (Session["PersonType"].ToString() == "TeamLeader")
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
            if (Session["errorDDate"] != null)
            {
                tblModule errorModule = DC.tblModules.Single(ob => ob.ModuleID == Convert.ToInt32(ltrModuleID.Text));
                tblProject errorProject = DC.tblProjects.Single(ob => ob.ProjectID == errorModule.ProjectID);
                errorDDate.Text = "Please Enter Date Between " + Convert.ToDateTime(errorModule.AssignDate).ToShortDateString() + " and " + Convert.ToDateTime(errorProject.DeadlineDate).ToShortDateString() + ".";
                errorDDate.Visible = true;
                Session["errorDDate"] = null;
            }
            if (Session["errorClose"] != null)
            {
                errorDDate.Text = "All Task are not Completed.";
                errorDDate.Visible = true;
                Session["errorClose"] = null;
            }

            //rptTaskList.DataSource =
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
            ddTeamLeader.DataSource = ProjectObject.GetTeamLeader(Convert.ToInt32(Session["ProjectID"]), Convert.ToInt32(Session["ModuleID"]));
            ddTeamLeader.DataValueField = "EmpID";
            ddTeamLeader.DataTextField = "FirstName";
            ddTeamLeader.DataBind();
            ddTeamLeader.Items.Insert(0, new ListItem("Select Team Leader", ""));
            ddTeamLeader.Visible = true;
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
            tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == Convert.ToInt32(ltrModuleID.Text));
            tblTeam TeamData = DC.tblTeams.Single(ob => ob.ModuleID == Convert.ToInt32(ltrModuleID.Text));
            int cnt = DC.tblTeamModules.Count(ob => ob.ModuleID == Convert.ToInt32(ltrModuleID.Text));
            if (cnt > 0)
            {
                tblTeamModule TeamModuleNewData = DC.tblTeamModules.Single(ob => ob.ModuleID == Convert.ToInt32(ltrModuleID.Text));
                if (ddTeamLeader.SelectedValue != "")
                {
                    tblNotification NotificationCancel = new tblNotification();
                    NotificationCancel.Title = "Team Leader Cancelling";
                    NotificationCancel.Description = "You are cancel Team Leader for" + " " + ModuleData.Title + " " + "work in" + " " + lblProName.Text;
                    NotificationCancel.CreatedOn = DateTime.Now;
                    NotificationCancel.CreatedBy = Convert.ToInt32(Session["EmpID"]);
                    DC.tblNotifications.InsertOnSubmit(NotificationCancel);
                    DC.SubmitChanges();
                    tblNotification NID = (from obID in DC.tblNotifications
                                           orderby obID.NotificationID descending
                                           select obID).First();
                    tblNotificationDetail DetailCancel = new tblNotificationDetail();
                    DetailCancel.NotificationID = NID.NotificationID;
                    DetailCancel.PersonID = TeamModuleNewData.EmpID;
                    DetailCancel.IsAdmin = false;
                    DetailCancel.IsRead = false;
                    DetailCancel.IsNotify = false;
                    DC.tblNotificationDetails.InsertOnSubmit(DetailCancel);
                    TeamModuleNewData.EmpID = Convert.ToInt32(ddTeamLeader.SelectedValue);
                    //Notification Cancellation

                }
                //Notification
                tblNotification Notification = new tblNotification();
                Notification.Title = "Assign Team Leader";
                Notification.Description = "You are selected Team Leader for" + " " + ModuleData.Title + " " + "work in" + " " + lblProName.Text;
                Notification.CreatedOn = DateTime.Now;
                Notification.CreatedBy = Convert.ToInt32(Session["EmpID"]);
                DC.tblNotifications.InsertOnSubmit(Notification);
                DC.SubmitChanges();
                tblNotification NID2 = (from obID in DC.tblNotifications
                                       orderby obID.NotificationID descending
                                       select obID).First();
                tblNotificationDetail Detail = new tblNotificationDetail();
                Detail.NotificationID = NID2.NotificationID;
                Detail.PersonID = TeamModuleNewData.EmpID;
                Detail.IsAdmin = false;
                Detail.IsRead = false;
                Detail.IsNotify = false;
                DC.tblNotificationDetails.InsertOnSubmit(Detail);
            }
            else
            {

                if (ddTeamLeader.SelectedValue != "")
                {
                    tblTeamModule TeamModuleNewData = new tblTeamModule();
                    TeamModuleNewData.EmpID = Convert.ToInt32(ddTeamLeader.SelectedValue);
                    TeamModuleNewData.TeamID = TeamData.TeamID;
                    TeamModuleNewData.CreatedOn = DateTime.Now;
                    TeamModuleNewData.CreatedBy = Convert.ToInt32(Session["EmpID"]);
                    TeamModuleNewData.ModuleID = Convert.ToInt32(ltrModuleID.Text);
                    DC.tblTeamModules.InsertOnSubmit(TeamModuleNewData);
                    DC.SubmitChanges();
                    //Notification
                    tblNotification Notification = new tblNotification();
                    Notification.Title = "Assign Team Leader";
                    Notification.Description = "You are selected Team Leader for" + " " + ModuleData.Title + " " + "work in" + " " + lblProName.Text;
                    Notification.CreatedOn = DateTime.Now;
                    Notification.CreatedBy = Convert.ToInt32(Session["EmpID"]);
                    DC.tblNotifications.InsertOnSubmit(Notification);
                    DC.SubmitChanges();
                    tblNotification NID = (from obID in DC.tblNotifications
                                           orderby obID.NotificationID descending
                                           select obID).First();
                    tblNotificationDetail Detail = new tblNotificationDetail();
                    Detail.NotificationID = NID.NotificationID;
                    Detail.PersonID = TeamModuleNewData.EmpID;
                    Detail.IsAdmin = false;
                    Detail.IsRead = false;
                    Detail.IsNotify = false;
                    DC.tblNotificationDetails.InsertOnSubmit(Detail);
                }


            }
            ModuleData.Title = txtModuleName.Text;
            ModuleData.Description = txtCkEditor.Text;
            tblProject ProjectData = DC.tblProjects.Single(ob => ob.ProjectID == ModuleData.ProjectID);
            if (txtDDate.Text != "")
            {
                if (Convert.ToDateTime(txtDDate.Text) < ProjectData.DeadlineDate && Convert.ToDateTime(txtDDate.Text) > ModuleData.AssignDate)
                {
                    if (txtDDate.Text == "")
                    {
                        if (lblDDate.Text != "Select Deadline Date")
                        {
                            ModuleData.DeadlineDate = Convert.ToDateTime(lblDDate.Text);
                        }
                    }
                    else
                    {
                        ModuleData.DeadlineDate = Convert.ToDateTime(txtDDate.Text);
                    }
                }
                else
                {
                    Session["errorDDate"] = true;
                }
            }
            if (ddPriority.SelectedValue != "")
            {
                ModuleData.Priority = Convert.ToInt32(ddPriority.SelectedValue);
            }
            if (ddRisk.SelectedValue != "")
            {
                ModuleData.Risk = Convert.ToInt32(ddRisk.SelectedValue);
            }
            if (ddState.SelectedIndex == 3)
            {
                int TaskPanding = DC.tblTasks.Count(ob => ob.ModuleID == Convert.ToInt32(ltrModuleID.Text) && ob.State != 4);
                if (TaskPanding > 0)
                {
                    Session["errorClose"] = true;
                }
                else
                {
                    ModuleData.State = Convert.ToInt32(ddState.SelectedValue);
                }
            }
            else
            {
                ModuleData.State = Convert.ToInt32(ddState.SelectedValue);
            }

            if ((DC.tblTeamModules.Count(ob => ob.ModuleID == Convert.ToInt32(ltrModuleID.Text))) > 0)
            {
                tblTeamModule MemberData = DC.tblTeamModules.Single(ob => ob.ModuleID == Convert.ToInt32(ltrModuleID.Text));
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
                        int cntAppraisal = DC.tblTeamModules.Count(ob => ob.ModuleID == Convert.ToInt32(ltrModuleID.Text));
                        //Response.Redirect(cntAppraisal.ToString());
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            if (fileUploadTask.HasFiles)
            {
                tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == Convert.ToInt32(ltrModuleID.Text));
                if (ModuleData.TaskFile == null)
                {
                    string FolderName = DateTime.Now.ToString("ddMMyyyyHmmss");
                    string folderPath = Server.MapPath("UploadFiles/" + FolderName + "/");

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
                    ModuleData.TaskFile = FolderName;
                }
                else
                {
                    foreach (HttpPostedFile uploadedfile in fileUploadTask.PostedFiles)
                    {
                        //uploadedfile.SaveAs(System.IO.Path.Combine(Server.MapPath(folderPath), uploadedfile.FileName));
                        uploadedfile.SaveAs(Server.MapPath("UploadFiles/" + ModuleData.TaskFile + "/") + Path.GetFileName(uploadedfile.FileName));
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

    protected void rptTaskFile_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            if (e.CommandName == "Download")
            {
                tblTask TaskData = DC.tblTasks.Single(ob => ob.TaskID == Convert.ToInt32(e.CommandArgument));
                tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == TaskData.ModuleID);
                tblProject ProjectData = DC.tblProjects.Single(ob => ob.ProjectID == ModuleData.ProjectID);
                Response.Clear();
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "filename=" + ProjectData.Title + "_" + ModuleData.Title + "_" + TaskData.Title + ".zip");
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddDirectory(Server.MapPath("UploadTaskFile/") + @TaskData.SubmittedFile);
                    zip.Save(Response.OutputStream);
                }
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

    protected void rptTaskList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "View")
            {
                Session["TaskID"] = e.CommandArgument;
                Response.Redirect("TaskDetail.aspx");
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