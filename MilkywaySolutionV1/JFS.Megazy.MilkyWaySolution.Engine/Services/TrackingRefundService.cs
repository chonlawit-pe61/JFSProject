using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Helpers;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
  public static  class TrackingRefundService
    {
        public static TrackingRefundResponse GetTrackingRefund(int trackingRefundID)
        {
            TrackingRefundResponse res = new TrackingRefundResponse();
            TrackingRefundCollection_Base obj = new TrackingRefundCollection_Base(CSystems.ProcessID);
            var row = obj.GetByPrimaryKey(trackingRefundID);
            if (row != null)
            {
                res.Amount = row.Amount;
                res.ContractID = row.ContractID;
                res.Description = row.Description;
                res.Note = row.Note;
                res.ReceivedAmount = row.ReceivedAmount;
                if (row._IsSetReceivedDate)
                {
                    res.ReceivedDate = row.ReceivedDate;
                    res.ReceivedDateStr = Utility.ConvertDateToString(row.ReceivedDate);
                }
                //if (row._IsSeRequestDateNull)
                //{
                //    res.ReceivedDate = row.RequestDate;
                //    res.ReceivedDateStr = Utility.ConvertDateToString(row.RequestDate);
                //}
                res.RefundStatusID = row.RefundStatusID;
                res.TrakingRefundID = row.TrakingRefundID;
                res.TransactionID = row.TransactionID;

                TransactionDetailCollection_Base detailsObj = new TransactionDetailCollection_Base(CSystems.ProcessID);
                var detailsRow = detailsObj.GetByTransactionID(row.TransactionID);
                detailsObj.Dispose();
                if(detailsRow!= null)
                {
                    if (detailsRow.Length > 0)
                    {
                        res.transactionDetails = (from q in detailsRow
                                                  select new TransactionDetailData
                                                  {
                                                      TransactionDetailID = q.TransactionDetailID,
                                                      BudgetID = q.BudgetID,
                                                      Qty = q.Qty,
                                                      Amount = q.Amount,
                                                      LineTotal = q.LineTotal,
                                                      Unit = q.Unit,
                                                      Note = q.Note
                                                  }
                                                  ).ToList();
                    }
                }
            }
            obj.Dispose();
            return res;
        }
        
        public static TrackingRefundResponse[] GetTrackingRefundByContractID(int contractID)
        {
            View_TrackingRefundCollection_Base obj = new View_TrackingRefundCollection_Base(CSystems.ProcessID);
            var row = obj.GetAsArray(new List<SqlParameter>(),$"ContractID={contractID}", "TrakingRefundID ASC");
            obj.Dispose();
            ArrayList recordList = new ArrayList();
            foreach (var item in row)
            {
                TrackingRefundResponse record = new TrackingRefundResponse();
                record.Amount = item.Amount;
                record.ContractID = item.ContractID;
                record.Description = item.Description;
                record.Note = item.Note;
                record.ReceivedAmount = item.ReceivedAmount;
                if (!item.IsReceivedDateNull)
                {
                    record.ReceivedDate = item.ReceivedDate;
                    record.ReceivedDateStr = Utility.ConvertDateToThaiString(item.ReceivedDate);
                }
                else {
                    record.ReceivedDateStr = "";
                }
                if (!item.IsRequestDateNull)
                {
                    record.RequestDate = item.RequestDate;
                    record.RequestDateStr = Utility.ConvertDateToThaiString(item.RequestDate);
                }
                else {
                    record.RequestDateStr = "";
                }
                if (!item.IsJFPortalReceiveDateNull)
                {
                    record.JFPortalReceiveDateStr = Utility.ConvertDateToThaiString(item.JFPortalReceiveDate);
                }
                else
                {
                    record.JFPortalReceiveDateStr = "";
                }
                record.TransactionID = item.TransactionID;
                record.TransactionNo = item.TransactionNo;
                record.TransactionType = item.TransactionType;
                record.TrasactionTypeDesc = item.TrasactionTypeDesc;
                record.RefundStatusID = item.RefundStatusID;
                record.RefundStatusName = item.RefundStatusName;
                record.TrakingRefundID = item.TrakingRefundID;
                record.TransactionStatusID = item.TransactionStatusID;
                recordList.Add(record);
            }
            return (TrackingRefundResponse[])(recordList.ToArray(typeof(TrackingRefundResponse))); ;
        }
        public static int InsertOrUpdateTrackingRefund(TransactionRefundRespon req,int status)
        {
            /// transaction ที่ได้รับเงินคืนจากศาล
            int trackingRefundID = 0;
            int transactionID = 0;
            string TransactionNo = null;
            int Transactionstatus = 0;
            if (status != 4)
            {
                Transactionstatus = req.Transaction.TransactionStatusID;
                if (req.Transaction.TransactionStatusID != 1)
                {
                    if (string.IsNullOrEmpty(req.Transaction.TransactionNo))
                    {
                        TransactionNo = RunningServices.GetTransactionNoRunning();

                    }
                    else
                    {
                        TransactionNo = req.Transaction.TransactionNo;

                    }
                }
            }
            else
            {
                TransactionNo = req.Transaction.TransactionNo;
                if (req.Transaction.TransactionStatusID == 1)
                {
                    Transactionstatus = status;
                }
                else
                {
                    Transactionstatus = req.Transaction.TransactionStatusID;
                }
            }

            DalBase dal = new DalBase();
            try
            {

                TransactionCollection_Base transaction = new TransactionCollection_Base(CSystems.ProcessID);
                var transactionrow = transaction.GetByPrimaryKey(req.Transaction.TransactionID);
                if (transactionrow != null)
                {
                    transactionrow.RefApplicantID = req.Transaction.RefApplicantID;
                    transactionrow.TransactionNo = TransactionNo;
                    transactionrow.RefCaseID = req.Transaction.RefCaseID;
                    transactionrow.RefContractID = req.Transaction.RefContractID;
                    transactionrow.TotalAmount = req.Transaction.TotalAmount;
                    transactionrow.TransactionStatusID = Transactionstatus;
                    transactionrow.TransactionType = req.Transaction.TransactionType;
                    transactionrow.Note = req.Transaction.Note;
                    transactionrow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                    transaction.Update(transactionrow);
                    transactionID = transactionrow.TransactionID;


                }
                else
                {

                    transactionID = transaction.InsertOnlyPlainText(new TransactionRow
                    {
                        TransactionNo = TransactionNo,
                        RefApplicantID = req.Transaction.RefApplicantID,
                        RefCaseID = req.Transaction.RefCaseID,
                        RefContractID = req.Transaction.RefContractID,
                        TotalAmount = req.Transaction.TotalAmount,
                        TransactionType = req.Transaction.TransactionType,
                        TransactionStatusID = Transactionstatus,
                        Note = req.Transaction.Note,
                        TranferDate = Utility.ConvertStringToDate(req.Transaction.TranferDateStr),
                        CreateDate = dal.GetSqlNow(CSystems.ProcessID),
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                        DeleteFlag = false
                    });
                }
                transaction.Dispose();

                TrackingRefundCollection_Base trackingRefund = new TrackingRefundCollection_Base(CSystems.ProcessID);
                var row = trackingRefund.GetByPrimaryKey(req.TrackingRefund.TrakingRefundID);
                if (row != null)
                {
                    row.ContractID = req.TrackingRefund.ContractID;
                    row.TransactionID = transactionID;
                    row.Description = req.TrackingRefund.Description;
                    row.Amount = req.TrackingRefund.Amount;
                    row.ReceivedAmount = req.TrackingRefund.ReceivedAmount;
                    row.RefundStatusID = req.TrackingRefund.RefundStatusID;
                    row.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                    row.Note = req.TrackingRefund.Note;
                    if (!string.IsNullOrWhiteSpace(req.TrackingRefund.ReceivedDateStr))
                    {
                        row.ReceivedDate = Utility.ConvertStringToDate(req.TrackingRefund.ReceivedDateStr);
                    }
                    if (!string.IsNullOrWhiteSpace(req.TrackingRefund.RequestDateStr))
                    {
                        row.RequestDate = Utility.ConvertStringToDate(req.TrackingRefund.RequestDateStr);
                    }
                    trackingRefund.UpdateOnlyPlainText(row);
                    trackingRefundID = row.TrakingRefundID;
                }
                else
                {
                    var rowT = new TrackingRefundRow
                    {
                        TransactionID = transactionID,
                        ContractID = req.TrackingRefund.ContractID,
                        Description = req.TrackingRefund.Description,
                        Amount = req.TrackingRefund.Amount,
                        ReceivedAmount = req.TrackingRefund.ReceivedAmount,
                        RefundStatusID = req.TrackingRefund.RefundStatusID,
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                        Note = req.TrackingRefund.Note,
                        TrakingRefundID = req.TrackingRefund.TrakingRefundID,
                    };
                    if (!string.IsNullOrWhiteSpace(req.TrackingRefund.RequestDateStr))
                    {
                        rowT.RequestDate = Utility.ConvertStringToDate(req.TrackingRefund.RequestDateStr);
                    }
                    else
                    {
                        rowT.RequestDate = dal.GetSqlNow(CSystems.ProcessID);
                    }
                    if (!string.IsNullOrWhiteSpace(req.TrackingRefund.ReceivedDateStr))
                    {
                        rowT.ReceivedDate = Utility.ConvertStringToDate(req.TrackingRefund.ReceivedDateStr);
                    }
                    trackingRefundID = trackingRefund.InsertOnlyPlainText(rowT);
                }
                trackingRefund.Dispose();

                if (req.TransactionDetail != null)
                {
                    TransactionDetailCollection_Base transactionDetail = new TransactionDetailCollection_Base(CSystems.ProcessID);

                    if (req.TransactionDetail.Count > 0)
                    {                

                        transactionDetail.DeleteByTransactionID(req.Transaction.TransactionID);
                        transactionDetail.Dispose();

                        transactionDetail = new TransactionDetailCollection_Base(CSystems.ProcessID);
                        foreach (var item in req.TransactionDetail)
                        {
                            transactionDetail.InsertOnlyPlainText(new TransactionDetailRow
                            {
                                TransactionID = transactionID,
                                Qty = item.Qty,
                                Amount = item.Amount,
                                LineTotal = item.LineTotal,
                                Note = item.Note,
                                BudgetID = item.BudgetID,
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                            });
                        }
                        transactionDetail.Dispose();
                    }
                    else
                    {
                        transactionDetail.DeleteByTransactionID(req.Transaction.TransactionID);
                        transactionDetail.Dispose();
                    }
                    
                }

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return trackingRefundID;
        }

    }
}
