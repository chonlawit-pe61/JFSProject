using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class MatterDataResponse
    {
       // public ProvinceResponse Province { get; set; }
        public IEnumerable<MatterResponse> Matter { get; set; }
        
    }
    public class MatterResponse : MatterData
    {
        public int ProcudureID { get; set; }
        public string ProcedureName { get; set; }
        public IEnumerable<BracketData> Bracket { get; set; }
    }
}
