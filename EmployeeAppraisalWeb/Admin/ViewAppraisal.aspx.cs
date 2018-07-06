using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class Admin_ViewAppraisal : System.Web.UI.Page
{
    ServiceClient objAppraisal = new ServiceClient();
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
                BindAppraisal();
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

    private void BindAppraisal()
    {
        try
        {
            var DC = new DataClassesDataContext();

            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsInsert == false)
            {
                btnGenerate.Visible = false;
            }

            IQueryable<tblEmpAppraisal> Appraisal = (from ob in DC.tblEmpAppraisals
                                                     select ob);
            rptViewAppraisal.DataSource = Appraisal;
            rptViewAppraisal.DataBind();
            foreach (RepeaterItem item in rptViewAppraisal.Items)
            {
                HiddenField hdnEmpID = (HiddenField)item.FindControl("hdnEmpID");
                Literal ltrEmpName = (Literal)item.FindControl("ltrEmpName");
                tblEmployee EmpID = (from obj in DC.tblEmployees
                                     where obj.EmpID == Convert.ToInt32(hdnEmpID.Value)
                                     select obj).Single();
                ltrEmpName.Text = EmpID.FirstName + " " + EmpID.LastName;
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

    protected void btnAppraial_Click(object sender, EventArgs e)
    {
        try
        {
            PanelAppraisal.Visible = true;
            PanelFinalPoint.Visible = false;
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

    protected void btnFinalAppraisal_Click(object sender, EventArgs e)
    {
        try
        {
            FinalAppraisal();
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

    private void FinalAppraisal()
    {
        try
        {
            PanelAppraisal.Visible = false;
            PanelFinalPoint.Visible = true;

            var DC = new DataClassesDataContext();
            IQueryable<tblEmpAppraisalPoint> FinalPoint = (from objFinal in DC.tblEmpAppraisalPoints
                                                           select objFinal);
            rptFinalPoint.DataSource = FinalPoint;
            rptFinalPoint.DataBind();
            foreach (RepeaterItem item in rptFinalPoint.Items)
            {
                HiddenField hdnEmpID = (HiddenField)item.FindControl("hdnEmpID");
                Literal ltrEmpName = (Literal)item.FindControl("ltrEmpName");
                tblEmployee EmpID = (from obj in DC.tblEmployees
                                     where obj.EmpID == Convert.ToInt32(hdnEmpID.Value)
                                     select obj).Single();
                ltrEmpName.Text = EmpID.FirstName + " " + EmpID.LastName;
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

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            IQueryable<tblEmpAppraisal> Data = (from objData in DC.tblEmpAppraisals
                                                select objData);
            foreach (tblEmpAppraisal item in Data)
            {
                int cnt = (from objData in DC.tblEmpAppraisalPoints
                           where objData.EmpID == item.EmpID
                           select objData).Count();

                if (cnt > 0)
                {
                    tblEmpAppraisalPoint Point = DC.tblEmpAppraisalPoints.Single(ob => ob.EmpID == item.EmpID);
                    Point.AppraisalPoint = (Point.AppraisalPoint + (Convert.ToInt32(item.Skills) + Convert.ToInt32(item.Quality) + Convert.ToInt32(item.Avialibility) + Convert.ToInt32(item.Communication) + Convert.ToInt32(item.Cooperation) + Convert.ToInt32(item.ClientFeedback))) - Convert.ToInt32(item.Deadlines);
                    Point.AppraisalDate = DateTime.Now;

                }
                else
                {
                    tblEmpAppraisalPoint Point = new tblEmpAppraisalPoint();
                    Point.EmpID = item.EmpID;
                    Point.AppraisalPoint = Convert.ToInt32(item.Skills) + Convert.ToInt32(item.Quality) + Convert.ToInt32(item.Avialibility) + Convert.ToInt32(item.Communication) + Convert.ToInt32(item.Cooperation) + Convert.ToInt32(item.ClientFeedback) - Convert.ToInt32(item.Deadlines);
                    Point.AppraisalDate = DateTime.Now;
                    Point.CreatedOn = DateTime.Now;
                    DC.tblEmpAppraisalPoints.InsertOnSubmit(Point);

                }
            }
            DC.tblEmpAppraisals.DeleteAllOnSubmit(Data);
            BindAppraisal();
            DC.SubmitChanges();
            BindAppraisal();
            FinalAppraisal();
            PanelAppraisal.Visible = false;
            PanelFinalPoint.Visible = true;
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