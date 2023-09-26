using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using AddressDepData = JFS.Megazy.MilkyWaySolution.Engine.Structure.AddressData;
namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{


 public abstract class Department
 {
        public int DepartmentID { get; set; }
        public int ProvinceID { get; set; }
        public string  DepartmentName { get; set; }
        public string DepartmentNameAbbr { get; set; }
        public bool IsActive { get; set; } = false;
        public string ModifiedDate { get; set; }

  
    }
    /// <summary>
    /// ข้อมูลสำนักงาน
    /// </summary>
    public class DepartmentResponse : Department
    {
        public DepartmentAddress Address { get; set; }

    }
    /// <summary>
    /// สำนักงาน + ID ที่สามารถไปใช้ในการแก้ไขได้
    /// </summary>
    public class DepartmentEditableResponse : Department
    {
        public DepartmentAddressEditable Address { get; set; }
        public DepartmentAuthorizedPersonData AuthorizedPerson { get; set; }
    }


    public class DepartmentAddress : AddressDepData
    {
        public int DepartmentID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string TelephoneNo { get; set; }
        public string FaxNo { get; set; }
    }
    public class DepartmentAddressEditable : DepartmentAddress
    {    
        public View_AddressRow[] OptionList { get; set; }
    }





















}
