using System;
using System.Data;
using System.Web;

namespace Megazy.StarterKit.Engine
{
    public class AntiSqlInjection
    {

        private static string[] blackList = { " --", ";--", ";", "/*", "*/", "@@", "union", "master.dbo.xp_cmdshell", "sp_configure", "exec", "system_user", "sys.tables", "information_schema.tables", "DB_NAME", "sys.databases" };

        public static void CheckInput(string parameter)
        {
            if (parameter != null)
            {
                bool isBlackList = false;
                string blackListToken = string.Empty;
                for (int i = 0; i < blackList.Length; i++)
                {
                    if ((parameter.IndexOf(blackList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                    {
                        isBlackList = true;
                        blackListToken = blackList[i];
                        break;
                    }
                    else if (parameter.StartsWith("--"))
                    {
                        isBlackList = true;
                        blackListToken = "--";
                        break;
                    }
                }

                if (isBlackList)
                {

                    Exception exSqlInject = new Exception("SqlInjectionAttack = " + blackListToken + " ," + parameter + " ,Host = " + GetIpFromHost());
                    DalBase.ExceptEngine.ThrowException(-500, exSqlInject);

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