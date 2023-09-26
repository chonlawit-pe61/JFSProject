﻿using JFS.Megazy.MilkyWaySolution.Engine.Dal;
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
    public class SingletonFinalApprove
    {
        private static SingletonFinalApprove _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public FinalApproveData[] FinalApproveItem { get; set; }
        private SingletonFinalApprove() { }
        public static SingletonFinalApprove Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonFinalApprove();
                        _instance.FinalApproveItem = _instance.GetFinalApprove();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.FinalApproveItem = _instance.GetFinalApprove();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private FinalApproveData[] GetFinalApprove()
        {
            FinalApproveData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/finalapprove.json");
                if (!File.Exists(path))
                {
                    res = FinalApproveFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = FinalApproveFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            if (!string.IsNullOrWhiteSpace(json))
                            {
                                res = JsonConvert.DeserializeObject<FinalApproveData[]>(json);
                            }
                            else
                            {
                                res = FinalApproveFile(path);
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
        private FinalApproveData[] FinalApproveFile(string path)
        {

            FinalApproveData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                FinalApproveCollection_Base obj = new FinalApproveCollection_Base(CSystems.ProcessID);
                string whereSql = "";
                FinalApproveRow[] row = obj.GetAsArray(parameter, whereSql, "");

                obj.Dispose();
                if (row != null)
                {
                    res = (from q in row
                           select new FinalApproveData
                           {
                              OfficerRoleID = q.OfficerRoleID,
                              FinalApproveName = q.FinalApproveName,
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
