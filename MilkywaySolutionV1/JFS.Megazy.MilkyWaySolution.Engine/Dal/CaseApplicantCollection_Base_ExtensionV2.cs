using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{
    public partial class CaseApplicantCollection_Base_ExtensionV2 : MarshalByRefObject
    {
        private int _processID;
        public SqlCommand cmd = null;
        public CaseApplicantCollection_Base_ExtensionV2(int intProcessID)
        {
            _processID = intProcessID;
        }
        #region StatisticsCaseProcess

        public DataTable GetReportCaseTypeDataTable(List<SqlParameter> sqlParameter, string whereSql, string[] col = null, string orderBySql = "")
        {
            string[] cols = col;
            string addTabalWithCol = "";
            string addConditionWithCol = "";
            string addColWithCol = "";
            if (cols != null)
            {
                foreach (var item in cols)
                {
                    if (string.IsNullOrWhiteSpace(addTabalWithCol) && string.IsNullOrWhiteSpace(addConditionWithCol))
                    {
                        if (item == "JFCaseTypeID")
                        {
                            if (sqlParameter.Find(o => o.ParameterName == "@JFCaseTypeID") != null)
                            {
                                var parameterValue = sqlParameter.Find(o => o.ParameterName == "@JFCaseTypeID").Value;
                                addTabalWithCol = " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 AND JFCaseTypeID = " + parameterValue + ") jcT ";
                            }
                            else
                            {
                                addTabalWithCol = " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 ) jcT ";
                            }
                            addConditionWithCol = " AND jcT.JFCaseTypeID = TA.JFCaseTypeID ";
                            addColWithCol = " ,jcT.JFCaseTypeID ,jcT.CaseTypeName ";
                        }
                        //else if (item == "ProvinceTypeName")
                        //{
                        //    if (sqlParameter.Find(o => o.ParameterName == "@ProvinceType") != null)
                        //    {
                        //        var parameterValue = sqlParameter.Find(o => o.ParameterName == "@ProvinceType").Value;
                        //        addTabalWithCol = " CROSS JOIN (SELECT * FROM ProvinceType WHERE ProvinceTypeCode = '" + parameterValue + "' ) AS pvT ";
                        //    }
                        //    else
                        //    {
                        //        addTabalWithCol = " CROSS JOIN ProvinceType AS pvT ";
                        //    }
                        //    addConditionWithCol = " AND pvT.ProvinceTypeCode = TA.ProvinceTypeCode ";
                        //    addColWithCol = " ,pvT.ProvinceTypeCode ,pvT.ProvinceTypeName ";
                        //}
                        //else if (item == "DepartmentName")
                        //{
                        //    if (sqlParameter.Find(o => o.ParameterName == "@DepartmentID") != null)
                        //    {
                        //        var parameterValue = sqlParameter.Find(o => o.ParameterName == "@DepartmentID").Value;
                        //        addTabalWithCol = " CROSS JOIN (SELECT * FROM Department WHERE DepartmentID = " + parameterValue + ") AS dpT ";
                        //    }
                        //    else
                        //    {
                        //        addTabalWithCol = " CROSS JOIN Department AS dpT ";
                        //    }
                        //    addConditionWithCol = " AND dpT.DepartmentID = TA.DepartmentID ";
                        //    addColWithCol = " ,dpT.DepartmentID ,dpT.DepartmentName ";
                        //}

                    }
                    else
                    {
                        if (item == "JFCaseTypeID")
                        {
                            if (sqlParameter.Find(o => o.ParameterName == "@JFCaseTypeID") != null)
                            {
                                var parameterValue = sqlParameter.Find(o => o.ParameterName == "@JFCaseTypeID").Value;
                                addTabalWithCol += " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 AND JFCaseTypeID = " + parameterValue + ") jcT ";
                            }
                            else
                            {
                                addTabalWithCol += " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 ) jcT ";
                            }
                            addConditionWithCol += " AND jcT.JFCaseTypeID = TA.JFCaseTypeID ";
                            addColWithCol += " ,jcT.JFCaseTypeID ,jcT.CaseTypeName ";
                        }
                        else if (item == "ProvinceTypeName" || item == "DepartmentName")
                        {
                            string valueWhereParameter = "";

                            if (sqlParameter.Find(o => o.ParameterName == "@ProvinceType") != null)
                            {
                                var parameterValue = sqlParameter.Find(o => o.ParameterName == "@ProvinceType").Value;
                            }
                            if (sqlParameter.Find(o => o.ParameterName == "@DepartmentID") != null)
                            {
                                var parameterValue = sqlParameter.Find(o => o.ParameterName == "@DepartmentID").Value;
                            }
                            //if (sqlParameter.Find(o => o.ParameterName == "@ProvinceType") != null)
                            //{
                            //    var parameterValue = sqlParameter.Find(o => o.ParameterName == "@ProvinceType").Value;
                            //    addTabalWithCol += " CROSS JOIN (SELECT * FROM ProvinceType WHERE ProvinceTypeCode = '" + parameterValue + "' ) AS pvT ";
                            //}
                            //else
                            //{
                            //    addTabalWithCol += " CROSS JOIN ProvinceType AS pvT ";
                            //}
                            //addConditionWithCol += " AND pvT.ProvinceTypeCode = TA.ProvinceTypeCode ";
                            //addColWithCol += " ,pvT.ProvinceTypeCode ,pvT.ProvinceTypeName ";
                        }
                        //else if (item == "DepartmentName")
                        //{
                        //    if (sqlParameter.Find(o => o.ParameterName == "@DepartmentID") != null)
                        //    {
                        //        var parameterValue = sqlParameter.Find(o => o.ParameterName == "@DepartmentID").Value;
                        //        addTabalWithCol += " CROSS JOIN (SELECT * FROM Department WHERE DepartmentID = " + parameterValue + ") AS dpT ";
                        //    }
                        //    else
                        //    {
                        //        addTabalWithCol += " CROSS JOIN Department AS dpT ";
                        //    }
                        //    addConditionWithCol += " AND dpT.DepartmentID = TA.DepartmentID ";
                        //    addColWithCol += " ,dpT.DepartmentID ,dpT.DepartmentName ";
                        //}
                    }
                }
            }
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " WHERE " + whereSql;
            }
            sql = @"

IF OBJECT_ID('tempdb..#TempApplicant') IS NOT NULL
DROP TABLE #TempApplicant

SELECT RegisterMonth,JFCaseTypeID,DepartmentID,ProvinceTypeCode
,dbo.[fn_ReportStatus](WorkStatus,KPIDay) AS ReportStatus
INTO #TempApplicant
FROM jfs_udf_tablestatistics() AS juT
 " + whereSql + @" 
SELECT CurrentIndex
,Month
,Month_TH
,Request
,[Finished_7] + Finished_21 AS Finished_21
,[Finished_22-30]
,[Finished_31-45]
,Finished_Over45
,Work_21
,Work_Over21
,Spoof
,( Request +[Finished_7] + Finished_21 + [Finished_22-30] 
+ [Finished_31-45] + Finished_Over45 
+ Work_21 + Work_Over21 + Spoof ) AS Total_Case
FROM (
SELECT 
juM.CurrentIndex
,juM.Month
,juM.Month_TH
" + addColWithCol + @"
,TA.ReportStatus
FROM dbo.jfs_udf_Month() AS juM
" + addTabalWithCol + @" 
LEFT JOIN #TempApplicant AS TA
ON juM.Month = TA.RegisterMonth
" + addConditionWithCol + @" 
) AS Tb
PIVOT (COUNT(ReportStatus)
FOR [ReportStatus] IN ([Request]
,[Finished_7],[Finished_21],[Finished_22-30]
,[Finished_31-45],[Finished_Over45]
,[Work_21],[Work_Over21],[Spoof])
) AS pvt

ORDER BY CurrentIndex

";
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }

        public DataTable GetListJFCaseDataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql = "")
        {
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " WHERE " + whereSql;
            }
            sql = @"
SELECT * FROM (
SELECT *
,dbo.[fn_ReportStatus](WorkStatus,KPIDay) AS ReportStatus
FROM jfs_udf_tablestatistics() AS juT ) TB
 " + whereSql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }

        public DataTable GetListJFCaseDataTableV2(List<SqlParameter> sqlParameter, string whereSql, string orderBySql = "")
        {
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " WHERE " + whereSql;
            }
            sql = @"



IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
DROP TABLE #allCaseRegister

SELECT 
CAT.CaseID
,CA.ApplicantID
,CA.Title
,CA.FirstName
,CA.LastName
,ISNULL(CA.DeletedFlag,0) AS DeletedFlag
,CAT.RegisterDate
,CAT.JFCaseTypeID
,JFT.CaseTypeNameAbbr
,COD.DepartmentID
,D.DepartmentName
,COD.StatusID
,COD.WorkStepID
,ISNULL(CAMOD.JFCaseNo,'') AS JFCaseNo
,CaseMeetingMinutes.MeetingDate AS  DecisionDate
,StartStep.ChangeDate AS StartDate
INTO #allCaseRegister
FROM
CaseApplication AS CAT
INNER JOIN 
CaseApplicant AS CA 
ON CAT.CaseID = CA.CaseID 
LEFT JOIN
CaseApplicantExtension AS CAE
ON CA.ApplicantID = CAE.ApplicantID
LEFT JOIN
CardType AS CT
ON CAE.CardType = CT.CardTypeID
LEFT JOIN 
(
SELECT 
CaseID
,DepartmentID
,WorkStepID
,StatusID 
,IsAppeal
FROM 
CaseOwnerDepartment 
WHERE StatusID != 6
) AS COD
ON CA.CaseID = COD.CaseID
LEFT JOIN
CaseApplicantMapOwnerDepartment AS CAMOD
ON CA.ApplicantID = CAMOD.ApplicantID AND COD.DepartmentID = CAMOD.DepartmentID  
LEFT JOIN 
CaseApplicationStatus AS CAS
ON COD.StatusID = CAS.CaseApplicationStatusID
LEFT JOIN 
Department AS D
ON COD.DepartmentID = D.DepartmentID
LEFT JOIN 
JFCaseType AS JFT
ON CAT.JFCaseTypeID = JFT.JFCaseTypeID
LEFT JOIN
CaseMeetingMinutes 
ON CAT.CaseID = CaseMeetingMinutes.CaseID AND CA.ApplicantID = CaseMeetingMinutes.ApplicantID
LEFT JOIN (
SELECT CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID,
		  MAX(ChangeDate) ChangeDate
   FROM CaseChangeWorkStepHistory CCW
   INNER JOIN (SELECT CaseID,
				WorkStepID,
				DepartmentID,
				MAX(ModifiedDate) ModifiedDate 
		  FROM CaseChangeWorkStepHistory 
		  WHERE WorkStepID = 2
		  GROUP BY CaseID,
				WorkStepID,
				DepartmentID) MDX
	ON CCW.ModifiedDate = MDX.ModifiedDate
   WHERE CCW.WorkStepID = 2 
   GROUP BY CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID
) AS StartStep 
ON CAT.CaseID = StartStep.CaseID 
AND COD.DepartmentID = StartStep.DepartmentID



