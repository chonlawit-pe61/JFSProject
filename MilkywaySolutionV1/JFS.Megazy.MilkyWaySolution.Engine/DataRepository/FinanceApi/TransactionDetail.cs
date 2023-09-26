using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FinanceApi
{
    public class TransactionDetail
    {
        public int TransactionDetailID { get; set; }
        public int BdgListID { get; set; }
        public string BdgList { get; set; }
        public string Note { get; set; }
        public double Amount { get; set; } 
    }
}
