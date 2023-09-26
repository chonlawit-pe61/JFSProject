using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
  public  class HelperService
    {
        public KeyValuePair<string, string> GetWebCondition(int processID)
        {
            KeyValuePair<string, string> ret = new KeyValuePair<string, string>();

            SysSettingCollection_Base obj = new SysSettingCollection_Base(processID);
            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Tag", System.Data.SqlDbType.VarChar));
            parameter.Add(new SqlParameter("@Key", System.Data.SqlDbType.VarChar));
            parameter[0].Value = "content";
            parameter[1].Value = "condition";
            SysSettingRow[] row = obj.GetAsArray(parameter, "Tag = @Tag and [Key] = @Key", "");
            obj.Dispose();

            if (row.Length > 0)
            {
                ret = new KeyValuePair<string, string>(row[0].Label, row[0].Value);
            }

            return ret;
        }

        public KeyValuePair<string, string> GetWebPolicy(int processID)
        {
            KeyValuePair<string, string> ret = new KeyValuePair<string, string>();

            SysSettingCollection_Base obj = new SysSettingCollection_Base(processID);
            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Tag", System.Data.SqlDbType.VarChar));
            parameter.Add(new SqlParameter("@Key", System.Data.SqlDbType.VarChar));
            parameter[0].Value = "content";
            parameter[1].Value = "policy";
            SysSettingRow[] row = obj.GetAsArray(parameter, "Tag = @Tag and [Key] = @Key", "");
            obj.Dispose();

            if (row.Length > 0)
            {
                ret = new KeyValuePair<string, string>(row[0].Label, row[0].Value);
            }

            return ret;
        }

        public void KeepLog(int processID, string logStr)
        {
            try
            {
                Exception ex = new Exception(logStr);
                DalBase.ExceptEngine.KeepLogOnly(processID, ex);
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.KeepLogOnly(processID, ex);
            }
        }

        public MailSetting GetMailSetting(int processID)
        {
            MailSetting ret = null;
            try
            {
                SysSettingCollection_Base sysBase = new SysSettingCollection_Base(processID);
                SysSettingRow[] sysRow = sysBase.GetAsArray(new List<SqlParameter>(), "tag='mail'", "");
                sysBase.Dispose();

                if (sysRow.Length > 0)
                {
                    ret = new MailSetting();
                    ret.IpSmtp = sysRow.Where(x => x.Key == "smtp").Select(x => x.Value).FirstOrDefault();
                    ret.Email = sysRow.Where(x => x.Key == "username").Select(x => x.Value).FirstOrDefault();
                    ret.Password = sysRow.Where(x => x.Key == "pw").Select(x => x.Value).FirstOrDefault();
                    ret.Port = sysRow.Where(x => x.Key == "smtp_port").Select(x => x.Value).FirstOrDefault();
                    ret.Port = string.IsNullOrEmpty(ret.Port) ? "0" : ret.Port;
                    ret.SSlStatus = sysRow.Where(x => x.Key == "is_ssl").Select(x => x.Value).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }

            return ret;
        }

        public DateTime GetSqlNow(int processID)
        {
            return new DalBase().GetSqlNow(processID);
        }
    }
}
