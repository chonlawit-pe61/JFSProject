using System;
using System.Web;
using System.Configuration;
using JFS.Megazy.MilkyWaySolution.Engine.Helpers;

namespace JFS.Megazy.MilkyWaySolution.Engine
{
    /// <summary>
    /// Summary description for Systems.
    /// </summary>
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
                if (ConfigurationManager.AppSettings["Domain"].Contains("jf.moj.go.th"))
                {
                    newProcessID = hCode + 100000000;
                }
                else if (ConfigurationManager.AppSettings["Domain"].Contains("jfs.developerinhouse.com"))
                {
                    newProcessID = hCode + 200000000;
                }
                return newProcessID;
            }
            //get
            //{
            //    int hCode = 0;
            //    try
            //    {
            //        if (HttpContext.Current != null)
            //        {
            //            hCode = HttpContext.Current.Request.GetHashCode();
            //        }
            //        else
            //        {
            //            hCode = new Random().Next(0, 99999);
            //        }
            //    }
            //    catch
            //    {
            //        //Nothing To Do
            //    }
            //    if (hCode >= 100000000)
            //    {
            //        Exception exRang = new Exception("hCode >= 100,000,000 : " + hCode.ToString());
            //        //ClientProxy.ClientProxyBase.Instance.ExceptWeb.ThrowException(exRang);
            //    }

            //    int newProcessID = hCode;

            //    return newProcessID;
            //}

        }
        public static string ConnString
        {
            get
            {
                return ConfigurationManager.AppSettings["DefaultLog"].ToString();
            }

        }
        public static string MapAPIKey
        {
            get
            {
                return ConfigurationManager.AppSettings["MapApi"].ToString();
            }

        }
        /// <summary>
        /// D:\2K18Zone\GuildSolution\Area.Megazy.GuildSolution.WebMvc\images
        /// </summary>
        public static string ImagePath
        {
            get
            {
                return ConfigurationManager.AppSettings["ImagePath"].ToString();
            }

        }

        /// <summary>
        ////D:\2K19Zone\GuildAreaSolution\Area.Megazy.GuildSolution.Backoffice\Files
        /// </summary>
        public static string FilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["FilePath"].ToString();
            }

        }
        /// <summary>
        /// DEV: http://localhost:10075
        /// PRODUCT : http://www.tooktee.com
        /// </summary>
        public static string Website
        {
            get
            {
                return ConfigurationManager.AppSettings["Website"].ToString();
            }

        }

        public static int ItemPerPage
        {
            get
            {
                return Utility.TryParseToInt(ConfigurationManager.AppSettings["ItemPerPage"].ToString());
            }

        }








    }
    public class CSystemsAsync
    {
        public static int ProcessID
        {
            get
            {
                int hCode = -90009;
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
