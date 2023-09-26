using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Linkage
{

    /// <summary>
    /// ข้อมูลทะเบียนราษฎร
    /// </summary>
    public class CivilRegistrationData
    {
        public int titleCode { get; set; }
        public string titleDesc { get; set; }
        public string titleName { get; set; }
        public int titleSex { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public int genderCode { get; set; }
        public string genderDesc { get; set; }
        public int dateOfBirth { get; set; }
        public int nationalityCode { get; set; }
        public string nationalityDesc { get; set; }
        public string ownerStatusDesc { get; set; }
        public int statusOfPersonCode { get; set; }
        public string statusOfPersonDesc { get; set; }
        public int dateOfMoveIn { get; set; }
        public int age { get; set; }
        public long fatherPersonalID { get; set; }
        public string fatherName { get; set; }
        public int fatherNationalityCode { get; set; }
        public string fatherNationalityDesc { get; set; }
        public long motherPersonalID { get; set; }
        public string motherName { get; set; }
        public int motherNationalityCode { get; set; }
        public string motherNationalityDesc { get; set; }
        public string fullnameAndRank { get; set; }
        public string englishTitleDesc { get; set; }
        public string englishFirstName { get; set; }
        public string englishMiddleName { get; set; }
        public string englishLastName { get; set; }

    }
}
