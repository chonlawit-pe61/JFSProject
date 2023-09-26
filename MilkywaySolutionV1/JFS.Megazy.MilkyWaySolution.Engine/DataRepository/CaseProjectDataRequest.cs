using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class CaseProjectDataRequest
    {

        public CaseProjectData CaseProjectData { get; set; }
        public CaseProjectSourceFundData[] CaseProjectSourceFundData { get; set; } = null;
        public CaseProjectReferencePersonData[] CaseProjectReferencePersonData { get; set; } = null;
        public CaseProjectCharacteristicsData[] CaseProjectCharacteristicsData { get; set; } = null;
        public CaseProjectDocumentCheckData[] CaseProjectDocumentCheckData { get; set; } = null;
        public ProjectAttachfile[] ProjectAttachfile { get; set; } = null;
        public CaseApplicantData CaseApplicantData { get; set; }
        public CaseApplicationData CaseApplicationData { get; set; }
        public CaseMapCaseCategoryData CaseMapCaseCategoryData { get; set; }
        public ProjectContactPersonDataRequest ProjectContactPersonData { get; set; }
        public ProjectAddressDataRequest ProjectAddressData { get; set; }
        public CaseApplicantExtensionData CaseApplicantExData { get; set; }
        public ProjectLocationAddressDataRequest ProjectLocation { get; set; }
        public ProjectCaseExpense ProjectCaseExpenseData { get; set; }
        public ProjectProxyDataRespones ProxyData { get; set; }
        public string imgSignature { get; set; }
        public Attach[] MSCFileAttach { get; set; }
    }
    public class ProjectProxyDataRespones : ProxyDataRespones
    {
        public string Religionother { get; set; }
    }

    public class ProjectContactPersonDataRequest
    {
        public ProjectContactPersonData ProjectContactPerson { get; set;  }
        public AddressRow AddressRow { get; set; }
    }
    public class ProjectAttachfile:TransactionAttachfileData
    {
        public string Path { get; set; }
        public string Url { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
    }
    public class ProjectResultAttachfile : MemberResultAttachFileData
    {
        public string Path { get; set; }
        public string Url { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
    }

    public class ProjectAddressDataRequest
    {
        public ProjectAddressData ProjectAddress { get; set; }
        public AddressRowRes AddressRow { get; set; }
    }
    public class AddressRowRes : AddressRow
    {
        public string ProvinceName { get; set; }
        public string SubdistrictName { get; set; }
        public string DisctrictName { get; set; }
    }
    public class ProjectLocationAddressDataRequest
    {
        public ProjectLocationData ProjectLocation { get; set; }
        public AddressRowRes AddressRow { get; set; }
    }

    public class ProjectCaseExpense
    {
        public CaseExpenseData[] caseExpense { get; set; }
        public CaseExpenseOtherData other { get; set; }
    }



}
