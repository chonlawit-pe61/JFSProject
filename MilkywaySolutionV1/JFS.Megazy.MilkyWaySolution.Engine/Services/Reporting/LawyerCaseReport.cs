using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
using JFS.Megazy.MilkyWaySolution.Engine.Request;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.Reporting
{
    public abstract class LawyerCaseReport
    {
        //public static string SqlQuery = GetQuery();
        public int _processID { get; set; }
        public LawyerCaseReport()
        {
            _processID = CSystems.ProcessID;
        }
        public SqlCommand cmd = null;
        public string OrderBySql { get; set; }
        public string WhereSql { get; set; }
        public abstract DataTable GetAsDataTable(LawyerComponentFilters filter, string[] columnName, int startRowIndex, int rowPerPage, string sortBy);
        public abstract DataTable GetAllAsDataTable(LawyerComponentFilters filter, string[] columnName, string sortBy);
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

            ////แก้ไขโดยให้ลบ Column ที่มีชื่อ "_Hide" ออก
            //foreach (var item in dataTable.Columns.Cast<DataColumn>())
            //{
            //    if (item.ColumnName.Contains("_Hide"))
            //    {
            //        dataTable.Columns.Remove(item.ColumnName);
            //    }
            //}

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
        public string ConvertCompenentFiltersToWheresql(LawyerComponentFilters filters, ref List<SqlParameter> listParameter)
        {
            if (filters == null)
            {
                throw new ArgumentNullException(nameof(filters));
            }

            StringBuilder query = new StringBuilder();
            string sql = "", joinsql = "";
            SqlParameter parameter;
            if (!string.IsNullOrEmpty(filters.Query))
            {
                filters.Query = "%" + filters.Query.Trim() + "%";
                parameter = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar) { Value = filters.Query };
                listParameter.Add(parameter);
                parameter = new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar) { Value = filters.Query };
                listParameter.Add(parameter);
                parameter = new SqlParameter("@CardID", System.Data.SqlDbType.NVarChar) { Value = filters.Query };
                listParameter.Add(parameter);
                parameter = new SqlParameter("@LicenseNo", System.Data.SqlDbType.NVarChar) { Value = filters.Query };
                listParameter.Add(parameter);
                parameter = new SqlParameter("@Email", System.Data.SqlDbType.NVarChar) { Value = filters.Query };
                listParameter.Add(parameter);
                parameter = new SqlParameter("@MobileNo", System.Data.SqlDbType.NVarChar) { Value = filters.Query };
                listParameter.Add(parameter);
                query.Append("([View_Lawyer].FirstName LIKE @FirstName OR [View_Lawyer].LastName LIKE @LastName OR [View_Lawyer].CardID LIKE @CardID OR [View_Lawyer].LicenseNo LIKE @LicenseNo OR [View_Lawyer].Email LIKE @Email OR [View_Lawyer].MobileNo LIKE @MobileNo)");
                sql += query.ToString();
            }
            if (filters.Location != null)
            {
                if (!string.IsNullOrEmpty(filters.Location.ProvinceID))
                {
                    query = new StringBuilder();
                    parameter = new SqlParameter("@ProvinceID", System.Data.SqlDbType.Int) { Value = filters.Location.ProvinceID };
                    listParameter.Add(parameter);
                    query.Append(" [View_Lawyer].[ProvinceID]=@ProvinceID");
                    if (sql == "")
                        sql += query.ToString();
                    else
                        sql += " AND " + query.ToString();
                }
                if (!string.IsNullOrEmpty(filters.Location.DistrictID))
                {
                    query = new StringBuilder();
                    parameter = new SqlParameter("@DistrictID", System.Data.SqlDbType.Int) { Value = filters.Location.DistrictID };
                    listParameter.Add(parameter);
                    query.Append(" [View_Lawyer].[DistrictID]=@DistrictID");
                    if (sql == "")
                        sql += query.ToString();
                    else
                        sql += " AND " + query.ToString();
                }
                if (!string.IsNullOrEmpty(filters.Location.SubDistrictID))
                {
                    query = new StringBuilder();
                    parameter = new SqlParameter("@SubDistrictID", System.Data.SqlDbType.Int) { Value = filters.Location.SubDistrictID };
                    listParameter.Add(parameter);
                    query.Append(" [View_Lawyer].[SubDistrictID]=@SubDistrictID");
                    if (sql == "")
                        sql += query.ToString();
                    else
                        sql += " AND " + query.ToString();
                }
                if (!string.IsNullOrEmpty(filters.Location.PostCode))
                {
                    query = new StringBuilder();
                    parameter = new SqlParameter("@PostCode", System.Data.SqlDbType.NVarChar) { Value = filters.Location.PostCode };
                    listParameter.Add(parameter);
                    query.Append(" [View_Lawyer].[PostCode]=@PostCode");
                    if (sql == "")
                        sql += query.ToString();
                    else
                        sql += " AND " + query.ToString();
                }

            }
            if (!string.IsNullOrEmpty(filters.LawyerTypeID))
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@LawyerTypeID", System.Data.SqlDbType.Int) { Value = filters.LawyerTypeID };
                listParameter.Add(parameter);
                query.Append(" [View_Lawyer].[LawyerTypeID]=@LawyerTypeID");

                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }
            if (!string.IsNullOrEmpty(filters.LawyerStatusID))
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@LawyerStatusID", System.Data.SqlDbType.Int) { Value = filters.LawyerStatusID };
                listParameter.Add(parameter);
                query.Append(" [View_Lawyer].[LawyerStatusID]=@LawyerStatusID");

                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }
            // if (!string.IsNullOrEmpty(filters.LawyerYear))
            //{
            //    query = new StringBuilder();
            //    parameter = new SqlParameter("@EnrollmentYear", System.Data.SqlDbType.Int) { Value = filters.LawyerYear };
            //    listParameter.Add(parameter);
            //    query.Append(" INNER JOIN LawyerEnrollment ON View_Lawyer.LawyerID = LawyerEnrollment.LawyerID  AND LawyerEnrollment.EnrollmentYear = @EnrollmentYear ");
            //    joinsql += query.ToString();
            //}
            //if (!string.IsNullOrEmpty(filters.TerritoryProvineID))
            //{
            //    query = new StringBuilder();
            //    parameter = new SqlParameter("@TerritoryProvineID", System.Data.SqlDbType.Int) { Value = filters.TerritoryProvineID };
            //    listParameter.Add(parameter);
            //    query.Append(" INNER JOIN LawyerTerritory ON View_Lawyer.LawyerID =  LawyerTerritory.LawyerID AND LawyerTerritory.ProvinceID = @TerritoryProvineID ");
            //    joinsql += query.ToString();
            //}

            if (!string.IsNullOrEmpty(filters.DateFrom) && !string.IsNullOrEmpty(filters.DateTo))
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@RegisterDateFrom", System.Data.SqlDbType.Date) { Value = filters.DateFrom };
                listParameter.Add(parameter);
                parameter = new SqlParameter("@RegisterDateTo", System.Data.SqlDbType.Date) { Value = filters.DateTo };
                listParameter.Add(parameter);
                query.Append(" [View_Lawyer].[RegisterDate] BETWEEN @RegisterDateFrom AND @RegisterDateTo");

                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }

            if (!string.IsNullOrEmpty(filters.LawyerID))
            {
                query = new StringBuilder();
                parameter = new SqlParameter("@LawyerID", System.Data.SqlDbType.VarChar) { Value = filters.LawyerID };
                listParameter.Add(parameter);
                query.Append(" [View_Lawyer].[LawyerID]=@LawyerID ");

                if (sql == "")
                    sql += query.ToString();
                else
                    sql += " AND " + query.ToString();
            }
            //if (filters.Status != -1)
            //{
            //    query = new StringBuilder();
            //    sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = filters.Status };
            //    parameter.Add(sqlParameter);
            //    query.Append(" [IsActive]=@IsActive");

            //    if (sql == "")
            //        sql += query.ToString();
            //    else
            //        sql += " AND " + query.ToString();
            //}

            //if (sql == "")
            //    sql += "ISNULL(ParentID,0) = 0";
            //else
            //    sql += " AND ISNULL(ParentID,0) = 0";


            return joinsql + sql;
        }

        public string DataTableToJSONWithJSONNet(DataTable dt)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }
    }
}
