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
    /// <summary>
    /// อ่านไฟล์สถานะเช็ค แบบไม่กำหนดอายุไฟล์ ยกเว้นสั่งให้ Reset
    /// </summary>
    public class SingletonChequeStatus : IDisposable
    {
        private static SingletonChequeStatus _instance = null;
        private static readonly object _syncLock = new object();
        public ChequeStatusData[] ChequeStatusItem { get; set; }
        private SingletonChequeStatus() { }
        public static SingletonChequeStatus Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonChequeStatus();
                        _instance.ChequeStatusItem = _instance.GetChequeStatus();
                    }
                }
                return _instance;
            }
        }
        private ChequeStatusData[] GetChequeStatus(bool reset = false)
        {
            ChequeStatusData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/chequestatus.json");
                if (!File.Exists(path) || reset)
                {
                    res = CreateChequeStatusFile(path);
                }
                else
                {
                    using (StreamReader r = new StreamReader(path))
                    {
                        string json = r.ReadToEnd();
                        if (!string.IsNullOrWhiteSpace(json))
                        {
                            res = JsonConvert.DeserializeObject<ChequeStatusData[]>(json);
                        }
                        else { res = CreateChequeStatusFile(path); }
                    }
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }

            return res;
        }
       
        private ChequeStatusData[] CreateChequeStatusFile(string path)
        {
            ChequeStatusData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                ChequeStatusCollection_Base obj = new ChequeStatusCollection_Base(CSystems.ProcessID);     
                string sql = "";
                ChequeStatusRow[] row = obj.GetAsArray(parameter, sql, "SortOrder ASC");
                obj.Dispose();
                if (row != null)
                {
                    res = (from q in row
                           select new ChequeStatusData
                           {
                                ChequeStatusCode = q.ChequeStatusCode,
                               ChequeStatusName = q.ChequeStatusName,
                               SortOrder = q.SortOrder
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
