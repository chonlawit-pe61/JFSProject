using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressResponse= JFS.Megazy.MilkyWaySolution.Engine.Structure.AddressData;
namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class ApplicantMaritalDataResponse
    {
        public ApplicantMaritalData ApplicantMaritalData { get; set; }
        public ApplicantFamilyIncomeData ApplicantIncomeData { get; set; }
        public ApplicantFamilyDataResponse ApplicantFamilySpouseData { get; set; }
        public List<ApplicantFamilyDataResponse> ApplicantFamilyChildData { get; set; }
    }
    public class ApplicantFamilyDataResponse : ApplicantFamilyData
    {
        public AddressResponse AddressResponse { get; set; }
    }
}
