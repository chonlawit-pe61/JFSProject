using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc
{

    public class JuvenilOffenderData
    {
        [JsonProperty("content")]
        public List<JuvenilOffenderContent> content { get; set; }
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

    public class JuvenilOffenderContent
    {
        public string allegation { get; set; }
        public DateTime? birthDate { get; set; }
        public string birthDateSrc { get; set; }
        public string blackCaseNum { get; set; }
        public string caseId { get; set; }
        public string caseNum { get; set; }
        public string caseYear { get; set; }
        public string citizenCardNumber { get; set; }
        public DateTime? dataSubmitDate { get; set; }
        public string education { get; set; }
        public DateTime? eventDate { get; set; }
        public string eventNo { get; set; }
        public string fatherHouseNo { get; set; }
        public string fatherName { get; set; }
        public string firstName { get; set; }
        public string houseNo { get; set; }
        public int id { get; set; }
        public string lastName { get; set; }
        public string liveHouseNo { get; set; }
        public string liveName { get; set; }
        public string liveRelation { get; set; }
        public string motherHouseNo { get; set; }
        public string motherName { get; set; }
        public DateTime? receiveDate { get; set; }
        public string receiveDateSrc { get; set; }
        public string redCaseNum { get; set; }
        public DateTime? releaseDate { get; set; }
        public string releaseDateSrc { get; set; }
        public string rn19Name { get; set; }
        public string rn19Occupation { get; set; }
        public string rulerHouseNo { get; set; }
        public string rulerName { get; set; }
        public string rulerTelephone { get; set; }
        public string sex { get; set; }
        public string title { get; set; }
        public string trainingUnitName { get; set; }
        public string unitName { get; set; }
        public string wordDesc { get; set; }
    }

}
