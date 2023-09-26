using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Request
{
    public class LawyerComponentFilters : ComponentFilters
    {
        public LocationFillters Location { get; set; }
        public string LawyerTypeID { get; set; }
        public string LawyerStatusID { get; set; }
        public string LawyerID { get; set; }
        public string LawyerYear { get; set; }
        public string TerritoryProvineID { get; set; }
    }
}