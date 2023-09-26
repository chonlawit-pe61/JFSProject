using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{
	
	public partial class CaseApplicationCollection_Base 
	{
        public int GetMaxID()
        {
            string sql = "Select ISNULL(MAX(CaseID),0) AS ID From CaseApplication";
            SqlCommand command = CreateCommand(sql);
            DataTable dt = CreateDataTable(command);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        /// <summary>
        /// สถานะการดำเนินงาน 21 วัน  เลือกสถานะ  2:รับเรืองและ5:พิจารณา เท่านั้น
        /// </summary>
        /// <returns></returns>
        public DataTable GetKPI(int departmentID)
        {
            string sql = @"
SELECT CaseTypeNameAbbr, WorkStepName,[ไม่เกิน 21 วัน],
        [22 - 30],
        [31 - 45],
        [เกิน 45] FROM
(
SELECT CaseTypeNameAbbr, JFCaseTypeID, CONVERT(varchar, WorkStepID) + ':' + WorkStepName AS WorkStepName, DayRange
FROM
(
     SELECT TbWorkStep.CaseID, dbo.CaseApplication.JFCaseTypeID, dbo.JFCaseType.CaseTypeNameAbbr, TbWorkStep.DepartmentID, TbWorkStep.WorkStepID, WorkStep.WorkStepName
     , ISNULL(TbCurrentStep.ChangeDate, GETDATE()) AS TbCurrentStepDate
                  , StepTwo.ChangeDate AS StepTwoDate
                  , ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) AS NumberOfDay
                       , CASE
                         WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) BETWEEN 1 AND  21 THEN   'ไม่เกิน 21 วัน'
                         WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) BETWEEN 22 AND 30 THEN '22-30'
                         WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) BETWEEN 31 AND 45 THEN '31-45'
                          WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) > 45 THEN  'เกิน 45'

                         ELSE 'N/A' END AS DayRange
                   FROM  dbo.CaseChangeWorkStepHistory AS TbWorkStep
                   INNER JOIN  dbo.CaseApplication ON   dbo.CaseApplication.CaseID = TbWorkStep.CaseID
                   INNER JOIN dbo.JFCaseType ON dbo.CaseApplication.JFCaseTypeID = dbo.JFCaseType.JFCaseTypeID
                   INNER JOIN WorkStep ON TbWorkStep.WorkStepID = WorkStep.WorkStepID
                    INNER JOIN(
                                /* สถานะปัจจุบันของสำนวน*/
                               SELECT  CaseID, MAX(ChangeDate) AS ChangeDate
                                 FROM  dbo.CaseChangeWorkStepHistory GROUP BY CaseID
                               /*ENDสถานะปัจจุบันของสำนวน*/)
                                AS TbCurrentStep ON TbWorkStep.CaseID = TbCurrentStep.CaseID
                                AND TbWorkStep.ChangeDate = TbCurrentStep.ChangeDate
    LEFT OUTER JOIN(
                           /* สถานะรับเรื่อง*/
                          SELECT   CaseID, MAX(ChangeDate) AS ChangeDate
                               FROM    dbo.CaseChangeWorkStepHistory
                               WHERE WorkStepID = 2
                               GROUP BY CaseID
                   /*ENDสถานะรับเรื่อง*/
                    ) AS StepTwo ON TbWorkStep.CaseID = StepTwo.CaseID
) Tb Where  tb.WorkStepID Between 2 AND 5 ";
            if (departmentID > 0)
            {
                sql += " AND tb.DepartmentID = " + departmentID;
            }
            sql += @")T Pivot(COUNT(JFCaseTypeID)
    FOR DayRange IN (
         [ไม่เกิน 21 วัน],
        [22 - 30],
        [31 - 45],
        [เกิน 45])
) AS pivot_table
ORDER BY pivot_table.CaseTypeNameAbbr,pivot_table.WorkStepName";

            SqlCommand command = CreateCommand(sql);
            return CreateDataTable(command); ;
        }


        /// <summary>
          /// ไม่เอา JFCaseType 5,ยังไม่ปิดสำนวน เลือกสถานะที่ 4,5
        /// </summary>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public DataTable GetKPI21Lawyer(int departmentID)
        {
            string sql = @"
SELECT JFCaseType.JFCaseTypeID,JFCaseType.CaseTypeNameAbbr, Count(CaseID) AS TotalCase,WorkStepName,DayRange
FROM(
	 SELECT        TbWorkStep.CaseID,dbo.CaseApplication.JFCaseTypeID,dbo.JFCaseType.CaseTypeNameAbbr, TbWorkStep.DepartmentID,TbWorkStep.WorkStepID,WorkStep.WorkStepName 
	 , ISNULL(TbCurrentStep.ChangeDate, GETDATE()) AS TbCurrentStepDate
                  ,StepTwo.ChangeDate AS StepTwoDate
				  ,ISNULL(DATEDIFF(DAY, DATEADD(DAY,-1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) AS NumberOfDay
				  	 ,CASE 
						 WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY,-1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) BETWEEN 1 AND  21 THEN 'ไม่เกิน 21 วัน'
						 WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY,-1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) BETWEEN 22 AND 30 THEN '22-30' 
						 WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY,-1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) BETWEEN 31 AND 45 THEN '31-45' 
						  WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY,-1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) > 45 THEN 'เกิน 45' 
						 ELSE 'N/A' END AS DayRange
				   FROM  dbo.CaseChangeWorkStepHistory AS TbWorkStep	
				   INNER JOIN  dbo.CaseApplication ON   dbo.CaseApplication.CaseID = TbWorkStep.CaseID
				   INNER JOIN dbo.JFCaseType ON dbo.CaseApplication.JFCaseTypeID = dbo.JFCaseType.JFCaseTypeID
				   INNER JOIN WorkStep ON TbWorkStep.WorkStepID = WorkStep.WorkStepID									   
					INNER JOIN  (
					             /* สถานะปัจจุบันของสำนวน*/
							   SELECT  CaseID,MAX(ChangeDate) AS ChangeDate
                                 FROM  dbo.CaseChangeWorkStepHistory GROUP BY CaseID								
								/*ENDสถานะปัจจุบันของสำนวน*/) 
								AS TbCurrentStep ON TbWorkStep.CaseID = TbCurrentStep.CaseID 
								AND TbWorkStep.ChangeDate = TbCurrentStep.ChangeDate
	LEFT OUTER JOIN ( 
					 /* สถานะรับเรื่อง*/
						  SELECT   CaseID,MAX(ChangeDate) AS ChangeDate
							   FROM    dbo.CaseChangeWorkStepHistory 
							   WHERE WorkStepID  = 2
                               GROUP BY CaseID
					/*ENDสถานะรับเรื่อง*/
					) AS StepTwo ON TbWorkStep.CaseID = StepTwo.CaseID 	
					  WHERE TbWorkStep.WorkStepID = 4 ";
            if (departmentID > 0)
            {
                sql += " AND TbWorkStep.DepartmentID = " + departmentID;
            }
            sql += @" ) AS Tb 
					 RIGHT OUTER JOIN JFCaseType ON Tb.JFCaseTypeID = JFCaseType.JFCaseTypeID 
					 WHERE JFCaseType.JFCaseTypeID  <> 5
