using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.MSC
{
    public class ProvinceDataResponse
    {
        public string provId { get; set; }
        public string provName { get; set; }
        public List<AmpherDataResponse> arrAmp { get; set; }

    }
    public class AmpherDataResponse
    {
        public string ampId { get; set; }
        public string ampName { get; set; }
        public List<Tamboon> tamboon { get; set; }
    }

    public class Tamboon
    {
        public string tamId { get; set; }
        public string tamName { get; set; }
    }
}
