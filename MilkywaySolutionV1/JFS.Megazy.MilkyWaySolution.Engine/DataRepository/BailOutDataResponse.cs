using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class BailOutDataResponse
    {
        public int BailOutLevelID { get; set; }
        public string BailOutLevelName { get; set; }
        public BailData[] DataList { get; set; }
    }
    public class BailData    {
        public int BailID { get; set; }
        public string BailAt { get; set; }
    }
}
