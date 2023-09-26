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
  public  class SingletonBailOut : IDisposable
    {
        private static SingletonBailOut _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public BailOutDataResponse[] BailOutItem { get; set; }
        private SingletonBailOut() { }
        public static SingletonBailOut Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonBailOut();
                        _instance.BailOutItem = _instance.GetBailOut();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.BailOutItem = _instance.GetBailOut();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private BailOutDataResponse[] GetBailOut()
        {
            BailOutDataResponse[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/jfbailout.json");
                if (!File.Exists(path))
                {
                    res = CreateBailOutFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateBailOutFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            if (!string.IsNullOrWhiteSpace(json))
                            {
                                res = JsonConvert.DeserializeObject<BailOutDataResponse[]>(json);
                            }
                            else { res = CreateBailOutFile(path); }
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

        //private BailOutData[] CreateBailOutFile(string path)
        //{

        //    BailOutData[] res = null;
        //    try
        //    {
        //        List<SqlParameter> parameter = new List<SqlParameter>();
        //        SqlParameter sqlParameter = new SqlParameter();
        //        BailOutCollection_Base obj = new BailOutCollection_Base(CSystems.ProcessID);
        //        BailOutRow[] row = obj.GetAll();
        //        obj.Dispose();
        //        if (row != null)
        //        {

        //            res = (from q in row
        //                   select new BailOutData
        //                   {
        //                       BailAt = q.BailAt,
        //                       BailID = q.BailID,
        //                   }).ToArray();

        //            string jsonString = JsonConvert.SerializeObject(res);
        //            File.WriteAllText(path, jsonString);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
        //    }
        //    return res;
        //}
        private BailOutDataResponse[] CreateBailOutFile(string path)
        {
            BailOutDataResponse[] res = null;
            try
            {
                View_BailOutCollection_Base bailoutBase = new View_BailOutCollection_Base(CSystems.ProcessID);
                var bailoutRow = bailoutBase.GetAll();
                bailoutBase.Dispose();
                res = (from t in bailoutRow
                       group t by new
                       {
                           t.BailOutLevelID,
                           t.BailOutLevelName
                       }
                         into grp
                       select new BailOutDataResponse
                       {
                           BailOutLevelID = grp.Key.BailOutLevelID,
                           BailOutLevelName = grp.Key.BailOutLevelName,
                           DataList = grp.Select(x => new BailData { BailID = x.BailID, BailAt = x.BailAt }).ToArray()
                       }).ToArray();

                string jsonString = JsonConvert.SerializeObject(res);
                File.WriteAllText(path, jsonString);

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
