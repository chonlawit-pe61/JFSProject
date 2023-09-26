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
   public class SingletonProvince : IDisposable   
    {

        private static SingletonProvince _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public ProvinceData[] ProvinceRow { get; set; }
        public ProvinceMSCData[] ProvinceMSCRow { get; set; }
        public DistrictData[] DistrictRow { get; set; }
        public SubdistrictData[] SubdistrictRow { get; set; }
        public RegionRow[] RegionRow { get; set; }
        private SingletonProvince() { }
        public static SingletonProvince Instance
        {
            get
            {
                //if (_instance != null) return _instance;
                //removed double lock because this is fixed in C# 6
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonProvince();
                        _instance.ProvinceRow = _instance.GetAll(); 
                       _instance.ProvinceMSCRow = _instance.GetProvinceMSCAll(); 
                        _instance.RegionRow = _instance.GetRegion();
                        _instance.SubdistrictRow = _instance.GetSubdistrict();
                        _instance.DistrictRow = _instance.GetDistrict();
                        _instance.lastDate = _instance.lastDate.AddMinutes(60);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 60)
                        {
                            _instance.ProvinceRow = _instance.GetAll();
                            _instance.ProvinceMSCRow = _instance.GetProvinceMSCAll();
                            _instance.RegionRow = _instance.GetRegion();
                            _instance.SubdistrictRow = _instance.GetSubdistrict();
                            _instance.DistrictRow = _instance.GetDistrict();
                            _instance.lastDate = _instance.lastDate.AddMinutes(60);
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
        private DistrictData[] GetDistrict()
        {
            DistrictData[] res = null;
            DistrictCollection_Base project = new DistrictCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>
            {
                new SqlParameter("@IsActive", SqlDbType.Bit){ Value =1 }
            };
            //parameter[0].Value = 1;
            string whereSql = "[IsActive] = @IsActive";
            string orderbySql = "[DistrictID] ASC";
            var row = project.GetAsArray(parameter, whereSql, orderbySql);
            project.Dispose();
            if (row.Length != 0)
            {
                res = (from q in row
                       select new DistrictData
                       {
                           DistrictID = q.DistrictID,
                           ProvinceID = q.ProvinceID,
                           DistrictCode = q.DistrictCode,
                           DistrictName = q.DistrictName,
                           DistrictNameEN = q.DistrictNameEN,
                           Latitude = q.Latitude,
                           Longitude = q.Longitude,
                           Geometry = q.Geometry,
                           IsActive = q.IsActive
                       }).ToArray();
            }
            return res;
        }
        private SubdistrictData[] GetSubdistrict()
        {
            SubdistrictData[] res = null;
            SubdistrictCollection_Base project = new SubdistrictCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>
            {
                new SqlParameter("@IsActive", SqlDbType.Bit){ Value =1 }
            };
            //parameter[0].Value = 1;
            string whereSql = "[IsActive] = @IsActive";
            string orderbySql = "[SubdistrictID] ASC";
            var row = project.GetAsArray(parameter, whereSql, orderbySql);
            project.Dispose();
            if (row.Length != 0)
            {
                res = (from q in row
                       select new SubdistrictData
                       {
                           SubdistrictID = q.SubdistrictID,
                           DistrictID = q.DistrictID,
                           SubdistrictCode = q.SubdistrictCode,
                           SubdistrictName = q.SubdistrictName,
                           SubdistrictNameEN = q.SubdistrictNameEN,
                           Latitude = q.Latitude,
                           Longitude = q.Longitude,
                           Geometry = q.Geometry,
                           PostCode = q.PostCode,
                           IsActive = q.IsActive
                       }).ToArray();
            }
            return res;
        }
        private ProvinceData[] GetAll()
        {
            ProvinceData[] res = null;
            ProvinceCollection_Base project = new ProvinceCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>
            {
                new SqlParameter("@IsActive", SqlDbType.Bit){ Value =1 }
            };
            //parameter[0].Value = 1;
            string whereSql = "[IsActive] = @IsActive";
            string orderbySql = "[ProvinceID] ASC";
            var row = project.GetAsArray(parameter, whereSql, orderbySql);            
            project.Dispose();
            if (row.Length != 0)
            {
                res = (from q in row
                       select new ProvinceData
                       {
                           ProvinceCode = q.ProvinceCode,
                           ProvinceID = q.ProvinceID,
                           IsActive = q.IsActive,
                           ProvinceName = q.ProvinceName,
                           ProvinceNameEN = q.ProvinceNameEN,
                           CountryCode = q.CountryCode,
                           RegionID = q.RegionID
                       }).ToArray();
            }
            return res;            
        }
        private ProvinceMSCData[] GetProvinceMSCAll()
        {
            ProvinceMSCData[] res = null;
            ProvinceMSCCollection_Base project = new ProvinceMSCCollection_Base(CSystems.ProcessID);
            string orderbySql = "[provName] ASC";
            var row = project.GetAsArray(new List<SqlParameter>(), "1=1", orderbySql);
            project.Dispose();
            if (row.Length != 0)
            {
                res = (from q in row
                       select new ProvinceMSCData
                       {
                           BelongJFSProvinceID = q.BelongJFSProvinceID,
                           provId = q.provId,
                           provName = q.provName,
                           regnId = q.regnId,
                       }).ToArray();
            }
            return res;
        }
        private RegionRow[] GetRegion()
        {
            RegionCollection_Base regionCollection = new RegionCollection_Base(CSystems.ProcessID);
            var row = regionCollection.GetAll();
            regionCollection.Dispose();
            return row;            
        }
        public ProvinceRow GetRow(int provinceCode)
        {
            ProvinceCollection_Base project = new ProvinceCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>
            {
                new SqlParameter("@IsActive", SqlDbType.Bit){ Value =1 },
                 new SqlParameter("@ProvinceCode", SqlDbType.Int){ Value =provinceCode }
            };
            string whereSql = "[ProvinceCode] = @ProvinceCode AND [IsActive] = @IsActive";
            var row = project.GetRow(parameter, whereSql);
            project.Dispose();
            return row;
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
