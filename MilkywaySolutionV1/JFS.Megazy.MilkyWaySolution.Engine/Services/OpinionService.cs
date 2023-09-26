using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Helpers;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class OpinionService
    {
        public CaseApplicantOfficerOpinionData GetCaseApplicantOfficerOpinion(int applicantID)
        {
            CaseApplicantOfficerOpinionData res = null;
            CaseApplicantOfficerOpinionCollection_Base officerOpinion = new CaseApplicantOfficerOpinionCollection_Base(CSystems.ProcessID);
            CaseApplicantOfficerOpinionRow officerOpinionRow = officerOpinion.GetByPrimaryKey(applicantID);
            if (officerOpinionRow != null)
            {

                res = new CaseApplicantOfficerOpinionData();
                res.ApplicantID = officerOpinionRow.ApplicantID;
                res.Circumstance = officerOpinionRow.Circumstance;
                res.Consideration = officerOpinionRow.Consideration;
                res.ApplicantSummary = officerOpinionRow.ApplicantSummary;
                res.ModifiedDate = officerOpinionRow.ModifiedDate;

            }
            officerOpinion.Dispose();
            return res;
        }
        public bool InsertOrUpdateCaseApplicantOfficerOpinion(CaseApplicantOfficerOpinionData req)
        {
            bool status = false;
            CaseApplicantOfficerOpinionCollection_Base officerOpinion = new CaseApplicantOfficerOpinionCollection_Base(CSystems.ProcessID);
            var officerOpinionRow = officerOpinion.GetByPrimaryKey(req.ApplicantID);
            DalBase dal = new DalBase();
            if (officerOpinionRow != null)
            {
                if (!string.IsNullOrWhiteSpace(req.ApplicantSummary))
                {
                    officerOpinionRow.ApplicantSummary = req.ApplicantSummary;
                }
                if (!string.IsNullOrWhiteSpace(req.Consideration))
                {
                    officerOpinionRow.Consideration = req.Consideration;
                }
                if (!string.IsNullOrWhiteSpace(req.Circumstance))
                {
                    officerOpinionRow.Circumstance = req.Circumstance;
                }

                officerOpinionRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);

                officerOpinion.UpdateOnlyPlainText(officerOpinionRow);
                status = true;
            }
            else
            {
                officerOpinion.InsertOnlyPlainText(new CaseApplicantOfficerOpinionRow
                {
                    ApplicantID = req.ApplicantID,
                    ApplicantSummary = req.ApplicantSummary,
                    Circumstance = req.Circumstance,
                    Consideration = req.Consideration,
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                });
                status = true;

            }
            Engine.Services.TrackingService.Log(req.ApplicantID, "_CaseOpinionOfficer");
            officerOpinion.Dispose();
            return status;

        }

        /// <summary>
        /// int applicantID,int officerRoleID
        /// </summary>
        /// <param name="applicantID"></param>
        /// <param name="officerRoleID"></param>
        /// <returns></returns>
        public CaseApplicantOpinionData GetCaseApplicantOpinion(int applicantID, int officerRoleID, bool isAppeal)
        {
            CaseApplicantOpinionData res = null;
            CaseApplicantOpinionCollection_Base applicantOpinion = new CaseApplicantOpinionCollection_Base(CSystems.ProcessID);
            //List<SqlParameter> parameters = new List<SqlParameter>();
            //string whereSql = $"ApplicantID = {applicantID} AND officerRoleID = {officerRoleID}"; 
            CaseApplicantOpinionRow applicantOpinionRow = applicantOpinion.GetByPrimaryKey(applicantID, officerRoleID, isAppeal);
            applicantOpinion.Dispose();
            if (applicantOpinionRow != null)
            {
                res = new CaseApplicantOpinionData();
                res.ApplicantID = applicantOpinionRow.ApplicantID;
                res.OfficerRoleID = applicantOpinionRow.OfficerRoleID;
                res.IsAppeal = applicantOpinionRow.IsAppeal;
                res.TermID = applicantOpinionRow.TermID;
                res.IsFinalApproved = applicantOpinionRow.IsFinalApproved;
                res.OpinionID = applicantOpinionRow.OpinionID;
                res.AdditionalOpinion = applicantOpinionRow.AdditionalOpinion;
                res.Comment = applicantOpinionRow.Comment;
                res.ShortComment = applicantOpinionRow.ShortComment;
                res.Remark = applicantOpinionRow.Remark;
                res.IssueDate = applicantOpinionRow.IssueDate;
                res.CompleteDate = applicantOpinionRow.CompleteDate;
                res.FollowAsOfficerRoleID = applicantOpinionRow.FollowAsOfficerRoleID;
                res.ModifiedDate = applicantOpinionRow.ModifiedDate;
            }
            return res;
        }
        //public bool InsertOrUpdateCaseApplicantOpinion(CaseApplicantOpinionData req)
        //{ //, int applicantID, int officerRoleID,bool isAppeal

        //    bool status = false;
        //    int state = 1;
        //    CaseApplicantOpinionCollection_Base applicantOpinion = new CaseApplicantOpinionCollection_Base(CSystems.ProcessID);
        //    CaseApplicantOpinionRow applicantOpinionRow = applicantOpinion.GetByPrimaryKey(req.ApplicantID, req.OfficerRoleID, req.IsAppeal);
        //    DalBase dal = new DalBase();
        //    if (applicantOpinionRow == null)
        //    {
        //        applicantOpinionRow = new CaseApplicantOpinionRow();
        //        state = 0;
        //    }
        //    applicantOpinionRow.ApplicantID = req.ApplicantID;
        //    applicantOpinionRow.OfficerRoleID = req.OfficerRoleID;
        //    //applicantOpinionRow.TermID = req.TermID;
        //    applicantOpinionRow.OpinionID = req.OpinionID;
        //    if (!string.IsNullOrWhiteSpace(req.AdditionalOpinion))
        //    {
        //        applicantOpinionRow.AdditionalOpinion = req.AdditionalOpinion;
        //    }
        //    if (!string.IsNullOrWhiteSpace(req.Comment))
        //    {
        //        applicantOpinionRow.Comment = req.Comment;
        //    }
        //    if (!string.IsNullOrWhiteSpace(req.ShortComment))
        //    {
        //        applicantOpinionRow.ShortComment = req.ShortComment;
        //    }
        //    if (!string.IsNullOrWhiteSpace(req.Remark))
        //    {
        //        applicantOpinionRow.Remark = req.Remark;
        //    }
        //    if (req.IssueDate != DateTime.MinValue)
        //    {
        //        applicantOpinionRow.IssueDate = req.IssueDate;
        //    }
        //    if (req.CompleteDate != DateTime.MinValue)
        //    {
        //        applicantOpinionRow.CompleteDate = req.CompleteDate;
        //    }
        //    if (req.FollowAsOfficerRoleID != 0)
        //    {
        //        applicantOpinionRow.FollowAsOfficerRoleID = req.FollowAsOfficerRoleID;
        //    }

        //    applicantOpinionRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
        //    if (state == 0)
        //    {
        //        applicantOpinion.InsertOnlyPlainText(applicantOpinionRow);
        //    }
        //    else
        //    {
        //        applicantOpinion.UpdateOnlyPlainText(applicantOpinionRow);
        //    }

        //    applicantOpinion.Dispose();
        //    status = true;
        //    return status;
        //}

        public bool InsertOrUpdateCaseApplicantOpinion(CaseApplicantOpinionData req, int processID)
        {
            bool status = false;
            int state = 1;
            DalBase dal = new DalBase();
            try
            {
                CaseApplicantOpinionCollection_Base applicantOpinion = new CaseApplicantOpinionCollection_Base(processID);
                CaseApplicantOpinionRow applicantOpinionRow = applicantOpinion.GetByPrimaryKey(req.ApplicantID, req.OfficerRoleID, req.IsAppeal);
                if (applicantOpinionRow == null)
                {
                    applicantOpinionRow = new CaseApplicantOpinionRow();
                    state = 0;
                }
                //CaseApplicantOpinionRow applicantOpinionRow = new CaseApplicantOpinionRow();
                applicantOpinionRow.ApplicantID = req.ApplicantID;
                applicantOpinionRow.OfficerRoleID = req.OfficerRoleID;
                applicantOpinionRow.IsAppeal = req.IsAppeal;
                applicantOpinionRow.IsFinalApproved = req.IsFinalApproved;
                if (req.TermID != 0)
                {
                    applicantOpinionRow.TermID = req.TermID;
                }
                applicantOpinionRow.OpinionID = req.OpinionID;
                if (!string.IsNullOrWhiteSpace(req.AdditionalOpinion))
                {
                    applicantOpinionRow.AdditionalOpinion = req.AdditionalOpinion;
                }
                if (!string.IsNullOrWhiteSpace(req.Comment))
                {
                    applicantOpinionRow.Comment = req.Comment;
                }
                if (!string.IsNullOrWhiteSpace(req.ShortComment))
                {
                    applicantOpinionRow.ShortComment = req.ShortComment;
                }
                if (!string.IsNullOrWhiteSpace(req.Remark))
                {
                    applicantOpinionRow.Remark = req.Remark;
                }
                if (!string.IsNullOrWhiteSpace(req.IssueDateStr))
                {
                    applicantOpinionRow.IssueDate = Utility.ConvertStringToDate(req.IssueDateStr);
                }
                if (!string.IsNullOrWhiteSpace(req.CompleteDateStr))
                {
                    applicantOpinionRow.CompleteDate = Utility.ConvertStringToDate(req.CompleteDateStr);
                }
                if (req.FollowAsOfficerRoleID != 0)
                {
                    applicantOpinionRow.FollowAsOfficerRoleID = req.FollowAsOfficerRoleID;
                }
                applicantOpinionRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                if (state == 0)
                {
                    applicantOpinion.InsertOnlyPlainText(applicantOpinionRow);
                }
                else
                {
                    applicantOpinion.UpdateOnlyPlainText(applicantOpinionRow);
                }
                applicantOpinion.Dispose();
                status = true;
            }
            catch (Exception ex)
            {

                DalBase.ExceptEngine.ThrowException(processID, ex);
            }
            return status;
        }

        /// <summary>
        /// บันทึกวงเงินสำหรับ การอนุมัติเท่านั้น
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public int InsertOrUpdateOfficerApprovedExpense(OfficerApprovedExpenseData req)// int approveID,int opinionID ,int applicantID,int caseID, double totalamount,string note , bool IsFinalApproved)
        {
            int approveID = 0;
            DalBase dal = new DalBase();

            OfficerApprovedExpenseCollection_Base obj = new OfficerApprovedExpenseCollection_Base(CSystems.ProcessID);
            string whereSql = "";
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter();// ("@CaseID", System.Data.SqlDbType.Int) { Value = req.CaseID };
            if (req.IsFinalApproved)
            {
                //ลบรายการที่เป็น final approved ออกก่อน
                sqlpara = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = req.CaseID };
                parameter.Add(sqlpara);
                sqlpara = new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = req.ApplicantID };
                //parameter.Add(sqlpara);
                //sqlpara = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = req.DepartmentID };
                parameter.Add(sqlpara);
                whereSql = "[CaseID] = @CaseID AND ApplicantID=@ApplicantID AND IsFinalApproved=1";
                var rowfinal = obj.GetRow(parameter, whereSql);
                obj.Dispose();
                if (rowfinal != null)
                {
                    DeleteOfficerApprovedExpense(rowfinal.OfficerRoleID, rowfinal.ApplicantID);
                }
            }
            parameter = new List<SqlParameter>();
            sqlpara = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = req.CaseID };
            parameter.Add(sqlpara);
            sqlpara = new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = req.ApplicantID };
            parameter.Add(sqlpara);
            //sqlpara = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = req.DepartmentID };
            //parameter.Add(sqlpara);
            sqlpara = new SqlParameter("@OfficerRoleID", System.Data.SqlDbType.Int) { Value = req.OfficerRoleID };
            parameter.Add(sqlpara);
            whereSql = "[CaseID] = @CaseID AND ApplicantID=@ApplicantID AND OfficerRoleID=@OfficerRoleID ";
            var row = obj.GetRow(parameter, whereSql);
            if (row != null)
            {
                row.CaseID = req.CaseID;
                row.ApplicantID = req.ApplicantID;
                row.OfficerRoleID = req.OfficerRoleID;
                //row.DepartmentID = req.DepartmentID;
                row.TotalAmount = req.TotalAmount;
                row.Note = req.Note;
                row.IsFinalApproved = req.IsFinalApproved;
                row.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                obj.Update(row);
                approveID = row.ApprovedID;
            }
            else
            {
                // approveID = GetMaxOfficerApprovedExpenseID() + 1;
                approveID = obj.InsertOnlyPlainText(new OfficerApprovedExpenseRow
                {
                   // ApprovedID = approveID,
                    CaseID = req.CaseID,
                    ApplicantID = req.ApplicantID,
                    //DepartmentID = req.DepartmentID,
                    OfficerRoleID = req.OfficerRoleID,
                    TotalAmount = req.TotalAmount,
                    Note = req.Note,
                    IsFinalApproved = req.IsFinalApproved,
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                });
            }
            obj.Dispose();
            //ยกเลิกใช้งาน 4 ส.ค 63 ให้ไปใช้  OfficerApprovedExpense where IsFinalApproved = 1
            //if (req.IsFinalApproved)
            //{
            //    //บันทึกข้อมูล กรณีที่อนุมัติเท่านั้น
            //    InsertOrUpdateCaseApproved(new CaseApprovedData
            //    {
            //        ApprovedID = approveID,
            //        ApprovedAmount = req.TotalAmount,
            //        CaseID = req.CaseID,
            //    });
            //}
            return approveID;
        }
        public void DeleteOfficerApprovedExpense(int officerRoleID, int applicantID)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@officerroleID", System.Data.SqlDbType.Int) { Value = officerRoleID };
            parameters.Add(sqlpara);
            sqlpara = new SqlParameter("@applicantID", System.Data.SqlDbType.Int) { Value = applicantID };
            parameters.Add(sqlpara);
            string wheresql = "OfficerRoleID=@officerroleID AND ApplicantID=@applicantID";
            OfficerApprovedExpenseCollection_Base obj = new OfficerApprovedExpenseCollection_Base(CSystems.ProcessID);
            var row = obj.GetRow(parameters, wheresql);
            obj.Dispose();
            if (row != null)
            {
                //CaseApprovedCollection_Base caseApproved = new CaseApprovedCollection_Base(CSystems.ProcessID);
                //caseApproved.DeleteByPrimaryKey(row.ApprovedID);
                //caseApproved.Dispose();
                //Step 1:
                OfficerFinalApprovedMapBudgetCollection_Base caseBudget = new OfficerFinalApprovedMapBudgetCollection_Base(CSystems.ProcessID);
                caseBudget.DeleteByApprovedID(row.ApprovedID);
                caseBudget.Dispose();
                //Step 2:
                OfficerApprovedExpenseListCollection_Base objlist = new OfficerApprovedExpenseListCollection_Base(CSystems.ProcessID);
                objlist.DeleteByApprovedID(row.ApprovedID);
                obj.DeleteByPrimaryKey(row.ApprovedID);
                objlist.Dispose();
                //Step 3:
                obj = new OfficerApprovedExpenseCollection_Base(CSystems.ProcessID);
                obj.DeleteByPrimaryKey(row.ApprovedID);
                obj.Dispose();
            }

        }
        //private int GetMaxOfficerApprovedExpenseID()
        //{
        //    int id = 0;
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    OfficerApprovedExpenseCollection_Base obj = new OfficerApprovedExpenseCollection_Base(CSystems.ProcessID);
        //    var approv = obj.GetRow(parameters, "ApprovedID IN (SELECT MAX(ApprovedID) FROM [OfficerApprovedExpense])");
        //    obj.Dispose();
        //    if (approv == null)
        //    {
        //        id = 0;
        //    }
        //    else
        //    {
        //        id = approv.ApprovedID;
        //    }
        //    return id;
        //}
        public bool InsertOrUpdateOfficerApprovedExpenseList(int approveID, OfficerApprovedExpenseListData[] req)
        {
            bool isPass = false;
            DalBase dal = new DalBase();

            OfficerApprovedExpenseListCollection_Base obj = new OfficerApprovedExpenseListCollection_Base(CSystems.ProcessID);
            obj.DeleteByApprovedID(approveID);
            obj.Dispose();
            if (req != null && req.Length != 0)
            {
                foreach (var item in req)
                {
                    if (item != null)
                    {
                        obj = new OfficerApprovedExpenseListCollection_Base(CSystems.ProcessID);
                        obj.InsertOnlyPlainText(new OfficerApprovedExpenseListRow
                        {
                            ApprovedID = approveID,
                            ExpenseID = item.ExpenseID,
                            Amount = item.Amount,
                            Note = item.Note,
                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                        });
                        obj.Dispose();
                    }
                }
            }
            return isPass;
        }
        public void InsertOrUpdateOfficerFinalApprovedMapBudget(int approveID, int budgetID)
        {
            OfficerFinalApprovedMapBudgetCollection_Base obj = new OfficerFinalApprovedMapBudgetCollection_Base(CSystems.ProcessID);
            obj.DeleteByApprovedID(approveID);
            if (budgetID > 0)
            {
                obj.InsertOnlyPlainText(new OfficerFinalApprovedMapBudgetRow
                {
                    ApprovedID = approveID,
                    BudgetID = budgetID
                });
            }
        }
        //public bool InsertOrUpdateCaseApplicationTermID(int caseID, int termID)
        //{

        //    bool status = false;
        //    DalBase dal = new DalBase();
        //    CaseApplicationCollection_Base obj = new CaseApplicationCollection_Base(CSystems.ProcessID);
        //    var row = obj.GetByPrimaryKey(caseID);
        //    if(row != null)
        //    {
        //        row.TermID = termID;
        //        row.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
        //        obj.Update(row);
        //    }
        //    obj.Dispose();
        //    status = true;

        //    return status;

        //}
        public bool InsertOrUpdateCaseTerm(CaseTermData req, int applicantID, bool isAppeal = false)
        {
            bool isPass = false;
            CaseTermCollection_Base obj = new CaseTermCollection_Base(CSystems.ProcessID);
           var row =  obj.GetByPrimaryKey(req.CaseID);
            obj.Dispose();
            if (row != null)
            {
                //ผู้ที่อนุมัติขั้นตอนสุดท้าย
                // OfficerRoleID FinalApproveName
                //4   เลขานุการคณะอนุกรรมการฯ
                //5   ประธานอนุกรรมการฯ
                //7   คณะอนุกรรมการฯ
                if (row.FinalApproveID != req.FinalApproveID)
                {
                    //กรณีเปลี่ยนผู้อนุมัติ จึงต้องลบข้อมูลความคิดเห็นผู้ที่อนุมัติก่อนหน้านั้น
                    string sql = string.Format("ApplicantID ={0} AND OfficerRoleID={1} AND IsAppeal={2}", applicantID, row.FinalApproveID, (isAppeal ? 1 : 0));
                    CaseApplicantOpinionCollection_Base caseApplicantOpinion = new CaseApplicantOpinionCollection_Base(CSystems.ProcessID);
                    caseApplicantOpinion.Delete(sql);
                    caseApplicantOpinion.Dispose();

                    OfficerApprovedExpenseCollection_Base officerApprovedExpense = new OfficerApprovedExpenseCollection_Base(CSystems.ProcessID);
                    List<SqlParameter> parameter = new List<SqlParameter>();
                    SqlParameter sqlpara = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = req.CaseID };
                    parameter.Add(sqlpara);
                    sqlpara = new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = applicantID };
                    parameter.Add(sqlpara);
                    sqlpara = new SqlParameter("@OfficerRoleID", System.Data.SqlDbType.Int) { Value = row.FinalApproveID };
                    parameter.Add(sqlpara);
                    string whereSql = "[CaseID]=@CaseID AND [ApplicantID] = @ApplicantID AND [OfficerRoleID]=@OfficerRoleID";
                    var rowOfficerApprovedExpense = officerApprovedExpense.GetRow(parameter, whereSql);
                    officerApprovedExpense.Dispose();
                    if (rowOfficerApprovedExpense != null)
                    {
                        OfficerFinalApprovedMapBudgetCollection_Base officerFinalApprovedMap = new OfficerFinalApprovedMapBudgetCollection_Base(CSystems.ProcessID);
                        officerFinalApprovedMap.DeleteByApprovedID(rowOfficerApprovedExpense.ApprovedID);
                        officerFinalApprovedMap.Dispose();

                        OfficerApprovedExpenseListCollection_Base officerApprovedExpenseList = new OfficerApprovedExpenseListCollection_Base(CSystems.ProcessID);
                        officerApprovedExpenseList.DeleteByApprovedID(rowOfficerApprovedExpense.ApprovedID);
                        officerApprovedExpenseList.Dispose();

                        officerApprovedExpense = new OfficerApprovedExpenseCollection_Base(CSystems.ProcessID);
                        officerApprovedExpense.DeleteByPrimaryKey(rowOfficerApprovedExpense.ApprovedID);
                        officerApprovedExpense.Dispose();

                        CaseMattersOfLawOpinionCollection_Base caseMattersOfLawOpinion = new CaseMattersOfLawOpinionCollection_Base(CSystems.ProcessID);
                        caseMattersOfLawOpinion.DeleteByAppicantID(applicantID);
                        caseMattersOfLawOpinion.Dispose();
                    }

                }
                obj = new CaseTermCollection_Base(CSystems.ProcessID);
                obj.DeleteByPrimaryKey(row.CaseID);
                obj.Dispose();

                row.TemID = req.TemID;
                row.FinalApproveID = req.FinalApproveID;
                row.SubcommitteeID = req.SubcommitteeID;
                row.ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID);
                obj = new CaseTermCollection_Base(CSystems.ProcessID);
                obj.InsertOnlyPlainText(row);
                obj.Dispose();
            }
            else
            {
                obj = new CaseTermCollection_Base(CSystems.ProcessID);
                //obj.DeleteByPrimaryKey(req.CaseID);
                obj.InsertOnlyPlainText(new CaseTermRow
                {
                    CaseID = req.CaseID,
                    TemID = req.TemID,
                    FinalApproveID = req.FinalApproveID,
                    SubcommitteeID = req.SubcommitteeID,
                    ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID)
                });
                obj.Dispose();

            }
           
           
            isPass = true;
            return isPass;
        }

        //บันทึกข้อมูล กรณีที่อนุมัติเท่านั้น
        public void InsertOrUpdateCaseApproved(CaseApprovedData req)
        {
            DalBase dal = new DalBase();
            try
            {
                CaseApprovedCollection_Base caseApproved = new CaseApprovedCollection_Base(CSystems.ProcessID);
                var approvedRow = caseApproved.GetByPrimaryKey(req.ApprovedID);
                if (approvedRow != null)
                {
                    approvedRow.ApprovedAmount = req.ApprovedAmount;
                    approvedRow.CaseID = req.CaseID;
                    approvedRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                    caseApproved.UpdateOnlyPlainText(approvedRow);
                }
                else
                {
                    caseApproved.InsertOnlyPlainText(new CaseApprovedRow
                    {
                        ApprovedID = req.ApprovedID,
                        ApprovedAmount = req.ApprovedAmount,
                        CaseID = req.CaseID,
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                    });
                }
                caseApproved.Dispose();
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
        }
        public bool SaveNotifyDecisionResult(NotifyDecisionResultData req,int processID = 0)
        {
            //Fix for async ebidt by piak
            if (processID == 0)
            {
                processID = CSystems.ProcessID;
            }
            DalBase dal = new DalBase();
            DateTime Date = dal.GetSqlNow(CSystems.ProcessID);
            DateTime notifyDate = Utility.ConvertStringToDate(req.NotifyDateStr);
            DateTime currentDate = dal.GetSqlNow(CSystems.ProcessID);
            if (!string.IsNullOrWhiteSpace(req.NotifyDateStr))
            {
                if ((notifyDate.Year - currentDate.Year) > 100)
                {
                    Date = notifyDate.AddYears(-543);
                }
                else
                {
                    Date = notifyDate;
                }
            }
            try
            {
              //  dal.DbBeginTransaction(CSystems.ProcessID);

                NotifyDecisionResultCollection_Base obj = new NotifyDecisionResultCollection_Base(processID);
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlpara = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = req.CaseID };
                parameter.Add(sqlpara);
                sqlpara = new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = req.ApplicantID };
                parameter.Add(sqlpara);
                string whereSql = "[CaseID] = @CaseID AND ApplicantID=@ApplicantID";
                var row = obj.GetRow(parameter, whereSql);
                if (row != null)
                {
                    if (!string.IsNullOrWhiteSpace(req.Note))
                        row.Note = req.Note;
                    if (!string.IsNullOrWhiteSpace(req.TelephoneNo))
                        row.TelephoneNo = req.TelephoneNo;
                    if (!string.IsNullOrWhiteSpace(req.Email))
                        row.Email = req.Email;
                    if (req.IsSendEmail)
                        row.IsSendEmail = req.IsSendEmail;
                    if (req.IsSendSMS)
                        row.IsSendSMS = req.IsSendSMS;
                    if (!string.IsNullOrWhiteSpace(req.NotifyDateStr))
                    {
                        row.NotifyDate = Date;
                    }    
                        
                    row.ModifiedDate = dal.GetSqlNow(processID);
                    obj.UpdateOnlyPlainText(row);
                }
                else
                {
                    obj.InsertOnlyPlainText(new NotifyDecisionResultRow
                    {
                        ApplicantID = req.ApplicantID,
                        CaseID = req.CaseID,
                        Email = req.Email,
                        TelephoneNo = req.TelephoneNo,
                        Note = req.Note,
                        ModifiedDate = dal.GetSqlNow(processID),
                        NotifyDate = !string.IsNullOrWhiteSpace(req.NotifyDateStr)? Date: dal.GetSqlNow(CSystems.ProcessID),
                        IsSendEmail = req.IsSendEmail,
                        IsSendSMS = req.IsSendSMS,
                    });
                    Engine.Services.TrackingService.LogAsync(req.ApplicantID, "_CaseResult",false, processID);


                }
                obj.Dispose();
              //  dal.DbCommit(CSystems.ProcessID);

            }
            catch (Exception ex)
            {
               // dal.DbRollBack(CSystems.ProcessID);
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }
            return true;
        }
        //public bool SaveDateNotifyDecisionResult(int caseID,int applicantID, string notifyDate)
        //{
        //    DalBase dal = new DalBase();
        //    try
        //    {
        //        if (!string.IsNullOrWhiteSpace(notifyDate))
        //        {
        //            dal.DbBeginTransaction(CSystems.ProcessID);
        //            NotifyDecisionResultCollection_Base obj = new NotifyDecisionResultCollection_Base(CSystems.ProcessID);
        //            List<SqlParameter> parameter = new List<SqlParameter>();
        //            SqlParameter sqlpara = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = caseID };
        //            parameter.Add(sqlpara);
        //            sqlpara = new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = applicantID };
        //            parameter.Add(sqlpara);
        //            string whereSql = "[CaseID] = @CaseID AND ApplicantID=@ApplicantID";
        //            var row = obj.GetRow(parameter, whereSql);
        //            if (row != null)
        //            {
        //                row.NotifyDate = Utility.ConvertStringToDate(notifyDate);
        //                row.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
        //                obj.UpdateOnlyPlainText(row);
        //            }
        //            obj.Dispose();
        //            dal.DbCommit(CSystems.ProcessID);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dal.DbRollBack(CSystems.ProcessID);
        //        DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
        //    }
        //    return true;
        //}

        public DecisionDataResponse GetFinalApproved(int caseID, bool isAppeal, int applicantID)
        {
            DecisionDataResponse res = new DecisionDataResponse();
            try
            {

                CaseTermCollection_Base obj = new CaseTermCollection_Base(CSystems.ProcessID);
                var row = obj.GetByPrimaryKey(caseID);
                obj.Dispose();
                if (row != null)
                {
                    res.CaseID = row.CaseID;

                    CaseApplicantOpinionCollection_Base opn = new CaseApplicantOpinionCollection_Base(CSystems.ProcessID);
                    var opnRow = opn.GetByPrimaryKey(applicantID, row.FinalApproveID, isAppeal);
                    opn.Dispose();
                    if (opnRow != null)
                    {
                        res.ApplicantID = opnRow.ApplicantID;
                        res.OfficerRoleID = opnRow.OfficerRoleID;
                        res.ShortDescription = opnRow.Comment;
                        if (!opnRow.IsCompleteDateNull)
                        {
                            res.DecisionDate = Utility.ConvertDateToThaiLongDate(opnRow.CompleteDate);
                        }
                        View_OfficerMapOpinionCollection_Base officopn = new View_OfficerMapOpinionCollection_Base(CSystems.ProcessID);
                        var officopnRow = officopn.GetRow(new List<SqlParameter>(), "OfficerRoleID=" + row.FinalApproveID + " AND OpinionID=" + opnRow.OpinionID);
                        officopn.Dispose();

                       // DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, new Exception("test1111"));

                        if (officopnRow != null)
                        {
                            res.OpinionID = officopnRow.OpinionID;
                            res.OpinionText = officopnRow.OpinionName;
                        }
                        NotifyDecisionResultCollection_Base notifyDecisionResult = new NotifyDecisionResultCollection_Base(CSystems.ProcessID);
                        var notifyDecisionResultRow = notifyDecisionResult.GetRow(new List<SqlParameter>(), "CaseID=" + row.CaseID + " AND ApplicantID=" + opnRow.ApplicantID);
                        notifyDecisionResult.Dispose();
                        if (notifyDecisionResultRow != null)
                        {
                            res.Email = notifyDecisionResultRow.Email;
                            res.TelephonNo = notifyDecisionResultRow.TelephoneNo;
                            res.IsSendEmail = notifyDecisionResultRow.IsSendEmail;
                            res.IsSendSMS = notifyDecisionResultRow.IsSendSMS;
                            if (!notifyDecisionResultRow.IsNotifyDateNull)
                            {
                                res.NotifyDateStr = Utility.ConvertDateToThaiLongDate(notifyDecisionResultRow.NotifyDate);
                                res.NotifyDate = notifyDecisionResultRow.NotifyDate;
                            }
                        }
                    }
                    //CaseApprovedCollection_Base ap = new CaseApprovedCollection_Base(CSystems.ProcessID);
                    //var apRow = ap.GetRow(new List<SqlParameter>(), "CaseID=" + caseID);
                    //ap.Dispose();
                    //if (apRow != null)
                    //{
                    //    res.Amount = apRow.ApprovedAmount;
                    //}



                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }

            return res;
        }

        public void InsertOrUpdateOpinionForm(int applicantid, int formid , OpinionReportData req)
        {
            DalBase dal = new DalBase();
            try
            {
             
                OpinionReportCollection_Base obj = new OpinionReportCollection_Base(CSystems.ProcessID);
                var row = obj.GetRow(new List<SqlParameter>(), $"ApplicantID={applicantid} AND FormID={formid}");
                
                if(row != null)
                {
                    row.ApplicantID = applicantid;
                    row.FormID = formid;
                    row.ChairmanName = req.ChairmanName;
                    row.ChairmanPosition = req.ChairmanPosition;
                    row.DirectorName = req.DirectorName;
                    row.DirectorPosition = req.DirectorPosition;
                    row.SeniorLawyerName = req.SeniorLawyerName;
                    row.SeniorPosition = req.SeniorPosition;
                    obj.Update(row);
                }
                else
                {
                    obj.InsertOnlyPlainText(new OpinionReportRow
                    {
                        ApplicantID = applicantid,
                        FormID = formid,
                        ChairmanName = req.ChairmanName,
                        ChairmanPosition = req.ChairmanPosition,
                        DirectorName = req.DirectorName,
                        DirectorPosition = req.DirectorPosition,
                        SeniorLawyerName = req.SeniorLawyerName,
                        SeniorPosition = req.SeniorPosition,
                        CrateDate = dal.GetSqlNow(CSystems.ProcessID)
                    });
                }
                obj.Dispose();
             }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
        }
        public bool GetIsPay(int opinionID)
        {
            OpinionCollection_Base obj = new OpinionCollection_Base(CSystems.ProcessID);
            var row = obj.GetByPrimaryKey(opinionID);
            obj.Dispose();
            return row != null && row.IsPay;
        }

    }
}
