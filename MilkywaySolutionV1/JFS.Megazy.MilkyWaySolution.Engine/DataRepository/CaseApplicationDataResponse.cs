using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
   public class CaseApplicationDataEditableResponse
    {
        public View_CaseDetailRow CaseApplicationData { get; set; }
        //public int CategoryID { get; set; }
        //public int SubCategoryID { get; set; }
        public  IEnumerable<CaseSubCategoryData> CaseSubCategoryData { get; set; }
        public  IEnumerable<NameValueData> ProcessRoute { get; set; }
        public ApplicantAdditionalInfoRow applicantAdditionalInfo { get; set; }
        public ApplicantPrimaryContactRow applicantPrimary { get; set; }
    }
}
