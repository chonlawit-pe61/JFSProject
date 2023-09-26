using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class TransactionRefundRespon
    {
        public TransactionData Transaction { get; set; }
        public TrackingRefundData TrackingRefund { get; set; }
        public List<TransactionDetailData> TransactionDetail { get; set; }
    }
}
