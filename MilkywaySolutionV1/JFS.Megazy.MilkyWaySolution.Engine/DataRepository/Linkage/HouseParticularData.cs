using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Linkage
{
    public class HouseParticularData
    {
        public long houseID { get; set; }
        public string houseNo { get; set; }
        public int houseType { get; set; }
        public string houseTypeDesc { get; set; }
        public int villageNo { get; set; }
        public int alleyWayCode { get; set; }
        public object alleyWayDesc { get; set; }
        public int alleyCode { get; set; }
        public object alleyDesc { get; set; }
        public int roadCode { get; set; }
        public object roadDesc { get; set; }
        public int subdistrictCode { get; set; }
        public string subdistrictDesc { get; set; }
        public int districtCode { get; set; }
        public string districtDesc { get; set; }
        public int provinceCode { get; set; }
        public string provinceDesc { get; set; }
        public string rcodeCode { get; set; }
        public string rcodeDesc { get; set; }
        public int dateOfTerminate { get; set; }
    }
}
