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
  public  class SingletonComplaintChannel : IDisposable
    {
        private static SingletonComplaintChannel _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public ComplaintChannel[] ComplaintChannelItem { get; set; }
        private SingletonComplaintChannel() { }
        public static SingletonComplaintChannel Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonComplaintChannel();
                        _instance.ComplaintChannelItem = _instance.GetComplaintChannel();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.ComplaintChannelItem = _instance.GetComplaintChannel();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private ComplaintChannel[] GetComplaintChannelByCase()
        {
            ComplaintChannel[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/complainchannelbycase.json");
                if (!File.Exists(path))
                {
                    res = CreateComplaintChannelByCaseFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateComplaintChannelByCaseFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<ComplaintChannel[]>(json);
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
     
        private ComplaintChannel[] CreateComplaintChannelByCaseFile(string path)
        {

            ComplaintChannel[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                View_ComplaintChannelCollection_Base obj = new View_ComplaintChannelCollection_Base(CSystems.ProcessID);
                sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                parameter.Add(sqlParameter);
                string sql = "IsActive = @IsActive";
                View_ComplaintChannelRow[] row = obj.GetAsArray(parameter, sql, "SortOrder ASC");
                obj.Dispose();
                if (row != null)
                {

                    res = (from q in row
                           select new ComplaintChannel
                           {
                               ChannelID = q.ChannelID,
                               ChannelName = q.ChannelName,
                               JFCaseType = q.JFCaseTypeID
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

        private ComplaintChannel[] GetComplaintChannel()
        {
            ComplaintChannel[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/complainchannel.json");
                if (!File.Exists(path))
                {
                    res = CreateComplaintChannelFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateComplaintChannelFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<ComplaintChannel[]>(json);
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

        private ComplaintChannel[] CreateComplaintChannelFile(string path)
        {

            ComplaintChannel[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                ComplaintChannelCollection_Base obj = new ComplaintChannelCollection_Base(CSystems.ProcessID);
                sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                parameter.Add(sqlParameter);
                string sql = "IsActive = @IsActive";
                ComplaintChannelRow[] row = obj.GetAsArray(parameter, sql, "SortOrder ASC");
                obj.Dispose();
                if (row != null)
                {

                    res = (from q in row
                           select new ComplaintChannel
                           {
                               ChannelID = q.ChannelID,
                               ChannelName = q.ChannelName
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
        public List<ComplaintChannel> GetByJFCaseType(int id)
        {
            var r = (from q in Instance.GetComplaintChannelByCase()
                     where q.JFCaseType == id
                     select q).ToList();
            return r;
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
