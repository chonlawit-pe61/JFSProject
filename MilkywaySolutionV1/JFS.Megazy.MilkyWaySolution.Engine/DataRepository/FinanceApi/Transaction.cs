using System.Collections.Generic;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FinanceApi
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public string TransactionNo { get; set; }
        public string TransactionStatusName { get; set; }
        public int TransactionType { get; set; }
        public int TransactionStatusID { get; set; }
        public int RefContractID { get; set; }
        public double TransactionAmount { get; set; }
        // public double TotalAmount { get; set; }
        //public double TotalAmountPaid { get; set; }
        public string DateCreated { get; set; }
        public string Note { get; set; }
        public string TransactionDate { get; set; }
        public string PaidDate { get; set; }
        public string Payee { get; set; }
        public string PayeePayerAddress { get; set; }
        public string Payer { get; set; }
        public string BankName { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNo { get; set; }
        public string BankAccountType { get; set; }
        public string BankBranch { get; set; }
        public string URL { get; set; }
        public string ModifiedDate { get; set; }
        public string RefTransactionNo { get; set; }
        public IEnumerable<TransactionDetail> TransactionDetails { get; set; }
    }
}
