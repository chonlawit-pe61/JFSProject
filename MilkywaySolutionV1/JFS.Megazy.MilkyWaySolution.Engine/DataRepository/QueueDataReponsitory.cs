using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class QueueData
    {
        public int StampChange { get; set; }
        public int QueueVersionID { get; set; }
        public int LawyerID { get; set; }
        public int Priority { get; set; }
        public DateTime StampTime { get; set; }

    }

   

    
}
