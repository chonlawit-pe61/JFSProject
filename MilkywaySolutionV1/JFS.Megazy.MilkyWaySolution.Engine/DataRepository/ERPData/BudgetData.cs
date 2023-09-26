using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.ERPData
{
    public class BudgetDataResult : ApiResult
    {
        public BudgetData Result { get; set; }
    }
    public class Budget
    {
        public string BdgListID { get; set; }
        public string BdgListName { get; set; }
    }

    public class BudgetData
    {
        public string Status { get; set; }
        public List<Budget> Result { get; set; }
        public int TotalRow { get; set; }
    }
}
