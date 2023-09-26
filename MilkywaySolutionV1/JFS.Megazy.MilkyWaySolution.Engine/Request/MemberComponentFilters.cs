using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Request
{
    public class MemberComponentFilters : ComponentFilters
    {
        public LocationFillters Location { get; set; }
        public string MemberType { get; set; }
        public string ProvinceID { get; set; }
        public string Status { get; set; }
    }
}

