using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class RolePermissionDataResponse : SysRoleData {

        public List<SysRoleMapPermissionData> PermissionCheck { get; set; }
        public List<PermissionDataResponse> PermissionDataResponse { get; set; }
    }
    public class PermissionDataResponse : View_RolePermissionData
    {
        public List<IDNameData> PermissionList { get; set; }
    }
    public class PermissionData
    {
        public List<int> PermissionID { get; set; }
    }
}
