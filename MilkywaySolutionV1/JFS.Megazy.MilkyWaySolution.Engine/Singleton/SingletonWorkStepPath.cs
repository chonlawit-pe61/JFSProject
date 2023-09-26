using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Singleton
{
    public class SingletonWorkStepPath : IDisposable
    {
        private static SingletonWorkStepPath _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public View_WorkStepPathData[] WorkStepDataPath { get; set; }
        private SingletonWorkStepPath() { }
        public static SingletonWorkStepPath Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonWorkStepPath();
                        _instance.WorkStepDataPath = _instance.GetWorkStepPath();
                        _instance.lastDate = _instance.lastDate.AddMinutes(10);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.WorkStepDataPath = _instance.GetWorkStepPath();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        public View_WorkStepPathData[] GetStepPath(bool isAppeal, int finalApprovedID)
        {
            var r = (from q in Instance.GetWorkStepPath()
                     where q.IsAppeal == isAppeal  && q.FinalApprovedID <= finalApprovedID
                     select q).ToArray();
            return r;

        }

        private View_WorkStepPathData[] GetWorkStepPath()
        {
            View_WorkStepPathData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/worksteppath.json");
                if (!File.Exists(path))
                {
                    res = CreateWorkStepDataPathFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateWorkStepDataPathFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<View_WorkStepPathData[]>(json);
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

        private View_WorkStepPathData[] CreateWorkStepDataPathFile(string path)
        {

            View_WorkStepPathData[] res = null;
            try
            {

                View_WorkStepPathCollection_Base obj = new View_WorkStepPathCollection_Base(CSystems.ProcessID);
                View_WorkStepPathRow[] row = obj.GetAll();
                obj.Dispose();

                if (row.Length > 0)
                {

                    res = (from q in row
                           select new View_WorkStepPathData
                           {
                               WorkStepID = q.WorkStepID,
                               WorkStepName = q.WorkStepName,
                               FinalApprovedID = q.FinalApprovedID,
                               IsAppeal = q.IsAppeal,
                               SortOrder = q.SortOrder,
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
