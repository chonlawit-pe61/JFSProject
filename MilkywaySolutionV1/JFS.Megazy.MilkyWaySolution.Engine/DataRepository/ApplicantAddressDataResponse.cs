using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressRequest = JFS.Megazy.MilkyWaySolution.Engine.Structure.AddressData;
namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class ApplicantAddressDataResponse : ApplicantAddressData
    {
        public AddressRequest AddressRequest { get; set; }
    }
}
