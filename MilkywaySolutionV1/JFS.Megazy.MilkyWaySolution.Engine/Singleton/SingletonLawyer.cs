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
   public class SingletonLawyer : IDisposable
    {
        private static SingletonLawyer _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public LawyerStatusItem[] LawyerStatusItem { get; set; }
        public LawyerTypeItem[] LawyerTypeItem { get; set; }
        private SingletonLawyer() { }
        public static SingletonLawyer Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonLawyer();
                        _instance.LawyerStatusItem = _instance.GetLawyerStatus();
                        _instance.LawyerTypeItem = _instance.GetLawyerType();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.LawyerStatusItem = _instance.GetLawyerStatus();
                            _instance.LawyerTypeItem = _instance.GetLawyerType();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private LawyerTypeItem[] GetLawyerType()
        {
            LawyerTypeItem[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/lawyertype.json");
                if (!File.Exists(path))
                {
                    res = CreateLawyerTypeFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateLawyerTypeFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<LawyerTypeItem[]>(json);
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
        private LawyerStatusItem[] GetLawyerStatus()
        {
            LawyerStatusItem[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/lawyerstatus.json");
                if (!File.Exists(path))
                {
                    res = CreateLawyerStatusFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateLawyerStatusFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<LawyerStatusItem[]>(json);
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
        private LawyerStatusItem[] CreateLawyerStatusFile(string path)
        {

            LawyerStatusItem[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                LawyerStatusCollection_Base obj = new LawyerStatusCollection_Base(CSystems.ProcessID);
                sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                parameter.Add(sqlParameter);
                string sql = "IsActive = @IsActive";
                LawyerStatusRow[] row = obj.GetAsArray(parameter, sql, "");
                obj.Dispose();
                if (row != null)
                {

                    res = (from q in row
                           select new LawyerStatusItem
                           {
                               LawyerStatusID = q.LawyerStatusID,
                               IsActive = q.IsActive,
                               LawyerStatusName = q.LawyerStatusName
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
        private LawyerTypeItem[] CreateLawyerTypeFile(string path)
        {

            LawyerTypeItem[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                LawyerTypeCollection_Base obj = new LawyerTypeCollection_Base(CSystems.ProcessID);
                sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                parameter.Add(sqlParameter);
                string sql = "IsActive = @IsActive";
                LawyerTypeRow[] row = obj.GetAsArray(parameter, sql, "");
                obj.Dispose();
                if (row != null)
                {

                    res = (from q in row
                           select new LawyerTypeItem
                           {
                               LawyerTypeID = q.LawyerTypeID,
                               IsActive = q.IsActive,
                               LawyerTypeName = q.LawyerTypeName
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
