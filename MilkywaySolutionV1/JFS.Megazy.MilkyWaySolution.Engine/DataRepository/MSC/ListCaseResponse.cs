using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.MSC
{
    public class ListCaseResponse
    {
        public ListCaseResult ListCaseResult { get; set; }
    }

    public class ListCaseResult
    {
        public IEnumerable<CaseData> Cases { get; set; }
        public bool First { get; set; }
        public bool Last { get; set; }
        public int ItemPerPage { get; set; } = 50;
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
    public class CaseData
    {
        public string CaseID { get; set; }
        public string CaseCode { get; set; }
        public string MSCID { get; set; }
        public string MSCCode { get; set; }
        public string OfficeID { get; set; }
        public string OfficeCode { get; set; }
        /// <summary>
        /// EX:YYYYMMDD
        /// </summary>
        public string IssueDate { get; set; }
        public string Remark { get; set; }


    }
    public class Person
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string CardID { get; set; }
        public string BirthDate { get; set; }
        public string Religion { get; set; }

    }
    public class Address
    {
        public string HouseNo { get; set; }
        public string VillageNo { get; set; }
        public string Street { get; set; }
        public string Soi { get; set; }
    }
}
