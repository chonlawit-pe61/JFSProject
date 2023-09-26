using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace JFS.Megazy.MilkyWaySolution.Engine.Singleton
{
    public  class SingletonAddressType : IDisposable
    {
        private static SingletonAddressType _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public AddressTypeData[] AddressTypeForCase { get; set; }
        public AddressTypeData[] AddressTypeForOther { get; set; }
        private SingletonAddressType() { }
        public static SingletonAddressType Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonAddressType();
                        _instance.AddressTypeForCase = _instance.GetAddressType("CASE");
                        _instance.AddressTypeForOther = _instance.GetAddressType("NORMAL");
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.AddressTypeForCase = _instance.GetAddressType("CASE");
                            _instance.AddressTypeForOther = _instance.GetAddressType("NORMAL");
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private AddressTypeData[] GetAddressType(string groupName)
        {
            AddressTypeData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/addresstype.json");
                if (!File.Exists(path))
                {
                    res = CreateAddressTypeFile(path).Where(o=>o.AddressGroup == groupName).ToArray();
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateAddressTypeFile(path).Where(o => o.AddressGroup == groupName).ToArray();
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<AddressTypeData[]>(json).Where(o => o.AddressGroup == groupName).ToArray();
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

        private AddressTypeData[] CreateAddressTypeFile(string path)
        {

            AddressTypeData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                AddressTypeCollection_Base obj = new AddressTypeCollection_Base(CSystems.ProcessID);
                sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                parameter.Add(sqlParameter);
                string sql = "IsActive= @IsActive";
                AddressTypeRow[] row = obj.GetAsArray(parameter, sql, "AddressTypeID ASC");
                obj.Dispose();
                if (row != null)
                {

                    res = (from q in row
                           select new AddressTypeData
                           {
                               AddressGroup = q.AddressGroup,
                               AddressTypeID = q.AddressTypeID,
                               TypeName = q.TypeName
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
