using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{

	public partial class CaseApplicantCollection_Base
	{
        public int GetMaxID()
        {
            string sql = "Select ISNULL(MAX(ApplicantID),0) AS ID From CaseApplicant";
            SqlCommand command = CreateCommand(sql);
            DataTable dt = CreateDataTable(command);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public DataTable GetLawyerWorking(int depID, string startData,string endDate)
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            string whereSql = "";
            string whereDepartment = "";

            if(startData != "" && endDate != "" && startData != null && endDate != null)
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startData };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                whereSql = $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";
            }
            if(depID != 0)
            {
                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = depID };
                parameter.Add(sqlParameter);
                whereSql += $" AND DepartmentID = @DepartmentID";

                sqlParameter = new SqlParameter("@LawyerDepartmentID", System.Data.SqlDbType.Int) { Value = depID };
                parameter.Add(sqlParameter);
                whereDepartment += $" AND UA.DepartmentID = @LawyerDepartmentID";
            }
            string sql = @"
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
,CaseMeetingMinutes.MeetingDate AS DecisionDate
,ISNULL(TbUser.UserID,9999) AS LawyerID
,TbUser.FirstName +' '+TbUser.LastName AS LawyerOfficerName

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
LEFT JOIN
 (SELECT CaseOwner.CaseID,
          CaseOwner.DepartmentID,
          CaseOwner.UserID
   FROM CaseOwner
   INNER JOIN
     (SELECT MAX(ChangeDate) AS ChangeDate,
             CaseID
      FROM CaseOwner
      GROUP BY CaseID) CurrentCaseOwner ON CaseOwner.CaseID = CurrentCaseOwner.CaseID
   AND CaseOwner.ChangeDate = CurrentCaseOwner.ChangeDate) CO ON CAT.CaseID = CO.CaseID
AND COD.DepartmentID = CO.DepartmentID
LEFT JOIN [User] AS TbUser ON CO.UserID = TbUser.UserID


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
--AND DepartmentID = 2
----- ไม่เอาเคสที่ยื่นเรื่อง
--AND WorkStepID != 1
"+ whereSql+
@"
Order By RegisterDate ASC



IF OBJECT_ID('tempdb..#tempCaseWorkingKPI') IS NOT NULL
DROP TABLE #tempCaseWorkingKPI

select
aCRF.CaseID 
,aCRF.LawyerID
,CASE 
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,GETDATE())) BETWEEN 0 AND 21 THEN 'WorkKPI_21'
	WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,GETDATE())) Between 22 AND 30 THEN 'WorkKPI_22-30'
	WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,GETDATE())) Between 31 AND 45 THEN 'WorkKPI_31-45'
    ELSE 'WorkKPI_Over45'
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


select ISNULL(LawyerID,9999) AS LawyerID,[WorkKPI_21],[WorkKPI_22-30],[WorkKPI_31-45],[WorkKPI_Over45]
INTO #tempCaseWork
from 
#tempCaseWorkingKPI
PIVOT (count(CaseID)
FOR KPIStatus IN ([WorkKPI_21],[WorkKPI_22-30],[WorkKPI_31-45],[WorkKPI_Over45])
) AS pvt



IF OBJECT_ID('tempdb..#tempStep') IS NOT NULL
DROP TABLE #tempStep


select ISNULL(LawyerID,9999) AS LawyerID , [Step_1],[Step_2],[Step_3],[Step_4],[Step_5],[OverStep_5]
INTO #tempStep
from 
(select 
CaseID,
LawyerID,
CASE 
WHEN WorkStepID = 1 THEN 'Step_1'
WHEN WorkStepID = 2 THEN 'Step_2'
WHEN WorkStepID = 3 THEN 'Step_3'
WHEN WorkStepID = 4 THEN 'Step_4'
WHEN WorkStepID = 5 THEN 'Step_5'
ELSE 'OverStep_5' 
END AS WorkStep

from #allCaseRegisterFilter  Where  DecisionDate IS NULL )tb
PIVOT (count(CaseID)
FOR WorkStep IN ([Step_1],[Step_2],[Step_3],[Step_4],[Step_5],[OverStep_5])
) AS pvt


IF OBJECT_ID('tempdb..#tempLawyer') IS NOT NULL
DROP TABLE #tempLawyer

select * 
INTO #tempLawyer
from (
select 
U.UserID 
,U.AliasName
from (SELECT U.AliasName,
          UA.DepartmentID,
          U.UserID
   FROM [User] AS U
   INNER JOIN UserAdditional AS UA ON U.UserID = UA.UserID AND U.UserID != 8 
   " + whereDepartment +
   @"
   
   ) AS U
UNION
select 
9999 AS UserID
,'ยังไม่มีนิติกรเจ้าของสำนวน' AS AliasName
) tb

--select 
--tL.UserID AS LawyerID
--,tL.AliasName AS LawyerName
--,ISNULL(tCW.WorkKPI_21,0) AS WorkKPI_21
--,ISNULL(tCW.WorkKPI_Over21,0) AS WorkKPI_Over21
--INTO #testTemp
--from #tempLawyer AS tL LEFT JOIN 
--#tempCaseWork AS tCW
--ON tL.UserID = tCW.LawyerID 

--select 

--LawyerID
--,SUM(WorkKPI_21)
--,SUM(WorkKPI_Over21)

--from #testTemp

--Group By ROLLUP (LawyerID)


IF OBJECT_ID('tempdb..#tempCaseSummary') IS NOT NULL
DROP TABLE #tempCaseSummary



select 
tL.UserID AS LawyerID
,tL.AliasName AS LawyerName
,ISNULL(tS.Step_1,0) AS 'Step_1'
,ISNULL(tS.Step_2,0) AS 'Step_2'
,ISNULL(tS.Step_3,0) AS 'Step_3'
,ISNULL(tS.Step_4,0) AS 'Step_4'
,ISNULL(tS.Step_5,0) AS 'Step_5'
,ISNULL(tS.OverStep_5,0) AS 'OverStep_5'
,ISNULL(tCW.WorkKPI_21,0) As 'WorkKPI_21'
,ISNULL(tCW.[WorkKPI_22-30],0) As 'WorkKPI_22-30'
,ISNULL(tCW.[WorkKPI_31-45],0) As 'WorkKPI_31-45'
,ISNULL(tCW.WorkKPI_Over45,0) AS 'WorkKPI_Over45'
,ISNULL(tCA.Total,0) AS NumberOfCase
INTO #tempCaseSummary
from #tempLawyer AS tL
LEFT JOIN #tempStep AS tS
ON tL.UserID = tS.LawyerID
LEFT JOIN #tempCaseWork AS tCW
ON tL.UserID = tCW.LawyerID 
LEFT JOIN 
(
select 
COUNT(CaseID)  AS Total
,LawyerID
from #allCaseRegisterFilter
Where DecisionDate IS NULL
AND WorkStepID > 1
Group By LawyerID

) AS tCA
ON tL.UserID = tCA.LawyerID
--select * from #tempStep
--select * from #tempCaseWork

SELECT
*
From #tempCaseSummary
UNION
select * from
(
select 
99999 AS LawyerID
,'รวม' AS LawyerName
,SUM(Step_1) AS 'Step_1'
,SUM(Step_2) AS 'Step_2'
,SUM(Step_3) AS 'Step_3'
,SUM(Step_4) AS 'Step_4'
,SUM(Step_5) AS 'Step_5'
,SUM(OverStep_5) AS 'OverStep_5'
,SUM(WorkKPI_21) AS 'WorkKPI_21'
,SUM([WorkKPI_22-30]) AS 'WorkKPI_22-30'
,SUM([WorkKPI_31-45]) AS 'WorkKPI_31-45'
,SUM(WorkKPI_Over45) AS 'WorkKPI_Over45'
,SUM(NumberOfCase) AS 'NumberOfCase'
from 
#tempCaseSummary
) tb


";
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }
        public DataTable GetCounselDepartment(string startDate, string endDate, int depID)
        {

            string sql = "";
            string whereDate = "";
            string whereDepID = "";
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            if (startDate != "" && endDate != "" && startDate != null && endDate != null)
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                whereDate = $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";
            }
            if (depID != 0 && !string.IsNullOrWhiteSpace(whereDate))
            {

                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = depID };
                parameter.Add(sqlParameter);
                whereDepID = $" Where D.DepartmentID = @DepartmentID ";

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

IF OBJECT_ID('tempdb..#allCaseRegisterFilter') IS NOT NULL
DROP TABLE #allCaseRegisterFilter

SELECT
*
INTO #allCaseRegisterFilter
FROM #allCaseRegister
WHERE
DeletedFlag != 1
AND JFCaseTypeID = 5
AND JFCaseNo NOT LIKE '%สกย%'
" + whereDate +
@"
IF OBJECT_ID('tempdb..#totalCase') IS NOT NULL
DROP TABLE #totalCase

select 
ISNULL(D.DepartmentName,'รวม') AS DepartmentName
,ISNULL(SUM(tC.Total),0) AS Total
from 
Department AS D
LEFT JOIN
(
select COUNT(DepartmentID) AS Total ,
DepartmentID
from #allCaseRegisterFilter
Group By DepartmentID
) tC
ON D.DepartmentID = tC.DepartmentID
" + whereDepID +
@"
Group By  Rollup(D.DepartmentName)
";




            //AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;

        }

        public DataTable GetLawyerWorkingStep(int userID,int depID,int workstepID, string startDate,string endDate)
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            string wheresql = "";
            string whereLawyer = "";
            if (workstepID != 0)
            {
                
                if(workstepID <= 5)
                {
                    sqlParameter = new SqlParameter("@WorkStepID", System.Data.SqlDbType.Int) { Value = workstepID };
                    parameter.Add(sqlParameter);
                    wheresql += " AND WorkStepID = @WorkStepID ";

                }
                else
                {
                    sqlParameter = new SqlParameter("@WorkStepID", System.Data.SqlDbType.Int) { Value = 5 };
                    parameter.Add(sqlParameter);
                    wheresql += " AND WorkStepID > @WorkStepID ";
                }
            }
            if(depID != 0)
            {
                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = depID };
                parameter.Add(sqlParameter);
                wheresql += " AND DepartmentID = @DepartmentID ";
            }
            if (userID != 0 && userID != 99999)
            {
                sqlParameter = new SqlParameter("@UserID", System.Data.SqlDbType.Int) { Value = userID };
                parameter.Add(sqlParameter);
                whereLawyer = " Where LawyerID = @UserID ";
            }
            
            if (startDate != "" && endDate != "" && startDate != null && endDate != null)
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                wheresql += $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";
            }

            string sql = @"IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
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
,CaseMeetingMinutes.MeetingDate AS DecisionDate
,ISNULL(TbUser.UserID,9999) AS LawyerID
,TbUser.FirstName +' '+TbUser.LastName AS LawyerOfficerName
,D.DepartmentName
,P.ProvinceName
,CAT.Subject
,CASE 
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,GETDATE())) IS NULL AND COD.WorkStepID > 1  THEN ABS(DATEDIFF(Day,CAT.CreateDate,GETDATE()))
    ELSE ABS(DATEDIFF(Day,StartStep.ChangeDate,GETDATE()))
END AS DateOfCase
,StartStep.ChangeDate AS ReceivedDate
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
LEFT JOIN
 (SELECT CaseOwner.CaseID,
          CaseOwner.DepartmentID,
          CaseOwner.UserID
   FROM CaseOwner
   INNER JOIN
     (SELECT MAX(ChangeDate) AS ChangeDate,
             CaseID
      FROM CaseOwner
      GROUP BY CaseID) CurrentCaseOwner ON CaseOwner.CaseID = CurrentCaseOwner.CaseID
   AND CaseOwner.ChangeDate = CurrentCaseOwner.ChangeDate) CO ON CAT.CaseID = CO.CaseID
AND COD.DepartmentID = CO.DepartmentID
LEFT JOIN [User] AS TbUser ON CO.UserID = TbUser.UserID
LEFT JOIN (
select CaseID,WorkStepID,DepartmentID,MIN(ChangeDate) AS ChangeDate 
from CaseChangeWorkStepHistory Where WorkStepID = 2 Group by CaseID,WorkStepID,DepartmentID
) AS StartStep ON COD.CaseID = StartStep.CaseID AND COD.DepartmentID = StartStep.DepartmentID
LEFT JOIN Department AS D ON COD.DepartmentID = D.DepartmentID
INNER JOIN Province AS P ON D.ProvinceID = P.ProvinceID

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
AND DecisionDate IS NULL 
----- ไม่เอาเคสที่ยื่นเรื่อง
--AND WorkStepID != 1
--- ค้นหาจากวันที่รับเรื่อง
" + wheresql + @"
Order By RegisterDate ASC