IF OBJECT_ID('tempdb..#allCaseRegisterFilter') IS NOT NULL
DROP TABLE #allCaseRegisterFilter

SELECT
*
,CASE 
    WHEN ABS(DATEDIFF(Day,StartDate,GETDATE())) BETWEEN 0 AND 21 THEN 'WorkKPI_21'
    ELSE 'WorkKPI_Over21'
END AS KPIStatus
,MONTH(RegisterDate) AS ThaiMonthFinance
INTO #allCaseRegisterFilter
FROM #allCaseRegister
WHERE
DeletedFlag != 1
AND JFCaseTypeID != 5
AND JFCaseNo NOT LIKE '%สกย%'
AND WorkStepID > 1
AND DecisionDate IS NULL
--- ค้นหาจากวันที่รับเรื่อง

SELECT * FROM #allCaseRegisterFilter
 " + whereSql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }
        public DataTable GetListJFCaseFinishedKPIDataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql = "")
        {
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " WHERE " + whereSql;
            }
            sql = @"







IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
DROP TABLE #allCaseRegister

SELECT 
CAT.CaseID
,CA.ApplicantID
,CA.Title
,CA.FirstName
,CA.LastName
,ISNULL(CA.DeletedFlag,0) AS DeletedFlag
,CAT.RegisterDate
,CAT.JFCaseTypeID
,JFT.CaseTypeNameAbbr
,COD.DepartmentID
,D.DepartmentName
,COD.StatusID
,COD.WorkStepID
,ISNULL(CAMOD.JFCaseNo,'') AS JFCaseNo
,CaseMeetingMinutes.MeetingDate AS  DecisionDate
,StartStep.ChangeDate AS StartDate
INTO #allCaseRegister
FROM
CaseApplication AS CAT
INNER JOIN 
CaseApplicant AS CA 
ON CAT.CaseID = CA.CaseID 
LEFT JOIN
CaseApplicantExtension AS CAE
ON CA.ApplicantID = CAE.ApplicantID
LEFT JOIN
CardType AS CT
ON CAE.CardType = CT.CardTypeID
LEFT JOIN 
(
SELECT 
CaseID
,DepartmentID
,WorkStepID
,StatusID 
,IsAppeal
FROM 
CaseOwnerDepartment 
WHERE StatusID != 6
) AS COD
ON CA.CaseID = COD.CaseID
LEFT JOIN
CaseApplicantMapOwnerDepartment AS CAMOD
ON CA.ApplicantID = CAMOD.ApplicantID AND COD.DepartmentID = CAMOD.DepartmentID  
LEFT JOIN 
CaseApplicationStatus AS CAS
ON COD.StatusID = CAS.CaseApplicationStatusID
LEFT JOIN 
Department AS D
ON COD.DepartmentID = D.DepartmentID
LEFT JOIN 
JFCaseType AS JFT
ON CAT.JFCaseTypeID = JFT.JFCaseTypeID
LEFT JOIN
CaseMeetingMinutes 
ON CAT.CaseID = CaseMeetingMinutes.CaseID AND CA.ApplicantID = CaseMeetingMinutes.ApplicantID
LEFT JOIN (
SELECT CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID,
		  MAX(ChangeDate) ChangeDate
   FROM CaseChangeWorkStepHistory CCW
   INNER JOIN (SELECT CaseID,
				WorkStepID,
				DepartmentID,
				MAX(ModifiedDate) ModifiedDate 
		  FROM CaseChangeWorkStepHistory 
		  WHERE WorkStepID = 2
		  GROUP BY CaseID,
				WorkStepID,
				DepartmentID) MDX
	ON CCW.ModifiedDate = MDX.ModifiedDate
   WHERE CCW.WorkStepID = 2 
   GROUP BY CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID
) AS StartStep 
ON CAT.CaseID = StartStep.CaseID 
AND COD.DepartmentID = StartStep.DepartmentID



IF OBJECT_ID('tempdb..#allCaseRegisterFilter') IS NOT NULL
DROP TABLE #allCaseRegisterFilter

SELECT
*
,CASE 
    WHEN ABS(DATEDIFF(Day,StartDate,DecisionDate)) BETWEEN 0 AND 21 THEN 'FinishedKPI_21'
    WHEN ABS(DATEDIFF(Day,StartDate,DecisionDate)) BETWEEN 22 AND 30 THEN 'FinishedKPI_22-30'
    WHEN ABS(DATEDIFF(Day,StartDate,DecisionDate)) BETWEEN 31 AND 45 THEN 'FinishedKPI_31-45'
    WHEN ABS(DATEDIFF(Day,StartDate,DecisionDate)) IS NULL THEN 'NON_Finished'
    ELSE 'FinishedKPI_Over45'
END AS KPIStatus
,MONTH(RegisterDate) AS ThaiMonthFinance
INTO #allCaseRegisterFilter
FROM #allCaseRegister
WHERE
DeletedFlag != 1
AND JFCaseTypeID != 5
AND JFCaseNo NOT LIKE '%สกย%'
AND WorkStepID > 1
AND DecisionDate IS NOT NULL
--- ค้นหาจากวันที่รับเรื่อง

SELECT * FROM #allCaseRegisterFilter
 " + whereSql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }
        public DataTable GetListJFCaseFinishedKPI7DataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql = "")
        {
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " WHERE " + whereSql;
            }
            sql = @"

IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
DROP TABLE #allCaseRegister

SELECT 
CAT.CaseID
,CA.ApplicantID
,CA.Title
,CA.FirstName
,CA.LastName
,ISNULL(CA.DeletedFlag,0) AS DeletedFlag
,CAT.RegisterDate
,CAT.JFCaseTypeID
,JFT.CaseTypeNameAbbr
,COD.DepartmentID
,D.DepartmentName
,COD.StatusID
,COD.WorkStepID
,ISNULL(CAMOD.JFCaseNo,'') AS JFCaseNo
,CaseMeetingMinutes.MeetingDate AS  DecisionDate
,StartStep.ChangeDate AS StartDate
,EndStep.ChangeDate AS EndDate
INTO #allCaseRegister
FROM
CaseApplication AS CAT
INNER JOIN 
CaseApplicant AS CA 
ON CAT.CaseID = CA.CaseID 
LEFT JOIN
CaseApplicantExtension AS CAE
ON CA.ApplicantID = CAE.ApplicantID
LEFT JOIN
CardType AS CT
ON CAE.CardType = CT.CardTypeID
LEFT JOIN 
(
SELECT 
CaseID
,DepartmentID
,WorkStepID
,StatusID 
,IsAppeal
FROM 
CaseOwnerDepartment 
WHERE StatusID != 6
) AS COD
ON CA.CaseID = COD.CaseID
LEFT JOIN
CaseApplicantMapOwnerDepartment AS CAMOD
ON CA.ApplicantID = CAMOD.ApplicantID AND COD.DepartmentID = CAMOD.DepartmentID  
LEFT JOIN 
CaseApplicationStatus AS CAS
ON COD.StatusID = CAS.CaseApplicationStatusID
LEFT JOIN 
Department AS D
ON COD.DepartmentID = D.DepartmentID
LEFT JOIN 
JFCaseType AS JFT
ON CAT.JFCaseTypeID = JFT.JFCaseTypeID
LEFT JOIN
CaseMeetingMinutes 
ON CAT.CaseID = CaseMeetingMinutes.CaseID AND CA.ApplicantID = CaseMeetingMinutes.ApplicantID
LEFT JOIN (
SELECT CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID,
		  MAX(ChangeDate) ChangeDate
   FROM CaseChangeWorkStepHistory CCW
   INNER JOIN (SELECT CaseID,
				WorkStepID,
				DepartmentID,
				MAX(ModifiedDate) ModifiedDate 
		  FROM CaseChangeWorkStepHistory 
		  WHERE WorkStepID = 4
		  GROUP BY CaseID,
				WorkStepID,
				DepartmentID) MDX
	ON CCW.ModifiedDate = MDX.ModifiedDate
   WHERE CCW.WorkStepID = 4
   GROUP BY CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID
) AS StartStep 
ON CAT.CaseID = StartStep.CaseID 
AND COD.DepartmentID = StartStep.DepartmentID

LEFT JOIN (SELECT CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID,
		  MAX(ChangeDate) ChangeDate
   FROM CaseChangeWorkStepHistory CCW
   INNER JOIN (SELECT CaseID,
				WorkStepID,
				DepartmentID,
				MAX(ModifiedDate) ModifiedDate 
		  FROM CaseChangeWorkStepHistory 
		  WHERE WorkStepID = 6
		  GROUP BY CaseID,
				WorkStepID,
				DepartmentID) MDX
	ON CCW.ModifiedDate = MDX.ModifiedDate
   WHERE CCW.WorkStepID = 6
   GROUP BY CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID
) AS EndStep ON CAT.CaseID = EndStep.CaseID 
AND COD.DepartmentID = EndStep.DepartmentID


IF OBJECT_ID('tempdb..#allCaseRegisterFilter') IS NOT NULL
DROP TABLE #allCaseRegisterFilter

SELECT
*
,CASE 
    WHEN ABS(DATEDIFF(Day,StartDate,EndDate))+1 BETWEEN 0 AND 7 THEN 'FinishedKPI_7'
    WHEN ABS(DATEDIFF(Day,StartDate,EndDate))+1 BETWEEN 8 AND 21 THEN 'FinishedKPI_8_21'
    WHEN ABS(DATEDIFF(Day,StartDate,EndDate))+1 BETWEEN 22 AND 30 THEN 'FinishedKPI_22-30'
    WHEN ABS(DATEDIFF(Day,StartDate,EndDate))+1 BETWEEN 31 AND 45 THEN 'FinishedKPI_31-45'
    WHEN ABS(DATEDIFF(Day,StartDate,EndDate))+1 IS NULL THEN 'NON_Finished'
    ELSE 'FinishedKPI_Over45'
