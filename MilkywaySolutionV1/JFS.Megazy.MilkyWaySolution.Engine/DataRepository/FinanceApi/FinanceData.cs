using System.Collections.Generic;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FinanceApi
{
    public class FinanceDataResponse
    {
        public IEnumerable<FinanceData> ListFinanceData { get; set; }
        public bool First { get; set; }
        public bool Last { get; set; }
        //public int Number { get; set; }
        //public int NumberOfElements { get; set; }
        // public PageAble pageable { get; set; }
        public int ItemPerPage { get; set; } = 100;
        // public Sort2 sort { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
    public class FinanceData
    {
        public CaseDetail CaseDetail { get; set; }
        public Contract Contract { get; set; }
        public Transaction Transaction { get; set; }
        public IEnumerable<Cheque> Cheque { get; set; }

    }

}
