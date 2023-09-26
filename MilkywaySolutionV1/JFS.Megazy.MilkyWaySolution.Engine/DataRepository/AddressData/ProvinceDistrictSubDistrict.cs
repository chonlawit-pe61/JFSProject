using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.AddressData
{
    public class ProvinceDistrictSubDistrict
    {
        public ProvinceResponse Province { get; set; }
        public IEnumerable<DistrictResponse> District { get; set; }
        public IEnumerable<SubDistrictResponse> SubDistrict { get; set; }


    }
}