END AS KPIStatus
,CASE 
    WHEN ABS(DATEDIFF(Day,StartDate,EndDate))+1 BETWEEN 0 AND 21 THEN 'FinishedTotal7_21'
    ELSE 'FinishedKPI_Over7_21'
END AS KPISubStatus
,MONTH(RegisterDate) AS ThaiMonthFinance
INTO #allCaseRegisterFilter
FROM #allCaseRegister
WHERE
DeletedFlag != 1
AND JFCaseTypeID != 5
AND JFCaseNo NOT LIKE '%สกย%'
AND WorkStepID > 1
AND DecisionDate IS NOT NULL
--- ค้นหาจากวันที่รับเรื่อง

SELECT *
FROM #allCaseRegisterFilter
 " + whereSql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }
        #endregion

        #region ReportCategory
        public DataTable GetReportCategoryDataTable(List<SqlParameter> sqlParameter, string whereSql, string[] col = null, string orderBySql = "")
        {
            string[] cols = col;
            string addTabalWithCol = "";
            string addConditionWithCol = "";
            string addColWithCol = "";
            if (cols != null)
            {
                foreach (var item in cols)
                {
                    if (string.IsNullOrWhiteSpace(addTabalWithCol) && string.IsNullOrWhiteSpace(addConditionWithCol))
                    {
                        if (item == "JFCaseTypeID")
                        {
                            if (sqlParameter.Find(o => o.ParameterName == "@JFCaseTypeID") != null)
                            {
                                var parameterValue = sqlParameter.Find(o => o.ParameterName == "@JFCaseTypeID").Value;
                                addTabalWithCol = " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 AND JFCaseTypeID = " + parameterValue + ") jcT ";
                            }
                            else
                            {
                                addTabalWithCol = " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 ) jcT ";
                            }
                            addConditionWithCol = " AND jcT.JFCaseTypeID = TA.JFCaseTypeID ";
                            addColWithCol = " ,jcT.JFCaseTypeID ,jcT.CaseTypeName ";
                        }

                    }
                    else
                    {
                        if (item == "JFCaseTypeID")
                        {
                            if (sqlParameter.Find(o => o.ParameterName == "@JFCaseTypeID") != null)
                            {
                                var parameterValue = sqlParameter.Find(o => o.ParameterName == "@JFCaseTypeID").Value;
                                addTabalWithCol += " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 AND JFCaseTypeID = " + parameterValue + ") jcT ";
                            }
                            else
                            {
                                addTabalWithCol += " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 ) jcT ";
                            }
                            addConditionWithCol += " AND jcT.JFCaseTypeID = TA.JFCaseTypeID ";
                            addColWithCol += " ,jcT.JFCaseTypeID ,jcT.CaseTypeName ";
                        }
                        else if (item == "ProvinceTypeName" || item == "DepartmentName")
                        {
                            string valueWhereParameter = "";

                            if (sqlParameter.Find(o => o.ParameterName == "@ProvinceType") != null)
                            {
                                var parameterValue = sqlParameter.Find(o => o.ParameterName == "@ProvinceType").Value;
                            }
                            if (sqlParameter.Find(o => o.ParameterName == "@DepartmentID") != null)
                            {
                                var parameterValue = sqlParameter.Find(o => o.ParameterName == "@DepartmentID").Value;
                            }

                        }

                    }
                }
            }
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " AND " + whereSql;
            }
            sql = @"


IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
DROP TABLE #allCaseRegister

select 
CAT.CaseID
,CA.ApplicantID
,ISNULL(CA.DeletedFlag,0) AS DeletedFlag
,CAT.RegisterDate
,CAT.JFCaseTypeID
,COD.DepartmentID
,COD.StatusID
,COD.WorkStepID
,ISNULL(CAMOD.JFCaseNo,'') AS JFCaseNo
,CaseMeetingMinutes.MeetingDate AS  DecisionDate
,CMCC.CaseCategoryID
,CMCC.CaseSubCategoryID

INTO #allCaseRegister
from
CaseApplication AS CAT
INNER JOIN 
CaseApplicant AS CA 
ON CAT.CaseID = CA.CaseID 
LEFT JOIN
CaseApplicantExtension AS CAE
ON CA.ApplicantID = CAE.ApplicantID
LEFT JOIN
CardType AS CT
ON CAE.CardType = CT.CardTypeID
LEFT JOIN 
(
select 
CaseID
,DepartmentID
,WorkStepID
,StatusID 
,IsAppeal
from 
CaseOwnerDepartment 
Where StatusID != 6
) AS COD
ON CA.CaseID = COD.CaseID
LEFT JOIN
CaseApplicantMapOwnerDepartment AS CAMOD
ON CA.ApplicantID = CAMOD.ApplicantID AND COD.DepartmentID = CAMOD.DepartmentID  
LEFT JOIN 
CaseApplicationStatus AS CAS
ON COD.StatusID = CAS.CaseApplicationStatusID
LEFT JOIN
CaseMeetingMinutes 
ON CAT.CaseID = CaseMeetingMinutes.CaseID AND CA.ApplicantID = CaseMeetingMinutes.ApplicantID
LEFT JOIN CaseMapCaseCategory CMCC
ON CAT.CaseID = CMCC.CaseID




IF OBJECT_ID('tempdb..#allCaseRegisterFilter') IS NOT NULL
DROP TABLE #allCaseRegisterFilter

SELECT
*
INTO #allCaseRegisterFilter
FROM #allCaseRegister
WHERE
DeletedFlag != 1
AND JFCaseTypeID != 5
AND JFCaseNo NOT LIKE '%สกย%'
--- ค้นหาจากวันที่รับเรื่อง
" + whereSql + @"

IF OBJECT_ID('tempdb..#Total') IS NOT NULL
 DROP TABLE #Total

 SELECT
 CaseCategory.CaseCategoryID AS 'CategoryID'
 , CaseCategory.CategoryName AS 'CategoryName'
 , COUNT(CaseID) AS 'CountCase' 
 INTO #Total
 FROM CaseCategory
 left outer join  #allCaseRegisterFilter 
 ON #allCaseRegisterFilter.CaseCategoryID = CaseCategory.CaseCategoryID
 GROUP BY CaseCategory.CaseCategoryID , CaseCategory.CategoryName

 IF OBJECT_ID('tempdb..#GrandTotal') IS NOT NULL
 DROP TABLE #GrandTotal


 SELECT 
 99 AS [CategoryID]
 ,'รวมทั้งหมด' AS [CategoryName]
 ,SUM([CountCase]) AS [CountCase]
 INTO #GrandTotal
 FROM #Total

 SELECT * FROM #Total 
 UNION
 SELECT * FROM #GrandTotal










";
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }
        #endregion


        #region StatisticsSevenDayCaseProcess
        public DataTable GetReportCaseSevenDayDataTable(List<SqlParameter> sqlParameter, string whereSql, string[] col = null, string orderBySql = "")
        {
            string[] cols = col;
            string addTabalWithCol = "";
            string addConditionWithCol = "";
            string addColWithCol = "";
            if (cols != null)
            {
                foreach (var item in cols)
                {
                    if (string.IsNullOrWhiteSpace(addTabalWithCol) && string.IsNullOrWhiteSpace(addConditionWithCol))
                    {
                        if (item == "JFCaseTypeID")
                        {
                            if (sqlParameter.Find(o => o.ParameterName == "@JFCaseTypeID") != null)
                            {
                                var parameterValue = sqlParameter.Find(o => o.ParameterName == "@JFCaseTypeID").Value;
                                addTabalWithCol = " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 AND JFCaseTypeID = " + parameterValue + ") jcT ";
                            }
                            else
                            {
                                addTabalWithCol = " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 ) jcT ";
                            }
                            addConditionWithCol = " AND jcT.JFCaseTypeID = TA.JFCaseTypeID ";
                            addColWithCol = " ,jcT.JFCaseTypeID ,jcT.CaseTypeName ";
                        }


                    }
                    else
                    {
                        if (item == "JFCaseTypeID")
                        {
                            if (sqlParameter.Find(o => o.ParameterName == "@JFCaseTypeID") != null)
                            {
                                var parameterValue = sqlParameter.Find(o => o.ParameterName == "@JFCaseTypeID").Value;
                                addTabalWithCol += " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 AND JFCaseTypeID = " + parameterValue + ") jcT ";
                            }
                            else
                            {
                                addTabalWithCol += " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 ) jcT ";
                            }
                            addConditionWithCol += " AND jcT.JFCaseTypeID = TA.JFCaseTypeID ";
                            addColWithCol += " ,jcT.JFCaseTypeID ,jcT.CaseTypeName ";
                        }
                        else if (item == "ProvinceTypeName" || item == "DepartmentName")
                        {
                            string valueWhereParameter = "";

                            if (sqlParameter.Find(o => o.ParameterName == "@ProvinceType") != null)
                            {
                                var parameterValue = sqlParameter.Find(o => o.ParameterName == "@ProvinceType").Value;
                            }
                            if (sqlParameter.Find(o => o.ParameterName == "@DepartmentID") != null)
                            {
                                var parameterValue = sqlParameter.Find(o => o.ParameterName == "@DepartmentID").Value;
                            }

                        }

                    }
                }
            }
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " AND " + whereSql;
            }
            sql = @"



IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
DROP TABLE #allCaseRegister

select 
CAT.CaseID
,CA.ApplicantID
,ISNULL(CA.DeletedFlag,0) AS DeletedFlag
,CAT.RegisterDate
,CAT.JFCaseTypeID
,COD.DepartmentID
,COD.StatusID
,COD.WorkStepID
,ISNULL(CAMOD.JFCaseNo,'') AS JFCaseNo
,CaseMeetingMinutes.MeetingDate AS  DecisionDate

INTO #allCaseRegister
from
CaseApplication AS CAT
INNER JOIN 
CaseApplicant AS CA 
ON CAT.CaseID = CA.CaseID 
LEFT JOIN
CaseApplicantExtension AS CAE
ON CA.ApplicantID = CAE.ApplicantID
LEFT JOIN
CardType AS CT
ON CAE.CardType = CT.CardTypeID
LEFT JOIN 
(
select 
CaseID
,DepartmentID
,WorkStepID
,StatusID 
,IsAppeal
from 
CaseOwnerDepartment 
Where StatusID != 6
) AS COD
ON CA.CaseID = COD.CaseID
LEFT JOIN
CaseApplicantMapOwnerDepartment AS CAMOD
ON CA.ApplicantID = CAMOD.ApplicantID AND COD.DepartmentID = CAMOD.DepartmentID  
LEFT JOIN 
CaseApplicationStatus AS CAS
ON COD.StatusID = CAS.CaseApplicationStatusID
LEFT JOIN
CaseMeetingMinutes 
ON CAT.CaseID = CaseMeetingMinutes.CaseID AND CA.ApplicantID = CaseMeetingMinutes.ApplicantID




