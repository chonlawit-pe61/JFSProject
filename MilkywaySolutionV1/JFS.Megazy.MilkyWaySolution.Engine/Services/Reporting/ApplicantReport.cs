using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
namespace JFS.Megazy.MilkyWaySolution.Engine.Services.Reporting
{
   public abstract class ApplicantReport
    {
        //public static string SqlQuery = GetQuery();
        public int _processID { get; set; }
        public ApplicantReport()
        {
            _processID = CSystems.ProcessID;
        }       
        public SqlCommand cmd = null;
        public string OrderBySql { get; set; }
        public string WhereSql { get; set; }
        public abstract DataTable GetAsDataTable(ComponentReportFilter filter,string[] columnName ,int startRowIndex, int rowPerPage, string sortBy);
        public abstract DataTable GetAllAsDataTable(ComponentReportFilter filter,string[] columnName ,string sortBy);
        public abstract bool Export();

        public SqlCommand CreateCommand(string sqlText)
        {
            return CreateCommand(sqlText, false);
        }
        private SqlCommand CreateCommand(string sqlText, bool procedure)
        {
            DalBase dal = new DalBase();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlText;
            if (_processID != 0)
            {
                dal.InitCommand(_processID, cmd);
            }
            else
            {
                _processID = CSystems.ProcessID;
                dal.InitCommand(_processID, cmd);
            }
            if (procedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            return cmd;
        }
        private void Close()
        {
            DalBase dal = new DalBase();
            if (_processID != 0)
            {
                dal.Close(_processID, cmd);
            }
            else
            {
                dal.Close(cmd);
            }
        }
        public DataTable CreateDataTable(IDbCommand command)
        {
            DataTable dataTable = new DataTable();
            new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)command).Fill(dataTable);
            return dataTable;
        }
       //static string GetQuery()
       // {
       //     //string path = System.Web.HttpContext.Current.Server.MapPath("/Reports/sqlapplicant.txt");
       //     //string  sql = "";
       //     //using (StreamReader sr = new StreamReader(path))
       //     //{
       //     //    sql = sr.ReadToEnd();
       //     //}
       //     return "SELECT * FROM ReportApplicant";
       // }
        public string ConvertCompenentFiltersToWheresql(ComponentReportFilter filters, ref List<SqlParameter> listParameter)
        {
            if (filters == null)
            {
                throw new ArgumentNullException(nameof(filters));
            }

            StringBuilder query = new StringBuilder();
            string sql = "";
            SqlParameter parameter;


            if (filters.JFCaseTypeID != 0)
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@JFCaseTypeID", System.Data.SqlDbType.Int) { Value = filters.JFCaseTypeID };
                listParameter.Add(parameter);
                query.Append(" [JFCaseTypeID]=@JFCaseTypeID");
                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }
            if (filters.DepartmentID != 0)
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = filters.DepartmentID };
                listParameter.Add(parameter);
                query.Append(" [DepartmentID]=@DepartmentID");
                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }
           

            if (!string.IsNullOrEmpty(filters.Region))
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@Region", System.Data.SqlDbType.Int) { Value = filters.Region };
                listParameter.Add(parameter);
                query.Append(" [RegionID]=@Region");

                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }
            if (!string.IsNullOrEmpty(filters.ThaiQuarter))
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@ThaiQuarter", System.Data.SqlDbType.Int) { Value = filters.ThaiQuarter };
                listParameter.Add(parameter);
                query.Append(" [ThaiQuarter]=@ThaiQuarter");

                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }
            if (!string.IsNullOrEmpty(filters.ThaiFiscalYear))
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@ThaiFiscalYear", System.Data.SqlDbType.Int) { Value = filters.ThaiFiscalYear };
                listParameter.Add(parameter);
                query.Append(" [ThaiFiscalYear]=@ThaiFiscalYear");

                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }
            if (!string.IsNullOrEmpty(filters.Quater))
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@Qt", System.Data.SqlDbType.Int) { Value = filters.Quater };
                listParameter.Add(parameter);
                query.Append(" [Qt]=@Qt");

                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }
            if (!string.IsNullOrEmpty(filters.YearStr))
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@YYYY", System.Data.SqlDbType.Int) { Value = filters.YearStr };
                listParameter.Add(parameter);
                query.Append(" [YYYY]=@YYYY");

                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }

            if (!string.IsNullOrEmpty(filters.DateFrom) && !string.IsNullOrEmpty(filters.DateTo))
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@RegisterDateFrom", System.Data.SqlDbType.Date) { Value = filters.DateFrom };
                listParameter.Add(parameter);
                parameter = new SqlParameter("@RegisterDateTo", System.Data.SqlDbType.Date) { Value = filters.DateTo };
                listParameter.Add(parameter);
                query.Append(" [RegisterDate] BETWEEN @RegisterDateFrom AND @RegisterDateTo");

                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }

            //if (sql == "")
            //    sql += "IsAppeal =" + Convert.ToInt16(filters.IsAppeal);
            //else
            //    sql += " AND IsAppeal =" + Convert.ToInt16(filters.IsAppeal);


            return sql;
        }
        public string DataTableToJSONWithJSONNet(DataTable dt)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }

    }
    public class ComponentReportFilter
    {
        public string YearStr { get; set; } 
        public string ThaiFiscalYear { get; set; }
        public string ThaiQuarter { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string Quater { get; set; }
        public string Region { get; set; }
        public string Province { get; set; } 

      public int DepartmentID { get; set; } 
      public int JFCaseTypeID { get; set; } 

    }
    //public class ReportApplicant
    //{
    //    public int ApplicantID { get; set; }
    //    public int? CaseID { get; set; }
    //    public string Title { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Gender { get; set; }
    //    public int Age { get; set; }
    //    public string IssuedAt { get; set; }
    //    public int? RaceID { get; set; }
    //    public int? ReligionID { get; set; }
    //    public int? NationalityID { get; set; }
    //    public string GenderName { get; set; }
    //    public string RaceName { get; set; }
    //    public string ReligionName { get; set; }
    //    public string NationalityName { get; set; }
    //    public int EducationLevelID { get; set; }
    //    public string Education { get; set; }
    //    public int CareerID { get; set; }
    //    public string Career { get; set; }
    //    public DateTime? RegisterDate { get; set; }
    //    public int? Qt { get; set; }
    //    public int? YYYY { get; set; }

    //}

    public enum FileType { PDF = 1, CSV = 2, DOC = 3, XLSX = 4 }
    public enum DisplayType { Table = 1, Chart = 2, Graph = 3 }

    


}
