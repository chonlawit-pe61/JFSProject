using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class NameValueData
    {
        public string Name { get; set; }
        public string Val { get; set; }
        //ปาล์มเพิ่ม
        public string DepID { get; set; }
    }
    public class IDNameData
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public class WorkStepChange
    {
        public int WorkStepID { get; set; }
        public string WorkStepName { get; set; }
        public DateTime ChangeDate { get; set; }
        public int DepartmentID { get; set; }
    }
}