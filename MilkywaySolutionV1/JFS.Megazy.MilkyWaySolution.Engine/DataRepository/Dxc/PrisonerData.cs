using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc
{
    public class PrisonerData
    {
        [JsonProperty("content")]
        public List<PrisonerContent> content { get; set; }
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
    public class PrisonerContent
    {
        public string addressAmphurText { get; set; }
        public string addressMooBanText { get; set; }
        public string addressMooText { get; set; }
        public string addressNoText { get; set; }
        public string addressPostCode { get; set; }
        public string addressProvinceText { get; set; }
        public string addressRoadText { get; set; }
        public string addressSoiText { get; set; }
        public string addressTumbonText { get; set; }
        public string allegation { get; set; }
        public int amountOfTimesBreakDiscipline { get; set; }
        public string citizenCardNumber { get; set; }
        public string dataId { get; set; }
        public string dataSource { get; set; }
        public DateTime? dataSubmitDate { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string decidedCaseId { get; set; }
        public string educationLevel { get; set; }
        public string educationProvince { get; set; }
        public string educationSchool { get; set; }
        public string fatherFirstName { get; set; }
        public string fatherLastName { get; set; }
        public string fatherPrefix { get; set; }
        public string firstName { get; set; }
        public string imposeTypeCode { get; set; }
        public string judgement { get; set; }
        public string lastName { get; set; }
        public string motherFirstName { get; set; }
        public string motherLastName { get; set; }
        public string motherPrefix { get; set; }
        public string nationality { get; set; }
        public string nationalityCode { get; set; }
        public string policeCaseId { get; set; }
        public string prisonCode { get; set; }
        public string prisonName { get; set; }
        public string prisonerId { get; set; }
        public DateTime? receiveDate { get; set; }
        public DateTime? releaseDate { get; set; }
        public string religious { get; set; }
        public string religiousCode { get; set; }
        public DateTime? sentenceDate { get; set; }
        public string sex { get; set; }
        public string sexCode { get; set; }
        public string undecidedCaseId { get; set; }
    }

}