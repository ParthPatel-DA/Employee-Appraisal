using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class Admin_Dashboard : System.Web.UI.Page
{
    ServiceClient DashboardObject = new ServiceClient();
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
            ((Panel)Master.FindControl("Panel1")).Visible = false;

            var dc = new DataClassesDataContext();
            int EmpCnt = dc.tblEmployees.Count(ob => ob.IsActive == true);
            lblEmp.Text = EmpCnt.ToString();

            int ClientCnt = dc.tblClients.Count(ob => ob.IsActive == true);
            lblClient.Text = ClientCnt.ToString();

            int ProCnt = dc.tblProjects.Count();
            lblPro.Text = ProCnt.ToString();

            //Chart------

            var Pro = (from ob in dc.tblProjects
                       select ob).ToList();
            int[] y = new int[Pro.Count];
            string[] x = new string[Pro.Count];
            int i = 0;
            foreach (tblProject Project in Pro)
            {
                x[i] = Project.Title;
                y[i] = dc.tblModules.Count(ob => ob.ProjectID == Project.ProjectID);
                i++;
            }
            ChartProject.Series[0].Points.DataBindXY(x, y);
            ChartProject.Series[0].ChartType = SeriesChartType.Line;
            ChartProject.ChartAreas[0].Area3DStyle.Enable3D = false;

            ChartProject.Series["Module"].BorderWidth = 3;
            //-----Chart
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

    protected void imgAddEmp_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("EmployeeReg.aspx");
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

    protected void Imagebutton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("ClientReg.aspx");
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

    protected void Imagebutton2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("Project.aspx");
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