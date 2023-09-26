using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class Applicant
    {
        public int ApplicantID { get; set; }
    }
    public class CaseIDApplicantID : Applicant
    {
        public  bool HasJFCaseNo { get; set; }
        public int CaseID { get; set; }
    }
    public class ApplicantCrime : Applicant
    {      
        public int CrimeID { get; set; }
        public string PoliceStation { get; set; }
        public string Charge { get; set; }
        public string LegalConsequence { get; set; }
        public string CrimeDate { get; set; }
    }
    public class ApplicantExpense : Applicant
    {
        public int ExpenseID { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
    }
    public class ApplicantNoIncome : Applicant
    {
        public int NoIncomeID { get; set; }
        public string Cause { get; set; }
        public string SupportBy { get; set; }
        public float Income { get; set; }
        public string IncomeUnit { get; set; }
    }
    public class ApplicantFamily : Applicant
    {
        public int FamilyID { get; set; }
        public string GroupName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string TelephoneNo { get; set; }
        public string Career { get; set; }
        public string AddressLine { get; set; }        

    }
    public class ApplicantIncome : Applicant
    {
        public int IncomeID { get; set; }
        public bool IsPermanent { get; set; }
        public string OcupationPosition { get; set; }
        public float Income { get; set; }
        public string IncomeUnit { get; set; }
        public string WorkPlace { get; set; }
        public string TelphoneNo { get; set; }
        public decimal MyProperty { get; set; }
    }
    public class ApplicantEducation : Applicant
    {
        public int EducationLevelID { get; set; }
        public string Education { get; set; }
    }
    public class ApplicantAttachFile : Applicant
    {
        public int ArchivalCopyID { get; set; }
        public int AttachFileID { get; set; }
        public string Remark { get; set; }
        
    }
    public class ApplicantAttachFileResponse
    {
        public ApplicantAttachFileRow[] applicantAttachFileRow { get; set; }
        public ArchivalCopyMapJFCaseTypeRow[] archivalCopyMapJFCaseTypeRow { get; set; }
    }
    public class ApplicantBail : Applicant
    {
        public int BailID { get; set; }
        public int BailStatusID { get; set; }
        public string Description { get; set; }
    }
    public class ApplicantBailResponse
    {
        public ApplicantBailInfo[] applicantbail { get; set; }
    }
    public class ApplicantBailInfo : ApplicantBailRow
    {
        public string BailAt { get; set; }
        public int BailOutLevelID { get; set; }
        public DateTime ModifiedDate { get; set; }
    }    
    public class ApplicantCareerResponse : Applicant
    {
        public ApplicantIncomeRow[] hascareer { get; set; }
        public ApplicantNoIncomeRow[] nocareer { get; set; }
        public ApplicantExpenseRow[] expense { get; set; }
        public ApplicantAssetRow[] asset { get; set; }
        public ApplicantCareerRow[] career { get; set; }
        public ApplicantAdditionalInfoRow socialWelfareCard { get; set; }

    }
    public class ApplicantCareerEditData : Applicant
    {
        public ApplicantCareerRow Career { get; set; }
        public ApplicantCareerRow SupCareer { get; set; }
        public ApplicantIncomeRow ApplicantIncome { get; set; }
        public ApplicantIncomeRow ApplicantSupIncome { get; set; }
        public ApplicantNoIncomeRow ApplicantOnincome { get; set; }
        public ApplicantAssetRow ApplicantAsset { get; set; }
        public ApplicantExpenseRow[] ApplicantExpense { get; set; }
        public int careerstatus { get; set; }
        public int supcareerstatus { get; set; }
        public int assetstatus { get; set; }
        public ApplicantAdditionalInfoData ApplicantAdditionalInfo { get; set; }


    }
    public class ApplicantDetailRespon
    {
        public View_ApplicantRow Applicant { get; set; }
        public View_ApplicantAddressRow[] Address { get; set; }
        public View_ApplicantEducationRow Education { get; set; }
    }
    public class ApplicantCareerIDSend
    {
        public int incomeID { get; set; }
        public int supincomeID { get; set; }
        public int onincomeID { get; set; }
        public int assetID { get; set; }
        public List<ApplicantExpenseRow> expenseID { get; set; }
    }

    public class ApplicantCrimeRespon
    {
        public List<ApplicantCrimeRow> crimedata { get; set; }
    }
    public class ReligionOther
    {
        public int religionID { get; set; }
        public string religionName { get; set; }
        public bool IsActive { get; set; }
        public bool IsOther { get; set; }
    }
    public class ArchivalCopyRespon
    {
        public int ArchivalCopyID { get; set; }
        public string ArchivalName { get; set; }
        public int JFCaseTypeID { get; set; }
    }
    public class ApplicantInterviewBailRespon
    {
        public ApplicantInterviewBailData ApplicantInterviewBailData { get; set; }
        public CaseArrestWithRow[] CaseArrestWithRow { get; set; }
    }
    public class ApplicantRelatePerson
    {
        public AddressRow[] Address { get; set; }
        public PersonRow[] Person { get; set; }
        public ApplicantRelatedPersonRow[] Relate { get; set; }
    }
    public class PersonRespon
    {
        public Object AddressID { get; set; }
        public Object PersonID { get; set; }
    }
}
