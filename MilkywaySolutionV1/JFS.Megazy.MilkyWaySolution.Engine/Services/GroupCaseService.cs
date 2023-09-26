using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class GroupCaseService
    {
        public GroupCaseResponse InsertGroupMapCase(int groupID ,List<int> caseID = null)
        {
            GroupCaseResponse res = new GroupCaseResponse();
            if (groupID != 0 && caseID.Count > 0 && caseID != null)
            {
                GroupMapCaseCollection_Base mapCaseObj = new GroupMapCaseCollection_Base(CSystems.ProcessID);
                mapCaseObj.DeleteByGroupID(groupID);
                foreach (var item in caseID)
                {
                    mapCaseObj.Insert(new GroupMapCaseRow
                    {
                        GroupID = groupID,
                        CaseID = item,
                    });
                }
                mapCaseObj.Dispose();
                res.Status = true;
                res.Message = "เพิ่มสำนวนแบบกลุ่มสำเร็จ";
            }
            else
            {
                res.Status = false;
                res.Message = "เกิดข้อผิดพลาดในการบันทึกข้อมูล";
            }

            return res;
        }
        public View_GroupCaseRow[] GetGroupCaseByCaseID(int caseID) {

            View_GroupCaseRow[] res = null;
            View_GroupCaseCollection_Base obj = new View_GroupCaseCollection_Base(CSystems.ProcessID);
            SqlParameter sql = new SqlParameter();
            List<SqlParameter> listsqlparameters = new List<SqlParameter>();
            if(caseID != 0)
            {
                int groupID = 0;
                GroupMapCaseCollection_Base groupmapObj = new GroupMapCaseCollection_Base(CSystems.ProcessID);
                //var groupmapRow = groupmapObj.GetRow();






            }
            
            
            obj.Dispose();
            return res;
        }
        public View_GroupCaseRow[] GetGroupCaseByGroupID(int groupID)
        {

            View_GroupCaseRow[] res = null;
            View_GroupCaseCollection_Base obj = new View_GroupCaseCollection_Base(CSystems.ProcessID);
            SqlParameter sql = new SqlParameter();
            List<SqlParameter> listsqlparameters = new List<SqlParameter>();


            obj.Dispose();
            return res;
        }
        public List<int> GetCaseIDByGroupID(int groupID)
        {
            List<int> res = new List<int>();
            GroupMapCaseCollection_Base obj = new GroupMapCaseCollection_Base(CSystems.ProcessID);
            var row = obj.GetByGroupID(groupID);
            obj.Dispose();
            if(row != null)
            {
                res = row.Select(p => p.CaseID).ToList<int>();
            }
            return res;
        }
        public bool GroupDeleteFlag(int groupID)
        {
            bool res = false;
            GroupCaseCollection_Base obj = new GroupCaseCollection_Base(CSystems.ProcessID);
            var row = obj.GetByPrimaryKey(groupID);
            obj.Dispose();
            if(row != null)
            {
                row.DeleteFlag = true;
                row.ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID);
                obj = new GroupCaseCollection_Base(CSystems.ProcessID);
                obj.UpdateOnlyPlainText(row);
                res = true;
            }
            return res;
        }
        public GroupCaseRow[] GetGroupCaseList(int depId = 0)
        {

            GroupCaseCollection_Base obj = new GroupCaseCollection_Base(CSystems.ProcessID);
            string where = "[DeleteFlag] = 0";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            if (depId > 0)
            {
               
                SqlParameter sqlParameter = new SqlParameter("@depId", System.Data.SqlDbType.Int) { Value = depId };
                sqlParameters.Add(sqlParameter);
                where += $"AND [DepartmentID] = @depId";
            }

            return obj.GetAsArray(sqlParameters, where, "GroupID ASC");
        }
        public int InsertOrUpDateGroupCase(GroupCaseData req)
        {
            int groupID = 0;
            GroupCaseCollection_Base obj = new GroupCaseCollection_Base(CSystems.ProcessID);
            var row = obj.GetByPrimaryKey(req.GroupID);
            obj.Dispose();

            if (string.IsNullOrEmpty(req.GroupName))
            {
                req.GroupName = $"ไม่มีชื่อกลุ่ม: สร้างโดย{req.UserCreateID}";
            }
            if (row != null)
            {
                row.GroupName = req.GroupName;
                //row.DepartmentID = req.DepartmentID;
                //row.UserCreateID = req.UserCreateID;
                //row.DeleteFlag = req.DeleteFlag;
                row.ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID);
                groupID = req.GroupID;

                obj = new GroupCaseCollection_Base(CSystems.ProcessID);
                obj.UpdateOnlyPlainText(row);
                obj.Dispose();
            }
            else
            {

                obj = new GroupCaseCollection_Base(CSystems.ProcessID);
                groupID = obj.InsertOnlyPlainText(new GroupCaseRow
                {
                    GroupName = req.GroupName,
                    DeleteFlag = false,
                    DepartmentID = req.DepartmentID,
                    UserCreateID = req.UserCreateID,
                    CreateDate = DalBase.SqlNowIncludePd(CSystems.ProcessID),
                    ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID)
                });
                obj.Dispose();
            }
            return groupID;
        } 
    }
    public class GroupCaseResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
