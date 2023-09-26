using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class SubCommitteeEditableResponse : CaseMeetingMinutesData
    {
        public CaseApplicantOpinionData CaseApplicantOpinion { get; set; }
        public View_OfficerMapOpinionData[] Opinion { get; set; }
    }
}
