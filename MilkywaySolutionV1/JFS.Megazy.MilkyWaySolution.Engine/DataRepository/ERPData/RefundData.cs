using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.ERPData
{
    public class RefundDataResult : ApiResult
    {
        public RefundRetult Result { get; set; }
    }
    //[DataContract(Name = "Payment")]
    //public class RefundPayment
    //{
    //    [DataMember(Name = "TRANSACTIONNO")]
    //    public string TRANSACTIONNO { get; set; }
    //    [DataMember(Name = "TITLE")]
    //    public string Title { get; set; }
    //    [DataMember(Name = "FIRSTNAME")]
    //    public string FirstName { get; set; }
    //    [DataMember(Name = "LASTNAME")]
    //    public string LastName { get; set; }
    //    [DataMember(Name = "DEPARTMENTNAME")]
    //    public string DepartmentName { get; set; }
    //    [DataMember(Name = "FORMNAME")]
    //    public string FormName { get; set; }
    //    [DataMember(Name = "CONTRACTNO")]
    //    public string ContractNo { get; set; }
    //    [DataMember(Name = "AMOUNT")]
    //    public string Amount { get; set; }
    //    [DataMember(Name = "APPROVER")]
    //    public string Approver { get; set; }
    //    [DataMember]
    //    public string SubcommitteeName { get; set; }
    //    [DataMember(Name = "MEET_NO")]
    //    public string MeetNo { get; set; }
    //    [DataMember(Name = "MEET_RESULT")]
    //    public string MeetResult { get; set; }
    //    [DataMember(Name = "CATE_LIST")]
    //    public string CateList { get; set; }
    //    [DataMember(Name = "TRAN_AMOUNT")]
    //    public string TranAmount { get; set; }
    //    [DataMember(Name = "BDGLISTID")]
    //    public string BudgetListID { get; set; }
    //    [DataMember(Name = "BDGLISTNAME")]
    //    public string BudgetListName { get; set; }
    //    [DataMember(Name = "payment_detial")]
    //    public List<PaymentDetial> PaymentDetial { get; set; }
    //}
    [DataContract(Name = "CallRefund")]
    public class PaymentDetial
    {
        [DataMember(Name = "call_refund_id")]
        public string RefuncID { get; set; }
        [DataMember(Name = "pay_cost_id")]
        public string PayCostID { get; set; }
        [DataMember(Name = "money_refund")]
        public string MoneyRefund { get; set; }
        [DataMember(Name = "call_status")]
        public string CallStatus { get; set; }
        [DataMember(Name = "call_status_name")]
        public string CallStatusName { get; set; }
        [DataMember(Name = "pay_cost_desc")]
        public string PayCostDesc { get; set; }
        [DataMember(Name = "cost_value")]
        public string CostValue { get; set; }
        [DataMember(Name = "note")]
        public string Note { get; set; }
        [DataMember(Name = "BDGLISTID")]
        public string BudgetID { get; set; }
    }
    [DataContract(Name = "REFUND")]
    public class RefundDetail
    {
        [DataMember(Name = "TRANSACTIONNO")]
        public string TransactionNo { get; set; }

        [DataMember(Name = "call_refund")]
        public List<PaymentDetial> PaymentDetial { get; set; }
    }
    [DataContract(Name = "Result")]
    public class RefundData
    {
        [DataMember(Name = "REFUND")]
        public List<RefundDetail> Refund { get; set; }
    }
    public class RefundRetult
    {
        public string Status { get; set; }
        public List<RefundData> Result { get; set; }
    }
}
