using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{



  public  class LawyerStatusItem
    {
        public int LawyerStatusID { get; set; }
        public string LawyerStatusName { get; set; }
        public bool  IsActive { get; set; }
    }
    public class LawyerTypeItem
    {
        public int LawyerTypeID { get; set; }
        public string LawyerTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
