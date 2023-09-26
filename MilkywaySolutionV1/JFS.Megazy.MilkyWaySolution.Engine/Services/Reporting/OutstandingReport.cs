using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.Reporting
{
    public class OutstandingReport : CaseReport
    {
        public override bool Export()
        {
            throw new NotImplementedException();
        }
        public override DataTable GetAsDataTable(ComponentReportFilter filter, string[] columName, int startRowIndex, int rowPerPage = 50000, string sortBy = "CaseTypeNameAbbr ASC")
        {
            string selectColumn = columName != null ? string.Join(",", columName) : "";
            string selectCount = "";
            if (selectColumn != "")
            {
                if(selectColumn == "DepartmentName")
                {
                    selectCount = "DepartmentID";
                    sortBy = "DepartmentName ASC";
                }
            }
                
            else
            {
                selectColumn = "CaseTypeNameAbbr";
                selectCount = "JFCaseTypeID";
            }
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            string whereSql = ConvertCompenentFiltersToWheresql(filter, ref sqlParameter);
            if (null != whereSql && 0 < whereSql.Length)
            {
                whereSql = " WHERE   " + whereSql;
            }

            string sqlTable = $"SELECT "+ selectColumn + " , COUNT("+ selectCount + ") AS Total FROM ReportOutstanding GROUP BY "+selectColumn+", "+ selectCount + "";
            string sql = $"SELECT COUNT("+ selectColumn + ") AS TotalRow FROM (" + sqlTable + ") Tb";
            AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            DataTable dt = CreateDataTable(command);
            command.Parameters.Clear();
            var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
            var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
            sql = " SELECT *," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
                      " FROM (SELECT *, " +
                      " ROW_NUMBER() OVER(ORDER BY " + sortBy + ") AS RowRank " +
                      " FROM (" + sqlTable + ") Tb" +
                      " ) AS AllWhitRowRank " +
                      "  WHERE RowRank >" + startRowIndex + "  AND RowRank  <= " + (startRowIndex + rowPerPage);// + wherePaging;
            command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }
        public override DataTable GetAllAsDataTable(ComponentReportFilter filter, string[] columName, string sortBy = "")
        {
            string selectColumn = columName != null ? string.Join(",", columName) : "";
            string selectCount = "";
            if (selectColumn != "")
            {
                if (selectColumn == "DepartmentName")
                {
                    selectCount = "DepartmentID";
                    sortBy = "DepartmentName ASC";
                }
            }

            else
            {
                selectColumn = "CaseTypeNameAbbr";
                selectCount = "JFCaseTypeID";
            }
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            string whereSql = ConvertCompenentFiltersToWheresql(filter, ref sqlParameter);
            if (null != whereSql && 0 < whereSql.Length)
            {
                whereSql = " WHERE   " + whereSql;
            }
            if (null != sortBy && 0 < sortBy.Length)
            {
                OrderBySql = " ORDER BY   " + sortBy;
            }
            string sql = $"SELECT " + selectColumn + " , COUNT(" + selectCount + ") AS Total FROM ReportOutstanding GROUP BY " + selectColumn + ", " + selectCount + ""+ OrderBySql;
            AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }
    }
}
