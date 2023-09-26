using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class DuplicateDataRequest
    {
        public int CaseID { get; set; }
        public int ApplicantID { get; set; }
        public int DepartmentID { get; set; }
        public int OldDepartmentID { get; set; }
        public int JFCaseTypeID { get; set; }
        public int UserID { get; set; }
        public string RegisterDateStr { get; set; }
    }
    public class ApplicantRelatedPersonDataResult
    {
        public int ContactPersonID { get; set; }
        public int AddressID { get; set; }
        public string Address1 { get; set; }
        public string HouseNo { get; set; }
        public string Soi { get; set; }
        public string Street { get; set; }
        public string VillageNo { get; set; }
        public int ProvinceID { get; set; }
        public int DisctrictID { get; set; }
        public int SubdistrictID { get; set; }
        public string PostCode { get; set; }
        public string GenderCode { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonRoleID { get; set; }
        public int CaseID { get; set; }
        public int ApplicantID { get; set; }
        public string RelatedAs { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
