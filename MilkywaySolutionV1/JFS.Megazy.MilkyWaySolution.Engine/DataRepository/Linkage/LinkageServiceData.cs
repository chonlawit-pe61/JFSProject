using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Linkage
{
    public abstract class LinkageServiceData
    {
        public int InspectID { get; set; }
        public string SupportCode { get; set; }
        public string OfficeID { get; set; }
        public string ServiceVersion { get; set; }
        public string ServiceID { get; set; }
        public string OfficerCode { get; set; } = "00887";
        /// <summary>
        /// เลขที่บัตรประจำตัวประชาชน
        /// </summary>
        public string PID { get; set; }
    }
}
