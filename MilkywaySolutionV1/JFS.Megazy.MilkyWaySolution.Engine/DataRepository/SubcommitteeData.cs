using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
  public  abstract class SubcommitteeData
    {
        public int SubcommiteeID { get; set; }
        public int SubcommitteeGroupID { get; set; }
        public string SubcommitteeGroupName { get; set; }
        public string SubcommitteeName { get; set; }
        public string AppointmentNo { get; set; }
        public string ChairmanTitle { get; set; }
        public string ChairmanFirstName { get; set; }
        public string ChairmanLastName { get; set; }
        public string ChairmanPosition{ get; set; }

    }
    public class SubcommitteeDataResponse : SubcommitteeData
    { 
    
    }
}
