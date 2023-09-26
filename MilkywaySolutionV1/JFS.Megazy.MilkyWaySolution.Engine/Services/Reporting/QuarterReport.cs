﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.Reporting
{
    public class QuarterReport : CaseReport
    {
        public override bool Export()
        {
            throw new NotImplementedException();
        }


        public override DataTable GetAsDataTable(ComponentReportFilter filter, string[] columName, int startRowIndex, int rowPerPage = 50000, string sortBy = "ThaiQuarter ASC")
        {
            string selectColumn = columName != null ? string.Join(",", columName) : "";
            if (selectColumn != "")
                selectColumn = "," + selectColumn;

            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            string whereSql = ConvertCompenentFiltersToWheresql(filter, ref sqlParameter);
            if (null != whereSql && 0 < whereSql.Length)
            {
                whereSql = " WHERE   " + whereSql;
            }
            string sqlTable = " SELECT  ThaiQuarter,ThaiFiscalYear" + selectColumn +",COUNT(CaseID) AS NumberOfCase" +
                          " FROM jfs_udf_report()" + whereSql +
                          " GROUP BY ThaiQuarter,ThaiFiscalYear" + selectColumn;
            string sql = "SELECT COUNT(ThaiQuarter) AS TotalRow FROM (" + sqlTable + ") Tb ";
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
            if (selectColumn != "")
                selectColumn = "," + selectColumn;

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
            string sql = " SELECT TOP 50000 ThaiQuarter,ThaiFiscalYear" + selectColumn + ",COUNT(CaseID) AS NumberOfCase" +
                          " FROM jfs_udf_report()" + whereSql +
                          "  GROUP BY ThaiQuarter,ThaiFiscalYear" + selectColumn + OrderBySql;
            AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }

    }
}