select * from #allCaseRegisterFilter " + whereLawyer;    
            
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }
        public DataTable GetCaseSubCommitteeOpinion(List<SqlParameter> sqlParameter, string whereSql, string orderBySql = "")
        {
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
,COD.ProvinceID
,COD.StatusID
,COD.WorkStepID
,ISNULL(CAMOD.JFCaseNo,'') AS JFCaseNo
,CaseMeetingMinutes.MeetingDate AS  DecisionDate
,ISNULL(CST.SubcommitteeID,1) SubcommitteeID
,ISNULL(CST.OfficerRoleID,7) OfficerRoleID
,ISNULL(CAO.OpinionID,99) OpinionID

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
,ProvinceID
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
LEFT JOIN (
 SELECT 
  ISNULL(CT.CaseID,CSC.CaseID) CaseID
  ,ISNULL(CT.SubcommitteeID,CSC.SubcommitteeID) SubcommitteeID
  ,ISNULL(CT.FinalApproveID,CSC.OfficerRoleID) OfficerRoleID
  ,ISNULL(CT.TemID,CSC.TermID) TermID
 FROM CaseSubcommitteeConsideration CSC
LEFT JOIN CaseTerm CT
ON
CSC.CaseID = CT.CaseID
)CST
ON CAT.CaseID = CST.CaseID
LEFT JOIN (SELECT * FROM CaseApplicantOpinion WHERE IsFinalApproved = 1 AND OfficerRoleID = 7) CAO
ON CA.ApplicantID = CAO.ApplicantID

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

IF OBJECT_ID('tempdb..#tempcasecount') IS NOT NULL
DROP TABLE #tempcasecount

SELECT SubcommitteeID
	,[99] InProgress
	,[3] Disapproved
	,[8] Terminate
	,[9] FactAdditional
	,[1] Approve
	,[2] PartialApprove
	,([1]+[2]+[3]+[8]+[9]+[99]) TotalCase
INTO #tempcasecount
FROM #allCaseRegisterFilter CAT
PIVOT(
COUNT(CaseID)
FOR OpinionID IN ([1],[2],[3],[8],[9],[99])
)PV

IF OBJECT_ID('tempdb..#tempcasecountrequest') IS NOT NULL
DROP TABLE #tempcasecountrequest

SELECT SubcommitteeID
	,[99] InProgress
	,[3] Disapproved
	,[8] Terminate
	,[9] FactAdditional
	,[1] Approve
	,[2] PartialApprove
	,([1]+[2]+[3]+[8]+[9]+[99]) TotalCase
INTO #tempcasecountrequest
FROM (SELECT * FROM 
#allCaseRegisterFilter WHERE WorkStepID = 1 AND DecisionDate  IS NULL) CAT
PIVOT(
COUNT(CaseID)
FOR OpinionID IN ([1],[2],[3],[8],[9],[99])
)PV

IF OBJECT_ID('tempdb..#tempresult') IS NOT NULL
DROP TABLE #tempresult

SELECT SCM.SubcommitteeID
	,SCM.SubcommitteeName SubcommitteeNameRP
	,SUM(TCC.InProgress) InProgress
	,Cast(Round((SUM(TCC.InProgress)*100.0/SUM(TCC.TotalCase)),2) AS DECIMAL (10,2)) PercenInProgress
	,SUM(TCC.Disapproved) Disapproved
	,Cast(Round((SUM(TCC.Disapproved)*100.0/SUM(TCC.TotalCase)),2) AS DECIMAL (10,2)) PercenDisapproved
	,SUM(TCC.Terminate) Terminate
	,Cast(Round((SUM(TCC.Terminate)*100.0/SUM(TCC.TotalCase)),2) AS DECIMAL (10,2)) PercenTerminate
	,SUM(TCC.FactAdditional) FactAdditional
	,Cast(Round((SUM(TCC.FactAdditional)*100.0/SUM(TCC.TotalCase)),2) AS DECIMAL (10,2)) PercenFactAdditional
	,SUM(TCC.Approve) Approve
	,Cast(Round((SUM(TCC.Approve)*100.0/SUM(TCC.TotalCase)),2) AS DECIMAL (10,2)) PercenApprove
	,SUM(TCC.PartialApprove) PartialApprove
	,Cast(Round((SUM(TCC.PartialApprove)*100.0/SUM(TCC.TotalCase)),2) AS DECIMAL (10,2)) PercenPartialApprove
	,SUM(TCC.TotalCase) TotalCaseRP
INTO #tempresult
FROM Subcommittee SCM
LEFT JOIN #tempcasecount TCC
ON TCC.SubcommitteeID = SCM.SubcommitteeID
GROUP BY SCM.SubcommitteeID,SCM.SubcommitteeName


SELECT
TR.SubcommitteeID
	,TR.SubcommitteeNameRP
	,ISNULL(TR.InProgress,0) InProgress
	,ISNULL(TR.PercenInProgress,0) PercenInProgress
	,ISNULL(TR.Disapproved,0) Disapproved
	,ISNULL(TR.PercenDisapproved,0) PercenDisapproved
	,ISNULL(TR.Terminate,0) Terminate
	,ISNULL(TR.PercenTerminate,0) PercenTerminate
	,ISNULL(TR.FactAdditional,0) FactAdditional
	,ISNULL(TR.PercenFactAdditional,0) PercenFactAdditional
	,ISNULL(TR.Approve,0) Approve
	,ISNULL(TR.PercenApprove,0) PercenApprove
	,ISNULL(TR.PartialApprove,0) PartialApprove
	,ISNULL(TR.PercenPartialApprove,0) PercenPartialApprove
	,ISNULL(TR.TotalCaseRP,0) TotalCaseRP
FROM #tempresult TR
UNION
SELECT * FROM
(
SELECT 
7 AS SubcommitteeID
,'รวม' AS SubcommitteeNameRP 
,SUM(InProgress) InProgress
,Cast(Round((SUM(InProgress)*100.0/ SUM(TotalCaseRP)),2) AS DECIMAL (10,2)) PercenInProgress
,SUM(Disapproved) Disapproved
,Cast(Round((SUM(Disapproved)*100.0/ SUM(TotalCaseRP)),2) AS DECIMAL (10,2)) PercenDisapproved
,SUM(Terminate) Terminate
,Cast(Round((SUM(Terminate)*100.0/ SUM(TotalCaseRP)),2) AS DECIMAL (10,2)) PercenTerminate
,SUM(FactAdditional) FactAdditional
,Cast(Round((SUM(FactAdditional)*100.0/ SUM(TotalCaseRP)),2) AS DECIMAL (10,2)) PercenFactAdditional
,SUM(Approve) Approve
,Cast(Round((SUM(Approve)*100.0/ SUM(TotalCaseRP)),2) AS DECIMAL (10,2)) PercenApprove
,SUM(PartialApprove) PartialApprove
,Cast(Round((SUM(PartialApprove)*100.0/ SUM(TotalCaseRP)),2) AS DECIMAL (10,2)) PercenPartialApprove
,SUM(TotalCaseRP) TotalCaseRP
FROM 
#tempresult
) TB

 

 ";
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }
        public DataTable GetCaseStatistic(string startDate, string endDate,int startYear, int endYear)
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            string sql = "";
            string SetStart = "";
            string SetEnd = "";
            string whereDate = "";
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                whereDate = $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";
            }
            if (startYear != 0)
            {
                sqlParameter = new SqlParameter("@SetStart", System.Data.SqlDbType.Int) { Value = startYear };
                parameter.Add(sqlParameter);
                SetStart = $" @SetStart ";
            }
            if (endYear != 0)
            {
                sqlParameter = new SqlParameter("@SetEnd", System.Data.SqlDbType.Int) { Value = endYear };
                parameter.Add(sqlParameter);
                SetEnd = $" @SetEnd ";
            }
            sql = @"IF OBJECT_ID('tempdb..#tempYear') IS NOT NULL
DROP TABLE #tempYear

IF OBJECT_ID('tempdb..#tempMonthFinance') IS NOT NULL
DROP TABLE #tempMonthFinance


CREATE TABLE #tempYear
(
    TempYear int,
)
DECLARE @StartYear INT
SET @StartYear = "+SetStart+ @" 
DECLARE @EndYear INT
SET @EndYear = " + SetEnd + @" 

WHILE (@EndYear>=@StartYear)
BEGIN
insert into #tempYear values(@StartYear)
   SET @StartYear=@StartYear+1
END

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
IF OBJECT_ID('tempdb..#tempDate') IS NOT NULL
DROP TABLE #tempDate

select * into #tempDate from #tempYear,#tempMonthFinance

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
,CaseMeetingMinutes.MeetingDate AS DecisionDate

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
"+ whereDate + @"

IF OBJECT_ID('tempdb..#tempCase') IS NOT NULL
DROP TABLE #tempCase
select
CASE
    WHEN MONTH(RegisterDate) < 10 THEN YEAR(RegisterDate) + 543
    ELSE YEAR(RegisterDate) + 543 +1
END AS ThaiYearFinance
,MONTH(RegisterDate) as ThaiMonthFinance
,CaseID
,JFCaseTypeID
into #tempCase
from #allCaseRegisterFilter

IF OBJECT_ID('tempdb..#tempcasePivot') IS NOT NULL
DROP TABLE #tempcasePivot

SELECT ThaiYearFinance
,ThaiMonthFinance
,[1],[2],[3],[4]
into #tempcasePivot
FROM #tempCase
PIVOT (Count(CaseID)
FOR JFCaseTypeID IN ([1],[2],[3],[4])
) AS pvt

