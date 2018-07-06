using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class AboutUs : System.Web.UI.Page
{
    ServiceClient ObjectAboutUS = new ServiceClient();
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
        if (!IsPostBack)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                //int session = Convert.ToInt32(Session["ClientID"].ToString());
                string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                string MACAddress = GetMacAddress();
                AddErrorLog(ref ex, PageName, "Client", 0, 0, MACAddress);
                ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
            }
        }
    }

    private void BindData()
    {
        try
        {
            var DC = new DataClassesDataContext();
            var data = (from obj in DC.tblEmployees
                        orderby obj.EmpID ascending
                        select obj).Take(4);

            rptAboutus.DataSource = data;
            rptAboutus.DataBind();

            foreach (RepeaterItem Item in rptAboutus.Items)
            {
                HiddenField hdn = (HiddenField)Item.FindControl("hdfgen");
                HiddenField hdnImage = (HiddenField)Item.FindControl("hdnImage");
                Image img = (Image)Item.FindControl("imgEmp");
                Label lblgen = (Label)Item.FindControl("lblGen");
                if (hdn.Value == "1")
                {
                    lblgen.Text = "Bussness Man";
                }
                else
                {
                    lblgen.Text = "Bussness Women";
                }
                tblEmployee EmpData = (from obj in DC.tblEmployees
                                       where obj.EmpID == Convert.ToInt32(hdnImage.Value)
                                       select obj).Single();
                if(EmpData.ProfilePic != null)
                {
                    img.ImageUrl = "Admin/EmpUpload/" + EmpData.ProfilePic;
                }
                else
                {
                    img.ImageUrl = "Admin/img/user-icon.png";
                }
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

}