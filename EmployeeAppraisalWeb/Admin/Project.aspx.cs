using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class Admin_AssignProject : System.Web.UI.Page
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
                fillCatDrop();
                fillClientDrop();

                var DC = new DataClassesDataContext();
                tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
                if (AdminData.IsInsert == false)
                {
                    divPage.Visible = false;
                    divError.Visible = true;
                }

                if (Request.QueryString["PostProjectID"] != null)
                {
                    tblPostProject Data = (from ob in DC.tblPostProjects
                                           where ob.ProjectID == Convert.ToInt32(Request.QueryString["PostProjectID"])
                                           select ob).Single();
                    txtPname.Text = Data.Title;
                    ddClient.SelectedValue = Data.ClientID.ToString();
                    string SuperID;
                    try
                    {
                        SuperID = (from obj in DC.tblCategories
                                   where obj.CategoryID == Convert.ToInt32(Data.CategoryID)
                                   select obj.SuperID).Single().ToString();
                    }
                    catch (Exception Ex)
                    {
                        SuperID = "0";
                        lblOther.Text = "(Other)";
                        lblOther.Visible = true;
                    }

                    IQueryable<tblCategory> Category;
                    if (SuperID != null && SuperID != "0")
                    {
                        Category = (from obCat in DC.tblCategories
                                    where obCat.SuperID == Convert.ToInt32(SuperID)
                                    select obCat);
                    }
                    else
                    {
                        Category = (from obCat in DC.tblCategories
                                    where obCat.SuperID == null
                                    select obCat);
                    }

                    ddCategory.DataSource = Category;
                    ddCategory.DataValueField = "CategoryID";
                    ddCategory.DataTextField = "CategoryName";
                    ddCategory.DataBind();
                    ddCategory.SelectedValue = Data.CategoryID.ToString();

                    int super = 0;
                    ddLanguage.DataSource = ProjectObject.FillLanguageProject(Convert.ToInt32(Data.CategoryID), super);
                    ddLanguage.DataTextField = "LanguageName";
                    ddLanguage.DataValueField = "LanguageID";
                    ddLanguage.DataBind();
                    ddLanguage.Items.Insert(0, new ListItem("Select Language", ""));

                    TimeSpan Days = Convert.ToDateTime(Data.DeadlineDate) - Convert.ToDateTime(Data.CreateOn);
                    txtDays.Text = Convert.ToInt32(Days.TotalDays).ToString();

                    txtDes.Text = Data.Description;
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
    private void fillCatDrop()
    {
        try
        {
            ddCategory.DataSource = ProjectObject.GetCatDrop();
            ddCategory.DataValueField = "CategoryID";
            ddCategory.DataTextField = "CategoryName";
            ddCategory.DataBind();
            ddCategory.Items.Insert(0, new ListItem("Select Category for Project", ""));
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

    protected void ddCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int cnt = ProjectObject.CountSubCategory(Convert.ToInt32(ddCategory.SelectedValue));
            ddCategory.DataSource = ProjectObject.GetSubCategory(Convert.ToInt32(ddCategory.SelectedValue));
            ddCategory.DataValueField = "CategoryID";
            ddCategory.DataTextField = "CategoryName";
            ddCategory.DataBind();
            if (cnt <= 0)
            {
                int super = 0;
                ddLanguage.DataSource = ProjectObject.FillLanguageProject(Convert.ToInt32(ddCategory.SelectedValue), super);
                ddLanguage.DataTextField = "LanguageName";
                ddLanguage.DataValueField = "LanguageID";
                ddLanguage.DataBind();
                ddLanguage.Items.Insert(0, new ListItem("Select Language", ""));
            }
            else
            {
                ddCategory.Items.Insert(0, new ListItem("Select a Sub Category", ""));
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

    public void fillClientDrop()
    {
        try
        {
            ddClient.DataSource = ProjectObject.FillClientProject();
            ddClient.DataValueField = "ClientID";
            ddClient.DataTextField = "ClientName";
            ddClient.DataBind();
            ddClient.Items.Insert(0, new ListItem("Select Client for Project", ""));
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

    protected void btnAddProject_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            //tblProject objpro = new tblProject();
            //objpro.ClientID = Convert.ToInt32(ddClient.SelectedValue);
            //objpro.CategoryID = Convert.ToInt32(ddCategory.SelectedValue);
            //objpro.LanguageID = Convert.ToInt32(ddLanguage.SelectedValue);
            //objpro.Title = txtTitle.Text;
            //objpro.Description = txtDes.Text;
            //objpro.AssignDate = DateTime.Now;
            //objpro.DeadlineDate = Convert.ToDateTime(txtDeadline.Text);

            //DC.tblProjects.InsertOnSubmit(objpro);
            //DC.SubmitChanges();
            DateTime DeadLineDate = DateTime.Now.AddDays(Convert.ToInt32(txtDays.Text));
            string Date = Convert.ToDateTime(DeadLineDate).ToString("dddd, MMMM dd, yyyy h:mm:ss tt");
            int LanguageID;
            if (ddLanguage.SelectedValue != "")
            {
                LanguageID = Convert.ToInt32(ddLanguage.SelectedValue);
            }
            else
            {
                LanguageID = Convert.ToInt32(0);
            }
            ProjectObject.AddProject(txtPname.Text, Convert.ToInt32(ddClient.SelectedValue), Convert.ToInt32(ddCategory.SelectedValue), LanguageID, txtDes.Text, Convert.ToInt32(Session["AdminID"]), Convert.ToDateTime(Date));

            //PostProejct Assign=true

            if (Request.QueryString["PostProjectID"] != null)
            {
                tblPostProject Assign = (from obj in DC.tblPostProjects
                                         where obj.ProjectID == Convert.ToInt32(Request.QueryString["PostProjectID"])
                                         select obj).Single();
                Assign.IsAssign = true;
                DC.SubmitChanges();
            }
            Response.Redirect("ViewProject.aspx");
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


    protected void ddLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int catID = 0;
            ddLanguage.DataSource = ProjectObject.FillLanguageProject(catID, Convert.ToInt32(ddLanguage.SelectedValue));
            ddLanguage.DataTextField = "LanguageName";
            ddLanguage.DataValueField = "LanguageID";
            ddLanguage.DataBind();
            ddLanguage.Items.Insert(0, new ListItem("Select sub Language", ""));
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