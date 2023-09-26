namespace JFS.Megazy.MilkyWaySolution.Engine.Request
{
    public class CaseComponentFilters : ComponentFilters
    {
        public LocationFillters Location { get; set; }
        public string CaseType { get; set; }
        public bool IsAppeal { get; set; } = false;
        public string Status { get; set; }
        public string WorkStep { get; set; }
        public string LawyerID { get; set; }
        public string DepartmentID { get; set; }
        public string ClaimType { get; set; }
    }
    public class TransactionFilters : ComponentFilters
    {
        public LocationFillters Location { get; set; }
        public string CaseType { get; set; }
        public string Status { get; set; }
        public string WorkStep { get; set; }
        public string LawyerID { get; set; }
        public int TransactionID { get; set; }
        public string TransactionNo { get; set; }
        public string DepartmentID { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionType { get; set; }

        public int ItemsPerPage { get; set; } = 200;
        public int CurrentPage { get; set; } = 1;
        public string UpdateDateFrom { get; set; }
        public string UpdateDateTo { get; set; }
    }
    public class TrackingFilters : ComponentFilters
    {
        public string CardID { get; set; }
     
    }
    public class CaseFilters : CaseComponentFilters
    {
        public string JFCaseNo { get; set; }
        public int CaseID { get; set; } = 0;
        public int ApplicantID { get; set; } = 0;
        public int ItemsPerPage { get; set; } = 200;
        public int CurrentPage { get; set; } = 1;
    }
    public class GroupCaseFilters: ComponentFilters
    {
        public string UserCreateID { get; set; }
        public string DepartmentID { get; set; }
    }
}
