using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
   public class CaseApplicantDataResponse
    {
        public int FinalApprovedID { get; set; }
        public bool IsAppeal { get; set; }
        public View_ApplicationRow CaseApplicantData { get; set; }
        public View_ApplicantEducationRow EducationData { get; set; }
        public View_ApplicantAddressRow[] ApplicantAddressData { get; set; }
    }
    public class CaseDataResposne
    {
        public int CaseID { get; set; }
        public int ApplicantID { get; set; }
        public int ProxyID { get; set; }

    }
}