IF OBJECT_ID('tempdb..#allCaseRegisterFilter') IS NOT NULL
DROP TABLE #allCaseRegisterFilter

SELECT
*
INTO #allCaseRegisterFilter
FROM #allCaseRegister
WHERE
DeletedFlag != 1
AND JFCaseTypeID != 5
AND JFCaseNo NOT LIKE '%สกย%'
--- ค้นหาจากวันที่รับเรื่อง
" + whereSql + @"


IF OBJECT_ID('tempdb..#tempMonthFinance') IS NOT NULL
DROP TABLE #tempMonthFinance

DECLARE @StartMonth INT
SET @StartMonth = 0
DECLARE @CurrentMonth INT
SET @CurrentMonth = 0
CREATE TABLE #tempMonthFinance (CurrentIndex INT,MonthFinance INT)  
WHILE (@StartMonth < 12)
BEGIN
IF @StartMonth > 2
BEGIN
   insert into #tempMonthFinance VALUES(@StartMonth+1,@CurrentMonth+1) 
   SET @CurrentMonth = @CurrentMonth+1
END
ELSE
BEGIN
   insert into #tempMonthFinance VALUES(@StartMonth+1,10+@StartMonth) 
END
    SET @StartMonth = @StartMonth + 1;
END



IF OBJECT_ID('tempdb..#tempTotalCase') IS NOT NULL
DROP TABLE #tempTotalCase

select tmF.MonthFinance,COUNT(CaseID) AS TotalCase
INTO #tempTotalCase
from #tempMonthFinance AS tmF
INNER JOIN 
(
select 
ACRF.CaseID
,CASE
    WHEN MONTH(ACRF.RegisterDate) < 10 THEN YEAR(ACRF.RegisterDate) + 543
    ELSE YEAR(ACRF.RegisterDate) + 543 +1
END AS ThaiYearFinance
,MONTH(ACRF.RegisterDate) AS ThaiMonthFinance
from 
#allCaseRegisterFilter AS ACRF

)
AS tacR
ON tmF.MonthFinance = tacR.ThaiMonthFinance 
Group By tmF.MonthFinance
IF OBJECT_ID('tempdb..#tempCaseFinishedKPI') IS NOT NULL
DROP TABLE #tempCaseFinishedKPI

select
aCRF.CaseID 
,CASE 
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,EndStep.ChangeDate))+1 BETWEEN 0 AND 7 THEN 'FinishedKPI_7'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,EndStep.ChangeDate))+1 BETWEEN 8 AND 21 THEN 'FinishedKPI_8_21'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,EndStep.ChangeDate))+1 BETWEEN 22 AND 30 THEN 'FinishedKPI_22-30'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,EndStep.ChangeDate))+1 BETWEEN 31 AND 45 THEN 'FinishedKPI_31-45'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,EndStep.ChangeDate))+1 IS NULL THEN 'NON_Finished'
    ELSE 'FinishedKPI_Over45'
END AS KPIStatus
,MONTH(aCRF.RegisterDate) AS ThaiMonthFinance
INTO #tempCaseFinishedKPI
from 
(
select * from 
#allCaseRegisterFilter Where WorkStepID > 1 AND DecisionDate IS NOT NULL
)AS aCRF
LEFT JOIN (SELECT CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID,
		  MAX(ChangeDate) ChangeDate
   FROM CaseChangeWorkStepHistory CCW
   INNER JOIN (SELECT CaseID,
				WorkStepID,
				DepartmentID,
				MAX(ModifiedDate) ModifiedDate 
		  FROM CaseChangeWorkStepHistory 
		  WHERE WorkStepID = 4
		  GROUP BY CaseID,
				WorkStepID,
				DepartmentID) MDX
	ON CCW.ModifiedDate = MDX.ModifiedDate
   WHERE CCW.WorkStepID = 4 
   GROUP BY CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID
) AS StartStep ON aCRF.CaseID = StartStep.CaseID AND aCRF.DepartmentID = StartStep.DepartmentID
LEFT JOIN (SELECT CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID,
		  MAX(ChangeDate) ChangeDate
   FROM CaseChangeWorkStepHistory CCW
   INNER JOIN (SELECT CaseID,
				WorkStepID,
				DepartmentID,
				MAX(ModifiedDate) ModifiedDate 
		  FROM CaseChangeWorkStepHistory 
		  WHERE WorkStepID = 6
		  GROUP BY CaseID,
				WorkStepID,
				DepartmentID) MDX
	ON CCW.ModifiedDate = MDX.ModifiedDate
   WHERE CCW.WorkStepID = 6
   GROUP BY CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID
) AS EndStep ON aCRF.CaseID = EndStep.CaseID AND aCRF.DepartmentID = EndStep.DepartmentID

IF OBJECT_ID('tempdb..#tempFinished') IS NOT NULL
DROP TABLE #tempFinished

select ThaiMonthFinance,[FinishedKPI_7],[FinishedKPI_8_21],[FinishedKPI_22-30],[FinishedKPI_31-45],[FinishedKPI_Over45]
INTO #tempFinished
from 
#tempCaseFinishedKPI
PIVOT (count(CaseID)
FOR KPIStatus IN ([FinishedKPI_7],[FinishedKPI_8_21],[FinishedKPI_22-30],[FinishedKPI_31-45],[FinishedKPI_Over45])
) AS pvt


IF OBJECT_ID('tempdb..#tempCaseWorkingKPI') IS NOT NULL
DROP TABLE #tempCaseWorkingKPI

select
aCRF.CaseID 
,CASE 
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,GETDATE())) BETWEEN 0 AND 21 THEN 'WorkKPI_21'
    ELSE 'WorkKPI_Over21'
END AS KPIStatus
,MONTH(aCRF.RegisterDate) AS ThaiMonthFinance
INTO #tempCaseWorkingKPI
from 
(
select * from 
#allCaseRegisterFilter Where WorkStepID > 1 AND DecisionDate IS NULL
)AS aCRF
LEFT JOIN (
select CaseID,WorkStepID,DepartmentID,MIN(ChangeDate) AS ChangeDate 
from CaseChangeWorkStepHistory Where WorkStepID = 2 Group by CaseID,WorkStepID,DepartmentID
) AS StartStep ON aCRF.CaseID = StartStep.CaseID AND aCRF.DepartmentID = StartStep.DepartmentID



IF OBJECT_ID('tempdb..#tempCaseWork') IS NOT NULL
DROP TABLE #tempCaseWork


select ThaiMonthFinance,[WorkKPI_21],[WorkKPI_Over21]
INTO #tempCaseWork
from 
#tempCaseWorkingKPI
PIVOT (count(CaseID)
FOR KPIStatus IN ([WorkKPI_21],[WorkKPI_Over21])
) AS pvt


IF OBJECT_ID('tempdb..#tempTotalCaseRequest') IS NOT NULL
DROP TABLE #tempTotalCaseRequest

