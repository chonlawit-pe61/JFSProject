using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    class CaseProjectDataResponse
    {
        ProjectAddressDataResponse ProjectAddressData { get; set; }
        ProjectContactPersonDataResponse ProjectContactPersonData { get; set; }
        CaseProjectApplicantDataResponse CaseProjectApplicantData { get; set; }

    }


    public class CaseProjectApplicantDataResponse
    {

        public CaseApplicantRow CaseApplicantRow { get; set; }
        public CaseProjectRow CaseProjectRow { get; set; }
        public ProjectAddressDataResponse ProjectAddressData { get; set; }
        public CaseApplicantExtensionRow CaseApplicantEXRow { get; set; }
        public ApplicantAdditionalInfoRow applicantAdditionalRow { get; set; }
    }

    public class ProjectContactPersonDataResponse
    {
        public ProjectContactPersonRow ProjectContactPerson { get; set; }
        public AddressRow Address { get; set; }
    }

    public class ProjectAddressDataResponse
    {
        public ProjectAddressRow ProjectAddress { get; set; }
        public AddressRow Address { get; set; }
    }
    public class ProjectLocationDataResponse
    {
        public ProjectLocationRow ProjectLocation { get; set; }
        public AddressRow Address { get; set; }
    }

    public class ReviewReport
    {
        public int isSendreport { get; set; }
        public int isCheck { get; set; }
        public int isPass { get; set; }
        public string Comment { get; set; }
        public string AliasName { get; set; }
        public DateTime DateSend { get; set; }
    }
}
