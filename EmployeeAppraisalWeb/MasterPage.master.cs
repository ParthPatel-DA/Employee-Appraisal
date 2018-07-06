using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
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
            if (!IsPostBack)
            {

                BindData();
                if (Session["SenderID"] != null)
                {
                    divMsg.Visible = false;
                    divMsgDetail.Visible = true;
                    var DC = new DataClassesDataContext();
                    tblMessage MsgData = DC.tblMessages.Single(ob => ob.MessegeID == Convert.ToInt32(Session["MsgID"]));
                    //Session["SenderID"] = MsgData.SenderID;
                    tblEmployee EmpData = DC.tblEmployees.Single(ob => ob.EmpID == Convert.ToInt32(Session["SenderID"]));
                    ltrEmpName.Text = EmpData.FirstName + " " + EmpData.LastName;
                    ltrSubject.Text = MsgData.Subject;
                    ltrDesc.Text = MsgData.Description;
                    if (EmpData.ProfilePic == null)
                    {
                        imgEmp.ImageUrl = "Admin/img/user-icon.png";
                    }
                    else
                    {
                        imgEmp.ImageUrl = "Admin/EmpUpload/" + EmpData.ProfilePic;
                    }
                    //MsgData.IsRead = true;
                    //DC.SubmitChanges();
                    btnClose.Visible = true;
                }
                if (Session["ReceiverID"] != null)
                {
                    divMsg.Visible = false;
                    divMsgDetail.Visible = true;
                    var DC = new DataClassesDataContext();
                    //Session["ReceiverID"] = e.CommandArgument;
                    tblEmployee EmpData = DC.tblEmployees.Single(ob => ob.EmpID == Convert.ToInt32(Session["ReceiverID"]));
                    ltrEmpName.Text = EmpData.FirstName + " " + EmpData.LastName;
                    ltrSubject.Visible = false;
                    ltrDesc.Visible = false;
                    if (EmpData.ProfilePic == null)
                    {
                        imgEmp.ImageUrl = "Admin/img/user-icon.png";
                    }
                    else
                    {
                        imgEmp.ImageUrl = "Admin/EmpUpload/" + EmpData.ProfilePic;
                    }
                    btnClose.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
        }
    }

    private void BindData()
    {
        try
        {
            var DC = new DataClassesDataContext();
            tblEmployee EmpData = (from obj in DC.tblEmployees
                                   where obj.EmpID == Convert.ToInt32(Session["EmpID"])
                                   select obj).Single();
            if (EmpData.ProfilePic != null)
            {
                imgbtnProfile.ImageUrl = "Admin/EmpUpload/" + EmpData.ProfilePic;
            }
            else
            {
                imgbtnProfile.ImageUrl = "Admin/img/user-icon.png";
            }
            IQueryable<tblNotification> str = (from obj in DC.tblNotificationDetails
                                               join obj2 in DC.tblNotifications
                                               on obj.NotificationID equals obj2.NotificationID
                                               where obj.PersonID == Convert.ToInt32(Session["EmpID"]) && (obj.IsAdmin == false || obj.IsAdmin == null) && (obj.IsRead == false || obj.IsRead == null)
                                               select obj2);

            rptNotify.DataSource = str;
            rptNotify.DataBind();
            IQueryable<tblMessage> MsgData = from obj in DC.tblMessages
                                             where obj.ReceiverID == Convert.ToInt32(Session["EmpID"]) && (obj.IsRead == false || obj.IsRead == null)
                                             select obj;
            rptMSg.DataSource = MsgData;
            rptMSg.DataBind();
            //divMsg.Visible = true;
            foreach (RepeaterItem item in rptMSg.Items)
            {
                HiddenField hdnSender = (HiddenField)item.FindControl("hdnSender");
                Literal ltrName = (Literal)item.FindControl("ltrName");
                tblEmployee SenderData = (from obj in DC.tblEmployees
                                          where obj.EmpID == Convert.ToInt32(hdnSender.Value)
                                          select obj).Single();
                ltrName.Text = SenderData.FirstName + SenderData.LastName;
            }

            IQueryable<tblEmployee> EmployeeData = from obj in DC.tblEmployees
                                                   where obj.IsActive == true && obj.EmpID != Convert.ToInt32(Session["EmpID"])
                                                   select obj;
            rptEmpMsgList.DataSource = EmployeeData;
            rptEmpMsgList.DataBind();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            //ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Clear();
            Response.Redirect("ClientLogin.aspx");
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            //ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkDB_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Dashboard.aspx");
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            //ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptNotify_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            tblNotification NotiData = (from obj in DC.tblNotifications
                                        where obj.NotificationID == Convert.ToInt32(e.CommandArgument)
                                        select obj).Single();
            tblNotificationDetail NotiDetailData = (from obj in DC.tblNotificationDetails
                                                    where obj.NotificationID == NotiData.NotificationID && obj.PersonID == Convert.ToInt32(Session["EmpID"]) && (obj.IsAdmin == false || obj.IsAdmin == null)
                                                    select obj).Single();
            NotiDetailData.IsRead = true;
            DC.SubmitChanges();
            BindData();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            //ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptMSg_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
            //divMsg.Visible = false;
            //divMsgDetail.Visible = true;
            var DC = new DataClassesDataContext();
            tblMessage MsgData = DC.tblMessages.Single(ob => ob.MessegeID == Convert.ToInt32(e.CommandArgument));
            Session["MsgID"] = e.CommandArgument;
            Session["SenderID"] = MsgData.SenderID;
            tblEmployee EmpData = DC.tblEmployees.Single(ob => ob.EmpID == Convert.ToInt32(Session["SenderID"]));
            ltrEmpName.Text = EmpData.FirstName + " " + EmpData.LastName;
            ltrSubject.Text = MsgData.Subject;
            ltrDesc.Text = MsgData.Description;
            if (EmpData.ProfilePic == null)
            {
                imgEmp.ImageUrl = "Admin/img/user-icon.png";
            }
            else
            {
                imgEmp.ImageUrl = "Admin/EmpUpload/" + EmpData.ProfilePic;
            }
            MsgData.IsRead = true;
            DC.SubmitChanges();
            //btnClose.Visible = true;
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            //ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptEmpMsgList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
            //divMsg.Visible = false;
            //divMsgDetail.Visible = true;
            var DC = new DataClassesDataContext();
            Session["ReceiverID"] = e.CommandArgument;
            tblEmployee EmpData = DC.tblEmployees.Single(ob => ob.EmpID == Convert.ToInt32(Session["ReceiverID"]));
            ltrEmpName.Text = EmpData.FirstName + " " + EmpData.LastName;
            ltrSubject.Visible = false;
            ltrDesc.Visible = false;
            if (EmpData.ProfilePic == null)
            {
                imgEmp.ImageUrl = "Admin/img/user-icon.png";
            }
            else
            {
                imgEmp.ImageUrl = "Admin/EmpUpload/" + EmpData.ProfilePic;
            }
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            //ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnMsg_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            tblMessage MsgData = new tblMessage();
            MsgData.Subject = txtSubject.Text;
            MsgData.Description = txtMSg.Text;
            if (Session["SenderID"] != null)
            {
                MsgData.ReceiverID = Convert.ToInt32(Session["SenderID"]);
            }
            else
            {
                MsgData.ReceiverID = Convert.ToInt32(Session["ReceiverID"]);
            }
            MsgData.SenderID = Convert.ToInt32(Session["EmpID"]);
            MsgData.CreatedOn = DateTime.Now;
            DC.tblMessages.InsertOnSubmit(MsgData);
            DC.SubmitChanges();
            Session["ReceiverID"] = null;
            Session["SenderID"] = null;
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            //ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        try
        {
            Session["ReceiverID"] = null;
            Session["SenderID"] = null;
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["EmpID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Employee", session, 0, MACAddress);
            //ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}