select tmF.MonthFinance,COUNT(CaseID) AS TotalCase
INTO #tempTotalCaseRequest
from #tempMonthFinance AS tmF
INNER JOIN 
(
select 
ACRF.CaseID
,CASE
    WHEN MONTH(ACRF.RegisterDate) < 10 THEN YEAR(ACRF.RegisterDate) + 543
    ELSE YEAR(ACRF.RegisterDate) + 543 +1
END AS ThaiYearFinance
,MONTH(ACRF.RegisterDate) AS ThaiMonthFinance
from 
(select * from #allCaseRegisterFilter Where WorkStepID = 1 AND DecisionDate IS NULL) AS ACRF

)
AS tacR
ON tmF.MonthFinance = tacR.ThaiMonthFinance 
Group By tmF.MonthFinance

IF OBJECT_ID('tempdb..#tempMonth') IS NOT NULL
DROP TABLE #tempMonth

DECLARE @MonthNo INT
SET @MonthNo = 1
DECLARE @Month NVARCHAR(150)
SET @Month = ''
CREATE TABLE #tempMonth (MonthFinance INT,MonthTH NVARCHAR(150))  
WHILE ( @MonthNo <= 12)
BEGIN
SET @Month = CASE 
				WHEN @MonthNo = 1 THEN 'มกราคม'
				WHEN @MonthNo = 2 THEN 'กุมภาพันธ์'
				WHEN @MonthNo = 3 THEN 'มีนาคม'
				WHEN @MonthNo = 4 THEN 'เมษายน'
				WHEN @MonthNo = 5 THEN 'พฤษภาคม'
				WHEN @MonthNo = 6 THEN 'มิถุนายน'
				WHEN @MonthNo = 7 THEN 'กรกฎาคม'
				WHEN @MonthNo = 8 THEN 'สิงหาคม'
				WHEN @MonthNo = 9 THEN 'กันยายน'
				WHEN @MonthNo = 10 THEN 'ตุลาคม'
				WHEN @MonthNo = 11 THEN 'พฤศจิกายน'
				ELSE 'ธันวาคม'
			 END

INSERT INTO #tempMonth VALUES(@MonthNo,@Month)

SET @MonthNo = @MonthNo + 1;
END


IF OBJECT_ID('tempdb..#tempCaseResultToTable') IS NOT NULL
DROP TABLE #tempCaseResultToTable

select tmF.CurrentIndex
--------,tmF.MonthFinance
,tmMt.MonthTH,
MAX(ISNULL(tTCR.TotalCase,0)) AS 'TotalRequest',
MAX(ISNULL(tF.FinishedKPI_7,0)) AS 'FinishedKPI_7'
,Case
WHEN SUM(ISNULL(ttC.TotalCase,0)) - ( SUM(ISNULL(tTCR.TotalCase,0)) +  SUM(ISNULL(tcW.WorkKPI_21,0)) + SUM(ISNULL(tcW.WorkKPI_Over21,0))) > 0  
THEN Cast(Round((SUM(ISNULL(tF.FinishedKPI_7,0))*100.0)/(SUM(ISNULL(ttC.TotalCase,0)) - (SUM(ISNULL(tTCR.TotalCase,0)) + SUM(ISNULL(tcW.WorkKPI_21,0)) + SUM(ISNULL(tcW.WorkKPI_Over21,0)))),2) AS decimal (10,2)) 
ELSE 0.00
END AS PersentFinished7
,MAX(ISNULL(tF.FinishedKPI_8_21,0)) AS 'FinishedKPI_8_21'
,MAX(ISNULL(tF.FinishedKPI_7,0)) + MAX(ISNULL(tF.FinishedKPI_8_21,0)) AS 'Total7_21'
,MAX(ISNULL(tF.[FinishedKPI_22-30],0)) AS 'FinishedKPI_22-30'
,MAX(ISNULL(tF.[FinishedKPI_31-45],0)) AS 'FinishedKPI_31-45'
,MAX(ISNULL(tF.FinishedKPI_Over45,0)) AS 'FinishedKPI_Over45'
,MAX(ISNULL(tcW.WorkKPI_21,0)) AS 'WorkKPI_21'
,MAX(ISNULL(tcW.WorkKPI_Over21,0)) AS 'WorkKPI_Over21'
,MAX(ISNULL(ttC.TotalCase,0)) AS 'TotalCase'
INTO #tempCaseResultToTable
from #tempMonthFinance AS tmF
LEFT JOIN #tempTotalCase AS ttC
ON tmF.MonthFinance = ttC.MonthFinance
LEFT JOIN #tempCaseWork AS tcW
ON tmF.MonthFinance = tcW.ThaiMonthFinance
LEFT JOIN #tempFinished AS tF
ON tmF.MonthFinance = tF.ThaiMonthFinance
LEFT JOIN #tempTotalCaseRequest AS tTCR
ON tmF.MonthFinance = tTCR.MonthFinance
LEFT JOIN #tempMonth tmMt
ON tmF.MonthFinance = tmMt.MonthFinance
Group By tmF.CurrentIndex,tmF.MonthFinance ,tmMt.MonthTH
ORDER BY tmF.CurrentIndex ASC


Select 
CurrentIndex
--------,CONVERT(varchar(10),MonthFinance) MonthFinance
,MonthTH
,TotalRequest
,[FinishedKPI_7]
,PersentFinished7
,FinishedKPI_8_21
--,Total7_21 FinishedTotal7_21
,[FinishedKPI_22-30]
,[FinishedKPI_31-45]
,FinishedKPI_Over45
,WorkKPI_21
,WorkKPI_Over21
,TotalCase
from
#tempCaseResultToTable
UNION
select * from
(
select 
13 AS CurrentIndex
--------,'รวม' AS MonthFinance
,'รวม' AS MonthTH
,SUM(TotalRequest) AS 'TotalRquest'
,SUM([FinishedKPI_7]) AS 'FinishedKPI_7'
,Case
WHEN SUM(ISNULL(TotalCase,0)) - (SUM(ISNULL(TotalRequest,0)) + SUM(ISNULL(WorkKPI_21,0)) + SUM(ISNULL(WorkKPI_Over21,0)))  > 0  
THEN Cast(Round((SUM(ISNULL(FinishedKPI_7,0))*100.0)/(SUM(ISNULL(TotalCase,0)) - ( SUM(ISNULL(TotalRequest,0)) + SUM(ISNULL(WorkKPI_21,0)) + SUM(ISNULL(WorkKPI_Over21,0)))),2) AS decimal (10,2)) 
ELSE 0.00
END AS PersentFinished7
,SUM(FinishedKPI_8_21) AS 'FinishedKPI_8_21'
--,SUM(Total7_21) AS 'FinishedTotal7_21'
,SUM([FinishedKPI_22-30]) AS 'FinishedKPI_22-30'
,SUM([FinishedKPI_31-45]) AS 'FinishedKPI_31-45'
,SUM(FinishedKPI_Over45) AS 'FinishedKPI_Over45'
,SUM(WorkKPI_21) AS 'WorkKPI_21'
,SUM(WorkKPI_Over21) AS 'WorkKPI_Over21'
,SUM(TotalCase) AS 'TotalCase'
from 
#tempCaseResultToTable
) tb






";
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }

        public DataTable GetListJFCaseSevenDayDataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql = "")
        {
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " WHERE " + whereSql;
            }
            sql = @"
SELECT * FROM (
SELECT *
,dbo.[fn_ReportStatus](WorkStatus,KPIDay) AS ReportStatus
FROM jfs_udf_tablestatistics() AS juT ) TB
 " + whereSql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }
        #endregion

        #region SummaryAcceptbyMission
        public DataTable GetReportSummaryAcceptbyMissionDataTable(List<SqlParameter> sqlParameter, string whereSql, string[] col = null, string orderBySql = "")
        {
            string[] cols = col;
            string addTabalWithCol = "";
            string addConditionWithCol = "";
            string addColWithCol = "";
            if (cols != null)
            {
                foreach (var item in cols)
                {
                    if (string.IsNullOrWhiteSpace(addTabalWithCol) && string.IsNullOrWhiteSpace(addConditionWithCol))
                    {
                        if (item == "JFCaseTypeID")
                        {
                            addTabalWithCol = " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 ) jcT ";
                            addConditionWithCol = " AND jcT.JFCaseTypeID = TA.JFCaseTypeID ";
                            addColWithCol = " ,jcT.JFCaseTypeID ,jcT.CaseTypeName ";
                        }
                        else if (item == "ProvinceTypeName")
                        {

                            addTabalWithCol = " CROSS JOIN ProvinceType AS pvT ";
                            addConditionWithCol = " AND pvT.ProvinceTypeCode = TA.ProvinceTypeCode ";
                            addColWithCol = " ,pvT.ProvinceTypeCode ,pvT.ProvinceTypeName ";
                        }
                        else if (item == "DepartmentName")
                        {
                            addTabalWithCol = " CROSS JOIN Department AS dpT ";
                            addConditionWithCol = " AND dpT.DepartmentID = TA.DepartmentID ";
                            addColWithCol = " ,dpT.DepartmentID ,dpT.DepartmentName ";
                        }

                    }
                    else
                    {
                        if (item == "JFCaseTypeID")
                        {
                            addTabalWithCol += " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 ) jcT ";
                            addConditionWithCol += " AND jcT.JFCaseTypeID = TA.JFCaseTypeID ";
                            addColWithCol += " ,jcT.JFCaseTypeID ,jcT.CaseTypeName ";
                        }
                        else if (item == "ProvinceTypeName")
                        {
                            addTabalWithCol += " CROSS JOIN ProvinceType AS pvT ";
                            addConditionWithCol += " AND pvT.ProvinceTypeCode = TA.ProvinceTypeCode ";
                            addColWithCol += " ,pvT.ProvinceTypeCode ,pvT.ProvinceTypeName ";
                        }
                        else if (item == "DepartmentName")
                        {
                            addTabalWithCol += " CROSS JOIN Department AS dpT ";
                            addConditionWithCol += " AND dpT.DepartmentID = TA.DepartmentID ";
                            addColWithCol += " ,dpT.DepartmentID ,dpT.DepartmentName ";
                        }
                    }
                }
            }
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " WHERE " + whereSql;
            }
            sql = @"
SELECT CaseTypeName
    ,JFCaseTypeID
	,(Work_CENTRAL+Finish_CENTRAL) AS Request_CENTRAL
	,Finish_CENTRAL
	,(Work_NOT_CENTRAL+Finish_NOT_CENTRAL) AS Request_NOT_CENTRAL
	,Finish_NOT_CENTRAL
FROM
(
SELECT CaseID
,CaseTypeName
,JFCaseTypeID
,[dbo].[fn_CasefinishRegion](WorkStatus,ProvinceTypeCode) AS ReportType
FROM (
	SELECT * 
	FROM jfs_udf_tablestatistics()
	" + whereSql + @"
	) AS t
) AS Tb
PIVOT(
COUNT(CaseID) FOR ReportType
IN ([Work_CENTRAL]
	,[Finish_CENTRAL]
    ,[Work_NOT_CENTRAL]
	,[Finish_NOT_CENTRAL])
)AS PT
";
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }

        public DataTable GetListSummaryAcceptbyMissionDataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql = "")
        {
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " WHERE " + whereSql;
            }
            sql = @"
SELECT * FROM (
SELECT *
,[dbo].[fn_CasefinishRegion](WorkStatus,ProvinceTypeCode) AS ReportStatus
FROM jfs_udf_tablestatistics() AS juT ) TB
 " + whereSql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }
        #endregion

        #region SummaryAcceptbyRegion
        public DataTable GetReportSummaryAcceptbyRegionDataTable(List<SqlParameter> sqlParameter, string whereSql, string[] col = null, string orderBySql = "")
        {
            string[] cols = col;
            string addTabalWithCol = "";
            string addConditionWithCol = "";
            string addColWithCol = "";
            if (cols != null)
            {
                foreach (var item in cols)
                {
                    if (string.IsNullOrWhiteSpace(addTabalWithCol) && string.IsNullOrWhiteSpace(addConditionWithCol))
                    {
                        if (item == "JFCaseTypeID")
                        {
                            addTabalWithCol = " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 ) jcT ";
                            addConditionWithCol = " AND jcT.JFCaseTypeID = TA.JFCaseTypeID ";
                            addColWithCol = " ,jcT.JFCaseTypeID ,jcT.CaseTypeName ";
                        }
                        else if (item == "ProvinceTypeName")
                        {

                            addTabalWithCol = " CROSS JOIN ProvinceType AS pvT ";
                            addConditionWithCol = " AND pvT.ProvinceTypeCode = TA.ProvinceTypeCode ";
                            addColWithCol = " ,pvT.ProvinceTypeCode ,pvT.ProvinceTypeName ";
                        }
                        else if (item == "DepartmentName")
                        {
                            addTabalWithCol = " CROSS JOIN Department AS dpT ";
                            addConditionWithCol = " AND dpT.DepartmentID = TA.DepartmentID ";
                            addColWithCol = " ,dpT.DepartmentID ,dpT.DepartmentName ";
                        }

                    }
                    else
                    {
                        if (item == "JFCaseTypeID")
                        {
                            addTabalWithCol += " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 ) jcT ";
                            addConditionWithCol += " AND jcT.JFCaseTypeID = TA.JFCaseTypeID ";
                            addColWithCol += " ,jcT.JFCaseTypeID ,jcT.CaseTypeName ";
                        }
                        else if (item == "ProvinceTypeName")
                        {
                            addTabalWithCol += " CROSS JOIN ProvinceType AS pvT ";
                            addConditionWithCol += " AND pvT.ProvinceTypeCode = TA.ProvinceTypeCode ";
                            addColWithCol += " ,pvT.ProvinceTypeCode ,pvT.ProvinceTypeName ";
                        }
                        else if (item == "DepartmentName")
                        {
                            addTabalWithCol += " CROSS JOIN Department AS dpT ";
                            addConditionWithCol += " AND dpT.DepartmentID = TA.DepartmentID ";
                            addColWithCol += " ,dpT.DepartmentID ,dpT.DepartmentName ";
                        }
                    }
                }
            }
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " WHERE " + whereSql;
            }
            sql = @"