select 
tD.CurrentIndex
,tD.MonthFinance
,tD.TempYear AS 'ThaiYearFinance'
,ISNULL(tC.[1],0) AS JF1
,ISNULL(tC.[2],0) AS JF2
,ISNULL(tC.[3],0) AS JF3
,ISNULL(tC.[4],0) AS JF4
,ISNULL(tT.Total,0) AS TotalCase
from #tempDate AS tD
LEFT JOIN (
select
Count(CaseID) as Total
,ThaiYearFinance
,ThaiMonthFinance
from #tempCase
group by ThaiYearFinance,ThaiMonthFinance
) AS tT 
ON tD.MonthFinance = tT.ThaiMonthFinance
AND tD.TempYear = tT.ThaiYearFinance
Left Join #tempcasePivot AS tC
ON tC.ThaiMonthFinance = tD.MonthFinance
AND tC.ThaiYearFinance = tD.TempYear
ORDER BY tD.CurrentIndex,tD.TempYear ASC
";
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return CreateDataTable(cmd);
        }
        public DataTable GetResultReportOverview(string startDate, string endDate,int startYear , int endYear, int jfID)
        {
            string sql = "";
            string whereSql = "";
            string whereDate = "";
            string SetStart = "";
            string SetEnd = "";
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            if(!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                whereDate = $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";
            }
            if(jfID != 0)
            {
                sqlParameter = new SqlParameter("@JFCaseTypeID", System.Data.SqlDbType.Int) { Value = jfID };
                parameter.Add(sqlParameter);
                whereSql = $" Where JFCaseTypeID = @JFCaseTypeID ";
            }
            if (startYear != 0)
            {
                sqlParameter = new SqlParameter("@SetStart", System.Data.SqlDbType.Int) { Value = startYear };
                parameter.Add(sqlParameter);
                SetStart = $" @SetStart ";
            }
            if (endYear != 0)
            {
                sqlParameter = new SqlParameter("@SetEnd", System.Data.SqlDbType.Int) { Value = endYear };
                parameter.Add(sqlParameter);
                SetEnd = $" @SetEnd ";
            }
            sql = @"
IF OBJECT_ID('tempdb..#tempYearFinance') IS NOT NULL
DROP TABLE #tempYearFinance
DECLARE @StartYear INT
SET @StartYear = " +
SetStart
+ @" 
DECLARE @EndtYear INT
SET @EndtYear = " +
SetEnd
+ @" 
CREATE TABLE #tempYearFinance (YearFinance INT)  
WHILE (@StartYear <= @EndtYear)
BEGIN
    insert into #tempYearFinance VALUES(@StartYear) 
    SET @StartYear = @StartYear + 1;
END

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


IF OBJECT_ID('tempdb..#tempMonthJFCaseType') IS NOT NULL
DROP TABLE #tempMonthJFCaseType

SELECT  tMF.CurrentIndex,
	tMF.MonthFinance,
	JT.JFCaseTypeID,
	JT.CaseTypeName,
	JT.CaseTypeNameAbbr
INTO #tempMonthJFCaseType
FROM #tempMonthFinance AS tMF
CROSS JOIN 
(SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5) JT 

DECLARE @PivotColumns NVARCHAR(MAX)
SELECT @PivotColumns = COALESCE(@PivotColumns + ',','') + QUOTENAME([YearFinance])
FROM #tempYearFinance

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
,CaseMeetingMinutes.MeetingDate AS DecisionDate
,ISNULL(Decision.OpinionID,0) AS OpinionID
,ISNULL(Opinion.OpinionName,'กำลังดำเนินการ') AS OpinionName
,MONTH(CAT.RegisterDate) AS MonthFinance
,CASE WHEN MONTH(CAT.RegisterDate) > 9 THEN YEAR(CAT.RegisterDate) + 1 +543 
ELSE YEAR(CAT.RegisterDate) + 543 END AS YearFinance


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
LEFT JOIN 
	(
		SELECT DISTINCT CaseApplicantOpinion.ApplicantID,
				CaseApplicantOpinion.OfficerRoleID,
				CaseApplicantOpinion.OpinionID,
				CaseApplicantOpinion.AdditionalOpinion,
				CaseApplicantOpinion.Comment,
				CaseApplicantOpinion.ShortComment,
				CaseApplicantOpinion.Remark
		FROM CaseApplicantOpinion
		INNER JOIN
			(SELECT ApplicantID,
				MAX(ModifiedDate) AS ModifiedDate
			FROM CaseApplicantOpinion
			WHERE IsFinalApproved != 0
			GROUP BY ApplicantID) CurrentComplete ON CaseApplicantOpinion.ApplicantID = CurrentComplete.ApplicantID
			AND CaseApplicantOpinion.ModifiedDate = CurrentComplete.ModifiedDate
	)
	AS Decision ON CA.ApplicantID = Decision.ApplicantID 
LEFT JOIN Opinion ON Decision.OpinionID = Opinion.OpinionID

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
"+ whereDate + @"

IF OBJECT_ID('tempdb..##ApproveTable') IS NOT NULL
  DROP TABLE ##ApproveTable DECLARE @ApproveSQL AS NVARCHAR(MAX)
  SET @ApproveSQL = '
select pvt.JFCaseTypeID,pvt.MonthFinance,'+@PivotColumns+'
from
(
select JFCaseTypeID,MonthFinance,OpinionID,YearFinance
from #allCaseRegisterFilter where OpinionID = 1
) AS Tb
PIVOT (Count(OpinionID)
FOR YearFinance IN ('+@PivotColumns+')
) AS pvt' DECLARE @ApproveColumns NVARCHAR(MAX)
  SELECT @ApproveColumns = COALESCE(@ApproveColumns + ',',
                                    '') + QUOTENAME([YearFinance])+ ' AS '''+CONVERT(varchar, YearFinance) +'_Approve'''
  FROM #tempYearFinance
  SET @ApproveSQL = 'select JFCaseTypeID,MonthFinance,'+@ApproveColumns+' into ##ApproveTable from ('+@ApproveSQL+') y' execute(@ApproveSQL) DECLARE @ApproveShow NVARCHAR(MAX)
  SELECT @ApproveShow = COALESCE(@ApproveShow + ',',
                                 '') + 'ISNULL('+'['+CONVERT(varchar, YearFinance) +'_Approve]' +',0)' + 'AS ' +'['+CONVERT(varchar, YearFinance) +'_Approve]'
  FROM #tempYearFinance ---- Case ที่มีผลอนุมัติบางส่วน
 IF OBJECT_ID('tempdb..##Partially') IS NOT NULL
  DROP TABLE ##Partially DECLARE @PartiallySQL AS NVARCHAR(MAX)
  SET @PartiallySQL = '
select pvt.JFCaseTypeID,pvt.MonthFinance,'+@PivotColumns+' from
(
select JFCaseTypeID,MonthFinance,OpinionID,YearFinance
from #allCaseRegisterFilter where OpinionID = 2
) AS Tb
PIVOT (Count(OpinionID)
FOR YearFinance IN ('+@PivotColumns+')
) AS pvt' DECLARE @PartiallyColumns NVARCHAR(MAX)
  SELECT @PartiallyColumns = COALESCE(@PartiallyColumns + ',',
                                      '') + QUOTENAME([YearFinance])+ ' AS '''+CONVERT(varchar, YearFinance) +'_Partially'''
  FROM #tempYearFinance
  SET @PartiallySQL = 'select JFCaseTypeID,MonthFinance,'+@PartiallyColumns+' into ##Partially from ('+@PartiallySQL+') y' execute(@PartiallySQL) DECLARE @PartiallyShow NVARCHAR(MAX)
  SELECT @PartiallyShow = COALESCE(@PartiallyShow + ',',
                                   '') + 'ISNULL('+'['+CONVERT(varchar, YearFinance) +'_Partially]' +',0)' + 'AS ' +'['+CONVERT(varchar, YearFinance) +'_Partially]'
  FROM #tempYearFinance ---- Case ที่มีผลไม่อนุมัติ
IF OBJECT_ID('tempdb..##Disapprove') IS NOT NULL
  DROP TABLE ##Disapprove DECLARE @DisapproveSQL AS NVARCHAR(MAX)
  SET @DisapproveSQL = '
select pvt.JFCaseTypeID,pvt.MonthFinance,'+@PivotColumns+' from
(
select JFCaseTypeID,MonthFinance,OpinionID,YearFinance
from #allCaseRegisterFilter where OpinionID = 3
) AS Tb
PIVOT (Count(OpinionID)
FOR YearFinance IN ('+@PivotColumns+')
) AS pvt' DECLARE @DisapproveColumns NVARCHAR(MAX)
  SELECT @DisapproveColumns = COALESCE(@DisapproveColumns + ',',
                                       '') + QUOTENAME([YearFinance])+ ' AS '''+CONVERT(varchar, YearFinance) +'_Disapprove'''
  FROM #tempYearFinance
  SET @DisapproveSQL = 'select JFCaseTypeID,MonthFinance,'+@DisapproveColumns+' into ##Disapprove from ('+@DisapproveSQL+') y' execute(@DisapproveSQL) DECLARE @DisapproveShow NVARCHAR(MAX)
  SELECT @DisapproveShow = COALESCE(@DisapproveShow + ',',
                                    '') + 'ISNULL('+'['+CONVERT(varchar, YearFinance) +'_Disapprove]' +',0)' + 'AS ' +'['+CONVERT(varchar, YearFinance) +'_Disapprove]'
  FROM #tempYearFinance ---- Case ที่มีผลยุติ
IF OBJECT_ID('tempdb..##Terminate') IS NOT NULL
  DROP TABLE ##Terminate DECLARE @TerminateSQL AS NVARCHAR(MAX)
  SET @TerminateSQL = '
select pvt.JFCaseTypeID,pvt.MonthFinance,'+@PivotColumns+' from
(
select JFCaseTypeID,MonthFinance,OpinionID,YearFinance
from #allCaseRegisterFilter where OpinionID = 8
) AS Tb
PIVOT (Count(OpinionID)
FOR YearFinance IN ('+@PivotColumns+')
) AS pvt' DECLARE @TerminateColumns NVARCHAR(MAX)
  SELECT @TerminateColumns = COALESCE(@TerminateColumns + ',',
                                      '') + QUOTENAME([YearFinance])+ ' AS '''+CONVERT(varchar, YearFinance) +'_Terminate'''
  FROM #tempYearFinance
  SET @TerminateSQL = 'select JFCaseTypeID,MonthFinance,'+@TerminateColumns+' into ##Terminate from ('+@TerminateSQL+') y' execute(@TerminateSQL) DECLARE @TerminateShow NVARCHAR(MAX)
  SELECT @TerminateShow = COALESCE(@TerminateShow + ',',
                                   '') + 'ISNULL('+'['+CONVERT(varchar, YearFinance) +'_Terminate]' +',0)' + 'AS ' +'['+CONVERT(varchar, YearFinance) +'_Terminate]'
  FROM #tempYearFinance ---- Case ที่มีผลพิจารณา
IF OBJECT_ID('tempdb..##NotConsidered') IS NOT NULL
  DROP TABLE ##NotConsidered DECLARE @NotConsideredSQL AS NVARCHAR(MAX)
  SET @NotConsideredSQL = '
select pvt.JFCaseTypeID,pvt.MonthFinance,'+@PivotColumns+' from
(
select JFCaseTypeID,MonthFinance,OpinionID,YearFinance
from #allCaseRegisterFilter where OpinionID = 0
) AS Tb
PIVOT (Count(OpinionID)
FOR YearFinance IN ('+@PivotColumns+')
) AS pvt' DECLARE @NotConsideredColumns NVARCHAR(MAX)
  SELECT @NotConsideredColumns = COALESCE(@NotConsideredColumns + ',',
                                          '') + QUOTENAME([YearFinance])+ ' AS '''+CONVERT(varchar, YearFinance) +'_NotConsidered'''
  FROM #tempYearFinance
  SET @NotConsideredSQL = 'select JFCaseTypeID,MonthFinance,'+@NotConsideredColumns+' into ##NotConsidered from ('+@NotConsideredSQL+') y' execute(@NotConsideredSQL) DECLARE @NotConsideredShow NVARCHAR(MAX)
  SELECT @NotConsideredShow = COALESCE(@NotConsideredShow + ',',
                                       '') + 'ISNULL('+'['+CONVERT(varchar, YearFinance) +'_NotConsidered]' +',0)' + 'AS ' +'['+CONVERT(varchar, YearFinance) +'_NotConsidered]'
 FROM #tempYearFinance 


 
IF OBJECT_ID('tempdb..##RepeatTable') IS NOT NULL
  DROP TABLE ##RepeatTable DECLARE @RepeatSQL AS NVARCHAR(MAX)
  SET @RepeatSQL = '
select pvt.JFCaseTypeID,pvt.MonthFinance,'+@PivotColumns+'
from
(
select JFCaseTypeID,MonthFinance,OpinionID,YearFinance
from #allCaseRegisterFilter where OpinionID = 9
) AS Tb
PIVOT (Count(OpinionID)
FOR YearFinance IN ('+@PivotColumns+')
) AS pvt' DECLARE @RepeatColumns NVARCHAR(MAX)
  SELECT @RepeatColumns = COALESCE(@RepeatColumns + ',',
                                    '') + QUOTENAME([YearFinance])+ ' AS '''+CONVERT(varchar, YearFinance) +'_Repeat'''
  FROM #tempYearFinance
  SET @RepeatSQL = 'select JFCaseTypeID,MonthFinance,'+@RepeatColumns+' into ##RepeatTable from ('+@RepeatSQL+') y' execute(@RepeatSQL) DECLARE @RepeatShow NVARCHAR(MAX)
  SELECT @RepeatShow = COALESCE(@RepeatShow + ',',
                                 '') + 'ISNULL('+'['+CONVERT(varchar, YearFinance) +'_Repeat]' +',0)' + 'AS ' +'['+CONVERT(varchar, YearFinance) +'_Repeat]'
 FROM #tempYearFinance 





 --select * from #tempMonthJFCaseType
 ----- รายงาน
IF OBJECT_ID('tempdb..##ReportTable') IS NOT NULL
  DROP TABLE ##ReportTable DECLARE @ReportTable NVARCHAR(MAX)
  SET @ReportTable = '
SELECT 
tMJ.CurrentIndex,tMJ.MonthFinance,
CASE
    WHEN tMJ.MonthFinance = 10 THEN' + '''ตุลาคม'''+'
    WHEN tMJ.MonthFinance = 11 THEN' + '''พฤศจิกายน'''+'
    WHEN tMJ.MonthFinance = 12 THEN' + '''ธันวาคม'''+'
    WHEN tMJ.MonthFinance = 1 THEN' + '''มกราคม'''+'
    WHEN tMJ.MonthFinance = 2 THEN' + '''กุมพาพันธ์'''+'
    WHEN tMJ.MonthFinance = 3 THEN' + '''มีนาคม'''+'
    WHEN tMJ.MonthFinance = 4 THEN' + '''เมษายน'''+'
    WHEN tMJ.MonthFinance = 5 THEN' + '''พฤษภาคม'''+'
    WHEN tMJ.MonthFinance = 6 THEN' + '''มิถุนายน'''+'
    WHEN tMJ.MonthFinance = 7 THEN' + '''กรกฏาคม'''+'
    WHEN tMJ.MonthFinance = 8 THEN' + '''สิงหาคม'''+'
    ELSE '+ '''กันยายน'''+'
END AS Months
,tMJ.JFCaseTypeID,tMJ.CaseTypeNameAbbr,'+@ApproveShow+','+@PartiallyShow+',' +@DisapproveShow+','+@TerminateShow+','+@NotConsideredShow+','+@RepeatShow+ 'INTO ##ReportTable
FROM #tempMonthJFCaseType AS tMJ
LEFT JOIN ##ApproveTable AS Apt 
ON tMJ.MonthFinance = Apt.MonthFinance AND tMJ.JFCaseTypeID = Apt.JFCaseTypeID
LEFT JOIN ##Partially AS Ptt 
ON tMJ.MonthFinance = Ptt.MonthFinance AND tMJ.JFCaseTypeID = Ptt.JFCaseTypeID
LEFT JOIN ##Disapprove AS Dpt
ON tMJ.MonthFinance = Dpt.MonthFinance AND tMJ.JFCaseTypeID = Dpt.JFCaseTypeID
LEFT JOIN ##Terminate AS Tmt
ON tMJ.MonthFinance = Tmt.MonthFinance AND tMJ.JFCaseTypeID = Tmt.JFCaseTypeID
LEFT JOIN ##NotConsidered AS Nct
ON tMJ.MonthFinance = Nct.MonthFinance AND tMJ.JFCaseTypeID = Nct.JFCaseTypeID
LEFT JOIN ##RepeatTable AS Rpt
ON tMJ.MonthFinance = Rpt.MonthFinance AND tMJ.JFCaseTypeID = Rpt.JFCaseTypeID
'
 execute(@ReportTable)

IF OBJECT_ID('tempdb..##ReportWhere') IS NOT NULL
  DROP TABLE ##ReportWhere
select
*
INTO ##ReportWhere
from 
##ReportTable
"+whereSql+
@"

DECLARE @SummaryApprove NVARCHAR(MAX)
SELECT @SummaryApprove = COALESCE(@SummaryApprove + ',',
                                      '')+ 'SUM(' + QUOTENAME(CONVERT(varchar, YearFinance)+ '_Approve')+ ') AS '''+CONVERT(varchar, YearFinance) +'_Approve'''
FROM #tempYearFinance
DECLARE @SummaryPartially NVARCHAR(MAX)
SELECT @SummaryPartially = COALESCE(@SummaryPartially + ',',
                                      '')+ 'SUM(' + QUOTENAME(CONVERT(varchar, YearFinance)+ '_Partially')+ ') AS '''+CONVERT(varchar, YearFinance) +'_Partially'''
FROM #tempYearFinance
DECLARE @SummaryDisapprove NVARCHAR(MAX)
SELECT @SummaryDisapprove = COALESCE(@SummaryDisapprove + ',',
                                      '')+ 'SUM(' + QUOTENAME(CONVERT(varchar, YearFinance)+ '_Disapprove')+ ') AS '''+CONVERT(varchar, YearFinance) +'_Disapprove'''
FROM #tempYearFinance
DECLARE @SummaryTerminate NVARCHAR(MAX)
SELECT @SummaryTerminate = COALESCE(@SummaryTerminate + ',',
                                      '')+ 'SUM(' + QUOTENAME(CONVERT(varchar, YearFinance)+ '_Terminate')+ ') AS '''+CONVERT(varchar, YearFinance) +'_Terminate'''
FROM #tempYearFinance
DECLARE @SummaryNotConsidered NVARCHAR(MAX)
SELECT @SummaryNotConsidered = COALESCE(@SummaryNotConsidered + ',',
                                      '')+ 'SUM(' + QUOTENAME(CONVERT(varchar, YearFinance)+ '_NotConsidered')+ ') AS '''+CONVERT(varchar, YearFinance) +'_NotConsidered'''
FROM #tempYearFinance
DECLARE @SummaryRepeat NVARCHAR(MAX)
SELECT @SummaryRepeat = COALESCE(@SummaryRepeat + ',',
                                      '')+ 'SUM(' + QUOTENAME(CONVERT(varchar, YearFinance)+ '_Repeat')+ ') AS '''+CONVERT(varchar, YearFinance) +'_Repeat'''
FROM #tempYearFinance


DECLARE @SummaryeTable AS NVARCHAR(MAX)
  SET @SummaryeTable = '
  select * from (
    SELECT *
  FROM ##ReportWhere
  UNION
  SELECT 999 AS CurrentIndex
  ,'''+''' AS MonthFinance
  ,'''+'รวม'+''' AS Months
  ,'''+''' AS JFCaseTypeID
  ,'''+''' AS CaseTypeNameAbbr
  ,'+@SummaryApprove+ ','+@SummaryPartially+ ','+@SummaryDisapprove+ ','+@SummaryTerminate+ ','+@SummaryNotConsidered+ ','+@SummaryRepeat+'
  FROM ##ReportWhere
  )tb 


  '
    

  execute(@SummaryeTable)


";





            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return CreateDataTable(cmd);
        }
        public DataTable GetStandardByProvince(string startDate, string endDate, int depID)
        {
            string sql = "";

            string where = "";
            string whereDep = "";
          
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            if (depID != 0)
            {
                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = depID };
                parameter.Add(sqlParameter);
                whereDep = $" Where DepartmentID = @DepartmentID ";
            }
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                where = $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";
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
INNER JOIN 
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
" + where + @"


 IF OBJECT_ID('tempdb..#tempCaseFinishedKPI') IS NOT NULL
DROP TABLE #tempCaseFinishedKPI

select
aCRF.CaseID 
,CASE 
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,DecisionDate)) BETWEEN 0 AND 21 THEN 'FinishedKPI_21'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,DecisionDate)) BETWEEN 22 AND 30 THEN 'FinishedKPI_22-30'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,DecisionDate)) BETWEEN 31 AND 45 THEN 'FinishedKPI_31-45'
    ELSE 'FinishedKPI_Over45'
END AS KPIStatus
,aCRF.DepartmentID
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
		  WHERE WorkStepID = 2
		  GROUP BY CaseID,
				WorkStepID,
				DepartmentID) MDX
	ON CCW.ModifiedDate = MDX.ModifiedDate
   WHERE CCW.WorkStepID = 2 
   GROUP BY CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID
) AS StartStep ON aCRF.CaseID = StartStep.CaseID AND aCRF.DepartmentID = StartStep.DepartmentID

IF OBJECT_ID('tempdb..#tempCountCaseFinishedKPI') IS NOT NULL
DROP TABLE #tempCountCaseFinishedKPI
SELECT DepartmentID
	,[FinishedKPI_21]
	,[FinishedKPI_22-30]
	,[FinishedKPI_31-45]
	,[FinishedKPI_Over45]
INTO #tempCountCaseFinishedKPI
FROM #tempCaseFinishedKPI
PIVOT(COUNT(CaseID) FOR KPIStatus IN ([FinishedKPI_21],[FinishedKPI_22-30],[FinishedKPI_31-45],[FinishedKPI_Over45]))PV

IF OBJECT_ID('tempdb..#tempCaseWorkingKPI') IS NOT NULL
DROP TABLE #tempCaseWorkingKPI

select
aCRF.CaseID 
,CASE 
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,GETDATE())) BETWEEN 0 AND 21 THEN 'WorkKPI_21'
    ELSE 'WorkKPI_Over21'
END AS KPIStatus
,aCRF.DepartmentID
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

IF OBJECT_ID('tempdb..#tempCountCaseWorkingKPI') IS NOT NULL
DROP TABLE #tempCountCaseWorkingKPI
SELECT DepartmentID
	,[WorkKPI_21]
	,[WorkKPI_Over21]
INTO #tempCountCaseWorkingKPI
FROM #tempCaseWorkingKPI
PIVOT(COUNT(CaseID) FOR KPIStatus IN ([WorkKPI_21],[WorkKPI_Over21]))PV

IF OBJECT_ID('tempdb..#tempTotalCaseRequest') IS NOT NULL
DROP TABLE #tempTotalCaseRequest

