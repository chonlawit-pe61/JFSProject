using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class CaseCompensationService
    {
        public CaseCompensationData CaseCompensation(int applicantID)
        {
            CaseCompensationData res = null;
            CaseCompensationCollection_Base caseCompensation = new CaseCompensationCollection_Base(CSystems.ProcessID);
            CaseCompensationRow compensationRow = caseCompensation.GetByPrimaryKey(applicantID);
            caseCompensation.Dispose();
            if (compensationRow != null)
            {
                res = new CaseCompensationData
                {
                    ApplicantID = compensationRow.ApplicantID,
                    CompensationID = compensationRow.CompensationID,
                    CompensationOtherNote = compensationRow.CompensationOtherNote,
                };
            }
            return res;
        }
        public bool InsertCaseCompensation(CaseCompensationData data, int applicantID)
        {

            bool status = false;
            if (data != null)
            {
                DalBase dal = new DalBase();

                CaseCompensationCollection_Base caseCompensation = new CaseCompensationCollection_Base(CSystems.ProcessID);
                caseCompensation.DeleteByPrimaryKey(applicantID);
                CaseCompensationRow compensationRow = new CaseCompensationRow();
                compensationRow.ApplicantID = applicantID;
                compensationRow.CompensationID = data.CompensationID;
                if (!string.IsNullOrWhiteSpace(data.CompensationOtherNote))
                {

                    compensationRow.CompensationOtherNote = data.CompensationOtherNote;
                }
                compensationRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                caseCompensation.InsertOnlyPlainText(compensationRow);
                caseCompensation.Dispose();
                status = true;
            }
            return status;
        }

    }
}