SELECT [dbo].[fu_ThaiRegionName](ProvinceTypeCode) AS ProvinceTypeCodeTH
,ProvinceTypeCode
,[Work]+[Finished] AS Request_Region
,[Finished] as Finished_Region
FROM
(
SELECT 	CaseID
,ProvinceTypeCode
,dbo.[fn_CheckFinish](WorkStatus) AS ReportStatus

FROM (
SELECT * FROM
jfs_udf_tablestatistics()
" + whereSql + @" ) AS TB
) AS T
PIVOT(
    COUNT(CaseID) 
    FOR ReportStatus IN (
        [Work], 
        [Finished])
) AS pivot_table

";
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }

        public DataTable GetListSummaryAcceptbyRegionDataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql = "")
        {
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " WHERE " + whereSql;
            }
            sql = @"
SELECT * FROM (
SELECT *
,dbo.[fn_CheckFinish](WorkStatus) AS ReportStatus
FROM jfs_udf_tablestatistics() AS juT ) TB
 " + whereSql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }
        #endregion

        #region ReportOverWork
        public DataTable GetReportOverWorkDataTable(List<SqlParameter> sqlParameter, string whereSql, string[] col = null, string orderBySql = "")
        {
            string[] cols = col;
            string addTabalWithCol = "";
            string addConditionWithCol = "";
            string addColWithCol = "";
            if (cols != null)
            {
                foreach (var item in cols)
                {
                    if (string.IsNullOrWhiteSpace(addTabalWithCol) && string.IsNullOrWhiteSpace(addConditionWithCol))
                    {
                        if (item == "JFCaseTypeID")
                        {
                            addTabalWithCol = " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 ) jcT ";
                            addConditionWithCol = " AND jcT.JFCaseTypeID = TA.JFCaseTypeID ";
                            addColWithCol = " ,jcT.JFCaseTypeID ,jcT.CaseTypeName ";
                        }
                        else if (item == "ProvinceTypeName")
                        {

                            addTabalWithCol = " CROSS JOIN ProvinceType AS pvT ";
                            addConditionWithCol = " AND pvT.ProvinceTypeCode = TA.ProvinceTypeCode ";
                            addColWithCol = " ,pvT.ProvinceTypeCode ,pvT.ProvinceTypeName ";
                        }
                        else if (item == "DepartmentName")
                        {
                            addTabalWithCol = " CROSS JOIN Department AS dpT ";
                            addConditionWithCol = " AND dpT.DepartmentID = TA.DepartmentID ";
                            addColWithCol = " ,dpT.DepartmentID ,dpT.DepartmentName ";
                        }

                    }
                    else
                    {
                        if (item == "JFCaseTypeID")
                        {
                            addTabalWithCol += " CROSS JOIN ( SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5 ) jcT ";
                            addConditionWithCol += " AND jcT.JFCaseTypeID = TA.JFCaseTypeID ";
                            addColWithCol += " ,jcT.JFCaseTypeID ,jcT.CaseTypeName ";
                        }
                        else if (item == "ProvinceTypeName")
                        {
                            addTabalWithCol += " CROSS JOIN ProvinceType AS pvT ";
                            addConditionWithCol += " AND pvT.ProvinceTypeCode = TA.ProvinceTypeCode ";
                            addColWithCol += " ,pvT.ProvinceTypeCode ,pvT.ProvinceTypeName ";
                        }
                        else if (item == "DepartmentName")
                        {
                            addTabalWithCol += " CROSS JOIN Department AS dpT ";
                            addConditionWithCol += " AND dpT.DepartmentID = TA.DepartmentID ";
                            addColWithCol += " ,dpT.DepartmentID ,dpT.DepartmentName ";
                        }
                    }
                }
            }
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " WHERE " + whereSql;
            }
            sql = @"
IF OBJECT_ID('tempdb..#TotalStatus') IS NOT NULL
DROP TABLE #TotalStatus

SELECT*
INTO #TotalStatus
FROM
(SELECT
	CaseID
	,DepartmentID
	,[dbo].[fn_ReportOverWork](WorkStepID) ReportStatus
	FROM
	(SELECT *
		FROM jfs_udf_tablestatistics() 
		WHERE EndWorkDate IS NULL) fnTB) TB
		PIVOT(
				COUNT(CaseID)
				FOR ReportStatus
				IN(
					[Total_Wait]
					,[Total_Lawyer]
					,[Total_Opinion]
					,[Step_ERROR]
				)
			)PV

IF OBJECT_ID('tempdb..#TotalKPI') IS NOT NULL
DROP TABLE #TotalKPI


SELECT *
INTO #TotalKPI
FROM
(SELECT
	CaseID
	,DepartmentID
	,[dbo].[fn_KPIStatus](KPIDay,fnTB.WorkStatus) KPIStatus
	FROM
	(SELECT *
		FROM jfs_udf_tablestatistics() 
		WHERE WorkStepID > 1 AND EndWorkDate IS NULL
	) fnTB
		) TB
PIVOT(
		COUNT(CaseID)
		FOR KPIStatus
		IN(
			[21]
			,[22-30]
			,[31-45]
			,[Over_45]
			,[NOT_KPI]
		)
	) PV

IF OBJECT_ID('tempdb..#Report') IS NOT NULL
DROP TABLE #Report


		SELECT #TotalStatus.DepartmentID
			,#TotalStatus.Total_Wait
			,#TotalStatus.Total_Lawyer
			,#TotalStatus.Total_Opinion
			,#TotalStatus.Step_ERROR
			,#TotalKPI.[21]
			,#TotalKPI.[22-30]
			,#TotalKPI.[31-45]
			,#TotalKPI.Over_45
			,#TotalKPI.NOT_KPI
		INTO #Report
		FROM #TotalKPI
		INNER JOIN #TotalStatus
		ON #TotalKPI.DepartmentID = #TotalStatus.DepartmentID