SELECT ACRF.DepartmentID
,COUNT(ACRF.CaseID) AS TotalCase
INTO #tempTotalCaseRequest
FROM (select * from #allCaseRegisterFilter Where WorkStepID = 1 AND DecisionDate IS NULL) AS ACRF
GROUP BY ACRF.DepartmentID

IF OBJECT_ID('tempdb..#tempTotalCase') IS NOT NULL
DROP TABLE #tempTotalCase

SELECT ACRF.DepartmentID
,COUNT(ACRF.CaseID) AS TotalCase
INTO #tempTotalCase
FROM #allCaseRegisterFilter AS ACRF
GROUP BY ACRF.DepartmentID

IF OBJECT_ID('tempdb..#tempCaseResultToTable') IS NOT NULL
DROP TABLE #tempCaseResultToTable

SELECT D.DepartmentID
	,D.DepartmentName
	,ISNULL(ttCR.TotalCase,0) 'WaitingStep'
	,ISNULL(tccFK.FinishedKPI_21,0) 'FinishedKPI_21'
	,Case
WHEN ISNULL(ttC.TotalCase,0) - ( ISNULL(tTCR.TotalCase,0) + ISNULL(tccWK.WorkKPI_21,0) + ISNULL(tccWK.WorkKPI_Over21,0)) > 0  
THEN CAST(ROUND((ISNULL(tccFK.FinishedKPI_21,0)*100.0)/(ISNULL(ttC.TotalCase,0) - (ISNULL(tTCR.TotalCase,0) + ISNULL(tccWK.WorkKPI_21,0) + ISNULL(tccWK.WorkKPI_Over21,0))),2) AS DECIMAL (10,2)) 
ELSE 0.00
END AS 'PersentFinished'
	,ISNULL(tccFK.[FinishedKPI_22-30],0) 'FinishedKPI_22-30'
	,ISNULL(tccFK.[FinishedKPI_31-45],0) 'FinishedKPI_31-45'
	,ISNULL(tccFK.FinishedKPI_Over45,0) 'FinishedKPI_Over45'
	,ISNULL(tccWK.WorkKPI_21,0) 'WorkKPI_21'
	,ISNULL(tccWK.WorkKPI_Over21,0) 'WorkKPI_Over21'
	,ISNULL(ttC.TotalCase,0) 'TotalCase'
INTO #tempCaseResultToTable
FROM Department D
LEFT JOIN #tempTotalCaseRequest ttCR
ON D.DepartmentID = ttCR.DepartmentID
LEFT JOIN #tempCountCaseWorkingKPI tccWK
ON D.DepartmentID = tccWK.DepartmentID
LEFT JOIN #tempCountCaseFinishedKPI tccFK
ON D.DepartmentID = tccFK.DepartmentID
LEFT JOIN #tempTotalCase ttC
ON D.DepartmentID = ttC.DepartmentID

IF OBJECT_ID('tempdb..#tempCaseResultToTableWhereDepID') IS NOT NULL
DROP TABLE #tempCaseResultToTableWhereDepID
SELECT * 
INTO #tempCaseResultToTableWhereDepID
FROM 
#tempCaseResultToTable

" + whereDep + @"

IF OBJECT_ID('tempdb..#tempResult') IS NOT NULL
DROP TABLE #tempResult

SELECT * 
INTO #tempResult
FROM
(
SELECT * 
FROM #tempCaseResultToTableWhereDepID
UNION (
SELECT 999 DepartmentID
	,'รวม' DepartmentName
	,SUM(WaitingStep) WaitingStep
	,SUM(FinishedKPI_21) FinishedKPI_21
	,Case
WHEN SUM(TotalCase) - ( SUM(TotalCase) + SUM(WorkKPI_21) + SUM(WorkKPI_Over21)) > 0  
THEN CAST(ROUND((SUM(FinishedKPI_21)*100.0)/(SUM(TotalCase) - (SUM(TotalCase) + SUM(WorkKPI_21) + SUM(WorkKPI_Over21))),2) AS DECIMAL (10,2)) 
ELSE 0.00
END AS 'PersentFinished'
	,SUM([FinishedKPI_22-30]) 'FinishedKPI_22-30'
	,SUM([FinishedKPI_31-45]) 'FinishedKPI_31-45'
	,SUM(FinishedKPI_Over45) 'FinishedKPI_Over45'
	,SUM(WorkKPI_21) 'WorkKPI_21'
	,SUM(WorkKPI_Over21) 'WorkKPI_Over21'
	,SUM(TotalCase) 'TotalCase-30'
FROM #tempCaseResultToTableWhereDepID
))TB
SELECT * FROM 
(SELECT ROW_NUMBER() OVER (ORDER BY DepartmentID) RowRank,* 
   FROM #tempResult)tb

";
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return CreateDataTable(cmd);
        }
        public DataTable GetStandardByMonth(int year)
        {
            string sql = @"[jfs_sp_standardbymonth]";
            SqlCommand cmd = CreateCommand(sql, true);
            cmd.Parameters.Add("@YearFinance", SqlDbType.Int).Value = year;
            return CreateDataTable(cmd);
        }
        public DataTable GetStandardByMonth(string startDate, string endDate, int depID)
        {
            string sql = "";
            string where = "";
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            if(!string.IsNullOrEmpty(startDate) &&!string.IsNullOrEmpty(endDate))
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                where = $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";


            }
            if(depID != 0)
            {
                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = depID };
                parameter.Add(sqlParameter);
                where += $" AND DepartmentID = @DepartmentID ";
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
,PT.ProvinceTypeCode
,ISNULL(CAMOD.JFCaseNo,'') AS JFCaseNo
,CASE
    WHEN MONTH(CAT.RegisterDate) < 10 THEN YEAR(CAT.RegisterDate) + 543
    ELSE YEAR(CAT.RegisterDate) + 543 +1
END AS ThaiYearFinance
,MONTH(CAT.RegisterDate) AS ThaiMonthFinance
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
LEFT JOIN Department AS D
ON COD.DepartmentID = D.DepartmentID
LEFT JOIN ProvinceExtension AS PE
ON D.ProvinceID = PE.ProvinceID
LEFT JOIN ProvinceType AS PT
ON PE.ProvinceTypeCode = PT.ProvinceTypeCode
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
"+where+ @"
Order By ApplicantID ASC


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





IF OBJECT_ID('tempdb..#tempCaseFinishedKPI') IS NOT NULL
DROP TABLE #tempCaseFinishedKPI

select
aCRF.CaseID 
,MONTH(aCRF.RegisterDate) AS ThaiMonthFinance
,CASE 
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,DecisionDate)) BETWEEN 0 AND 21 THEN 'FinishedKPI_21'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,DecisionDate)) BETWEEN 22 AND 30 THEN 'FinishedKPI_22-30'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,DecisionDate)) BETWEEN 31 AND 45 THEN 'FinishedKPI_31-45'
    ELSE 'FinishedKPI_Over45'
END AS KPIStatus
,CASE
    WHEN MONTH(RegisterDate) < 10 THEN YEAR(RegisterDate) + 543
    ELSE YEAR(RegisterDate) + 543 +1
END AS ThaiYearFinance
INTO #tempCaseFinishedKPI
from 
(
select * from 
#allCaseRegisterFilter Where WorkStepID > 1 AND DecisionDate IS NOT NULL
)AS aCRF
LEFT JOIN (
select CaseID,WorkStepID,DepartmentID,MIN(ChangeDate) AS ChangeDate 
from CaseChangeWorkStepHistory Where WorkStepID = 2 Group by CaseID,WorkStepID,DepartmentID
) AS StartStep ON aCRF.CaseID = StartStep.CaseID AND aCRF.DepartmentID = StartStep.DepartmentID


IF OBJECT_ID('tempdb..#tempFinished') IS NOT NULL
DROP TABLE #tempFinished

select ThaiMonthFinance,ThaiYearFinance,[FinishedKPI_21],[FinishedKPI_22-30],[FinishedKPI_31-45],[FinishedKPI_Over45]
INTO #tempFinished
from 
#tempCaseFinishedKPI
PIVOT (count(CaseID)
FOR KPIStatus IN ([FinishedKPI_21],[FinishedKPI_22-30],[FinishedKPI_31-45],[FinishedKPI_Over45])
) AS pvt


IF OBJECT_ID('tempdb..#tempCaseWorkingKPI') IS NOT NULL
DROP TABLE #tempCaseWorkingKPI


select
aCRF.CaseID 
,MONTH(aCRF.RegisterDate) AS ThaiMonthFinance
,CASE 
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,GETDATE())) BETWEEN 0 AND 21 THEN 'WorkKPI_21'
    ELSE 'WorkKPI_Over21'
END AS KPIStatus
,CASE
    WHEN MONTH(RegisterDate) < 10 THEN YEAR(RegisterDate) + 543
    ELSE YEAR(RegisterDate) + 543 +1
END AS ThaiYearFinance
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

select ThaiMonthFinance,ThaiYearFinance,[WorkKPI_21],[WorkKPI_Over21]
INTO #tempCaseWork
from 
#tempCaseWorkingKPI
PIVOT (count(CaseID)
FOR KPIStatus IN ([WorkKPI_21],[WorkKPI_Over21])
) AS pvt

IF OBJECT_ID('tempdb..#tempTotalCaseRequest') IS NOT NULL
DROP TABLE #tempTotalCaseRequest

select tmF.MonthFinance,COUNT(ProvinceID) AS TotalCase
INTO #tempTotalCaseRequest
from #tempMonthFinance AS tmF
INNER JOIN 
(
select 
P.ProvinceID
,PT.ProvinceTypeCode
,CASE
    WHEN MONTH(ACRF.RegisterDate) < 10 THEN YEAR(ACRF.RegisterDate) + 543
    ELSE YEAR(ACRF.RegisterDate) + 543 +1
END AS ThaiYearFinance
,MONTH(ACRF.RegisterDate) AS ThaiMonthFinance
from 
(select * from #allCaseRegisterFilter Where WorkStepID = 1 AND DecisionDate IS NULL) AS ACRF
INNER JOIN 
Department AS D
ON ACRF.DepartmentID = D.DepartmentID
INNER JOIN Province AS P
ON D.ProvinceID = P.ProvinceID
INNER JOIN ProvinceExtension AS PE
ON P.ProvinceID = PE.ProvinceID 
INNER JOIN ProvinceType AS PT
ON PE.ProvinceTypeCode = PT.ProvinceTypeCode
)
AS tacR
ON tmF.MonthFinance = tacR.ThaiMonthFinance 
--Where tacR.ProvinceID = 2 AND tacR.ProvinceTypeCode = 'CENTRAL'
Group By tmF.MonthFinance

IF OBJECT_ID('tempdb..#tempCaseResultToTable') IS NOT NULL
DROP TABLE #tempCaseResultToTable

SELECT
tMF.CurrentIndex,
tMF.MonthFinance,
MAX(ISNULL(tTCR.TotalCase,0)) AS 'WaitingStep',
MAX(ISNULL(tF.FinishedKPI_21,0)) AS 'FinishedKPI_21',
Case
WHEN SUM(ISNULL(tC.Total,0)) - ( SUM(ISNULL(tTCR.TotalCase,0)) + SUM(ISNULL(tcW.WorkKPI_21,0)) + SUM(ISNULL(tcW.WorkKPI_Over21,0))) > 0  
THEN Cast(Round((SUM(ISNULL(tF.FinishedKPI_21,0))*100.0)/(SUM(ISNULL(tC.Total,0)) - (SUM(ISNULL(tTCR.TotalCase,0)) + SUM(ISNULL(tcW.WorkKPI_21,0)) + SUM(ISNULL(tcW.WorkKPI_Over21,0)))),2) AS decimal (10,2)) 
ELSE 0.00
END AS PersentFinished,
MAX(ISNULL(tF.[FinishedKPI_22-30],0)) AS 'FinishedKPI_22-30' ,
MAX(ISNULL(tF.[FinishedKPI_31-45],0)) AS 'FinishedKPI_31-45',
MAX(ISNULL(tF.FinishedKPI_Over45,0)) AS 'FinishedKPI_Over45',
MAX(ISNULL(tCW.WorkKPI_21,0)) AS 'WorkKPI_21',
MAX(ISNULL(tCW.WorkKPI_Over21,0)) AS 'WorkKPI_Over21',
MAX(ISNULL(tC.Total,0)) AS TotalCase
INTO #tempCaseResultToTable
FROM #tempMonthFinance AS tMF
LEFT JOIN #tempFinished AS tF
ON tMF.MonthFinance = tF.ThaiMonthFinance
LEFT JOIN #tempCaseWork AS tCW
ON tMF.MonthFinance = tCW.ThaiMonthFinance
LEFT JOIN #tempTotalCaseRequest AS tTCR
ON tMF.MonthFinance = tTCR.MonthFinance
LEFT JOIN 
( SELECT 
COUNT(ProvinceTypeCode) AS Total,
ThaiMonthFinance,
ThaiYearFinance
FROM #allCaseRegisterFilter 
Group By ThaiMonthFinance,ThaiYearFinance ) AS tC
ON tMF.MonthFinance = tC.ThaiMonthFinance
Group By tMF.MonthFinance,tMF.CurrentIndex
ORDER BY tMF.CurrentIndex ASC

Select 
CurrentIndex
,CONVERT(varchar, MonthFinance) AS MonthFinance
,WaitingStep
,FinishedKPI_21
,PersentFinished
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
,'รวม' AS MonthFinance
,SUM(WaitingStep) AS 'WaitingStep'
,SUM([FinishedKPI_21]) AS 'FinishedKPI_21'
,Case
WHEN SUM(ISNULL(TotalCase,0)) - (SUM(ISNULL(WaitingStep,0)) + SUM(ISNULL(WorkKPI_21,0)) + SUM(ISNULL(WorkKPI_Over21,0)))  > 0  
THEN Cast(Round((SUM(ISNULL(FinishedKPI_21,0))*100.0)/(SUM(ISNULL(TotalCase,0)) -( SUM(ISNULL(WaitingStep,0)) + SUM(ISNULL(WorkKPI_21,0)) + SUM(ISNULL(WorkKPI_Over21,0)))),2) AS decimal (10,2)) 
ELSE 0.00
END AS PersentFinished
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
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }
        public DataTable GetStandardByRegion(string startDate, string endDate)
        {
            string sql = "";
            string where = "";

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                where = $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";
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
,PT.ProvinceTypeCode
,ISNULL(CAMOD.JFCaseNo,'') AS JFCaseNo
,CASE
    WHEN MONTH(CAT.RegisterDate) < 10 THEN YEAR(CAT.RegisterDate) + 543
    ELSE YEAR(CAT.RegisterDate) + 543 +1
END AS ThaiYearFinance
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
LEFT JOIN Department AS D
ON COD.DepartmentID = D.DepartmentID
LEFT JOIN ProvinceExtension AS PE
ON D.ProvinceID = PE.ProvinceID
LEFT JOIN ProvinceType AS PT
ON PE.ProvinceTypeCode = PT.ProvinceTypeCode
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
"+ where + @"


IF OBJECT_ID('tempdb..#tempProvinceType') IS NOT NULL
DROP TABLE #tempProvinceType

select 
ProvinceTypeCode,
ProvinceTypeName,
IsShow
INTO #tempProvinceType
from ProvinceType


IF OBJECT_ID('tempdb..#tempCaseFinishedKPI') IS NOT NULL
DROP TABLE #tempCaseFinishedKPI

select
aCRF.CaseID 
,aCRF.ProvinceTypeCode
,CASE 
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,DecisionDate)) BETWEEN 0 AND 21 THEN 'FinishedKPI_21'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,DecisionDate)) BETWEEN 22 AND 30 THEN 'FinishedKPI_22-30'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,DecisionDate)) BETWEEN 31 AND 45 THEN 'FinishedKPI_31-45'
    ELSE 'FinishedKPI_Over45'
END AS KPIStatus
,CASE
    WHEN MONTH(RegisterDate) < 10 THEN YEAR(RegisterDate) + 543
    ELSE YEAR(RegisterDate) + 543 +1
END AS ThaiYearFinance
INTO #tempCaseFinishedKPI
from 
(
select * from 
#allCaseRegisterFilter Where WorkStepID > 1 AND DecisionDate IS NOT NULL
)AS aCRF
LEFT JOIN
(SELECT CCW.CaseID,
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
) AS StartStep ON aCRF.CaseID = StartStep.CaseID AND aCRF.DepartmentID = StartStep.DepartmentID


IF OBJECT_ID('tempdb..#tempFinished') IS NOT NULL
DROP TABLE #tempFinished

select ProvinceTypeCode,ThaiYearFinance,[FinishedKPI_21],[FinishedKPI_22-30],[FinishedKPI_31-45],[FinishedKPI_Over45]
INTO #tempFinished
from 
#tempCaseFinishedKPI
PIVOT (count(CaseID)
FOR KPIStatus IN ([FinishedKPI_21],[FinishedKPI_22-30],[FinishedKPI_31-45],[FinishedKPI_Over45])
) AS pvt



IF OBJECT_ID('tempdb..#tempCaseWorkingKPI') IS NOT NULL
DROP TABLE #tempCaseWorkingKPI

select
aCRF.CaseID 
,CASE 
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,GETDATE())) BETWEEN 0 AND 21 THEN 'WorkKPI_21'
    ELSE 'WorkKPI_Over21'
END AS KPIStatus
,aCRF.ProvinceTypeCode
INTO #tempCaseWorkingKPI
from 
(
select * from 
#allCaseRegisterFilter Where WorkStepID > 1 AND DecisionDate IS NULL
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
		  WHERE WorkStepID = 2
		  GROUP BY CaseID,
				WorkStepID,
				DepartmentID) MDX
	ON CCW.ModifiedDate = MDX.ModifiedDate
   WHERE CCW.WorkStepID = 2 
   GROUP BY CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID
) AS StartStep ON aCRF.CaseID = StartStep.CaseID AND aCRF.DepartmentID = StartStep.DepartmentID


IF OBJECT_ID('tempdb..#tempCaseWork') IS NOT NULL
DROP TABLE #tempCaseWork


select ProvinceTypeCode,[WorkKPI_21],[WorkKPI_Over21]
INTO #tempCaseWork
from 
#tempCaseWorkingKPI
PIVOT (count(CaseID)
FOR KPIStatus IN ([WorkKPI_21],[WorkKPI_Over21])
) AS pvt


IF OBJECT_ID('tempdb..#tempCaseWaiting') IS NOT NULL
DROP TABLE #tempCaseWaiting

