using System;
using System.Web;
using System.Configuration;
using Megazy.StarterKit.Engine.Helpers;

namespace Megazy.StarterKit.Engine
{
    public class CSystems
    {
        public static int ProcessID
        {
            get
            {
                int hCode = 0;
                try
                {
                    hCode = HttpContext.Current.Request.GetHashCode();
                }
                catch
                {
                    //Nothing To Do
                }
                if (hCode >= 100000000)
                {
                    Exception exRang = new Exception("hCode >= 100,000,000 : " + hCode.ToString());
                }
                int newProcessID = hCode;
                //if (ConfigurationManager.AppSettings["Domain"].Contains("jf.moj.go.th"))
                //{
                //    newProcessID = hCode + 100000000;
                //}
                //else if (ConfigurationManager.AppSettings["Domain"].Contains("jfs.developerinhouse.com"))
                //{
                //    newProcessID = hCode + 200000000;
                //}
                return newProcessID;
            }
        }
        public static string ConnString
        {
            get { return ConfigurationManager.AppSettings["DefaultLog"].ToString(); }
        }
        public static string MapAPIKey
        {
            get{return ConfigurationManager.AppSettings["MapApi"].ToString();}
        }
        /// <summary>
        /// c:\images
        /// </summary>
        public static string ImagePath
        {
            get { return ConfigurationManager.AppSettings["ImagePath"].ToString(); }
        }

        /// <summary>
        ///c:\Files
        /// </summary>
        public static string FilePath
        {
            get { return ConfigurationManager.AppSettings["FilePath"].ToString(); }
        }
        /// <summary>
        /// DEV: http://localhost:10075
        /// PRODUCT : http://www.xxxx.com
        /// </summary>
        public static string Website
        {
            get { return ConfigurationManager.AppSettings["Website"].ToString(); }
        }

        public static int ItemPerPage
        {
            get { return Utility.TryParseToInt(ConfigurationManager.AppSettings["ItemPerPage"].ToString()); }
        }

    }

    public class CSystemsAsync
    {
        public static int ProcessID
        {
            get
            {
                int hCode;
                try
                {
                    int year = DateTime.Now.Year;
                    hCode = (int)(DateTime.UtcNow.Subtract(new DateTime(year, 1, 1))).TotalMinutes * -1;
                }
                catch
                {
                    hCode = -98889;
                }
                return hCode;
            }

        }




    }
}
