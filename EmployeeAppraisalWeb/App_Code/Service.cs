using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net.Mail;
using System.Net;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    // Same Function
   
    private string Encryptdata(string password)
    {
        string strmsg = string.Empty;
        byte[] encode = new byte[password.Length];
        encode = Encoding.UTF8.GetBytes(password);

        strmsg = Convert.ToBase64String(encode);

        return strmsg;
    }

    public string SendMail(string Email)
    {
        string vc;
        DateTime now = DateTime.Now;
        vc = now.ToString();
        vc = vc.GetHashCode().ToString().Trim('-');
        MailMessage Msg = new MailMessage("trackmyworkindia@gmail.com", Email);
        Msg.Subject = "Email Verification";
        //Msg.Body = "<html><head></head><body><table><tr><td>Your E-Mail :</td><td>" + Email + "</td></tr><tr><td>Your Code :</td><td>" + vc + "</td></tr></table></body></html>";
        Msg.Body = "<!DOCTYPE html><html><head><title>Track My Work</title> <meta charset=\"utf - 8\"><meta name=\"viewport\" content=\"width = device - width, initial - scale = 1\"><meta http-equiv=\"X - UA - Compatible\" content=\"IE = edge\" /><style type=\"text / css\"> /* CLIENT-SPECIFIC STYLES */ body, table, td, a{-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;} /* Prevent WebKit and Windows mobile changing default text sizes */ table, td{mso-table-lspace: 0pt; mso-table-rspace: 0pt;} /* Remove spacing between tables in Outlook 2007 and up */ img{-ms-interpolation-mode: bicubic;} /* Allow smoother rendering of resized image in Internet Explorer */ /* RESET STYLES */ img{border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none;} table{border-collapse: collapse !important;} body{height: 100% !important; margin: 0 !important; padding: 0 !important; width: 100% !important;} /* iOS BLUE LINKS */ a[x-apple-data-detectors] { color: inherit !important; text-decoration: none !important; font-size: inherit !important; font-family: inherit !important; font-weight: inherit !important; line-height: inherit !important; } /* MOBILE STYLES */ @media screen and (max-width: 525px) { /* ALLOWS FOR FLUID TABLES */ .wrapper { width: 100% !important; max-width: 100% !important; } /* ADJUSTS LAYOUT OF LOGO IMAGE */ .logo img { margin: 0 auto !important; } /* USE THESE CLASSES TO HIDE CONTENT ON MOBILE */ .mobile-hide { display: none !important; } .img-max { max-width: 100% !important; width: 100% !important; height: auto !important; } /* FULL-WIDTH TABLES */ .responsive-table { width: 100% !important; } /* UTILITY CLASSES FOR ADJUSTING PADDING ON MOBILE */ .padding { padding: 10px 5% 15px 5% !important; } .padding-meta { padding: 30px 5% 0px 5% !important; text-align: center; } .no-padding { padding: 0 !important; } .section-padding { padding: 50px 15px 50px 15px !important; } /* ADJUST BUTTONS ON MOBILE */ .mobile-button-container { margin: 0 auto; width: 100% !important; } .mobile-button { padding: 15px !important; border: 0 !important; font-size: 16px !important; display: block !important; } } /* ANDROID CENTER FIX */ div[style*=\"margin: 16px 0; \"] { margin: 0 !important; }</style></head><body style=\"margin: 0 !important; padding: 0 !important; \"><!-- HIDDEN PREHEADER TEXT --><div style=\"display: none; font - size: 1px; color: #fefefe; line-height: 1px; font-family: Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;\"> Entice the open with some amazing preheader text. Use a little mystery and get those subscribers to read through...</div><!-- HEADER --><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"> <tr> <td align=\"center\" style=\" background:#008bff;\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 500px;\" class=\"wrapper\"> <tr style=\" background:#008bff;\"> <td align=\"center\" valign=\"top\" style=\"padding: 15px 0;\" class=\"logo\"> <h1 style=\"color:white; background:#008bff; font-family:calibri; font-size:40px;\">Track My Work</h1> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td bgcolor=\"#ffffff\" align=\"center\" style=\"padding: 70px 15px 70px 15px;\" class=\"section-padding\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 500px;\" class=\"responsive-table\"> <tr> <td> <!-- HERO IMAGE --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td> <!-- COPY --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td align=\"center\" style=\"font-size: 25px; font-family: Helvetica, Arial, sans-serif; color: #333333; padding-top: 30px;\" class=\"padding\">Your Email id is</td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0 0 0; font-size: 16px; line-height: 25px; font-family: Helvetica, Arial, sans-serif; color: #666666;\" class=\"padding\">" + Email + "</td> </tr> <tr> <td align=\"center\" style=\"font-size: 25px; font-family: Helvetica, Arial, sans-serif; color: #333333; padding-top: 30px;\" class=\"padding\">Your Verification Code is</td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0 0 0; font-size: 16px; line-height: 25px; font-family: Helvetica, Arial, sans-serif; color: #666666;\" class=\"padding\">" + vc + "</td> </tr> </table> </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0px; background:#424242; color:white;\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <!-- UNSUBSCRIBE COPY --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"max-width: 500px;\" class=\"responsive-table\"> <tr> <td align=\"center\" style=\"font-size: 12px; line-height: 18px; font-family: Helvetica, Arial, sans-serif; color:white;\"> <b>Track My Work</b> by:- Renown Infosys <span style=\"font-family: Arial, sans-serif; font-size: 12px; color:white;\">&nbsp;&nbsp;</span> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr></table></body></html>";
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
        return vc;
    }


    // AddErrorLog

    //public void AddErrorLog(ref Exception strException, string PageName, string UserType, int UserID, int AdminID, string MACAddress = null)
    //{
    //    var DC = new DataClassesDataContext();
    //    //Insert record in ErrorLog
    //    tblError objError = new tblError();
    //    objError.PageName = PageName;
    //    objError.Description = strException.Message.ToString();
    //    objError.CreatedOn = Convert.ToDateTime(DateTime.Now);
    //    objError.UserType = UserType;
    //    if (UserID != 0)
    //    {
    //        objError.UserID = UserID;
    //    }
    //    else
    //    {
    //        objError.UserID = null;
    //    }
    //    if (AdminID != 0)
    //    {
    //        objError.AdminID = AdminID;
    //    }
    //    else
    //    {
    //        objError.AdminID = null;
    //    }
    //    if (MACAddress != null)
    //    {
    //        objError.MacAddress = MACAddress;
    //    }
    //    else
    //    {
    //        objError.MacAddress = null;
    //    }
    //    DC.tblErrors.InsertOnSubmit(objError);
    //    DC.SubmitChanges();
    //}
    
    public IQueryable<tblSkill> ViewSkill()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblSkill> strskill = from obj in DC.tblSkills select obj;
        return strskill;
    }

    public void AddSkill(string SkillName, int CBY, string SSkill)
    {
        var DC = new DataClassesDataContext();

        tblSkill skill = new tblSkill();
        skill.SkillName = SkillName;
        skill.CreatedBy = CBY;
        skill.CreatedOn = DateTime.Now;
        if (SSkill == null)
        {
            skill.SuperSkill = null;
        }
        else
        {
            skill.SuperSkill = Convert.ToInt32(SSkill);
        }
        DC.tblSkills.InsertOnSubmit(skill);
        DC.SubmitChanges();
    }

    // \AddSkill.aspx

    // AdminGrid.aspx
    public IQueryable<tblAdmin> ViewAddmin()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblAdmin> stradmin = from obj in DC.tblAdmins select obj;
        return stradmin;
    }

    public bool ResSubAdmin(int AdminID)
    {
        var DC = new DataClassesDataContext();
        tblAdmin result = (from u in DC.tblAdmins
                           where u.AdminID == AdminID
                           select u).SingleOrDefault();
        return Convert.ToBoolean(result.IsSuper);
    }

    public IQueryable<tblAdmin> BindAdminGrid(int AdminID)
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblAdmin> AdminData = from obj in DC.tblAdmins
                                         where obj.IsActive == true && obj.AdminID != AdminID
                                         select obj;

        DC.SubmitChanges();
        return AdminData;
    }

    public string BindCBy(int AdminID)
    {
        var DC = new DataClassesDataContext();
        var CreatedBy = (from obj in DC.tblAdmins
                         where obj.AdminID == AdminID
                         select obj).FirstOrDefault();
        string AdminName = CreatedBy.FirstName + " " + CreatedBy.LastName;
        return AdminName;
    }

    public void AdminModify(int ID, string ComName)
    {
        var DC = new DataClassesDataContext();
        if (ComName == "Insert")
        {
            tblAdmin result = (from u in DC.tblAdmins
                               where u.AdminID == ID
                               select u).Single();
            if (result.IsInsert == true)
            {
                result.IsInsert = false;
            }
            else
            {
                result.IsInsert = true;
            }
            DC.SubmitChanges();
        }
        else if (ComName == "Update")
        {
            tblAdmin result = (from u in DC.tblAdmins
                               where u.AdminID == ID
                               select u).Single();
            if (result.IsUpdate == true)
            {
                result.IsUpdate = false;
            }
            else
            {
                result.IsUpdate = true;
            }
            DC.SubmitChanges();
        }
        else if (ComName == "Delete")
        {
            tblAdmin result = (from u in DC.tblAdmins
                               where u.AdminID == ID
                               select u).Single();
            if (result.IsDelete == true)
            {
                result.IsDelete = false;
            }
            else
            {
                result.IsDelete = true;
            }
            DC.SubmitChanges();
        }
        else if (ComName == "Active")
        {
            tblAdmin result = (from u in DC.tblAdmins
                               where u.AdminID == ID
                               select u).Single();
            if (result.IsActive == true)
            {
                result.IsActive = false;
            }
            DC.SubmitChanges();
        }
        //else if (e.CommandName == "AllCheck")
        //{
        //    Response.Redirect("ok");
        //}
    }

    // \AdminGrid.aspx

    // CMS.aspx
    public IQueryable<tblCM> CMSFillDD()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblCM> strCMSFillDD = from obj in DC.tblCMs where obj.IsActive == true select obj;
        return strCMSFillDD;
    }

    public string CMSFillEdit(int CMSID)
    {
        var DC = new DataClassesDataContext();
        string strCMSContent = (from obj in DC.tblCMs where obj.CMSID == CMSID select obj.Content).FirstOrDefault();
        DC.SubmitChanges();
        return strCMSContent;
    }

    public void CMSInsert(string Title, string content, int CBy)
    {
        var DC = new DataClassesDataContext();
        tblCM tblCMS = new tblCM();
        tblCMS.Title = Title;
        tblCMS.Content = content;
        tblCMS.CreatedBY = CBy;
        tblCMS.CreatedOn = DateTime.Now;
        tblCMS.IsActive = true;
        DC.tblCMs.InsertOnSubmit(tblCMS);
        DC.SubmitChanges();
    }

    public void CMSEdit(string Title, string content, int CMSID)
    {
        var DC = new DataClassesDataContext();
        tblCM strEditCMS = (from obj in DC.tblCMs
                            where obj.CMSID == Convert.ToInt32(CMSID)
                            select obj).Single();
        strEditCMS.Title = Title;
        strEditCMS.Content = content;
        strEditCMS.ModifyOn = DateTime.Now;
        DC.SubmitChanges();
    }

    // \CMS.aspx

    // Inquiry.aspx
    public IQueryable<tblInquiry> ViewInquiry()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblInquiry> strinquiry = from obj in DC.tblInquiries select obj;
        return strinquiry;
    }

    // \Inquiry.aspx

    // ViewPostProject.aspx

    public IQueryable<tblPostProject> GetPostedProject()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblPostProject> Data = from obj in DC.tblPostProjects
                                          where obj.IsAssign == null || obj.IsAssign == false
                                          select obj;
        return Data;
    }

    public string GetClientNamePostedProject(int ClientID)
    {
        var DC = new DataClassesDataContext();
        string ClientName = (from obj in DC.tblClients
                             where obj.ClientID == ClientID
                             select obj.ClientName).Single();
        return ClientName;
    }

    public string GetCategoryNamePostProject(int CategoryID)
    {
        var DC = new DataClassesDataContext();
        string CategoryName = (from obj in DC.tblCategories
                               where obj.CategoryID == CategoryID
                               select obj.CategoryName).Single();
        return CategoryName;
    }


    // \ViewPostProject.aspx

    // Project.aspx

    public IQueryable<tblClient> FillClientProject()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblClient> drop = (from ob in DC.tblClients
                                      where ob.IsActive == true
                                      select ob);
        return drop;
    }

    public int CountSubCategory(int value)
    {
        var DC = new DataClassesDataContext();
        int cnt = 0;
        cnt = (from ob in DC.tblCategories
               where ob.SuperID == Convert.ToInt32(value)
               select ob).Count();
        return cnt;
    }

    public IQueryable<tblLanguage> FillLanguageProject(int CatID, int value)
    {
        var DC = new DataClassesDataContext();
        if (CatID == 0)
        {
            IQueryable<tblLanguage> LangData = from obj in DC.tblLanguages
                                               where obj.SuperID == value
                                               select obj;
            int cnt = (from obj in DC.tblLanguages
                       where obj.SuperID == value
                       select obj).Count();
            if (cnt > 0)
            {
                return LangData;
            }
            else
            {
                return null;
            }

        }
        else if (value == 0)
        {
            IQueryable<tblLanguage> LangData = from obj in DC.tblLanguages
                                               where obj.CategoryID == CatID
                                               select obj;
            return LangData;
        }
        else
        {
            IQueryable<tblLanguage> LangData = from obj in DC.tblLanguages
                                               where obj.SuperID == null
                                               select obj;
            return LangData;
        }
    }

    public void AddProject(string Title, int ClientID, int CatID, int LanID, string Desc, int AdminID, DateTime DeadLine)
    {
        var DC = new DataClassesDataContext();

        tblProject Project = new tblProject();
        Project.Title = Title;
        Project.ClientID = ClientID;
        Project.CategoryID = CatID;
        Project.LanguageID = LanID;
        Project.DeadlineDate = DeadLine;
        Project.Description = Desc;
        Project.CreatedOn = DateTime.Now;
        Project.CreatedBy = AdminID;
        Project.IsActive = false;
        DC.tblProjects.InsertOnSubmit(Project);
        DC.SubmitChanges();

    }

    // \Project.aspx

    // AssignProject.aspx

    public IQueryable<tblProject> BindProject()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblProject> ProjectData = from obj in DC.tblProjects
                                             where obj.IsActive == false && obj.ManagerID == null
                                             select obj;
        return ProjectData;
    }

    public IQueryable<tblSkill> BindSkill()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblSkill> SkillList = from obj in DC.tblSkills
                                         where obj.SuperSkill == null
                                         select obj;
        return SkillList;
    }

    public int CountProjectSkill(int ProjectID)
    {
        var DC = new DataClassesDataContext();
        int cnt = (from obj in DC.tblProjectXSkills
                   where obj.ProjectID == ProjectID
                   select obj).Count();
        return cnt;
    }

    public IQueryable<tblEmployee> BindEmployee(int ProjectID)
    {
        var DC = new DataClassesDataContext();
        //IList<int> Data = new int[] { Convert.ToInt32(from obj in DC.tblProjects
        //                               where obj.IsComplete == true
        //                               select obj.ManagerID) };
        //IQueryable<tblEmployee> EmployeeList = (from E in DC.tblEmployees
        //                                        join ES in DC.tblEmpXSkills
        //                                        on E.EmpID equals ES.EmpID
        //                                        join PS in DC.tblProjectXSkills
        //                                        on ES.SkillID equals PS.SkillID
        //                                        where PS.ProjectID == ProjectID && !(Data.Contains(E.EmpID))
        //                                        select E).Distinct();
        IQueryable<tblEmployee> EmployeeList = (from E in DC.tblEmployees
                                                join ES in DC.tblEmpXSkills
                                                on E.EmpID equals ES.EmpID
                                                join PS in DC.tblProjectXSkills
                                                on ES.SkillID equals PS.SkillID
                                                select E).Distinct();
        return EmployeeList;
    }

    public bool AssignProject(int ProjectID, int ManagerID, int AssignBy)
    {
        var DC = new DataClassesDataContext();
        try
        {

            tblProject Project = (from obj in DC.tblProjects
                                  where obj.ProjectID == ProjectID
                                  select obj).Single();
            Project.ManagerID = ManagerID;
            Project.AssignDate = DateTime.Now;
            Project.AssignBy = AssignBy;
            Project.IsActive = true;
            DC.SubmitChanges();
            return true;
        }
        catch (Exception Ex)
        {
            return false;
        }

    }

    // \AssignProject.aspx

    // ViewProject.aspx
    public IQueryable<tblProject> ViewProject()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblProject> strViwePro = from obj in DC.tblProjects
                                            where obj.IsActive == true && (obj.IsComplete == null || obj.IsComplete == false)
                                            select obj;
        return strViwePro;
    }

    public IQueryable<tblProject> ViewProjectPandding()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblProject> strViwePro = from obj in DC.tblProjects
                                            where obj.IsActive == false && (obj.IsComplete == null || obj.IsComplete == false)
                                            select obj;
        return strViwePro;
    }

    public IQueryable<tblProject> ViewProjectComplete()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblProject> strViwePro = from obj in DC.tblProjects
                                            where obj.IsActive == true && obj.IsComplete == true
                                            select obj;
        return strViwePro;
    }

    public string ViewCategory(int CategoryID)
    {
        var DC = new DataClassesDataContext();
        string Category = (from obj in DC.tblCategories
                           where obj.CategoryID == CategoryID
                           select obj.CategoryName).FirstOrDefault();
        return Category;
    }

    public string ViewLanguage(int LanguageID)
    {
        var DC = new DataClassesDataContext();
        string Language = (from obj in DC.tblLanguages
                           where obj.LanguageID == LanguageID
                           select obj.LanguageName).FirstOrDefault();
        return Language;
    }

    public string ViewClient(int ClientID)
    {
        var DC = new DataClassesDataContext();
        string Client = (from obj in DC.tblClients
                         where obj.ClientID == ClientID
                         select obj.ClientName).FirstOrDefault();
        return Client;
    }
    public string ViewManager(int MangerID)
    {
        var DC = new DataClassesDataContext();
        string Manger = (from obj in DC.tblEmployees
                         where obj.EmpID == MangerID
                         select obj.FirstName + " " + obj.LastName).FirstOrDefault();
        return Manger;
    }

    public void ProjectActive(int ID, string ComName)
    {
        var DC = new DataClassesDataContext();
        if (ComName == "Active")
        {
            tblProject result = (from u in DC.tblProjects
                                 where u.ProjectID == ID
                                 select u).Single();
            if (result.IsActive == true)
            {
                result.IsActive = false;
            }
            else
            {
                result.IsActive = true;
            }
            DC.SubmitChanges();
        }
    }
    public string GetManager(int ProjectID)
    {
        var DC = new DataClassesDataContext();
        int manager = Convert.ToInt32((from obj in DC.tblProjects
                                       where obj.ProjectID == ProjectID
                                       select obj.ManagerID).SingleOrDefault());
        return manager.ToString();
    }

    // \ViewProject.aspx

    // Admin Login.aspx
    public IList<int> AdminLogin(string Email, string Pwd)
    {

        var DC = new DataClassesDataContext();
        var st = (from ob in DC.tblAdmins
                  where (ob.EmailID == Email.ToLower() && ob.Password == Encryptdata(Pwd))
                  select ob).Count();

        var st1 = (from ob in DC.tblAdmins
                   where (ob.EmailID == Email.ToLower() && ob.Password == Encryptdata(Pwd))
                   select ob).FirstOrDefault();
        IList<int> Login = new int[] { st, st1.AdminID };

        return Login;
    }

    public IList<int> SendCode(string Email)
    {
        string vc = SendMail(Email);
        var DC = new DataClassesDataContext();
        int cnt = (from obj in DC.tblAdmins
                   where obj.EmailID == Email.ToLower()
                   select obj).Count();
        IList<int> Data = new int[] { cnt, Convert.ToInt32(vc) };
        return Data;
    }

    public string ChangePwd(string Email, string Pwd)
    {
        var DC = new DataClassesDataContext();
        var check = (from user in DC.tblAdmins
                     where user.EmailID == Email.ToLower()
                     select user.AdminID).Count();
        var AdminData = (from user in DC.tblAdmins
                         where user.EmailID == Email.ToLower()
                         select user).FirstOrDefault();
        if (check > 0)
        {
            tblAdmin result = (from u in DC.tblAdmins
                               where u.AdminID == AdminData.AdminID
                               select u).Single();
            result.Password = Encryptdata(Pwd);
            DC.SubmitChanges();
            return AdminData.AdminID.ToString();
        }
        else
        {
            return null;
        }

    }

    // \Admin Login.aspx

    //AddData.aspx
    public IQueryable<tblCategory> GetCatDrop()
    {
        var DC = new DataClassesDataContext();
        var GetCat = (from ob in DC.tblCategories
                      where ob.SuperID == null || ob.SuperID == 0
                      select ob);
        return GetCat;
    }

    public IQueryable<tblCategory> GetSubCategory(int value)
    {
        var DC = new DataClassesDataContext();
        int cnt = (from obj in DC.tblCategories where obj.SuperID == Convert.ToInt32(value) select obj).Count();

        if (cnt > 0)
        {
            var strSubCategory = (from obj in DC.tblCategories where obj.SuperID == Convert.ToInt32(value) select obj);
            return strSubCategory;
        }
        return null;
    }

    public void AddCategory(string CategoryName, int SuperID, int CBY)
    {
        var DC = new DataClassesDataContext();
        tblCategory objCategory = new tblCategory();
        objCategory.CategoryName = CategoryName;
        objCategory.SuperID = SuperID;
        objCategory.CreatedOn = DateTime.Now;
        objCategory.CreatedBy = CBY;
        DC.tblCategories.InsertOnSubmit(objCategory);
        DC.SubmitChanges();
    }

    public IQueryable<tblLanguage> GetLanguage(int CategoryID)
    {
        var DC = new DataClassesDataContext();
        int cnt = (from obj in DC.tblCategories select obj).Count();

        var GetLang = (from ob in DC.tblLanguages
                       where ob.CategoryID == CategoryID
                       select ob);
        return GetLang;
    }
    public void AddLanguage(string LanguageName, int CategoryID, int SuperID, int CBY)
    {
        var DC = new DataClassesDataContext();
        tblLanguage objLanguage = new tblLanguage();
        objLanguage.LanguageName = LanguageName;
        objLanguage.CategoryID = CategoryID;
        objLanguage.SuperID = SuperID;
        objLanguage.CreatedOn = DateTime.Now;
        objLanguage.CreatedBy = CBY;
        DC.tblLanguages.InsertOnSubmit(objLanguage);
        DC.SubmitChanges();
    }


    public IQueryable<tblLanguage> GetSubLanguage(int value)
    {
        var DC = new DataClassesDataContext();
        int cnt = (from obj in DC.tblLanguages where obj.SuperID == Convert.ToInt32(value) select obj).Count();

        if (cnt > 0)
        {
            var strSublanguage = (from obj in DC.tblLanguages where obj.SuperID == Convert.ToInt32(value) select obj);
            return strSublanguage;
        }
        return null;
    }

    // \AddData.aspx

    // EmployeeReg.aspx
    public Boolean EmployeeRegistration(string FirstName, string LastName, string EmailID, string Password, string ContactNo, int Gender, string CBy)
    {
        var DC = new DataClassesDataContext();
        if (CBy != "")
        {

            tblEmployee objEmp = new tblEmployee();
            objEmp.FirstName = FirstName;
            objEmp.LastName = LastName;
            objEmp.EmailID = EmailID.ToLower();
            objEmp.Password = Encryptdata(Password);
            if (Gender != 0)
            {
                objEmp.Gender = Gender;
            }

            objEmp.ContactNo = ContactNo;

            objEmp.CreatedOn = DateTime.Now;
            if (CBy != null)
            {
                objEmp.CreatedBy = Convert.ToInt32(CBy);
                objEmp.IsActive = true;
                objEmp.IsVerify = true;
                objEmp.IsVerifyByAdmin = true;
            }
            else
            {
                objEmp.IsActive = false;
                objEmp.IsVerify = false;
            }

            DC.tblEmployees.InsertOnSubmit(objEmp);
            DC.SubmitChanges();
            return true;
        }
        else
        {
            return false;
        }
    }
    // \EmployeeReg.aspx

    // EmpGrid.aspx

    public IQueryable<tblEmployee> ViewEmployee()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblEmployee> stremp = from obj in DC.tblEmployees
                                         where obj.IsActive == true
                                         select obj;
        return stremp;
    }

    public string BindEmpCBy(int AdminID)
    {
        var DC = new DataClassesDataContext();
        var CreatedBy = (from obj in DC.tblAdmins
                         where obj.AdminID == AdminID
                         select obj).FirstOrDefault();
        return CreatedBy.FirstName + " " + CreatedBy.LastName;
    }

    public void EmpModify(int ID, string ComName)
    {
        var DC = new DataClassesDataContext();

        if (ComName == "Active")
        {
            tblEmployee result = (from u in DC.tblEmployees
                                  where u.EmpID == ID
                                  select u).Single();
            result.IsActive = false;
            DC.SubmitChanges();
        }

    }

    // \EmpGrid.aspx

    // AdminChangePassword.aspx
    public Boolean AdminChangePassword(int AdminID, string CurPwd, string Pwd)
    {
        var DC = new DataClassesDataContext();
        int ID = (AdminID);
        int count = (from u in DC.tblAdmins
                     where u.AdminID == ID && u.Password == Encryptdata(CurPwd)
                     select u).Count();
        if (count > 0)
        {
            tblAdmin result1 = (from u in DC.tblAdmins
                                where u.AdminID == ID && u.Password == Encryptdata(CurPwd)
                                select u).Single();
            result1.Password = Encryptdata(Pwd);
            DC.SubmitChanges();
            return true;
        }
        else
        {
            return false;
        }

    }
    // \AdminChangePassword.aspx


    // AdminReg.aspx
    public IQueryable<tblAdmin> AdminRegBindData()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblAdmin> objAdmin = from Ob in DC.tblAdmins select Ob;

        return objAdmin;
    }

    public bool AdminRegistration(string FirstName, string LastName, string EmailID, string Password, string ContactNo, string Image, bool IsInsert, bool IsUpdate, bool IsDelete, int CBY, bool IsSuper)
    {
        var DC = new DataClassesDataContext();
        tblAdmin objAddAdmin = new tblAdmin();
        objAddAdmin.FirstName = FirstName;
        objAddAdmin.LastName = LastName;
        objAddAdmin.EmailID = EmailID;
        objAddAdmin.Password = Encryptdata(Password);
        objAddAdmin.ContactNo = ContactNo;
        objAddAdmin.Image = Image;
        objAddAdmin.IsInsert = IsInsert;
        objAddAdmin.IsUpdate = IsUpdate;
        objAddAdmin.IsDelete = IsDelete;
        objAddAdmin.IsActive = true;
        objAddAdmin.CreatedBy = CBY;
        objAddAdmin.CreatedOn = DateTime.Now;
        objAddAdmin.IsSuper = IsSuper;
        DC.tblAdmins.InsertOnSubmit(objAddAdmin);
        DC.SubmitChanges();
        return true;
    }
    // AdminReg.aspx

    // ClientReg.aspx
    IQueryable<tblCountry> IService.GetCountry()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblCountry> objCountry = from ob in DC.tblCountries select ob;
        return objCountry;
    }

    public IQueryable<tblState> GetState(int value)
    {
        var DC = new DataClassesDataContext();
        int cnt = (from obj in DC.tblStates where obj.CountryID == Convert.ToInt32(value) select obj).Count();
        if (cnt > 0)
        {
            var strState = (from obj in DC.tblStates where obj.CountryID == Convert.ToInt32(value) select obj);
            return strState;
        }
        return null;
    }

    public IQueryable<tblCity> GetCity(int value)
    {
        var DC = new DataClassesDataContext();
        int cnt = (from obj in DC.tblCities where obj.StateID == Convert.ToInt32(value) select obj).Count();
        if (cnt > 0)
        {
            var strCity = (from obj in DC.tblCities where obj.StateID == Convert.ToInt32(value) select obj);
            return strCity;
        }
        return null;
    }

    public IQueryable<tblClient> ClientRegBindData()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblClient> objClient = from Ob in DC.tblClients select Ob;

        return objClient;
    }

    public bool ClientRegistration(string Name, string EmailID, string Password, string ContactNo, string ComName, string WebURL, string Address, string Landmark, int City, int ZipCode, int CBY)
    {
        var DC = new DataClassesDataContext();
        tblClient objAddClient = new tblClient();
        objAddClient.ClientName = Name;
        objAddClient.ContactNo = ContactNo;
        objAddClient.EmailID = EmailID;
        objAddClient.Password = Encryptdata(Password);
        if (ComName != null)
        {
            objAddClient.CompanyName = ComName;
            objAddClient.WebsiteURL = WebURL;
            objAddClient.Address = Address;
            objAddClient.Landmark = Landmark;
            objAddClient.CityID = City;
            objAddClient.Zipcode = ZipCode;
            objAddClient.CreatedBy = CBY;
            objAddClient.IsActive = true;
        }
        else
        {
            objAddClient.IsActive = false;
        }
        objAddClient.CreatedOn = DateTime.Now;
        DC.tblClients.InsertOnSubmit(objAddClient);
        DC.SubmitChanges();
        return true;
    }
    // \ClientReg.aspx

    // TrackProject.aspx

    public IQueryable<tblModule> BindModule(int ProjectID)
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblModule> ModuleData = from obj in DC.tblModules
                                           where obj.ProjectID == ProjectID
                                           select obj;
        return ModuleData;

    }
    public IQueryable<tblTask> BindTask(int ModuleID)
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblTask> TaskData = from obj in DC.tblTasks
                                       where obj.ModuleID == ModuleID
                                       select obj;
        return TaskData;
    }

    // \TrackProject.aspx

    // \AdminServices---------------------------------------------------------------------------------------------------------------------------------------------------



    // ClientServices---------------------------------------------------------------------------------------------------------------------------------------------------

    // Default.aspx

    public IQueryable<tblProject> ProjectStatus()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblProject> Data = from obj in DC.tblProjects
                                      where obj.IsHome == true
                                      select obj;
        return Data;
    }

    // \Default.aspx

    // NewsLetter

    public bool Subscribe(string Email)
    {
        //string vc = "Now You are subscriber in your website.";
        //DateTime now = DateTime.Now;
        //vc = now.ToString();
        //vc = vc.GetHashCode().ToString().Trim('-');
        //MailMessage Msg = new MailMessage("trackmyworkindia@gmail.com", Email);
        //Msg.Subject = "Subscribe Message";
        //Msg.Body = "<html><head></head><body><table><tr><td>Your E-Mail :</td><td>" + Email + "</td></tr><tr><td colspan='2'>" + vc + "</td></tr></table></body></html>";
        //Msg.IsBodyHtml = true;

        //SmtpClient smtp = new SmtpClient();
        //smtp.Host = "smtp.gmail.com";
        //smtp.Port = 587;
        //smtp.UseDefaultCredentials = false;
        //smtp.EnableSsl = true;
        //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

        //NetworkCredential MyCredentials = new NetworkCredential("trackmyworkindia@gmail.com", "TMW2016open");
        //smtp.Credentials = MyCredentials;
        //smtp.Send(Msg);

        //var DC = new DataClassesDataContext();
        //tblNewsLetter News = new tblNewsLetter();
        //News.EmailID = Email;
        //News.SubscribedDate = DateTime.Now;
        //DC.tblNewsLetters.InsertOnSubmit(News);
        //DC.SubmitChanges();
        //return true;

        var DC = new DataClassesDataContext();
        var NewsLetter = (from ob in DC.tblNewsLetters
                          where ob.EmailID == Email
                          select ob).Count();
        tblNewsLetter News = new tblNewsLetter();
        if (NewsLetter > 0)
        {
            News = (from obj in DC.tblNewsLetters
                    where obj.EmailID == Email
                    select obj).FirstOrDefault();
            News.UnSubscribedDate = null;
            DC.SubmitChanges();
        }
        else
        {
            News.EmailID = Email;
            News.SubscribedDate = DateTime.Now;
            DC.tblNewsLetters.InsertOnSubmit(News);
            DC.SubmitChanges();
        }
        return true;
    }

    public bool UnSubscribe(string Email)
    {
        var DC = new DataClassesDataContext();
        var UnSubscribeNews = (from ob in DC.tblNewsLetters
                               where ob.EmailID == Email
                               select ob).FirstOrDefault();
        UnSubscribeNews.UnSubscribedDate = DateTime.Now;
        DC.SubmitChanges();
        return true;
    }

    public bool SubscribeEmailCheck(string Email)
    {
        var DC = new DataClassesDataContext();
        int News = (from obj in DC.tblNewsLetters
                    where obj.EmailID == Email.ToLower() && obj.UnSubscribedDate == null
                    select obj).Count();
        if (News > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    // \NewsLetter


    //Email Checking
    public bool EmailCkecking(string Email, string Event)
    {

        var DC = new DataClassesDataContext();
        int Admin = (from obj in DC.tblAdmins
                     where obj.EmailID == Email.ToLower()
                     select obj).Count();
        int Employee = (from obj in DC.tblEmployees
                        where obj.EmailID == Email.ToLower()
                        select obj).Count();
        int Client = (from obj in DC.tblClients
                      where obj.EmailID == Email.ToLower()
                      select obj).Count();


        if (Event == "Login")
        {
            if (Client > 0)
            {
                return true;
            }
            else if (Employee > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (Admin > 0)
            {
                return false;
            }
            else if (Employee > 0)
            {
                return false;
            }
            else if (Client > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }

    // \EmailChecking

    // Services.aspx
    public IQueryable<tblCategory> Viewservice()
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblCategory> Data = (from obj in DC.tblCategories where obj.SuperID == null || obj.SuperID == 0 select obj);
        return Data;
    }
    public IQueryable<tblCategory> ViewSubservice(int CatID)
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblCategory> Data = (from obj in DC.tblCategories where obj.SuperID == CatID select obj);
        return Data;
    }

    // \Services.aspx

    // Profile.aspx
    public tblEmployee BindEmpProfile(int EmpID)
    {
        var DC = new DataClassesDataContext();
        tblEmployee str = (from obj in DC.tblEmployees
                           where obj.EmpID == EmpID
                           select obj).Single();
        return str;
    }

    public tblEmployee UpdateEmpProfile(int EmpID, string FirstName, string LastName, int gen, DateTime dob, string con, string email, string add, string Img)
    {
        var DC = new DataClassesDataContext();
        tblEmployee objemp = (from u in DC.tblEmployees
                              where u.EmpID == EmpID
                              select u).SingleOrDefault();
        objemp.FirstName = FirstName;
        objemp.LastName = LastName;
        objemp.Gender = gen;
        objemp.DOB = dob;
        objemp.ContactNo = con;
        objemp.EmailID = email;
        objemp.Address = add;
        objemp.ProfilePic = Img;

        DC.SubmitChanges();
        return objemp;
    }

    public IQueryable<tblSkill> ViewEmpSkill(int EmpID)
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblSkill> str = (from obj in DC.tblEmpXSkills
                                    join obj2 in DC.tblSkills
                                    on obj.SkillID equals obj2.SkillID
                                    where obj.EmpID == EmpID && obj.SkillID == obj2.SkillID
                                    select obj2);
        return str;
    }

    public void AddEmpSkill(int EmpID, string SkillName)
    {
        var DC = new DataClassesDataContext();
        int SkillID = (from obj in DC.tblSkills
                       where obj.SkillName == SkillName
                       select obj.SkillID).Single();
        tblEmpXSkill skill = new tblEmpXSkill();
        skill.EmpID = EmpID;
        skill.SkillID = SkillID;
        skill.CreatedOn = DateTime.Now;
        DC.tblEmpXSkills.InsertOnSubmit(skill);
        DC.SubmitChanges();
    }

    public void DelEmpSkill(int EmpID, int SkillID)
    {
        var DC = new DataClassesDataContext();
        var Skill = (from obj in DC.tblEmpXSkills
                     where obj.SkillID == SkillID && obj.EmpID == EmpID
                     select obj).Single();
        DC.tblEmpXSkills.DeleteOnSubmit(Skill);
        DC.SubmitChanges();

    }

    // \Profile.aspx

    // ClientLogIn.aspx
    public IList<string> ClientLogin(string Email, string Password)
    {
        var dc = new DataClassesDataContext();
        int stEmp = (from ob in dc.tblEmployees
                     where (ob.EmailID == Email.ToLower() && ob.Password == Encryptdata(Password))
                     select ob).Count();

        int stClient = (from ob in dc.tblClients
                        where (ob.EmailID == Email.ToLower() && ob.Password == Encryptdata(Password))
                        select ob).Count();
        IList<string> Login;
        if (stEmp > 0)
        {
            var st1 = (from ob in dc.tblEmployees
                       where (ob.EmailID == Email.ToLower() && ob.Password == Encryptdata(Password))
                       select ob).FirstOrDefault();
            Login = new string[] { "Employee", st1.EmpID.ToString() };
            return Login;
        }
        else if (stClient > 0)
        {
            var st2 = (from ob in dc.tblClients
                       where (ob.EmailID == Email.ToLower() && ob.Password == Encryptdata(Password))
                       select ob).FirstOrDefault();
            Login = new string[] { "Client", st2.ClientID.ToString() };
            return Login;
        }
        else
        {
            return null;
        }
    }



    public void ForgetChangePwd(string MailID, string Pwd)
    {
        var dc = new DataClassesDataContext();
        int Emp = (from user in dc.tblEmployees
                   where user.EmailID == MailID.ToLower()
                   select user.EmpID).Count();
        int Client = (from user in dc.tblClients
                      where user.EmailID == MailID.ToLower()
                      select user.ClientID).Count();
        if (Emp > 0)
        {
            var st1 = (from user in dc.tblEmployees
                       where user.EmailID == MailID.ToLower()
                       select user).FirstOrDefault();
            tblEmployee result = (from u in dc.tblEmployees
                                  where u.EmpID == st1.EmpID
                                  select u).Single();
            result.Password = Encryptdata(Pwd);
            dc.SubmitChanges();
        }
        else if (Client > 0)
        {
            var st1 = (from user in dc.tblClients
                       where user.EmailID == MailID.ToLower()
                       select user).FirstOrDefault();
            tblClient result = (from u in dc.tblClients
                                where u.ClientID == st1.ClientID
                                select u).Single();
            result.Password = Encryptdata(Pwd);
            dc.SubmitChanges();
        }
    }

    public IList<string> MailToPerson(string Email)
    {
        IList<string> vc;
        var DC = new DataClassesDataContext();
        int Client = (from obj in DC.tblClients
                      where obj.EmailID == Email.ToLower() && obj.IsActive == false
                      select obj).Count();
        int Employee = (from obj in DC.tblEmployees
                        where obj.EmailID == Email.ToLower() && (obj.IsVerify == false || obj.IsVerify == null)
                        select obj).Count();
        if (Client > 0)
        {
            string Code = SendMail(Email);
            vc = new string[] { Code, null };
            return vc;
        }
        else if (Employee > 0)
        {
            string Code = ((from obj in DC.tblEmployees
                            where obj.EmailID == Email.ToLower() && (obj.IsActive == false) && (obj.IsVerify == null || obj.IsVerify == false)
                            select obj.VerifyCode).Single()).ToString();
            DateTime now = DateTime.Now;
            MailMessage Msg = new MailMessage("trackmyworkindia@gmail.com", Email);
            Msg.Subject = "Email Verification";
            //Msg.Body = "<html><head></head><body><table><tr><td>Your E-Mail :</td><td>" + Email + "</td></tr><tr><td>Your Code :</td><td>" + Code + "</td></tr></table></body></html>";
            Msg.Body = "<!DOCTYPE html><html><head><title>Track My Work</title> <meta charset=\"utf - 8\"><meta name=\"viewport\" content=\"width = device - width, initial - scale = 1\"><meta http-equiv=\"X - UA - Compatible\" content=\"IE = edge\" /><style type=\"text / css\"> /* CLIENT-SPECIFIC STYLES */ body, table, td, a{-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;} /* Prevent WebKit and Windows mobile changing default text sizes */ table, td{mso-table-lspace: 0pt; mso-table-rspace: 0pt;} /* Remove spacing between tables in Outlook 2007 and up */ img{-ms-interpolation-mode: bicubic;} /* Allow smoother rendering of resized image in Internet Explorer */ /* RESET STYLES */ img{border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none;} table{border-collapse: collapse !important;} body{height: 100% !important; margin: 0 !important; padding: 0 !important; width: 100% !important;} /* iOS BLUE LINKS */ a[x-apple-data-detectors] { color: inherit !important; text-decoration: none !important; font-size: inherit !important; font-family: inherit !important; font-weight: inherit !important; line-height: inherit !important; } /* MOBILE STYLES */ @media screen and (max-width: 525px) { /* ALLOWS FOR FLUID TABLES */ .wrapper { width: 100% !important; max-width: 100% !important; } /* ADJUSTS LAYOUT OF LOGO IMAGE */ .logo img { margin: 0 auto !important; } /* USE THESE CLASSES TO HIDE CONTENT ON MOBILE */ .mobile-hide { display: none !important; } .img-max { max-width: 100% !important; width: 100% !important; height: auto !important; } /* FULL-WIDTH TABLES */ .responsive-table { width: 100% !important; } /* UTILITY CLASSES FOR ADJUSTING PADDING ON MOBILE */ .padding { padding: 10px 5% 15px 5% !important; } .padding-meta { padding: 30px 5% 0px 5% !important; text-align: center; } .no-padding { padding: 0 !important; } .section-padding { padding: 50px 15px 50px 15px !important; } /* ADJUST BUTTONS ON MOBILE */ .mobile-button-container { margin: 0 auto; width: 100% !important; } .mobile-button { padding: 15px !important; border: 0 !important; font-size: 16px !important; display: block !important; } } /* ANDROID CENTER FIX */ div[style*=\"margin: 16px 0; \"] { margin: 0 !important; }</style></head><body style=\"margin: 0 !important; padding: 0 !important; \"><!-- HIDDEN PREHEADER TEXT --><div style=\"display: none; font - size: 1px; color: #fefefe; line-height: 1px; font-family: Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;\"> Entice the open with some amazing preheader text. Use a little mystery and get those subscribers to read through...</div><!-- HEADER --><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"> <tr> <td align=\"center\" style=\" background:#008bff;\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 500px;\" class=\"wrapper\"> <tr style=\" background:#008bff;\"> <td align=\"center\" valign=\"top\" style=\"padding: 15px 0;\" class=\"logo\"> <h1 style=\"color:white; background:#008bff; font-family:calibri; font-size:40px;\">Track My Work</h1> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td bgcolor=\"#ffffff\" align=\"center\" style=\"padding: 70px 15px 70px 15px;\" class=\"section-padding\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 500px;\" class=\"responsive-table\"> <tr> <td> <!-- HERO IMAGE --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td> <!-- COPY --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td align=\"center\" style=\"font-size: 25px; font-family: Helvetica, Arial, sans-serif; color: #333333; padding-top: 30px;\" class=\"padding\">Your Email id is</td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0 0 0; font-size: 16px; line-height: 25px; font-family: Helvetica, Arial, sans-serif; color: #666666;\" class=\"padding\">" + Email + "</td> </tr> <tr> <td align=\"center\" style=\"font-size: 25px; font-family: Helvetica, Arial, sans-serif; color: #333333; padding-top: 30px;\" class=\"padding\">Your Verification Code is</td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0 0 0; font-size: 16px; line-height: 25px; font-family: Helvetica, Arial, sans-serif; color: #666666;\" class=\"padding\">" + Code + "</td> </tr> </table> </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td align=\"center\" style=\"padding: 20px 0px; background:#424242; color:white;\"> <!--[if (gte mso 9)|(IE)]> <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\"> <tr> <td align=\"center\" valign=\"top\" width=\"500\"> <![endif]--> <!-- UNSUBSCRIBE COPY --> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"max-width: 500px;\" class=\"responsive-table\"> <tr> <td align=\"center\" style=\"font-size: 12px; line-height: 18px; font-family: Helvetica, Arial, sans-serif; color:white;\"> <b>Track My Work</b> by:- Renown Infosys <span style=\"font-family: Arial, sans-serif; font-size: 12px; color:white;\">&nbsp;&nbsp;</span> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr></table></body></html>";
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
            vc = new string[] { Code, "NotVerify" };
            return vc;
        }
        else
        {
            return null;
        }

    }

    public string GetPersonType(string Email)
    {
        var DC = new DataClassesDataContext();
        int Client = (from obj in DC.tblClients
                      where obj.EmailID == Email.ToLower() && obj.IsActive == false
                      select obj).Count();
        int Employee = (from obj in DC.tblEmployees
                        where obj.EmailID == Email.ToLower() && (obj.IsActive == false) && (obj.IsVerify == null || obj.IsVerify == false)
                        select obj).Count();
        if (Client > 0)
        {
            return "Client";
        }
        else if (Employee > 0)
        {
            return "Employee";
        }
        else
        {
            return null;
        }
    }

    public int VerifyPerson(string Email)
    {
        var DC = new DataClassesDataContext();
        int Client = (from obj in DC.tblClients
                      where obj.EmailID == Email.ToLower() && obj.IsActive == false
                      select obj).Count();
        int Employee = (from obj in DC.tblEmployees
                        where obj.EmailID == Email.ToLower() && (obj.IsActive == false) && (obj.IsVerify == null || obj.IsVerify == false)
                        select obj).Count();
        if (Client > 0)
        {
            tblClient ClientData = (from obj in DC.tblClients
                                    where obj.EmailID == Email.ToLower() && obj.IsActive == false
                                    select obj).Single();
            ClientData.IsActive = true;
            DC.SubmitChanges();
            return ClientData.ClientID;
        }
        else if (Employee > 0)
        {
            tblEmployee EmpData = (from obj in DC.tblEmployees
                                   where obj.EmailID == Email.ToLower() && obj.IsActive == false && (obj.IsVerify == false || obj.IsVerify == null)
                                   select obj).Single();
            EmpData.IsVerify = true;
            EmpData.IsActive = true;
            DC.SubmitChanges();
            return EmpData.EmpID;
        }
        else
        {
            return 0;
        }
    }

    // \ClientLogIn.aspx

    // PostProject.aspx

    public void AddInquiry(string Name, string EmailID, string ContactNo, string Description)
    {
        var DC = new DataClassesDataContext();
        tblInquiry Inquiry = new tblInquiry();
        Inquiry.Name = Name;
        Inquiry.EmailID = EmailID;
        Inquiry.ContactNo = ContactNo;
        Inquiry.Description = Description;
        Inquiry.CreatedOn = DateTime.Now;
        DC.tblInquiries.InsertOnSubmit(Inquiry);
        DC.SubmitChanges();
    }

    public void AddPostProject(int ClientID, string CategoryID, string Title, string Description, string ContentUpload, DateTime DeadlineDate, int CreatedBy)
    {
        var DC = new DataClassesDataContext();
        tblPostProject Project = new tblPostProject();
        Project.ClientID = ClientID;
        if (CategoryID != "")
        {
            Project.CategoryID = Convert.ToInt32(CategoryID);
        }
        Project.Title = Title;
        Project.Description = Description;
        Project.ContentUpload = ContentUpload;
        Project.DeadlineDate = DeadlineDate;
        Project.CreateOn = DateTime.Now;
        Project.CreatedBy = CreatedBy;
        DC.tblPostProjects.InsertOnSubmit(Project);
        DC.SubmitChanges();
    }

    public int CountContentTrans()
    {
        var DC = new DataClassesDataContext();
        int cnt = (from obj in DC.tblCategories where obj.CategoryName == "Content Translation" select obj).Count();
        return cnt;
    }

    // \PostProject.aspx

    // ProjectMaster.aspx

    public void AddModule(string ModuleName, int ProjectID, int ManagerID)
    {
        //var DC = new DataClassesDataContext();
        //tblModule ModuleData = new tblModule();
        //ModuleData.Title = ModuleName;
        //ModuleData.ProjectID = ProjectID;
        //ModuleData.CreatedBy = ManagerID;
        //ModuleData.CreatedOn = DateTime.Now;
        //ModuleData.State = 1;
        //DC.tblModules.InsertOnSubmit(ModuleData);
        //DC.SubmitChanges();
        var DC = new DataClassesDataContext();
        tblProject ProjectData = DC.tblProjects.Single(ob => ob.ProjectID == ProjectID);
        tblModule ModuleData = new tblModule();
        ModuleData.Title = ModuleName;
        ModuleData.ProjectID = ProjectID;
        ModuleData.CreatedBy = ManagerID;
        ModuleData.AssignDate = DateTime.Now;
        ModuleData.DeadlineDate = ProjectData.DeadlineDate;
        ModuleData.CreatedOn = DateTime.Now;
        ModuleData.State = 1;
        DC.tblModules.InsertOnSubmit(ModuleData);
        DC.SubmitChanges();
    }

    public IQueryable<tblModule> BindNewProject(int ProjectID)
    {
        var DC = new DataClassesDataContext();
        //var Module = from objM in DC.tblModules
        //             join objT in DC.tblTasks
        //             on objM.ModuleID equals objT.ModuleID
        //             where objM.ProjectID == 1
        //             group objT by objT.ModuleID into grp
        //             select new
        //             {
        //                 grp.Key,

        //             };

        //var ModuleData = from tblModules in DC.tblModules
        //                 join tblTasks in DC.tblTasks on tblModules.ModuleID equals tblTasks.ModuleID
        //                 where
        //                   tblModules.ProjectID == 1
        //                 group tblModules by new
        //                 {
        //                     tblModules.Description
        //                 } into g
        //                 select new
        //                 {
        //                     TotalTask = g.Count(p => p.ModuleID != 0),
        //                     ModuleDescription = g.Key.Description,
        //                     ModuleID = g.First().ModuleID
        //                 };
        IQueryable<tblModule> ModuleData = from obj in DC.tblModules
                                           where obj.ProjectID == ProjectID && obj.State == 1 && (obj.IsActive == true || obj.IsActive == null)
                                           select obj;
        return ModuleData;
    }

    public int BindTotalTask(int ModuleID)
    {
        var DC = new DataClassesDataContext();
        int cnt = (from obj in DC.tblTasks
                   where obj.ModuleID == ModuleID && (obj.IsActive == true || obj.IsActive == null)
                   select obj).Count();
        return cnt;
    }

    public tblModule BindProjectModule(int ModuleID)
    {
        var DC = new DataClassesDataContext();
        tblModule ModuleData = (from obj in DC.tblModules
                                where obj.ModuleID == ModuleID
                                select obj).Single();
        return ModuleData;
    }

    public IList<string> GetProjectDetail(int ProjectID)
    {
        var DC = new DataClassesDataContext();
        tblProject Data = (from obj in DC.tblProjects
                           where obj.ProjectID == ProjectID
                           select obj).Single();
        string Category = (from obj in DC.tblCategories
                           where obj.CategoryID == Data.CategoryID
                           select obj.CategoryName).Single();
        IList<string> DataList = new string[] { Data.ProjectID.ToString(), Data.Title, Data.Description, Data.AssignDate.ToString(), Data.DeadlineDate.ToString(), Category, Data.Image };
        return DataList;
    }

    public IQueryable<tblTask> GetTaskList(int ModuleID)
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblTask> Data = from obj in DC.tblTasks
                                   where obj.ModuleID == ModuleID && (obj.IsActive == true || obj.IsActive == null)
                                   select obj;
        return Data;
    }

    public bool AddTask(int ModuleID, string Title, int TeamLeaderID)
    {
        var DC = new DataClassesDataContext();
        tblModule ModuleData = DC.tblModules.Single(ob => ob.ModuleID == ModuleID);
        tblTask AddTask = new tblTask();
        AddTask.ModuleID = ModuleID;
        AddTask.Title = Title;
        AddTask.CreatedOn = DateTime.Now;
        AddTask.IsActive = true;
        AddTask.State = 1;
        AddTask.AssignDate = DateTime.Now;
        AddTask.DeadlineDate = ModuleData.DeadlineDate;
        DC.tblTasks.InsertOnSubmit(AddTask);
        DC.SubmitChanges();
        return true;
    }

    // \ProjectMaster.aspx

    // ModuleDetail.aspx

    public IQueryable<tblEmployee> GetTeamLeader(int ProjectID, int ModuleID)
    {
        var DC = new DataClassesDataContext();
        var project = DC.tblProjects.SingleOrDefault(ob => ob.ProjectID == ProjectID);
        var Data = (from E in DC.tblEmployees
                    join ES in DC.tblEmpXSkills
                    on E.EmpID equals ES.EmpID
                    //join P in DC.tblProjects
                    //on E.EmpID equals P.ManagerID
                    join PS in DC.tblProjectXSkills
                    on ES.SkillID equals PS.SkillID
                    where E.EmpID != project.ManagerID
                    select E).Distinct();
        return Data;
    }

    //public bool EditModule(int ModuleID, string Title, string Desc, int State, int Priority, int Risk, string TaskFile, DateTime SubmitedDate)
    //{
    //    var DC = new DataClassesDataContext();
    //    tblModule Module = (from obj in DC.tblModules
    //                        where obj.ModuleID == ModuleID
    //                        select obj).Single();
    //    Module.Title = Title;
    //    if()
    //}

    // \ModuleDetail.aspx

    // TrackProject.aspx

    public IQueryable<tblModule> BindNewProjectTrack(int ProjectID)
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblModule> ModuleData = from obj in DC.tblModules
                                           where obj.ProjectID == ProjectID
                                           select obj;
        return ModuleData;
    }

    public IQueryable<tblProject> BindClientProject(int ClientID)
    {
        var DC = new DataClassesDataContext();
        var Data = from obj in DC.tblProjects
                   where obj.ClientID == ClientID
                   select obj;
        return Data;
    }

    public int GetProjectPoint(int ModuleID)
    {
        var DC = new DataClassesDataContext();
        int TotalTask = (from obj in DC.tblTasks
                         where obj.ModuleID == ModuleID
                         select obj).Count();
        int ComplitedTask = (from obj in DC.tblTasks
                             where obj.ModuleID == ModuleID && obj.IsComplete == true
                             select obj).Count();
        int Percentage = (ComplitedTask * 100) / TotalTask;
        return Percentage;
    }

    // TrackProject.aspx

    // Feedback.aspx

    public tblClient GetClientDetail(string Email)
    {
        var DC = new DataClassesDataContext();
        tblClient Data = (from obj in DC.tblClients
                          where obj.EmailID == Email
                          select obj).Single();
        return Data;
    }

    public bool GiveFeedback(string Email, int ProjectID, float Point, string Desc)
    {
        var DC = new DataClassesDataContext();
        tblFeedback Feedback = new tblFeedback();
        Feedback.EmailID = Email;
        if (ProjectID != 0)
        {
            Feedback.ProjectID = ProjectID;
        }
        Feedback.FeedBackPoint = Convert.ToDecimal(Point);
        Feedback.Description = Desc;
        Feedback.CreatedOn = DateTime.Now;
        int cnt = (from obj in DC.tblClients
                   where obj.EmailID == Email
                   select obj.ClientID).Count();
        if (cnt > 0)
        {
            int Data = (from obj in DC.tblClients
                        where obj.EmailID == Email
                        select obj.ClientID).Single();
            Feedback.ClientID = Data;
        }
        Feedback.IsRead = false;
        DC.tblFeedbacks.InsertOnSubmit(Feedback);
        DC.SubmitChanges();
        return true;
    }

    
    // \Feedback.aspx

    // ClientServices---------------------------------------------------------------------------------------------------------------------------------------------------

}