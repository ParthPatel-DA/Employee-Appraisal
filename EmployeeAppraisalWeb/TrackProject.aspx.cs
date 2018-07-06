using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EmployeeAppraisalServiceReference;
using System.Net.NetworkInformation;

public partial class TrackProject : System.Web.UI.Page
{
    ServiceClient objProject = new ServiceClient();
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
                BindProject();
                BindClient();
                if (Session["ClientID"] == null)
                {
                    Response.Redirect("ClientLogin.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void BindClient()
    {
        try
        {
            if (Session["ClientID"] != null)
            {
                var DC = new DataClassesDataContext();
                tblClient Client = DC.tblClients.Single(ob => ob.ClientID == Convert.ToInt32(Session["ClientID"]));
                lblName.Text = Client.ClientName;
                lblEmail.Text = Client.EmailID;
                lblCNO.Text = Client.ContactNo;
                lblComName.Text = Client.CompanyName;
                lblURL.Text = Client.WebsiteURL;
                lnkURl.PostBackUrl = "http://" + Client.WebsiteURL;

                if (Client.ImageName != null)
                {
                    ImgImage.ImageUrl = "ClientUpload/" + Client.ImageName;
                    hdnImage.Value = Client.ImageName;
                }
                else
                {
                    ImgImage.ImageUrl = "~/Admin/img/user-icon.png";
                }
            }
            else
            {
                Response.Redirect("ClientLogin.aspx");
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private string EncryptPass(string password)
    {
        string strmsg = string.Empty;
        byte[] encode = new byte[password.Length];
        encode = Encoding.UTF8.GetBytes(password);

        strmsg = Convert.ToBase64String(encode);

        return strmsg;
    }
    private void BindProject()
    {
        try
        {
            //SliderProject
            //rptProjectView.DataSource = objProject.BindClientProject(Convert.ToInt32(Session["ClientID"]));
            //rptProjectView.DataBind();

            //TotalProject
            //int cnt = rptProjectView.Items.Count;
            //foreach (RepeaterItem item in rptProjectView.Items)
            //{
            //    Literal ltr = (Literal)item.FindControl("ltrItemCount");
            //    ltr.Text = cnt.ToString();
            //}

            //SliderButton
            //rptSlider.DataSource = objProject.BindClientProject(Convert.ToInt32(Session["ClientID"]));
            //rptSlider.DataBind();

            //Project
            rptProject.DataSource = objProject.BindClientProject(Convert.ToInt32(Session["ClientID"]));
            rptProject.DataBind();
            foreach (RepeaterItem item in rptProject.Items)
            {
                Label lblADate = (Label)item.FindControl("lblADate");
                Label lblDDate = (Label)item.FindControl("lblDDate");
                Label lblDays = (Label)item.FindControl("lblDays");
                HiddenField hdnDays = (HiddenField)item.FindControl("hdnDays");
                lblADate.Text = Convert.ToDateTime(lblADate.Text).ToShortDateString();
                lblDDate.Text = Convert.ToDateTime(lblDDate.Text).ToShortDateString();
                TimeSpan Days = Convert.ToDateTime(hdnDays.Value) - DateTime.Now;
                if (Days.TotalDays > 0)
                {
                    lblDays.Text = Convert.ToInt32(Days.TotalDays).ToString() + " " + "Days left to complete";
                }
                else
                {
                    lblDays.Text = "Completed";
                }
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }


    protected void rptProjectView_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if (e.CommandName == "TrackProject")
        //{
        //    Session["ProjectID"] = e.CommandArgument;
        //    var Data = objProject.GetProjectDetail(Convert.ToInt32(Session["ProjectID"]));
        //    ltrProjectName.Text = Data[1];
        //    rptProjectTracking.DataSource = objProject.BindNewProject(Convert.ToInt32(Session["ProjectID"]));
        //    rptProjectTracking.DataBind();
        //    PanelProjectStatus.Visible = true;
        //    //PanelProjectView.Visible = false;
        //}
    }


    //protected void lnkProject_Click(object sender, EventArgs e)
    //{
    //    PanelProjectStatus.Visible = true;
    //    PanelProject.Visible = false;
    //}

    protected void rptProject_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "TrackProject")
            {
                PanelUserProfle.Visible = false;
                PanelChangePass.Visible = false;
                Session["ProjectID"] = e.CommandArgument;
                var Data = objProject.GetProjectDetail(Convert.ToInt32(Session["ProjectID"]));
                ltrProjectName.Text = Data[1];
                ltrProTitle.Text = Data[1];
                ltrProDescription.Text = Data[2];
                ltrAssignDate.Text = Convert.ToDateTime(Data[3]).ToShortDateString();
                ltrDeadLineDate.Text = Convert.ToDateTime(Data[4]).ToShortDateString();
                lblTrackDays.Text = Convert.ToDateTime(Data[4]).ToShortDateString();
                TimeSpan Days = Convert.ToDateTime(lblTrackDays.Text) - DateTime.Now;
                if (Days.TotalDays > 0)
                {
                    lblTrackDays.Text = Convert.ToInt32(Days.TotalDays).ToString() + " " + "Days left to complete";
                }
                else
                {
                    lblTrackDays.Text = "Completed";
                }
                rptProjectTracking.DataSource = objProject.BindNewProjectTrack(Convert.ToInt32(Session["ProjectID"]));
                rptProjectTracking.DataBind();
                foreach (RepeaterItem item in rptProjectTracking.Items)
                {
                    HiddenField hdnModuleID = (HiddenField)item.FindControl("hdnModuleID");
                    var DC = new DataClassesDataContext();
                    int cnt = DC.tblTasks.Count(ob => ob.ModuleID == Convert.ToInt32(hdnModuleID.Value));
                    if (cnt > 0)
                    {
                        Panel PanelStatus = (Panel)item.FindControl("PanelStatus");
                        Literal ltrProStatus = (Literal)item.FindControl("ltrProStatus");
                        Literal ltrDescription = (Literal)item.FindControl("ltrTrackDescription");
                        int Per = objProject.GetProjectPoint(Convert.ToInt32(hdnModuleID.Value));
                        PanelStatus.Style.Add("width", Per.ToString() + "%");
                        ltrProStatus.Text = Per.ToString() + "%";
                    }
                    else
                    {
                        item.Visible = false;
                    }

                }
                PanelProjectStatus.Visible = true;
                PanelProject.Visible = false;
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            PanelProject.Visible = true;
            PanelProjectStatus.Visible = false;
            PanelChangePass.Visible = false;
            PanelUserProfle.Visible = true;
            BindProject();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            //Lable
            lblName.Visible = false;
            lblEmail.Visible = false;
            lblCNO.Visible = false;
            lblComName.Visible = false;
            lblURL.Visible = false;

            //TextBox
            txtName.Visible = true;
            txtEmail.Visible = true;
            txtCNO.Visible = true;
            txtComName.Visible = true;
            txtURl.Visible = true;
            PanelUploader.Visible = true;

            btnEdit.Visible = false;
            btnChPass.Visible = false;
            btnUpdate.Visible = true;

            var DC = new DataClassesDataContext();
            tblClient ClientDetail = DC.tblClients.Single(ob => ob.ClientID == Convert.ToInt32(Session["ClientID"]));
            txtName.Text = ClientDetail.ClientName;
            txtEmail.Text = ClientDetail.EmailID;
            txtCNO.Text = ClientDetail.ContactNo;
            txtComName.Text = ClientDetail.CompanyName;
            txtURl.Text = ClientDetail.WebsiteURL;
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            var FileName = "";
            if (FileProfile.HasFile)
            {
                string strPic = FileProfile.FileName;
                var path = Server.MapPath("ClientUpload/");
                DateTime date = DateTime.Now;
                string strdate = date.ToString();

                var charsToRemove = new string[] { "%", "-", ":", " ", "\\", "/" };
                foreach (var c in charsToRemove)
                {
                    strdate = strdate.Replace(c, string.Empty);
                    strPic = strPic.Replace(c, string.Empty);
                }
                //filename = strdate + strPic;
                FileName = strPic;
                FileProfile.SaveAs(path + "/" + FileName);
            }
            else
            {
                FileName = hdnImage.Value;
            }


            tblClient ClientUpdate = DC.tblClients.Single(ob => ob.ClientID == Convert.ToInt32(Session["ClientID"]));
            ClientUpdate.ClientName = txtName.Text;
            ClientUpdate.EmailID = txtEmail.Text;
            ClientUpdate.ContactNo = txtCNO.Text;
            ClientUpdate.CompanyName = txtComName.Text;
            ClientUpdate.WebsiteURL = txtURl.Text;
            if (FileProfile.FileName != "")
            {
                ClientUpdate.ImageName = FileProfile.FileName;
            }
            else
            {
                ClientUpdate.ImageName = FileName;
            }
            DC.SubmitChanges();
            BindClient();
            Response.Redirect("TrackProject.aspx");
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Client", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnChPass_Click(object sender, EventArgs e)
    {
        try
        {
            PanelChangePass.Visible = true;
            PanelProject.Visible = false;
            PanelUserProfle.Visible = false;
            btnChPass.Visible = false;
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            objProject.AddErrorLog(ref ex, PageName, "Client", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void txtCurPass_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            tblClient ClientPass = DC.tblClients.Single(ob => ob.ClientID == Convert.ToInt32(Session["ClientID"]));

            if (ClientPass.Password != EncryptPass(txtCurPass.Text))
            {
                errorPassword.Text = "Invalid Current Password!!";
                errorPassword.Visible = true;
            }
            else
            {
                errorPassword.Visible = false;
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            objProject.AddErrorLog(ref ex, PageName, "Client", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();
            tblClient ClientPass = DC.tblClients.Single(ob => ob.ClientID == Convert.ToInt32(Session["ClientID"]));

            if (ClientPass.Password != EncryptPass(txtCurPass.Text))
            {
                errorPassword.Text = "Invalid Current Password!!";
                errorPassword.Visible = true;
            }
            else
            {
                errorPassword.Visible = false;
                if (txtNewPass.Text == txtComNewPass.Text)
                {
                    ClientPass.Password = EncryptPass(txtNewPass.Text);
                    DC.SubmitChanges();
                    ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Password Changed Successfully');window.location ='TrackProject.aspx'</script>");
                }
                else
                {
                    errorPassword.Text = "New Password and Confirm doesn't Match!!";
                    errorPassword.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            objProject.AddErrorLog(ref ex, PageName, "Client", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}