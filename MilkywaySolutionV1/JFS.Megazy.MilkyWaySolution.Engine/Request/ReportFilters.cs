namespace JFS.Megazy.MilkyWaySolution.Engine.Request
{
    public class ReportFilters : ComponentFilters
    {
        public string DepartmentID { get; set; }
        public string ProvinceType { get; set; }
        public string JFCaseTypeID { get; set; }
        public int WorkStepID { get; set; }
        public int StatusID { get; set; }
        public string MeetingDate { get; set; }
    }
    public class ExportListJFSCaseFilters : ComponentFilters
    {

        public string DepartmentID { get; set; }
        public string ProvinceType { get; set; }
        public string Month { get; set; }
        public string JFCaseTypeID { get; set; }
        public string Role { get; set; }
        public int ReportType { get; set; }
    }
}
