using System;

namespace JFS.Megazy.MilkyWaySolution.Web.CommonProvide
{
    public class Authorization
    {
        private static int _sitecallid = 1;

        public enum SiteName
        {
            MEGAZY = 1
        }

        public Authorization()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static void ValidKey(string key)
        {
            if (string.IsNullOrEmpty(key) == false)
            {
                if (key != "a0815599800")
                {
                    Exception ex = new Exception("Could not call engine because key Invalid");
                    throw ex;
                }
            }

        }
        public static int SiteCallId(int processID)
        {
            int siteid = 0;

            if (processID < 0)
            {
                siteid = -1;
            }
            else if (processID >= 0 && processID <= 100000000)
            {
                siteid = 1;
            }
            else if (processID > 100000000 && processID <= 200000000)
            {
                siteid = 2;
            }
            else if (processID > 200000000 && processID <= 300000000)
            {
                siteid = 3;
            }
            else if (processID > 300000000 && processID <= 400000000)
            {
                siteid = 4;
            }
            return siteid;
        }
    }
}