using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FinanceApi
{
    public class Address
    {
        public string HouseNo { get; set; }
        public string VillageNo { get; set; }
        public string Street { get; set; }
        public string Soi { get; set; }
        public string AddressLine1 { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string SubDistrictName { get; set; }
        public string PostCode { get; set; }
    }
}
