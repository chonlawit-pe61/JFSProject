using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public abstract class LawyerData : Person
    {
        public int LawyerID { get; set; }
        public string CardID { get; set; }
        public Gender Gender { get; set; }
        public string LicenseNo { get; set; }
        public string LicenseType { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Education { get; set; }
        public string Remark { get; set; }
        public int NumberOfConductCase { get; set; }
        public int YearsExperience { get; set; }
        public string IssueDate { get; set; }
        public string ExprieDate { get; set; }
        public string RegisterDate { get; set; }
        public string ModifiedDate { get; set; }      
        public string DateOfBirth { get; set; }      
        public string LawyerStatus { get; set; }
        
        public string LawyerTypeName { get; set; }
        public int LawyerTypeID { get; set; }
        public List<Territory> Territory { get; set; }
        public LawyerEnrollment[] Enrollment { get; set; }
        public LawyerSpecialtyRow[] Specialty { get; set; }
    }


    public class LawyerEnrollment
    {
        public int EnrollmentYear { get; set; }
        public DateTime EnrollmentDate { get; set; }

    }


    /// <summary>
    /// ข้อมูลทนาย
    /// </summary>
    public class LawyerResponse : LawyerData
    {
        public LawyerAddress Address { get; set; }

    }
    /// <summary>
    /// ข้อมูลทนาย + ID ที่สามารถไปใช้ในการแก้ไขได้
    /// </summary>
    public class LawyerEditableResponse : LawyerData
    {
        public int LawyerStatusID { get; set; }
        public LawyerAddressEditable Address { get; set; }
        public LawyerOfficeEditable OfficeAddress { get; set; }
       
    }

  

    public class LawyerAddress : Address
    {
        public string TelephoneNo { get; set; }
        public string FaxNo { get; set; }
        //public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsPrimary { get; set; }
    }
    public class LawyerAddressEditable : LawyerAddress
    {
        public int AddressID { get; set; }
        public int AddressTypeID { get; set; }
        public int ProvinceID { get; set; }
        public int DistrictID { get; set; }
        public int SubDistrictID { get; set; }

    }
    public class LawyerOffice
    {
        public int LawyerOfficeID { get; set; }
        public string LawyerFirmName { get; set; }
        public string TelephoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

    }
    public class LawyerOfficeEditable : LawyerOffice
    {
        public LawyerOfficeAddressEditable Address { get; set; }
    }
    public class LawyerOfficeAddress : Address
    {
        public string TelephoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
    public class LawyerOfficeAddressEditable : LawyerOfficeAddress
    {
        public int AddressID { get; set; }
        public int AddressTypeID { get; set; }
        public int ProvinceID { get; set; }
        public int DistrictID { get; set; }
        public int SubDistrictID { get; set; }

    }


    public class ResponseLawyerOfficeAddress
    { 
        public LawyerOfficeRow OfficeRow { get; set; }
        public View_LawyerOfficeAddressRow OfficeAddressRow { get; set; }
    
    }

    public class LawyerAttachFile 
    {
        public int LawyerID { get; set; }
        public int AttachFileID { get; set; }
        public string AttachFileIDTitle { get; set; }
        public string ModifiedDate { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public int SortOrder { get; set; }

    }
   



}
