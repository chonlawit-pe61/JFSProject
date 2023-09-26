using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.LinkGate
{
    public class CardData
    {
        public ContentCard content { get; set; }
    }
    public class ContentCard
    {
        public AddressCardCreate address { get; set; }
        public NameData nameTH { get; set; }
        public NameData nameEN { get; set; }
        public DateTime? birthDate { get; set; }
        public string blood { get; set; }
        public string cancelCause { get; set; }
        public string documentNumber { get; set; }
        public DateTime? expireDate { get; set; }
        public string foreignCountry { get; set; }
        public string foreignCountryCity { get; set; }
        public string religion { get; set; }
        public string religionOther { get; set; }
        public string sex { get; set; }
        public DateTime? issueDate { get; set; }
        public DateTime? issueTime { get; set; }
    }
    public class AddressCardCreate
    {
        public string alleyDesc { get; set; }
        public string alleyWayDesc { get; set; }
        public string districtDesc { get; set; }
        public string houseNo { get; set; }
        public string provinceDesc { get; set; }
        public string roadDesc { get; set; }
        public string subdistrictDesc { get; set; }
        public int villageNo { get; set; }

    }
   
   
}
