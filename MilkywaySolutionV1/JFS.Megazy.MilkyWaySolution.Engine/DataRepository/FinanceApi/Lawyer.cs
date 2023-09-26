using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FinanceApi
{
    public class Lawyer
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  CardID { get; set; }
        public string TelephoneNo { get; set; }
        public string Email { get; set; }
        public string URL { get; set; }
        public int FormID { get; set; }
        public string FormName { get; set; }
        public string ContractNo { get; set; }
        public string ContractNote { get; set; }
        public double Amount { get; set; }
        public string ContractDate { get; set; }
        public Address Address { get; set; }
    }
}
