using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class MemberDataResponse : MemberData
    {
        public MemberDataResponse()
        {
            IsLoginSuccess = false;
            Remark = "";
        }
        public string Remark { get; set; }
        public bool IsLoginSuccess { get; set; }
        public int TypeOffailed { get; set; }
        //1 user failed 2 user and password failed
    }
}
