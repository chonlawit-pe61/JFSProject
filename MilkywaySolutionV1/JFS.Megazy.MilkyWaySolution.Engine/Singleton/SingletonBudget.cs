using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.Singleton
{
   public class SingletonBudget : IDisposable   
    {

        private static SingletonBudget _instance = null;
        private static readonly object _syncLock = new object();
        public DateTime LastDate { get; set; } = DateTime.Now;
        public BudgetData[] BudgetRow { get; set; }
        public FinanceBudgetData[] FinanceBudgetRow { get; set; }
        private SingletonBudget() { }
        public static SingletonBudget Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonBudget();
                        _instance.BudgetRow = _instance.GetAll();
                        _instance.FinanceBudgetRow = _instance.GetFinanceBudgetAll();
                        _instance.LastDate = _instance.LastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.LastDate).Minutes >= 30)
                        {
                            _instance.BudgetRow = _instance.GetAll();
                            _instance.FinanceBudgetRow = _instance.GetFinanceBudgetAll();
                            _instance.LastDate = _instance.LastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        public void Reset()
        {
            _instance.Dispose(true);
        }

        private BudgetData[] GetAll()
        {
            BudgetData[] res = null;
            BudgetCollection_Base obj = new BudgetCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>
            {
                new SqlParameter("@IsActive", SqlDbType.Bit){ Value =1 }
            };
            string whereSql = "[IsActive] = @IsActive";
            string orderbySql = "[BudgetID] ASC";
            var row = obj.GetAsArray(parameter, whereSql, orderbySql);
            obj.Dispose();
            if (row.Length != 0)
            {
                res = (from q in row select new BudgetData { BudgetID = q.BudgetID, BudgetName = q.BudgetName, Description = q.Description }).ToArray();
            }
            return res;
        } private FinanceBudgetData[] GetFinanceBudgetAll()
        {
            FinanceBudgetData[] res = null;
            FinanceBudgetCollection_Base obj = new FinanceBudgetCollection_Base(CSystems.ProcessID);
            var row = obj.GetAll();
            obj.Dispose();
            if (row.Length != 0)
            {
                res = (from q in row select new FinanceBudgetData { BudgetID = q.BudgetID, BudgetName = q.BudgetName}).ToArray();
            }
            return res;
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                      _instance = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SingletonProvince()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