SELECT  D.DepartmentID
	,D.DepartmentName
	,PC.ProvinceTypeCode
	,ISNULL(#Report.Total_Wait,0) Total_Wait
	,ISNULL(#Report.Total_Lawyer,0) Total_Lawyer
	,ISNULL(#Report.Total_Opinion,0) Total_Opinion
	,ISNULL(#Report.Step_ERROR,0) Step_ERROR
	,ISNULL(#Report.[21],0) [21]
	,ISNULL(#Report.[22-30],0) [22-30]
	,ISNULL(#Report.[31-45],0) [31-45]
	,ISNULL(#Report.Over_45,0) Over_45
	,ISNULL(#Report.NOT_KPI,0) NOT_KPI
	,ISNULL((#Report.[21] + #Report.[22-30] + #Report.[31-45] + #Report.Over_45 + #Report.NOT_KPI),0)  Total_Outstanding
	FROM Department D
	LEFT JOIN #Report
	ON D.DepartmentID = #Report.DepartmentID
	INNER JOIN (
					SELECT P.ProvinceID
						,P.ProvinceName
						,PEX.ProvinceTypeCode
						FROM Province P
						INNER JOIN ProvinceExtension PEX
						ON P.ProvinceID = PEX.ProvinceID
				) PC
	ON D.ProvinceID = PC.ProvinceID
	--WHERE ProvinceTypeCode = 'BKK'

" + whereSql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }
        #endregion

        #region StatisticsSevenDayCaseProcessProvince
        public DataTable GetReportCaseSevenDayProvinceDataTable(List<SqlParameter> sqlParameter, string whereSql, string wheredepID = "", string orderBySql = "")
        {

            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " AND " + whereSql;
            }
            if (!string.IsNullOrEmpty(wheredepID))
            {
                wheredepID = "WHERE DepartmentID = " + wheredepID;
            }
            sql = @"





IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
DROP TABLE #allCaseRegister

select 
CAT.CaseID
,CA.ApplicantID
,ISNULL(CA.DeletedFlag,0) AS DeletedFlag
,CAT.RegisterDate
,CAT.JFCaseTypeID
,COD.DepartmentID
,COD.StatusID
,COD.WorkStepID
,ISNULL(CAMOD.JFCaseNo,'') AS JFCaseNo
,CaseMeetingMinutes.MeetingDate AS  DecisionDate

INTO #allCaseRegister
from
CaseApplication AS CAT
INNER JOIN 
CaseApplicant AS CA 
ON CAT.CaseID = CA.CaseID 
LEFT JOIN
CaseApplicantExtension AS CAE
ON CA.ApplicantID = CAE.ApplicantID
LEFT JOIN
CardType AS CT
ON CAE.CardType = CT.CardTypeID
LEFT JOIN 
(
select 
CaseID
,DepartmentID
,WorkStepID
,StatusID 
,IsAppeal
from 
CaseOwnerDepartment 
Where StatusID != 6
) AS COD
ON CA.CaseID = COD.CaseID
LEFT JOIN
CaseApplicantMapOwnerDepartment AS CAMOD
ON CA.ApplicantID = CAMOD.ApplicantID AND COD.DepartmentID = CAMOD.DepartmentID  
LEFT JOIN 
CaseApplicationStatus AS CAS
ON COD.StatusID = CAS.CaseApplicationStatusID
LEFT JOIN
CaseMeetingMinutes 
ON CAT.CaseID = CaseMeetingMinutes.CaseID AND CA.ApplicantID = CaseMeetingMinutes.ApplicantID




IF OBJECT_ID('tempdb..#allCaseRegisterFilter') IS NOT NULL
DROP TABLE #allCaseRegisterFilter

SELECT
*
INTO #allCaseRegisterFilter
FROM #allCaseRegister
WHERE
DeletedFlag != 1
AND JFCaseTypeID != 5
AND JFCaseNo NOT LIKE '%สกย%'
--- ค้นหาจากวันที่รับเรื่อง
" + whereSql + @"


 IF OBJECT_ID('tempdb..#tempTotalCase') IS NOT NULL
DROP TABLE #tempTotalCase

select D.DepartmentID,COUNT(CaseID) AS TotalCase
INTO #tempTotalCase
from Department AS D
INNER JOIN 
(
select 
ACRF.CaseID
,CASE
    WHEN MONTH(ACRF.RegisterDate) < 10 THEN YEAR(ACRF.RegisterDate) + 543
    ELSE YEAR(ACRF.RegisterDate) + 543 +1
END AS ThaiYearFinance
,ACRF.DepartmentID
from 
#allCaseRegisterFilter AS ACRF

)
AS tacR
ON D.DepartmentID = tacR.DepartmentID 
Group By D.DepartmentID




IF OBJECT_ID('tempdb..#tempCaseFinishedKPI') IS NOT NULL
DROP TABLE #tempCaseFinishedKPI

select
aCRF.CaseID 
,aCRF.DepartmentID
,CASE 
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,EndStep.ChangeDate))+1 BETWEEN 0 AND 7 THEN 'FinishedKPI_7'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,EndStep.ChangeDate))+1 BETWEEN 8 AND 21 THEN 'FinishedKPI_8_21'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,EndStep.ChangeDate))+1 BETWEEN 22 AND 30 THEN 'FinishedKPI_22-30'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,EndStep.ChangeDate))+1 BETWEEN 31 AND 45 THEN 'FinishedKPI_31-45'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,EndStep.ChangeDate))+1 IS NULL THEN 'NON_Finished'
    ELSE 'FinishedKPI_Over45'
END AS KPIStatus
INTO #tempCaseFinishedKPI
from 
(
select * from 
#allCaseRegisterFilter Where WorkStepID > 1 AND DecisionDate IS NOT NULL
)AS aCRF
LEFT JOIN (SELECT CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID,
		  MAX(ChangeDate) ChangeDate
   FROM CaseChangeWorkStepHistory CCW
   INNER JOIN (SELECT CaseID,
				WorkStepID,
				DepartmentID,
				MAX(ModifiedDate) ModifiedDate 
		  FROM CaseChangeWorkStepHistory 
		  WHERE WorkStepID = 4
		  GROUP BY CaseID,
				WorkStepID,
				DepartmentID) MDX
	ON CCW.ModifiedDate = MDX.ModifiedDate
   WHERE CCW.WorkStepID = 4 
   GROUP BY CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID
) AS StartStep ON aCRF.CaseID = StartStep.CaseID AND aCRF.DepartmentID = StartStep.DepartmentID
LEFT JOIN (SELECT CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID,
		  MAX(ChangeDate) ChangeDate
   FROM CaseChangeWorkStepHistory CCW
   INNER JOIN (SELECT CaseID,
				WorkStepID,
				DepartmentID,
				MAX(ModifiedDate) ModifiedDate 
		  FROM CaseChangeWorkStepHistory 
		  WHERE WorkStepID = 6
		  GROUP BY CaseID,
				WorkStepID,
				DepartmentID) MDX
	ON CCW.ModifiedDate = MDX.ModifiedDate
   WHERE CCW.WorkStepID = 6
   GROUP BY CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID
) AS EndStep ON aCRF.CaseID = EndStep.CaseID AND aCRF.DepartmentID = EndStep.DepartmentID

IF OBJECT_ID('tempdb..#tempTotalCaseRequest') IS NOT NULL
DROP TABLE #tempTotalCaseRequest

select D.DepartmentID,COUNT(CaseID) AS TotalCase
INTO #tempTotalCaseRequest
from Department AS D
INNER JOIN 
(
select 
ACRF.CaseID
,CASE
    WHEN MONTH(ACRF.RegisterDate) < 10 THEN YEAR(ACRF.RegisterDate) + 543
    ELSE YEAR(ACRF.RegisterDate) + 543 +1
END AS ThaiYearFinance
,ACRF.DepartmentID
from 
(select * from #allCaseRegisterFilter Where WorkStepID = 1 AND DecisionDate IS NULL) AS ACRF

)
AS tacR
ON D.DepartmentID = tacR.DepartmentID 
Group By D.DepartmentID


IF OBJECT_ID('tempdb..#tempFinished') IS NOT NULL
DROP TABLE #tempFinished

select DepartmentID,[FinishedKPI_7],[FinishedKPI_8_21],[FinishedKPI_22-30],[FinishedKPI_31-45],[FinishedKPI_Over45]
INTO #tempFinished
from 
#tempCaseFinishedKPI
PIVOT (count(CaseID)
FOR KPIStatus IN ([FinishedKPI_7],[FinishedKPI_8_21],[FinishedKPI_22-30],[FinishedKPI_31-45],[FinishedKPI_Over45])
) AS pvt



IF OBJECT_ID('tempdb..#tempCaseWorkingKPI') IS NOT NULL
DROP TABLE #tempCaseWorkingKPI

select
aCRF.CaseID 
,aCRF.DepartmentID
,CASE 
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,GETDATE())) BETWEEN 0 AND 21 THEN 'WorkKPI_21'
    ELSE 'WorkKPI_Over21'
END AS KPIStatus
INTO #tempCaseWorkingKPI
from 
(
select * from 
#allCaseRegisterFilter Where WorkStepID > 1 AND DecisionDate IS NULL
)AS aCRF
LEFT JOIN (
select CaseID,WorkStepID,DepartmentID,MIN(ChangeDate) AS ChangeDate 
from CaseChangeWorkStepHistory Where WorkStepID = 2 Group by CaseID,WorkStepID,DepartmentID
) AS StartStep ON aCRF.CaseID = StartStep.CaseID AND aCRF.DepartmentID = StartStep.DepartmentID



IF OBJECT_ID('tempdb..#tempCaseWork') IS NOT NULL
DROP TABLE #tempCaseWork


select DepartmentID,[WorkKPI_21],[WorkKPI_Over21]
INTO #tempCaseWork
from 
#tempCaseWorkingKPI
PIVOT (count(CaseID)
FOR KPIStatus IN ([WorkKPI_21],[WorkKPI_Over21])
) AS pvt


IF OBJECT_ID('tempdb..#tempCaseResultToTable') IS NOT NULL
DROP TABLE #tempCaseResultToTable


select D.DepartmentID
--------,tmF.MonthFinance
,D.DepartmentName,
MAX(ISNULL(tTCR.TotalCase,0)) AS 'P_TotalRequest',
MAX(ISNULL(tF.FinishedKPI_7,0)) AS 'P_FinishedKPI_7'
,Case
WHEN SUM(ISNULL(ttC.TotalCase,0)) - ( SUM(ISNULL(tTCR.TotalCase,0)) +  SUM(ISNULL(tcW.WorkKPI_21,0)) + SUM(ISNULL(tcW.WorkKPI_Over21,0))) > 0  
THEN Cast(Round((SUM(ISNULL(tF.FinishedKPI_7,0))*100.0)/(SUM(ISNULL(ttC.TotalCase,0)) - (SUM(ISNULL(tTCR.TotalCase,0)) + SUM(ISNULL(tcW.WorkKPI_21,0)) + SUM(ISNULL(tcW.WorkKPI_Over21,0)))),2) AS decimal (10,2)) 
ELSE 0.00
END AS P_PersentFinished7
,MAX(ISNULL(tF.FinishedKPI_8_21,0)) AS 'P_FinishedKPI_8_21'
,MAX(ISNULL(tF.FinishedKPI_7,0)) + MAX(ISNULL(tF.FinishedKPI_8_21,0)) AS 'P_Total7_21'
,MAX(ISNULL(tF.[FinishedKPI_22-30],0)) AS 'P_FinishedKPI_22-30'
,MAX(ISNULL(tF.[FinishedKPI_31-45],0)) AS 'P_FinishedKPI_31-45'
,MAX(ISNULL(tF.FinishedKPI_Over45,0)) AS 'P_FinishedKPI_Over45'
,MAX(ISNULL(tcW.WorkKPI_21,0)) AS 'P_WorkKPI_21'
,MAX(ISNULL(tcW.WorkKPI_Over21,0)) AS 'P_WorkKPI_Over21'
,MAX(ISNULL(ttC.TotalCase,0)) AS 'P_TotalCase'
INTO #tempCaseResultToTable
from Department AS D
LEFT JOIN #tempTotalCase AS ttC
ON D.DepartmentID = ttC.DepartmentID
LEFT JOIN #tempCaseWork AS tcW
ON D.DepartmentID = tcW.DepartmentID
LEFT JOIN #tempFinished AS tF
ON D.DepartmentID = tF.DepartmentID
LEFT JOIN #tempTotalCaseRequest AS tTCR
ON D.DepartmentID = tTCR.DepartmentID
Group By D.DepartmentID ,D.DepartmentName
ORDER BY D.DepartmentID ASC

Select 
DepartmentID
--------,CONVERT(varchar(10),MonthFinance) MonthFinance
,DepartmentName P_DepartmentName
,P_TotalRequest
,[P_FinishedKPI_7]
,P_PersentFinished7
--,FinishedKPI_8_21
,P_Total7_21 P_FinishedTotal7_21
,[P_FinishedKPI_22-30]
,[P_FinishedKPI_31-45]
,P_FinishedKPI_Over45
,P_WorkKPI_21
,P_WorkKPI_Over21
,P_TotalCase
from
#tempCaseResultToTable
" + wheredepID + @"
UNION
select * from
(
select 
9999 AS DepartmentID
--------,'รวม' AS MonthFinance
,'รวม' AS P_DepartmentName
,SUM(P_TotalRequest) AS 'P_TotalRquest'
,SUM([P_FinishedKPI_7]) AS 'P_FinishedKPI_7'
,Case
WHEN SUM(ISNULL(P_TotalCase,0)) - (SUM(ISNULL(P_TotalRequest,0)) + SUM(ISNULL(P_WorkKPI_21,0)) + SUM(ISNULL(P_WorkKPI_Over21,0)))  > 0  
THEN Cast(Round((SUM(ISNULL(P_FinishedKPI_7,0))*100.0)/(SUM(ISNULL(P_TotalCase,0)) - ( SUM(ISNULL(P_TotalRequest,0)) + SUM(ISNULL(P_WorkKPI_21,0)) + SUM(ISNULL(P_WorkKPI_Over21,0)))),2) AS decimal (10,2)) 
ELSE 0.00
END AS P_PersentFinished7
--,SUM(FinishedKPI_8_21) AS 'FinishedKPI_8_21'
,SUM(P_Total7_21) AS 'P_FinishedTotal7_21'
,SUM([P_FinishedKPI_22-30]) AS 'P_FinishedKPI_22-30'
,SUM([P_FinishedKPI_31-45]) AS 'P_FinishedKPI_31-45'
,SUM(P_FinishedKPI_Over45) AS 'P_FinishedKPI_Over45'
,SUM(P_WorkKPI_21) AS 'P_WorkKPI_21'
,SUM(P_WorkKPI_Over21) AS 'P_WorkKPI_Over21'
,SUM(P_TotalCase) AS 'P_TotalCase'
from 
#tempCaseResultToTable
" + wheredepID + @"
) tb





