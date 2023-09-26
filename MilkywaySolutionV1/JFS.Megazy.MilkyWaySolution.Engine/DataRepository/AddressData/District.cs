using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.AddressData
{
    public abstract class District
    {
        public int ProvinceID { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
    }
}