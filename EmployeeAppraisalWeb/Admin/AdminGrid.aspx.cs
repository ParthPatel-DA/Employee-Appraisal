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
    ServiceClient AdminObject = new ServiceClient();
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
            if (AdminData.IsUpdate == false)
            {
                foreach (RepeaterItem item in rptViewAdmin.Items)
                {
                    PlaceHolder Update = (PlaceHolder)item.FindControl("PlaceHolderUpdate");
                    Update.Visible = false;
                }
                PlaceHolderUpdateHeader.Visible = false;
            }
            if (AdminData.IsDelete == false)
            {
                foreach (RepeaterItem item in rptViewAdmin.Items)
                {
                    PlaceHolder Delete = (PlaceHolder)item.FindControl("PlaceHolderDelete");
                    Delete.Visible = false;
                }
                PlaceHolderDeleteHeader.Visible = false;
            }



            if (AdminObject.ResSubAdmin(Convert.ToInt32(Session["AdminID"])) == false)
            {
                rptViewAdmin.Visible = false;
                divPage.Visible = false;
                divError.Visible = true;
            }
            else
            {
                divPage.Visible = true;
                divError.Visible = false;
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
            rptViewAdmin.DataSource = AdminObject.BindAdminGrid(Convert.ToInt32(Session["AdminID"]));
            rptViewAdmin.DataBind();
            foreach (RepeaterItem Item in rptViewAdmin.Items)
            {
                string AdminName = "---";
                HiddenField AdminID = (HiddenField)Item.FindControl("HiddenField1");
                HiddenField CBy = (HiddenField)Item.FindControl("HiddenField2");
                HiddenField hdnImage = (HiddenField)Item.FindControl("hdnImage");
                Image img = (Image)Item.FindControl("Image2");
                if (hdnImage.Value == "")
                {
                    img.ImageUrl = "img/user-icon.png";
                }
                if (AdminID.Value != "" && CBy.Value != "")
                {
                    int CBY = Convert.ToInt32(CBy.Value);

                    AdminName = AdminObject.BindCBy(CBY);
                }
                Literal LtrCBY = (Literal)Item.FindControl("LtrCBy");
                LtrCBY.Text = AdminName;
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

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            AdminObject.AdminModify(Convert.ToInt32(e.CommandArgument), e.CommandName);
            //else if (e.CommandName == "Super")
            //{
            //    tblAdmin result = (from u in DC.tblAdmins
            //                       where u.AdminID == ID
            //                       select u).Single();
            //    result.IsSuper = true;
            //    tblAdmin result1 = (from u in DC.tblAdmins
            //                        where u.AdminID == Convert.ToInt32(Session["AdminID"])
            //                        select u).Single();
            //    result1.IsSuper = false;
            //    DC.SubmitChanges();
            //    Response.Redirect("empgrid.aspx");
            //}
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