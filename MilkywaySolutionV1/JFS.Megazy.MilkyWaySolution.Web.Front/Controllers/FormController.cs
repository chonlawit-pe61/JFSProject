using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using JFS.Megazy.MilkyWaySolution.Engine;
using JFS.Megazy.MilkyWaySolution.Engine.Services;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FormRequest;
using Newtonsoft.Json;
using JFS.Megazy.MilkyWaySolution.Engine.Request;
using System.Text;
using System.Configuration;

namespace JFS.Megazy.MilkyWaySolution.Web.Front.Controllers
{
    public partial class FormController : BaseController
    {
        // GET: OnlineRegister
        [WebViewAuthorizeFilter]
        public ActionResult Index()
        {
            SetMetaHtml(new ComponentHead { Title = "รายการยื่นคำขอ", MetaDescription = "รายการยื่นคำขอ กองทุนยุติธรรม" });
            return View();
        }
        [WebViewAuthorizeFilter]
        public ActionResult Register(int? id)
        {
            SetMetaHtml(new ComponentHead { Title = "ยื่นคำขอออนไลน์", MetaDescription = "ยื่นคำขอออนไลน์ กองทุนยุติธรรม" });
            if (id != null)
            {
                CaseRegisterDataResponse res = new CaseRegisterDataResponse();
                CaseApplicantRequestCollection_Base obj = new CaseApplicantRequestCollection_Base(CSystems.ProcessID);
                res.caseApplicant = obj.GetByPrimaryKey((int)id);
                obj.Dispose();
                CaseApplicantRequestExtensionCollection_Base exobj = new CaseApplicantRequestExtensionCollection_Base(CSystems.ProcessID);
                var row = exobj.GetByPrimaryKey((int)id);
                exobj.Dispose();
                if (row != null)
                {
                    res.caseProjectData = JsonConvert.DeserializeObject<CaseProjectDataRequest>(row.AdditionalDataJson);
                    ViewData["Remark"] = row.Remark;
                    View_TransectionAttachfileCollection_Base r_attachFile = new View_TransectionAttachfileCollection_Base(CSystems.ProcessID);
                    string whereSql = $"TransactionID={(int)id}";
                    var rows = r_attachFile.GetAsArray(new List<SqlParameter>(), whereSql, "");
                    r_attachFile.Dispose();
                    if (rows.Length > 0)
                    {
                        List<ProjectAttachfile> listAttachfiles = new List<ProjectAttachfile>();
                        foreach (var i in rows)
                        {
                            listAttachfiles.Add(new ProjectAttachfile { 
                                TransactionID = i.TransactionID, 
                                LableFile = i.LableFile,
                                FileType = i.FileType,
                                FileName = i.FileName, 
                                AttachFileID = i.AttachFileID,
                                Description = i.Description, 
                                Path = $"/download/document?url=/files/memberattachfile/{i.TransactionID}/{i.FileName}",
                                ModifiedDateStr = Engine.Helpers.Utility.ConvertDateToThaiString(i.ModifiedDate) 
                            });
                        }
                        ViewData["ProjectAttachfile"] = listAttachfiles;

                    }
                }
                return View(res);
            }
            else
            {
                return View();

            }
        }
        [WebViewAuthorizeFilter]
        public ActionResult Applicant()
        {
            SetMetaHtml(new ComponentHead { Title = "รายการที่รับเรื่องแล้ว", MetaDescription = "รายการที่รับเรื่องแล้ว กองทุนยุติธรรม" });
            return View();
        }
        [WebViewAuthorizeFilter]
        public ActionResult Detail(int caseID, int applicantID, int depID)
        {
            CurrentUser currentUser = SiteSession.GetCurrentUser();
            CaseRegisterDataService service = new CaseRegisterDataService();

            if (service.GetCaseRegisterDataResponse(caseID, applicantID, depID, currentUser.MemberID) != null)
            {
                string filepath = ConfigurationManager.AppSettings["FilePath"].ToString();

                View_MemberResultAttachFileCollection_Base r_attachFile = new View_MemberResultAttachFileCollection_Base(CSystems.ProcessID);
                string whereSql = $"caseid={caseID} AND applicantID={applicantID}";
                var rows = r_attachFile.GetAsArray(new List<SqlParameter>(), whereSql, "");
                r_attachFile.Dispose();
                if (rows.Length > 0)
                {
                    List<ProjectResultAttachfile> listResultAttachfiles = new List<ProjectResultAttachfile>();
                    foreach (var i in rows)
                    {
                        listResultAttachfiles.Add(new ProjectResultAttachfile { 
                            CaseID = i.CaseID, 
                            ApplicantID = i.ApplicantID, 
                            AttachFileID = i.AttachFileID, 
                            LableFile = i.LableFile, 
                            Description = i.Description, 
                            FileName = i.FileName, FileType = i.FileType, 
                            IsImage = i.IsImage, 
                            Path = filepath + $"/transaction/{i.CaseID}/{i.ApplicantID}/{i.FileName}",
                            //Path = $"/file/case/{i.CaseID}/{i.ApplicantID}/{i.FileName}"
                            ModifiedDateStr = Engine.Helpers.Utility.ConvertDateToThaiString(i.ModifiedDate) });
                    }
                    ViewData["ProjectResultAttachfile"] = listResultAttachfiles;

                }
                return View(service.GetCaseRegisterDataResponse(caseID, applicantID, depID, currentUser.MemberID));
            }
            else
            {
                return Redirect("/form");
            }
        }
        [HttpPost]
        public JsonResult TempRegister(FormRequest req)
        {
            FormRequestService service = new FormRequestService();
            string Additional = JsonConvert.SerializeObject(req.caseProjectData);
            ResponseResult res = new ResponseResult();
            var currentuser = SiteSession.GetCurrentUser();
            DalBase dal = new DalBase();
            try
            {
                dal.DbBeginTransaction(CSystems.ProcessID);
                int tempcaseid = service.InsertCaseApplicantTemp(req.data, currentuser.MemberID);
                if (tempcaseid != 0)
                {
                    res.DataID = tempcaseid;
                    res.Status = service.InsInsertOrUpdateRequestExtension(tempcaseid, Additional);
                }
                dal.DbCommit(CSystems.ProcessID);
            }
            catch (Exception ex)
            {
                dal.DbRollBack(CSystems.ProcessID);
                DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, ex);
            }

