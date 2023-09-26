using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.AddressData;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using JFS.Megazy.MilkyWaySolution.Engine;
using JFS.Megazy.MilkyWaySolution.Engine.Services;
using JFS.Megazy.MilkyWaySolution.Engine.Singleton;
using JFS.Megazy.MilkyWaySolution.Engine.Helpers;
using System.Data;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FormRequest;
using System.Web.Helpers;
using Newtonsoft.Json;
using JFS.Megazy.MilkyWaySolution.Engine.Request;
using System.Text;

namespace JFS.Megazy.MilkyWaySolution.Web.Front.Controllers
{
    public partial class FormController : BaseController
    {
        [HttpPost]
        public JsonResult SaveMateValue(MetaValueDataRepository req)
        {
            ResponseResult res = new ResponseResult();
            CaseProjectMetaCollection_Base obj = new CaseProjectMetaCollection_Base(CSystems.ProcessID);
            var row = obj.GetByPrimaryKey(req.MetaID,req.CaseID);
            obj.Dispose();
            if (req.caseProjectSchedule != null)
            {
                req.MetaKey = "CASEPROJECT_OF_SCHEDULE".Trim();
                req.MetaValue = JsonConvert.SerializeObject(req.caseProjectSchedule);
            }
            else if(req.caseProjectParticipant!=null)
            {
                req.MetaKey = "CASEPROJECT_OF_PARTICIPANT".Trim();
                req.MetaValue = JsonConvert.SerializeObject(req.caseProjectParticipant);
            }
            else if(req.projectProponent != null)
            {
                req.MetaKey = "CASEPROJECT_OF_PROJECTPROPONENT".Trim();
                req.MetaValue = JsonConvert.SerializeObject(req.projectProponent);
            }
            else if(req.projectResultAttachVideo != null)
            {
                req.MetaKey = "CASEPROJECT_OF_PROJECTRESULTATTACHVIDEO".Trim();
                req.MetaValue = JsonConvert.SerializeObject(req.projectResultAttachVideo);
            }
            else
            {
                req.MetaKey = "CASEPROJECT_OF_FOLLOWUPRESULT".Trim();
            }

            if (row != null)
            {
                row.MetaKey = req.MetaKey;
                row.MetaValue = req.MetaValue;
                obj = new CaseProjectMetaCollection_Base(CSystems.ProcessID);
                obj.Update(row);
                obj.Dispose();
                res.Status = true;
                
            }
            else
            {
                obj = new CaseProjectMetaCollection_Base(CSystems.ProcessID);
                int metaID = obj.Insert(new CaseProjectMetaRow
                {
                    CaseID = req.CaseID,
                    MetaKey = req.MetaKey,
                    MetaValue = req.MetaValue
                });
                obj.Dispose();
                res.Status = true;

                if (res.Status) 
                {
                    string whereSql = $"metaid={metaID}";
                    var rowatt = obj.GetRow(new List<SqlParameter>(), whereSql);
                    obj.Dispose();
                    if (rowatt != null)
                    {
                        res.Data = new MetaValueDataRepository
                        {
                            MetaID = rowatt.MetaID,
                            CaseID = rowatt.CaseID,
                            MetaKey = rowatt.MetaKey,
                            MetaValue = rowatt.MetaValue,
                            projectResultAttachVideo = JsonConvert.DeserializeObject<ProjectResultAttachVideo>(rowatt.MetaValue)
                        };

                    }
                }
            }

            return Json(res, JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public JsonResult SaveExpense(ExpensRequestData req)
        {
            ResponseResult res = new ResponseResult();
            DalBase dal = new DalBase();
            dal.DbBeginTransaction(CSystems.ProcessID);
            try
            {
                CaseExpenseCollection_Base caseExpense = new CaseExpenseCollection_Base(CSystems.ProcessID);
                caseExpense.Delete($"[CaseID] = {req.Expense[0].CaseID} AND [ApplicantID] = {req.Expense[0].ApplicantID}");
                foreach (var i in req.Expense)
                {
                    caseExpense.InsertOnlyPlainText(new CaseExpenseRow
                    {
                        CaseID = i.CaseID,
                        ApplicantID = i.ApplicantID,
                        ExpenseID = i.ExpenseID,
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                    });
                }
                caseExpense.Dispose();
                CaseExpenseExtensionCollection_Base caseExpenseEx = new CaseExpenseExtensionCollection_Base(CSystems.ProcessID);
                caseExpenseEx.Delete($"[CaseID] = {req.ExpenseEx[0].CaseID} AND [ApplicantID] = {req.ExpenseEx[0].ApplicantID}");
                foreach (var i in req.ExpenseEx)
                {
                    caseExpenseEx.InsertOnlyPlainText(new CaseExpenseExtensionRow
                    {
                        CaseID = i.CaseID,
                        ApplicantID = i.ApplicantID,
                        ExpenseID = i.ExpenseID,
                        PriceThreshold = i.PriceThreshold,
                        Unit = i.Unit,
                        Amount = i.Amount,
                        Remark = i.Remark,
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                    });
                }
                caseExpenseEx.Dispose();
                dal.DbCommit(CSystems.ProcessID);
                res.Status = true;
            }
            catch (Exception ex)
            {
                dal.DbRollBack(CSystems.ProcessID);
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return Json(res, JsonRequestBehavior.DenyGet);

        }
    }
}