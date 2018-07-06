using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;
using EmployeeAppraisalServiceReference;
public partial class ClientLogin : System.Web.UI.Page
{
    ServiceClient objClient = new ServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        Panellogin.Visible = true;
        Panelforgetpass.Visible = false;
        Panelchangpass.Visible = false;
        PanelSignUp.Visible = false;
        PanelVerifyEmail.Visible = false;

        if (Session["PostProjectReg"] != null)
        {
            if (Session["PostProjectReg"].ToString() == "True")
            {
                PanelSignUp.Visible = true;
                Panellogin.Visible = false;
                Panelforgetpass.Visible = false;
                Panelchangpass.Visible = false;
                PanelVerifyEmail.Visible = false;
                chkEmployee.Visible = false;
                lblEmp.Visible = false;
            }
        }
        if (Session["EmailID"] != null)
        {
            PanelSignUp.Visible = false;
            PanelVerifyEmail.Visible = true;
            Panellogin.Visible = false;
            Panelforgetpass.Visible = false;
            Panelchangpass.Visible = false;
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        IList<string> vc = objClient.MailToPerson(txtLoginEmail.Text);
        string Code;
        string Check;
        try
        {
            Session["vc"] = vc[0];
            Check = vc[1];
        }
        catch (Exception Ex)
        {
            Code = null;
            Check = null;
        }


        if (vc != null && (Check == "NotVerify" || Session["vc"] != null))
        {
            Session["EmailID"] = txtLoginEmail.Text;
            PanelVerifyEmail.Visible = true;
            Panellogin.Visible = false;
            PanelSignUp.Visible = false;
            Panelchangpass.Visible = false;
            Panelforgetpass.Visible = false;
        }
        else
        {


            if (Session["PostProject"] != null)
            {
                IList<string> Login = objClient.ClientLogin(txtLoginEmail.Text, txtLoginPassword.Text);
                if (Login[0] == "Employee")
                {
                    errorLogin.Text = "You are employee you can't post the project";
                    errorLogin.Visible = true;
                }

                else if (Login[0] == "Client")
                {
                    Session["ClientID"] = Login[1];
                    Response.Redirect("PostProject.aspx");
                }
                else
                {
                    errorLogin.Text = "Your EmailID and Password is invalid";
                    errorLogin.Visible = true;
                }
            }
            else
            {
                IList<string> Login = objClient.ClientLogin(txtLoginEmail.Text, txtLoginPassword.Text);
                if (Login[0] == "Employee")
                {
                    Session["EmpID"] = Login[1];
                    Response.Redirect("ProjectMaster.aspx");
                }
                else if (Login[0] == "Client")
                {
                    Session["ClientID"] = Login[1];
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    errorLogin.Text = "Your EmailID and Password is invalid";
                    errorLogin.Visible = true;
                }
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Panellogin.Visible = false;
        PanelSignUp.Visible = true;
    }

    protected void lkforgetpass_Click(object sender, EventArgs e)
    {
        Panellogin.Visible = false;
        Panelforgetpass.Visible = true;
    }

    protected void btncode_Click(object sender, EventArgs e)
    {
        txtcode.Visible = true;
        btnsubmit.Visible = true;
        btncode.Visible = false;
        Panelforgetpass.Visible = true;
        var EmailChecking = objClient.EmailCkecking(txtForPassEmail.Text, "Login");
        if (EmailChecking == true)
        {
            string vc;

            DateTime now = DateTime.Now;
            vc = now.ToString();
            vc = vc.GetHashCode().ToString().Trim('-');
            MailMessage Msg = new MailMessage("trackmyworkindia@gmail.com", txtForPassEmail.Text);
            Msg.Subject = "Email Verification";
            Msg.Body = "<html><head></head><body><table><tr><td>Your E-Mail :</td><td>" + txtForPassEmail.Text + "</td></tr><tr><td>Your Code :</td><td>" + vc + "</td></tr></table></body></html>";
            Msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            NetworkCredential MyCredentials = new NetworkCredential("trackmyworkindia@gmail.com", "TMW2016open");
            smtp.Credentials = MyCredentials;
            smtp.Send(Msg);
            //Panel6.Visible = true;
            Session["VCode"] = vc;
            //Label2.Text = Session["VCode"].ToString();
            //Button2.Visible = false;
            Panelforgetpass.Visible = true;
            Panellogin.Visible = false;
            errorForEmail.Visible = false;

        }
        else
        {
            errorForEmail.Text = "You are not Registered user Check Your Email";
            errorForEmail.Visible = true;
            Panelforgetpass.Visible = true;
            btncode.Visible = true;
            Panelchangpass.Visible = false;
            PanelSignUp.Visible = false;
            Panellogin.Visible = false;
            txtcode.Visible = false;
            btnsubmit.Visible = false;
            errorCode.Visible = false;
        }

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Session["VCode"].ToString() == txtcode.Text)
        {
            Panelforgetpass.Visible = false;
            Panellogin.Visible = false;
            Panelchangpass.Visible = true;
            errorCode.Visible = false;
        }
        else
        {
            Panelforgetpass.Visible = true;
            errorCode.Visible = true;
            Panellogin.Visible = false;
        }
    }

    protected void btnchandpass_Click(object sender, EventArgs e)
    {
        if (txtNewPwd.Text == txtConfirmPassword.Text)
        {
            objClient.ForgetChangePwd(txtForPassEmail.Text, txtNewPwd.Text);
            Panelchangpass.Visible = false;
            Panellogin.Visible = true;
            ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Password Changed Successfully');window.location ='ClientLogin.aspx'</script>");
        }
        else
        {
            errorChangePassword.Text = "Password don't match. Please enter same password.";
            errorChangePassword.Visible = true;
            Panellogin.Visible = false;
            Panelchangpass.Visible = true;
        }

    }

    protected void btnsignup_Click(object sender, EventArgs e)
    {
        bool CheckEmail = objClient.EmailCkecking(txtRegEmail.Text, "");
        if (CheckEmail == false)
        {
            errorEmail.Text = "Email Already Exist..";
            errorEmail.Visible = true;
            PanelSignUp.Visible = true;
            Panellogin.Visible = false;
            Panelchangpass.Visible = false;
            Panelforgetpass.Visible = false;
            PanelVerifyEmail.Visible = false;
        }
        else
        {
            if (chkEmployee.Checked == true)
            {
                if (Session["PostProjectReg"] == null)
                {
                    objClient.EmployeeRegistration(txtRegFname.Text, txtRegLname.Text, txtRegEmail.Text, txtRegPassword.Text, txtRegCNO.Text, Convert.ToInt32(null), null);
                }
            }
            else
            {
                Session["EmailID"] = txtRegEmail.Text;
                if (Session["PostProjectReg"] != null)
                {
                    objClient.ClientRegistration(txtRegFname.Text + " " + txtRegLname.Text, txtRegEmail.Text, txtRegPassword.Text, txtRegCNO.Text, null, null, null, null, Convert.ToInt32(null), Convert.ToInt32(null), Convert.ToInt32(null));
                    IList<string> Data = objClient.MailToPerson(txtRegEmail.Text);
                    Session["vc"] = Data[0];
                    PanelSignUp.Visible = false;
                    PanelVerifyEmail.Visible = true;
                    Panellogin.Visible = false;
                    Panelforgetpass.Visible = false;
                    Panelchangpass.Visible = false;
                }
                else
                {
                    objClient.ClientRegistration(txtRegFname.Text + " " + txtRegLname.Text, txtRegEmail.Text, txtRegPassword.Text, txtRegCNO.Text, null, null, null, null, Convert.ToInt32(null), Convert.ToInt32(null), Convert.ToInt32(null));
                    IList<string> Data = objClient.MailToPerson(txtRegEmail.Text);
                    Session["vc"] = Data[0];
                    PanelSignUp.Visible = false;
                    PanelVerifyEmail.Visible = true;
                    Panellogin.Visible = false;
                    Panelforgetpass.Visible = false;
                    Panelchangpass.Visible = false;
                }
            }
        }

    }

    protected void btnSubmitCode_Click(object sender, EventArgs e)
    {
        string PersonType = objClient.GetPersonType(Session["EmailID"].ToString());

        if (PersonType == "Employee")
        {
            if (Session["vc"].ToString() == txtVerificationCode.Text)
            {
                Session["EmpID"] = objClient.VerifyPerson(Session["EmailID"].ToString());
                Session.Remove("EmailID");
                ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Register and Verify Successfully');window.location ='ProjectMaster.aspx'</script>");
            }
            else
            {
                lblverify.Text = "Your Verification code is invalid.";
                lblverify.Visible = true;
            }
        }
        else if (PersonType == "Client")
        {
            if (Session["vc"].ToString() == txtVerificationCode.Text)
            {
                if (Session["PostProjectReg"] != null || Session["PostProject"] != null)
                {
                    Session["ClientID"] = objClient.VerifyPerson(Session["EmailID"].ToString());
                    Session.Remove("EmailID");
                    ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Register and Verify Successfully');window.location ='PostProject.aspx'</script>");
                }
                else
                {
                    Session["ClientID"] = objClient.VerifyPerson(Session["EmailID"].ToString());
                    Session.Remove("EmailID");
                    ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Register and Verify Successfully');window.location ='Default.aspx'</script>");
                }
            }
            else
            {
                lblverify.Text = "Your Verification code is invalid.";
                lblverify.Visible = true;
            }
        }
        else
        {
            Response.Write("sorry");
        }

    }

    protected void lnkSendCodeAgain_Click(object sender, EventArgs e)
    {
        objClient.MailToPerson(Session["EmailID"].ToString());
    }


    protected void txtRegEmail_TextChanged(object sender, EventArgs e)
    {
        bool CheckEmail = objClient.EmailCkecking(txtRegEmail.Text, "");
        if (CheckEmail == false)
        {
            errorEmail.Text = "Email Already Exist..";
            errorEmail.Visible = true;
            PanelSignUp.Visible = true;
            Panellogin.Visible = false;
            Panelchangpass.Visible = false;
            Panelforgetpass.Visible = false;
            PanelVerifyEmail.Visible = false;
        }
        else
        {
            errorEmail.Visible = false;
            PanelSignUp.Visible = true;
            Panellogin.Visible = false;
            Panelchangpass.Visible = false;
            Panelforgetpass.Visible = false;
            PanelVerifyEmail.Visible = false;
        }
    }
}


