using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.Reporting
{
   public class ContractReport : ApplicantReport
    {
        public override bool Export()
        {
            throw new NotImplementedException();
        }
        private static  readonly string CONTRACT_QUERY= @"( SELECT ApplicantID,CaseID,DepartmentID,JFCaseTypeID,CaseTypePrefix,JFCaseNo,CaseTypePrefix AS CaseTypeNameAbbr,CaseTypeName
,DepartmentName,StatusID,StatusName,WorkStepID,WorkStepName,Title,FirstName,LastName,Gender,GenderName
,Age,AgeRank,RaceID,RaceName,ReligionID,ReligionName,NationalityID,NationalityName,EducationLevelID,Education
,CareerID,Career,ChannelID,ChannelName,CaseCategoryID,CategoryName,SourceProvinceID AS ProvinceID ,SourceProvinceName AS ProvinceName
,SourceRegionID AS RegionID, SourceRegionName AS RegionName,RegisterDate,Qt,YYYY,ThaiQuarter,ThaiFiscalYear,MM,ThaiMonth
,CourtName,LawyerName,ContractNo,AmountInContract,ContractBy,ContractDate,FormName,FormID,ReceiveDate,SigningDate,SigningPlace 

FROM (SELECT CA.ApplicantID,
       CAT.CaseID,
       JT.JFCaseTypeID,
       JT.CaseTypeName,
       JT.CaseTypeNameAbbr AS CaseTypePrefix,
       ISNULL(CAMOD.JFCaseNo, '') AS JFCaseNo,
       COD.DepartmentID,
       DPO.DepartmentName,
       COD.StatusID,
	   PE.ProvinceTypeCode,
       CAS.CaseApplicationStatusName AS StatusName,
       WS.WorkStepID,
       WS.WorkStepName,      
       SourceDepartment.DepartmentID AS SourceDepartmentID,
       SourceDepartment.DepartmentName AS SourceDepartmentName,
       CAT.ReferenceCaseID,
       CAT.ReferenceMSCCODE,
       CAT.ReferenceMSCID,
       CAE.CardID,
       CT.CardTypeName,
       CA.Title,
       CA.FirstName,
       CA.LastName,
       CA.RequestAmount,
	   CAE.ReligionID,
	   REL.ReligionName,
       CA.Score,
       CAT.Subject,
       ISNULL(CA.Gender, 'N/A') AS Gender,
       ISNULL(GN.GenderName, 'ไม่ระบุ') AS GenderName,
       ISNULL(CAE.Age, 0) AS Age,
       CASE
           WHEN ISNULL(CAE.Age, 0) BETWEEN 1 AND 17 THEN '1-17'
           WHEN ISNULL(CAE.Age, 0) BETWEEN 18 AND 24 THEN '18-24'
           WHEN ISNULL(CAE.Age, 0) BETWEEN 25 AND 34 THEN '25-34'
           WHEN ISNULL(CAE.Age, 0) BETWEEN 35 AND 44 THEN '35-44'
           WHEN ISNULL(CAE.Age, 0) BETWEEN 45 AND 54 THEN '45-54'
           WHEN ISNULL(CAE.Age, 0) BETWEEN 55 AND 64 THEN '55-64'
           WHEN ISNULL(CAE.Age, 0) BETWEEN 65 AND 199 THEN '65 Up'
           ELSE 'Unknown'
       END AS AgeRank,
       ISNULL(R.RaceID, 0) AS RaceID,
       ISNULL(R.RaceName, 'N/A')AS RaceName,
       ISNULL(N.NationalityID, 0) AS NationalityID,
       ISNULL(N.NationalityName, 'N/A')AS NationalityName ,
       ISNULL(EDU.EducationLevelID, 0) EducationLevelID,
       ISNULL(EDU.Education, 'N/A') AS Education,
       ISNULL(TCareer.CareerID, 0) AS CareerID,
       ISNULL(TCareer.CareerName, 'N/A') AS Career,
       ComC.ChannelID,
       ComC.ChannelName,
       Cateory.CaseCategoryID,
       Cateory.CategoryName,
       Cateory.CaseSubCategoryID,
       Cateory.CaseSubCategoryName,
       SourceProvince.ProvinceID AS SourceProvinceID,
       SourceProvince.ProvinceName AS SourceProvinceName,
       SourceRegion.RegionID AS SourceRegionID,
       SourceRegion.RegionName AS SourceRegionName,
       CAT.RegisterDate,
       DATEPART(QUARTER, CAT.RegisterDate) AS Qt,
       YEAR(CAT.RegisterDate) +543 AS YYYY,
       CASE
           WHEN DATEPART(QUARTER, CAT.RegisterDate) BETWEEN 1 AND 3 THEN DATEPART(QUARTER, CAT.RegisterDate) + 1
           ELSE 1
       END AS ThaiQuarter,
       CASE
           WHEN MONTH(CAT.RegisterDate) > 9 THEN YEAR(CAT.RegisterDate) + 1 +543
           ELSE YEAR(CAT.RegisterDate) +543 
       END AS ThaiFiscalYear,

       CaseProject.ProjectTitle,       
       CurrentCaseStatus.HelpCaseLevelID,
       CurrentCaseStatus.HelpCaseLevelName,
       CurrentCaseStatus.HelpCaseLevelOther,
       CurrentCaseStatus.CaseTypeID AS CourtTypeID,
       CurrentCaseStatus.CaseTypeName AS CourtTypeName,
       ISNULL(CurrentCaseStatus.CourtName,'') AS  CourtName,
       CurrentCaseStatus.ProvinceID AS CourtProvinceID,
       CurrentCaseStatus.ProvinceName AS CourtProvinceName,
       CurrentCaseStatus.Charge,
       CO.UserID AS LawyerID,
	   U.AliasName AS LawyerName,
	      -------#START Column สัญญา ---------------
	   ISNULL(TbContract.ContractNo,'') AS ContractNo,
	  TbContract.AmountInContract,
	  TbContract.ContractBy,
	  TbContract.ContractDate,
	  TbContract.FormName,
	  TbContract.FormID,
	  TST.ReceiveDate,
	  TbContract.SigningDate,
	  TbContract.SigningPlace,
	   -------#END Column สัญญา ---------------
	   ISNULL(CA.DeletedFlag, 0) AS DeletedFlag ,
	   Right('00' + CAST(MONTH(CAT.RegisterDate) AS VARCHAR(2)), 2) AS MM,
CASE MONTH(CAT.RegisterDate)
when 1 then  'ม.ค.' +' '+CAST(YEAR(CAT.RegisterDate) + 543 AS VARCHAR(4))
when 2 then  'ก.พ.'   +' '+CAST(YEAR(CAT.RegisterDate) + 543 AS VARCHAR(4))
when 3 then 'มี.ค.' +' '+CAST(YEAR(CAT.RegisterDate) + 543 AS VARCHAR(4))
when 4 then 'เม.ย.' +' '+CAST(YEAR(CAT.RegisterDate) + 543 AS VARCHAR(4))
when 5 then 'พ.ค.' +' '+CAST(YEAR(CAT.RegisterDate) + 543 AS VARCHAR(4))
when 6 then 'มิ.ย.' +' '+CAST(YEAR(CAT.RegisterDate) + 543 AS VARCHAR(4))
when 7 then 'ก.ค.' +' '+CAST(YEAR(CAT.RegisterDate) + 543 AS VARCHAR(4))
when 8 then 'ส.ค.' +' '+CAST(YEAR(CAT.RegisterDate) + 543 AS VARCHAR(4))
when 9 then 'ก.ย.' +' '+CAST(YEAR(CAT.RegisterDate) + 543 AS VARCHAR(4))
when 10 then 'ต.ค.' +' '+CAST(YEAR(CAT.RegisterDate) + 543 AS VARCHAR(4))
when 11 then 'พ.ย.' +' '+CAST(YEAR(CAT.RegisterDate) + 543 AS VARCHAR(4))
when 12 then 'ธ.ค.' +' '+CAST(YEAR(CAT.RegisterDate) + 543 AS VARCHAR(4))
end AS ThaiMonth
FROM CaseApplication AS CAT
INNER JOIN CaseApplicant AS CA ON CAT.CaseID = CA.CaseID
-----------#START สัญญา-----------
INNER JOIN (

SELECT [Contract].ContractID,
	   [Contract].ContractNo,
       ISNULL([Contract].Amount, 0) AS AmountInContract,
       [Contract].ContractDate,
       [Contract].ApplicantID,
       [Contract].CaseID,
	   [Contract].DepartmentID,
	   [Contract].SigningDate,
	   [Contract].SigningPlace,  
	   ([User].FirstName + ' '+ [User].LastName) AS ContractBy,
       [Form].FormName,
       [Form].FormID
FROM [Contract]
INNER JOIN Form ON [Contract].FormID = [Form].FormID
LEFT OUTER JOIN [ContractChangeHistory] ON [Contract].ContractID = [ContractChangeHistory].ContractID AND[ContractChangeHistory].IsCreate = 1
LEFT OUTER JOIN [User] ON [ContractChangeHistory].UserID = [User].UserID
WHERE  [Contract].IsActive = 1 AND  [Form].FormID Between  5 AND 10 
) AS TbContract
ON CA.ApplicantID = TbContract.ApplicantID
----------------#END สัญญา ------------------------------
LEFT JOIN CaseApplicantExtension AS CAE ON CA.ApplicantID = CAE.ApplicantID
LEFT JOIN CardType AS CT ON CAE.CardType = CT.CardTypeID
LEFT JOIN JFCaseType AS JT ON CAT.JFCaseTypeID = JT.JFCaseTypeID
LEFT JOIN Gender AS GN ON CA.Gender = GN.GenderCode
LEFT JOIN Religion AS REL ON CAE.ReligionID = REL.ReligionID
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
LEFT JOIN Race AS R ON CAE.RaceID = R.RaceID
INNER JOIN Department AS SourceDepartment ON CAT.DepartmentID = SourceDepartment.DepartmentID
INNER JOIN Province AS SourceProvince ON CAT.ProvinceID = SourceProvince.ProvinceID
LEFT JOIN WorkStep AS WS ON COD.WorkStepID = WS.WorkStepID
LEFT JOIN
  (SELECT AEL.ApplicantID,
          EL.EducationLevelID,
          EL.Education
   FROM ApplicantEducationLevel AS AEL
   INNER JOIN EducationLevel AS EL ON AEL.EducationLevelID = EL.EducationLevelID) AS EDU ON CA.ApplicantID = EDU.ApplicantID
LEFT JOIN Nationality AS N ON CAE.NationalityID = N.NationalityID
LEFT JOIN
  (SELECT AI.ApplicantID,
          C.CareerID,
          C.CareerName
   FROM ApplicantIncome AS AI
   INNER JOIN ApplicantCareer AS AC ON AI.IncomeID = AC.IncomeID
   AND IsPermanent = 1
   INNER JOIN Career AS C ON AC.CareerID = C.CareerID) AS TCareer ON CA.ApplicantID = TCareer.ApplicantID
INNER JOIN ComplaintChannel AS ComC ON CAT.ChannelID = ComC.ChannelID
LEFT JOIN
  (SELECT CMCC.CaseID,
          CC.CaseCategoryID,
          CC.CategoryName,
          CSC.CaseSubCategoryID,
          CSC.CaseSubCategoryName
   FROM CaseMapCaseCategory AS CMCC
   INNER JOIN CaseCategory AS CC ON CMCC.CaseCategoryID = CC.CaseCategoryID
   LEFT JOIN CaseSubCategory AS CSC ON CMCC.CaseSubCategoryID = CSC.CaseSubCategoryID) AS Cateory ON CAT.CaseID = Cateory.CaseID
INNER JOIN Region AS SourceRegion ON SourceProvince.RegionID = SourceRegion.RegionID
LEFT JOIN CaseProject ON CAT.CaseID = CaseProject.CaseID
LEFT JOIN
  (SELECT CCS.ApplicantID,
          CCS.CaseID,
          CCS.ApplicantStatus,
          CCS.Charge,
          HCL.HelpCaseLevelID,
          HCL.HelpCaseLevelName,
          CCS.HelpCaseLevelOther,
          CT.CaseTypeID,
          CT.CaseTypeName,
          CCS.CaseTypeOther,
          Court.CourtID,
          Court.CourtName,
          P.ProvinceID,
          P.ProvinceName
   FROM CurrentCaseStatus AS CCS
   LEFT JOIN HelpCaseLevel AS HCL ON CCS.HelpCaseLevelID = HCL.HelpCaseLevelID
   LEFT JOIN CaseType AS CT ON CCS.CaseTypeID = CT.CaseTypeID
   LEFT JOIN Court ON CCS.CourID = Court.CourtID
   LEFT JOIN Province AS P ON Court.ProvinceID = P.ProvinceID) AS CurrentCaseStatus ON CAT.CaseID = CurrentCaseStatus.CaseID
AND CA.ApplicantID = CurrentCaseStatus.ApplicantID
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
LEFT JOIN dbo.[User] AS U
ON CO.UserID = U.UserID
LEFT JOIN NotifyDecisionResult AS NDR ON CAT.CaseID = NDR.CaseID
AND CA.ApplicantID = NDR.ApplicantID
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
LEFT JOIN OfficerApprovedExpense OAE ON CA.ApplicantID = OAE.ApplicantID
AND CAT.CaseID = OAE.CaseID AND IsFinalApproved = 1
LEFT JOIN Department AS DPO ON COD.DepartmentID = DPO.DepartmentID
LEFT JOIN ProvinceExtension AS PE
ON DPO.ProvinceID = PE.ProvinceID
LEFT JOIN ProvinceType AS PT
ON PE.ProvinceTypeCode = PT.ProvinceTypeCode
LEFT JOIN (SELECT * FROM [Transaction] WHERE TransactionStatusID = 5 AND TransactionType = 1) TST
ON CA.ApplicantID = TST.RefApplicantID AND CAT.CaseID = TST.RefCaseID AND TbContract.ContractID = TST.RefContractID
) tb
WHERE DeletedFlag != 1
AND JFCaseNo NOT LIKE '%สกย%'
AND JFCaseTypeID != 5) TB ";

        public override DataTable GetAsDataTable(ComponentReportFilter filter, string[] columName, int startRowIndex, int rowPerPage = 50000, string sortBy = "RegisterDate ASC")
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
            string sqlTable = " SELECT JFCaseNo,CaseTypeName,DepartmentName,RegisterDate,Title,FirstName,LastName,LawyerName,ContractNo,FormName,AmountInContract,ContractBy,ContractDate,SigningDate,SigningPlace" + selectColumn + //",COUNT(ApplicantID) AS NumberOfApplicant" +
                          " FROM "+ CONTRACT_QUERY + whereSql +
                          " GROUP BY JFCaseNo,CaseTypeName,DepartmentName,RegisterDate,Title,FirstName,LastName,LawyerName,ContractNo,FormName,AmountInContract,ContractBy,ContractDate,SigningDate,SigningPlace" + selectColumn;
            string sql = "SELECT COUNT(*) AS TotalRow FROM (" + sqlTable + ") Tb ";
            //AntiSqlInjection.CheckInput(sql);
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
            string sql = " SELECT TOP 50000 JFCaseNo,CaseTypeName,DepartmentName,RegisterDate,Title,FirstName,LastName,LawyerName,ContractNo,FormName,AmountInContract,ContractBy,ContractDate,SigningDate,SigningPlace" + selectColumn +
                          " FROM " + CONTRACT_QUERY+ whereSql +
                          "  GROUP BY JFCaseNo,CaseTypeName,DepartmentName,RegisterDate,Title,FirstName,LastName,LawyerName,ContractNo,FormName,AmountInContract,ContractBy,ContractDate,SigningDate,SigningPlace" + selectColumn + OrderBySql;
            //AntiSqlInjection.CheckInput(sql);
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            DataTable dt = CreateDataTable(command);
            return dt;
        }

    }
}
