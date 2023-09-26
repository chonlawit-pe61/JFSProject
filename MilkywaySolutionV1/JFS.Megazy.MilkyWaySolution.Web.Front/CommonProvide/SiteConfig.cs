using Banish.Treasure.Megazy;
using JFS.Megazy.MilkyWaySolution.Engine;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
namespace JFS.Megazy.MilkyWaySolution.Web.Front
{
    public sealed class SiteConfig
    {
        static readonly SiteConfig _instance = new SiteConfig();
        //private static string _resUrl;
       // private static string _domain;
        private static string _datetimeFormat;
        private static string _dateFormat;
          private static string _styleVersion;
          private static string _scriptVersion;
        private static CultureInfo _culture;
        //private static string _channelSecret;
        //private static string _channelID;
        //private static string _facebookAppID;
        //private static string _facebookAppSecret;
       // private static bool _sendToMSC;
        private static string _rootDomain;
        private static SysMailConfigInfo _mailConfig;
        private static string _webSite;
        private static string _jfWebSite;

        public static SiteConfig Instance
        {
            get { return _instance; }
        }
        SiteConfig()
        {
            //--Init
            //_resUrl = ConfigurationManager.AppSettings["ResURL"];
           // _domain = ConfigurationManager.AppSettings["Domain"];
            _dateFormat = ConfigurationManager.AppSettings["DateFormat"];
            _datetimeFormat = ConfigurationManager.AppSettings["DatetimeFormat"];
            _culture = new CultureInfo(ConfigurationManager.AppSettings["Culture"]);
            _styleVersion = ConfigurationManager.AppSettings["StyleVersion"];
            _scriptVersion = ConfigurationManager.AppSettings["ScriptVersion"];
          //  _sendToMSC = Convert.ToBoolean(ConfigurationManager.AppSettings["SendToMSC"].ToString()== "1");
            //_channelSecret = ConfigurationManager.AppSettings["ChannelSecret"];
            //_facebookAppID = ConfigurationManager.AppSettings["FacebookAppID"];
            //_facebookAppSecret = ConfigurationManager.AppSettings["FacebookAppSecret"];
            //_instanceName = ConfigurationManager.AppSettings["InstanceName"];
            _rootDomain = ConfigurationManager.AppSettings["RootDomain"];
            SetSysMailConfig();
            _webSite = ConfigurationManager.AppSettings["Website"];
            _jfWebSite = ConfigurationManager.AppSettings["JFWebsite"];
        }
        #region SET
        private void SetSysMailConfig()
        {
            string query = @"tag='mail'";
            SysSettingCollection_Base settingBase = new SysSettingCollection_Base(CSystems.ProcessID);
            SysSettingRow[] settingRow = settingBase.GetAsArray(new List<SqlParameter>(), query, "");
            settingBase.Dispose();

            _mailConfig = new SysMailConfigInfo();

            foreach (SysSettingRow item in settingRow)
            {
                switch (item.Key)
                {
                    case "username": _mailConfig.UserName = item.Value; break;
                    case "pw": _mailConfig.Password = item.Value; break;
                    case "smtp": _mailConfig.Smtp = item.Value; break;
                    case "smtp_port": _mailConfig.SmtpPort = string.IsNullOrEmpty(item.Value) ? 0 : Convert.ToInt32(item.Value); break;
                    case "is_ssl":
                        _mailConfig.IsSsl = string.IsNullOrEmpty(item.Value) ? false
                 : (item.Value == "1" ? true : false)
                 ; break;
                }
            }
        }
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


        //public string GetDomain()
        //{
        //    return _domain;
        //}
        //public string GetProfileUrl(int userID)
        //{
        //    string profileID = Maze.Cypher(userID.ToString());
        //    string ret = GetDomain() + "/images/member/" + Maze.Cypher(userID.ToString()) + ".jpg";

        //    return ret;
        //}
        //public string GetPhotoPath()
        //{
        //    return _resUrl.Replace("[n]", new Random().Next(1, 9).ToString());
        //}
        //public string GetInstanceName()
        //{
        //    return _instanceName;
        //}

        public string GetRootDomain()
        {
            return _rootDomain;
        }

        private int myVar;

        public string ScriptVerision
        {
            get { return _scriptVersion; }
        }
        public  string StyleVersion
        {
            get { return _styleVersion; }
        }
        //public bool SendToMSC()
        //{
        //    return _sendToMSC;
        //}
        //public string GetChannelSecret()
        //{
        //    return _channelSecret;
        //}
        //public string GetFacebookAppID()
        //{
        //    return _facebookAppID;
        //}
        //public string GetFacebookAppSecret()
        //{
        //    return _facebookAppSecret;
        //}

        public SysMailConfigInfo GetMailConfig()
        {
            return _mailConfig;
        }
        public string GetWebSite()
        {
            return _webSite;
        }
         public string GetJFWebSite()
        {
            return _jfWebSite;
        }
        #endregion
    }
}