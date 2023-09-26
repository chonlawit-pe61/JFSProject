using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FormRequest
{
    public class FormRequest
    {
        public CaseApplicantRequestData data { get; set; }
        public AddressRow address { get; set; }
        public JFSCaseRequest jfscase { get; set; }
        public ApplicantRelatedPersonData relate { get; set; }
        public CaseProjectDataRequest caseProjectData { get; set; }

    }
    public class JFSCaseRequest
    {
        public int jfscasetype { get; set; }
        public float Amont { get; set; }
    }
   
}
