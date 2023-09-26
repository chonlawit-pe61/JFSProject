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
  public  class SingletonOfficerMapOpinion : IDisposable
    {
        private static SingletonOfficerMapOpinion _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public View_OfficerMapOpinionData[] OfficerMapOpinion { get; set; }
        private SingletonOfficerMapOpinion() { }
        public static SingletonOfficerMapOpinion Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonOfficerMapOpinion();
                        _instance.OfficerMapOpinion = _instance.GetOfficerMapOpinion();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.OfficerMapOpinion = _instance.GetOfficerMapOpinion();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private View_OfficerMapOpinionData[] GetOfficerMapOpinion()
        {
            View_OfficerMapOpinionData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/officermapopinion.json");
                if (!File.Exists(path))
                {
                    res = CreateOfficerMapOpinionDataeFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateOfficerMapOpinionDataeFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<View_OfficerMapOpinionData[]>(json);
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
     
        private View_OfficerMapOpinionData[] CreateOfficerMapOpinionDataeFile(string path)
        {

            View_OfficerMapOpinionData[] res = null;
            try
            {

                View_OfficerMapOpinionCollection_Base obj = new View_OfficerMapOpinionCollection_Base(CSystems.ProcessID);
                View_OfficerMapOpinionRow[] row = obj.GetAsArray(new List<SqlParameter>(), "IsActive=1", "SortOrder ASC");
                    obj.Dispose();

                    if (row.Length > 0)
                    {

                        res = (from q in row
                               select new View_OfficerMapOpinionData
                               {
                                   OfficerRoleID = q.OfficerRoleID,
                                   OpinionName = q.OpinionName,
                                   OpinionID = q.OpinionID,
                                   SortOrder = q.SortOrder,
                                   IsPay = q.IsPay,
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
