using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class GetApplicantInspectResponse
    {
        public int ApplicantID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int NationalityID { get; set; }
        public string CardID { get; set; }
        public bool IsThaiCitizen
        {
            get { return NationalityID == 99; }
        }
        public View_ApplicantInspectRow[] ApplicantInspectRow { get; set; }
    }
}
