using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class TransactionDataResponse
    {
       public TransactionRow Transaction { get; set; }
       public TransactionDetailRow[] TransactionDetail { get; set; }

    }
    public class TransactionDatailResponse 
    {
        public double TotalAmountInContract { get; set; }
        public View_TransactionRow ViewTransaction { get; set; }
        //public TransactionDetailRow[] TransactionDetail { get; set; }
        public View_ApplicationRow Application { get; set; }
       public View_LawyerAddressRow LawyerAddress { get; set; }
      // public CurrentCaseStatusRow CurrentCaseStatus { get; set; }
     public View_CurrentCaseStatusRow CurrentCaseStatus { get; set; }

    }
}
