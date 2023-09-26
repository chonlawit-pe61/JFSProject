using Megazy.StarterKit.Engine.DataRepository.Navigation;
using Megazy.StarterKit.Engine.Helpers;
using Megazy.StarterKit.Engine.Dal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Megazy.StarterKit.Engine.Mvc.Singleton
{
    public class SingletonNavi : IDisposable
    {
        private static SingletonNavi _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public List<NavItem> MenuItem { get; set; }
        private SingletonNavi() { }
        public static SingletonNavi Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonNavi();
                        _instance.MenuItem = _instance.GetNavi();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.MenuItem = _instance.GetNavi();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }

        private List<NavItem> GetNavi()
        {
            List<NavItem> res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/navi.json");
                if (!File.Exists(path))
                {
                    res = GetMenuFile(path);
                }
                else
                {
                    if (FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = GetMenuFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            if (!string.IsNullOrWhiteSpace(json))
                            {
                                res = JsonConvert.DeserializeObject<List<NavItem>>(json);
                            }
                            else
                            {
                                res = GetMenuFile(path);
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
        private List<NavItem> GetMenuFile(string path)
        {
            List<NavItem> res = new List<NavItem>();
            try
            {
                View_ModuleCollection_Base obj = new View_ModuleCollection_Base(CSystems.ProcessID);
                List<SqlParameter> parameter = new List<SqlParameter>();
                string whereSql = "[IsActive] = 1";
                string orderbySql = "SortOrder ASC";
                var rows = obj.GetAsArray(parameter, whereSql, orderbySql);
                obj.Dispose();
                foreach (var item in rows)
                {
                    NavItem data = new NavItem
                    {

                        IconName = item.ModuleIcon,
                        ModuleID = item.ModuleID,
                        ModuleName = item.ModuleName,
                        ModuleTitle = item.ModuleTitle,
                        SortOrder = item.SortOrder
                    };
                    if (!string.IsNullOrWhiteSpace(item.Screen))
                    {
                        List<ScreenList> screenList = JsonConvert.DeserializeObject<List<ScreenList>>(item.Screen);
                        if (screenList.Safe().Any())
                        {
                            data.Screen = (from q in screenList
                                           where q.IsActive == true
                                           orderby q.SeqNo ascending
                                           select new ScreenList
                                           {
                                               ScreenID = q.ScreenID,
                                               Name = q.Name,
                                               Title = q.Title,
                                               SeqNo = q.SeqNo,
                                               ParentScreenID = q.ParentScreenID,
                                               SubScreen = q.SubScreen != null ? q.SubScreen.ToList() : new List<ScreenList>(),
                                           }
                                 ).ToList();
                        }
                    }
                    res.Add(data);
                }
                string jsonString = JsonConvert.SerializeObject(res);
                File.WriteAllText(path, jsonString);
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return res;
        }

        public List<NavItem> GetMenu(IEnumerable<int> moduleID)
        {


            var r = (from q in Instance.GetNavi()
                     where moduleID.Contains(q.ModuleID)
                     select q).ToList();
            return r;

        }
        //private SysRoleData[] RoleFile(string path)
        //{

        //    SysRoleData[] res = null;
        //    try
        //    {
        //        List<SqlParameter> parameter = new List<SqlParameter>();
        //        SysRoleCollection_Base obj = new SysRoleCollection_Base(CSystems.ProcessID);
        //        string whereSql = "";
        //        SysRoleRow[] row = obj.GetAsArray(parameter, whereSql, "SortOrder ASC");
        //        obj.Dispose();
        //        if (row != null)
        //        {

        //            res = (from q in row
        //                   select new SysRoleData
        //                   {
        //                       RoleID = q.RoleID,
        //                       RoleName = q.RoleName,
        //                       IsActive = q.IsActive
        //                   }).ToArray();

        //            string jsonString = JsonConvert.SerializeObject(res);
        //            File.WriteAllText(path, jsonString);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
        //    }
        //    return res;
        //}




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