using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.Singleton
{
   public class SingletonInspect : IDisposable   
    {

        private static SingletonInspect _instance = null;
        private static readonly object _syncLock = new object();
        public DateTime LastDate { get; set; } = DateTime.Now;
        public View_InspectData[] InspectDataRow { get; set; }
        public InspectValueListData[] InspectValueListDataRow { get; set; }
        private SingletonInspect() { }
        public static SingletonInspect Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonInspect();
                        _instance.InspectDataRow = _instance.GetAll();
                        _instance.InspectValueListDataRow = _instance.GetAllValueList();
                        _instance.LastDate = _instance.LastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.LastDate).Minutes >= 30)
                        {
                            _instance.InspectDataRow = _instance.GetAll();
                            _instance.InspectValueListDataRow = _instance.GetAllValueList();
                            _instance.LastDate = _instance.LastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        public void Reset()
        {
            _instance.Dispose(true);
        }

        private View_InspectData[] GetAll()
        {
            View_InspectData[] res = null;
            View_InspectCollection_Base obj = new View_InspectCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>
            {
                new SqlParameter("@IsActive", SqlDbType.Bit){ Value =1 }
            };
            string whereSql = "[IsActive] = @IsActive";
            string orderbySql = "[SortOrder] ASC";
            var row = obj.GetAsArray(parameter, whereSql, orderbySql);
            obj.Dispose();
            if (row.Length != 0)
            {
                res = (from q in row
                       select new View_InspectData
                       {
                           InspectID = q.InspectID,
                           InspectName = q.InspectName,
                           IsThaiCitizen = q.IsThaiCitizen,
                           InspectValueType = q.InspectValueType,
                           InspectValueTypeName = q.InspectValueTypeName,
                           ServiceCode =q.ServiceCode
                       }).ToArray();
            }
            return res;
        }
        private InspectValueListData[] GetAllValueList()
        {
            InspectValueListData[] res = null;
            InspectValueListCollection_Base obj = new InspectValueListCollection_Base(CSystems.ProcessID);
            var row = obj.GetAll();
            obj.Dispose();
            if (row.Length != 0)
            {
                res = (from q in row
                       select new InspectValueListData
                       {
                           InspectValueListID = q.InspectValueListID,
                           InspectValueListName = q.InspectValueListName,
                           InspectValueTypeID = q.InspectValueTypeID,
                       }).ToArray();
            }
            return res;
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
        // ~SingletonProvince()
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
