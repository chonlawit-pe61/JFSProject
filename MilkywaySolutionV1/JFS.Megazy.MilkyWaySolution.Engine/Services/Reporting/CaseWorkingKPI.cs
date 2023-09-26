using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.Reporting
{
    public class CaseWorkingKPI : CaseReport
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
            string sqlTable = @"IF OBJECT_ID('tempdb..#tempCaseWorkingKPI') IS NOT NULL
DROP TABLE #tempCaseWorkingKPI

select CaseOwnerDepartment.CaseID,ProvinceExtension.ProvinceTypeCode,ProvinceType.ProvinceTypeName,
DATEDIFF(Day, StartStep.ChangeDate, ResultStep.ChangeDate) AS KPIStatus
INTO #tempCaseWorkingKPI
from CaseOwnerDepartment
INNER JOIN(select CaseID, WorkStepID, DepartmentID, Max(ModifiedDate) AS ModifiedDate
from CaseOwnerDepartment Where StatusID != 6 AND WorkStepID >= 2 Group by CaseID, WorkStepID, DepartmentID) AS OwnerCase
ON CaseOwnerDepartment.ModifiedDate = OwnerCase.ModifiedDate
AND CaseOwnerDepartment.CaseID = OwnerCase.CaseID
AND CaseOwnerDepartment.DepartmentID = OwnerCase.DepartmentID
AND CaseOwnerDepartment.WorkStepID = OwnerCase.WorkStepID
INNER JOIN CaseApplication ON CaseOwnerDepartment.CaseID = CaseApplication.CaseID
AND CaseOwnerDepartment.DepartmentID = CaseApplication.DepartmentID
AND CaseApplication.JFCaseTypeID != 5
INNER JOIN(
select CaseID, WorkStepID, DepartmentID, MIN(ChangeDate) AS ChangeDate
from CaseChangeWorkStepHistory Where WorkStepID = 2 Group by CaseID, WorkStepID, DepartmentID
) AS StartStep ON CaseOwnerDepartment.CaseID = StartStep.CaseID
AND CaseOwnerDepartment.DepartmentID = StartStep.DepartmentID
INNER JOIN(
select CaseID, WorkStepID, DepartmentID, MAX(ChangeDate) AS ChangeDate
from CaseChangeWorkStepHistory Where WorkStepID BETWEEN 2 AND 5 Group by CaseID,WorkStepID,DepartmentID
) AS ResultStep ON CaseOwnerDepartment.CaseID = ResultStep.CaseID
AND CaseOwnerDepartment.DepartmentID = ResultStep.DepartmentID
AND CaseOwnerDepartment.WorkStepID = ResultStep.WorkStepID
INNER JOIN Department
ON OwnerCase.DepartmentID = Department.DepartmentID
INNER JOIN ProvinceExtension
ON Department.ProvinceID = ProvinceExtension.ProvinceID
INNER JOIN ProvinceType
ON ProvinceExtension.ProvinceTypeCode = ProvinceType.ProvinceTypeCode
--Where CaseApplication.RegisterDate Between '2020-5-1' AND '2021-9-30'

select ProvinceTypeName, COUNT(ProvinceTypeCode) AS TotalCase from #tempCaseWorkingKPI
Where KPIStatus > 21 Group By ProvinceTypeName";
            string sql = "SELECT COUNT(ProvinceTypeName) AS TotalRow FROM (" + sqlTable + ") Tb ";
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
                          " FROM ReportCase" + whereSql +
                          "  GROUP BY ThaiQuarter,ThaiFiscalYear" + selectColumn + OrderBySql;
            AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }
    }
}
