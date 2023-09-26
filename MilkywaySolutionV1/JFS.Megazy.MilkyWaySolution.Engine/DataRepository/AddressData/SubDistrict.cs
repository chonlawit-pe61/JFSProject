using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.AddressData
{
    public abstract class SubDistrict
    {
        public int DistrictID { get; set; }
        public int SubDistrictID { get; set; }
        public string SubDistrictName { get; set; }
        public string PostCode { get; set; }
    }
}