using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc
{
    public class SeizeData
    {
        [JsonProperty("content")]
        public List<SeizeContent> content { get; set; }
        public bool empty { get; set; }
        public bool first { get; set; }
        public bool last { get; set; }
        public int number { get; set; }
        public int numberOfElements { get; set; }
        public Pageable pageable { get; set; }
        public int size { get; set; }
        public Sort2 sort { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
    }
    public class SeizeContent
    {
        public string citizenCardNumber { get; set; }
        public int dataId { get; set; }
        public string dataSource { get; set; }
        public DateTime? dataSubmitDate { get; set; }
        public string firstname { get; set; }
        public int id { get; set; }
        public string lastname { get; set; }
        public string prisonCode { get; set; }
        public string prisonerId { get; set; }
        public string seizeBase { get; set; }
        public string seizeBaseDesc { get; set; }
        public DateTime? seizeBookDate { get; set; }
        public string seizeBookNo { get; set; }
        public DateTime? seizeCaseDate { get; set; }
        public string seizeOwner { get; set; }
        public string seizePolice { get; set; }
        public string seizePrisonName { get; set; }
        public string seizeProvince { get; set; }
        public string seizeProvinceDesc { get; set; }
        public string seizeRemark { get; set; }
        public string seizeStatus { get; set; }
        public string seizeStatusName { get; set; }
        public string seizeType { get; set; }
        public string seizeTypeName { get; set; }
        public string seizeWarrantDate { get; set; }
        public string seizeWarrantNo { get; set; }
        public DateTime? seizeWithdrawBookDate { get; set; }
        public string seizeWithdrawBookNo { get; set; }
        public string seizeWithdrawRemark { get; set; }

    }



  
}
