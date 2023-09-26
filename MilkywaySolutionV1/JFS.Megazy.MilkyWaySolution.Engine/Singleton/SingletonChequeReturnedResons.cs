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
    /// อ่านไฟล์เหตุผลการยกเลิกใช้เช็ค แบบไม่กำหนดอายุไฟล์ ยกเว้นสั่งให้ Reset
    /// </summary>
    public class SingletonChequeReturnedResons : IDisposable
    {
        private static SingletonChequeReturnedResons _instance = null;
        private static readonly object _syncLock = new object();
        public ChequeReturnedResonsData[] ChequeReturnedResonsItem { get; set; }
        private SingletonChequeReturnedResons() { }
        public static SingletonChequeReturnedResons Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonChequeReturnedResons();
                        _instance.ChequeReturnedResonsItem = _instance.GetChequeReturnedResons();
                    }
                }
                return _instance;
            }
        }
        private ChequeReturnedResonsData[] GetChequeReturnedResons(bool reset = false)
        {
            ChequeReturnedResonsData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/chequereturnedresons.json");
                if (!File.Exists(path) || reset)
                {
                    res = CreateChequeReturnedResonsFile(path);
                }
                else
                {
                    using (StreamReader r = new StreamReader(path))
                    {
                        string json = r.ReadToEnd();
                        if (!string.IsNullOrWhiteSpace(json))
                        {
                            res = JsonConvert.DeserializeObject<ChequeReturnedResonsData[]>(json);
                        }
                        else { res = CreateChequeReturnedResonsFile(path); }
                    }
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }

            return res;
        }
       
        private ChequeReturnedResonsData[] CreateChequeReturnedResonsFile(string path)
        {
            ChequeReturnedResonsData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                ChequeReturnedResonsCollection_Base obj = new ChequeReturnedResonsCollection_Base(CSystems.ProcessID);     
                string sql = "IsActive = 1";
                ChequeReturnedResonsRow[] row = obj.GetAsArray(parameter, sql, "");
                obj.Dispose();
                if (row != null)
                {
                    res = (from q in row
                           select new ChequeReturnedResonsData
                           {
                               ChequeReturnedResonsCode = q.ChequeReturnedResonsCode,
                               ChequeReturnedResonsName = q.ChequeReturnedResonsName,
                               RetureType = q.RetureType,
                               IsActive = q.IsActive
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
