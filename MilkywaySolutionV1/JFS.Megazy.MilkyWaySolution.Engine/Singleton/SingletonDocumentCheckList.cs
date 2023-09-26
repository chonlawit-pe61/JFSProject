using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Singleton
{
  public  class SingletonDocumentCheckList : IDisposable
    {
        private static SingletonDocumentCheckList _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public DocumentCheckListResponse[] DocumentItem { get; set; }
        private SingletonDocumentCheckList() { }
        public static SingletonDocumentCheckList Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonDocumentCheckList();
                        _instance.DocumentItem = _instance.GetDocument();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.DocumentItem = _instance.GetDocument();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private DocumentCheckListResponse[] GetDocument()
        {
            DocumentCheckListResponse[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/documentchecklist.json");
                if (!File.Exists(path))
                {
                    res = CreateDocumentFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateDocumentFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            if (!string.IsNullOrWhiteSpace(json))
                            {
                                res = JsonConvert.DeserializeObject<DocumentCheckListResponse[]>(json);
                            }
                            else { res = CreateDocumentFile(path); }
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
     
        private DocumentCheckListResponse[] CreateDocumentFile(string path)
        {

            DocumentCheckListResponse[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                DocumentCheckListGroupCollection_Base obj = new DocumentCheckListGroupCollection_Base(CSystems.ProcessID);
                //sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                //parameter.Add(sqlParameter);
                //string sql = "1 = 1";
                DocumentCheckListGroupRow[] row = obj.GetAll();
                obj.Dispose();
                DocumentCheckListResponse record;
                DocumentChecklistOfProjectCollection_Base documentChecklistOfProject = new DocumentChecklistOfProjectCollection_Base(CSystems.ProcessID);
                ArrayList recordList = new ArrayList();
                foreach (var item in row)
                {
                    record = new DocumentCheckListResponse();
                    record.DocumentGroupID = item.DocumentGroupID;
                    record.DocumentGroupName = item.DocumentGroupName;
                    record.DocumentsList = documentChecklistOfProject.GetByDocumentGroupID(item.DocumentGroupID);

                    recordList.Add(record);
                }

                res = (DocumentCheckListResponse[])(recordList.ToArray(typeof(DocumentCheckListResponse)));

                if (res != null)
                {

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
