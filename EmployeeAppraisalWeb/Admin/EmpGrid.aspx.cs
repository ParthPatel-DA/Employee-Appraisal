using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class Admin_empgrid : System.Web.UI.Page
{
    ServiceClient EmployeeObject = new ServiceClient();
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
            var DC = new DataClassesDataContext();
            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsDelete == false)
            {
                foreach (RepeaterItem item in rptEmp.Items)
                {
                    PlaceHolder Active = (PlaceHolder)item.FindControl("PlaceHolderActive");

                    Active.Visible = false;
                }
                PlaceHolderActiveHeader.Visible = false;
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
            //var DC = new DataClassesDataContext();
            //var str1 = from obj in DC.tblEmployees
            //          where obj.IsActive == true
            //          select new
            //          {
            //              obj.FirstName,
            //              obj.ContactNo,
            //              obj.CreatedOn,
            //              CBy = (from ob in DC.tblAdmins
            //                     where ob.AdminID == obj.CreatedBy
            //                     select new
            //                     {
            //                         Data = ob.FirstName + " " + ob.LastName
            //                     }).Take(1).FirstOrDefault().Data,
            //              obj.Address,
            //              obj.Landmark,
            //              obj.IsActive,
            //              obj.LastName,
            //              obj.EmailID,
            //              obj.EmpID,
            //              obj.Gender,
            //              obj.ProfilePic
            //          };

            //DC.SubmitChanges();
            rptEmp.DataSource = EmployeeObject.ViewEmployee();
            rptEmp.DataBind();
            foreach (RepeaterItem Item in rptEmp.Items)
            {
                string AdminName = "---";
                HiddenField EmpID = (HiddenField)Item.FindControl("HiddenField1");
                HiddenField CBy = (HiddenField)Item.FindControl("HiddenField2");
                HiddenField hdnImage = (HiddenField)Item.FindControl("hdnImage");
                Image img = (Image)Item.FindControl("Image2");
                if (hdnImage.Value == "")
                {
                    img.ImageUrl = "img/user-icon.png";
                }
                if (EmpID.Value != "" && CBy.Value != "" && CBy.Value != "0")
                {
                    AdminName = EmployeeObject.BindEmpCBy(Convert.ToInt32(CBy.Value));
                }
                Literal LtrCBY = (Literal)Item.FindControl("LtrCBy");
                LtrCBY.Text = AdminName;



                string Gender = "---";
                Label Gen = (Label)Item.FindControl("lblGender");
                if (Gen.Text == "1")
                {
                    Gender = "Male";
                }
                else if (Gen.Text == "2")
                {
                    Gender = "Female";
                }
                else
                {
                    Gender = "Other";
                }
                Label lblgen = (Label)Item.FindControl("lblGender");
                lblgen.Text = Gender;
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

    protected void rptEmp_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            EmployeeObject.EmpModify(Convert.ToInt32(e.CommandArgument), e.CommandName);
            BindData();
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