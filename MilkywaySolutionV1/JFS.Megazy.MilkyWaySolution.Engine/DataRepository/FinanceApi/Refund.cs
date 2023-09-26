using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FinanceApi
{
    public class Refund
    {
        public int TrakingRefundID { get; set; }
        public int RefundStatusID { get; set; }
        //public string Description { get; set; }
        //public double Amount { get; set; }
        public double ReceivedAmount { get; set; }
        public string ReceivedDate { get; set; }
    }
}
