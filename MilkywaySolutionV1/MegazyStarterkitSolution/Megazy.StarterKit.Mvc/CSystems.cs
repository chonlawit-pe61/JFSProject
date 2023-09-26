using System;
using System.Web;
using System.Configuration;

namespace Megazy.StarterKit.Mvc
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
                    _ = new Exception("hCode >= 100,000,000 : " + hCode.ToString());
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