select ProvinceTypeCode,ThaiYearFinance,[1]
INTO #tempCaseWaiting
from
(select CaseID
,ProvinceTypeCode
,CASE
    WHEN MONTH(RegisterDate) < 10 THEN YEAR(RegisterDate) + 543
    ELSE YEAR(RegisterDate) + 543 +1
END AS ThaiYearFinance
,WorkStepID
from #allCaseRegisterFilter where WorkStepID = 1 AND DecisionDate IS NULL)tb
PIVOT (count(CaseID)
for WorkStepID IN ([1])
)as pvt


IF OBJECT_ID('tempdb..#tempCaseResultToTable') IS NOT NULL
DROP TABLE #tempCaseResultToTable

SELECT 
tYP.ProvinceTypeCode,
tYP.ProvinceTypeName,
MAX(ISNULL(tCWT.[1],0)) AS 'WaitingStep',
MAX(ISNULL(tF.FinishedKPI_21,0)) AS 'FinishedKPI_21',
Case
WHEN SUM(ISNULL(tC.Total,0)) - ( SUM(ISNULL(tCWT.[1],0)) + SUM(ISNULL(tcW.WorkKPI_21,0)) + SUM(ISNULL(tcW.WorkKPI_Over21,0))) > 0  
THEN Cast(Round((SUM(ISNULL(tF.FinishedKPI_21,0))*100.0)/(SUM(ISNULL(tC.Total,0)) - (SUM(ISNULL(tCWT.[1],0)) + SUM(ISNULL(tcW.WorkKPI_21,0)) + SUM(ISNULL(tcW.WorkKPI_Over21,0)))),2) AS decimal (10,2)) 
ELSE 0.00
END AS PersentFinished,
MAX(ISNULL(tF.[FinishedKPI_22-30],0)) AS 'FinishedKPI_22-30' ,
MAX(ISNULL(tF.[FinishedKPI_31-45],0)) AS 'FinishedKPI_31-45',
MAX(ISNULL(tF.FinishedKPI_Over45,0)) AS 'FinishedKPI_Over45',
MAX(ISNULL(tCW.WorkKPI_21,0)) AS 'WorkKPI_21',
MAX(ISNULL(tCW.WorkKPI_Over21,0)) AS 'WorkKPI_Over21',
MAX(ISNULL(tC.Total,0)) AS TotalCase
INTO #tempCaseResultToTable
FROM #tempProvinceType AS tYP
LEFT JOIN #tempFinished AS tF
ON tYP.ProvinceTypeCode = tF.ProvinceTypeCode
LEFT JOIN #tempCaseWork AS tCW
ON tYP.ProvinceTypeCode = tCW.ProvinceTypeCode
LEFT JOIN #tempCaseWaiting AS tCWT
ON tYP.ProvinceTypeCode = tCWT.ProvinceTypeCode
LEFT JOIN 
( SELECT 
COUNT(ProvinceTypeCode) AS Total,
ProvinceTypeCode,
ThaiYearFinance
FROM #allCaseRegisterFilter 
Group By ProvinceTypeCode,ThaiYearFinance ) AS tC
ON tYP.ProvinceTypeCode = tC.ProvinceTypeCode
Where tYP.IsShow != 0
GROUP BY tYP.ProvinceTypeCode,tYP.ProvinceTypeName
Order BY tYP.ProvinceTypeCode ASC

select * 
from #tempCaseResultToTable
UNION
select * from
(
select
'ZSUM' AS ProvinceTypeCode,
'รวม' AS ProvinceTypeName,
SUM(WaitingStep) AS 'WaitingStep',
SUM(FinishedKPI_21) AS 'FinishedKPI_21',
Case
WHEN SUM(ISNULL(TotalCase,0)) - (SUM(ISNULL(WaitingStep,0)) + SUM(ISNULL(WorkKPI_21,0)) + SUM(ISNULL(WorkKPI_Over21,0)))  > 0  
THEN Cast(Round((SUM(ISNULL(FinishedKPI_21,0))*100.0)/(SUM(ISNULL(TotalCase,0)) -( SUM(ISNULL(WaitingStep,0)) + SUM(ISNULL(WorkKPI_21,0)) + SUM(ISNULL(WorkKPI_Over21,0)))),2) AS decimal (10,2)) 
ELSE 0.00
END AS PersentFinished,
SUM([FinishedKPI_22-30]) AS 'FinishedKPI_22-30',
SUM([FinishedKPI_31-45]) AS 'FinishedKPI_31-45',
SUM([FinishedKPI_Over45]) AS 'FinishedKPI_Over45',
SUM([WorkKPI_21]) AS 'WorkKPI_21',
SUM([WorkKPI_Over21]) AS 'WorkKPI_Over21',
SUM([TotalCase]) AS 'TotalCase'
from 
#tempCaseResultToTable
)tb

";
           
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }
        public DataTable GetResultReportDepartment(string startDate, string endDate, int startYear, int endYear,int depID,int jfID)
        {
            string sql = "";
            string whereDate = "";
            string whereDepID = "";
            string SetStart = "";
            string SetEnd = "";
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                whereDate = $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";
            }
            if (depID != 0 && jfID != 0)
            {
                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = depID };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@JFCaseTypeID", System.Data.SqlDbType.Int) { Value = jfID };
                parameter.Add(sqlParameter);
                whereDepID = $" Where DepartmentID = @DepartmentID AND JFCaseTypeID = @JFCaseTypeID ";
            }
            else if( depID != 0 && jfID == 0)
            {
                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = depID };
                parameter.Add(sqlParameter);
                whereDepID = $" Where DepartmentID = @DepartmentID ";
            }
            else if(depID == 0 && jfID != 0)
            {
                sqlParameter = new SqlParameter("@JFCaseTypeID", System.Data.SqlDbType.Int) { Value = jfID };
                parameter.Add(sqlParameter);
                whereDepID = $" Where JFCaseTypeID = @JFCaseTypeID ";
            }
            if(startYear != 0)
            {
                sqlParameter = new SqlParameter("@SetStart", System.Data.SqlDbType.Int) { Value = startYear };
                parameter.Add(sqlParameter);
                SetStart = $" @SetStart ";
            }
            if(endYear != 0)
            {
                sqlParameter = new SqlParameter("@SetEnd", System.Data.SqlDbType.Int) { Value = endYear };
                parameter.Add(sqlParameter);
                SetEnd = $" @SetEnd ";
            }
            sql = @"
IF OBJECT_ID('tempdb..#tempYearFinance') IS NOT NULL
DROP TABLE #tempYearFinance
DECLARE @StartYear INT
SET @StartYear = "+
SetStart
+ @" 
DECLARE @EndtYear INT
SET @EndtYear =" +
SetEnd
+ @" 
CREATE TABLE #tempYearFinance (YearFinance INT) WHILE (@StartYear <= @EndtYear) BEGIN
INSERT INTO #tempYearFinance
VALUES(@StartYear) SET @StartYear = @StartYear + 1; END


IF OBJECT_ID('tempdb..#tempDepartmentJFCaseType') IS NOT NULL DROP TABLE #tempDepartmentJFCaseType SELECT DP.DepartmentID, DP.DepartmentName, JT.JFCaseTypeID, JT.CaseTypeName, JT.CaseTypeNameAbbr INTO #tempDepartmentJFCaseType FROM Department AS DP CROSS JOIN (SELECT * FROM JFCaseType WHERE JFCaseTypeID != 5) JT DECLARE @PivotColumns NVARCHAR(MAX) SELECT @PivotColumns = COALESCE(@PivotColumns + ',','') + QUOTENAME([YearFinance]) FROM #tempYearFinance IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL DROP TABLE #allCaseRegister SELECT CAT.CaseID,CA.ApplicantID,ISNULL(CA.DeletedFlag,0) AS DeletedFlag ,CAT.RegisterDate,CAT.JFCaseTypeID,COD.DepartmentID,COD.StatusID,COD.WorkStepID,ISNULL(CAMOD.JFCaseNo,'') AS JFCaseNo,CaseMeetingMinutes.MeetingDate AS DecisionDate,ISNULL(Decision.OpinionID,0) AS OpinionID,ISNULL(Opinion.OpinionName,'กำลังดำเนินการ') AS OpinionName,CASE WHEN MONTH(CAT.RegisterDate) > 9 THEN YEAR(CAT.RegisterDate) + 1 +543 ELSE YEAR(CAT.RegisterDate) + 543 END AS YearFinance INTO #allCaseRegister FROM CaseApplication AS CAT INNER JOIN CaseApplicant AS CA ON CAT.CaseID = CA.CaseID LEFT JOIN CaseApplicantExtension AS CAE ON CA.ApplicantID = CAE.ApplicantID LEFT JOIN CardType AS CT ON CAE.CardType = CT.CardTypeID LEFT JOIN (SELECT CaseID,DepartmentID,WorkStepID,StatusID ,IsAppeal FROM CaseOwnerDepartment WHERE StatusID != 6 ) AS COD ON CA.CaseID = COD.CaseID LEFT JOIN CaseApplicantMapOwnerDepartment AS CAMOD ON CA.ApplicantID = CAMOD.ApplicantID AND COD.DepartmentID = CAMOD.DepartmentID LEFT JOIN CaseApplicationStatus AS CAS ON COD.StatusID = CAS.CaseApplicationStatusID LEFT JOIN CaseMeetingMinutes ON CAT.CaseID = CaseMeetingMinutes.CaseID AND CA.ApplicantID = CaseMeetingMinutes.ApplicantID LEFT JOIN (SELECT DISTINCT CaseApplicantOpinion.ApplicantID, CaseApplicantOpinion.OfficerRoleID, CaseApplicantOpinion.OpinionID, CaseApplicantOpinion.AdditionalOpinion, CaseApplicantOpinion.Comment, CaseApplicantOpinion.ShortComment, CaseApplicantOpinion.Remark FROM CaseApplicantOpinion INNER JOIN (SELECT ApplicantID, MAX(ModifiedDate) AS ModifiedDate FROM CaseApplicantOpinion WHERE IsFinalApproved != 0 GROUP BY ApplicantID) CurrentComplete ON CaseApplicantOpinion.ApplicantID = CurrentComplete.ApplicantID AND CaseApplicantOpinion.ModifiedDate = CurrentComplete.ModifiedDate) AS Decision ON CA.ApplicantID = Decision.ApplicantID LEFT JOIN Opinion ON Decision.OpinionID = Opinion.OpinionID ---- ตั้งต้น Table ที่จะนำไปใช้งาน
 IF OBJECT_ID('tempdb..#allCaseRegisterFilter') IS NOT NULL
DROP TABLE #allCaseRegisterFilter
SELECT * INTO #allCaseRegisterFilter
FROM #allCaseRegister
WHERE DeletedFlag != 1
  AND JFCaseTypeID != 5
  AND JFCaseNo NOT LIKE '%สกย%' ---- Case ที่มีผลอนุมัติ
"+ whereDate + @"
 IF OBJECT_ID('tempdb..##ApproveTable') IS NOT NULL
  DROP TABLE ##ApproveTable DECLARE @ApproveSQL AS NVARCHAR(MAX)
  SET @ApproveSQL = '
select pvt.JFCaseTypeID,pvt.DepartmentID,'+@PivotColumns+'
from
(
select JFCaseTypeID,DepartmentID,OpinionID,YearFinance
from #allCaseRegisterFilter where OpinionID = 1
) AS Tb
PIVOT (Count(OpinionID)
FOR YearFinance IN ('+@PivotColumns+')
) AS pvt' DECLARE @ApproveColumns NVARCHAR(MAX)
  SELECT @ApproveColumns = COALESCE(@ApproveColumns + ',',
                                    '') + QUOTENAME([YearFinance])+ ' AS '''+CONVERT(varchar, YearFinance) +'_Approve'''
  FROM #tempYearFinance
  SET @ApproveSQL = 'select JFCaseTypeID,DepartmentID,'+@ApproveColumns+' into ##ApproveTable from ('+@ApproveSQL+') y' execute(@ApproveSQL) DECLARE @ApproveShow NVARCHAR(MAX)
  SELECT @ApproveShow = COALESCE(@ApproveShow + ',',
                                 '') + 'ISNULL('+'['+CONVERT(varchar, YearFinance) +'_Approve]' +',0)' + 'AS ' +'['+CONVERT(varchar, YearFinance) +'_Approve]'
  FROM #tempYearFinance ---- Case ที่มีผลอนุมัติบางส่วน
 IF OBJECT_ID('tempdb..##Partially') IS NOT NULL
  DROP TABLE ##Partially DECLARE @PartiallySQL AS NVARCHAR(MAX)
  SET @PartiallySQL = '
select pvt.JFCaseTypeID,pvt.DepartmentID,'+@PivotColumns+' from
(
select JFCaseTypeID,DepartmentID,OpinionID,YearFinance
from #allCaseRegisterFilter where OpinionID = 2
) AS Tb
PIVOT (Count(OpinionID)
FOR YearFinance IN ('+@PivotColumns+')
) AS pvt' DECLARE @PartiallyColumns NVARCHAR(MAX)
  SELECT @PartiallyColumns = COALESCE(@PartiallyColumns + ',',
                                      '') + QUOTENAME([YearFinance])+ ' AS '''+CONVERT(varchar, YearFinance) +'_Partially'''
  FROM #tempYearFinance
  SET @PartiallySQL = 'select JFCaseTypeID,DepartmentID,'+@PartiallyColumns+' into ##Partially from ('+@PartiallySQL+') y' execute(@PartiallySQL) DECLARE @PartiallyShow NVARCHAR(MAX)
  SELECT @PartiallyShow = COALESCE(@PartiallyShow + ',',
                                   '') + 'ISNULL('+'['+CONVERT(varchar, YearFinance) +'_Partially]' +',0)' + 'AS ' +'['+CONVERT(varchar, YearFinance) +'_Partially]'
  FROM #tempYearFinance ---- Case ที่มีผลไม่อนุมัติ
IF OBJECT_ID('tempdb..##Disapprove') IS NOT NULL
  DROP TABLE ##Disapprove DECLARE @DisapproveSQL AS NVARCHAR(MAX)
  SET @DisapproveSQL = '
select pvt.JFCaseTypeID,pvt.DepartmentID,'+@PivotColumns+' from
(
select JFCaseTypeID,DepartmentID,OpinionID,YearFinance
from #allCaseRegisterFilter where OpinionID = 3
) AS Tb
PIVOT (Count(OpinionID)
FOR YearFinance IN ('+@PivotColumns+')
) AS pvt' DECLARE @DisapproveColumns NVARCHAR(MAX)
  SELECT @DisapproveColumns = COALESCE(@DisapproveColumns + ',',
                                       '') + QUOTENAME([YearFinance])+ ' AS '''+CONVERT(varchar, YearFinance) +'_Disapprove'''
  FROM #tempYearFinance
  SET @DisapproveSQL = 'select JFCaseTypeID,DepartmentID,'+@DisapproveColumns+' into ##Disapprove from ('+@DisapproveSQL+') y' execute(@DisapproveSQL) DECLARE @DisapproveShow NVARCHAR(MAX)
  SELECT @DisapproveShow = COALESCE(@DisapproveShow + ',',
                                    '') + 'ISNULL('+'['+CONVERT(varchar, YearFinance) +'_Disapprove]' +',0)' + 'AS ' +'['+CONVERT(varchar, YearFinance) +'_Disapprove]'
  FROM #tempYearFinance ---- Case ที่มีผลยุติ
IF OBJECT_ID('tempdb..##Terminate') IS NOT NULL
  DROP TABLE ##Terminate DECLARE @TerminateSQL AS NVARCHAR(MAX)
  SET @TerminateSQL = '
select pvt.JFCaseTypeID,pvt.DepartmentID,'+@PivotColumns+' from
(
select JFCaseTypeID,DepartmentID,OpinionID,YearFinance
from #allCaseRegisterFilter where OpinionID = 8
) AS Tb
PIVOT (Count(OpinionID)
FOR YearFinance IN ('+@PivotColumns+')
) AS pvt' DECLARE @TerminateColumns NVARCHAR(MAX)
  SELECT @TerminateColumns = COALESCE(@TerminateColumns + ',',
                                      '') + QUOTENAME([YearFinance])+ ' AS '''+CONVERT(varchar, YearFinance) +'_Terminate'''
  FROM #tempYearFinance
  SET @TerminateSQL = 'select JFCaseTypeID,DepartmentID,'+@TerminateColumns+' into ##Terminate from ('+@TerminateSQL+') y' execute(@TerminateSQL) DECLARE @TerminateShow NVARCHAR(MAX)
  SELECT @TerminateShow = COALESCE(@TerminateShow + ',',
                                   '') + 'ISNULL('+'['+CONVERT(varchar, YearFinance) +'_Terminate]' +',0)' + 'AS ' +'['+CONVERT(varchar, YearFinance) +'_Terminate]'
  FROM #tempYearFinance ---- Case ที่มีผลพิจารณา
