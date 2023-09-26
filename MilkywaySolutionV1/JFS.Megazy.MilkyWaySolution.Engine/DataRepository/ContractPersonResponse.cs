using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class ContractPersonResponse
    {
        public int ContractID { get; set; }
        public int CaseID { get; set; }
        public int AddressID { get; set; }
        public int ApplicantID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardID { get; set; }
        public string GenderCode { get; set; }
        public string ContractDate { get; set; }
        public string ContractNo { get; set; }
        public string ContractNote { get; set; }
        public int PersonID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string TelephoneNo { get; set; }
        public string Address { get; set; }
    }
    public class ContractWitness 
    {
        public View_ContractFormRow Contract { get; set; }       
        public View_ContractPersonRow[] Witness { get; set; }
    }

    public class ContractFromResponseShow
    {
        public View_ApplicationRow Application { get; set; }
        public View_ApplicantAddressRow ApplicantAddress { get; set; }
        public CaseExpenseRow[] CaseExpense { get; set; }
        public CaseProjectRow CaseProject { get; set; }
        public CurrentCaseStatusRow CurrentCaseStatus { get; set; }
        public CaseVictimRow CaseVictim { get; set; }
        public AddressRow ProjectAddress { get; set; }
        public ContractWitness ContractWitness { get; set; }

    }
    
    public class AuthorizedOfficialsData
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Book { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string FormDate { get; set; }

    }
    public class ProjectProxyDetail
    {
        public string PlaceName { get; set; }
        public string Position { get; set; }
        public string Authorize { get; set; }
        public string AuthorizeDate { get; set; }
    }
    public class GuaranteeData
    {
        public PersonData Guarantee { get; set; }
        public AddressRow GuaranteeAddress { get; set; }
    }
}
