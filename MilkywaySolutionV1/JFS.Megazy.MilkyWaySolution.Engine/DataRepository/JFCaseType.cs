using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
   public class JFCaseType
    {
        public int JFCaseTypeID { get; set; }
        public string JFCaseTypeName { get; set; }
        public bool IsActive { get; set; }
        public string JFCaseTypeAbbr { get; set; }
    }
    public class JFCaseTypeReportData
    {
        public int JFCaseTypeID { get; set; }
        public int Amount { get; set; }
        public string JFCaseTypeAbbr { get; set; }

    }

    public class KPI21ReportData
    {
        public int JFCaseTypeID { get; set; }
        public string JFCaseTypeAbbr { get; set; }
        public string WorkStepName { get; set; }
        public int TotalCase { get; set; }
        public string DayRange { get; set; }
    }
    public class KPIReportData
    {
        public int KPI21 { get; set; }
        public int KPI22 { get; set; }
        public int KPI31 { get; set; }
        public int KPI45 { get; set; }
        public string WorkStepName { get; set; }
        public string JFCaseTypeAbbr { get; set; }

    }
    public class JFSCaseTotalData
    {
        public int JFCaseTypeID { get; set; }
        public int Total { get; set; }
    }
}
