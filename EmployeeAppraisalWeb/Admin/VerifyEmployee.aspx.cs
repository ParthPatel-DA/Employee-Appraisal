using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;
using System.Net;

public partial class Admin_VerifyEmployee : System.Web.UI.Page
{
    ServiceClient objVerify = new ServiceClient();
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
                BindVerifyEmployee();
            }
            var DC = new DataClassesDataContext();
            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsUpdate == false)
            {
                divPage.Visible = false;
                divError.Visible = true;
            }
            else if (AdminData.IsDelete == false)
            {
                foreach (RepeaterItem item in rptVerifyEmployee.Items)
                {
                    PlaceHolder Delete = (PlaceHolder)item.FindControl("PlaceHolderDelete");
                    Delete.Visible = false;
                }
                PlaceHolderDeleteHeader.Visible = false;
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

    private void BindVerifyEmployee()
    {
        try
        {
            var DC = new DataClassesDataContext();
            IQueryable<tblEmployee> Employee = (from ob in DC.tblEmployees
                                                where (ob.IsVerify == false || ob.IsVerify == null) && (ob.IsVerifyByAdmin == false || ob.IsVerifyByAdmin == null)
                                                select ob);
            rptVerifyEmployee.DataSource = Employee;
            rptVerifyEmployee.DataBind();
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
    public static bool CheckForInternetConnection()
    {
        try
        {
            using (var client = new WebClient())
            {
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
        }
        catch
        {
            return false;
        }
    }
    protected void rptVerifyEmployee_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        try
        {
            var DC = new DataClassesDataContext();

            if (e.CommandName == "Email")
            {
                if (CheckForInternetConnection() == true)
                {
                    tblEmployee EmpVerify = (from obj in DC.tblEmployees
                                             where obj.EmpID == Convert.ToInt32(e.CommandArgument)
                                             select obj).Single();
                    string Code = objVerify.SendMail(EmpVerify.EmailID);
                    EmpVerify.VerifyCode = Code;
                    EmpVerify.IsVerifyByAdmin = true;
                    DC.SubmitChanges();
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Please Check your Internet Connection');", true);
                }
            }


            //DeleteVerify Employee
            if (e.CommandName == "Delete")
            {
                var Emp = (from obj in DC.tblEmployees
                           where obj.EmpID == Convert.ToInt32(e.CommandArgument)
                           select obj).Single();
                DC.tblEmployees.DeleteOnSubmit(Emp);
                DC.SubmitChanges();
            }
            BindVerifyEmployee();
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