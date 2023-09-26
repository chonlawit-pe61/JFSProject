using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
   public class CaseMattersOfLawOpinionService
    {

        public CaseMattersOfLawOpinionRow[] CaseMattersOfLawOpinion(int officerRoleID,int caseID,int appicantID)
        {
            CaseMattersOfLawOpinionRow[] res = null;
            CaseMattersOfLawOpinionCollection_Base caseMattersOfLawOpinion = new CaseMattersOfLawOpinionCollection_Base(CSystems.ProcessID);
            string whereSql = $"CaseID={caseID} AND AppicantID={appicantID} AND OfficerRoleID={officerRoleID}";   
            res = caseMattersOfLawOpinion.GetAsArray(new List<SqlParameter>(), whereSql,"");
            caseMattersOfLawOpinion.Dispose();
            return res;
        }

        public bool InsertCaseMattersOfLawOpinion(CaseMattersOfLawOpinionData[] caseMattersOfLawData,int applicantID)
        {
            bool status = false;

            CaseMattersOfLawOpinionCollection_Base caseMattersOfLawOpinion = new CaseMattersOfLawOpinionCollection_Base(CSystems.ProcessID);
            caseMattersOfLawOpinion.DeleteByAppicantID(applicantID);           
            if (caseMattersOfLawData.Length > 0)
            {
                foreach (var item in caseMattersOfLawData)
                {                    
                    caseMattersOfLawOpinion.InsertOnlyPlainText(new CaseMattersOfLawOpinionRow { 
                    
                       CaseID = item.CaseID,
                       AppicantID = item.AppicantID,
                       MatterID = item.MatterID,
                       BracketID = item.BracketID,
                       OfficerRoleID = item.OfficerRoleID
                    });
                    status = true;                   
                }
            }
            caseMattersOfLawOpinion.Dispose();
            return status;
        }


    }
}
