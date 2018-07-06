using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class Admin_AddData : System.Web.UI.Page
{
    ServiceClient objCategory = new ServiceClient();
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
                FillCategory();
                //FillLanguage();
                lnkNewCategory.Visible = true;
                lnkNewLanguage.Visible = true;
            }
            var DC = new DataClassesDataContext();
            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsInsert == false)
            {
                divPage.Visible = false;
                divError.Visible = true;
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

    //private void FillLanguage()
    //{
    //    ddLanguage.DataSource = objCategory.GetLanguage();
    //    ddLanguage.DataValueField = "LanguageID";
    //    ddLanguage.DataTextField = "LanguageName";
    //    ddLanguage.DataBind();
    //    ddLanguage.Items.Insert(0, new ListItem("Select a Language", ""));
    //}

    private void FillCategory()
    {
        try
        {
            ddCategory.DataSource = objCategory.GetCatDrop();
            ddCategory.DataValueField = "CategoryID";
            ddCategory.DataTextField = "categoryName";
            ddCategory.DataBind();
            ddCategory.Items.Insert(0, new ListItem("Select a Category", ""));
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



    protected void lnkNewCategory_Click(object sender, EventArgs e)
    {
        try
        {
            lnkNewCategory.Visible = false;
            txtCategory.Visible = true;
            btnSubmitCategory.Visible = true;
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

    protected void lnkNewLanguage_Click(object sender, EventArgs e)
    {
        try
        {
            lnkNewLanguage.Visible = false;
            txtLanguage.Visible = true;
            btnSubmitLanguage.Visible = true;
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
            var Category = objCategory.GetSubCategory(Convert.ToInt32(ddCategory.SelectedValue));
            if (Category != null)
            {
                //Category
                ddSubCategory.DataSource = Category;
                ddSubCategory.DataValueField = "CategoryID";
                ddSubCategory.DataTextField = "CategoryName";
                ddSubCategory.DataBind();
                ddSubCategory.Items.Insert(0, new ListItem("Select a Sub Category", ""));
                ddSubCategory.Visible = true;

                //Language
                ddLanguage.DataSource = objCategory.GetLanguage(Convert.ToInt32(ddCategory.SelectedValue));
                ddLanguage.DataValueField = "LanguageID";
                ddLanguage.DataTextField = "LanguageName";
                ddLanguage.DataBind();
                ddLanguage.Items.Insert(0, new ListItem("Select Language", ""));
                ddLanguage.Visible = true;
            }
            else
            {
                //Category
                ddSubCategory.DataSource = Category;
                ddSubCategory.DataValueField = "CategoryID";
                ddSubCategory.DataTextField = "CategoryName";
                ddSubCategory.DataBind();
                ddSubCategory.Items.Insert(0, new ListItem("Select a Sub Category", ""));
                ddSubCategory.Visible = false;

                //Language
                ddLanguage.DataSource = objCategory.GetLanguage(Convert.ToInt32(ddCategory.SelectedValue));
                ddLanguage.DataValueField = "LanguageID";
                ddLanguage.DataTextField = "LanguageName";
                ddLanguage.DataBind();
                ddLanguage.Items.Insert(0, new ListItem("Select Language", ""));
                ddLanguage.Visible = false;
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

    protected void ddSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var Category = objCategory.GetSubCategory(Convert.ToInt32(ddSubCategory.SelectedValue));
            if (Category != null)
            {
                ddAnotherCategory.DataSource = Category;
                ddAnotherCategory.DataValueField = "CategoryID";
                ddAnotherCategory.DataTextField = "CategoryName";
                ddAnotherCategory.DataBind();
                ddAnotherCategory.Items.Insert(0, new ListItem("Select a Another Category", ""));
                ddAnotherCategory.Visible = true;

                //Language
                ddLanguage.DataSource = objCategory.GetLanguage(Convert.ToInt32(ddSubCategory.SelectedValue));
                ddLanguage.DataValueField = "LanguageID";
                ddLanguage.DataTextField = "LanguageName";
                ddLanguage.DataBind();
                ddLanguage.Items.Insert(0, new ListItem("Select Language", ""));
                ddLanguage.Visible = true;
            }
            else
            {
                ddAnotherCategory.DataSource = Category;
                ddAnotherCategory.DataValueField = "CategoryID";
                ddAnotherCategory.DataTextField = "CategoryName";
                ddAnotherCategory.DataBind();
                ddAnotherCategory.Items.Insert(0, new ListItem("Select a Another Category", ""));
                ddAnotherCategory.Visible = false;

                //Language
                ddLanguage.DataSource = objCategory.GetLanguage(Convert.ToInt32(ddSubCategory.SelectedValue));
                ddLanguage.DataValueField = "LanguageID";
                ddLanguage.DataTextField = "LanguageName";
                ddLanguage.DataBind();
                ddLanguage.Items.Insert(0, new ListItem("Select Language", ""));
                ddLanguage.Visible = false;
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

    protected void ddAnotherCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var Category = objCategory.GetSubCategory(Convert.ToInt32(ddAnotherCategory.SelectedValue));
            if (Category != null)
            {
                ddNewCategory.DataSource = Category;
                ddNewCategory.DataValueField = "CategoryID";
                ddNewCategory.DataTextField = "CategoryName";
                ddNewCategory.DataBind();
                ddNewCategory.Items.Insert(0, new ListItem("Select a Another Category", " "));
                ddNewCategory.Visible = true;

                //Language
                ddLanguage.DataSource = objCategory.GetLanguage(Convert.ToInt32(ddAnotherCategory.SelectedValue));
                ddLanguage.DataValueField = "LanguageID";
                ddLanguage.DataTextField = "LanguageName";
                ddLanguage.DataBind();
                ddLanguage.Items.Insert(0, new ListItem("Select Language", ""));
                ddLanguage.Visible = true;
            }
            else
            {
                ddNewCategory.DataSource = Category;
                ddNewCategory.DataValueField = "CategoryID";
                ddNewCategory.DataTextField = "CategoryName";
                ddNewCategory.DataBind();
                ddNewCategory.Items.Insert(0, new ListItem("Select a Another Category", ""));
                ddNewCategory.Visible = false;

                //Language
                ddLanguage.DataSource = objCategory.GetLanguage(Convert.ToInt32(ddAnotherCategory.SelectedValue));
                ddLanguage.DataValueField = "LanguageID";
                ddLanguage.DataTextField = "LanguageName";
                ddLanguage.DataBind();
                ddLanguage.Items.Insert(0, new ListItem("Select Language", ""));
                ddLanguage.Visible = true;
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


    protected void btnSubmitCategory_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            int Cat = (from ob in DC.tblCategories
                       where ob.CategoryName == txtCategory.Text
                       select ob).Count();
            if (Cat > 0)
            {
                errorCategory.Visible = true;
            }
            else
            {
                int CategoryID;
                if (ddNewCategory.SelectedValue != "")
                {
                    CategoryID = Convert.ToInt32(ddNewCategory.SelectedValue);
                }
                else if (ddAnotherCategory.SelectedValue != "")
                {
                    CategoryID = Convert.ToInt32(ddAnotherCategory.SelectedValue);
                }
                else if (ddSubCategory.SelectedValue != "")
                {
                    CategoryID = Convert.ToInt32(ddSubCategory.SelectedValue);
                }
                else if (ddCategory.SelectedValue != "")
                {
                    CategoryID = Convert.ToInt32(ddCategory.SelectedValue);
                }
                else
                {
                    CategoryID = 0;
                }
                objCategory.AddCategory(txtCategory.Text, CategoryID, Convert.ToInt32(Session["AdminID"]));
                Response.Redirect("AddData.aspx");
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

    protected void ddLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var Language = objCategory.GetSubLanguage(Convert.ToInt32(ddLanguage.SelectedValue));

            if (Language != null)
            {
                ddSubLanguage.DataSource = Language;
                ddSubLanguage.DataValueField = "LanguageID";
                ddSubLanguage.DataTextField = "LanguageName";
                ddSubLanguage.DataBind();
                ddSubLanguage.Items.Insert(0, new ListItem("Select a Language", ""));
                ddSubLanguage.Visible = true;
            }
            else
            {
                ddSubLanguage.DataSource = Language;
                ddSubLanguage.DataValueField = "LanguageID";
                ddSubLanguage.DataTextField = "LanguageName";
                ddSubLanguage.DataBind();
                ddSubLanguage.Items.Insert(0, new ListItem("Select a Language", ""));
                ddSubLanguage.Visible = false;
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

    protected void btnSubmitLanguage_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            int Cat = (from ob in DC.tblLanguages
                       where ob.LanguageName == txtLanguage.Text
                       select ob).Count();
            if (Cat > 0)
            {
                errorLanguage.Visible = true;
            }
            else
            {
                int LanguageID;
                int CategoryID;
                if (ddNewSubCategory.SelectedValue != "")
                {
                    if (ddLanguage.SelectedValue != "")
                    {
                        LanguageID = Convert.ToInt32(ddLanguage.SelectedValue);
                        CategoryID = 0;
                    }
                    else
                    {
                        LanguageID = 0;
                        CategoryID = Convert.ToInt32(ddNewSubCategory.SelectedValue);
                    }
                }
                else if (ddNewCategory.SelectedValue != "")
                {
                    if (ddLanguage.SelectedValue != "")
                    {
                        LanguageID = Convert.ToInt32(ddLanguage.SelectedValue);
                        CategoryID = 0;
                    }
                    else
                    {
                        LanguageID = 0;
                        CategoryID = Convert.ToInt32(ddNewCategory.SelectedValue);
                    }
                }
                else if (ddAnotherCategory.SelectedValue != "")
                {
                    if (ddLanguage.SelectedValue != "")
                    {
                        LanguageID = Convert.ToInt32(ddLanguage.SelectedValue);
                        CategoryID = 0;
                    }
                    else
                    {
                        LanguageID = 0;
                        CategoryID = Convert.ToInt32(ddAnotherCategory.SelectedValue);
                    }
                }
                else if (ddSubCategory.SelectedValue != "")
                {
                    if (ddLanguage.SelectedValue != "")
                    {
                        LanguageID = Convert.ToInt32(ddLanguage.SelectedValue);
                        CategoryID = 0;
                    }
                    else
                    {
                        LanguageID = 0;
                        CategoryID = Convert.ToInt32(ddSubCategory.SelectedValue);
                    }
                }
                else if (ddCategory.SelectedValue != "")
                {
                    if (ddLanguage.SelectedValue != "")
                    {
                        LanguageID = Convert.ToInt32(ddLanguage.SelectedValue);
                        CategoryID = 0;
                    }
                    else
                    {
                        LanguageID = 0;
                        CategoryID = Convert.ToInt32(ddCategory.SelectedValue);
                    }
                }
                else
                {
                    LanguageID = 0;
                    CategoryID = 0;
                }
                objCategory.AddLanguage(txtLanguage.Text, CategoryID, LanguageID, Convert.ToInt32(Session["AdminID"]));
                Response.Redirect("AddData.aspx");
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



    protected void NewCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var Category = objCategory.GetSubCategory(Convert.ToInt32(ddNewCategory.SelectedValue));
            if (Category != null)
            {
                ddNewSubCategory.DataSource = Category;
                ddNewSubCategory.DataValueField = "CategoryID";
                ddNewSubCategory.DataTextField = "CategoryName";
                ddNewSubCategory.DataBind();
                ddNewSubCategory.Items.Insert(0, new ListItem("Select a Another Category", ""));
                ddNewSubCategory.Visible = true;

                //Language
                ddLanguage.DataSource = objCategory.GetLanguage(Convert.ToInt32(ddNewCategory.SelectedValue));
                ddLanguage.DataValueField = "LanguageID";
                ddLanguage.DataTextField = "LanguageName";
                ddLanguage.DataBind();
                ddLanguage.Items.Insert(0, new ListItem("Select Language", ""));
                ddLanguage.Visible = true;
            }
            else
            {
                ddNewSubCategory.DataSource = Category;
                ddNewSubCategory.DataValueField = "CategoryID";
                ddNewSubCategory.DataTextField = "CategoryName";
                ddNewSubCategory.DataBind();
                ddNewSubCategory.Items.Insert(0, new ListItem("Select a Another Category", ""));
                ddNewSubCategory.Visible = false;

                //Language
                ddLanguage.DataSource = objCategory.GetLanguage(Convert.ToInt32(ddNewCategory.SelectedValue));
                ddLanguage.DataValueField = "LanguageID";
                ddLanguage.DataTextField = "LanguageName";
                ddLanguage.DataBind();
                ddLanguage.Items.Insert(0, new ListItem("Select Language", ""));
                ddLanguage.Visible = true;
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

    protected void ddNewSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var Category = objCategory.GetSubCategory(Convert.ToInt32(ddSubCategory.SelectedValue));

            if (Category != null)
            {
                //Language
                ddLanguage.DataSource = objCategory.GetLanguage(Convert.ToInt32(ddNewSubCategory.SelectedValue));
                ddLanguage.DataValueField = "LanguageID";
                ddLanguage.DataTextField = "LanguageName";
                ddLanguage.DataBind();
                ddLanguage.Items.Insert(0, new ListItem("Select Language", ""));
                ddLanguage.Visible = true;
            }
            else
            {
                //Language
                ddLanguage.DataSource = objCategory.GetLanguage(Convert.ToInt32(ddNewSubCategory.SelectedValue));
                ddLanguage.DataValueField = "LanguageID";
                ddLanguage.DataTextField = "LanguageName";
                ddLanguage.DataBind();
                ddLanguage.Items.Insert(0, new ListItem("Select Language", ""));
                ddLanguage.Visible = true;
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
}