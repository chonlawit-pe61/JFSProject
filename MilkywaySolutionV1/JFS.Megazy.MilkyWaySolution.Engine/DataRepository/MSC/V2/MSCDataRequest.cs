using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.AddressData;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.MSC.V2
{

    // Root General = JsonConvert.DeserializeObject<General>(myJsonResponse);
    public class Address
    {
        [JsonProperty("no")]
        public string No { get; set; }
        [JsonProperty("soi")]
        public string Soi { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("tamboon_name")]
        public string Tamboon_name { get; set; }
        [JsonProperty("amphur_name")]
        public string Amphur_name { get; set; }
        [JsonProperty("province_name")]
        public string Province_name { get; set; }
        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }
    }

    public class Attach
    {
        [JsonProperty("srcAttach")]
        public string SrcAttach { get; set; }
        [JsonProperty("nameAttach")]
        public string NameAttach { get; set; }
        [JsonProperty("typeAttach")]
        public string TypeAttach { get; set; }
    }

    public class General
    {
     
        [JsonProperty("CardID")]
        public string CardID { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("firstname")]
        public string Firstname { get; set; }
        [JsonProperty("lastname")]
        public string Lastname { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("tel")]
        public string Tel { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }
        [JsonProperty("petNo")]
        public string PetNo { get; set; }
        [JsonProperty("petMainTypeName")]
        public string PetMainTypeName { get; set; }
        [JsonProperty("petTypeName")]
        public string PetTypeName { get; set; }
        [JsonProperty("petName")]
        public string PetName { get; set; }
        [JsonProperty("petDetail")]
        public string PetDetail { get; set; }
        [JsonProperty("boardName")]
        public string BoardName { get; set; }
        [JsonProperty("petDate")]
        public string PetDate { get; set; }
        [JsonProperty("petTimeRegister")]
        public string PetTimeRegister { get; set; }
        [JsonProperty("petTime")]
        public string PetTime { get; set; }
        [JsonProperty("petTimeFinished")]
        public string PetTimeFinished { get; set; }
        [JsonProperty("defdInfo")]
        public string DefdInfo { get; set; }
        [JsonProperty("deptOtherContact")]
        public string DeptOtherContact { get; set; }
        [JsonProperty("confidential")]
        public string Confidential { get; set; }
        [JsonProperty("situStartDate")]
        public string SituStartDate { get; set; }
        [JsonProperty("situEndDate")]
        public string SituEndDate { get; set; }
        [JsonProperty("situAboutTime")]
        public string SituAboutTime { get; set; }
        [JsonProperty("situPlace")]
        public string SituPlace { get; set; }
        [JsonProperty("situProvName")]
        public string SituProvName { get; set; }
        [JsonProperty("situAmpName")]
        public string SituAmpName { get; set; }
        [JsonProperty("situTambName")]
        public string SituTambName { get; set; }
    }

    public class MSCDataRequest
    {   // / <summary>
        /// รหัสจังหวัดเจ้าของเรื่อง (สยจ.)
        /// </summary>
        public string DivnID { get; set; }
        public string ReferenceMSCID { get; set; }
        public string ReferenceMSCCode { get; set; }
        public General General { get; set; }
        [JsonProperty("attach")]
        public List<Attach> Attach { get; set; }
    }
    public class MSCDataResponse
    {
        public General General { get; set; }
        public View_ApplicantAddressRow MSCPermamentAddress { get; set; }
        //public ProvinceDistrictSubDistrict AddressList { get; set; }
    }

}
