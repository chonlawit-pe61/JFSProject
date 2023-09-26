using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc
{

    public class BorderPassesData
    {
        [JsonProperty("content")]
        public List<BorderPassesContent> content { get; set; }
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

    public class BorderPassesContent
    {
        public string citizenCardNumber { get; set; }
        public string dataId { get; set; }
        public string bookNo { get; set; }
        public string bookTypeDesc { get; set; }
        public string borderName { get; set; }
        public object borderPassNo { get; set; }
        public object dateOfBirth { get; set; }
        public object dateOfReq { get; set; }
        public string englistName { get; set; }
        public object expireDate { get; set; }
        public string genderText { get; set; }
        public object height { get; set; }
        public string houseAlleyDesc { get; set; }
        public string houseAlleyWayDesc { get; set; }
        public string houseDistrictDesc { get; set; }
        public string houseNo { get; set; }
        public string houseProvinceDesc { get; set; }
        public string houseRoadDesc { get; set; }
        public string houseSubdistrictDesc { get; set; }
        public object houseVillageNo { get; set; }
        public string occupation { get; set; }
        public object personalID { get; set; }
        public object reqNo { get; set; }
        public string specialPeculiarities { get; set; }
        public object statusOfRequest { get; set; }
        public string thaiName { get; set; }
        public string travelPurpose { get; set; }
        public string id { get; set; }

    }

}




