using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
   public class UserPermissionDataRequest 
    {
        public int UserID { get; set; }
       // public int AssignByUserID { get; set; }
        public int[] PermissionData { get; set; }
    }
}
