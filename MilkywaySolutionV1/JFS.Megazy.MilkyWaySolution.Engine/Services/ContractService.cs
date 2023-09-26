using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Helpers;
using JFS.Megazy.MilkyWaySolution.Engine.Singleton;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class ContractService
    {
        public ContractPersonResponse[] GetSurety(int contractID, int roleID)
        {
            View_ContractPersonCollection_Base obj = new View_ContractPersonCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@ContractID", System.Data.SqlDbType.Int) { Value = contractID };
            parameter.Add(sqlpara); 
            sqlpara = new SqlParameter("@RoleID", System.Data.SqlDbType.Int) { Value = roleID };
            parameter.Add(sqlpara);
            string whereSql = "[ContractID] = @ContractID AND [RoleID] = @RoleID";
            string orderbySql = "PersonID Asc";
            var row = obj.GetAsArray(parameter, whereSql, orderbySql);
            obj.Dispose();
            ArrayList recordList = new ArrayList();
            if (row.Length != 0)
            {
                ContractPersonResponse record;
                foreach (var q in row)
                {
                    record = new ContractPersonResponse();
                    record.ContractID = q.ContractID;
                    record.CaseID = q.CaseID;
                    record.AddressID = q.AddressID;
                    record.ApplicantID = q.ApplicantID;
                    record.Title = q.Title;
                    record.FirstName = q.FirstName;
                    record.LastName = q.LastName;
                    record.CardID = q.CardID;
                    record.GenderCode = q.GenderCode;
                    record.ContractDate = Helpers.Utility.ConvertDateToThaiLongDate(q.ContractDate);
                    record.ContractNo = q.ContractNo;
                    record.ContractNote = q.ContractNote;
                    record.RoleID = q.RoleID;
                    record.RoleName = q.RoleName;
                    record.TelephoneNo = q.TelephoneNo;
                    record.Address = new Address
                    { 
                        AddressLine1 = q.Address1,
                        HouseNo = q.HouseNo,
                        Soi = q.Soi,
                        Street = q.Street,
                        VillageNo = q.VillageNo,
                        DistrictName = q.DistrictName,
                        SubDistrictName = q.SubdistrictName,
                        ProvinceName = q.ProvinceName,
                        PostCode = q.PostCode,
                    }.ToAddressString();
                    recordList.Add(record);
                }
            }
            return (ContractPersonResponse[])(recordList.ToArray(typeof(ContractPersonResponse)));
        }

        public ContractFromResponseShow GetContractFrom(int applicantID, int caseID ,int depID,int fromID,int contractID)
        {
            ContractFromResponseShow data = new ContractFromResponseShow();

            View_ApplicationCollection_Base obj = new View_ApplicationCollection_Base(CSystems.ProcessID);
            var row = obj.GetRow(new List<SqlParameter>(), $"ApplicantID={applicantID} AND CaseID={caseID} AND DepartmentID={depID}");
            obj.Dispose();
            if(row != null)
            {
                data.Application = row;

                if(row.JFCaseTypeID == 4)
                {
                    CaseProjectCollection_Base caseproject = new CaseProjectCollection_Base(CSystems.ProcessID);
                    var caserow = caseproject.GetByPrimaryKey(row.CaseID);
                    caseproject.Dispose();
                    if(caserow != null)
                    {
                        data.CaseProject = caserow;
                    }
                    AddressCollection_Base address = new AddressCollection_Base(CSystems.ProcessID);
                    var addressrow = address.GetRow(new List<SqlParameter>(), $"AddressID in (select AddressID from dbo.ProjectAddress where CaseID={caseID})");
                    address.Dispose();
                    if (addressrow != null)
                    {
                        data.ProjectAddress = addressrow;
                    }
                    CaseExpenseCollection_Base expense = new CaseExpenseCollection_Base(CSystems.ProcessID);
                    var expenserow = expense.GetAsArray(new List<SqlParameter>(), $"ApplicantID={row.ApplicantID}", "");
                    if (expenserow.Length > 0)
                    {
                        data.CaseExpense = expenserow;
                    }
                }
                else
                {
                    View_ApplicantAddressCollection_Base address = new View_ApplicantAddressCollection_Base(CSystems.ProcessID);
                    var addressrow = address.GetRow(new List<SqlParameter>(), $"ApplicantID={row.ApplicantID}");
                    address.Dispose();
                    if(addressrow != null)
                    {
                        data.ApplicantAddress = addressrow;
                    }
                    if(row.JFCaseTypeID == 2)
                    {
                        CurrentCaseStatusCollection_Base current = new CurrentCaseStatusCollection_Base(CSystems.ProcessID);
                        var currentrow = current.GetRow(new List<SqlParameter>(), $"ApplicantID={row.ApplicantID}");
                        current.Dispose();
                        CaseVictimCollection_Base victim = new CaseVictimCollection_Base(CSystems.ProcessID);
                        var victimrow = victim.GetRow(new List<SqlParameter>(), $"CaseID={row.CaseID}");
                        victim.Dispose();
                        if(currentrow != null && victimrow != null)
                        {
                            data.CurrentCaseStatus = currentrow;
                            data.CaseVictim = victimrow;

                        }
                    }
                    else
                    {
                        CaseExpenseCollection_Base expense = new CaseExpenseCollection_Base(CSystems.ProcessID);
                        var expenserow = expense.GetAsArray(new List<SqlParameter>(), $"ApplicantID={row.ApplicantID}", "");
                        if(expenserow.Length > 0)
                        {
                            data.CaseExpense = expenserow;
                        }
                    }
                }
                //var fromID = 0;
                //switch (row.JFCaseTypeID)
                //{
                //    case 1:
                //        fromID = 5;
                //        break;
                //    case 2:
                //        fromID = 8;
                //        break;
                //    case 3:
                //        fromID = 28;
                //        break;
                //    case 4:
                //        fromID = 29;
                //        break;
                //    default:                        
                //        break;
                //}
                
                View_ContractFormCollection_Base contractfrom = new View_ContractFormCollection_Base(CSystems.ProcessID);
                if (contractID != 0)
                {
                    var contractfromrow = contractfrom.GetRow(new List<SqlParameter>(), $"ApplicantID={applicantID} AND" +
                    $" CaseID={caseID} AND DepartmentID={depID} AND FormID={fromID} AND ContractID={contractID}");
                    if (contractfromrow != null)
                    {
                        data.ContractWitness = new ContractWitness();
                        View_ContractPersonCollection_Base person = new View_ContractPersonCollection_Base(CSystems.ProcessID);
                        var personrow = person.GetAsArray(new List<SqlParameter>(), $"CaseID={caseID} AND ApplicantID={applicantID}" +
                            $" AND ContractID={contractfromrow.ContractID} AND RoleID={4} AND FormID={fromID}", "");
                        if (personrow.Length > 0)
                        {
                            data.ContractWitness.Witness = personrow;
                        }
                        data.ContractWitness.Contract = contractfromrow;
                    }
                }
                else
                {
                    var contractfromrow = contractfrom.GetRow(new List<SqlParameter>(), $"ApplicantID={applicantID} AND" +
                    $" CaseID={caseID} AND FormID={fromID}");
                    if (contractfromrow != null)
                    {
                        data.ContractWitness = new ContractWitness();
                        View_ContractPersonCollection_Base person = new View_ContractPersonCollection_Base(CSystems.ProcessID);
                        var personrow = person.GetAsArray(new List<SqlParameter>(), $"CaseID={caseID} AND ApplicantID={applicantID} AND DepartmentID={depID}" +
                            $" AND ContractID={contractfromrow.ContractID} AND RoleID={4} AND FormID={fromID}", "");
                        if (personrow.Length > 0)
                        {
                            data.ContractWitness.Witness = personrow;
                        }
                        data.ContractWitness.Contract = contractfromrow;
                    }
                }
                contractfrom.Dispose();


            }
            return data;
        }

        public View_LawyerQueueRow[] GetLawyerQueue(int applicantID,int caseID,int depID)
        {
            View_LawyerQueueCollection_Base obj = new View_LawyerQueueCollection_Base(CSystems.ProcessID);
            var row = obj.GetAsArray(new List<SqlParameter>(), $"TerritoryProvinceID  IN (Select ProvinceID from Department where DepartmentID={depID}) AND QueueStatusID={1}  AND  Priority IS Not NULL", "Priority ASC");
            obj.Dispose();
            return row;
        }

        public View_LawyerContractRow GetLawyerContractRow(int applicantID, int caseID,int depID)
        {
            View_LawyerContractCollection_Base obj = new View_LawyerContractCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("ApplicantID", System.Data.SqlDbType.Int) { Value = applicantID };
            parameter.Add(sqlpara);
            sqlpara = new SqlParameter("CaseID", System.Data.SqlDbType.Int) { Value = caseID };
            parameter.Add(sqlpara);
             sqlpara = new SqlParameter("DepartmentID", System.Data.SqlDbType.Int) { Value = depID };
            parameter.Add(sqlpara);
            string whereSql = "[ApplicantID] = @ApplicantID AND CaseID = @CaseID AND DepartmentID = @DepartmentID AND IsActive = 1 AND FormID IN(6,7)";
            var row = obj.GetRow(parameter, whereSql);
            obj.Dispose();
            return row;
        }

        public View_ContractFormRow GetTrackingRow(int applicantID, int caseID,int depID)
        {
            View_ContractFormCollection_Base obj = new View_ContractFormCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("ApplicantID", System.Data.SqlDbType.Int) { Value = applicantID };
            parameter.Add(sqlpara);
            sqlpara = new SqlParameter("CaseID", System.Data.SqlDbType.Int) { Value = caseID };
            parameter.Add(sqlpara);
            sqlpara = new SqlParameter("DepartmentID", System.Data.SqlDbType.Int) { Value = depID };
            parameter.Add(sqlpara);
            string whereSql = "[ApplicantID] = @ApplicantID AND CaseID = @CaseID AND [DepartmentID] = @DepartmentID AND IsActive = 1 AND FormID IN(8)";
            var row = obj.GetRow(parameter, whereSql);
            obj.Dispose();
            return row;
        }


        public FollowUpLawyerDataResponse GetFollowUpLawyerInContract(int applicantID, int caseID,int depID)
        {
            FollowUpLawyerDataResponse res = new FollowUpLawyerDataResponse();
            var lRow = GetLawyerContractRow(applicantID, caseID,depID);
            if (lRow != null)
            {
                res.ContractID = lRow.ContractID;
                res.CaseID = lRow.CaseID;
                res.LawyerFirstName = lRow.FirstName;
                res.LawyerLastName = lRow.LastName;
                res.LaywerID = lRow.LawyerID;
                res.ApplicantID = lRow.ApplicantID;
                res.ContractID = lRow.ContractID;
                res.ContractNo = lRow.ContractNo;


                View_CurrentCaseStatusCollection_Base currentStatusCase = new View_CurrentCaseStatusCollection_Base(CSystems.ProcessID);
                var currRow = currentStatusCase.GetRow(new List<SqlParameter>(), $"CaseID={caseID} AND ApplicantID={applicantID}");
                if (currRow != null)
                {
                    res.CaseData = new View_CurrentCaseStatusData
                    {
                        CaseRedNo = currRow.CaseRedNo,
                        CaseBlackNo = currRow.CaseBlackNo,
                        CaseID = currRow.CaseID,
                        CurrentStatusCaseID = currRow.CurrentStatusCaseID,
                        CaseTypeOther = currRow.CaseTypeOther,
                        CourID = currRow.CourID,
                        CourtName = currRow.CourtName,
                        HelpCaseLevelID = currRow.HelpCaseLevelID,
                        HelpCaseLevelName = currRow.HelpCaseLevelName,
                        HelpCaseLevelOther = currRow.HelpCaseLevelOther,
                        Judgement = currRow.Judgement,
                        Charge = currRow.Charge,
                        ApplicantStatus = currRow.ApplicantStatus,
                        LitigantName = currRow.LitigantName,
                        LitigantTitle = currRow.LitigantTitle
                    };
                }



                View_ContractCaseFollowUpCollection_Base obj = new View_ContractCaseFollowUpCollection_Base(CSystems.ProcessID);
                var frow = obj.GetRow(new List<SqlParameter>(), "ContractID=" + lRow.ContractID);
                obj.Dispose();
                if (frow != null)
                {
                    res.FollowUpData = new View_ContractCaseFollowUpData
                    {
                        CourtOrderName = frow.CourtOrderName,
                        ContractID = frow.ContractID,
                        CourtLocation = frow.CourtLocation,
                        CourtOrderAmount = frow.CourtOrderAmount,
                        CourtOrderID = frow.CourtOrderID,
                        Note = frow.Note,
                        ResultID = frow.ResultID,
                        ResultName = frow.ResultName
                    };
                    if (!frow.IsJudgmentDateNull)
                    {
                        res.FollowUpData.JudgmentDate = frow.JudgmentDate;
                        res.FollowUpData.JudgmentDateStr = Utility.ConvertDateToThaiLongDate(frow.JudgmentDate);
                    }
                    if (currRow == null)
                    {
                       var CourtItem = SingletonCourt.Instance.CourtItem.Where(p => p.CourtName == frow.CourtLocation).FirstOrDefault();
                        if (CourtItem != null)
                        {
                            res.CaseData = new View_CurrentCaseStatusData
                            {
                                CourID = CourtItem.CourtID,
                                CourtName = CourtItem.CourtName,
                            };
                        }

                    }
                }
            }
            return res;
        }

        public TrackingDataResponse GetTrackingContract(int applicantID,int caseID)
        {
            TrackingDataResponse res = new TrackingDataResponse();
            var lRow = GetContractRow(applicantID, caseID);
            if (lRow != null)
            {
                res.ContractID = lRow.ContractID;
                res.CaseID = lRow.CaseID;              
                res.ApplicantID = lRow.ApplicantID;
                res.ContractID = lRow.ContractID;
                res.ContractNo = lRow.ContractNo;


                View_CurrentCaseStatusCollection_Base currentStatusCase = new View_CurrentCaseStatusCollection_Base(CSystems.ProcessID);
                var currRow = currentStatusCase.GetRow(new List<SqlParameter>(), $"CaseID={caseID} AND ApplicantID={applicantID}");
                if (currRow != null)
                {
                    res.CaseData = new View_CurrentCaseStatusData
                    {
                        CaseRedNo = currRow.CaseRedNo,
                        CaseBlackNo = currRow.CaseBlackNo,
                        CaseID = currRow.CaseID,
                        CurrentStatusCaseID = currRow.CurrentStatusCaseID,
                        CaseTypeOther = currRow.CaseTypeOther,
                        CourID = currRow.CourID,
                        CourtName = currRow.CourtName,
                        HelpCaseLevelID = currRow.HelpCaseLevelID,
                        HelpCaseLevelName = currRow.HelpCaseLevelName,
                        HelpCaseLevelOther = currRow.HelpCaseLevelOther,
                        Judgement = currRow.Judgement,
                        Charge = currRow.Charge,
                        ApplicantStatus = currRow.ApplicantStatus,
                        LitigantName = currRow.LitigantName,
                        LitigantTitle = currRow.LitigantTitle
                    };
                }


                View_ContractCaseFollowUpCollection_Base obj = new View_ContractCaseFollowUpCollection_Base(CSystems.ProcessID);
                var frow = obj.GetRow(new List<SqlParameter>(), "ContractID=" + lRow.ContractID);
                obj.Dispose();
                if (frow != null)
                {
                    res.FollowUpData = new View_ContractCaseFollowUpData
                    {
                        CourtOrderName = frow.CourtOrderName,
                        ContractID = frow.ContractID,
                        CourtLocation = frow.CourtLocation,
                        CourtOrderAmount = frow.CourtOrderAmount,
                        CourtOrderID = frow.CourtOrderID,
                        Note = frow.Note,
                        ResultID = frow.ResultID,
                        ResultName = frow.ResultName
                    };
                    if (!frow.IsJudgmentDateNull)
                    {
                        res.FollowUpData.JudgmentDate = frow.JudgmentDate;
                        res.FollowUpData.JudgmentDateStr = Utility.ConvertDateToThaiLongDate(frow.JudgmentDate);
                    }
                    if (currRow == null)
                    {
                        var CourtItem = SingletonCourt.Instance.CourtItem.Where(p => p.CourtName == frow.CourtLocation).FirstOrDefault();
                        if (CourtItem != null)
                        {
                            res.CaseData = new View_CurrentCaseStatusData
                            {
                                CourID = CourtItem.CourtID,
                                CourtName = CourtItem.CourtName,
                            };
                        }

                    }
                }
            }
            return res;

        }

        public bool InsertOrUpdateContractCaseFollowUp(ContractCaseFollowUpData req)
        {
            bool isPass = false;
            DalBase dal = new DalBase();
            try
            {
                ContractCaseFollowUpCollection_Base contractCaseFollowUp = new ContractCaseFollowUpCollection_Base(CSystems.ProcessID);
                var row = contractCaseFollowUp.GetByPrimaryKey(req.ContractID);
                if (row != null)
                {
                    row.CourtLocation = req.CourtLocation;
                    row.CourtOrderAmount = req.CourtOrderAmount;
                    row.CourtOrderID = req.CourtOrderID;
                    row.ResultID = req.ResultID;
                    row.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                    row.Note = req.Note;
                    row.JudgmentDate = Utility.ConvertStringToDate(req.JudgmentDateStr);
                    contractCaseFollowUp.UpdateOnlyPlainText(row);
                    isPass = true;
                }
                else
                {
                    //กรณีที่ไม่ได้ส่ง ContracID เข้ามา
                    if (req.ContractID > 0)
                    {
                        contractCaseFollowUp.InsertOnlyPlainText(new ContractCaseFollowUpRow
                        {
                            CourtLocation = req.CourtLocation,
                            CourtOrderAmount = req.CourtOrderAmount,
                            CourtOrderID = req.CourtOrderID,
                            ResultID = req.ResultID,
                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                            Note = req.Note,
                            JudgmentDate = Utility.ConvertStringToDate(req.JudgmentDateStr),
                            ContractID = req.ContractID,

                        });
                        isPass = true;
                    }
                    else
                    {
                        isPass = false;
                    }
                }
                contractCaseFollowUp.Dispose();
               
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return isPass;
        }
        public int GetProvinceDepartment(int depID)
        {
            DepartmentCollection_Base obj = new DepartmentCollection_Base(CSystems.ProcessID);
            var row = obj.GetByPrimaryKey(depID).ProvinceID;
            obj.Dispose();
            return row;
        }

        public View_ContractFormRow[] GetAllContract(int applicantID, int caseID,int depID, int formID)
        {
            View_ContractFormCollection_Base obj = new View_ContractFormCollection_Base(CSystems.ProcessID);
            var row = obj.GetAsArray(new List<SqlParameter>(), $"ApplicantID={applicantID} AND DepartmentID={depID} AND CaseID={caseID}" +
                $" AND FormID={formID}", "");
            obj.Dispose();
            return row;

        }
        public int GetAllContractList(int applicantID, int caseID,int depID, int formID)
        {           
            View_ContractFormCollection_Base obj = new View_ContractFormCollection_Base(CSystems.ProcessID);
            var row = obj.GetAsArray(new List<SqlParameter>(), $"ApplicantID={applicantID} AND DepartmentID={depID} AND CaseID={caseID}" +
                $" AND FormID={formID}", "");
            obj.Dispose();
            return row.Length;

        }
        public View_QueueAllVersionRow[] ViewQueueList(int depID)
        {
            View_QueueAllVersionCollection_Base obj = new View_QueueAllVersionCollection_Base(CSystems.ProcessID);
            var row = obj.GetAsArray(new List<SqlParameter>(), $" ProvinceID IN (select ProvinceID from Department where DepartmentID = {depID} ) AND IsActive = 1", "");
            obj.Dispose();
            return row;

        }
        public View_LawyerQueueRow[] GetLawyerQueue(int queueID)
        {
            View_LawyerQueueCollection_Base obj = new View_LawyerQueueCollection_Base(CSystems.ProcessID);
            var row = obj.GetAsArray(new List<SqlParameter>(), $" QueueVersionID = {queueID} AND QueueStatusID = 1", "Priority ASC");
            obj.Dispose();
            return row;
        }

        public ContractRow GetContractRow(int applicantID, int caseID)
        {
            ContractCollection_Base obj = new ContractCollection_Base(CSystems.ProcessID);
            var row = obj.GetRow(new List<SqlParameter>(),$"FormID IN (SELECT FormID FROM Form WHERE IsMoneyForm = 1) AND IsActive = 1 AND ContractNo IS NOT NULL AND CaseID = {caseID} AND ApplicantID = {applicantID}");
            obj.Dispose();
            return row;
        }

    }
}