IF OBJECT_ID('tempdb..##NotConsidered') IS NOT NULL
  DROP TABLE ##NotConsidered DECLARE @NotConsideredSQL AS NVARCHAR(MAX)
  SET @NotConsideredSQL = '
select pvt.JFCaseTypeID,pvt.DepartmentID,'+@PivotColumns+' from
(
select JFCaseTypeID,DepartmentID,OpinionID,YearFinance
from #allCaseRegisterFilter where OpinionID = 0
) AS Tb
PIVOT (Count(OpinionID)
FOR YearFinance IN ('+@PivotColumns+')
) AS pvt' DECLARE @NotConsideredColumns NVARCHAR(MAX)
  SELECT @NotConsideredColumns = COALESCE(@NotConsideredColumns + ',',
                                          '') + QUOTENAME([YearFinance])+ ' AS '''+CONVERT(varchar, YearFinance) +'_NotConsidered'''
  FROM #tempYearFinance
  SET @NotConsideredSQL = 'select JFCaseTypeID,DepartmentID,'+@NotConsideredColumns+' into ##NotConsidered from ('+@NotConsideredSQL+') y' execute(@NotConsideredSQL) DECLARE @NotConsideredShow NVARCHAR(MAX)
  SELECT @NotConsideredShow = COALESCE(@NotConsideredShow + ',',
                                       '') + 'ISNULL('+'['+CONVERT(varchar, YearFinance) +'_NotConsidered]' +',0)' + 'AS ' +'['+CONVERT(varchar, YearFinance) +'_NotConsidered]'
  FROM #tempYearFinance ----- รายงาน
   
IF OBJECT_ID('tempdb..##RepeatTable') IS NOT NULL
  DROP TABLE ##RepeatTable DECLARE @RepeatSQL AS NVARCHAR(MAX)
  SET @RepeatSQL = '
select pvt.JFCaseTypeID,pvt.DepartmentID,'+@PivotColumns+'
from
(
select JFCaseTypeID,DepartmentID,OpinionID,YearFinance
from #allCaseRegisterFilter where OpinionID = 9
) AS Tb
PIVOT (Count(OpinionID)
FOR YearFinance IN ('+@PivotColumns+')
) AS pvt' DECLARE @RepeatColumns NVARCHAR(MAX)
  SELECT @RepeatColumns = COALESCE(@RepeatColumns + ',',
                                    '') + QUOTENAME([YearFinance])+ ' AS '''+CONVERT(varchar, YearFinance) +'_Repeat'''
  FROM #tempYearFinance
  SET @RepeatSQL = 'select JFCaseTypeID,DepartmentID,'+@RepeatColumns+' into ##RepeatTable from ('+@RepeatSQL+') y' execute(@RepeatSQL) DECLARE @RepeatShow NVARCHAR(MAX)
  SELECT @RepeatShow = COALESCE(@RepeatShow + ',',
                                 '') + 'ISNULL('+'['+CONVERT(varchar, YearFinance) +'_Repeat]' +',0)' + 'AS ' +'['+CONVERT(varchar, YearFinance) +'_Repeat]'
 FROM #tempYearFinance 










IF OBJECT_ID('tempdb..##ReportTable') IS NOT NULL
  DROP TABLE ##ReportTable DECLARE @ReportTable NVARCHAR(MAX)
  SET @ReportTable = '
SELECT 
tDJ.DepartmentID,tDJ.DepartmentName
,tDJ.JFCaseTypeID,tDJ.CaseTypeNameAbbr,'+@ApproveShow+','+@PartiallyShow+',' +@DisapproveShow+','+@TerminateShow+','+@NotConsideredShow+','+@RepeatShow+ 'INTO ##ReportTable
FROM #tempDepartmentJFCaseType AS tDJ
LEFT JOIN ##ApproveTable AS Apt 
ON tDJ.DepartmentID = Apt.DepartmentID AND tDJ.JFCaseTypeID = Apt.JFCaseTypeID
LEFT JOIN ##Partially AS Ptt 
ON tDJ.DepartmentID = Ptt.DepartmentID AND tDJ.JFCaseTypeID = Ptt.JFCaseTypeID
LEFT JOIN ##Disapprove AS Dpt
ON tDJ.DepartmentID = Dpt.DepartmentID AND tDJ.JFCaseTypeID = Dpt.JFCaseTypeID
LEFT JOIN ##Terminate AS Tmt
ON tDJ.DepartmentID = Tmt.DepartmentID AND tDJ.JFCaseTypeID = Tmt.JFCaseTypeID
LEFT JOIN ##NotConsidered AS Nct
ON tDJ.DepartmentID = Nct.DepartmentID AND tDJ.JFCaseTypeID = Nct.JFCaseTypeID
LEFT JOIN ##RepeatTable AS Rpt
ON tDJ.DepartmentID = Rpt.DepartmentID AND tDJ.JFCaseTypeID = Rpt.JFCaseTypeID
' execute(@ReportTable)

IF OBJECT_ID('tempdb..##ReportWhere') IS NOT NULL
  DROP TABLE ##ReportWhere
select
*
INTO ##ReportWhere
from 
##ReportTable
"
+ whereDepID +
@"




DECLARE @SummaryApprove NVARCHAR(MAX)
SELECT @SummaryApprove = COALESCE(@SummaryApprove + ',',
                                      '')+ 'SUM(' + QUOTENAME(CONVERT(varchar, YearFinance)+ '_Approve')+ ') AS '''+CONVERT(varchar, YearFinance) +'_Approve'''
FROM #tempYearFinance
DECLARE @SummaryPartially NVARCHAR(MAX)
SELECT @SummaryPartially = COALESCE(@SummaryPartially + ',',
                                      '')+ 'SUM(' + QUOTENAME(CONVERT(varchar, YearFinance)+ '_Partially')+ ') AS '''+CONVERT(varchar, YearFinance) +'_Partially'''
FROM #tempYearFinance
DECLARE @SummaryDisapprove NVARCHAR(MAX)
SELECT @SummaryDisapprove = COALESCE(@SummaryDisapprove + ',',
                                      '')+ 'SUM(' + QUOTENAME(CONVERT(varchar, YearFinance)+ '_Disapprove')+ ') AS '''+CONVERT(varchar, YearFinance) +'_Disapprove'''
FROM #tempYearFinance
DECLARE @SummaryTerminate NVARCHAR(MAX)
SELECT @SummaryTerminate = COALESCE(@SummaryTerminate + ',',
                                      '')+ 'SUM(' + QUOTENAME(CONVERT(varchar, YearFinance)+ '_Terminate')+ ') AS '''+CONVERT(varchar, YearFinance) +'_Terminate'''
FROM #tempYearFinance
DECLARE @SummaryNotConsidered NVARCHAR(MAX)
SELECT @SummaryNotConsidered = COALESCE(@SummaryNotConsidered + ',',
                                      '')+ 'SUM(' + QUOTENAME(CONVERT(varchar, YearFinance)+ '_NotConsidered')+ ') AS '''+CONVERT(varchar, YearFinance) +'_NotConsidered'''
FROM #tempYearFinance
DECLARE @SummaryRepeat NVARCHAR(MAX)
SELECT @SummaryRepeat = COALESCE(@SummaryRepeat + ',',
                                      '')+ 'SUM(' + QUOTENAME(CONVERT(varchar, YearFinance)+ '_Repeat')+ ') AS '''+CONVERT(varchar, YearFinance) +'_Repeat'''
FROM #tempYearFinance


DECLARE @SummaryeTable AS NVARCHAR(MAX)
  SET @SummaryeTable = '
  select * from (
    SELECT *
  FROM ##ReportWhere
  UNION
  SELECT 9999 AS DepartmentID
  ,'''+'รวม'+''' AS DepartmentName

  ,'''+''' AS JFCaseTypeID
  ,'''+''' AS CaseTypeNameAbbr
  ,'+@SummaryApprove+ ','+@SummaryPartially+ ','+@SummaryDisapprove+ ','+@SummaryTerminate+ ','+@SummaryNotConsidered+ ','+@SummaryRepeat+'
  FROM ##ReportWhere
  )tb 

  '
    execute(@SummaryeTable)

";
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return CreateDataTable(cmd);
        }
        public DataTable GetCaseLawyerWorkingKPI(string startDate, string endDate)
        {
            string sql = @"jfs_sp_casetotallawyerworkingchartkpi";
            SqlCommand cmd = CreateCommand(sql, true);
                cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
            return CreateDataTable(cmd);
        }
        public DataTable GetCaseOpinionWorkingKPI(string startDate, string endDate)
        {
            string sql = @"jfs_sp_casetotalopinionworkingchartkpi";
            SqlCommand cmd = CreateCommand(sql, true);
            cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
            cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
            return CreateDataTable(cmd);
        }
        public DataTable GetCaseWorkingKPI(string startDate, string endDate)
        {
            string sql = @"jfs_sp_casetotalworkingchartkpi";
            SqlCommand cmd = CreateCommand(sql, true);
            cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
            cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
            return CreateDataTable(cmd);
        }
        public DataTable GetTotalWorking(string startDate, string endDate)
        {
            string sql = @"jfs_sp_casetotalworkingchartkpi";
            SqlCommand cmd = CreateCommand(sql, true);
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startDate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = endDate;
            return CreateDataTable(cmd);
        }
        public DataTable GetTotalLawyerWorking(string startDate, string endDate)
        {
            string sql = @"jfs_sp_casetotallawyerworkingchartkpi";
            SqlCommand cmd = CreateCommand(sql, true);
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startDate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = endDate;
            return CreateDataTable(cmd);
        }
        public DataTable GetTotalOpinionWorking(string startDate, string endDate)
        {
            string sql = @"jfs_sp_casetotalopinionworkingchartkpi";
            SqlCommand cmd = CreateCommand(sql, true);
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startDate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = endDate;
            return CreateDataTable(cmd);
        }
        public DataTable GetCaseProcess(string startDate, string endDate)
        {
            string sql = @"jfs_sp_statisticscaseprocess";
            SqlCommand cmd = CreateCommand(sql, true);
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startDate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = endDate;
            return CreateDataTable(cmd);

        }
        public DataTable GetCaseProcess(string startDate, string endDate,int depID)
        {

            string sql = "";
            string whereDate = "";
            string whereDepID = "";
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            if (startDate != "" && endDate != "" && startDate != null && endDate != null)
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                whereDate = $" AND  CONVERT(char(10),[RegisterDate],126) BETWEEN  @StartData AND @EndDate ";
            }
            if(depID != 0 && !string.IsNullOrWhiteSpace(whereDate))
            {

                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = depID };
                parameter.Add(sqlParameter);
                whereDepID = $" AND DepartmentID = @DepartmentID ";
                whereDate += whereDepID;
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
"+ whereDate + @"


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
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,DecisionDate)) BETWEEN 0 AND 21 THEN 'FinishedKPI_21'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,DecisionDate)) BETWEEN 22 AND 30 THEN 'FinishedKPI_22-30'
    WHEN ABS(DATEDIFF(Day,StartStep.ChangeDate,DecisionDate)) BETWEEN 31 AND 45 THEN 'FinishedKPI_31-45'
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
		  WHERE WorkStepID = 2
		  GROUP BY CaseID,
				WorkStepID,
				DepartmentID) MDX
	ON CCW.ModifiedDate = MDX.ModifiedDate
   WHERE CCW.WorkStepID = 2 
   GROUP BY CCW.CaseID,
          CCW.WorkStepID,
          CCW.DepartmentID
) AS StartStep ON aCRF.CaseID = StartStep.CaseID AND aCRF.DepartmentID = StartStep.DepartmentID


IF OBJECT_ID('tempdb..#tempFinished') IS NOT NULL
DROP TABLE #tempFinished

select ThaiMonthFinance,[FinishedKPI_21],[FinishedKPI_22-30],[FinishedKPI_31-45],[FinishedKPI_Over45]
INTO #tempFinished
from 
#tempCaseFinishedKPI
PIVOT (count(CaseID)
FOR KPIStatus IN ([FinishedKPI_21],[FinishedKPI_22-30],[FinishedKPI_31-45],[FinishedKPI_Over45])
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



IF OBJECT_ID('tempdb..#tempCaseResultToTable') IS NOT NULL
DROP TABLE #tempCaseResultToTable

select tmF.CurrentIndex
,tmMt.MonthTH,
MAX(ISNULL(tTCR.TotalCase,0)) AS 'TotalRequest',
MAX(ISNULL(tF.FinishedKPI_21,0)) AS 'FinishedKPI_21'
,Case
WHEN SUM(ISNULL(ttC.TotalCase,0)) - ( SUM(ISNULL(tTCR.TotalCase,0)) + SUM(ISNULL(tcW.WorkKPI_21,0)) + SUM(ISNULL(tcW.WorkKPI_Over21,0))) > 0  
THEN Cast(Round((SUM(ISNULL(tF.FinishedKPI_21,0))*100.0)/(SUM(ISNULL(ttC.TotalCase,0)) - (SUM(ISNULL(tTCR.TotalCase,0)) + SUM(ISNULL(tcW.WorkKPI_21,0)) + SUM(ISNULL(tcW.WorkKPI_Over21,0)))),2) AS decimal (10,2)) 
ELSE 0.00
END AS PersentFinished
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
,MonthTH
,TotalRequest
,FinishedKPI_21
,PersentFinished
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
,'รวม' AS MonthTH
,SUM(TotalRequest) AS 'TotalRquest'
,SUM([FinishedKPI_21]) AS 'FinishedKPI_21'
,Case
WHEN SUM(ISNULL(TotalCase,0)) - (SUM(ISNULL(TotalRequest,0)) + SUM(ISNULL(WorkKPI_21,0)) + SUM(ISNULL(WorkKPI_Over21,0)))  > 0  
THEN Cast(Round((SUM(ISNULL(FinishedKPI_21,0))*100.0)/(SUM(ISNULL(TotalCase,0)) -( SUM(ISNULL(TotalRequest,0)) + SUM(ISNULL(WorkKPI_21,0)) + SUM(ISNULL(WorkKPI_Over21,0)))),2) AS decimal (10,2)) 
ELSE 0.00
END AS PersentFinished
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




            //AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;

        }




        public DataTable GetReportOverWork(string startDate, string endDate, int DepartmentID, string ProvinceType)
        {
            string sql = "";
            string whereDepAndPT = "";
            
            string whereDate = "";
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            if (startDate != "" && endDate != "" && startDate != null && endDate != null)
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                whereDate = $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";
            }
            if(DepartmentID != 0 && !string.IsNullOrEmpty(whereDepAndPT))
            {
                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = DepartmentID };
                parameter.Add(sqlParameter);
                whereDepAndPT += " AND D.DepartmentID = @DepartmentID ";
            }
            else if(DepartmentID != 0 && string.IsNullOrEmpty(whereDepAndPT))
            {
                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = DepartmentID };
                parameter.Add(sqlParameter);
                whereDepAndPT = " Where D.DepartmentID = @DepartmentID ";
            }
            if(!string.IsNullOrEmpty(ProvinceType) && !string.IsNullOrEmpty(whereDepAndPT))
            {
                sqlParameter = new SqlParameter("@ProvinceTypeCode", System.Data.SqlDbType.NVarChar) { Value = ProvinceType };
                parameter.Add(sqlParameter);
                whereDepAndPT += " AND  PT.ProvinceTypeCode = @ProvinceTypeCode ";
            }
            else if(!string.IsNullOrEmpty(ProvinceType) && string.IsNullOrEmpty(whereDepAndPT))
            {
                sqlParameter = new SqlParameter("@ProvinceTypeCode", System.Data.SqlDbType.NVarChar) { Value = ProvinceType };
                parameter.Add(sqlParameter);
                whereDepAndPT = " Where PT.ProvinceTypeCode = @ProvinceTypeCode ";
            }








            sql = @"IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
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
,CaseMeetingMinutes.MeetingDate AS DecisionDate

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
--INNER JOIN
--Department AS D
--ON COD.DepartmentID  = D.DepartmentID
--INNER JOIN
--Province AS P
--ON D.ProvinceID = P.ProvinceID
--INNER JOIN
--ProvinceExtension AS PE
--ON 
--P.ProvinceID = PE.ProvinceID
--INNER JOIN 
--ProvinceType AS PT
--ON PE.ProvinceTypeCode = PT.ProvinceTypeCode


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
"+ whereDate + @"

