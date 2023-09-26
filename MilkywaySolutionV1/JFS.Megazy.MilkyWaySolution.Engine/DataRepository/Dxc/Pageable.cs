using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc
{

    public class Pageable
    {
        public int offset { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public bool paged { get; set; }
        public Sort sort { get; set; }
        public bool unpaged { get; set; }

    }
}
