using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;

namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{
    public partial class JFCaseTypeCollection_Base
    {
		public List<JFSCaseTotalData> GetJFSCaseTotal(int depID)
		{
			List<JFSCaseTotalData> res = new List<JFSCaseTotalData>();
			List<SqlParameter> parameter = new List<SqlParameter>();
			SqlParameter sqlParameter = new SqlParameter();
			string whereSql = "";
			if (depID != 0)
			{
				sqlParameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = depID };
				parameter.Add(sqlParameter);
				whereSql = $" AND DepartmentID = @DepartmentID";
			}
			string sql = @"IF OBJECT_ID('tempdb..#allCaseRegister') IS NOT NULL
DROP TABLE #allCaseRegister
SELECT CAT.CaseID,
       CA.ApplicantID,
       ISNULL(CA.DeletedFlag, 0) AS DeletedFlag ,
       CAT.RegisterDate,
       CAT.JFCaseTypeID,
       COD.DepartmentID,
       COD.StatusID,
       COD.WorkStepID,
       ISNULL(CAMOD.JFCaseNo, '') AS JFCaseNo,
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

IF OBJECT_ID('tempdb..#allCaseRegisterFilter') IS NOT NULL
DROP TABLE #allCaseRegisterFilter
SELECT * INTO #allCaseRegisterFilter
FROM #allCaseRegister
WHERE DeletedFlag != 1
"
+whereSql+
@"

SELECT JFCaseTypeID,
	Count(CaseID) AS Total	
FROM #allCaseRegisterFilter WHERE DeletedFlag != 1
GROUP BY JFCaseTypeID
ORDER BY JFCaseTypeID ASC";

			AntiSqlInjection.CheckInput(sql);
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(parameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				while (reader.Read())
				{
					JFSCaseTotalData data = new JFSCaseTotalData();
					data.JFCaseTypeID = reader.GetInt32(0);
					data.Total = reader.GetInt32(1);
					res.Add(data);
				}
				return res;
			}
		}






	}
}
