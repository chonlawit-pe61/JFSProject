using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Services.Reporting;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Singleton
{
    public class SingletonJFCaseType : IDisposable
    {
        private static SingletonJFCaseType _instance = null;
        private static readonly object _syncLock = new object();
        private DateTime lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }
        public JFCaseType[] JFCaseTypeItem { get; set; }
        //public JFCaseTypeReportData[] JFCaseTypeReportDataItem { get; set; }
        private SingletonJFCaseType() { }
        public static SingletonJFCaseType Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonJFCaseType();
                        _instance.JFCaseTypeItem = _instance.GetJFCaseType();
                        //_instance.JFCaseTypeReportDataItem = _instance.GetJFCaseTypeReportData();
                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
                    }
                    else
                    {
                        if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
                        {
                            _instance.JFCaseTypeItem = _instance.GetJFCaseType();
                            // _instance.JFCaseTypeReportDataItem = _instance.GetJFCaseTypeReportData();
                            _instance.lastDate = _instance.lastDate.AddMinutes(30);
                        }
                    }
                }
                return _instance;
            }
        }
        private JFCaseType[] GetJFCaseType()
        {
            JFCaseType[] res = null;
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/jfcasetype.json");
                if (!File.Exists(path))
                {
                    res = CreateJFCaseTypeFile(path);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 120)
                    {
                        res = CreateJFCaseTypeFile(path);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<JFCaseType[]>(json);
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

        private JFCaseType[] CreateJFCaseTypeFile(string path)
        {

            JFCaseType[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                JFCaseTypeCollection_Base obj = new JFCaseTypeCollection_Base(CSystems.ProcessID);
                sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
                parameter.Add(sqlParameter);
                string sql = "IsActive = @IsActive";
                JFCaseTypeRow[] row = obj.GetAsArray(parameter, sql, "");
                obj.Dispose();
                if (row != null)
                {

                    res = (from q in row
                           select new JFCaseType
                           {
                               JFCaseTypeID = q.JFCaseTypeID,
                               IsActive = q.IsActive,
                               JFCaseTypeName = q.CaseTypeName,
                               JFCaseTypeAbbr = q.CaseTypeNameAbbr
                           }).ToArray();

                    string jsonString = JsonConvert.SerializeObject(res);
                    File.WriteAllText(path, jsonString);
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return res;
        }

        public static JFCaseTypeReportData[] GetJFCaseTypeReportData(int departmentId = -1)//Default GetAllCase
        {
            JFCaseTypeReportData[] res = null;
            try
            {
                string fileName = "jfcasetypereportdata";
                if (departmentId != -1)
                { fileName += departmentId.ToString(); }
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/" + fileName + ".json");
                if (!File.Exists(path))
                {
                    res = CreateCountJFCaseTypeFile(path, departmentId);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 10)
                    {
                        res = CreateCountJFCaseTypeFile(path, departmentId);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<JFCaseTypeReportData[]>(json);
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

        private static JFCaseTypeReportData[] CreateCountJFCaseTypeFile(string path, int departmentID)
        {

            JFCaseTypeReportData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                JFCaseTypeCollection_Base obj = new JFCaseTypeCollection_Base(CSystems.ProcessID);
                sqlParameter = new SqlParameter("@IsActive", SqlDbType.Bit) { Value = true };
                parameter.Add(sqlParameter);
                string sql = "IsActive = @IsActive";


                JFCaseTypeRow[] row = obj.GetAsArray(parameter, sql, "");
                obj.Dispose();
                List<JFCaseTypeReportData> dd = new List<JFCaseTypeReportData>();
                if (row != null)
                {
                    dd = (from q in row
                          select new JFCaseTypeReportData
                          {
                              JFCaseTypeID = q.JFCaseTypeID,
                              JFCaseTypeAbbr = q.CaseTypeNameAbbr
                          }).ToList();

                    JFCaseTypeReport jf = new JFCaseTypeReport();
                    var filter = new ComponentReportFilter();
                    if (departmentID > 0)
                    {
                        filter.DepartmentID = departmentID;
                    }
                    var dt = jf.GetAsDataTable(filter, null, 0, 10);
                    if (dt.Rows.Count != 0)
                    {
                        foreach (var item in dd)
                        {
                            var drow = dt.AsEnumerable().Where(myRow => myRow.Field<string>("CaseTypeNameAbbr") == item.JFCaseTypeAbbr).FirstOrDefault();
                            if (drow != null)
                            {
                                item.Amount = (int)drow["NumberOfCase"];
                            }
                        }
                    }
                    res = dd.ToArray();
                    string jsonString = JsonConvert.SerializeObject(res);
                    File.WriteAllText(path, jsonString);
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return res;
        }

        public static KPI21ReportData[] GetKPILawyerReportData(int departmentId = -1)//Default GetAllCase
        {
            KPI21ReportData[] res = null;
            try
            {
                string fileName = "kpilawyerreportdata";
                if (departmentId != -1)
                { fileName += departmentId.ToString(); }
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/" + fileName + ".json");
                if (!File.Exists(path))
                {
                    res = CreateKPILawyerDataFile(path, departmentId);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 10)
                    {
                        res = CreateKPILawyerDataFile(path, departmentId);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<KPI21ReportData[]>(json);
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
        public static KPI21ReportData[] GetKPISubCommitteeReportData(int departmentId = -1)//Default GetAllCase
        {
            KPI21ReportData[] res = null;
            try
            {
                string fileName = "kpisubcommitteereportdata";
                if (departmentId != -1)
                { fileName += departmentId.ToString(); }
                string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/" + fileName + ".json");
                if (!File.Exists(path))
                {
                    res = CreateKPISubCommitteeDataFile(path, departmentId);
                }
                else
                {
                    if (Helpers.FileHelper.GetLastUpdateTotalMinutes(path) > 10)
                    {
                        res = CreateKPISubCommitteeDataFile(path, departmentId);
                    }
                    else
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            res = JsonConvert.DeserializeObject<KPI21ReportData[]>(json);
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
        private static KPI21ReportData[] CreateKPILawyerDataFile(string path, int departmentID)
        {

            KPI21ReportData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                CaseApplicationCollection_Base obj = new CaseApplicationCollection_Base(CSystems.ProcessID);
                DataTable dt = obj.GetKPI21Lawyer(departmentID);
                obj.Dispose();
                if (dt.Rows.Count != 0)
                {
                    res = (from q in dt.AsEnumerable()
                           select new KPI21ReportData
                           {
                               JFCaseTypeAbbr = q.Field<string>("CaseTypeNameAbbr"),
                               WorkStepName = q.Field<string>("WorkStepName"),
                               DayRange = q.Field<string>("DayRange"),
                               JFCaseTypeID = q.Field<int>("JFCaseTypeID"),
                               TotalCase = q.Field<int>("TotalCase")
                           }).ToArray();

                    string jsonString = JsonConvert.SerializeObject(res);
                    File.WriteAllText(path, jsonString);
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return res;
        }
        private static KPI21ReportData[] CreateKPISubCommitteeDataFile(string path, int departmentID)
        {

            KPI21ReportData[] res = null;
            try
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlParameter = new SqlParameter();
                CaseApplicationCollection_Base obj = new CaseApplicationCollection_Base(CSystems.ProcessID);
                DataTable dt = obj.GetKPI21Subcommittee(departmentID);
                obj.Dispose();
                if (dt.Rows.Count != 0)
                {
                    res = (from q in dt.AsEnumerable()
                           select new KPI21ReportData
                           {
                               JFCaseTypeAbbr = q.Field<string>("CaseTypeNameAbbr"),
                               WorkStepName = q.Field<string>("WorkStepName"),
                               DayRange = q.Field<string>("DayRange"),
                               JFCaseTypeID = q.Field<int>("JFCaseTypeID"),
                               TotalCase = q.Field<int>("TotalCase")
                           }).ToArray();

                    string jsonString = JsonConvert.SerializeObject(res);
                    File.WriteAllText(path, jsonString);
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return res;
        }


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
