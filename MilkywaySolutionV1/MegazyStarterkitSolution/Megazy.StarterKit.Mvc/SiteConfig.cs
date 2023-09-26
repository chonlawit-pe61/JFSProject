using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
namespace Megazy.StarterKit.Mvc
{
    public sealed class SiteConfig
    {
        static readonly SiteConfig _instance = new SiteConfig();
        private static string _datetimeFormat;
        private static string _dateFormat;
        private static string _styleVersion;
        private static string _scriptVersion;
        private static CultureInfo _culture;
        private static bool _production;
        private static string _rootDomain;
       // private static SysMailConfigInfo _mailConfig;
        private static string _webSite;
        public static SiteConfig Instance
        {
            get { return _instance; }
        }
        SiteConfig()
        {
            _dateFormat = ConfigurationManager.AppSettings["DateFormat"];
            _datetimeFormat = ConfigurationManager.AppSettings["DatetimeFormat"];
            _culture = new CultureInfo(ConfigurationManager.AppSettings["Culture"]);
            _styleVersion = ConfigurationManager.AppSettings["StyleVersion"];
            _scriptVersion = ConfigurationManager.AppSettings["ScriptVersion"];
            _production = ConfigurationManager.AppSettings["Production"].ToString() == "1";
            _rootDomain = ConfigurationManager.AppSettings["RootDomain"];
           // SetSysMailConfig();
            _webSite = ConfigurationManager.AppSettings["Website"];
        }
        #region SET
        //private void SetSysMailConfig()
        //{
        //    string query = @"tag='mail'";
        //    SysSettingCollection_Base settingBase = new SysSettingCollection_Base(CSystems.ProcessID);
        //    SysSettingRow[] settingRow = settingBase.GetAsArray(new List<SqlParameter>(), query, "");
        //    settingBase.Dispose();

        //    _mailConfig = new SysMailConfigInfo();

        //    foreach (SysSettingRow item in settingRow)
        //    {
        //        switch (item.Key)
        //        {
        //            case "username": _mailConfig.UserName = item.Value; break;
        //            case "pw": _mailConfig.Password = item.Value; break;
        //            case "smtp": _mailConfig.Smtp = item.Value; break;
        //            case "smtp_port": _mailConfig.SmtpPort = string.IsNullOrEmpty(item.Value) ? 0 : Convert.ToInt32(item.Value); break;
        //            case "is_ssl":
        //                _mailConfig.IsSsl = string.IsNullOrEmpty(item.Value) ? false
        //         : (item.Value == "1" ? true : false)
        //         ; break;
        //        }
        //    }
        //}
        #endregion
        #region GET
        public string ConvertDateToString(DateTime date)
        {
            return date.ToString(_dateFormat, _culture);
        }
        public string ConvertDateTimeToString(DateTime datetime)
        {
            return datetime.ToString(_datetimeFormat, _culture);
        }
        public DateTime ConvertStringToDate(string date)
        {
            return DateTime.ParseExact(date, _dateFormat, _culture);
        }
        public DateTime ConvertStringToDatetime(string datetime)
        {
            return DateTime.ParseExact(datetime, _datetimeFormat, _culture);
        }
        public string ConvertBirthDateToString(DateTime? datetime)
        {
            DateTime d = Convert.ToDateTime(datetime);
            return d.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
        }

        public DateTime ConvertBirthDateToString(string datetime)
        {
            return DateTime.ParseExact(datetime, "yyyy-MM-dd", new CultureInfo("en-US"));
        }
        public string GetRootDomain()
        {
            return _rootDomain;
        }

        public string ScriptVerision
        {
            get { return _scriptVersion; }
        }
        public string StyleVersion
        {
            get { return _styleVersion; }
        }
        public bool Production()
        {
            return _production;
        }
        //public SysMailConfigInfo GetMailConfig()
        //{
        //    return _mailConfig;
        //}
        public string GetWebSite()
        {
            return _webSite;
        }
        #endregion
    }
}