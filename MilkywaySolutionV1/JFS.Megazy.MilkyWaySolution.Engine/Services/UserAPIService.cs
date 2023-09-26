using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banish.Treasure.Megazy;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class UserAPIService
    {
        //api
        public UserRow AddUser(UserAPIDataRequest data, string userType, int userStatus, string verifyToken)
        {
            DalBase dal = new DalBase();
             UserRow ret = null;
            try
            {

                CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
                UserCollection_Base userBase = new UserCollection_Base(CSystems.ProcessID);
                List<SqlParameter> para = new List<SqlParameter>();
                para.Add(new SqlParameter("@UserName", System.Data.SqlDbType.NVarChar));
                para[0].Value = data.username.Trim();
                para.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar));
                para[1].Value = data.email.Trim();

                UserRow[] user = userBase.GetAsArray(para, "UserName=@UserName OR email=@Email", "");
                userBase.Dispose();
                if (user.Length == 0)
                {
                    //verifyToken = Membership.GeneratePassword(8, 1);
                    UserRow userRow = new UserRow();
                    userRow.UserName = data.username;
                    userRow.AliasName = data.firstname + " " + data.lastname;
                    userRow.Password = Maze.Cypher(verifyToken);
                    userRow.FirstName = data.firstname;
                    userRow.LastName = data.lastname;
                    userRow.CardID = data.cardid;
                    userRow.Gender = data.gender;
                    userRow.Title = data.title;
                    userRow.Email = data.email;
                    userRow.PhoneNumber = data.phonenumber;
                    userRow.UserTypeID = userType;
                    userRow.UserStatusID = userStatus;
                    userRow.IsVerifyByEmail = false;

                    UserCollection_Base usrBase = new UserCollection_Base(CSystems.ProcessID);
                    int userID = usrBase.InsertOnlyPlainText(userRow);
                    userRow.UserID = userID;
                    usrBase.Dispose();
                    if (userRow.UserID != 0)
                    {
                        DepartmentCollection_Base department = new DepartmentCollection_Base(CSystems.ProcessID);
                        List<SqlParameter> parameter = new List<SqlParameter>();
                        SqlParameter sqlpara = new SqlParameter("@DepartmentCode", System.Data.SqlDbType.VarChar) { Value = data.depid };
                        parameter.Add(sqlpara);
                        string whereSql = "[DepartmentCode] = @DepartmentCode";
                        var depRow = department.GetRow(parameter, whereSql);
                        department.Dispose();
                        if (depRow != null)
                        {
                            AddUserAdditional(userID, depRow.DepartmentID);
                            data.depid = depRow.DepartmentID;
                        }

                        AddUserOfficerMapRole(userID, data.roleid);
                        //depid 2  = กองทุนส่วนกลาง
                        int sysRoleID = data.depid == 2 ? 3 : 4;
                        AddUserMapRole(userID, sysRoleID);
                        AddUserPermission(userID, sysRoleID);
                    }
                    ret = userRow;
                }
                else {

                    ret = user[0];
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return ret;
        }

        public UserDataResponse APILoginVerification(string username)
        {
            UserDataResponse curr = null;
            try
            {
                List<SqlParameter> para = new List<SqlParameter>
                {
                    new SqlParameter("@UserName", System.Data.SqlDbType.VarChar)
                };
                para[0].Value = username;
                UserCollection_Base user = new UserCollection_Base(CSystems.ProcessID);
                UserRow[] userRow = user.GetAsArray(para, "UserName=@UserName", "UserID DESC");
                user.Dispose();
                if (userRow.Length > 0)
                {
                    curr = new UserDataResponse
                    {
                        UserID = userRow[0].UserID,
                        FirstName = userRow[0].FirstName,
                        LastName = userRow[0].LastName,
                        UserName = userRow[0].UserName,
                        AliasName = userRow[0].UserName,
                        CardID = userRow[0].CardID,
                        UserTypeID = userRow[0].UserTypeID
                    };
                    if (userRow[0].UserStatusID == 1)
                    {
                        UserAdditionalCollection_Base obj = new UserAdditionalCollection_Base(CSystems.ProcessID);
                        var row = obj.GetByPrimaryKey(userRow[0].UserID);
                        obj.Dispose();

                        if (row != null)
                        {
                            DepartmentCollection_Base dep = new DepartmentCollection_Base(CSystems.ProcessID);
                            var depRow = dep.GetByPrimaryKey(row.DepartmentID);
                            dep.Dispose();
                            if (depRow != null)
                            {
                                curr.DepartmentName = depRow.DepartmentName;
                                curr.ProvinceID = depRow.ProvinceID;
                            }
                            curr.IsAdmin = row.IsAdministrator;
                            curr.DepartmentID = row.DepartmentID;
                            curr.UpdateDate = DateTime.Now;
                            //if (row.SecondaryDepartmentID != 0)
                            //{
                            //    dep = new DepartmentCollection_Base(CSystems.ProcessID);
                            //    depRow = dep.GetByPrimaryKey(row.SecondaryDepartmentID);
                            //    dep.Dispose();
                            //    if (depRow != null)
                            //    {
                            //        curr.SecondaryDepartmentID = depRow.DepartmentID;
                            //        curr.SecondaryDepartmentName = depRow.DepartmentName;
                            //    }
                            //}
                        }
                        //เรียก Module ที่เข้าใช้งานได้
                        View_UserMapModuleCollection_Base userModule = new View_UserMapModuleCollection_Base(CSystems.ProcessID);
                        List<SqlParameter> parameter = new List<SqlParameter>();
                        SqlParameter sqlpara = new SqlParameter("@UserID", System.Data.SqlDbType.Int) { Value = userRow[0].UserID };
                        parameter.Add(sqlpara);
                        string whereSql = "[UserID] = @UserID";
                        string orderbySql = "ModuleID Asc";
                        var userModuleTow = userModule.GetAsArray(parameter, whereSql, orderbySql);
                        userModule.Dispose();
                        if (userModuleTow.Length != 0)
                        {
                            curr.Module = (from q in userModuleTow select q.ModuleID).ToArray();
                        }
                        curr.Login = true;
                    }
                    else {

                        curr.Login = false;
                    }
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return curr;
        }

        public void LogUserLogin(int userID, string ip, string deviceType)
        {

            DalBase dal = new DalBase();
            try
            {
                // dal.DbBeginTransaction(CSystems.ProcessID);
                UserLoginHistoryCollection_Base userLoginHistory = new UserLoginHistoryCollection_Base(CSystems.ProcessID);
                userLoginHistory.InsertOnlyPlainText(new UserLoginHistoryRow
                {
                    UserID = userID,
                    DeviceType = deviceType,
                    IP = ip,
                    LoginDate = dal.GetSqlNow(CSystems.ProcessID)
                });
                userLoginHistory.Dispose();
                // dal.DbCommit(CSystems.ProcessID);

            }
            catch (Exception ex)
            {
                // dal.DbRollBack(CSystems.ProcessID);
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="depid">DepartmentID ของระบบกองทุนเอง ไม่ใช่ของ MSC</param>
        private void AddUserAdditional(int userID, int depid, int secondaryDepID = 0)
        {

            UserAdditionalCollection_Base userAdditional = new UserAdditionalCollection_Base(CSystems.ProcessID);
            UserAdditionalRow additionalRow = new UserAdditionalRow
            {
                UserID = userID,
                DepartmentID = depid,
                IsAdministrator = false,
                ModifiedDate = DateTime.Now
            };
            userAdditional.InsertOnlyPlainText(additionalRow);
            userAdditional.Dispose();
        }

        private bool AddUserMapRole(int userID, int roleID)
        {

            bool res = false;
            var systemRole = SystemRoleByRoleID(roleID);

            if (systemRole != null)
            {

                UserMapRoleCollection_Base userMap = new UserMapRoleCollection_Base(CSystems.ProcessID);
                userMap.InsertOnlyPlainText(new UserMapRoleRow
                {
                    UserID = userID,
                    RoleID = systemRole.RoleID,
                    AssignID = 8,   //usertest
                    ModifiedDate = new DalBase().GetSqlNow(CSystems.ProcessID)
                });
                userMap.Dispose();
                res = true;
            }

            return res;
        }

        private void AddUserPermission(int userID, int roleID)
        {

            //check role

            var systemRole = SystemRoleByRoleID(roleID);
            if (systemRole != null)
            {
                //check role map permisstion
                var sysRoleMapPermission = SystemRoleMapPermission(systemRole.RoleID);
                if (sysRoleMapPermission.Length > 0)
                {
                    DalBase dal = new DalBase();
                    for (int i = 0; i < sysRoleMapPermission.Length; i++)
                    {
                        UserMapPermissionCollection_Base userMap = new UserMapPermissionCollection_Base(CSystems.ProcessID);
                        userMap.InsertOnlyPlainText(new UserMapPermissionRow
                        {
                            UserID = userID,
                            PermissionID = sysRoleMapPermission[i].PermissionID,
                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                        });
                        userMap.Dispose();

                    }
                }
            }

        }

        private void AddUserOfficerMapRole(int userID, int officerRoleID = 2)
        {
            var officerRole = OfficerRoleByRoleID(officerRoleID);
            if (officerRole != null)
            {
                OfficerMapRoleCollection_Base officerMapRole = new OfficerMapRoleCollection_Base(CSystems.ProcessID);
                officerMapRole.InsertOnlyPlainText(new OfficerMapRoleRow
                {
                    UserID = userID,
                    OfficeRoleID = officerRole.OfficerRoleID,
                    ModifiedDate = new DalBase().GetSqlNow(CSystems.ProcessID)
                });
                officerMapRole.Dispose();
            }
        }

        private SysRoleMapPermissionRow[] SystemRoleMapPermission(int roleID)
        {
            SysRoleMapPermissionCollection_Base sysRoleMapPermission = new SysRoleMapPermissionCollection_Base(CSystems.ProcessID);
            SysRoleMapPermissionRow[] res = sysRoleMapPermission.GetByRoleID(roleID);
            sysRoleMapPermission.Dispose();
            return res;
        }

        private SysRoleRow SystemRoleByRoleID(int roleID)
        {
            SysRoleCollection_Base sysRole = new SysRoleCollection_Base(CSystems.ProcessID);
            SysRoleRow res = sysRole.GetByPrimaryKey(roleID);
            sysRole.Dispose();
            return res;
        }

        private OfficerRoleRow OfficerRoleByRoleID(int officerRoleID)
        {
            OfficerRoleCollection_Base officerRole = new OfficerRoleCollection_Base(CSystems.ProcessID);
            OfficerRoleRow  res = officerRole.GetByPrimaryKey(officerRoleID);
            officerRole.Dispose();
            return res;
        }

        
        //api
    }
}
