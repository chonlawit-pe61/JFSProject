using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc
{

    public class Por4LicenseData
    {
        [JsonProperty("content")]
        public List<Por4LicenseContent> content { get; set; }
        public Pageable pageable { get; set; }
        public int totalPages { get; set; }
        public int totalElements { get; set; }
        public int number { get; set; }
        public int size { get; set; }
        public int numberOfElements { get; set; }
        public Sort2 sort { get; set; }
        public bool last { get; set; }
        public bool first { get; set; }
        public bool empty { get; set; }
    }

    public class Por4LicenseContent
    {
        public string citizenCardNumber { get; set; }
        public string dataId { get; set; }
        public long applicantType { get; set; }
        public object docDate { get; set; }
        public object expireDate { get; set; }
        public long hid { get; set; }
        public object hid2 { get; set; }
        public object personalId { get; set; }
        public long personalId2 { get; set; }
        public object processTimestamp { get; set; }
        public object total { get; set; }
        public BusinessType businessType { get; set; }
        public FullNameAndRank2 fullNameAndRank2 { get; set; }
        public string amphorDesc { get; set; }
        public string amphorDesc2 { get; set; }
        public string businessName { get; set; }
        public string districtDesc { get; set; }
        public string districtDesc2 { get; set; }
        public string docID { get; set; }
        public string docPlaceDesc { get; set; }
        public string docPlaceProvince { get; set; }
        public string firstName { get; set; }
        public string firstName2 { get; set; }
        public string fullNameAndRank { get; set; }
        public string genderDesc { get; set; }
        public string genderDesc2 { get; set; }
        public string gunCharacteristic { get; set; }
        public string gunProduct { get; set; }
        public string gunRegistrationId { get; set; }
        public string gunSerialNo { get; set; }
        public string gunSize { get; set; }
        public string gunType { get; set; }
        public string hidRcodeDesc { get; set; }
        public string hidRcodeDesc2 { get; set; }
        public string hno { get; set; }
        public string hno2 { get; set; }
        public string lastName { get; set; }
        public string lastName2 { get; set; }
        public string middleName { get; set; }
        public string middleName2 { get; set; }
        public string provinceDesc { get; set; }
        public string provinceDesc2 { get; set; }
        public string remark { get; set; }
        public string soi { get; set; }
        public string soi2 { get; set; }
        public string thanon { get; set; }
        public string thanon2 { get; set; }
        public string titleDesc { get; set; }
        public string titleDesc2 { get; set; }
        public string trok { get; set; }
        public string trok2 { get; set; }
        public AdditionalProperties additionalProperties { get; set; }
        public string id { get; set; }
    }
    public class AdditionalProperties
    {
    }

    public class BusinessType
    {
    }

    public class FullNameAndRank2
    {
    }
}


