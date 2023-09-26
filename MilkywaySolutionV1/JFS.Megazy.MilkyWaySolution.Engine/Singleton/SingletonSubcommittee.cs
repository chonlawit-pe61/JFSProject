using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.MSC;
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
    public class SingletonSubcommittee : IDisposable
    {
        private static SingletonSubcommittee _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public View_SubcommitteeData[] SubcommitteeItem { get; set; }
        private SingletonSubcommittee() { }
        public static SingletonSubcommittee Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonSubcommittee();
                        _instance.SubcommitteeItem = _instance.GetSubcommittee();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.SubcommitteeItem = _instance.GetSubcommittee();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private View_SubcommitteeData[] GetSubcommittee()
        {
            View_SubcommitteeData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/subcommittee.json");
                if (!File.Exists(path))
                {
                    res = SubcommitteeFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = SubcommitteeFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            if (!string.IsNullOrWhiteSpace(json))
                            {
                                res = JsonConvert.DeserializeObject<View_SubcommitteeData[]>(json);
                            }
                            else { 
                                res = SubcommitteeFile(path);
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
        private View_SubcommitteeData[] SubcommitteeFile(string path)
        {

            View_SubcommitteeData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                View_SubcommitteeCollection_Base obj = new View_SubcommitteeCollection_Base(CSystems.ProcessID);     
                string whereSql = "";
                View_SubcommitteeRow[] row = obj.GetAsArray(parameter, whereSql, "SubcommitteeID ASC");

                obj.Dispose();
                if (row != null)
                {
                    res = (from q in row
                           select new View_SubcommitteeData
                           {
                               SubcommitteeID = q.SubcommitteeID,
                               SubcommitteeGroupID = q.SubcommitteeGroupID,
                               SubcommitteeGroupName = q.SubcommitteeGroupName,
                               SubcommitteeName = q.SubcommitteeName,
                               AppointmentNo = q.AppointmentNo,
                               IsHeadquarter = q.IsHeadquarter,
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
