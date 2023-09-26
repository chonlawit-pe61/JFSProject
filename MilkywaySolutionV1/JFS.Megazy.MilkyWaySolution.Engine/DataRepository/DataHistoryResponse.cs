using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
  public  class DataHistoryResponse
    {
        public IEnumerable<ApplicantChangeHistoryData> ApplicantChange { get; set; }
        public IEnumerable<View_CaseChangeData> CaseChange { get; set; }
        public IEnumerable<View_WorkStepChangeHistoryData> WorkStepChange { get; set; }
        public IEnumerable<AssignmentRecordData> AssignmentChange { get; set; }
    }



    public class DataProcessResponse
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string ProcessDate { get; set; }
        public IEnumerable<DataProcessResponse> SubProcess { get; set; }
        public DataJudgeResult DataJudgeResult { get; set; }
    }
  
    public class DataJudgeResult {
        public string JudgeDate { get; set; }
        public string Message { get; set; }
        public bool IsApprove { get; set; }
        public string ApproveAmount { get; set; }
    }
}
