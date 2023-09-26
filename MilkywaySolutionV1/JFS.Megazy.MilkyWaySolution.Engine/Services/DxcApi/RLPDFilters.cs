using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.DxcApi
{
   public class RLPDFilters
    {
        ///// <summary>
        ///// nin:เลขประจำตัวประชาชน
        ///// </summary>
        //public string CardID { get; set; }
        /// <summary>
        /// เลขหน้าข้อมูล (เริ่มที่เลข 0)
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// จำนวนข้อมูลต่อหน้า ค่าเริ่มต้น 10 รายการ
        /// </summary>
        public int Size { get; set; } = 10;
        /// <summary>
        /// userNin:เลขประจำตัวประชาชน ผู้ใช้งาน 
        /// </summary>
        public string UserCardID { get; set; }
    }
}
