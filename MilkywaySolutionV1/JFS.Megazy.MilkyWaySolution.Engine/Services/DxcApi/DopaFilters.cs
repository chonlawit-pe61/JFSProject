using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.DxcApi
{
    public class DopaFilters
    {
        /// <summary>
        /// จำนวนรายการข้อมูลต่อหน้า
        /// </summary>
        public int maxNumberOfResults { get; set; } = 1;
        public string orderBy { get; set; } = "DESC";
        /// <summary>
        /// userCitizenNumber:เลขประจำตัวประชาชน ผู้ใช้งาน 
        /// </summary>
        public string UserCardID { get; set; }
    }
}
