using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

    //AddErrorLog

    //[OperationContract]
    //void AddErrorLog(ref Exception strException, string PageName, string UserType, int UserID, int AdminID, string MACAddress = null);

    //void AddErrorLog(ref Exception strException, string PageName, string UserType, int UserID, int AdminID, string MACAddress = null);
    // \AddErrorLog

    // AdminServices-----------------------------------------------------------------------------------------------------------------------------------------------

    [OperationContract]
    string SendMail(string Email);

    // AddSkill.aspx
    [OperationContract]
    IQueryable<tblSkill> ViewSkill();

    [OperationContract]
    void AddSkill(string SkillName, int CBY, string SSkill);

    // \AddSkill.aspx

    // AdminGrid.aspx

    [OperationContract]
    IQueryable<tblAdmin> ViewAddmin();

    [OperationContract]
    bool ResSubAdmin(int AdminID);

    [OperationContract]
    IQueryable<tblAdmin> BindAdminGrid(int AdminID);

    [OperationContract]
    string BindCBy(int AdminID);

    [OperationContract]
    void AdminModify(int ID, string ComName);

    // \AdminGrid.aspx

    // EmployeeGrid.aspx

    [OperationContract]
    IQueryable<tblEmployee> ViewEmployee();

    [OperationContract]
    string BindEmpCBy(int AdminID);

    [OperationContract]
    void EmpModify(int ID, string ComName);

    // \EmployeeGrid.aspx

    // CMS.aspx

    [OperationContract]
    IQueryable<tblCM> CMSFillDD();

    [OperationContract]
    string CMSFillEdit(int CMSID);

    [OperationContract]
    void CMSInsert(string Title, string content, int CBy);

    [OperationContract]
    void CMSEdit(string Title, string content, int CMSID);

    // \CMS.aspx

    // Inquiry.aspx

    [OperationContract]
    IQueryable<tblInquiry> ViewInquiry();

    // \Inquiry.aspx

    // ViewPostProject.aspx

    [OperationContract]
    IQueryable<tblPostProject> GetPostedProject();

    [OperationContract]
    string GetClientNamePostedProject(int ClientID);

    [OperationContract]
    string GetCategoryNamePostProject(int CategoryID);

    // \ViewPostProject.aspx

    // Project.aspx

    //[OperationContract]
    //void AddProject(int ProjectId, int ClientId, int CategoryId, int LanguageId, string Title, string Description, string Deadlinedate, int CBY);

    [OperationContract]
    IQueryable<tblClient> FillClientProject();

    [OperationContract]
    int CountSubCategory(int value);

    [OperationContract]
    IQueryable<tblLanguage> FillLanguageProject(int CatID, int value = 0);

    [OperationContract]
    void AddProject(string Title, int ClientID, int CatID, int LanID, string Desc, int AdminID, DateTime DeadLine);

    // Two method GetCatDrop() & GetSubCategory() are is in AddData.aspx. and it's use for fill dropdown category.

    // \Project.aspx

    // AssignProject.aspx

    [OperationContract]
    IQueryable<tblProject> BindProject();

    [OperationContract]
    IQueryable<tblSkill> BindSkill();

    [OperationContract]
    int CountProjectSkill(int ProjectID);

    [OperationContract]
    IQueryable<tblEmployee> BindEmployee(int ProjectID);

    [OperationContract]
    bool AssignProject(int ProjectID, int ManagerID, int AssignBy);

    // \AssignProject.aspx

    // ViewProject.aspx

    [OperationContract]
    IQueryable<tblProject> ViewProject();

    [OperationContract]
    IQueryable<tblProject> ViewProjectPandding();

    [OperationContract]
    IQueryable<tblProject> ViewProjectComplete();

    [OperationContract]
    string ViewCategory(int CategoryID);

    [OperationContract]
    string ViewLanguage(int LanguageID);

    [OperationContract]
    string ViewClient(int ClientID);

    [OperationContract]
    string ViewManager(int MangerID);

    [OperationContract]
    void ProjectActive(int ID, string ComName);

    [OperationContract]
    string GetManager(int ProjectID);

    // \ViewProject.aspx

    // Admin Login.aspx
    [OperationContract]
    IList<int> AdminLogin(string Email, string Pwd);
    [OperationContract]
    IList<int> SendCode(string Email);
    [OperationContract]
    string ChangePwd(string Email, string Pwd);
    // \Admin Login.aspx

    // AddData.aspx

    [OperationContract]
    IQueryable<tblCategory> GetCatDrop();

    [OperationContract]
    IQueryable<tblCategory> GetSubCategory(int value);

    [OperationContract]
    void AddCategory(string CategoryName, int SuperID, int CBY);

    [OperationContract]
    IQueryable<tblLanguage> GetLanguage(int CategoryID);

    [OperationContract]
    IQueryable<tblLanguage> GetSubLanguage(int value);

    [OperationContract]
    void AddLanguage(string LanguageName, int CategoryID, int SuperID, int CBY);

    // \AddData.aspx


    // EmployeeReg.aspx
    [OperationContract]
    Boolean EmployeeRegistration(string FirstName, string LastName, string EmailID, string Password, string ContactNo, int Gender = 0, string CBy = null);

    // \EmployeeReg.aspx

    // AdminChangePassword.aspx
    [OperationContract]
    Boolean AdminChangePassword(int AdminID, string CurPwd, string Pwd);

    // \AdminChangePassword.aspx


    // AdminReg.aspx
    [OperationContract]
    IQueryable<tblAdmin> AdminRegBindData();

    [OperationContract]
    Boolean AdminRegistration(string FirstName, string LastName, string EmailID, string Password, string ContactNo, string Image, bool IsInsert, bool IsUpdate, bool IsDelete, int CBY, bool IsSuper);

    // \AdminReg.aspx


    // ClientReg.aspx
    [OperationContract]
    IQueryable<tblCountry> GetCountry();

    [OperationContract]
    IQueryable<tblState> GetState(int value);

    [OperationContract]
    IQueryable<tblCity> GetCity(int value);

    [OperationContract]
    IQueryable<tblClient> ClientRegBindData();

    [OperationContract]
    Boolean ClientRegistration(string Name, string EmailID, string Password, string ContactNo, string ComName = null, string WebURL = null, string Address = null, string Landmark = null, int City = 0, int ZipCode = 0, int CBY = 0);

    // \ClientReg.aspx

    // TrackProject.aspx

    [OperationContract]
    IQueryable<tblModule> BindModule(int ProjectID);

    [OperationContract]
    IQueryable<tblTask> BindTask(int ModuleID);

    // \TrackProject.aspx

    // \AdminServices---------------------------------------------------------------------------------------------------------------------------------------------------






    // ClientServices---------------------------------------------------------------------------------------------------------------------------------------------------


    // Default.aspx

    [OperationContract]
    IQueryable<tblProject> ProjectStatus();

    // \Default.aspx

    // NewsLetter

    [OperationContract]
    bool Subscribe(string Email);

    [OperationContract]
    bool UnSubscribe(string Email);

    [OperationContract]
    bool SubscribeEmailCheck(string Email);
    // \NewsLetter


    //EmailChecking

    [OperationContract]
    bool EmailCkecking(string Email, string Event);

    // \EmailChecking

    // ClientLogIn.aspx

    [OperationContract]
    IList<string> ClientLogin(string Email, string Password);

    [OperationContract]
    void ForgetChangePwd(string MailID, string Pwd);

    [OperationContract]
    IList<string> MailToPerson(string Email);

    [OperationContract]
    string GetPersonType(string Email);

    [OperationContract]
    int VerifyPerson(string Email);

    // \ClientLogIn

    // Services.aspx

    [OperationContract]
    IQueryable<tblCategory> Viewservice();

    [OperationContract]
    IQueryable<tblCategory> ViewSubservice(int CatID);

    // \Services.aspx

    // Profile.aspx

    [OperationContract]
    tblEmployee BindEmpProfile(int EmpID);

    [OperationContract]
    tblEmployee UpdateEmpProfile(int EmpID, string FirstName, string LastName, int gen, DateTime dob, string con, string email, string add, string Img);

    [OperationContract]
    IQueryable<tblSkill> ViewEmpSkill(int EmpID);

    [OperationContract]
    void AddEmpSkill(int EmpID, string SkillName);

    [OperationContract]
    void DelEmpSkill(int EmpID, int SkillID);

    // \Profile.aspx


    // PostProject.aspx

    [OperationContract]
    void AddInquiry(string Name, string EmailID, string ContactNo, string Description);

    [OperationContract]
    void AddPostProject(int ClientID, string CategoryID, string Title, string Description, string ContentUpload, DateTime DeadlineDate, int CreatedBy);

    [OperationContract]
    int CountContentTrans();

    // \PostProject.aspx

    // ProjectMaster.aspx

    [OperationContract]
    void AddModule(string ModuleName, int ProjectID, int ManagerID);

    [OperationContract]
    IQueryable<tblModule> BindNewProject(int ProjectID);

    [OperationContract]
    int BindTotalTask(int ModuleID);

    [OperationContract]
    tblModule BindProjectModule(int ModuleID);

    [OperationContract]
    IList<string> GetProjectDetail(int ProjectID);

    [OperationContract]
    IQueryable<tblTask> GetTaskList(int ModuleID);

    [OperationContract]
    bool AddTask(int ModuleID, string Title, int TeamLeaderID);

    // \ProjectMaster.aspx

    // ModuleDetail.aspx

    [OperationContract]
    IQueryable<tblEmployee> GetTeamLeader(int ProjectID, int ModuleID);

    //[OperationContract]
    //bool EditModule(int ModuleID, string Title, string Desc, int State, int Priority, int Risk, string TaskFile, DateTime SubmitedDate);

    // \ModuleDetail.aspx

    // TrackProject.aspx

    [OperationContract]
    IQueryable<tblModule> BindNewProjectTrack(int ProjectID);

    [OperationContract]
    IQueryable<tblProject> BindClientProject(int ClientID);

    [OperationContract]
    int GetProjectPoint(int ModuleID);

    // TrackProject.aspx

    // Feedback.aspx

    [OperationContract]
    tblClient GetClientDetail(string Email);

    [OperationContract]
    bool GiveFeedback(string Email, int ProjectID, float Point, string Desc);

    // \Feedback.aspx

    // \ClientServices
}

