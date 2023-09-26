using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FinanceApi
{
    public class CaseDataResponse
    {
        public IEnumerable<CaseData> ListCaseData { get; set; }
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
    public class CaseData
    {
        public CaseDetail CaseDetail { get; set; }
        public IEnumerable<Contract> Contract { get; set; }
    }
}
