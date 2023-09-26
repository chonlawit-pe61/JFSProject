using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
   public  class CaseCategory
    {
        public int CaseCategoryID { get; set; }
        public string CaseCategoryName { get; set; }
        public int ChildCount { get; set; }

    }
}
