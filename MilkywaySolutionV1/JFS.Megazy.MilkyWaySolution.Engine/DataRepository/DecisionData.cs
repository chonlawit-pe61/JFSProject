using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public abstract class DecisionData
    {
        public int CaseID { get; set; }
        public int ApplicantID { get; set; }
        public int OfficerRoleID { get; set; }
        public int OpinionID { get; set; }
        public string OpinionText { get; set; }
        public string NotifyDateStr { get; set; }
         public DateTime NotifyDate { get; set; }
        public string DecisionDate { get; set; }
        public string ShortDescription { get; set; }
       // public double Amount { get; set; }
        public string TelephonNo { get; set; }
        public string Email { get; set; }
        public bool IsSendSMS { get; set; }
        public bool  IsSendEmail { get; set; }

    }
    public class DecisionDataResponse : DecisionData
    { 
    
    }
}
