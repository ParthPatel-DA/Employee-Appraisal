using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Ionic.Zip;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class Admin_ProjectDetail : System.Web.UI.Page
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
            if (Session["AdminID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindData();
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void BindData()
    {
        try
        {
            if (Request.QueryString["ProjectID"] != null)
            {
                var DC = new DataClassesDataContext();
                IList<string> Data = ProjectObject.GetProjectDetail(Convert.ToInt32(Request.QueryString["ProjectID"]));
                ltrProjectName.Text = Data[1];

                //ProjectManager
                tblProject Project = DC.tblProjects.Single(obj => obj.ProjectID == Convert.ToInt32(Data[0]));
                tblEmployee Manager = DC.tblEmployees.Single(ob => ob.EmpID == Project.ManagerID);
                ltrManager.Text = Manager.FirstName + " " + Manager.LastName;

                rptModule.DataSource = ProjectObject.BindModule(Convert.ToInt32(Request.QueryString["ProjectID"]));
                rptModule.DataBind();

                foreach (RepeaterItem Item in rptModule.Items)
                {
                    HiddenField ModuleID = (HiddenField)Item.FindControl("hdnModuleID");
                    Repeater TaskList = (Repeater)Item.FindControl("rptTrackTask");
                    Literal ltrTeamLeader = (Literal)Item.FindControl("ltrTeamLeader");

                    //TeamLeader
                    int cnt = DC.tblTeamModules.Count(obTeam => obTeam.ModuleID == Convert.ToInt32(ModuleID.Value));
                    if (cnt > 0)
                    {
                        tblTeamModule TeamLeader = DC.tblTeamModules.Single(obTeam => obTeam.ModuleID == Convert.ToInt32(ModuleID.Value));
                        tblEmployee TeamLeaderData = DC.tblEmployees.Single(ob => ob.EmpID == TeamLeader.EmpID);
                        ltrTeamLeader.Text = TeamLeaderData.FirstName + " " + TeamLeaderData.LastName;
                    }
                    else
                    {
                        ltrTeamLeader.Text = "Unassigned";
                    }

                    TaskList.DataSource = ProjectObject.BindTask(Convert.ToInt32(ModuleID.Value));
                    TaskList.DataBind();
                    foreach (RepeaterItem Items in TaskList.Items)
                    {
                        string Duration = "---";
                        //string DurationLeft = "---";
                        HiddenField hdnCreatedOn = (HiddenField)Items.FindControl("hdnCreatedOn");
                        HiddenField hdnAssignDay = (HiddenField)Items.FindControl("hdnAssignDay");
                        HiddenField hdnSubDate = (HiddenField)Items.FindControl("hdnSubDate");
                        HiddenField hdnIsActive = (HiddenField)Items.FindControl("hdnIsActive");
                        HiddenField hdnIsComplete = (HiddenField)Items.FindControl("hdnIsComplete");
                        HiddenField hdnTaskID = (HiddenField)Items.FindControl("hdnTaskID");
                        Literal ltrEmp = (Literal)Items.FindControl("ltrEmp");
                        //Literal ltrStatus = (Literal)Items.FindControl("ltrStatus");
                        Literal ltrAssignDate = (Literal)Items.FindControl("ltrAssignDate");
                        Literal ltrSubmitionDate = (Literal)Items.FindControl("ltrSubmitionDate");
                        string val = hdnSubDate.Value;
                        if (hdnTaskID.Value != "")
                        {
                            tblTask TaskData = DC.tblTasks.Single(ob => ob.TaskID == Convert.ToInt32(hdnTaskID.Value));
                            if ((DC.tblTeamMembers.Count(ob => ob.TaskID == TaskData.TaskID)) > 0)
                            {
                                tblTeamMember TeamMemberData = DC.tblTeamMembers.Single(ob => ob.TaskID == TaskData.TaskID);
                                tblEmployee EmpData = DC.tblEmployees.Single(ob => ob.EmpID == TeamMemberData.EmpID);
                                ltrEmp.Text = EmpData.FirstName + " " + EmpData.LastName;
                            }
                            else
                            {
                                ltrEmp.Text = "---";
                            }
                        }
                        if (hdnAssignDay.Value != "" && hdnSubDate.Value != "")
                        {
                            TimeSpan Days = Convert.ToDateTime(hdnSubDate.Value) - Convert.ToDateTime(hdnAssignDay.Value);
                            Duration = Convert.ToInt32(Days.TotalDays).ToString();
                            //TimeSpan DaysLeft = Convert.ToDateTime(hdnSubDate.Value) - DateTime.Now;
                            //DurationLeft = Convert.ToInt32(DaysLeft.TotalDays).ToString();

                        }
                        else if (hdnAssignDay.Value == "" && hdnSubDate.Value == "")
                        {
                            TimeSpan Days = Convert.ToDateTime(hdnSubDate.Value) - Convert.ToDateTime(hdnCreatedOn.Value);
                            Duration = Convert.ToInt32(Days.TotalDays).ToString();
                        }
                        Literal ltrDuration = (Literal)Items.FindControl("ltrDuration");
                        //Literal ltrDurationLeft = (Literal)Items.FindControl("ltrDurationLeft");
                        ltrDuration.Text = Duration + " Days";
                        //if (Convert.ToInt32(DurationLeft) < 0)
                        //{
                        //    ltrDurationLeft.Text = "Completed";
                        //}
                        //else
                        //{
                        //    ltrDurationLeft.Text = DurationLeft + " DaysLeft";
                        //}

                        //ProjectStatus
                        //if (hdnIsActive.Value == "True" && (hdnIsComplete.Value == "" || hdnIsComplete.Value == "False") && ltrSubmitionDate.Text != "")
                        //{
                        //    ltrStatus.Text = "Resolve";
                        //}
                        //else if (hdnIsActive.Value == "True" && (hdnIsComplete.Value == "" || hdnIsComplete.Value == "False"))
                        //{
                        //    ltrStatus.Text = "Running";
                        //    ltrSubmitionDate.Text = "---";
                        //}
                        //else if (hdnIsActive.Value == "False" && (hdnIsComplete.Value == "" || hdnIsComplete.Value == "False"))
                        //{
                        //    ltrStatus.Text = "Panding";
                        //    ltrSubmitionDate.Text = "---";
                        //}
                        //else if (hdnIsActive.Value == "True" && hdnIsComplete.Value == "True")
                        //{
                        //    ltrStatus.Text = "Completed";
                        //    ltrDurationLeft.Text = "Completed";
                        //}
                        //else
                        //{
                        //    ltrStatus.Text = "---";
                        //    ltrSubmitionDate.Text = "---";
                        //}
                    }
                }
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkTrack_Click(object sender, EventArgs e)
    {
        try
        {
            //var DC = new DataClassesDataContext();
            //tblProject ProjectData = DC.tblProjects.Single(ob => ob.ProjectID == Convert.ToInt32(Request.QueryString["ProjectID"]));
            //tblModule ModuleData = DC.tblModules.Single(ob => ob.Module ob.ProjectID == ProjectData.ProjectID);
            //tblTask TaskData = DC.tblTasks.Single(ob => ob.ModuleID == ModuleData.ModuleID);
            //Response.Clear();
            //Response.ContentType = "application/zip";
            //Response.AddHeader("content-disposition", "filename=" + ProjectData.Title + "_" + ModuleData.Title + "_" + TaskData.Title + ".zip");
            //using (ZipFile zip = new ZipFile())
            //{
            //    zip.AddDirectory(Server.MapPath("UploadTaskFile/") + @TaskData.SubmittedFile);
            //    zip.Save(Response.OutputStream);
            //}
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}