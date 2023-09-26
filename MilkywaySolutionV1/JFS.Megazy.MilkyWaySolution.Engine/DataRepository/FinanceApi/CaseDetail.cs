using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FinanceApi
{
    public class CaseDetail
    {
        public int ApplicantID { get; set; }
        public int CaseID { get; set; }
        public string JFSCaseNo { get; set; }
        public string MSCID { get; set; }
        public string MSCCODE { get; set; }
        public string BlackNo { get; set; }
        public string RedNo { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardID { get; set; }
        public int DepartmentID { get; set; }
        public int Age { get; set; }
        public string DepartmentName { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public int WorkStepID { get; set; }
        public string WorkStepName { get; set; }
        public string RequestCertificateCode { get; set; }
        public string RequestCertificate { get; set; }

        public string CourtName { get; set; }
        public string URL { get; set; }
        //public string PayeeAddress { get; set; }
        public Address Address { get; set; }
        public string ReqestDate { get; set; }
        public string ProjectName { get; set; }
        public string Proposer { get; set; }
        public int OpinionID { get; set; }
        public string OpinionName { get; set; }
        public string Approver { get; set; }
        public string ApproveDate { get; set; }
        public string MeetNo { get; set; }
        public string MeetResult { get; set; }
        public string MeetDate { get; set; }
        public string ApproverAmount { get; set; }
        public string Budget { get; set; }
        public int BudgetID { get; set; }
        public string RightgiverTitle { get; set; }
        public string RightgiverName { get; set; }
        public string RightgiverLastName { get; set; }
        public string Faultbase { get; set; }
        public string CourtLevel { get; set; }
        public int SubcommitteeID { get; set; }
        public string SubcommitteeName { get; set; }


    }
}
