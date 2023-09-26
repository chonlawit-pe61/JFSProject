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
  public  class SingletonProject : IDisposable
    {
        private static SingletonProject _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public ProposerTypeData[] ProposerTypeItem { get; set; } 
        public CharacteristicsOfProjectData[] CharacteristicsOfProjectItem { get; set; }
        private SingletonProject() { }
        public static SingletonProject Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonProject();
                        _instance.ProposerTypeItem = _instance.GetProposerType();
                        _instance.CharacteristicsOfProjectItem = _instance.GetCharacteristicsOfProject();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.ProposerTypeItem = _instance.GetProposerType();
                            _instance.CharacteristicsOfProjectItem = _instance.GetCharacteristicsOfProject();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private ProposerTypeData[] GetProposerType()
        {
            ProposerTypeData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/proposertype.json");
                if (!File.Exists(path))
                {
                    res = CreateProposerTypeFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateProposerTypeFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<ProposerTypeData[]>(json);
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
     
        private ProposerTypeData[] CreateProposerTypeFile(string path)
        {

            ProposerTypeData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                ProposerTypeCollection_Base obj = new ProposerTypeCollection_Base(CSystems.ProcessID);
                //sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                //parameter.Add(sqlParameter);
                //string sql = "IsActive = @IsActive";
                ProposerTypeRow[] row = obj.GetAll();
                obj.Dispose();
                if (row != null)
                {
                    res = (from q in row
                           select new ProposerTypeData
                           {
                               ProposerTypeID = q.ProposerTypeID,
                               ProposerTypeName = q.ProposerTypeName
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
        private CharacteristicsOfProjectData[] GetCharacteristicsOfProject()
        {
            CharacteristicsOfProjectData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/characteristicsofproject.json");
                if (!File.Exists(path))
                {
                    res = CreateCharacteristicsOfProjectFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateCharacteristicsOfProjectFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<CharacteristicsOfProjectData[]>(json);
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

        private CharacteristicsOfProjectData[] CreateCharacteristicsOfProjectFile(string path)
        {

            CharacteristicsOfProjectData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                CharacteristicsOfProjectCollection_Base obj = new CharacteristicsOfProjectCollection_Base(CSystems.ProcessID);
                sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                parameter.Add(sqlParameter);
                string sql = "IsActive = @IsActive";
                CharacteristicsOfProjectRow[] row = obj.GetAsArray(parameter,sql, "CharacteristicID ASC");
                obj.Dispose();
                if (row != null)
                {
                    res = (from q in row
                           select new CharacteristicsOfProjectData
                           {
                                CharacteristicID = q.CharacteristicID,
                                Characteristic = q.Characteristic
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
