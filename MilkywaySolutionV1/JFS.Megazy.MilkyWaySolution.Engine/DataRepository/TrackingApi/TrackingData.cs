using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.TrackingApi
{
    public class TrackingData
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalCase { get; set; }
        public int TotalProcessingCase { get; set; }
        public int TotalCompletedCase { get; set; }
        public List<ApplicantCase> ListCase { get; set; }
    }
    public class ApplicantCase
    {
        public string JFCaseNo { get; set; }
        public List<ApplicantCaseDetail> StepList { get; set; }

    }
    public class ApplicantCaseDetail
    {
        public string StepDate { get; set; }
        public string StepName { get; set; }
    }
}
