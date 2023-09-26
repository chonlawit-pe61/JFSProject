using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Linkage
{
   public class CitizenRegistrationDataResponse
    {
        public CivilRegistrationData civilRegistration { get; set; } 
        public PersonalData personal { get; set; }
        public PersonalImageData personalImage { get; set; }
        public HouseParticularData houseParticular { get; set; }
    }

    public class PersonalInspectDataResponse
    {
        public int InspectID { get; set; }
        public string InspectValue { get; set; }
        public string InspectName { get; set; }
    }
}
