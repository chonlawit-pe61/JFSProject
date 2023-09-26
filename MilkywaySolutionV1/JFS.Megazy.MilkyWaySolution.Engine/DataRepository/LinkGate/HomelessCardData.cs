using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.LinkGate
{
    public class HomelessCardData
    {
        public ContentHomelessCard content { get; set; }
    }
    public class ContentHomelessCard
    {
        public AddressHomelessCard address { get; set; }
        public DateTime? cardExpireDate { get; set; }
        public DateTime? cardIssueDate { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string genderText { get; set; }
        public int nationalityCode { get; set; }
        public string nationalityText { get; set; }
    }
    public class AddressHomelessCard
    {
        public string houseAlley { get; set; }
        public string houseAlleyWay { get; set; }
        public string houseDistrict { get; set; }
        public string houseNo { get; set; }
        public string houseProvince { get; set; }
        public string houseRoad { get; set; }
        public string houseSubDistrict { get; set; }
        public int houseVillageNo { get; set; }
       
    }
}
