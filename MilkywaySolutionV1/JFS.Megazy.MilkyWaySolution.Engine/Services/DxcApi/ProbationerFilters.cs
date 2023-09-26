using JFS.Megazy.MilkyWaySolution.Engine.Dal;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.DxcApi
{
    public class ProbationerFilters
    {
        /// <summary>
        /// จำนวนรายการข้อมูลต่อหน้า
        /// </summary>
        public int Size { get; set; } = 1;
        public string SortDirection { get; set; } = "DESC";
        public string Firstname { get; set; }
        public string UserCardID { get; set; }
    }
}