GROUP BY JFCaseType.JFCaseTypeID,JFCaseType.CaseTypeNameAbbr,WorkStepName,DayRange";
            SqlCommand command = CreateCommand(sql);
            return CreateDataTable(command); ;
        }
       public DataTable GetKPI21Subcommittee(int departmentID)
        {
            string sql = @"
SELECT JFCaseType.JFCaseTypeID,JFCaseType.CaseTypeNameAbbr, Count(CaseID) AS TotalCase,WorkStepName,DayRange
FROM(
	 SELECT        TbWorkStep.CaseID,dbo.CaseApplication.JFCaseTypeID,dbo.JFCaseType.CaseTypeNameAbbr, TbWorkStep.DepartmentID,TbWorkStep.WorkStepID,WorkStep.WorkStepName 
	 , ISNULL(TbCurrentStep.ChangeDate, GETDATE()) AS TbCurrentStepDate
                  ,StepTwo.ChangeDate AS StepTwoDate
				  ,ISNULL(DATEDIFF(DAY, DATEADD(DAY,-1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) AS NumberOfDay
				  	 ,CASE 
						 WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY,-1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) BETWEEN 1 AND  21 THEN 'ไม่เกิน 21 วัน'
						 WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY,-1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) BETWEEN 22 AND 30 THEN '22-30' 
						 WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY,-1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) BETWEEN 31 AND 45 THEN '31-45' 
						  WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY,-1, StepTwo.ChangeDate), TbCurrentStep.ChangeDate), 0) > 45 THEN 'เกิน 45' 
						 ELSE 'N/A' END AS DayRange
				   FROM  dbo.CaseChangeWorkStepHistory AS TbWorkStep	
				   INNER JOIN  dbo.CaseApplication ON   dbo.CaseApplication.CaseID = TbWorkStep.CaseID
				   INNER JOIN dbo.JFCaseType ON dbo.CaseApplication.JFCaseTypeID = dbo.JFCaseType.JFCaseTypeID
				   INNER JOIN WorkStep ON TbWorkStep.WorkStepID = WorkStep.WorkStepID									   
					INNER JOIN  (
					          /* สถานะปัจจุบันของสำนวน*/
							   SELECT  CaseID,MAX(ChangeDate) AS ChangeDate
                                 FROM  dbo.CaseChangeWorkStepHistory GROUP BY CaseID								
								/*ENDสถานะปัจจุบันของสำนวน*/) 
								AS TbCurrentStep ON TbWorkStep.CaseID = TbCurrentStep.CaseID 
								AND TbWorkStep.ChangeDate = TbCurrentStep.ChangeDate
	LEFT OUTER JOIN ( 
					/* สถานะรับเรื่อง*/
						  SELECT   CaseID,MAX(ChangeDate) AS ChangeDate
							   FROM    dbo.CaseChangeWorkStepHistory 
							   WHERE WorkStepID  = 2
                               GROUP BY CaseID
					/*ENDสถานะรับเรื่อง*/
					) AS StepTwo ON TbWorkStep.CaseID = StepTwo.CaseID 	
					  WHERE TbWorkStep.WorkStepID = 5 ";
            if (departmentID > 0)
            {
                sql += " AND TbWorkStep.DepartmentID = " + departmentID;
            }
            sql += @" ) AS Tb 
					 RIGHT OUTER JOIN JFCaseType ON Tb.JFCaseTypeID = JFCaseType.JFCaseTypeID 
					 WHERE JFCaseType.JFCaseTypeID  <> 5
