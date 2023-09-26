using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using AddressRequest = JFS.Megazy.MilkyWaySolution.Engine.Structure.AddressData;
namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
 public  class ApplicantMaritalDataRequest
    {
        public ApplicantMaritalData ApplicantMaritalData { get; set; }
        public ApplicantFamilyDataRequest[] ApplicantFamilyData { get; set; }
        public ApplicantIncomeData ApplicantIncomeData { get; set; }
    }
    public class ApplicantFamilyDataRequest : ApplicantFamilyData
    {
        public AddressRequest AddressRequest { get; set; }
    }
}
