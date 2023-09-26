using System;
using System.Data;
using System.Web;

namespace JFS.Megazy.MilkyWaySolution.Engine
{
    public class AntiSqlInjection
    {

        private static string[] blackList = { "--", ";--", ";", "/*", "*/", "@@", "union", "master.dbo.xp_cmdshell", "sp_configure", "exec", "system_user", "sys.tables","information_schema.tables","DB_NAME", "sys.databases" };

        public static void CheckInput(string parameter)
        {
            if (parameter != null)
            {
                for (int i = 0; i < blackList.Length; i++)
                {
                    if ((parameter.IndexOf(blackList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                    {

                        Exception exSqlInject = new Exception("SqlInjectionAttack = " + blackList[i] + " ," + parameter + " ,Host = " + GetIpFromHost());

                        DalBase.ExceptEngine.ThrowException(-500, exSqlInject);
                    }
                }
            }
        }
        private static string GetIpFromHost()
        {
            string userHostAddress = string.Empty;

            try
            {
                userHostAddress = HttpContext.Current.Request.UserHostAddress.ToString();
            }
            catch
            {

                userHostAddress = "Cannot reach IP";
            }

            return userHostAddress;
        }
    }
}