Order By RegisterDate ASC


IF OBJECT_ID('tempdb..#TotalCaseWait') IS NOT NULL
DROP TABLE #TotalCaseWait

select 
COUNT(CaseID) AS Total
,DepartmentID
INTO #TotalCaseWait
from
#allCaseRegisterFilter Where WorkStepID = 1 AND DecisionDate IS NULL
Group By DepartmentID


IF OBJECT_ID('tempdb..#CaseOverKPI') IS NOT NULL
DROP TABLE #CaseOverKPI
select 
aCRF.CaseID
,aCRF.WorkStepID
,aCRF.DepartmentID
,CASE
WHEN ABS(DATEDIFF(DAY, StartStep.ChangeDate, GETDATE()))  BETWEEN 0 AND 21 THEN '21'
WHEN ABS(DATEDIFF(DAY, StartStep.ChangeDate, GETDATE())) BETWEEN 22 AND 30 THEN '22-30'
WHEN ABS(DATEDIFF(DAY, StartStep.ChangeDate, GETDATE())) BETWEEN 31 AND 45 THEN '31-45'
ELSE 'Over_45' END AS KPIStatus
INTO #CaseOverKPI
from
(
select * from #allCaseRegisterFilter where WorkStepID > 1 AND DecisionDate IS NULL
) AS aCRF
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
) AS StartStep ON aCRF.CaseID = StartStep.CaseID AND aCRF.DepartmentID = StartStep.DepartmentID






IF OBJECT_ID('tempdb..#TotalCaseLawyer') IS NOT NULL
DROP TABLE #TotalCaseLawyer

select
COUNT(CaseID) AS Total
,DepartmentID
INTO #TotalCaseLawyer
from
#CaseOverKPI
WHERE WorkStepID Between 2 AND 4
Group By DepartmentID

IF OBJECT_ID('tempdb..#TotalCaseOpinion') IS NOT NULL
DROP TABLE #TotalCaseOpinion

select
COUNT(CaseID) AS Total
,DepartmentID
INTO #TotalCaseOpinion
from
#CaseOverKPI
WHERE WorkStepID >= 5
Group By DepartmentID

IF OBJECT_ID('tempdb..#TotalCaseOutstanding') IS NOT NULL
DROP TABLE #TotalCaseOutstanding

select
COUNT(CaseID) AS Total
,DepartmentID
INTO #TotalCaseOutstanding
from
#CaseOverKPI
WHERE WorkStepID > 1 AND KPIStatus != ''
Group By DepartmentID

IF OBJECT_ID('tempdb..#caseOverResultKPIs') IS NOT NULL
DROP TABLE #caseOverResultKPIs

select 
DepartmentID
,[22-30]
,[31-45]
,[Over_45]
INTO #caseOverResultKPIs
from 
(
select DepartmentID,KPIStatus,WorkStepID from #CaseOverKPI Where KPIStatus IS NOT NULL
) AS Tb
PIVOT (COUNT(WorkStepID)
FOR KPIStatus IN ([22-30],[31-45],[Over_45])
) AS pvt


--select DepartmentID,
--SUM([22-30])
--,SUM([31-45])
--,SUM([Over_45])
--from #caseOverResultKPIs Group By Rollup (DepartmentID)
IF OBJECT_ID('tempdb..#caseOverKPISummary') IS NOT NULL
DROP TABLE #caseOverKPISummary

select 
D.DepartmentID
,D.DepartmentName
,PT.ProvinceTypeName
,ISNULL(TCL.Total,0) AS Total_Lawyer
,ISNULL(TCW.Total,0) AS Total_Wait
,ISNULL(TCO.Total,0) AS Total_Opinion
,ISNULL(COR.[22-30],0) AS '22-30'
,ISNULL(COR.[31-45],0) AS '31-45'
,ISNULL(COR.Over_45,0) AS 'Over_45'
,ISNULL(TCOT.Total,0) AS Total_Outstanding
INTO #caseOverKPISummary
from
Department AS D
INNER JOIN 
Province AS P
ON D.ProvinceID = P.ProvinceID
INNER JOIN 
ProvinceExtension AS PE
ON P.ProvinceID = PE.ProvinceID
INNER JOIN
ProvinceType AS PT
ON PE.ProvinceTypeCode = PT.ProvinceTypeCode
LEFT JOIN
#TotalCaseLawyer AS TCL
ON D.DepartmentID = TCL.DepartmentID
LEFT JOIN
#TotalCaseOpinion AS TCO
ON D.DepartmentID = TCO.DepartmentID
LEFT JOIN
#TotalCaseWait AS TCW
ON D.DepartmentID = TCW.DepartmentID
LEFT JOIN
#TotalCaseOutstanding AS TCOT
ON D.DepartmentID = TCOT.DepartmentID
LEFT JOIN
#caseOverResultKPIs AS COR
ON D.DepartmentID = COR.DepartmentID
--Where 
--D.DepartmentID = 2 
--AND PT.ProvinceTypeCode = 'BKK'

" + whereDepAndPT + @"

select * from #caseOverKPISummary
UNION
select 
999 AS DepartmentID
,'รวม' AS DepartmentName
,'' AS ProvinceTypeName
,SUM(Total_Lawyer) AS Total_Lawyer
,SUM(Total_Wait) AS Total_Wait
,SUM(Total_Opinion) AS Total_Opinion
,SUM([22-30]) AS '22-30'
,SUM([31-45]) AS '31-45'
,SUM(Over_45) AS 'Over_45'
,SUM(Total_Outstanding) AS Total_Outstanding
from 
#caseOverKPISummary

";

            //AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }


        public DataTable GetCaseHaveLawyer(string startDate, string endDate, int DepartmentID, string ProvinceType)
        {
            string sql = "";
            string whereDepAndPT = "";

            string whereDate = "";
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            if (startDate != "" && endDate != "" && startDate != null && endDate != null)
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                whereDate = $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";
            }
            if (DepartmentID != 0 && !string.IsNullOrWhiteSpace(whereDepAndPT))
            {
                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = DepartmentID };
                parameter.Add(sqlParameter);
                whereDepAndPT += " AND D.DepartmentID = @DepartmentID ";
            }
            else if (DepartmentID != 0 && string.IsNullOrWhiteSpace(whereDepAndPT))
            {
                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = DepartmentID };
                parameter.Add(sqlParameter);
                whereDepAndPT = " Where D.DepartmentID = @DepartmentID ";
            }
            if (!string.IsNullOrEmpty(ProvinceType) && !string.IsNullOrWhiteSpace(whereDepAndPT))
            {
                sqlParameter = new SqlParameter("@ProvinceTypeCode", System.Data.SqlDbType.NVarChar) { Value = ProvinceType };
                parameter.Add(sqlParameter);
                whereDepAndPT += " AND  PE.ProvinceTypeCode = @ProvinceTypeCode ";
            }
            else if (!string.IsNullOrEmpty(ProvinceType) && string.IsNullOrWhiteSpace(whereDepAndPT))
            {
                sqlParameter = new SqlParameter("@ProvinceTypeCode", System.Data.SqlDbType.NVarChar) { Value = ProvinceType };
                parameter.Add(sqlParameter);
                whereDepAndPT = " Where PE.ProvinceTypeCode = @ProvinceTypeCode ";
            }


            sql = @"
IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
DROP TABLE #allCaseRegister
SELECT CAT.CaseID,
       CA.ApplicantID,
       ISNULL(CA.DeletedFlag, 0) AS DeletedFlag,
       CAT.RegisterDate,
       CAT.JFCaseTypeID,
       COD.DepartmentID,
       COD.StatusID,
       COD.WorkStepID,
       ISNULL(CAMOD.JFCaseNo, '') AS JFCaseNo,
       CO.UserID,
       CaseMeetingMinutes.MeetingDate AS DecisionDate INTO #allCaseRegister
FROM CaseApplication AS CAT
INNER JOIN CaseApplicant AS CA ON CAT.CaseID = CA.CaseID
LEFT JOIN CaseApplicantExtension AS CAE ON CA.ApplicantID = CAE.ApplicantID
LEFT JOIN CardType AS CT ON CAE.CardType = CT.CardTypeID
LEFT JOIN
  (SELECT CaseID,
          DepartmentID,
          WorkStepID,
          StatusID ,
          IsAppeal
   FROM CaseOwnerDepartment
   WHERE StatusID != 6 ) AS COD ON CA.CaseID = COD.CaseID
LEFT JOIN CaseApplicantMapOwnerDepartment AS CAMOD ON CA.ApplicantID = CAMOD.ApplicantID
AND COD.DepartmentID = CAMOD.DepartmentID
LEFT JOIN CaseApplicationStatus AS CAS ON COD.StatusID = CAS.CaseApplicationStatusID
LEFT JOIN CaseMeetingMinutes ON CAT.CaseID = CaseMeetingMinutes.CaseID
AND CA.ApplicantID = CaseMeetingMinutes.ApplicantID
LEFT JOIN
  (SELECT CaseOwner.CaseID,
          CaseOwner.DepartmentID,
          CaseOwner.UserID
   FROM CaseOwner
   INNER JOIN
     (SELECT MAX(ChangeDate) AS ChangeDate,
             CaseID
      FROM CaseOwner
      GROUP BY CaseID) CurrentCaseOwner ON CaseOwner.CaseID = CurrentCaseOwner.CaseID
   AND CaseOwner.ChangeDate = CurrentCaseOwner.ChangeDate) CO ON CAT.CaseID = CO.CaseID
AND COD.DepartmentID = CO.DepartmentID IF OBJECT_ID('tempdb..#allCaseRegisterFilter') IS NOT NULL
DROP TABLE #allCaseRegisterFilter
SELECT * INTO #allCaseRegisterFilter
FROM #allCaseRegister
WHERE DeletedFlag != 1
  AND JFCaseTypeID != 5
  AND JFCaseNo NOT LIKE '%สกย%' ----- ไม่เอาเคสที่ยื่นเรื่อง
"+ whereDate
+ @"
AND UserID IS NOT NULL
ORDER BY RegisterDate ASC
IF OBJECT_ID('tempdb..#SummaryUserOwner') IS NOT NULL
DROP TABLE #SummaryUserOwner
SELECT COUNT(CaseID) AS Total,
       UserID,
       DepartmentID INTO #SummaryUserOwner
FROM #allCaseRegisterFilter AS aCRF
GROUP BY UserID,
         DepartmentID



SELECT U.AliasName,
	   U.UserID,
       ISNULL(SUO.Total, 0) AS Total,
       D.DepartmentID,
       D.DepartmentName,
       PE.ProvinceTypeCode
FROM #SummaryUserOwner AS SUO
RIGHT JOIN
  (SELECT U.AliasName,
          UA.DepartmentID,
          U.UserID
   FROM [User] AS U
  INNER JOIN UserAdditional AS UA ON U.UserID = UA.UserID AND U.UserID != 8
 ) AS U ON SUO.UserID = U.UserID
INNER JOIN Department AS D ON U.DepartmentID = D.DepartmentID
INNER JOIN Province AS P ON D.ProvinceID = P.ProvinceID
INNER JOIN ProvinceExtension AS PE ON P.ProvinceID = PE.ProvinceID
"
+ whereDepAndPT+
@"
Order By D.DepartmentID,PE.ProvinceTypeCode ASC 


";


            //AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }

        public DataTable GetCaseNotHaveLawyer(string startDate, string endDate, int DepartmentID, string ProvinceType)
        {
            string sql = "";
            string whereDepAndPT = "";

            string whereDate = "";
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            if (startDate != "" && endDate != "" && startDate != null && endDate != null)
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                whereDate = $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";
            }
            if (DepartmentID != 0 && !string.IsNullOrWhiteSpace(whereDepAndPT))
            {
                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = DepartmentID };
                parameter.Add(sqlParameter);
                whereDepAndPT += " AND D.DepartmentID = @DepartmentID";
            }
            else if (DepartmentID != 0 && string.IsNullOrWhiteSpace(whereDepAndPT))
            {
                sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = DepartmentID };
                parameter.Add(sqlParameter);
                whereDepAndPT = " Where D.DepartmentID = @DepartmentID";
            }
            if (!string.IsNullOrEmpty(ProvinceType) && !string.IsNullOrWhiteSpace(whereDepAndPT))
            {
                sqlParameter = new SqlParameter("@ProvinceTypeCode", System.Data.SqlDbType.NVarChar) { Value = ProvinceType };
                parameter.Add(sqlParameter);
                whereDepAndPT += " AND  PE.ProvinceTypeCode = @ProvinceTypeCode";
            }
            else if (!string.IsNullOrEmpty(ProvinceType) && string.IsNullOrWhiteSpace(whereDepAndPT))
            {
                sqlParameter = new SqlParameter("@ProvinceTypeCode", System.Data.SqlDbType.NVarChar) { Value = ProvinceType };
                parameter.Add(sqlParameter);
                whereDepAndPT = " Where PE.ProvinceTypeCode = @ProvinceTypeCode";
            }

            sql = @"IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
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
,CO.UserID
,CaseMeetingMinutes.MeetingDate AS DecisionDate

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
LEFT JOIN
(
select  
CaseOwner.CaseID
,CaseOwner.DepartmentID
,CaseOwner.UserID
from CaseOwner
INNER JOIN 
(
select MAX(ChangeDate) AS ChangeDate
,CaseID
from CaseOwner
Group By CaseID
) CurrentCaseOwner
ON CaseOwner.CaseID = CurrentCaseOwner.CaseID
AND CaseOwner.ChangeDate = CurrentCaseOwner.ChangeDate
) CO ON CAT.CaseID = CO.CaseID
AND COD.DepartmentID = CO.DepartmentID


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
----- ไม่เอาเคสที่ยื่นเรื่อง
--AND WorkStepID != 1
--- ค้นหาจากวันที่รับเรื่อง
"+ whereDate + 
@"
--- ไม่เอากรณีไม่มีเจ้าของสำนวน
AND UserID IS NULL 

Order By RegisterDate ASC


IF OBJECT_ID('tempdb..#SummaryNotUserOwner') IS NOT NULL
DROP TABLE #SummaryNotUserOwner


select 
COUNT(CaseID) AS Total
,UserID
,DepartmentID
INTO #SummaryNotUserOwner
from #allCaseRegisterFilter AS aCRF
Group By UserID,DepartmentID


IF OBJECT_ID('tempdb..#Summary') IS NOT NULL
DROP TABLE #Summary
select
ISNULL(SUO.Total,0) AS Total
,D.DepartmentID
,D.DepartmentName
,PE.ProvinceTypeCode
INTO #Summary
from #SummaryNotUserOwner AS SUO
RIGHT JOIN
Department AS D
ON SUO.DepartmentID = D.DepartmentID
INNER JOIN 
Province AS P
ON D.ProvinceID = P.ProvinceID
INNER JOIN 
ProvinceExtension AS PE
ON P.ProvinceID = PE.ProvinceID

