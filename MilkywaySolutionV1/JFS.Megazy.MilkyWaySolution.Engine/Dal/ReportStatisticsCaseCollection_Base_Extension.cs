using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{

    public partial class ReportStatisticsCaseCollection_Base : MarshalByRefObject
    {

        public DataTable GetJFSCaseTypeDataTable(List<SqlParameter> sqlParameter, string whereSql)
        {
            AntiSqlInjection.CheckInput(whereSql);
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " AND " + whereSql;
            }
            string sql = @"
                    Select JFCaseTypeID,COUNT(JFCaseTypeID) AS Total,
                    SUM(Case  When WorkStepID  >= 5 THEN 1
                    ELSE 0 END ) AS CountFinish
                    from ReportStatisticsCase
                    Where StatusID  <> 6 --ไม่เท่ากับโอนสำนวน
                    AND  JFCaseTypeID <> 5  " + whereSql + @" GROUP BY JFCaseTypeID ORDER BY JFCaseTypeID";
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            var dt = CreateDataTable(command);
            return dt;
        }
        public DataTable GetWorkingOver21DaysDataTable(List<SqlParameter> sqlParameter, string whereSql)
        {
            AntiSqlInjection.CheckInput(whereSql);
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " AND " + whereSql;
            }
            string sql = @"
                  Select COUNT(*) AS 'ทั้งหมด',
	                    SUM(CASE WHEN WorkStepID Between 2 AND 4 THEN 1
	                    ELSE 0 END )AS 'ค้างนิติกร',
	                    SUM(CASE WHEN WorkStepID >= 5 THEN 1
	                    ELSE 0 END ) AS 'ค้างที่อนุฯ'
                    FROM ReportStatisticsCase
                    WHERE MeetingDate IS  NULL  --สำนวนที่ไม่เสร็จ(ยังไม่มีวันประชุม)
                    AND JFCaseTypeID <> 5 --ไม่เป็นสำนวนปรึกษากฎหมาย
                    AND ABS(DATEDIFF(DAY,Step2,GETDATE()))  > 21 --จำนวนวันเกิน 21 
                    AND WorkStepID > 1 
                    AND StatusID  <> 6 " + whereSql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            var dt = CreateDataTable(command);
            return dt;
        }

        public DataTable GetWorking21DaysDataTable(string whereSql,string sqlcolumnyears)
        {
            AntiSqlInjection.CheckInput(whereSql);
            string sql = @" IF OBJECT_ID('tempdb..#tempDataReport') IS NOT NULL
DROP TABLE #tempDataReport

SELECT 
CaseID
,MM
,YEAR(RegisterDate) + 543 AS Years
,CASE
	WHEN DATEDIFF(DAY,Step2, Step6) < 21 THEN 'Working21'
	WHEN DATEDIFF(DAY,Step2, Step6) > 21 THEN 'Over21'
	ELSE 'Over21'
END AS KPIStatus
INTO #tempDataReport
FROM ReportStatisticsCase
WHERE Step2 IS NOT NULL "+ whereSql + @"

IF OBJECT_ID('tempdb..#tempDateM') IS NOT NULL
DROP TABLE #tempDateM 
CREATE TABLE #tempDateM (Months nvarchar(100), MonthsName nvarchar(100))

INSERT INTO #tempDateM
VALUES ('01','ม.ค.')
,('02','ก.พ.')
,('03','มี.ค.')
,('04','เม.ย.')
,('05','พ.ค.')
,('06','มิ.ย.')
,('07','ก.ค.')
,('08','ส.ค.')
,('09','ก.ย.')
,('10','ต.ค.')
,('11','พ.ย.')
,('12','ธ.ค.')

IF OBJECT_ID('tempdb..#tempDataFilter') IS NOT NULL
DROP TABLE #tempDataFilter
SELECT 
*
INTO #tempDataFilter
FROM #tempDataReport
WHERE KPIStatus = 'Working21'

SELECT DM.Months
,DM.MonthsName
"+ sqlcolumnyears + @"
FROM #tempDateM AS DM
LEFT JOIN #tempDataFilter AS DR
ON DM.Months = DR.MM
GROUP BY DM.Months,DM.MonthsName " ;
            SqlCommand command = CreateCommand(sql);
            var dt = CreateDataTable(command);
            return dt;
        }

        public DataTable GetOpinionDataTable(List<SqlParameter> sqlParameter, string whereSql)
        {
            AntiSqlInjection.CheckInput(whereSql);
            if (!string.IsNullOrWhiteSpace(whereSql))
            {
                whereSql = " AND " + whereSql;
            }
            string sql = @"
                    SELECT 
                      CaseTypeNameAbbr, 
                      [อนุมัติ], 
                      [อนุมัติบางส่วน], 
                      [อนุมัติตามที่ใช้จ่ายจริง], 
                      [ไม่อนุมัติ], 
                      [ยุติ], 
                      [ให้แสวงหาข้อเท็จจริงเพิ่มเติม], 
                      [ยังไม่ทราบผล] 
                    FROM 
                      (
                        SELECT 
                          CaseTypeNameAbbr, 
                          JFCaseTypeID, 
                          ISNULL(
                             OpinionName, 'ยังไม่ทราบผล'
                          ) AS OpinionName 
                        FROM 
                          ReportStatisticsCase 
                        WHERE  WorkStepID > 1 
                           AND JFCaseTypeID <> 5 --ไม่เป็นสำนวนปรึกษากฎหมาย
                          AND StatusID <> 6 --ไม่เป็นสำนวนโอน
                    " + whereSql + @" 
                          ) p PIVOT (
                        COUNT (JFCaseTypeID) FOR OpinionName IN (
                            [อนุมัติ], [อนุมัติบางส่วน], 
                          [อนุมัติตามที่ใช้จ่ายจริง], 
                          [ไม่อนุมัติ], 
                          [ยุติ], [ให้แสวงหาข้อเท็จจริงเพิ่มเติม], 
                          [ยังไม่ทราบผล]
                        )
                      ) AS pvt";
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            var dt = CreateDataTable(command);
            return dt;
        }

        /// <summary>
        /// ปริมาณคำขอเชิงพื้นที่(แสดงบนผนที่)
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetRequestProvince(string where)
        {
            string sql = @" IF OBJECT_ID('tempdb..#tempRePortFilter') IS NOT NULL
DROP TABLE #tempRePortFilter
SELECT * 
INTO #tempRePortfilter
FROM ReportStatisticsCase
"+ where + @"

IF OBJECT_ID('tempdb..#tempRePort') IS NOT NULL
DROP TABLE #tempRePort

SELECT Province.ProvinceID, Province.ProvinceName,ProvinceMapThaiCharts.MapCode , COUNT(CaseID) AS CaseRequest 
INTO #tempRePort
FROM Province
LEFT JOIN #tempRePortFilter AS tRF
ON Province.ProvinceID = tRF.ProvinceID
INNER JOIN ProvinceMapThaiCharts
ON ProvinceMapThaiCharts.ProvinceID = Province.ProvinceID
GROUP BY Province.ProvinceID,Province.ProvinceName,ProvinceMapThaiCharts.MapCode

SELECT * FROM #tempRePort
ORDER BY ProvinceName";
            SqlCommand command = CreateCommand(sql);
            var dt = CreateDataTable(command);
            return dt;
        }

        /// <summary>
        /// จังหวัดที่มีปริมาณคำขอสูงสุด 5 อันดับ
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetTopRequestProvince(string where , string whereregion)
        {
            string sql = @" IF OBJECT_ID('tempdb..#tempRePortFilter') IS NOT NULL
DROP TABLE #tempRePortFilter
SELECT * 
INTO #tempRePortfilter
FROM ReportStatisticsCase
"+ where + @"

IF OBJECT_ID('tempdb..#tempRePort') IS NOT NULL DROP TABLE #tempRePort 
SELECT Province.ProvinceID, Province.ProvinceName,Province.RegionID,ProvinceMapThaiCharts.MapCode , COUNT(CaseID) AS CaseRequest 
INTO #tempRePort 
FROM Province 
LEFT JOIN #tempRePortfilter AS tRF
ON Province.ProvinceID = tRF.ProvinceID 
LEFT JOIN ProvinceMapThaiCharts 
ON ProvinceMapThaiCharts.ProvinceID = Province.ProvinceID 
GROUP BY Province.ProvinceID,Province.ProvinceName,Province.RegionID,ProvinceMapThaiCharts.MapCode 

SELECT TOP(5) * FROM #tempRePort 
"+ whereregion + @"
ORDER BY CaseRequest DESC ";
            SqlCommand command = CreateCommand(sql);
            var dt = CreateDataTable(command);
            return dt;
        }

        /// <summary>
        /// จังหวัดที่มีปริมาณผลการพิจารณาสูงสุด 5 อันดับ
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetTopOpinionProvince(string where, string whereregion)
        {
            string sql = @" IF OBJECT_ID('tempdb..#tempRePortFilter') IS NOT NULL
DROP TABLE #tempRePortFilter
SELECT * 
INTO #tempRePortFilter
FROM ReportStatisticsCase
" + where + @"

IF OBJECT_ID('tempdb..#tempRePort') IS NOT NULL
DROP TABLE #tempRePort

SELECT PV.ProvinceID
,PV.ProvinceName
,PV.RegionID
,ProvinceMapThaiCharts.MapCode 
,COUNT(CaseID) AS CaseRequest
,(SELECT COUNT(CaseID) FROM ReportStatisticsCase
WHERE OpinionID = 1 AND ProvinceID = PV.ProvinceID) AS CaseOpinion1
,(SELECT COUNT(CaseID) FROM ReportStatisticsCase
WHERE OpinionID = 2 AND ProvinceID = PV.ProvinceID) AS CaseOpinion2
,(SELECT COUNT(CaseID) FROM ReportStatisticsCase
WHERE OpinionID = 3 AND ProvinceID = PV.ProvinceID) AS CaseOpinion3
,(SELECT COUNT(CaseID) FROM ReportStatisticsCase
WHERE OpinionID = 8 AND ProvinceID = PV.ProvinceID) AS CaseOpinion8
,(SELECT COUNT(CaseID) FROM ReportStatisticsCase
WHERE OpinionID = 9 AND ProvinceID = PV.ProvinceID) AS CaseOpinion9
INTO #tempRePort
FROM Province AS PV
LEFT JOIN #tempRePortFilter AS tRF
ON PV.ProvinceID = tRF.ProvinceID
LEFT JOIN ProvinceMapThaiCharts
ON ProvinceMapThaiCharts.ProvinceID = PV.ProvinceID
WHERE OpinionID IS NOT NULL
GROUP BY PV.ProvinceID,PV.ProvinceName,PV.RegionID,ProvinceMapThaiCharts.MapCode

SELECT TOP(5) * FROM #tempRePort
" + whereregion + @"
ORDER BY CaseRequest DESC ";

            SqlCommand command = CreateCommand(sql);
            var dt = CreateDataTable(command);
            return dt;
        }

        public int GetMaxID()
        {
            string sql = "Select ISNULL(MAX(ChoiceID),0) AS ID From ScoreChoice";
            SqlCommand command = CreateCommand(sql);
            DataTable dt = CreateDataTable(command);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}

