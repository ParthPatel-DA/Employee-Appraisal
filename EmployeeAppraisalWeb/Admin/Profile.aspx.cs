using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        //var DC = new DataClassesDataContext();
        //var str = from obj in DC.tblAdmins
        //          where obj.IsActive == true && obj.AdminID != Convert.ToInt32(Session["AdminID"])
        //          select new
        //          {
        //              Data = obj.FirstName + " " + obj.LastName,
        //              obj.ContactNo,
        //              obj.Image,
        //              obj.IsActive,
        //              obj.IsDelete,
        //              obj.IsInsert,
        //              obj.IsUpdate,
        //              obj.UserID,
        //              obj.AdminID,
        //          };
    }
}