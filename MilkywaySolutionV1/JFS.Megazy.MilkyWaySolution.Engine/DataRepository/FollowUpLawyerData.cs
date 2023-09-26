using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
   public abstract class FollowUpLawyerData
    {
        public int LaywerID { get; set; }
        public string LawyerFirstName { get; set; }
        public string LawyerLastName { get; set; }
        public string ContractNo { get; set; }
        public int ContractID { get; set; }
        public int CaseID { get; set; }
        public int ApplicantID { get; set; }
        //public string BlackNumber { get; set; }
        //public string RedNumber { get; set; }
        public View_CurrentCaseStatusData CaseData { get; set; }
        public View_ContractCaseFollowUpData FollowUpData { get; set; }
    }
    public class FollowUpLawyerDataResponse : FollowUpLawyerData
    { 
    
    }

    public class TrackingRefundResponse : View_TrackingRefundData
    {
        //Coding here
        public List<TransactionDetailData> transactionDetails { get; set; }
    }

    public class TrackingDataResponse
    {
        public string ContractNo { get; set; }
        public int ContractID { get; set; }
        public int CaseID { get; set; }
        public int ApplicantID { get; set; }
        public View_CurrentCaseStatusData CaseData { get; set; }
        public View_ContractCaseFollowUpData FollowUpData { get; set; }
    }
}
