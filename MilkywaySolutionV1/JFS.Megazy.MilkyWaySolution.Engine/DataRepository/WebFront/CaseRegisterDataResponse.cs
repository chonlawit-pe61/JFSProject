using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class CaseRegisterDataResponse
    {
        public CaseRegisterDataResponse()
        {
            caseMetaData = null;
            CaseExpenseEx = null;
        }
        public CaseApplicantRequestRow caseApplicant { get; set; }
        public CaseProjectDataRequest caseProjectData { get; set; }
        public CaseApplicantRequestExtensionRow requestExtension { get; set; }
        public List<CaseProjectMetaData> caseMetaData { get; set; }
        public List<CaseExpenseExtensionData> CaseExpenseEx { get; set; }
    }

    public class CaseApplicantRequest: CaseApplicantRequestRow
    {
        public string ChannelName { get; set; }
    }
}
