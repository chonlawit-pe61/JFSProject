using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public static class TrackingService
    {
        /// <summary>
        /// บันทึกการใส่ข้อมูลแต่ละส่วน
        /// </summary>
        /// <param name="id">caseID,ApplicantID</param>
        /// <param name="sectionName">ชื่อส่วนข้อมูล</param>
        /// <param name="isCaseSection"></param>
        public static void Log(int id, string sectionName, bool isCaseSection = false)
        {

            DalBase dal = new DalBase();
            try
            {
                // dal.DbBeginTransaction(CSystems.ProcessID);
                SectionTrackingCollection_Base sectiontracking = new SectionTrackingCollection_Base(CSystems.ProcessID);
                sectiontracking.DeleteByPrimaryKey(id, sectionName, isCaseSection);
                sectiontracking.InsertOnlyPlainText(new SectionTrackingRow
                {
                    SectionID = id,
                    SectionName = sectionName,
                    IsCaseSection = isCaseSection,
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                });
                sectiontracking.Dispose();
                // dal.DbCommit(CSystems.ProcessID);

            }
            catch (Exception ex)
            {
                //  dal.DbRollBack(CSystems.ProcessID);
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
        }
        public static void LogAsync(int id, string sectionName, bool isCaseSection = false, int processID = 0)
        {
            //Fix for async ebidt by piak
            if (processID == 0)
            {
                processID = CSystems.ProcessID;
            }
            DalBase dal = new DalBase();
            try
            {
                SectionTrackingCollection_Base sectiontracking = new SectionTrackingCollection_Base(processID);
                sectiontracking.DeleteByPrimaryKey(id, sectionName, isCaseSection);
                sectiontracking.InsertOnlyPlainText(new SectionTrackingRow
                {
                    SectionID = id,
                    SectionName = sectionName,
                    IsCaseSection = isCaseSection,
                    ModifiedDate = dal.GetSqlNow(processID)
                });
                sectiontracking.Dispose();

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }
        }

        public static DataHistoryResponse GetHistory(int caseID, int applicantID)
        {
            DataHistoryResponse res = new DataHistoryResponse();
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter();
            //CaseOwnerCollection_Base caseOwner = new CaseOwnerCollection_Base(CSystems.ProcessID);
            //var row = caseOwner.GetByCaseID(caseID);
            //caseOwner.Dispose();
            //if (row != null)
            //{

            //}

            //การเปลี่ยนแปลง ข้อมูลสำนวนรายบุคคล
            ApplicantChangeHistoryCollection_Base applicantChangeHistory = new ApplicantChangeHistoryCollection_Base(CSystems.ProcessID);
            sqlpara = new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = applicantID };
            parameters = new List<SqlParameter>();
            parameters.Add(sqlpara);
            string wheresql = "ApplicantID = @ApplicantID";
            var rowAppChang = applicantChangeHistory.GetTopAsArray(30, parameters, wheresql, "[ChangeDate] DESC");
            applicantChangeHistory.Dispose();
            if (rowAppChang.Length > 0)
            {
                res.ApplicantChange = from q in rowAppChang
                                      select new ApplicantChangeHistoryData
                                      {
                                          ApplicantID = q.ApplicantID,
                                          Comment = q.Comment,
                                          UserID = q.UserID,
                                          ChangeDateStr = Helpers.Utility.ConvertDateTimeToThaiLongDate(q.ChangeDate)
                                      };
            }

            //การเปลี่ยนแปลง ข้อมูลสำนวน (สถานะหลัก)
            View_CaseChangeCollection_Base view_CaseChange = new View_CaseChangeCollection_Base(CSystems.ProcessID);
            sqlpara = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = caseID };
            parameters = new List<SqlParameter>
            {
                sqlpara
            };
            wheresql = "CaseID = @CaseID";
            var rowChange = view_CaseChange.GetTopAsArray(30, parameters, wheresql, "[ChangeDate] DESC");
            view_CaseChange.Dispose();
            if (rowChange.Length > 0)
            {
                res.CaseChange = from q in rowChange
                                 select new View_CaseChangeData
                                 {
                                     CaseID = q.CaseID,
                                     Comment = q.Comment,
                                     CaseApplicationStatusName = q.CaseApplicationStatusName,
                                     UserID = q.UserID,
                                     ChangeDateStr = Helpers.Utility.ConvertDateTimeToThaiLongDate(q.ChangeDate)
                                 };
            } 
            View_WorkStepChangeHistoryCollection_Base view_WorkStepChange = new View_WorkStepChangeHistoryCollection_Base(CSystems.ProcessID);
            sqlpara = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = caseID };
            parameters = new List<SqlParameter>{sqlpara};
            //sqlpara = new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = applicantID };
            //parameters.Add(sqlpara);
            wheresql = "CaseID = @CaseID";
            var rowStepChange = view_WorkStepChange.GetTopAsArray(30, parameters, wheresql, "[ChangeDate] DESC");
            view_WorkStepChange.Dispose();
            if (rowStepChange.Length > 0)
            {
                res.WorkStepChange = from q in rowStepChange
                                     select new View_WorkStepChangeHistoryData
                                     {
                                         CaseID = q.CaseID,
                                         Comment = q.Comment,
                                         WorkStepName = q.WorkStepName,
                                         UserName = q.UserName,
                                         FirstName = q.FirstName,
                                         LastName = q.LastName,
                                         AliasName = q.AliasName,
                                         DepartmentName = q.DepartmentName,
                                         DepartmentNameAbbr = q.DepartmentNameAbbr,
                                         UserID = q.UserID,
                                         ChangeDateStr = Helpers.Utility.ConvertDateToThaiLongDate(q.ChangeDate),
                                         ModifiedDateStr = Helpers.Utility.ConvertDateTimeToThaiLongDate(q.ModifiedDate)
                                     };
            }
            AssignmentRecordCollection_Base AssignmentChange = new AssignmentRecordCollection_Base(CSystems.ProcessID);
            sqlpara = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = caseID };
            parameters = new List<SqlParameter> { sqlpara };
            wheresql = "CaseID = @CaseID";
            var rowAssignmentChange = AssignmentChange.GetTopAsArray(30, parameters, wheresql, "[ModifiedDate] DESC");
            AssignmentChange.Dispose();
            if (rowAssignmentChange.Length > 0)
            {
                res.AssignmentChange = from q in rowAssignmentChange
                                       select new AssignmentRecordData
                                       {
                                           AssignmentID = q.AssignmentID,
                                           CaseID = q.CaseID,
                                           UserID = q.UserID,
                                           ViaSMS = q.ViaSMS,
                                           ViaEmail = q.ViaEmail,
                                           AssignmentNote = q.AssignmentNote,
                                           ModifiedDateStr = Helpers.Utility.ConvertDateTimeToThaiLongDate(q.ModifiedDate)
                                       };
            }
            return res;
        }
      /// <summary>
      /// เรียกขั้นตอนการดำเนินงาน  : ผู้ร้องติดตามสถานะการดำเนินงาน
      /// </summary>
        public static List<DataProcessResponse> GetCaseHistoryForRequestor(int caseID,int applicantID,int departmentID)
        {
            //WorkStepID = 6 คือแจ้งผลการพิจารณา
            DataProcessResponse res = new DataProcessResponse();
            List<DataProcessResponse> list = new List<DataProcessResponse>();
            View_CaseChangeCollection_Base obj = new View_CaseChangeCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = caseID };
            parameter.Add(sqlpara);
            sqlpara = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = departmentID };
            parameter.Add(sqlpara);
            string whereSql = "[CaseID] = @CaseID AND DepartmentID= @DepartmentID";
            string orderbySql = "[ChangeDate] DESC";
            var rows = obj.GetAsArray(parameter, whereSql, orderbySql);
            obj.Dispose();
            foreach (var item in rows)
            {
                res = new DataProcessResponse();
                res.Message =string.Format("{0} {1}",item.DepartmentName,item.Comment);
                res.ProcessDate = Helpers.Utility.ConvertDateToThaiLongDate(item.ChangeDate);
                if (item.CaseApplicationStatusID == 2)
                {
                    //เรียนสถานะการทำงานแต่ละขั้นตอน
                    View_WorkStepChangeHistoryCollection_Base view_WorkStepChange = new View_WorkStepChangeHistoryCollection_Base(CSystems.ProcessID);
                    sqlpara = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = caseID };
                    List<SqlParameter> parameters = new List<SqlParameter> { sqlpara };
                    //sqlpara = new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = applicantID };
                    //parameters.Add(sqlpara);
                   string wheresql = "CaseID = @CaseID AND WorkStepID <= 6";
                    var rowStepChange = view_WorkStepChange.GetTopAsArray(30, parameters, wheresql, "[ChangeDate] DESC");
                    view_WorkStepChange.Dispose();
                    if (rowStepChange.Length > 0)
                    {
                        res.SubProcess = from q in rowStepChange
                                             select new DataProcessResponse
                                             {
                                                 ID = q.WorkStepID,
                                                 ProcessDate = Helpers.Utility.ConvertDateTimeToThaiLongDate(q.ChangeDate),
                                                 Message =q.Comment,
                                                 Status = q.WorkStepName,
                                             };
                        //6 = แจ้งผลพิจารณา
                        var stepInform = rowStepChange.Where(x => x.WorkStepID == 6).FirstOrDefault();
                        if (stepInform != null)
                        {
                            //ผลการประชุมผู้พิจารณา/วันที่พิจารณา
                            CaseMeetingMinutesCollection_Base objMeeting = new CaseMeetingMinutesCollection_Base(CSystems.ProcessID);
                            parameter = new List<SqlParameter>();
                            sqlpara = new SqlParameter("@ApplicantID", System.Data.SqlDbType.VarChar) { Value = applicantID };
                            parameter.Add(sqlpara);
                             whereSql = "[ApplicantID] = @ApplicantID";
                            var rowMeeting = objMeeting.GetRow(parameter, whereSql);
                            objMeeting.Dispose();
                            if (rowMeeting != null)
                            {
                                //กรณีอนุมัติ
                                View_OfficerApprovedExpenseCollection_Base objAppv = new View_OfficerApprovedExpenseCollection_Base(CSystems.ProcessID);
                                parameter = new List<SqlParameter>();
                                sqlpara = new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = applicantID };
                                parameter.Add(sqlpara);
                                sqlpara = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = caseID };
                                parameter.Add(sqlpara);
                                whereSql = "[ApplicantID] = @ApplicantID AND CaseID=@CaseID";
                                var rowAppv = objAppv.GetRow(parameter, whereSql);
                                objAppv.Dispose();

                                res.DataJudgeResult = new DataJudgeResult();
                                if (rowAppv != null)
                                {
                                    res.DataJudgeResult.IsApprove = true;
                                    res.DataJudgeResult.JudgeDate = Helpers.Utility.ConvertDateToThaiLongDate(rowMeeting.MeetingDate);
                                    res.DataJudgeResult.Message = "อนุมัติ";
                                    res.DataJudgeResult.ApproveAmount = rowAppv.TotalAmount.ToString("#,##0");
                                }
                                else
                                {
                                    res.DataJudgeResult.IsApprove = false;
                                    res.DataJudgeResult.JudgeDate = Helpers.Utility.ConvertDateToThaiLongDate(rowMeeting.MeetingDate);
                                    res.DataJudgeResult.Message = "ไม่อนุมัติ";
                                    
                                }
                            }
                        
                        }
                    }
                }
                list.Add(res);
            }
            return list;

        }

        public static void SaveCaseChangeWorkStepHistory(CaseChangeWorkStepHistoryRow row, int processID)
        {

            DalBase dal = new DalBase();
            try
            {
                CaseChangeWorkStepHistoryCollection_Base caseworksetp = new CaseChangeWorkStepHistoryCollection_Base(processID);
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlpara = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = row.CaseID };
                parameter.Add(sqlpara);
                sqlpara = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = row.DepartmentID };
                parameter.Add(sqlpara);
                sqlpara = new SqlParameter("@UserID", System.Data.SqlDbType.Int) { Value = row.UserID };
                parameter.Add(sqlpara);
                sqlpara = new SqlParameter("@WorkStepID", System.Data.SqlDbType.Int) { Value = row.WorkStepID };
                parameter.Add(sqlpara);
                string whereSql = "[CaseID] = @CaseID AND [DepartmentID] = @DepartmentID AND [UserID] = @UserID AND [WorkStepID] = @WorkStepID ";

                if (Helpers.Utility.DateValidateInput(row.ChangeDate))
                {
                    sqlpara = new SqlParameter("@ChangeDate", System.Data.SqlDbType.NVarChar) { Value = row.ChangeDate };
                    parameter.Add(sqlpara);
                    whereSql += " AND  CONVERT(varchar(10),[ChangeDate],23) =  CONVERT(varchar(10),@ChangeDate,23)";
                }
                var tmpRow = caseworksetp.GetRow(parameter, whereSql);
                if (tmpRow != null)
                {
                    tmpRow.ModifiedDate = dal.GetSqlNow(processID);
                    caseworksetp.Update(tmpRow, true);
                }
                else
                {
                    caseworksetp.InsertOnlyPlainText(row);
                }
                caseworksetp.Dispose();

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }
        }
    }
}
