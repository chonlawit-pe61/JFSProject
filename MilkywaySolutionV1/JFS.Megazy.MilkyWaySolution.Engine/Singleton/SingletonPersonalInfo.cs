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
    public class SingletonPersonalInfo : IDisposable
    {
        private static SingletonPersonalInfo _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public RaceData[] RaceData { get; set; }
        public ReligionData[] ReligionData { get; set; }
        public NationalityData[] NationalityData { get; set; }
        public CardTypeData[] CardTypeData { get; set; }
        private SingletonPersonalInfo() { }
        public static SingletonPersonalInfo Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonPersonalInfo();
                        _instance.RaceData = _instance.GetRace();
                        _instance.ReligionData = _instance.GetReligion();
                        _instance.NationalityData = _instance.GetNationality();
                        _instance.CardTypeData = _instance.GetCardType();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.RaceData = _instance.GetRace();
                            _instance.ReligionData = _instance.GetReligion();
                            _instance.NationalityData = _instance.GetNationality();
                            _instance.CardTypeData = _instance.GetCardType();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private RaceData[] GetRace()
        {
            RaceData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                RaceCollection_Base obj = new RaceCollection_Base(CSystems.ProcessID);
                RaceRow[] row = obj.GetAll();
                obj.Dispose();
                if (row != null)
                {
                    res = (from q in row
                           select new RaceData
                           {
                               RaceID = q.RaceID,
                               RaceName = q.RaceName
                           }).ToArray();
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return res;
        }
        private NationalityData[] GetNationality()
        {
            NationalityData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                NationalityCollection_Base obj = new NationalityCollection_Base(CSystems.ProcessID);
                sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                parameter.Add(sqlParameter);
                string sql = "IsActive = @IsActive";
                NationalityRow[] row = obj.GetAsArray(parameter, sql, "SortOrder DESC");
                obj.Dispose();
                if (row != null)
                {
                    res = (from q in row
                           select new NationalityData
                           {
                               NationalityID = q.NationalityID,
                               NationalityCode = q.NationalityCode,
                               NationalityName = q.NationalityName
                           }).ToArray();
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return res;
        }
        private CardTypeData[] GetCardType()
        {
            CardTypeData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                CardTypeCollection_Base obj = new CardTypeCollection_Base(CSystems.ProcessID);
                sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                parameter.Add(sqlParameter);
                string sql = "IsActive = @IsActive";
                CardTypeRow[] row = obj.GetAsArray(parameter, sql,"");
                obj.Dispose();
                if (row != null)
                {
                    res = (from q in row
                           select new CardTypeData
                           {
                               CardTypeID = q.CardTypeID,
                               CardTypeName = q.CardTypeName,
                               IsActive = q.IsActive
                           }).ToArray();
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return res;
        }

        private ReligionData[] GetReligion()
        {
            ReligionData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                ReligionCollection_Base obj = new ReligionCollection_Base(CSystems.ProcessID);
                sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                parameter.Add(sqlParameter);
                string sql = "IsActive = @IsActive";
                ReligionRow[] row = obj.GetAsArray(parameter, sql, "ReligionID ASC");
                obj.Dispose();
                if (row != null)
                {
                    res = (from q in row
                           select new ReligionData
                           {
                               ReligionCode = q.ReligionCode,
                               ReligionID = q.ReligionID,
                               ReligionName = q.ReligionName,
                               IsOther = q.IsOther
                                
                           }).ToArray();
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
