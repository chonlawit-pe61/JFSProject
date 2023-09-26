using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.DxcApi
{
    public class SeizeFilters
    {
        /// <summary>
        /// เลขบัตรประจำตัวผู้ถูกอายัดตัว
        /// </summary>
       // public string CitizenCardNumber { get; set; }
        /// <summary>
        /// จำนวนรายการข้อมูลต่อหน้า
        /// </summary>
        public int Size { get; set; } = 1;
        public string SortDirection { get; set; } = "DESC";
        public string Firstname { get; set; }
    }
}
