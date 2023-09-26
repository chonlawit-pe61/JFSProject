using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class ExpensData
    {
        public string ExpenseID { get; set; }
        public string ExpenseName { get; set; }
        public string JFCaseTypeID { get; set; }
        public string IsOther { get; set; }
        public string SortOrder { get; set; }
    }

    //public class ExpensListAndAmont
    //{
    //    public ExpenseRow[] ExpenseList { get; set; }
    //    public float[] Amont { get; set; }

    // }
    //public class ExpensListAndAmontRespon : ExpensListAndAmont
    //{
    //    public float MyProperty { get; set; }
    //}

    public class ExpensRequestData
    {
        public List<CaseExpenseExtensionData> ExpenseEx { get; set; }
        public List<CaseExpenseData> Expense { get; set; }

    }
    public class AmountApprovedData
    {
        public int ApprovedID { get; set; }
        public double PreTotalAmount { get; set; }
        public double TotalAmount { get; set; }
        public string Remark { get; set; }
        public int OfficerRoleID { get; set; }
        public int BudgetID { get; set; }
    }
}
