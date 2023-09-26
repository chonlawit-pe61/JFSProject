namespace JFS.Megazy.MilkyWaySolution.Engine.Services.DxcApi
{
    public class JuvenilOffenderFilters
    {
        /// <summary>
        /// จำนวนรายการข้อมูลต่อหน้า
        /// </summary>
        public int Size { get; set; } = 1;
        public string SortDirection { get; set; } = "DESC";
        public string Firstname { get; set; }
    }
}