";
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }

        #endregion

        #region DepListDataProvince
        public DataTable GetDepListJFCaseFinishedKPI7DataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql = "")
        {
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " WHERE " + whereSql;
            }
            sql = @"

IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
DROP TABLE #allCaseRegister

SELECT 
CAT.CaseID
,CA.ApplicantID
,CA.Title
,CA.FirstName
,CA.LastName
,ISNULL(CA.DeletedFlag,0) AS DeletedFlag
,CAT.RegisterDate
,CAT.JFCaseTypeID
,JFT.CaseTypeNameAbbr
,COD.DepartmentID
,D.DepartmentName
,COD.StatusID
,COD.WorkStepID
,ISNULL(CAMOD.JFCaseNo,'') AS JFCaseNo
,CaseMeetingMinutes.MeetingDate AS  DecisionDate
,StartStep.ChangeDate AS StartDate
,EndStep.ChangeDate AS EndDate
INTO #allCaseRegister
FROM
CaseApplication AS CAT
INNER JOIN 
CaseApplicant AS CA 
ON CAT.CaseID = CA.CaseID 
LEFT JOIN
CaseApplicantExtension AS CAE
ON CA.ApplicantID = CAE.ApplicantID
LEFT JOIN
CardType AS CT
ON CAE.CardType = CT.CardTypeID
LEFT JOIN 
(
SELECT 
CaseID
,DepartmentID
,WorkStepID
,StatusID 
,IsAppeal
FROM 
CaseOwnerDepartment 
WHERE StatusID != 6
) AS COD
ON CA.CaseID = COD.CaseID
LEFT JOIN
CaseApplicantMapOwnerDepartment AS CAMOD
ON CA.ApplicantID = CAMOD.ApplicantID AND COD.DepartmentID = CAMOD.DepartmentID  
LEFT JOIN 
CaseApplicationStatus AS CAS
ON COD.StatusID = CAS.CaseApplicationStatusID
LEFT JOIN 
Department AS D
ON COD.DepartmentID = D.DepartmentID
LEFT JOIN 
JFCaseType AS JFT
ON CAT.JFCaseTypeID = JFT.JFCaseTypeID
LEFT JOIN
CaseMeetingMinutes 
ON CAT.CaseID = CaseMeetingMinutes.CaseID AND CA.ApplicantID = CaseMeetingMinutes.ApplicantID
LEFT JOIN (
SELECT CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID,
		  MAX(ChangeDate) ChangeDate
   FROM CaseChangeWorkStepHistory CCW
   INNER JOIN (SELECT CaseID,
				WorkStepID,
				DepartmentID,
				MAX(ModifiedDate) ModifiedDate 
		  FROM CaseChangeWorkStepHistory 
		  WHERE WorkStepID = 4
		  GROUP BY CaseID,
				WorkStepID,
				DepartmentID) MDX
	ON CCW.ModifiedDate = MDX.ModifiedDate
   WHERE CCW.WorkStepID = 4
   GROUP BY CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID
) AS StartStep 
ON CAT.CaseID = StartStep.CaseID 
AND COD.DepartmentID = StartStep.DepartmentID

LEFT JOIN (SELECT CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID,
		  MAX(ChangeDate) ChangeDate
   FROM CaseChangeWorkStepHistory CCW
   INNER JOIN (SELECT CaseID,
				WorkStepID,
				DepartmentID,
				MAX(ModifiedDate) ModifiedDate 
		  FROM CaseChangeWorkStepHistory 
		  WHERE WorkStepID = 6
		  GROUP BY CaseID,
				WorkStepID,
				DepartmentID) MDX
	ON CCW.ModifiedDate = MDX.ModifiedDate
   WHERE CCW.WorkStepID = 6
   GROUP BY CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID
) AS EndStep ON CAT.CaseID = EndStep.CaseID 
AND COD.DepartmentID = EndStep.DepartmentID


IF OBJECT_ID('tempdb..#allCaseRegisterFilter') IS NOT NULL
DROP TABLE #allCaseRegisterFilter

SELECT
*
,CASE 
    WHEN ABS(DATEDIFF(Day,StartDate,EndDate))+1 BETWEEN 0 AND 7 THEN 'P_FinishedKPI_7'
    WHEN ABS(DATEDIFF(Day,StartDate,EndDate))+1 BETWEEN 8 AND 21 THEN 'P_FinishedKPI_8_21'
    WHEN ABS(DATEDIFF(Day,StartDate,EndDate))+1 BETWEEN 22 AND 30 THEN 'P_FinishedKPI_22-30'
    WHEN ABS(DATEDIFF(Day,StartDate,EndDate))+1 BETWEEN 31 AND 45 THEN 'P_FinishedKPI_31-45'
    WHEN ABS(DATEDIFF(Day,StartDate,EndDate))+1 IS NULL THEN 'NON_Finished'
    ELSE 'P_FinishedKPI_Over45'
END AS KPIStatus
,CASE 
    WHEN ABS(DATEDIFF(Day,StartDate,EndDate))+1 BETWEEN 0 AND 21 THEN 'P_FinishedTotal7_21'
    ELSE 'P_FinishedKPI_Over7_21'
END AS KPISubStatus
,MONTH(RegisterDate) AS ThaiMonthFinance
INTO #allCaseRegisterFilter
FROM #allCaseRegister
WHERE
DeletedFlag != 1
AND JFCaseTypeID != 5
AND JFCaseNo NOT LIKE '%สกย%'
AND WorkStepID > 1
AND DecisionDate IS NOT NULL
--- ค้นหาจากวันที่รับเรื่อง

SELECT *
FROM #allCaseRegisterFilter
 " + whereSql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }

        public DataTable GetDepListJFCaseDataTableV2(List<SqlParameter> sqlParameter, string whereSql, string orderBySql = "")
        {
            DataTable dt = new DataTable();
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "";
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " WHERE " + whereSql;
            }
            sql = @"

IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
DROP TABLE #allCaseRegister

SELECT 
CAT.CaseID
,CA.ApplicantID
,CA.Title
,CA.FirstName
,CA.LastName
,ISNULL(CA.DeletedFlag,0) AS DeletedFlag
,CAT.RegisterDate
,CAT.JFCaseTypeID
,JFT.CaseTypeNameAbbr
,COD.DepartmentID
,D.DepartmentName
,COD.StatusID
,COD.WorkStepID
,ISNULL(CAMOD.JFCaseNo,'') AS JFCaseNo
,CaseMeetingMinutes.MeetingDate AS  DecisionDate
,StartStep.ChangeDate AS StartDate
INTO #allCaseRegister
FROM
CaseApplication AS CAT
INNER JOIN 
CaseApplicant AS CA 
ON CAT.CaseID = CA.CaseID 
LEFT JOIN
CaseApplicantExtension AS CAE
ON CA.ApplicantID = CAE.ApplicantID
LEFT JOIN
CardType AS CT
ON CAE.CardType = CT.CardTypeID
LEFT JOIN 
(
SELECT 
CaseID
,DepartmentID
,WorkStepID
,StatusID 
,IsAppeal
FROM 
CaseOwnerDepartment 
WHERE StatusID != 6
) AS COD
ON CA.CaseID = COD.CaseID
LEFT JOIN
CaseApplicantMapOwnerDepartment AS CAMOD
ON CA.ApplicantID = CAMOD.ApplicantID AND COD.DepartmentID = CAMOD.DepartmentID  
LEFT JOIN 
CaseApplicationStatus AS CAS
ON COD.StatusID = CAS.CaseApplicationStatusID
LEFT JOIN 
Department AS D
ON COD.DepartmentID = D.DepartmentID
LEFT JOIN 
JFCaseType AS JFT
ON CAT.JFCaseTypeID = JFT.JFCaseTypeID
LEFT JOIN
CaseMeetingMinutes 
ON CAT.CaseID = CaseMeetingMinutes.CaseID AND CA.ApplicantID = CaseMeetingMinutes.ApplicantID
LEFT JOIN (
SELECT CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID,
		  MAX(ChangeDate) ChangeDate
   FROM CaseChangeWorkStepHistory CCW
   INNER JOIN (SELECT CaseID,
				WorkStepID,
				DepartmentID,
				MAX(ModifiedDate) ModifiedDate 
		  FROM CaseChangeWorkStepHistory 
		  WHERE WorkStepID = 2
		  GROUP BY CaseID,
				WorkStepID,
				DepartmentID) MDX
	ON CCW.ModifiedDate = MDX.ModifiedDate
   WHERE CCW.WorkStepID = 2 
   GROUP BY CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID
) AS StartStep 
ON CAT.CaseID = StartStep.CaseID 
AND COD.DepartmentID = StartStep.DepartmentID



IF OBJECT_ID('tempdb..#allCaseRegisterFilter') IS NOT NULL
DROP TABLE #allCaseRegisterFilter

SELECT
*
,CASE 
    WHEN ABS(DATEDIFF(Day,StartDate,GETDATE())) BETWEEN 0 AND 21 THEN 'P_WorkKPI_21'
    ELSE 'P_WorkKPI_Over21'
END AS KPIStatus
,MONTH(RegisterDate) AS ThaiMonthFinance
INTO #allCaseRegisterFilter
FROM #allCaseRegister
WHERE
DeletedFlag != 1
AND JFCaseTypeID != 5
AND JFCaseNo NOT LIKE '%สกย%'
AND WorkStepID > 1
AND DecisionDate IS NULL
--- ค้นหาจากวันที่รับเรื่อง

SELECT * FROM #allCaseRegisterFilter
 " + whereSql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }

        #endregion

        public DataTable CreateDataTable(IDbCommand command)
        {
            DataTable dataTable = new DataTable();
            new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)command).Fill(dataTable);
            return dataTable;
        }
        public SqlCommand CreateCommand(string sqlText)
        {
            return CreateCommand(sqlText, false);
        }
        private SqlCommand CreateCommand(string sqlText, bool procedure)
        {
            DalBase dal = new DalBase();
            cmd = new System.Data.SqlClient.SqlCommand();
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
        public void Dispose()
        {
            Close();
        }

    }
}
