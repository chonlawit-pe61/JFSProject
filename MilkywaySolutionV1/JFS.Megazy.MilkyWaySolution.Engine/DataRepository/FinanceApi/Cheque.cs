using System.Collections.Generic;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FinanceApi
{
    public class Cheque
    {
        public string ChequeNo { get; set; }
        public string Amount { get; set; }
        public string ChequeStatus { get; set; }
        public string ChequeStatusCode { get; set; }
        public string ChequeNote { get; set; }
        public string MoneyOrderCertificateNumber { get; set; }
        public ChequeDetail Detail { get; set; }
    }

    public class ChequeDetail
    {
        public string PaidDate { get; set; }
        public string NumberOfBook { get; set; }
        public string CheckNo { get; set; }
        public string Court { get; set; }
        public string CaseNumber { get; set; }
        public string CaseNumber1 { get; set; }
        public string BlackNumber { get; set; }
        public string RedNumber { get; set; }

        public string MoneyOrderCertificateCreateDate { get; set; }
        public string MoneyOrderCertificateSendDate { get; set; }

        public string HelpCaseLevel { get; set; }
        public string OtherHelpCaseLevel { get; set; }
        public string ChequeReturnedResons { get; set; }
        public IEnumerable<ChequeAttachFile> AttachFiles { get; set; }
    }
    public class ChequeAttachFile {
        public string FileName { get; set; }
        public string URL { get; set; }


    }
}
