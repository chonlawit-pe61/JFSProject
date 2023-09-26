using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressRequest = JFS.Megazy.MilkyWaySolution.Engine.Structure.AddressData;
namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{

    public class CaseApplicationDataRequest
    {
        public CaseApplicantData CaseApplicantData { get; set; }
        public CaseApplicantExtensionData CaseApplicantExtensionData { get; set; }
        public CaseApplicationData CaseApplicationData { get; set; }      
        public CaseMapCaseCategoryData CaseMapCaseCategoryData { get; set; }
        public EducationData EducationData { get; set; }
        public ApplicantAddressDataRequest[] ApplicantAddressDataRequest { get; set; }
        public CaseApplicantRequestData SourceData { get; set; }
        public CaseApplicationChannelData ChannelData { get; set; }
        public CaseApplicantPDPAData pDPAData { get; set; }
        public string imgSignature { get; set; }
        public Attach[] FileAttach { get; set; }
    }
    public class CaseDataRequest
    {
        public CaseApplicationData CaseApplicationData { get; set; }
        public CaseMapCaseCategoryData CaseMapCaseCategoryData { get; set; }
        public CaseOwnerDepartmentData CaseOwnerDepartmentData { get; set; }
        public int StatusID { get; set; }
        public int WorkStepID { get; set; }
    }

    public class Attach
    {
        public int AttachFileID { get; set; }
        public int TransactionID { get; set; }
        public string FileName { get; set; }
        public string FileLable { get; set; }

    }




}
