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
    public class SingletonCourt : IDisposable
    {
        private static SingletonCourt _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public CourtData[] CourtItem { get; set; }
        public CourtLevelData[] CourtLevelItem { get; set; }
        private SingletonCourt() { }
        public static SingletonCourt Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonCourt();
                        _instance.CourtItem = _instance.GetCourt();
                        _instance.CourtLevelItem = _instance.GetCourtLevel();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.CourtItem = _instance.GetCourt();
                            _instance.CourtLevelItem = _instance.GetCourtLevel();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private CourtData[] GetCourt()
        {
            CourtData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/court.json");
                if (!File.Exists(path))
                {
                    res = CourtFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CourtFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            if (!string.IsNullOrWhiteSpace(json))
                            {
                                res = JsonConvert.DeserializeObject<CourtData[]>(json);
                            }
                            else
                            {
                                res = CourtFile(path);
                            }
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
        private CourtLevelData[] GetCourtLevel()
        {
            CourtLevelData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/courtlevel.json");
                if (!File.Exists(path))
                {
                    res = CourtLevelFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CourtLevelFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            if (!string.IsNullOrWhiteSpace(json))
                            {
                                res = JsonConvert.DeserializeObject<CourtLevelData[]>(json);
                            }
                            else
                            {
                                res = CourtLevelFile(path);
                            }
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

        private CourtData[] CourtFile(string path)
        {

            CourtData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                CourtCollection_Base obj = new CourtCollection_Base(CSystems.ProcessID);
                string whereSql = "IsActive=1";
                CourtRow[] row = obj.GetAsArray(parameter, whereSql, "CourtID ASC");
                obj.Dispose();
                if (row != null)
                {

                    res = (from q in row
                           select new CourtData
                           {
                               CourtID = q.CourtID,
                               CourtName = q.CourtName,
                               CourtGroupID = q.CourtGroupID,
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
        private CourtLevelData[] CourtLevelFile(string path)
        {

            CourtLevelData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                CourtLevelCollection_Base obj = new CourtLevelCollection_Base(CSystems.ProcessID);
                CourtLevelRow[] row = obj.GetAll();
                obj.Dispose();
                if (row != null)
                {

                    res = (from q in row
                           select new CourtLevelData
                           {
                               CourtLevelID = q.CourtLevelID,
                               CourtLevelName = q.CourtLevelName
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
