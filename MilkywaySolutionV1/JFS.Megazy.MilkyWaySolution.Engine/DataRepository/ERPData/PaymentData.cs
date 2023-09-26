using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.ERPData
{
    public class PaymentDataResult : ApiResult
    {
        public PaymentData Result { get; set; }
    }
    public class Payment
    {
        public string TRANSACTIONNO { get; set; }
        public string TRANSACTIONSTATUSID { get; set; }
        public string DETAILBACK { get; set; }
        public string PAY_DATE { get; set; }
        public string RECEIVE_DATE { get; set; }
        public ChequeInfo[] CHEQUE_INFO { get; set; }//เพิ่ม 15 ก.พ. 65 by Piak
    }
    public class PaymentData
    {
        //public string Status { get; set; }
        //public List<Payment> Result { get; set; }
        //public int TotalRow { get; set; }
        public string Status { get; set; }
        public List<Payment> Result { get; set; }
        public int TotalRow { get; set; }
    }
    public class PaymentFillter
    {
        public string TRANSACTIONNO { get; set; }
        public string TRANSACTIONSTATUSID { get; set; }
        public string STARTDATE { get; set; }
        public string ENDDATE { get; set; }
    }
    [DataContract(Name = "CHEQUE_INFO")]
    public class ChequeInfo
    {
        [DataMember(Name = "CHEQUE_NO")]
        public string ChequeNo { get; set; }

        [DataMember(Name = "CHEQUE_BANK_NO")]
        public string BankNo { get; set; }

        [DataMember(Name = "CHEQUE_BANK_NAME")]
        public string BankName { get; set; }

        [DataMember(Name = "CHEQUE_BANK_BRANCH")]
        public string BankBranch { get; set; }

        [DataMember(Name = "CHEQUE_RECEIVE_NAME")]
        public string ReceiveName { get; set; }

        [DataMember(Name = "CHEQUE_AMOUNT")]
        public float Amount { get; set; }

    }
}