            return Json(res, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GetMscApplicant(string page = "1", CaseComponentFilters filters = null)
        {
            ResponseResult res = new ResponseResult();
            var currentUser = SiteSession.GetCurrentUser();
            try
            {
                int number = 0;
                if (!string.IsNullOrEmpty(page))
                {
                    bool result = int.TryParse(page, out number);
                }
                StringBuilder query = new StringBuilder();
                List<SqlParameter> listParameter = new List<SqlParameter>();
                string sql = $"MemberID = {currentUser.MemberID}";
                int startRowIndex = (CSystems.ItemPerPage * (number - 1));
                if (startRowIndex < 0)
                    startRowIndex = 0;
                res.Data = GetMscPages(startRowIndex, listParameter, sql);
                res.Status = true;
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, ex);
            }
            return Json(new { Result = res }, JsonRequestBehavior.DenyGet);
        }
        private View_CaseApplicantRequestItemsPaging GetMscPages(int startRowIndex
          , List<SqlParameter> listParameter
          , string whereSql = "", int rowPerPage = 20
          , string sortExpression = "ModifiedDate DESC")
        {

            View_CaseApplicantRequestCollection_Base obj = new View_CaseApplicantRequestCollection_Base(CSystems.ProcessID);
            View_CaseApplicantRequestItemsPaging res = obj.GetView_CaseApplicantRequestPagingAsArray(listParameter, whereSql, startRowIndex, rowPerPage, sortExpression);
            obj.Dispose();
            return res;
        }
        //private string ConvertMscCompenentFiltersToWheresql(CaseComponentFilters filters, ref List<SqlParameter> listParameter)
        //{
        //    StringBuilder query = new StringBuilder();
        //    CurrentUser currentUser = SiteSession.GetCurrentUser();
        //    string sql = $"MemberID = {currentUser.MemberID}";
        //    SqlParameter parameter;



        //    return sql;
        //}


        [HttpPost]
        public JsonResult GetCaseApplicant(string page = "1", CaseComponentFilters filters = null)
        {
            ResponseResult res = new ResponseResult();
            var currentUser = SiteSession.GetCurrentUser();
            try
            {
                int number = 0;
                if (!string.IsNullOrEmpty(page))
                {
                    bool result = int.TryParse(page, out number);
                }
                StringBuilder query = new StringBuilder();
                List<SqlParameter> listParameter = new List<SqlParameter>();
                string sql = $"MemberID = {currentUser.MemberID} AND DeletedFlag = 0 AND StatusID != 6";
                int startRowIndex = (CSystems.ItemPerPage * (number - 1));
                if (startRowIndex < 0)
                    startRowIndex = 0;
                res.Data = GetCasePages(startRowIndex, listParameter, sql);
                res.Status = true;
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, ex);
            }
            return Json(new { Result = res }, JsonRequestBehavior.DenyGet);
        }
        private View_CaseApplicationMemberMapping2ItemsPaging GetCasePages(int startRowIndex
  , List<SqlParameter> listParameter
  , string whereSql = "", int rowPerPage = 20
  , string sortExpression = "[CreateDate] DESC")
        {

            View_CaseApplicationMemberMapping2Collection_Base obj = new View_CaseApplicationMemberMapping2Collection_Base(CSystems.ProcessID);
            View_CaseApplicationMemberMapping2ItemsPaging res = obj.GetView_CaseApplicationMemberMapping2PagingAsArray(listParameter, whereSql, startRowIndex, rowPerPage, sortExpression);
            obj.Dispose();
            return res;
        }

        [HttpPost]
        public JsonResult SendReport(int caseid , string data)
        {
            ResponseResult res = new ResponseResult();
            CaseProjectMetaCollection_Base obj = new CaseProjectMetaCollection_Base(CSystems.ProcessID);
            CaseProjectMetaRow row = new CaseProjectMetaRow {
                    CaseID = caseid,
                    MetaKey = "CASEPROJECT_SENDREPORT",
                    MetaValue = data
                };
            obj.Insert(row);  
            obj.Dispose();
            res.Status = true;
            return Json(res, JsonRequestBehavior.DenyGet);
        }

    }
}