GROUP BY JFCaseType.JFCaseTypeID,JFCaseType.CaseTypeNameAbbr,WorkStepName,DayRange";
            SqlCommand command = CreateCommand(sql);
            return CreateDataTable(command); ;
        }


        public DataTable GetKPI21(int departmentID = 0)
        {

            string sql = "";
            string whereDepartment = "";
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();

            if (departmentID != 0)
            {
                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.NVarChar) { Value = departmentID };
                parameter.Add(sqlParameter);
                whereDepartment = $" AND DepartmentID = @DepartmentID ";
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
,TW2.[2_รับเรื่อง] AS StartDate
,CaseMeetingMinutes.MeetingDate 


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
LEFT JOIN CaseMeetingMinutes ON CAT.CaseID = CaseMeetingMinutes.CaseID
AND CA.ApplicantID = CaseMeetingMinutes.ApplicantID
LEFT JOIN
  (SELECT CaseID,
          WorkStepID,
          DepartmentID,
          MIN(ChangeDate) AS '2_รับเรื่อง'
   FROM CaseChangeWorkStepHistory
   WHERE WorkStepID = 2
   GROUP BY CaseID,
            WorkStepID,
            DepartmentID) AS TW2 ON COD.CaseID = TW2.CaseID
AND COD.DepartmentID = TW2.DepartmentID

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
AND MeetingDate IS NULL 
"+ whereDepartment 
+ @"
IF OBJECT_ID('tempdb..#totalCase') IS NOT NULL
DROP TABLE #totalCase

Select 
COUNT(JFCaseTypeID) AS Total
,JFCaseTypeID
INTO #totalCase
from #allCaseRegisterFilter
Where WorkStepID Between 2 AND 5
Group By JFCaseTypeID


IF OBJECT_ID('tempdb..#tempLawyer') IS NOT NULL
DROP TABLE #tempLawyer
select 
JFCaseTypeID
,CaseID
,CASE
WHEN DATEDIFF(DAY, DATEADD(DAY,-1, StartDate), GETDATE()) < 22 THEN '21'
WHEN DATEDIFF(DAY, DATEADD(DAY,-1, StartDate), GETDATE()) BETWEEN 22 AND 30 THEN '22-30'
WHEN DATEDIFF(DAY, DATEADD(DAY,-1, StartDate), GETDATE()) BETWEEN 31 AND 45 THEN '31-45'
WHEN DATEDIFF(DAY, DATEADD(DAY,-1, StartDate), GETDATE()) > 45 THEN 'Over_45'
ELSE '' END AS KPIStatus
INTO #tempLawyer
from #allCaseRegisterFilter
Where WorkStepID Between 2 AND 4

IF OBJECT_ID('tempdb..#tempSummaryLawyer') IS NOT NULL
DROP TABLE #tempSummaryLawyer

SELECT JFCaseTypeID,
[21] AS 'KPILawyer21',
[22-30] AS 'KPILawyer22',
[31-45] AS 'KPILawyer31',
[Over_45] AS 'KPILawyer45'
INTO #tempSummaryLawyer
FROM #tempLawyer
PIVOT (COUNT(CaseID)
FOR KPIStatus IN ([21],[22-30],[31-45],[Over_45])
) AS pvt



IF OBJECT_ID('tempdb..#tempMeeting') IS NOT NULL
DROP TABLE #tempMeeting
select 
JFCaseTypeID
,CaseID
,CASE
WHEN DATEDIFF(DAY, DATEADD(DAY,-1, StartDate), GETDATE()) < 22 THEN '21'
WHEN DATEDIFF(DAY, DATEADD(DAY,-1, StartDate), GETDATE()) BETWEEN 22 AND 30 THEN '22-30'
WHEN DATEDIFF(DAY, DATEADD(DAY,-1, StartDate), GETDATE()) BETWEEN 31 AND 45 THEN '31-45'
WHEN DATEDIFF(DAY, DATEADD(DAY,-1, StartDate), GETDATE()) > 45 THEN 'Over_45'
ELSE '' END AS KPIStatus
INTO #tempMeeting
from #allCaseRegisterFilter
Where WorkStepID = 5

IF OBJECT_ID('tempdb..#tempSummaryMeeting') IS NOT NULL
DROP TABLE #tempSummaryMeeting

SELECT JFCaseTypeID,
[21] AS 'KPIMeeting21',
[22-30] AS 'KPIMeeting22',
[31-45] AS 'KPIMeeting31',
[Over_45] AS 'KPIMeeting45'
INTO #tempSummaryMeeting
FROM #tempMeeting
PIVOT (COUNT(CaseID)
FOR KPIStatus IN ([21],[22-30],[31-45],[Over_45])
) AS pvt



IF OBJECT_ID('tempdb..#Summary') IS NOT NULL
DROP TABLE #Summary

select 
JT.CaseTypeNameAbbr,
ISNULL(#totalCase.Total,0) AS Total,
ISNULL(tSY.KPILawyer21,0) AS 'KPILawyer21',
ISNULL(tSY.KPILawyer22,0) AS 'KPILawyer22',
ISNULL(tSY.KPILawyer31,0) AS 'KPILawyer31',
ISNULL(tSY.KPILawyer45,0) AS 'KPILawyer45',
ISNULL(tSM.KPIMeeting21,0) AS 'KPIMeeting21',
ISNULL(tSM.KPIMeeting22,0) AS 'KPIMeeting22',
ISNULL(tSM.KPIMeeting31,0) AS 'KPIMeeting31',
ISNULL(tSM.KPIMeeting45,0) AS 'KPIMeeting45'
INTO #Summary
from 
(select * from JFCaseType Where JFCaseTypeID != 5) AS JT
LEFT JOIN #totalCase 
ON JT.JFCaseTypeID = #totalCase.JFCaseTypeID
LEFT JOIN #tempSummaryLawyer AS tSY
ON JT.JFCaseTypeID = tSY.JFCaseTypeID
LEFT JOIN #tempSummaryMeeting AS tSM
ON JT.JFCaseTypeID = tSM.JFCaseTypeID

select
ISNULL(CaseTypeNameAbbr,'รวม') AS CaseTypeNameAbbr
,SUM(Total) AS TotalCase
,SUM(KPILawyer21) AS KPILawyer21
,SUM(KPILawyer22) AS KPILawyer22
,SUM(KPILawyer31) AS KPILawyer31
,SUM(KPILawyer45) AS KPILawyer45
,SUM(KPIMeeting21) AS KPIMeeting21
,SUM(KPIMeeting22) AS KPIMeeting22
,SUM(KPIMeeting31) AS KPIMeeting31
,SUM(KPIMeeting45) AS KPIMeeting45
from 
#Summary
Group By ROLLUP(CaseTypeNameAbbr)




";




            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            return CreateDataTable(command); ;

            //            string sql = "";
            //            string twdepcol = "";
            //            string tcdepcol = "";
            //            string tbdepcol = "";
            //            string kpialldep = "";
            //            string kpilawyerdep = "";
            //            string kpiresultdep = "";
            //            string colwhere = "";
            //            string cadepcol = "";
            //            string wheredep = "";
            //            if (departmentID > 0)
            //            {
            //                cadepcol = ",CA.DepartmentID";
            //                tbdepcol = "DepartmentID";
            //                kpialldep = "AND TotalCase.DepartmentID = TbKPIALLWork.DepartmentID";
            //                kpilawyerdep = "AND TotalCase.DepartmentID = TbKPILawyer.DepartmentID";
            //                kpiresultdep = "AND TotalCase.DepartmentID = TbKPIResult.DepartmentID";
            //                twdepcol = ",TbWorking.DepartmentID";
            //                tcdepcol = ",TotalCase.DepartmentID";
            //                colwhere = $"AND TbWorking.DepartmentID = {departmentID}";
            //                wheredep = $"Where DepartmentID = {departmentID}";
            //            }
            //            sql = @"select JCT.JFCaseTypeID,JCT.CaseTypeNameAbbr,TotalCase.TotalCase";
            //            sql += tcdepcol;
            //            sql += @",ISNULL(TbKPIALLWork.[äÁèà¡Ô¹ 21],0) AS 'KPIALL21',ISNULL(TbKPIALLWork.[22-30],0) AS 'KPIALL22',
            //ISNULL(TbKPIALLWork.[31-45],0) AS 'KPIALL31',ISNULL(TbKPIALLWork.[à¡Ô¹ 45],0) AS 'KPIALL45',
            //ISNULL(TbKPILawyer.[äÁèà¡Ô¹ 21],0) AS 'KPILawyer21',ISNULL(TbKPILawyer.[22-30],0) AS 'KPILawyer22',
            //ISNULL(TbKPILawyer.[31-45],0) AS 'KPILawyer31',ISNULL(TbKPILawyer.[à¡Ô¹ 45],0) AS 'KPILawyer45',
            //ISNULL(TbKPIResult.[äÁèà¡Ô¹ 21],0) AS 'KPIMeeting21',ISNULL(TbKPIResult.[22-30],0) AS 'KPIMeeting22',
            //ISNULL(TbKPIResult.[31-45],0) AS 'KPIMeeting31',ISNULL(TbKPIResult.[à¡Ô¹ 45],0) AS 'KPIMeeting45'
            //from JFCaseType AS JCT 
            //INNER JOIN
            //(
            ///* KPI Department */
            //select TbWorking.JFCaseTypeID";
            //            sql += twdepcol;
            //            sql += @",COUNT(TbWorking.CaseID) AS TotalCase
            //from (
            //select Ca.CaseID,TbWork.ChangeDate,Ca.JFCaseTypeID ";
            //            sql += cadepcol;
            //            sql += @" from 
            //CaseApplication AS CA INNER JOIN (
            //select tb.CaseID,tb.ChangeDate from (
            //select TbWorkStep.CaseID,TbWorkStep.WorkStepID,TbWorkStep.ChangeDate from CaseChangeWorkStepHistory AS TbWorkStep
            //INNER JOIN (
            //SELECT  CaseID, MAX(ChangeDate) AS ChangeDate
            //FROM  dbo.CaseChangeWorkStepHistory GROUP BY CaseID
            //) AS TbCuurentStep ON TbWorkStep.CaseID = TbCuurentStep.CaseID AND TbWorkStep.ChangeDate = TbCuurentStep.ChangeDate
            //)tb where tb.WorkStepID BETWEEN 2 AND 5
            //) AS TbWork ON CA.CaseID = TbWork.CaseID AND Ca.JFCaseTypeID != 5 
            //) AS TbWorking INNER JOIN 
            //(
            //SELECT   CaseID, MAX(ChangeDate) AS ChangeDate
            //FROM    dbo.CaseChangeWorkStepHistory
            //WHERE WorkStepID = 2
            //GROUP BY CaseID
            //) AS TbStartWork ON TbWorking.CaseID = TbStartWork.CaseID ";
            //            sql += wheredep;
            //            sql += @"Group By TbWorking.JFCaseTypeID";
            //            sql += twdepcol;
            //            sql += @")AS TotalCase ON JCT.JFCaseTypeID = TotalCase.JFCaseTypeID 
            //LEFT JOIN 
            //(
            ///* Pivot KPI Working */
            //select * from 
            //(
            //select TbWorking.CaseID";
            //            sql += twdepcol;
            //            sql += @",TbWorking.JFCaseTypeID,

            //CASE
            //WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, TbStartWork.ChangeDate), TbWorking.ChangeDate), 0) BETWEEN 1 AND  21 THEN  'äÁèà¡Ô¹ 21'
            //WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, TbStartWork.ChangeDate), TbWorking.ChangeDate), 0) BETWEEN 22 AND 30 THEN '22-30'
            //WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, TbStartWork.ChangeDate), TbWorking.ChangeDate), 0) BETWEEN 31 AND 45 THEN '31-45'
            //WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, TbStartWork.ChangeDate), TbWorking.ChangeDate), 0) > 45 THEN 'à¡Ô¹ 45'
            //ELSE 'N/A' END AS DayRange
            //from (
            //select Ca.CaseID,TbWork.ChangeDate,Ca.JFCaseTypeID,CA.DepartmentID from 
            //CaseApplication AS CA INNER JOIN (
            //select tb.CaseID,tb.ChangeDate from (
            //select TbWorkStep.CaseID,TbWorkStep.WorkStepID,TbWorkStep.ChangeDate from CaseChangeWorkStepHistory AS TbWorkStep
            //INNER JOIN (
            //SELECT  CaseID, MAX(ChangeDate) AS ChangeDate
            //FROM  dbo.CaseChangeWorkStepHistory GROUP BY CaseID
            //) AS TbCuurentStep ON TbWorkStep.CaseID = TbCuurentStep.CaseID AND TbWorkStep.ChangeDate = TbCuurentStep.ChangeDate
            //)tb where tb.WorkStepID BETWEEN 2 AND 5
            //) AS TbWork ON CA.CaseID = TbWork.CaseID AND Ca.JFCaseTypeID != 5 
            //) AS TbWorking INNER JOIN 
            //(
            //SELECT   CaseID, MAX(ChangeDate) AS ChangeDate
            //FROM    dbo.CaseChangeWorkStepHistory
            //WHERE WorkStepID = 2
            //GROUP BY CaseID
            //) AS TbStartWork ON TbWorking.CaseID = TbStartWork.CaseID ";
            //            sql += colwhere;
            //            sql += @") AS Tb
            //Pivot(COUNT(CaseID)
            //    FOR DayRange IN (
            //        [äÁèà¡Ô¹ 21],
            //        [22-30],
            //        [31-45],
            //        [à¡Ô¹ 45])
            //) AS pivot_table  
            //)  AS TbKPIALLWork ON TotalCase.JFCaseTypeID = TbKPIALLWork.JFCaseTypeID ";
            //            sql += kpialldep;
            //            sql += @"/*-- KPI LawyerWorking */
            //LEFT JOIN 
            //(
            //select * from 
            //(
            //select TbWorking.CaseID,TbWorking.JFCaseTypeID ";
            //            sql += twdepcol;
            //            sql += @",CASE
            //WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, TbStartWork.ChangeDate), TbWorking.ChangeDate), 0) BETWEEN 1 AND  21 THEN  'äÁèà¡Ô¹ 21'
            //WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, TbStartWork.ChangeDate), TbWorking.ChangeDate), 0) BETWEEN 22 AND 30 THEN '22-30'
            //WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, TbStartWork.ChangeDate), TbWorking.ChangeDate), 0) BETWEEN 31 AND 45 THEN '31-45'
            //WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, TbStartWork.ChangeDate), TbWorking.ChangeDate), 0) > 45 THEN 'à¡Ô¹ 45'
            //ELSE 'N/A' END AS DayRange
            //from (
            //select Ca.CaseID,TbWork.ChangeDate,Ca.JFCaseTypeID,CA.DepartmentID from 
            //CaseApplication AS CA INNER JOIN (
            //select tb.CaseID,tb.ChangeDate from (
            //select TbWorkStep.CaseID,TbWorkStep.WorkStepID,TbWorkStep.ChangeDate from CaseChangeWorkStepHistory AS TbWorkStep
            //INNER JOIN (
            //SELECT  CaseID, MAX(ChangeDate) AS ChangeDate
            //FROM  dbo.CaseChangeWorkStepHistory GROUP BY CaseID
            //) AS TbCuurentStep ON TbWorkStep.CaseID = TbCuurentStep.CaseID AND TbWorkStep.ChangeDate = TbCuurentStep.ChangeDate
            //)tb where tb.WorkStepID BETWEEN 2 AND 4
            //) AS TbWork ON CA.CaseID = TbWork.CaseID AND Ca.JFCaseTypeID != 5 
            //) AS TbWorking INNER JOIN 
            //(
            //SELECT   CaseID, MAX(ChangeDate) AS ChangeDate
            //FROM    dbo.CaseChangeWorkStepHistory
            //WHERE WorkStepID = 2
            //GROUP BY CaseID
            //) AS TbStartWork ON TbWorking.CaseID = TbStartWork.CaseID ";
            //            sql += colwhere;
            //            sql += @") AS Tb
            //Pivot(COUNT(CaseID)
            //    FOR DayRange IN (
            //        [äÁèà¡Ô¹ 21],
            //        [22-30],
            //        [31-45],
            //        [à¡Ô¹ 45])
            //) AS pivot_table  
            //) AS TbKPILawyer ON TotalCase.JFCaseTypeID = TbKPILawyer.JFCaseTypeID ";
            //            sql += kpilawyerdep;
            //            sql += @"
            ///*-- KPI Committee */
            //LEFT JOIN 
            //(
            //select * from 
            //(
            //select TbWorking.CaseID,TbWorking.JFCaseTypeID";
            //            sql += twdepcol;
            //            sql += @",CASE
            //WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, TbStartWork.ChangeDate), TbWorking.ChangeDate), 0) BETWEEN 1 AND  21 THEN  'äÁèà¡Ô¹ 21'
            //WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, TbStartWork.ChangeDate), TbWorking.ChangeDate), 0) BETWEEN 22 AND 30 THEN '22-30'
            //WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, TbStartWork.ChangeDate), TbWorking.ChangeDate), 0) BETWEEN 31 AND 45 THEN '31-45'
            //WHEN ISNULL(DATEDIFF(DAY, DATEADD(DAY, -1, TbStartWork.ChangeDate), TbWorking.ChangeDate), 0) > 45 THEN 'à¡Ô¹ 45'
            //ELSE 'N/A' END AS DayRange
            //from (
            //select Ca.CaseID,TbWork.ChangeDate,Ca.JFCaseTypeID,CA.DepartmentID from 
            //CaseApplication AS CA INNER JOIN (
            //select tb.CaseID,tb.ChangeDate from (
            //select TbWorkStep.CaseID,TbWorkStep.WorkStepID,TbWorkStep.ChangeDate from CaseChangeWorkStepHistory AS TbWorkStep
            //INNER JOIN (
            //SELECT  CaseID, MAX(ChangeDate) AS ChangeDate
            //FROM  dbo.CaseChangeWorkStepHistory GROUP BY CaseID
            //) AS TbCuurentStep ON TbWorkStep.CaseID = TbCuurentStep.CaseID AND TbWorkStep.ChangeDate = TbCuurentStep.ChangeDate
            //)tb where tb.WorkStepID = 5
            //) AS TbWork ON CA.CaseID = TbWork.CaseID AND Ca.JFCaseTypeID != 5 
            //) AS TbWorking INNER JOIN 
            //(
            //SELECT   CaseID, MAX(ChangeDate) AS ChangeDate
            //FROM    dbo.CaseChangeWorkStepHistory
            //WHERE WorkStepID = 2
            //GROUP BY CaseID
            //) AS TbStartWork ON TbWorking.CaseID = TbStartWork.CaseID ";
            //            sql += colwhere;
            //            sql += @") AS Tb
            //Pivot(COUNT(CaseID)
            //    FOR DayRange IN (
            //        [äÁèà¡Ô¹ 21],
            //        [22-30],
            //        [31-45],
            //        [à¡Ô¹ 45])
            //) AS pivot_table  
            //)AS TbKPIResult ON TotalCase.JFCaseTypeID = TbKPIResult.JFCaseTypeID ";
            //            sql += kpiresultdep;
            //            SqlCommand command = CreateCommand(sql);
            //            return CreateDataTable(command); ;
        }

        public bool DeleteCase(int caseID,int applicantID)
        {
            string sql = @"[dbo].[msp_deletecase]";
            SqlCommand cmd = CreateCommand(sql, true);
            //cmd.Parameters.Add("@lat", SqlDbType.Float).Value = lat;
            //cmd.Parameters.Add("@lng", SqlDbType.Float).Value = lng;
            //cmd.Parameters.Add("@place", SqlDbType.VarChar).Value = place;
            cmd.Parameters.Add("@ApplicantID", SqlDbType.Int).Value = applicantID;
            cmd.Parameters.Add("@CaseID", SqlDbType.Int).Value = caseID;
            return cmd.ExecuteNonQuery() == 0;
            //return CreateCommand(cmd);
        }

      
    }
}

