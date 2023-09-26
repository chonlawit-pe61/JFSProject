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
    public class SingletonLocation : IDisposable
    {
        private static SingletonLocation _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public LocationResponse[] LocationItems { get; set; }
        private SingletonLocation() { }
        public static SingletonLocation Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonLocation();
                        _instance.LocationItems = _instance.GetLocation();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.LocationItems = _instance.GetLocation();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private LocationResponse[] GetLocation()
        {
            LocationResponse[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/location.json");
                if (!File.Exists(path))
                {
                    res = CreateFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            if (!string.IsNullOrWhiteSpace(json))
                            {
                                res = JsonConvert.DeserializeObject<LocationResponse[]>(json);
                            }
                            else
                            {
                                res = CreateFile(path);
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
        private LocationResponse[] CreateFile(string path)
        {

            List<string> location = new List<string>();
            LocationResponse[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                PrisonCollection_Base obj = new PrisonCollection_Base(CSystems.ProcessID);
                string whereSql = "IsActive=1";
                PrisonRow[] row = obj.GetAsArray(parameter, whereSql, "PrisonID ASC");                
                obj.Dispose();
                parameter = new List<SqlParameter>();
                DepartmentCollection_Base depart = new DepartmentCollection_Base(CSystems.ProcessID);
                DepartmentRow[] departRow = depart.GetAsArray(parameter, whereSql, "DepartmentID ASC");
                depart.Dispose();
                if (row != null && departRow != null)
                {
                    foreach (var item in departRow)
                    {
                        location.Add(item.ProvinceID != 1 ?"สำนักงานจังหวัด" + item.DepartmentName : item.DepartmentName);
                    }
                    foreach (var item in row)
                    {
                        location.Add(item.PrisonName);
                    }
                    
                    res = (from q in location
                           select new LocationResponse
                           {
                               LocationName = q
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