" + whereDepAndPT +
@" Order By PE.ProvinceTypeCode ASC ,D.DepartmentID ASC" +
@"
SELECT ISNULL(DepartmentName,'รวม') AS DepartmentName, SUM(Total) AS Total
From #Summary
GROUP BY ROLLUP(DepartmentName)";



            //AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }
        public DataTable GetCaseSummaryByMissionOverView(string startDate, string endDate)
        {
            string sql = "";
            string whereDate = "";
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            if (startDate != "" && endDate != "" && startDate != null && endDate != null)
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                whereDate = $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";
            }
            sql = @"IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
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
,CaseMeetingMinutes.MeetingDate AS DecisionDate
,PT.ProvinceTypeCode
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
INNER JOIN
Department AS D
ON COD.DepartmentID  = D.DepartmentID
INNER JOIN
Province AS P
ON D.ProvinceID = P.ProvinceID
INNER JOIN
ProvinceExtension AS PE
ON 
P.ProvinceID = PE.ProvinceID
INNER JOIN 
ProvinceType AS PT
ON PE.ProvinceTypeCode = PT.ProvinceTypeCode


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
"+ whereDate + @"

IF OBJECT_ID('tempdb..#allCaseRegisterCentral') IS NOT NULL
DROP TABLE #allCaseRegisterCentral
select * 
INTO #allCaseRegisterCentral
from #allCaseRegisterFilter Where ProvinceTypeCode = 'BKK'


IF OBJECT_ID('tempdb..#allCaseRegisterNotCentral') IS NOT NULL
DROP TABLE #allCaseRegisterNotCentral
select * 
INTO #allCaseRegisterNotCentral
from #allCaseRegisterFilter Where ProvinceTypeCode != 'BKK'


IF OBJECT_ID('tempdb..#Summery') IS NOT NULL
DROP TABLE #Summery

select 
JT.JFCaseTypeID
,JT.CaseTypeName
,ISNULL(TCR.TotalCentralRegister,0) AS TotalCentralRegister
,ISNULL(TCF.TotalCentralFinish,0) AS TotalCentralFinish
,ISNULL(TNCR.TotalNotCentralRegister,0) AS TotalNotCentralRegister
,ISNULL(TNCF.TotalNotCentralFinish,0) AS TotalNotCentralFinish
INTO #Summery
from 
(
Select * from JFCaseType where JFCaseTypeID != 5
) AS JT
LEFT JOIN
(
select
COUNT(CaseID) AS TotalCentralRegister 
,JFCaseTypeID
from #allCaseRegisterCentral 
Group By JFCaseTypeID
) AS TCR
ON JT.JFCaseTypeID = TCR.JFCaseTypeID
LEFT JOIN
(
select
COUNT(CaseID) AS TotalCentralFinish 
,JFCaseTypeID
from #allCaseRegisterCentral 
Where WorkStepID > 1 AND DecisionDate IS NOT NULL
Group By JFCaseTypeID
) AS TCF
ON JT.JFCaseTypeID = TCF.JFCaseTypeID
LEFT JOIN
(
select
COUNT(CaseID) AS TotalNotCentralRegister 
,JFCaseTypeID
from #allCaseRegisterNotCentral 
Group By JFCaseTypeID
) AS TNCR
ON JT.JFCaseTypeID = TNCR.JFCaseTypeID
LEFT JOIN
(
select
COUNT(CaseID) AS TotalNotCentralFinish 
,JFCaseTypeID
from #allCaseRegisterNotCentral 
Where WorkStepID > 1 AND DecisionDate IS NOT NULL
Group By JFCaseTypeID
) AS TNCF
ON JT.JFCaseTypeID = TNCF.JFCaseTypeID


Select 
ISNULL(CaseTypeName,'รวม') AS CaseTypeName
,SUM(TotalCentralRegister) AS TotalCentralRegister
,SUM(TotalCentralFinish) AS TotalCentralFinish
,SUM(TotalNotCentralRegister) AS TotalNotCentralRegister
,SUM(TotalNotCentralFinish) AS TotalNotCentralFinish
from 
#Summery
Group By Rollup(CaseTypeName)
";




            //AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }
        public DataTable GetCaseSummaryByMissionNotOverView(string startDate, string endDate, string provinceType)
        {
            string sql = "";
            string whereDate = "";
            string whereProvinceType = "";
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            if (startDate != "" && endDate != "" && startDate != null && endDate != null)
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                whereDate = $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";
            }
            if (!string.IsNullOrWhiteSpace(provinceType))
            {
                sqlParameter = new SqlParameter("@ProvinceTypeCode", System.Data.SqlDbType.NVarChar) { Value = provinceType };
                parameter.Add(sqlParameter);
                whereProvinceType = $" Where DP.ProvinceTypeCode = @ProvinceTypeCode ";
            }

            sql = @"IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
DROP TABLE #allCaseRegister

select 
CAT.CaseID
,CA.ApplicantID
,ISNULL(CA.DeletedFlag,0) AS DeletedFlag 
,CAT.RegisterDate
,CAT.JFCaseTypeID
,COD.DepartmentID
,D.DepartmentName
,COD.StatusID
,COD.WorkStepID
,ISNULL(CAMOD.JFCaseNo,'') AS JFCaseNo
,CaseMeetingMinutes.MeetingDate AS DecisionDate
--,PT.ProvinceTypeCode
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
INNER JOIN
Department AS D
ON COD.DepartmentID  = D.DepartmentID
--INNER JOIN
--Province AS P
--ON D.ProvinceID = P.ProvinceID
--INNER JOIN
--ProvinceExtension AS PE
--ON 
--P.ProvinceID = PE.ProvinceID
--INNER JOIN 
--ProvinceType AS PT
--ON PE.ProvinceTypeCode = PT.ProvinceTypeCode


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
"+ whereDate + @"

IF OBJECT_ID('tempdb..#JfcaseTypeDepartment') IS NOT NULL
DROP TABLE #JfcaseTypeDepartment

select 
JT.JFCaseTypeID
,DP.DepartmentID
INTO #JfcaseTypeDepartment
from
(
select * from JFCaseType Where JFCaseTypeID != 5
)JT,
(select 
D.DepartmentID
from Department AS D
)DP

IF OBJECT_ID('tempdb..#Summery') IS NOT NULL
DROP TABLE #Summery
select 
JT.JFCaseTypeID
,JT.DepartmentID
,ISNULL(TR.TotalRegister,0) AS TotalRegister
,ISNULL(TF.TotalFinish,0) AS TotalFinish

INTO #Summery
from 
#JfcaseTypeDepartment AS JT
LEFT JOIN
(
select
COUNT(CaseID) AS TotalRegister 
,JFCaseTypeID
,DepartmentID
from #allCaseRegisterFilter
Group By JFCaseTypeID,DepartmentID
) AS TR
ON JT.JFCaseTypeID = TR.JFCaseTypeID AND JT.DepartmentID = TR.DepartmentID
LEFT JOIN
(
select
COUNT(CaseID) AS TotalFinish 
,JFCaseTypeID
,DepartmentID
from #allCaseRegisterFilter
Where WorkStepID > 1 AND DecisionDate IS NOT NULL
Group By JFCaseTypeID,DepartmentID
) AS TF
ON JT.JFCaseTypeID = TF.JFCaseTypeID AND JT.DepartmentID = TF.DepartmentID

IF OBJECT_ID('tempdb..#CaseRollUP') IS NOT NULL
DROP TABLE #CaseRollUP


select 
ISNULL(JFCaseTypeID,99) AS JFCaseTypeID
,DepartmentID
,SUM(TotalRegister) AS TotalRegister
,SUM(TotalFinish) AS TotalFinish
INTO #CaseRollUP
from #Summery 
Group By DepartmentID, ROLLUP (JFCaseTypeID)



select 
JT.JFCaseTypeID
,ISNULL(JT.CaseTypeName, 'รวม') AS CaseTypeName
,DP.DepartmentID
,DP.DepartmentName
,TotalRegister AS 'TotalCaseRegister'
,TotalFinish AS 'TotalCaseRegisterFinish'
,DP.ProvinceTypeCode
from
#CaseRollUP AS CRU
LEFT JOIN
JFCaseType AS JT 
ON CRU.JFCaseTypeID = JT.JFCaseTypeID
LEFT JOIN
(
select 
D.DepartmentID
,D.DepartmentName
,PT.ProvinceTypeCode
from 
Department AS D
INNER JOIN
Province AS P
ON D.ProvinceID = P.ProvinceID
INNER JOIN
ProvinceExtension AS PE
ON 
P.ProvinceID = PE.ProvinceID
INNER JOIN 
ProvinceType AS PT
ON PE.ProvinceTypeCode = PT.ProvinceTypeCode
) AS DP
ON CRU.DepartmentID = DP.DepartmentID

--Where DP.ProvinceTypeCode = 'BKK'
"
+ whereProvinceType;

            //AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }
        public DataTable GetCaseSummaryByRegion(string startDate, string endDate, string provinceType)
        {
            string sql = "";
            string whereDate = "";
            string whereProvinceType = "";
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter();
            if (startDate != "" && endDate != "" && startDate != null && endDate != null)
            {
                sqlParameter = new SqlParameter("@StartData", System.Data.SqlDbType.NVarChar) { Value = startDate };
                parameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@EndDate", System.Data.SqlDbType.NVarChar) { Value = endDate };
                parameter.Add(sqlParameter);
                whereDate = $" AND RegisterDate BETWEEN  @StartData AND @EndDate ";
            }
            if (!string.IsNullOrWhiteSpace(provinceType))
            {
                sqlParameter = new SqlParameter("@ProvinceTypeCode", System.Data.SqlDbType.NVarChar) { Value = provinceType };
                parameter.Add(sqlParameter);
                whereProvinceType = $" Where ProvinceTypeCode = @ProvinceTypeCode ";
            }

            sql = @"IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
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
,CaseMeetingMinutes.MeetingDate AS DecisionDate
,PT.ProvinceTypeCode
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
INNER JOIN
Department AS D
ON COD.DepartmentID  = D.DepartmentID
INNER JOIN
Province AS P
ON D.ProvinceID = P.ProvinceID
INNER JOIN
ProvinceExtension AS PE
ON 
P.ProvinceID = PE.ProvinceID
INNER JOIN 
ProvinceType AS PT
ON PE.ProvinceTypeCode = PT.ProvinceTypeCode

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
----- ไม่เอาเคสที่ยื่นเรื่อง
--AND WorkStepID != 1
"+ whereDate + @"
Order By RegisterDate ASC


IF OBJECT_ID('tempdb..#allCaseRegisterTotal') IS NOT NULL
DROP TABLE #allCaseRegisterTotal

select 
COUNT(aCRF.ApplicantID) AS Total
,aCRF.ProvinceTypeCode
INTO #allCaseRegisterTotal
from #allCaseRegisterFilter AS aCRF
Group By ProvinceTypeCode


IF OBJECT_ID('tempdb..#allCaseFinishTotal') IS NOT NULL
DROP TABLE #allCaseFinishTotal

select 
COUNT(aCRF.ApplicantID) AS Total
,aCRF.ProvinceTypeCode
INTO #allCaseFinishTotal
from #allCaseRegisterFilter AS aCRF
Where WorkStepID > 1 AND DecisionDate IS NOT NULL
Group By ProvinceTypeCode

IF OBJECT_ID('tempdb..#Summary') IS NOT NULL
DROP TABLE #Summary

select 
PT.ProvinceTypeName
,PT.ProvinceTypeCode
,IsShow
,ISNULL(RT.Total,0) AS Total
,ISNULL(FT.Total,0) AS TotalFininsh
,CAST(((ISNULL(FT.Total,0)) * 100.00) / ISNULL(RT.Total,1) as decimal(10,2)) AS PercentFininsh
,CASE 
    WHEN PT.ProvinceTypeCode = 'BKK' THEN 0
	WHEN PT.ProvinceTypeCode = 'CENTRAL' THEN 1
	WHEN PT.ProvinceTypeCode = 'EAST' THEN 2
	WHEN PT.ProvinceTypeCode = 'NORTH' THEN 3
	WHEN PT.ProvinceTypeCode = 'NORTHEAST' THEN 4
	WHEN PT.ProvinceTypeCode = 'SOUTH' THEN 5
	WHEN PT.ProvinceTypeCode = 'TSB' THEN 6
    ELSE 7
END AS CurrentType
INTO #Summary
from 
ProvinceType AS PT
LEFT JOIN #allCaseRegisterTotal AS RT
ON PT.ProvinceTypeCode = RT.ProvinceTypeCode
LEFT JOIN #allCaseFinishTotal AS FT
ON PT.ProvinceTypeCode = FT.ProvinceTypeCode
WHERE IsShow != 0

select 
ProvinceTypeName
,Total
,TotalFininsh
,PercentFininsh
from 
(
select 
ProvinceTypeName
,ProvinceTypeCode
,Total
,TotalFininsh
,PercentFininsh
,CurrentType
from #Summary
UNION
select 
'รวม' AS ProvinceTypeName
,'ALL' AS ProvinceTypeCode
,SUM(Total) AS Total
,SUM(TotalFininsh) AS TotalFininsh
,CAST(((ISNULL(SUM(TotalFininsh),0)) * 100.00) /
CASE
    WHEN  SUM(Total) > 0 THEN SUM(Total)
    ELSE 1
END
 as decimal(10,2)) AS PercentFininsh
,7 AS CurrentType
from #Summary
)Tb
"+ whereProvinceType + @"
Order By CurrentType ASC
";

            //AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(parameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }
        public DataTable GetStaticCompareQuarter()
        {
            string sql = @"IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
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

Order By RegisterDate ASC

IF OBJECT_ID('tempdb..#temResult') IS NOT NULL
DROP TABLE #temResult

select CaseID,Case
WHEN MONTH(RegisterDate) > 9 THEN YEAR(RegisterDate) + 1 +543
ELSE YEAR(RegisterDate) +543
END AS ThaiYearFinance
,Case
WHEN MONTH(RegisterDate) Between 10 AND 12 THEN 1
WHEN MONTH(RegisterDate) Between 1 AND 3 THEN 2
WHEN MONTH(RegisterDate) Between 4 AND 6 THEN 3
ELSE 4
END AS ThaiQuarterFinance 
INTO #temResult
from #allCaseRegisterFilter

IF OBJECT_ID('tempdb..#report') IS NOT NULL
DROP TABLE #report

SELECT ThaiYearFinance
,ISNULL([1],0) AS QT1
,ISNULL([2],0) AS QT2
,ISNULL([3],0) AS QT3
,ISNULL([4],0) AS QT4
INTO #report
FROM #temResult
PIVOT (COUNT(CaseID)
FOR ThaiQuarterFinance IN ([1],[2],[3],[4])
) AS pvt
Order By ThaiYearFinance ASC 

select * from #report
";
           
            //AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);            
            DataTable dt = CreateDataTable(command);
            return dt;
        }
        public DataTable GetStaticCompareYear()
        {
            string sql = @"IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
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
----- ไม่เอาเคสที่ยื่นเรื่อง

Order By RegisterDate ASC

IF OBJECT_ID('tempdb..#temResult') IS NOT NULL
DROP TABLE #temResult

select CaseID,Case
WHEN MONTH(RegisterDate) > 9 THEN YEAR(RegisterDate) + 1 +543
ELSE YEAR(RegisterDate) +543
END AS ThaiYearFinance
,MONTH(RegisterDate) AS ThaiMonthFinance 
INTO #temResult
from #allCaseRegisterFilter

SELECT ThaiYearFinance
,ISNULL([10],0) AS 'M10'
,ISNULL([11],0) AS 'M11'
,ISNULL([12],0) AS 'M12'
,ISNULL([1],0) AS 'M1'
,ISNULL([2],0) AS 'M2'
,ISNULL([3],0) AS 'M3'
,ISNULL([4],0) AS 'M4'
,ISNULL([5],0) AS 'M5'
,ISNULL([6],0) AS 'M6'
,ISNULL([7],0) AS 'M7'
,ISNULL([8],0) AS 'M8'
,ISNULL([9],0) AS 'M9'
FROM #temResult
PIVOT (COUNT(CaseID)
FOR ThaiMonthFinance IN ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])
) AS pvt
Order By ThaiYearFinance ASC 
";

            //AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);
            DataTable dt = CreateDataTable(command);
            return dt;
        }
    }
}

