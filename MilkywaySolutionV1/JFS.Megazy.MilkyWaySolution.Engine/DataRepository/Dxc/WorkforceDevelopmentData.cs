using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc
{

    public class WorkforceDevelopmentData
    {
        [JsonProperty("content")]
        public List<WorkforceDevelopmentContent> content { get; set; }
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

    public class WorkforceDevelopmentContent
    {
        public string certificateDate { get; set; }
        public string certificateNo { get; set; }
        public string citizenCardNumber { get; set; }
        public string course { get; set; }
        public string dataId { get; set; }
        public string email { get; set; }
        public string id { get; set; }
        public string names { get; set; }
        public string personalId { get; set; }
        public string site { get; set; }
        public string telNo { get; set; }
        public string trainId { get; set; }
        public string typeOfTrain { get; set; }
        public string year { get; set; }
    }
}
