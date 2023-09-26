using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Linkage
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<PersonalData>(myJsonResponse); 
    public class NameTH
    {
        public string title { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }

    }

    public class NameEN
    {
        public string title { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }

    }

    public class Address
    {
        public string houseNo { get; set; }
        public int villageNo { get; set; }
        public string alleyWayDesc { get; set; }
        public string alleyDesc { get; set; }
        public string roadDesc { get; set; }
        public string subdistrictDesc { get; set; }
        public string districtDesc { get; set; }
        public string provinceDesc { get; set; }

    }

    public class PersonalData
    {
        public string documentNumber { get; set; }
        public long personalID { get; set; }
        public NameTH nameTH { get; set; }
        public NameEN nameEN { get; set; }
        public Address address { get; set; }
        public string blood { get; set; }
        public int birthDate { get; set; }
        public string religion { get; set; }
        public string religionOther { get; set; }
        public string sex { get; set; }
        public string cancelCause { get; set; }
        public int issueDate { get; set; }
        public int issueTime { get; set; }
        public string foreignCountry { get; set; }
        public string foreignCountryCity { get; set; }
        public string expireDate { get; set; }

    }


}
