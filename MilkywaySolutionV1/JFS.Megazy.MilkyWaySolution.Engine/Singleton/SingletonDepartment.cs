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
    public class SingletonDepartment : IDisposable
    {
        private static SingletonDepartment _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public DepartmentData[] DepartmentItem { get; set; }
        private SingletonDepartment() { }
        public static SingletonDepartment Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonDepartment();
                        _instance.DepartmentItem = _instance.GetDepartment();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.DepartmentItem = _instance.GetDepartment();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private DepartmentData[] GetDepartment()
        {
            DepartmentData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/department.json");
                if (!File.Exists(path))
                {
                    res = CreateDepartmentFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateDepartmentFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<DepartmentData[]>(json);
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

        private DepartmentData[] CreateDepartmentFile(string path)
        {

            DepartmentData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                DepartmentCollection_Base obj = new DepartmentCollection_Base(CSystems.ProcessID);
                sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                parameter.Add(sqlParameter);
                string sql = "IsActive = @IsActive";
                DepartmentRow[] row = obj.GetAsArray(parameter, sql, "DepartmentID ASC");
                obj.Dispose();
                if (row != null)
                {

                    res = (from q in row
                           select new DepartmentData
                           {
                               DepartmentID = q.DepartmentID,
                               DepartmentName = q.DepartmentName,
                               DepartmentCode = q.DepartmentCode,
                               DepartmentNameAbbr = q.DepartmentNameAbbr,
                               ProvinceID = q.ProvinceID
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
