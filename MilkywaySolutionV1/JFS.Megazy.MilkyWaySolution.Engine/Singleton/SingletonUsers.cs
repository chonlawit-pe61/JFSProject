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
  public  class SingletonUsers : IDisposable
    {
        private static SingletonUsers _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public UserTypeData[] UserTypeItem { get; set; }
        public UserStatusData[] UserStatusItem { get; set; }
        public View_UserOfficerData[] OfficerItem { get; set; }
        private SingletonUsers() { }
        public static SingletonUsers Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonUsers();
                        _instance.UserTypeItem = _instance.GetUserType();
                        _instance.UserStatusItem = _instance.GetUserStatus();
                        _instance.OfficerItem = _instance.GetOfficer();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.UserTypeItem = _instance.GetUserType();
                            _instance.UserStatusItem = _instance.GetUserStatus();
                            _instance.OfficerItem = _instance.GetOfficer();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private UserTypeData[] GetUserType()
        {
            UserTypeData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/usertype.json");
                if (!File.Exists(path))
                {
                    res = CreateUserTypeFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateUserTypeFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<UserTypeData[]>(json);
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
     
        private UserTypeData[] CreateUserTypeFile(string path)
        {

            UserTypeData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                UserTypeCollection_Base obj = new UserTypeCollection_Base(CSystems.ProcessID);
                //sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                //parameter.Add(sqlParameter);
                //string sql = "IsActive = @IsActive";
                UserTypeRow[] row = obj.GetAll();
                obj.Dispose();
                if (row != null)
                {
                    res = (from q in row
                           select new UserTypeData
                           {
                               UserTypeID = q.UserTypeID,
                               Name = q.Name,
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
       private UserStatusData[] GetUserStatus()
        {
            UserStatusData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/userstatus.json");
                if (!File.Exists(path))
                {
                    res = CreateUserStatusFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateUserStatusFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {                           
                            string json = r.ReadToEnd();
                            if (!string.IsNullOrWhiteSpace(json))
                            {
                                res = JsonConvert.DeserializeObject<UserStatusData[]>(json);
                            }
                            else
                            {
                                res = CreateUserStatusFile(path);
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
     
        private UserStatusData[] CreateUserStatusFile(string path)
        {

            UserStatusData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                UserStatusCollection_Base obj = new UserStatusCollection_Base(CSystems.ProcessID);
                //sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                //parameter.Add(sqlParameter);
                //string sql = "IsActive = @IsActive";
                UserStatusRow[] row = obj.GetAll();
                obj.Dispose();
                if (row != null)
                {
                    res = (from q in row
                           select new UserStatusData
                           {
                                UserStatusID = q.UserStatusID,
                               Description = q.Description,
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
       private View_UserOfficerData[] GetOfficer()
        {
            View_UserOfficerData[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/officer.json");
                if (!File.Exists(path))
                {
                    res = CreateOfficerFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateOfficerFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {                           
                            string json = r.ReadToEnd();
                            if (!string.IsNullOrWhiteSpace(json))
                            {
                                res = JsonConvert.DeserializeObject<View_UserOfficerData[]>(json);
                            }
                            else
                            {
                                res = CreateOfficerFile(path);
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
     
        private View_UserOfficerData[] CreateOfficerFile(string path)
        {

            View_UserOfficerData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                View_UserOfficerCollection_Base obj = new View_UserOfficerCollection_Base(CSystems.ProcessID);
                //sqlParameter = new SqlParameter("@OfficeRoleID", System.Data.SqlDbType.Int) { Value = 2 };
                //parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@UserStatusID", System.Data.SqlDbType.Int) { Value = 1};
                parameter.Add(sqlParameter);
                string sql = "UserStatusID = @UserStatusID";// AND OfficeRoleID=@OfficeRoleID";
               var row = obj.GetAsArray(parameter,sql,"UserID ASC");
                obj.Dispose();
                if (row != null)
                {
                    res = (from q in row
                           select new View_UserOfficerData
                           {
                               UserID = q.UserID,
                               DepartmentID = q.DepartmentID,
                               FirstName = q.FirstName,
                               LastName = q.LastName,
                            OfficerRoleName =q.OfficerRoleName,
                            OfficeRoleID = q.OfficeRoleID
                               
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
