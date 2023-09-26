using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class AccusedTracking
    {
        public int AccusedTrackingID { get; set; }
        public int CaseID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Note { get; set; }

    }

    public class AccusedTrackingRespon
    {
        public AccusedTracking Accused { get; set; }
    }

    public class AccusedTrackingDetail : AccusedTracking
    {
        public int TrackingID { get; set; }
        public string ReportToOfficerName { get; set; }
        public string ReportAtCode { get; set; }
        public string LocationName { get; set; }
        public string NoteTracking { get; set; }
        public string ReportDate { get; set; }
        public string TrackingCode { get; set; }
        public int UserID { get; set; }
    }

    public class AccusedTrackingDetailRespon : AccusedTrackingRow
    {
        public AccusedTrackingDetail Detail { get; set; }

        public AccusedTrackingDetailRow[] OptionList { get; set; }
    }

    
}
