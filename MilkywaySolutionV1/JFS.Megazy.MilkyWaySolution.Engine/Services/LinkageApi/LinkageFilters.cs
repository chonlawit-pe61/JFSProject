using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.LinkageApi
{
   public class LinkageFilters
    {
        [Required(ErrorMessage = "ServiceOfficerID is required.")]
        public string ServiceOfficerID { get; set; }
        [Required(ErrorMessage = "ServiceVersion is required.")]
        public string ServiceVersion { get; set; }
        [Required(ErrorMessage = "ServiceID is required.")]
        public string ServiceID { get; set; }
        [Required(ErrorMessage = "กรุณาใส่เลขที่บัตรประชาชน")]
        public string PID { get; set; }
        [Required(ErrorMessage = "Token Key is required.")]
        public string TKey { get; set; }
    }
}
