using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.MSC
{
    public class MSCProvinceResult : ApiResult
    {
        public ProvinceDataResponse Result { get; set; }
    }
    public class MSCAmpherResult : ApiResult
    {
        public List<AmpherDataResponse> Result { get; set; }
    }
    public class MSCPETResult : ApiResult
    {
        public List<PETDataResponse> Result { get; set; }
    }
}
