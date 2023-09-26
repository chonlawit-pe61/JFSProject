using System.Collections.Generic;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using JFS.Megazy.MilkyWaySolution.Engine.Helpers;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using System.Data.SqlClient;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class TransactionService
    {

        public TransactionRow[] Transaction(int caseID, int applicantID)
        {
            TransactionRow[] res = null;
            TransactionCollection_Base transaction = new TransactionCollection_Base(CSystems.ProcessID);
            string whereSQL = $"RefCaseID={caseID} AND RefApplicantID={applicantID}";
            res = transaction.GetAsArray(new List<SqlParameter>(), whereSQL, "");
            transaction.Dispose();
            return res;
        }

        public TransactionDetailRow[] TransactionDetail(int TransactionDetailID)
        {
            TransactionDetailRow[] res = null;
            TransactionDetailCollection_Base transaction = new TransactionDetailCollection_Base(CSystems.ProcessID);
            res = transaction.GetByTransactionID(TransactionDetailID);
            transaction.Dispose();
            return res;
        }

        public int InsertTransaction(TransactionRow data)
        {
            DalBase dal = new DalBase();
            int transactionID = 0;
            if (data != null)
            {
                TransactionCollection_Base transaction = new TransactionCollection_Base(CSystems.ProcessID);
                transactionID = transaction.InsertOnlyPlainText(new TransactionRow
                {
                    TransactionType = 1,
                    RefApplicantID = data.RefApplicantID,
                    RefCaseID = data.RefCaseID,
                    RefContractID = data.RefContractID,
                    TotalAmount = data.TotalAmount,
                    Note = data.Note,
                    TransactionStatusID = 1,
                    CreateDate = dal.GetSqlNow(CSystems.ProcessID)
                });
                transaction.Dispose();
            }
            return transactionID;
        }

        public bool UpdateTransaction(TransactionRow data)
        {
            bool status = false;
            TransactionCollection_Base transaction = new TransactionCollection_Base(CSystems.ProcessID);
            transaction.UpdateOnlyPlainText(data);
            status = true;
            transaction.Dispose();
            return status;
        }
        public bool InserOrUpdateTransactionMeta(string TransactionID, string MetaKey, string MetaValue)
        {
            bool status = false;
            int processID = CSystemsAsync.ProcessID;
            TransactionMetaCollection_Base transaction = new TransactionMetaCollection_Base(CSystems.ProcessID);
            var data = transaction.GetRow(new List<SqlParameter> {
                                               new SqlParameter("@TransactionID", System.Data.SqlDbType.VarChar) { Value = TransactionID }
                                               ,new SqlParameter("@MetaKey", System.Data.SqlDbType.VarChar) { Value = MetaKey.ToUpper() }
                                           }, "TransactionID = @TransactionID AND MetaKey= @MetaKey");
            if (data != null)
            {
                transaction.UpdateOnlyPlainText(data);
            }
            else
            {

                transaction.Insert(new TransactionMetaRow
                {
                    TransactionID = Utility.TryParseToInt(TransactionID),
                    MetaKey = MetaKey,
                    MetaValue = MetaValue,
                    ModifiedDate = DalBase.SqlNowIncludePd(processID)

                });
            }

            status = true;
            transaction.Dispose();
            return status;
        }


    }
}
