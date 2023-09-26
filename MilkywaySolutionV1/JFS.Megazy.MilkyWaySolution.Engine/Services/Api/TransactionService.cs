using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.TrackingApi;
using JFS.Megazy.MilkyWaySolution.Engine.Helpers;
using JFS.Megazy.MilkyWaySolution.Engine.Request;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.Api
{
    public class TransactionService
    {
        public TrackingDataResult TrackingApplicant(TrackingFilters filters)
        {
            TrackingDataResult res = new TrackingDataResult();

            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>();
                string sql = ConvertCompenentFiltersToWheresqlTracking(filters, ref listParameter);
                var row = GetValueTracking(ref listParameter, sql);
                if(row != null)
                {
                    TrackingData data = new TrackingData();
                    data.Title = row.Title;
                    data.FirstName = row.FirstName;
                    data.LastName = row.LastName;
                    listParameter = new List<SqlParameter>();
                    sql = ConvertCompenentFiltersToWheresqlTracking(filters, ref listParameter);
                    var caselist = GetValueTrackingList(ref listParameter, sql);
                    if(caselist.Length > 0)
                    {
                        data.TotalCase = caselist.Length;
                        data.TotalCompletedCase = caselist.Where(o => o.WorkStepID >= 6).Count();
                        data.TotalProcessingCase = caselist.Where(o => o.WorkStepID < 6).Count();
                    }
                    data.ListCase = new List<ApplicantCase>();
                    foreach (var item in caselist)
                    {
                        var tempCase = new ApplicantCase();
                        tempCase.JFCaseNo = item.JFCaseNo;
                        tempCase.StepList = new List<ApplicantCaseDetail>();
                        ApplicantCaseDetail tempWorkStep = new ApplicantCaseDetail();
                        tempWorkStep = GetChangeWorkStep(item.CaseID, item.ApplicantID, item.DepartmentID, 2);
                        tempCase.StepList.Add(tempWorkStep);
                        tempWorkStep = new ApplicantCaseDetail();
                        tempWorkStep = GetChangeWorkStep(item.CaseID, item.ApplicantID, item.DepartmentID, 3);
                        tempCase.StepList.Add(tempWorkStep);
                        tempWorkStep = new ApplicantCaseDetail();
                        tempWorkStep = GetChangeWorkStep(item.CaseID, item.ApplicantID, item.DepartmentID, 6);
                        tempCase.StepList.Add(tempWorkStep);
                        data.ListCase.Add(tempCase);
                    }
                    res.Result = data;
                    res.Status = "Success";
                    //data.CaseList.Add();
                }
                else
                {
                    res.Result = null;
                    res.Status = "Success";
                }
                //if(rows.Length > 0)
                //{
                //    TrackingData data = new TrackingData();
                //    var firstrow = rows.FirstOrDefault();
                //    if(firstrow != null)
                //    {
                //        data.Title = firstrow.Title;
                //        data.FirstName = firstrow.FirstName;
                //        data.LastName = firstrow.LastName;
                //        data.TotalCase = rows.Length;
                //        data.TotalResultCase = rows.Where(o => o.WorkStepID >= 6).Count();
                //        data.TotalWorkingCase = rows.Where(o => o.WorkStepID < 6).Count();
                //        data.CaseList = new List<ApplicantCase>();
                //        foreach (var item in rows)
                //        {
                //            ApplicantCase caseTemp = new ApplicantCase();
                //            caseTemp.JFCaseNo = item.JFCaseNo;
                //            caseTemp.StepList = new List<ApplicantCaseDetail>();



                //        }
                //    }
                   
                //}
            }
            catch(Exception ex)
            {
                res.Status = "Fail";
                DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, ex);
            }


            return res;
        }
        private View_ApplicationRow GetValueTracking(ref List<SqlParameter> listParameter
  , string whereSql = "",string orderBy = " CreateDate DESC ")
        {
            View_ApplicationCollection_Base obj = new View_ApplicationCollection_Base(CSystems.ProcessID);
            View_ApplicationRow res = obj.GetRow(listParameter, whereSql);
            obj.Dispose();
            return res;
        }
        private View_ApplicationRow[] GetValueTrackingList(ref List<SqlParameter> listParameter
, string whereSql = "", string orderBy = " CreateDate DESC ")
        {
            View_ApplicationCollection_Base obj = new View_ApplicationCollection_Base(CSystems.ProcessID);
            View_ApplicationRow[] res = obj.GetAsArray(listParameter, whereSql,orderBy);
            obj.Dispose();
            return res;
        }
        private ApplicantCaseDetail GetChangeWorkStep(int caseID,int applicantID,int departmentID,int workstepID)
        {
            ApplicantCaseDetail res = new ApplicantCaseDetail();
            List<SqlParameter> listParameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            string wheresql = "";
            string orderby = "";
            CaseChangeWorkStepHistoryCollection_Base obj = new CaseChangeWorkStepHistoryCollection_Base(CSystems.ProcessID);
            sqlParameter = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = caseID };
            listParameter.Add(sqlParameter);
            sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = departmentID };
            listParameter.Add(sqlParameter);
            if(workstepID == 2)
            {
                sqlParameter = new SqlParameter("@WorkStepID", System.Data.SqlDbType.Int) { Value = workstepID };
                listParameter.Add(sqlParameter);
                wheresql = @" CaseID = @CaseID AND DepartmentID = @DepartmentID AND WorkStepID = @WorkStepID ";
                orderby = "ChangeDate ASC";
            }
            else if(workstepID > 2 && workstepID < 6)
            {
                sqlParameter = new SqlParameter("@WorkStepID", System.Data.SqlDbType.Int) { Value = workstepID };
                listParameter.Add(sqlParameter);
                wheresql = @" CaseID = @CaseID AND DepartmentID = @DepartmentID AND WorkStepID  Between 3 AND 5 ";
                orderby = "ChangeDate DESC";
            }
            else if(workstepID >= 6)
            {
                sqlParameter = new SqlParameter("@WorkStepID", System.Data.SqlDbType.Int) { Value = 6 };
                listParameter.Add(sqlParameter);
                wheresql = @" CaseID = @CaseID AND DepartmentID = @DepartmentID AND WorkStepID = @WorkStepID ";
                orderby = "ChangeDate DESC";
            }
            var row = obj.GetAsArray(listParameter, wheresql, orderby);
            if(row.Length > 0)
            {
                var temp = row.FirstOrDefault();
                res.StepDate = String.Format("{0:s}", temp.ChangeDate);


            }
            else
            {
                res.StepDate = "";
            }
            if (workstepID == 2)
            {
                res.StepName = "รับเรื่อง";
            }
            else if (workstepID > 2 && workstepID < 6)
            {
                res.StepName = "อยู่ระหว่างดำเนินการ";
            }
            else if (workstepID >= 6)
            {
                OpinionCollection_Base opinionObj = new OpinionCollection_Base(CSystems.ProcessID);
                var opinionRow = opinionObj.GetRow(new List<SqlParameter>(), $"OpinionID IN (select OpinionID from CaseApplicantOpinion Where ApplicantID = {applicantID} AND IsFinalApproved = 1)");
                opinionObj.Dispose();
                if(opinionRow != null)
                {
                    res.StepName = "ผลพิจารณา" + " (" + opinionRow.OpinionName + ")";
                }
                else
                {
                    res.StepName = "ผลพิจารณา";
                }
            }

            obj.Dispose();
            return res;
        }



        private string ConvertCompenentFiltersToWheresqlTracking(TrackingFilters filters, ref List<SqlParameter> listParameter)
        {
            if (filters == null)
            {
                throw new ArgumentNullException(nameof(filters));
            }

            StringBuilder query = new StringBuilder();
            string sql = "";
            SqlParameter parameter;
            if (!string.IsNullOrWhiteSpace(filters.CardID))
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@CardID", System.Data.SqlDbType.NVarChar) { Value = filters.CardID };
                listParameter.Add(parameter);
                query.Append(" [CardID]=@CardID ");
                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
                if (string.IsNullOrWhiteSpace(sql))
                {
                    sql += " DeletedFlag = 0 AND WorkStepID > 1 AND WorkStepID IS NOT NULL ";
                }
                else
                {
                    sql += " AND DeletedFlag = 0 AND WorkStepID > 1 AND WorkStepID IS NOT NULL ";
                }

            }
            else
            {
                throw new ArgumentNullException(nameof(filters.CardID));
            }

            return sql;
        }
    }
}
