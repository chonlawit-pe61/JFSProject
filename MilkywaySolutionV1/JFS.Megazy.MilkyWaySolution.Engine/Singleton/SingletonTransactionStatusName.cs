using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JFS.Megazy.MilkyWaySolution.Engine.Singleton
{
    public class SingletonTransactionStatusName : IDisposable
    {
        private static SingletonTransactionStatusName _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public TransactionStatusData[] TransactionStatusNameItem { get; set; }
        private SingletonTransactionStatusName() { }
        public static SingletonTransactionStatusName Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonTransactionStatusName();
                        _instance.TransactionStatusNameItem = _instance.GetTransactionStatusName();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.TransactionStatusNameItem = _instance.GetTransactionStatusName();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private TransactionStatusData[] GetTransactionStatusName()
        {
            TransactionStatusData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/transactionstatusname.json");
                if (!File.Exists(path))
                {
                    res = CreateTransactionStatusNameFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateTransactionStatusNameFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            if (!string.IsNullOrWhiteSpace(json))
                            {
                                res = JsonConvert.DeserializeObject<TransactionStatusData[]>(json);
                            }
                            else { res = CreateTransactionStatusNameFile(path); }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }

            return res;
        }       
        private TransactionStatusData[] CreateTransactionStatusNameFile(string path)
        {

            TransactionStatusData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                TransactionStatusCollection_Base obj = new TransactionStatusCollection_Base(CSystems.ProcessID);
                
                //string sql = "GroupCode='CASE'";
                string sql = "";
                TransactionStatusRow[] row = obj.GetAsArray(new List<SqlParameter>(), sql, "");
                obj.Dispose();
                if (row != null)
                {
                    res = (from q in row
                           select new TransactionStatusData
                           {
                               TransactionStatusID = q.TransactionStatusID,
                               TransactionStatusName = q.TransactionStatusName,
                           }).ToArray();
                    string jsonString = JsonConvert.SerializeObject(res);
                    File.WriteAllText(path, jsonString);
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return res;
        }

        public void Reset()
        {
            _instance.Dispose(true);
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
        // ~SingletonLawyer()
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
