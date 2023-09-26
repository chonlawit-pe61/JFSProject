using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FinanceApi;
using JFS.Megazy.MilkyWaySolution.Engine.Helpers;
using JFS.Megazy.MilkyWaySolution.Engine.Request;
using JFS.Megazy.MilkyWaySolution.Engine.Singleton;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.Api
{
    public class FinanceService
    {
        public FinanceDataResult FinanceTransaction(TransactionFilters filters)
        {
            FinanceDataResult res = new FinanceDataResult();
            try
            {
                StringBuilder query = new StringBuilder();
                List<SqlParameter> listParameter = new List<SqlParameter>();
                string sql = ConvertCompenentFiltersToWheresqlTransaction(filters, ref listParameter);
                int startRowIndex = (filters.ItemsPerPage * (filters.CurrentPage - 1));
                if (startRowIndex < 0)
                    startRowIndex = 0;
                var rows = GetPagesTransactions(startRowIndex, listParameter, sql, filters.ItemsPerPage);
                FinanceDataResponse financeRes = new FinanceDataResponse();

                if (rows.totalRow > 0)
                {
                    financeRes.ItemPerPage = filters.ItemsPerPage;
                    financeRes.TotalPages = rows.totalPage;
                    financeRes.TotalItems = rows.totalRow;
                    financeRes.Last = filters.CurrentPage == rows.totalPage;
                    financeRes.First = filters.CurrentPage == 1;
                    List<FinanceData> list = new List<FinanceData>();
                    foreach (var item in rows.view_TransactionItems)
                    {
                        FinanceData data = new FinanceData();
                        data.Contract = new Contract();
                        data.CaseDetail = new CaseDetail();
                        data.CaseDetail.ApplicantID = item.ApplicantID;
                        data.CaseDetail.CaseID = item.CaseID;
                        data.CaseDetail.CardID = item.CardID;
                        data.CaseDetail.Age = item.Age;
                        data.CaseDetail.DepartmentID = item.DepartmentID;
                        data.CaseDetail.DepartmentName = item.DepartmentName;
                        data.CaseDetail.Title = item.Title;
                        data.CaseDetail.FirstName = item.FirstName;
                        data.CaseDetail.LastName = item.LastName;
                        data.CaseDetail.JFSCaseNo = item.JFCaseNo;
                        data.CaseDetail.RedNo = item.RedNo;
                        data.CaseDetail.BlackNo = item.BlackNo;
                        // data.CaseDetail.CourtName =  item.CourtName + (string.IsNullOrEmpty(item.AdditionnalCourtName)? "" : " "+ item.AdditionnalCourtName);//ชื่อศาล
                        data.CaseDetail.CourtLevel = item.CourtLevel; //ชั้นคดี
                        data.CaseDetail.URL = CSystems.Website + string.Format("/applicant/details/{0}?caseid={1}&depid={2}", item.ApplicantID, item.CaseID, item.DepartmentID);

                        //เพิ่ม WorkStepName และ StatusName
                        View_ApplicationCollection_Base vapplictionObj = new View_ApplicationCollection_Base(CSystems.ProcessID);
                        var vapplictionrow = vapplictionObj.GetRow(new List<SqlParameter>(), $"CaseID = {item.CaseID} AND ApplicantID = {item.ApplicantID} AND DepartmentID = {item.DepartmentID}");
                        if (vapplictionrow != null) 
                        {
                            data.CaseDetail.StatusID = vapplictionrow.StatusID;
                            data.CaseDetail.StatusName = vapplictionrow.CaseApplicationStatusName;
                            data.CaseDetail.WorkStepID = vapplictionrow.WorkStepID;
                            data.CaseDetail.WorkStepName = vapplictionrow.WorkStepName;
                        }

                        //ข้อมูลใช้หนังสือรับรองการชำระเงินสำหรับ กทย.2
                        CaseApplicantReqCertificateCollection_Base caseApplicantReqCertificate = new CaseApplicantReqCertificateCollection_Base(CSystems.ProcessID);
                        var reqCerRow = caseApplicantReqCertificate.GetByPrimaryKey(item.CaseID, item.ApplicantID);
                        caseApplicantReqCertificate.Dispose();
                        if (reqCerRow != null) {

                            data.CaseDetail.RequestCertificateCode = reqCerRow.RequestCertificateCode.Trim();

                            if (reqCerRow.RequestCertificateCode.Trim() == "R")
                            {
                                
                                data.CaseDetail.RequestCertificate = "ใช้หนังสือรับรองการชำระเงิน";
                            }
                            else if (reqCerRow.RequestCertificateCode.Trim() == "N")
                            {
                                data.CaseDetail.RequestCertificate = "ไม่ใช้หนังสือรับรองการชำระเงิน (เนื่องจากชำระหลักประกันในรูปแบบอื่นๆ)";
                            }
                            else if (reqCerRow.RequestCertificateCode.Trim() == "C")
                            {
                                data.CaseDetail.RequestCertificate = "ยกเลิกการใช้หนังสือรับรองการชำระเงิน";
                            }

                        }
                        

                        // CaseProject 
                        CaseProjectCollection_Base projectObj = new CaseProjectCollection_Base(CSystems.ProcessID);
                        var projectRow = projectObj.GetByPrimaryKey(item.CaseID);
                        projectObj.Dispose();
                        if (projectRow != null)
                        {
                            data.CaseDetail.ProjectName = projectRow.ProjectTitle;
                        }
                        // RequestDate
                        CaseApplicationCollection_Base applicationObj = new CaseApplicationCollection_Base(CSystems.ProcessID);
                        var applicationRow = applicationObj.GetByPrimaryKey(item.CaseID);
                        applicationObj.Dispose();
                        if (applicationRow != null)
                        {
                            data.CaseDetail.ReqestDate = Utility.DateValidateInput(applicationRow.RegisterDate) ? string.Format("{0:s}", applicationRow.RegisterDate) : "";
                        }
                        // CaseMeeting
                        CaseMeetingMinutesCollection_Base meetingObj = new CaseMeetingMinutesCollection_Base(CSystems.ProcessID);
                        var meetingRow = meetingObj.GetRow(new List<SqlParameter>(), $"CaseID = {item.CaseID} AND ApplicantID = {item.ApplicantID}");
                        meetingObj.Dispose();
                        if (meetingRow != null)
                        {
                            data.CaseDetail.MeetNo = meetingRow.Times;
                            data.CaseDetail.MeetResult = meetingRow.MeetingResults;
                            data.CaseDetail.MeetDate = Utility.DateValidateInput(meetingRow.MeetingDate) ? String.Format("{0:s}", meetingRow.MeetingDate) : "";
                        }
                        // Approve
                        View_OfficerApprovedExpenseCollection_Base approveObj = new View_OfficerApprovedExpenseCollection_Base(CSystems.ProcessID);
                        var approveRow = approveObj.GetRow(new List<SqlParameter>(), $"CaseID = {item.CaseID} AND ApplicantID = {item.ApplicantID} AND IsFinalApproved = 1");
                        approveObj.Dispose();
                        if (approveRow != null)
                        {
                            //FinalApproveCollection_Base finalApproveObj = new FinalApproveCollection_Base(CSystems.ProcessID);
                            //var finalApproveRow = finalApproveObj.GetByPrimaryKey(approveRow.OfficerRoleID);
                            //finalApproveObj.Dispose();
                            //data.CaseDetail.ApproverAmount = approveRow.TotalAmount.ToString();
                            //data.CaseDetail.ApproveDate = Utility.DateValidateInput(approveRow.ApproveDate) ? String.Format("{0:s}", approveRow.ApproveDate) : "";
                            //if (finalApproveRow != null)
                            //{
                            //    data.CaseDetail.Approver = finalApproveRow.FinalApproveName;
                            //}

                            //OfficerFinalApprovedMapBudgetCollection_Base objbudget = new OfficerFinalApprovedMapBudgetCollection_Base(CSystems.ProcessID);
                            //var budgetRow = objbudget.GetByApprovedID(approveRow.ApprovedID);
                            //objbudget.Dispose();
                            //if (budgetRow != null)
                            //{
                            //    data.CaseDetail.BudgetID = budgetRow[0].BudgetID;
                            //}
                            data.CaseDetail.ApproverAmount = approveRow.TotalAmount.ToString();
                            data.CaseDetail.ApproveDate = Utility.DateValidateInput(approveRow.ApproveDate) ? string.Format("{0:s}", approveRow.ApproveDate) : "";
                            data.CaseDetail.Approver = approveRow.OfficerRoleName;
                            data.CaseDetail.BudgetID = approveRow.BudgetID;
                            data.CaseDetail.Budget = approveRow.BudgetName;
                            //แก้ไขตาม คุณบอยแจ้ง กรณีประธาน วาระเร่งด่วน ก็ต้องมี SubcommitteeID ถ้าไม่มีจะทำให้ API ส่งให้การเงินติดปัญหา /23 มี.ค. 66
                            CaseTermCollection_Base caseTerm = new CaseTermCollection_Base(CSystems.ProcessID);
                            var caseTermRow = caseTerm.GetRow(new List<SqlParameter>(), $"CaseID = {item.CaseID}");
                            caseTerm.Dispose();
                            if (caseTermRow != null)
                            {
                                data.CaseDetail.SubcommitteeID = caseTermRow.SubcommitteeID;
                                data.CaseDetail.SubcommitteeName = SingletonSubcommittee.Instance.SubcommitteeItem.Where(p => p.SubcommitteeID == caseTermRow.SubcommitteeID).Select(p => p.SubcommitteeName).FirstOrDefault().ToString();
                            }
                            //if (approveRow.OfficerRoleID == 7)
                            //{
                            //    CaseTermCollection_Base caseTerm = new CaseTermCollection_Base(CSystems.ProcessID);
                            //    var caseTermRow = caseTerm.GetRow(new List<SqlParameter>(), $"CaseID = {item.CaseID} AND FinalApproveID = 7");
                            //    caseTerm.Dispose();
                            //    if (caseTermRow != null)
                            //    {
                            //        data.CaseDetail.SubcommitteeID = caseTermRow.SubcommitteeID;
                            //        data.CaseDetail.SubcommitteeName = Singleton.SingletonSubcommittee.Instance.SubcommitteeItem.Where(p => p.SubcommitteeID == caseTermRow.SubcommitteeID).Select(p => p.SubcommitteeName).FirstOrDefault().ToString();
                            //    }
                            //}
                        }

                        // Proxy
                        ProxyCollection_Base proxyObj = new ProxyCollection_Base(CSystems.ProcessID);
                        var proxyRow = proxyObj.GetRow(new List<SqlParameter>(), $"CaseID = {item.CaseID} AND ApplicantID = {item.ApplicantID}");
                        proxyObj.Dispose();
                        if (proxyRow != null)
                        {
                            data.CaseDetail.RightgiverTitle = proxyRow.Title;
                            data.CaseDetail.RightgiverName = proxyRow.FirstName;
                            data.CaseDetail.RightgiverLastName = proxyRow.LastName;

                            data.Contract.ContractorTitle = proxyRow.Title;
                            data.Contract.ContractorName = proxyRow.FirstName;
                            data.Contract.ContractorLastName = proxyRow.LastName;
                            data.Contract.ContractorBirthDate = Utility.DateValidateInput(proxyRow.DateOfBirth) ? String.Format("{0:s}", proxyRow.DateOfBirth) : "";
                        }
                        else
                        {

                            data.Contract.ContractorTitle = item.Title;
                            data.Contract.ContractorName = item.FirstName;
                            data.Contract.ContractorLastName = item.LastName;
                            data.Contract.ContractorBirthDate = Utility.DateValidateInput(item.DateOfBirth) ? String.Format("{0:s}", item.DateOfBirth) : ""; ;
                        }
                        // Guilt
                        CurrentCaseStatusCollection_Base caseStatus = new CurrentCaseStatusCollection_Base(CSystems.ProcessID);
                        var caseStatusRow = caseStatus.GetRow(new List<SqlParameter>(), $"CaseID = {item.CaseID} AND ApplicantID = {item.ApplicantID}");
                        caseStatus.Dispose();
                        if (caseStatusRow != null)
                        {
                            data.CaseDetail.Faultbase = caseStatusRow.Charge;
                        }




                        data.Contract.Amount = item.Amount;
                        data.Contract.ContractDate = Utility.DateValidateInput(item.ContractDate) ? String.Format("{0:s}", item.ContractDate) : "";
                        data.Contract.ContractNo = item.ContractNo;
                        data.Contract.ContractNote = item.ContractNote;
                        data.Contract.FormID = item.FormID;
                        data.Contract.FormName = item.FormName;

                        CaseApplicantReqCertificateCollection_Base CaseReqObj = new CaseApplicantReqCertificateCollection_Base(CSystems.ProcessID);
                        var CaseReqRow = CaseReqObj.GetByPrimaryKey(item.CaseID, item.ApplicantID);
                        CaseReqObj.Dispose();
                        if (CaseReqRow != null)
                        {
                            data.Contract.ContractRequestCertificate = GetRequestCertificateName(CaseReqRow.RequestCertificateCode);
                        }
                        // data.Contract.URL = CSystems.Website + string.Format("/finance/bill/{0}?caseid={1}&depid={2}", item.ApplicantID, item.CaseID, item.DepartmentID);
                        data.Transaction = new Transaction();
                        data.Transaction.TransactionID = item.TransactionID;
                        data.Transaction.RefContractID = item.ContractID;
                        data.Transaction.TransactionNo = item.TransactionNo;
                        data.Transaction.TransactionType = item.TransactionTypeID;
                        data.Transaction.TransactionStatusID = item.TransactionStatusID; //เพิ่ม StatusID update by bank.p
                        data.Transaction.TransactionStatusName = item.TransactionStatusName;
                        data.Transaction.Note = item.Note;
                        data.Transaction.TransactionDate = Utility.DateValidateInput(item.TransactionDate) ? String.Format("{0:s}", item.TransactionDate) : "";
                        data.Transaction.DateCreated = Utility.DateValidateInput(item.CreateDate) ? String.Format("{0:s}", item.CreateDate) : "";
                        data.Transaction.PaidDate = Utility.DateValidateInput(item.PaidDate) ? String.Format("{0:s}", item.PaidDate) : "";
                        data.Transaction.ModifiedDate = Utility.DateValidateInput(item.ModifiedDate) ? String.Format("{0:s}", item.ModifiedDate) : "";
                        data.Transaction.TransactionAmount = item.TransactionAmount;
                        data.Transaction.Payee = item.Payee;
                        data.Transaction.Payer = item.Payer;
                        data.Transaction.PayeePayerAddress = item.LawyerAddressLine;
                        data.Transaction.BankAccountName = item.BankAccountName;
                        data.Transaction.BankAccountNo = item.BankAccountNo;
                        data.Transaction.BankAccountType = item.BankAccountType;
                        data.Transaction.BankBranch = item.BankBranch;
                        data.Transaction.BankName = item.BankName;
                        data.Transaction.RefTransactionNo = item.RefTransactionNo;
                        data.Transaction.URL = CSystems.Website + string.Format("/finance/bill/{0}?caseid={1}&depid={2}", item.ApplicantID, item.CaseID, item.DepartmentID);
                        //data.Transaction.URL = CSystems.Website + string.Format("/finance/TransactionDetail/{0}?caseid={1}&depid={2}&contractid={3}&trasactionid={4}&type={5}",item.ApplicantID,item.CaseID,item.DepartmentID,item.ContractID, item.TransactionID, item.TransactionTypeID);
                        View_ApplicantAddressCollection_Base addr = new View_ApplicantAddressCollection_Base(CSystems.ProcessID);
                        var addrRow = addr.GetRow(new List<SqlParameter>(), "ApplicantID=" + item.ApplicantID);
                        addr.Dispose();
                        if (addrRow != null)
                        {
                            data.CaseDetail.Address = new Address();
                            data.CaseDetail.Address.AddressLine1 = addrRow.Address1;
                            data.CaseDetail.Address.DistrictName = addrRow.DistrictName;
                            data.CaseDetail.Address.HouseNo = addrRow.HouseNo;
                            data.CaseDetail.Address.VillageNo = addrRow.VillageNo;
                            data.CaseDetail.Address.Soi = addrRow.Soi;
                            data.CaseDetail.Address.Street = addrRow.Street;
                            data.CaseDetail.Address.SubDistrictName = addrRow.SubdistrictName;
                            data.CaseDetail.Address.ProvinceName = addrRow.ProvinceName;
                            data.CaseDetail.Address.PostCode = addrRow.PostCode;
                        }
                        TransactionDetailCollection_Base transactionDetail = new TransactionDetailCollection_Base(CSystems.ProcessID);
                        var tranDetailRow = transactionDetail.GetByTransactionID(item.TransactionID);
                        transactionDetail.Dispose();
                        if (tranDetailRow.Length != 0)
                        {
                            data.Transaction.TransactionDetails = (from q in tranDetailRow
                                                                   select new TransactionDetail
                                                                   {
                                                                       Amount = q.Amount,
                                                                       TransactionDetailID = q.TransactionDetailID,
                                                                       BdgListID = q.BudgetID,
                                                                       BdgList = SingletonBudget.Instance.FinanceBudgetRow.Where(p=>p.BudgetID == q.BudgetID).Select(p=>p.BudgetName).FirstOrDefault(),
                                                                       Note = q.Note,
                                                                   }).ToList();
                        }
                        View_ContractFormCollection_Base objContract = new View_ContractFormCollection_Base(CSystems.ProcessID);
                        var whereSql = $"[ApplicantID] = {item.ApplicantID} AND [CaseID] = {item.CaseID} AND ActiveForm = 1 AND FormID IN (6,7)";//6=สัญญาทนาย 7=สัญญาจ้างทนายในชั้นบังคับคดี
                        var rowContractLawyer = objContract.GetRow(new List<SqlParameter>(), whereSql);
                        objContract.Dispose();
                        if(rowContractLawyer != null)
                        {
                            data.Contract.Lawyer = GetLawyer(rowContractLawyer.ContractID);//เรียกข้อมูลทนาย
                            data.Contract.Lawyer.ContractDate = Utility.DateValidateInput(rowContractLawyer.ContractDate) ? String.Format("{0:s}", rowContractLawyer.ContractDate) : ""; 
                            data.Contract.Lawyer.ContractNote = rowContractLawyer.ContractNote;
                            data.Contract.Lawyer.ContractNo = rowContractLawyer.ContractNo;
                            data.Contract.Lawyer.FormID = rowContractLawyer.FormID;
                            data.Contract.Lawyer.FormName = rowContractLawyer.FormName;
                            data.Contract.Lawyer.Amount = rowContractLawyer.Amount;
                        }

                        ChequeLogCollection_Base chequeLogCollection = new ChequeLogCollection_Base(CSystems.ProcessID);
                        var chequeLogRow = chequeLogCollection.GetAsArray(new List<SqlParameter>(), $"[TransactionID] = {item.TransactionID} AND [FlagDelete] = 0", "ChequeLogID DESC");
                        chequeLogCollection.Dispose();
                        if (chequeLogRow != null)
                        {
                            List<Cheque> chequeLst = new List<Cheque>();
                            foreach (var i in chequeLogRow)
                            {
                                Cheque chkData = new Cheque();
                                chkData.ChequeNo = i.ChequeNo;
                                chkData.Amount = i.Amount.ToString();
                                if (!string.IsNullOrEmpty(i.ChequeStatus))
                                {
                                    chkData.ChequeStatusCode = i.ChequeStatus;
                                    chkData.ChequeStatus = SingletonChequeStatus.Instance.ChequeStatusItem.Where(p => p.ChequeStatusCode == i.ChequeStatus).Select(p => p.ChequeStatusName).FirstOrDefault();
                                }

                                chkData.ChequeNote = i.ChequeNote;
                                chkData.MoneyOrderCertificateNumber = i.MoneyOrderCertificateNumber;
                                if (!string.IsNullOrEmpty(i.AdditionalDataJson))
                                {
                                    chkData.Detail = new ChequeDetail();
                                    var ChequeDetail = JsonConvert.DeserializeObject<ChequeDetail>(i.AdditionalDataJson);
                                    if (ChequeDetail != null)
                                    {
                                        if (!string.IsNullOrEmpty(ChequeDetail.Court))
                                        {
                                            chkData.Detail.Court = SingletonCourt.Instance.CourtItem.Where(p => p.CourtID == int.Parse(ChequeDetail.Court)).Select(p => p.CourtName).FirstOrDefault();
                                        }

                                        chkData.Detail.PaidDate = ChequeDetail.PaidDate;
                                        chkData.Detail.NumberOfBook = ChequeDetail.NumberOfBook;
                                        chkData.Detail.CheckNo = ChequeDetail.CheckNo;
                                        chkData.Detail.CaseNumber = ChequeDetail.CaseNumber;
                                        chkData.Detail.CaseNumber1 = ChequeDetail.CaseNumber1;
                                        chkData.Detail.BlackNumber = ChequeDetail.BlackNumber;
                                        chkData.Detail.RedNumber = ChequeDetail.RedNumber;
                                        chkData.Detail.MoneyOrderCertificateCreateDate = Utility.DateValidateInput(Utility.ConvertStringToDate(ChequeDetail.MoneyOrderCertificateCreateDate)) ? String.Format("{0:s}", Utility.ConvertStringToDate(ChequeDetail.MoneyOrderCertificateCreateDate)) : "";
                                        chkData.Detail.MoneyOrderCertificateSendDate = Utility.DateValidateInput(Utility.ConvertStringToDate(ChequeDetail.MoneyOrderCertificateSendDate)) ? String.Format("{0:s}", Utility.ConvertStringToDate(ChequeDetail.MoneyOrderCertificateSendDate)) : "";
                                        chkData.Detail.OtherHelpCaseLevel = ChequeDetail.OtherHelpCaseLevel;

                                        if (!string.IsNullOrEmpty(ChequeDetail.HelpCaseLevel))
                                        {
                                            chkData.Detail.HelpCaseLevel = SingletonHelpCaseLevel.Instance.HelpCaseLevelItem.Where(p => p.HelpCaseLevelID == int.Parse(ChequeDetail.HelpCaseLevel)).Select(p => p.HelpCaseLevelName).FirstOrDefault();
                                        }
                                        if (!string.IsNullOrEmpty(ChequeDetail.ChequeReturnedResons))
                                        {
                                            chkData.Detail.ChequeReturnedResons = SingletonChequeReturnedResons.Instance.ChequeReturnedResonsItem.Where(p => p.ChequeReturnedResonsCode == ChequeDetail.ChequeReturnedResons).Select(p => p.ChequeReturnedResonsName).FirstOrDefault();
                                        }
                                    }
                                }
                                //Attach File

                                View_ChequeAttachFileCollection_Base objAttachFile = new View_ChequeAttachFileCollection_Base(CSystems.ProcessID);
                                List<SqlParameter> parameter = new List<SqlParameter>();
                                SqlParameter sqlpara = new SqlParameter("@ChequeLogID", System.Data.SqlDbType.Int) { Value = i.ChequeLogID };
                                parameter.Add(sqlpara);
                                whereSql = "[ChequeLogID] = @ChequeLogID";
                                string orderbySql = "AttachFileID Asc";
                                var rowAttachFile = objAttachFile.GetAsArray(parameter, whereSql, orderbySql);
                                objAttachFile.Dispose();
                                if (rowAttachFile.Any())
                                {
                                    chkData.Detail.AttachFiles = from q in rowAttachFile select new ChequeAttachFile {
                                     FileName = q.LableFile, URL = $"{CSystems.Website}/filesupload/cheque/{q.TransactionID}/{q.FileName}"
                                    };
                                }


                                chequeLst.Add(chkData);
                            }
                            data.Cheque = chequeLst;
                        }

                        list.Add(data);
                    }
                    financeRes.ListFinanceData = list;
                    res.Result = financeRes;
                    res.Status = "Success";
                }

            }
            catch (Exception ex)
            {
                res.Status = "Fail";
                DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, ex);
            }
            return res;
        }
        string GetRequestCertificateName(string ReqCerCode)
        {
            string name = "";
            switch (ReqCerCode)
            {
                case "R":
                    name = "ใช้หนังสือรับรองการชำระเงิน";
                    break;
                case "N":
                    name = "ไม่ใช้หนังสือรับรองการชำระเงิน (เนื่องจากชำระหลักประกันในรูปแบบอื่นๆ)";
                    break;
                default:
                    name = "ยกเลิกการใช้หนังสือรับรองการชำระเงิน";
                    break;
            }
            return name;
        }
        public CaseDataResult GetApproveCaseDetail(CaseFilters filters)
        {
            CaseDataResult res = new CaseDataResult();
            DalBase dal = new DalBase();
            try
            {
                StringBuilder query = new StringBuilder();
                List<SqlParameter> listParameter = new List<SqlParameter>();
                string sql = ConvertCompenentFiltersToWheresqlCaseDetailApprove(filters, ref listParameter);
                int startRowIndex = (filters.ItemsPerPage * (filters.CurrentPage - 1));
                if (startRowIndex < 0)
                    startRowIndex = 0;
                View_CaseDetailApproveForFinanceCollection_Base obj = new View_CaseDetailApproveForFinanceCollection_Base(CSystems.ProcessID);
                List<SqlParameter> parameter = new List<SqlParameter>();
                var rows = obj.GetView_CaseDetailApproveForFinancePagingAsArray(listParameter, sql, startRowIndex, filters.ItemsPerPage);
                CaseDataResponse caseDataRes = new CaseDataResponse();
                if (rows.totalRow > 0)
                {
                    caseDataRes.ItemPerPage = filters.ItemsPerPage;
                    caseDataRes.TotalPages = rows.totalPage;
                    caseDataRes.TotalItems = rows.totalRow;
                    caseDataRes.Last = filters.CurrentPage == rows.totalPage;
                    caseDataRes.First = filters.CurrentPage == 1;
                    List<CaseData> list = new List<CaseData>();
                    foreach (var item in rows.view_CaseDetailApproveForFinanceItems)
                    {
                        CaseData data = new CaseData();
                        data.Contract = new Contract[0];
                        data.CaseDetail = new CaseDetail();
                        data.CaseDetail.ApplicantID = item.ApplicantID;
                        data.CaseDetail.CaseID = item.CaseID;
                        data.CaseDetail.CardID = item.CardID;
                        data.CaseDetail.MSCCODE = item.ReferenceMSCCODE;
                        data.CaseDetail.MSCID = item.ReferenceMSCID.ToString();
                        data.CaseDetail.Age = item.Age;
                        data.CaseDetail.DepartmentID = item.DepartmentID;
                        data.CaseDetail.DepartmentName = item.DepartmentName;
                        data.CaseDetail.Title = item.Title;
                        data.CaseDetail.FirstName = item.FirstName;
                        data.CaseDetail.LastName = item.LastName;
                        data.CaseDetail.JFSCaseNo = item.JFCaseNo;
                        data.CaseDetail.RedNo = item.RedNo;
                        data.CaseDetail.BlackNo = item.BlackNo;
                        data.CaseDetail.OpinionID = item.OpinionID;
                        data.CaseDetail.OpinionName = item.OpinionName;

                        // data.CaseDetail.CourtName =  item.CourtName + (string.IsNullOrEmpty(item.AdditionnalCourtName)? "" : " "+ item.AdditionnalCourtName);//ชื่อศาล
                        // data.CaseDetail.CourtLevel = item.CourtLevel; //ชั้นคดี
                        data.CaseDetail.URL = CSystems.Website + string.Format("/applicant/details/{0}?caseid={1}&depid={2}", item.ApplicantID, item.CaseID, item.DepartmentID);
                        // CaseProject 
                        CaseProjectCollection_Base projectObj = new CaseProjectCollection_Base(CSystems.ProcessID);
                        var projectRow = projectObj.GetByPrimaryKey(item.CaseID);
                        projectObj.Dispose();
                        if (projectRow != null)
                        {
                            data.CaseDetail.ProjectName = projectRow.ProjectTitle;
                        }
                        // RequestDate
                        CaseApplicationCollection_Base applicationObj = new CaseApplicationCollection_Base(CSystems.ProcessID);
                        var applicationRow = applicationObj.GetByPrimaryKey(item.CaseID);
                        applicationObj.Dispose();
                        if (applicationRow != null)
                        {
                            data.CaseDetail.ReqestDate = Utility.DateValidateInput(applicationRow.RegisterDate) ? String.Format("{0:s}", applicationRow.RegisterDate) : "";
                        }

                        //เพิ่ม WorkStepName และ StatusName
                        View_ApplicationCollection_Base vapplictionObj = new View_ApplicationCollection_Base(CSystems.ProcessID);
                        var vapplictionrow = vapplictionObj.GetRow(new List<SqlParameter>(), $"CaseID = {item.CaseID} AND ApplicantID = {item.ApplicantID} AND DepartmentID = {item.DepartmentID}");
                        if (vapplictionrow != null)
                        {
                            data.CaseDetail.StatusID = vapplictionrow.StatusID;
                            data.CaseDetail.StatusName = vapplictionrow.CaseApplicationStatusName;
                            data.CaseDetail.WorkStepID = vapplictionrow.WorkStepID;
                            data.CaseDetail.WorkStepName = vapplictionrow.WorkStepName;
                        }

                        //ข้อมูลใช้หนังสือรับรองการชำระเงินสำหรับ กทย.2
                        CaseApplicantReqCertificateCollection_Base caseApplicantReqCertificate = new CaseApplicantReqCertificateCollection_Base(CSystems.ProcessID);
                        var reqCerRow = caseApplicantReqCertificate.GetByPrimaryKey(item.CaseID, item.ApplicantID);
                        caseApplicantReqCertificate.Dispose();
                        if (reqCerRow != null)
                        {

                            data.CaseDetail.RequestCertificateCode = reqCerRow.RequestCertificateCode.Trim();

                            if (reqCerRow.RequestCertificateCode.Trim() == "R")
                            {

                                data.CaseDetail.RequestCertificate = "ใช้หนังสือรับรองการชำระเงิน";
                            }
                            else if (reqCerRow.RequestCertificateCode.Trim() == "N")
                            {
                                data.CaseDetail.RequestCertificate = "ไม่ใช้หนังสือรับรองการชำระเงิน (เนื่องจากชำระหลักประกันในรูปแบบอื่นๆ)";
                            }
                            else if (reqCerRow.RequestCertificateCode.Trim() == "C")
                            {
                                data.CaseDetail.RequestCertificate = "ยกเลิกการใช้หนังสือรับรองการชำระเงิน";
                            }

                        }

                        // CaseMeeting
                        CaseMeetingMinutesCollection_Base meetingObj = new CaseMeetingMinutesCollection_Base(CSystems.ProcessID);
                        var meetingRow = meetingObj.GetRow(new List<SqlParameter>(), $"CaseID = {item.CaseID} AND ApplicantID = {item.ApplicantID}");
                        meetingObj.Dispose();
                        if (meetingRow != null)
                        {
                            data.CaseDetail.MeetNo = meetingRow.Times;
                            data.CaseDetail.MeetResult = meetingRow.MeetingResults;
                            data.CaseDetail.MeetDate = Utility.DateValidateInput(meetingRow.MeetingDate) ? String.Format("{0:s}", meetingRow.MeetingDate) : "";
                        }
                        // Approve
                        View_OfficerApprovedExpenseCollection_Base approveObj = new View_OfficerApprovedExpenseCollection_Base(CSystems.ProcessID);
                        var approveRow = approveObj.GetRow(new List<SqlParameter>(), $"CaseID = {item.CaseID} AND ApplicantID = {item.ApplicantID} AND IsFinalApproved = 1");
                        approveObj.Dispose();
                        if (approveRow != null)
                        {
                            data.CaseDetail.ApproverAmount = approveRow.TotalAmount.ToString();
                            data.CaseDetail.ApproveDate = Utility.DateValidateInput(approveRow.ApproveDate) ? String.Format("{0:s}", approveRow.ApproveDate) : "";
                            data.CaseDetail.Approver = approveRow.OfficerRoleName;
                            data.CaseDetail.BudgetID = approveRow.BudgetID;
                            data.CaseDetail.Budget = approveRow.BudgetName;
                            if (approveRow.OfficerRoleID == 7)
                            {
                                CaseTermCollection_Base caseTerm = new CaseTermCollection_Base(CSystems.ProcessID);
                                var caseTermRow = caseTerm.GetRow(new List<SqlParameter>(), $"CaseID = {item.CaseID} AND FinalApproveID = 7");
                                caseTerm.Dispose();
                                if (caseTermRow != null)
                                {
                                    data.CaseDetail.SubcommitteeID = caseTermRow.SubcommitteeID;
                                    data.CaseDetail.SubcommitteeName = Singleton.SingletonSubcommittee.Instance.SubcommitteeItem.Where(p => p.SubcommitteeID == caseTermRow.SubcommitteeID).Select(p => p.SubcommitteeName).FirstOrDefault().ToString();
                                }
                            }
                        }

                        // Proxy
                        ProxyCollection_Base proxyObj = new ProxyCollection_Base(CSystems.ProcessID);
                        var proxyRow = proxyObj.GetRow(new List<SqlParameter>(), $"CaseID = {item.CaseID} AND ApplicantID = {item.ApplicantID}");
                        proxyObj.Dispose();
                        if (proxyRow != null)
                        {
                            data.CaseDetail.RightgiverTitle = proxyRow.Title;
                            data.CaseDetail.RightgiverName = proxyRow.FirstName;
                            data.CaseDetail.RightgiverLastName = proxyRow.LastName;

                            //data.Contract.ContractorTitle = proxyRow.Title;
                            //data.Contract.ContractorName = proxyRow.FirstName;
                            //data.Contract.ContractorLastName = proxyRow.LastName;
                            //data.Contract.ContractorBirthDate = Utility.DateValidateInput(proxyRow.DateOfBirth) ? String.Format("{0:s}", proxyRow.DateOfBirth) : "";
                        }
                        else
                        {

                            //data.Contract.ContractorTitle = item.Title;
                            //data.Contract.ContractorName = item.FirstName;
                            //data.Contract.ContractorLastName = item.LastName;
                            //data.Contract.ContractorBirthDate = Utility.DateValidateInput(item.DateOfBirth) ? String.Format("{0:s}", item.DateOfBirth) : ""; ;
                        }

                        View_ContractFormCollection_Base objContract = new View_ContractFormCollection_Base(CSystems.ProcessID);
                        parameter = new List<SqlParameter>();
                        SqlParameter sqlpara = new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = item.ApplicantID };
                        parameter.Add(sqlpara);
                        sqlpara = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = item.CaseID };
                        parameter.Add(sqlpara);
                        var whereSql = "[ApplicantID] = @ApplicantID AND [CaseID] = @CaseID ";//AND ActiveForm = 1 ส่งไปทุกสถานะให้ระบบการเงิน 
                        string orderbySql = "ContractID Asc";
                        var rowContract = objContract.GetAsArray(parameter, whereSql, orderbySql);
                        objContract.Dispose();
                        List<Contract> li = new List<Contract>();

                        foreach (var itemContract in rowContract)
                        {
                            var contract = new Contract();
                            contract.Lawyer = GetLawyer(itemContract.ContractID);//เรียกข้อมูลทนาย
                            contract.Amount = itemContract.Amount;
                            contract.ContractDate = Utility.DateValidateInput(itemContract.ContractDate) ? string.Format("{0:s}", itemContract.ContractDate) : "";
                            contract.ContractNo = itemContract.ContractNo;
                            contract.ContractNote = itemContract.ContractNote;
                            contract.FormID = itemContract.FormID;
                            contract.FormName = itemContract.FormName;
                            contract.ContractorTitle = item.Title;
                            contract.ContractorName = item.FirstName;
                            contract.ContractorLastName = item.LastName;
                            contract.ContractorBirthDate = Utility.DateValidateInput(item.DateOfBirth) ? String.Format("{0:s}", item.DateOfBirth) : ""; ;
                            contract.IsActive = itemContract.ActiveForm;//สถานะยกเลิกใบ 0= ยกเลิก

                            li.Add(contract);
                            //data.Contract.Amount = item.Amount;
                            //data.Contract.ContractDate = Utility.DateValidateInput(item.ContractDate) ? String.Format("{0:s}", item.ContractDate) : "";
                            //data.Contract.ContractNo = item.ContractNo;
                            //data.Contract.ContractNote = item.ContractNote;
                            //data.Contract.FormID = item.FormID;
                            //data.Contract.FormName = item.FormName;
                            //data.Contract = (from q in rowContract
                            //                 select new Contract
                            //                 {
                            //                     Amount = q.Amount,
                            //                     ContractDate = Utility.DateValidateInput(q.ContractDate) ? string.Format("{0:s}", q.ContractDate) : "",
                            //                     ContractNo = q.ContractNo,
                            //                     ContractNote = q.ContractNote,
                            //                     FormID = q.FormID,
                            //                     FormName = q.FormName
                            //                 }).ToArray();
                        }
                        data.Contract = li;
                        // Guilt
                        CurrentCaseStatusCollection_Base caseStatus = new CurrentCaseStatusCollection_Base(CSystems.ProcessID);
                        var caseStatusRow = caseStatus.GetRow(new List<SqlParameter>(), $"CaseID = {item.CaseID} AND ApplicantID = {item.ApplicantID}");
                        caseStatus.Dispose();
                        if (caseStatusRow != null)
                        {
                            data.CaseDetail.Faultbase = caseStatusRow.Charge;
                        }

                        View_ApplicantAddressCollection_Base addr = new View_ApplicantAddressCollection_Base(CSystems.ProcessID);
                        var addrRow = addr.GetRow(new List<SqlParameter>(), "ApplicantID=" + item.ApplicantID);
                        addr.Dispose();
                        if (addrRow != null)
                        {
                            data.CaseDetail.Address = new Address();
                            data.CaseDetail.Address.AddressLine1 = addrRow.Address1;
                            data.CaseDetail.Address.DistrictName = addrRow.DistrictName;
                            data.CaseDetail.Address.HouseNo = addrRow.HouseNo;
                            data.CaseDetail.Address.VillageNo = addrRow.VillageNo;
                            data.CaseDetail.Address.Soi = addrRow.Soi;
                            data.CaseDetail.Address.Street = addrRow.Street;
                            data.CaseDetail.Address.SubDistrictName = addrRow.SubdistrictName;
                            data.CaseDetail.Address.ProvinceName = addrRow.ProvinceName;
                            data.CaseDetail.Address.PostCode = addrRow.PostCode;
                        }
                        // data.Contract.Lawyer = GetLawyer(item.ContractID);//เรียกข้อมูลทนาย

                        list.Add(data);
                    }
                    caseDataRes.ListCaseData = list;
                    res.Result = caseDataRes;
                    res.Status = "Success";

                }
                obj.Dispose();

            }
            catch (Exception ex)
            {

                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return res;
        }
        //public ApplicantDetail Applicant(int contract)
        //{
        //    DalBase dal = new DalBase();
        //    ApplicantDetail res = new ApplicantDetail();
        //    try
        //    {

        //        CaseApplicantCollection_Base obj = new CaseApplicantCollection_Base(CSystems.ProcessID);                
        //        string sqlParameter = "";
        //        var row = obj.GetRow(new List<SqlParameter>(), $"ApplicantID IN (select ApplicantID from Contract where ContractID = {contract})");
        //        if(row != null)
        //        {
        //            res.Title = row.Title;
        //            res.FirstName = row.FirstName;
        //            res.LastName = row.LastName;
        //        }
        //        else
        //        {
        //            res = null;
        //        }
        //        obj.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
        //    }
        //    return res;
        //}
        public Lawyer GetLawyer(int contractID)
        {
           Lawyer res = new Lawyer();
            try
            {
                LawyerCollection_Base obj = new LawyerCollection_Base(CSystems.ProcessID);
                var row = obj.GetRow(new List<SqlParameter>(), $"LawyerID IN (Select LawyerID from LawyerContract where ContractID = {contractID})");
                if (row != null)
                {
                    res.Title = row.Title;
                    res.FirstName = row.FirstName;
                    res.LastName = row.LastName;
                    res.Email = row.Email;
                    res.CardID = row.CardID;
                    res.TelephoneNo = row.MobileNo;
                    res.URL = CSystems.Website + "/lawyer/detail/" + row.LawyerID;
                    View_LawyerAddressCollection_Base view_LawyerAddress = new View_LawyerAddressCollection_Base(CSystems.ProcessID);
                    List<SqlParameter> parameter = new List<SqlParameter>();
                    SqlParameter sqlpara = new SqlParameter("@LawyerID", System.Data.SqlDbType.VarChar) { Value = row.LawyerID };
                    parameter.Add(sqlpara);
                    string whereSql = "[LawyerID] = @LawyerID AND AddressTypeID = 7 AND IsActive=1";
                    // string orderbySql = "AddressID Asc";
                    var rowLawyerAddress = view_LawyerAddress.GetRow(parameter, whereSql);
                    view_LawyerAddress.Dispose();
                    if (rowLawyerAddress != null)
                    {
                        res.Address = new Address
                        {
                            AddressLine1 = rowLawyerAddress.Address1,
                            HouseNo = rowLawyerAddress.HouseNo,
                            VillageNo = rowLawyerAddress.VillageNo,
                            Soi = rowLawyerAddress.Soi,
                            Street = rowLawyerAddress.Street,
                            SubDistrictName = rowLawyerAddress.SubdistrictCode,
                            DistrictName = rowLawyerAddress.DistrictName,
                            ProvinceName = rowLawyerAddress.ProvinceName,
                            PostCode = rowLawyerAddress.PostCode
                        };
                    }
                }
                else
                {
                    res = null;
                }
                obj.Dispose();
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return res;
        }
        //public Refund Refund(int tranID)
        //{
        //    DalBase dal = new DalBase();
        //    Refund res = new Refund();
        //    try
        //    {
        //        TrackingRefundCollection_Base obj = new TrackingRefundCollection_Base(CSystems.ProcessID);
        //        var row = obj.GetRow(new List<SqlParameter>(), $"TransactionID = {tranID}");
        //        if(row != null)
        //        {
        //            res.TrakingRefundID = row.TrakingRefundID;
        //            res.RefundStatusID = row.RefundStatusID;
        //            //res.Description = row.Description;
        //            //res.Amount = row.Amount;
        //            res.ReceivedAmount = row.ReceivedAmount;
        //            res.ReceivedDate = Engine.Helpers.Utility.ConvertDateToString(row.ReceivedDate);
        //        }
        //        else
        //        {
        //            res = null;
        //        }
        //       }
        //    catch (Exception ex)
        //    {
        //          DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
        //    }
        //    return res;
        //}



        private View_TransactionItemsPaging GetPagesTransactions(int startRowIndex
          , List<SqlParameter> listParameter
          , string whereSql = "", int rowPerPage = 20
          , string sortExpression = "CreateDate DESC")
        {
            View_TransactionCollection_Base obj = new View_TransactionCollection_Base(CSystems.ProcessID);
            View_TransactionItemsPaging res = obj.GetView_TransactionPagingAsArray(listParameter, whereSql, startRowIndex, rowPerPage, sortExpression);
            obj.Dispose();
            return res;
        }

        private string ConvertCompenentFiltersToWheresqlTransaction(TransactionFilters filters, ref List<SqlParameter> listParameter)
        {
            if (filters == null)
            {
                throw new ArgumentNullException(nameof(filters));
            }

            StringBuilder query = new StringBuilder();
            string sql = "";
            SqlParameter parameter;
            if (filters.TransactionID > 0)
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@TransactionID", System.Data.SqlDbType.Int) { Value = filters.TransactionID };
                listParameter.Add(parameter);
                query.Append(" [TransactionID]=@TransactionID");
                if (sql == "")
                    sql += query.ToString() + " AND TransactionStatusID > 1";
                else
                    sql += " AND " + query.ToString() + " AND TransactionStatusID > 1";
            }
            else if (!string.IsNullOrEmpty(filters.TransactionNo))
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@TransactionNo", System.Data.SqlDbType.NVarChar) { Value = filters.TransactionNo };
                listParameter.Add(parameter);
                query.Append(" [TransactionNo]=@TransactionNo");
                if (sql == "")
                    sql += query.ToString() + " AND TransactionStatusID > 1";
                else
                    sql += " AND " + query.ToString() + " AND TransactionStatusID > 1";
            }
            else
            {
                //กรณีไม่ส่ง TransactionID เข้ามา
                if (!string.IsNullOrEmpty(filters.Query))
                {
                    filters.Query = "%" + filters.Query.Trim() + "%";
                    parameter = new SqlParameter("@Title", System.Data.SqlDbType.NVarChar) { Value = filters.Query };
                    listParameter.Add(parameter);
                    parameter = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar) { Value = filters.Query };
                    listParameter.Add(parameter);
                    parameter = new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar) { Value = filters.Query };
                    listParameter.Add(parameter);
                    parameter = new SqlParameter("@TransactionNo", System.Data.SqlDbType.NVarChar) { Value = filters.Query };
                    listParameter.Add(parameter);

                    query.Append("(Title LIKE @Title OR FirstName LIKE @FirstName OR LastName LIKE @LastName OR TransactionNo LIKE @TransactionNo)");// OR LicenseNo LIKE @LicenseNo OR Email LIKE @Email OR MobileNo LIKE @MobileNo)");
                    sql += query.ToString();
                }
                if (!string.IsNullOrEmpty(filters.DepartmentID))
                {

                    query = new StringBuilder();
                    parameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = filters.DepartmentID };
                    listParameter.Add(parameter);
                    query.Append(" [DepartmentID]=@DepartmentID");
                    if (sql == "")
                        sql += query.ToString() + " AND WorkStepID >=10 AND WorkStepID <= 12";
                    else
                        sql += " AND " + query.ToString() + " AND WorkStepID >=10 AND WorkStepID <= 12";



                }
                if (!string.IsNullOrEmpty(filters.DateFrom) && !string.IsNullOrEmpty(filters.DateTo))
                {
                    //CreateDate:วันที่สร้างรายการ
                    query = new StringBuilder();
                    parameter = new SqlParameter("@CreateDateFrom", System.Data.SqlDbType.Date) { Value = filters.DateFrom };
                    listParameter.Add(parameter);
                    parameter = new SqlParameter("@CreateDateTo", System.Data.SqlDbType.Date) { Value = filters.DateTo };
                    listParameter.Add(parameter);
                    query.Append(" [CreateDate] BETWEEN @CreateDateFrom AND @CreateDateTo");

                    if (sql == "")
                        sql += query.ToString();
                    else
                        sql += " AND " + query.ToString();
                }
                else {
                    //ModifiedDate:วันที่แก้ไขรายการ
                    if (!string.IsNullOrEmpty(filters.UpdateDateFrom) && !string.IsNullOrEmpty(filters.UpdateDateTo))
                    {
                        query = new StringBuilder();
                        parameter = new SqlParameter("@CreateDateFrom", System.Data.SqlDbType.Date) { Value = filters.UpdateDateFrom };
                        listParameter.Add(parameter);
                        parameter = new SqlParameter("@CreateDateTo", System.Data.SqlDbType.Date) { Value = filters.UpdateDateTo };
                        listParameter.Add(parameter);
                        query.Append(" [ModifiedDate] BETWEEN @CreateDateFrom AND @CreateDateTo");

                        if (sql == "")
                            sql += query.ToString();
                        else
                            sql += " AND " + query.ToString();
                    }
                }
                if (!string.IsNullOrEmpty(filters.TransactionType))
                {
                    query = new StringBuilder();
                    parameter = new SqlParameter("@TransactionTypeID", System.Data.SqlDbType.Int) { Value = filters.TransactionType };
                    listParameter.Add(parameter);
                    query.Append(" [TransactionTypeID]=@TransactionTypeID");
                    if (sql == "")
                        sql += query.ToString();
                    else
                        sql += " AND " + query.ToString();
                }
                if (!string.IsNullOrEmpty(filters.TransactionStatus))
                {
                    query = new StringBuilder();
                    parameter = new SqlParameter("@TransactionStatusID", System.Data.SqlDbType.Int) { Value = filters.TransactionStatus };
                    listParameter.Add(parameter);
                    if (filters.TransactionStatus.Trim() == "1")
                    {
                        query.Append(" [TransactionStatusID] > @TransactionStatusID");
                    }
                    else
                    {
                        query.Append(" [TransactionStatusID] = @TransactionStatusID");
                    }
                    if (sql == "")
                        sql += query.ToString();
                    else
                        sql += " AND " + query.ToString();
                }
                else
                {
                    if (sql == "")
                        sql += query.ToString();
                    else
                        sql += " AND [TransactionStatusID] > 1";
                }
            }
            return sql;
        }

        private string ConvertCompenentFiltersToWheresqlCaseDetailApprove(CaseFilters filters, ref List<SqlParameter> listParameter)
        {
            if (filters == null)
            {
                throw new ArgumentNullException(nameof(filters));
            }

            StringBuilder query = new StringBuilder();
            string sql = " DeletedFlag = 0 ";
            SqlParameter parameter;
            if (!string.IsNullOrEmpty(filters.CaseType))
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@JFCaseTypeID", System.Data.SqlDbType.NVarChar) { Value = filters.CaseType };
                listParameter.Add(parameter);
                query.Append(" [JFCaseTypeID]=@JFCaseTypeID");
                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }
            else if (filters.CaseID > 0)
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = filters.CaseID };
                listParameter.Add(parameter);
                query.Append(" [CaseID]= @CaseID");
                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }
            else if (!string.IsNullOrEmpty(filters.JFCaseNo))
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@JFCaseNo", System.Data.SqlDbType.NVarChar) { Value = filters.JFCaseNo };
                listParameter.Add(parameter);
                query.Append(" [JFCaseNo] = @JFCaseNo");
                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }
            else if (filters.ApplicantID > 0)
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = filters.ApplicantID };
                listParameter.Add(parameter);
                query.Append(" [ApplicantID]=@ApplicantID");
                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }
            else
            {
                //กรณีไม่ส่ง ApplicantID,CaseID,JFCaseTypeID เข้ามา
                if (!string.IsNullOrEmpty(filters.Query))
                {
                    filters.Query = "%" + filters.Query.Trim() + "%";
                    parameter = new SqlParameter("@Title", System.Data.SqlDbType.NVarChar) { Value = filters.Query };
                    listParameter.Add(parameter);
                    parameter = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar) { Value = filters.Query };
                    listParameter.Add(parameter);
                    parameter = new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar) { Value = filters.Query };
                    listParameter.Add(parameter);
                    parameter = new SqlParameter("@JFSCaseNo", System.Data.SqlDbType.NVarChar) { Value = filters.Query };
                    listParameter.Add(parameter);

                    query.Append("(Title LIKE @Title OR FirstName LIKE @FirstName OR LastName LIKE @LastName OR JFSCaseNo LIKE @JFSCaseNo)");// OR LicenseNo LIKE @LicenseNo OR Email LIKE @Email OR MobileNo LIKE @MobileNo)");
                    sql += query.ToString();
                }
                if (!string.IsNullOrEmpty(filters.DepartmentID))
                {

                    query = new StringBuilder();
                    parameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = filters.DepartmentID };
                    listParameter.Add(parameter);
                    query.Append(" [DepartmentID]=@DepartmentID");
                    if (sql == "")
                        sql += query.ToString();
                    else
                        sql += " AND " + query.ToString();



                }
                if (!string.IsNullOrEmpty(filters.DateFrom) && !string.IsNullOrEmpty(filters.DateTo))
                {
                    query = new StringBuilder();
                    parameter = new SqlParameter("@CreateDateFrom", System.Data.SqlDbType.Date) { Value = filters.DateFrom };
                    listParameter.Add(parameter);
                    parameter = new SqlParameter("@CreateDateTo", System.Data.SqlDbType.Date) { Value = filters.DateTo };
                    listParameter.Add(parameter);
                    query.Append(" [CreateDate] BETWEEN @CreateDateFrom AND @CreateDateTo");

                    if (sql == "")
                        sql += query.ToString();
                    else
                        sql += " AND " + query.ToString();
                }

            }
            return sql;
        }


        //public class TransactionFillters
        //{
        //    public int TransactionID { get; set; }

        //}

    }
}

