using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Configuration;
using Banish.Treasure.Megazy;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using Newtonsoft.Json;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class UserService
    {
        public UserData ViewEditMember(int processID, int userID, CultureInfo cultureInfo, CultureInfo culture, string format)
        {
            UserData ret = new UserData();
            try
            {
                UserCollection_Base userBase = new UserCollection_Base(processID);
                UserRow user = userBase.GetByPrimaryKey(userID);
                userBase.Dispose();

                ret.UserID = user.UserID;
                ret.UserName = user.UserName;
                ret.FirstName = user.FirstName;
                ret.LastName = user.LastName;
                ret.Gender = user.Gender;
                ret.CardID = user.CardID;
                ret.DateOfBirthStr = Helpers.Utility.ConvertDateToThaiLongDate(user.DateOfBirth);
                ret.Email = user.Email;
                ret.PhoneNumber = user.PhoneNumber;
                ret.UserTypeID = user.UserTypeID;
                ret.UserStatusID = user.UserStatusID;
                ret.IsVerifyByEmail = user.IsVerifyByEmail;
                ret.UpdateDateStr = user.UpdateDate.ToString(format, culture);

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }

            return ret;
        }
        public RolePermissionDataResponse GetPermission(int roleID)
        {
            // List<PermissionDataResponse>
            RolePermissionDataResponse res = new RolePermissionDataResponse();
            List<PermissionDataResponse> permissionDatas = new List<PermissionDataResponse>();
            View_RolePermissionCollection_Base obj = new View_RolePermissionCollection_Base(CSystems.ProcessID);
            var row = obj.GetAsArray(new List<SqlParameter>(), "IsActive = 1", "SortOrder ASC");
            obj.Dispose();
            foreach (var item in row)
            {
                // PermissionDataResponse data = 
                permissionDatas.Add(new PermissionDataResponse
                {
                    IsActive = item.IsActive,
                    ModuleIcon = item.ModuleIcon,
                    ModuleID = item.ModuleID,
                    ModuleName = item.ModuleName,
                    ModuleTitle = item.ModuleTitle,
                    SortOrder = item.SortOrder,
                    PermissionList = item.Permission != null ? JsonConvert.DeserializeObject<List<IDNameData>>(item.Permission) : new List<IDNameData>()
                });
            }
            res.PermissionDataResponse = permissionDatas;
            res.PermissionCheck = new List<SysRoleMapPermissionData>();

            SysRoleCollection_Base sysRole = new SysRoleCollection_Base(CSystems.ProcessID);
            var sysRoleRow = sysRole.GetByPrimaryKey(roleID);
            sysRole.Dispose();
            if (sysRoleRow != null)
            {
                res.IsActive = sysRoleRow.IsActive;
                res.IsShow = sysRoleRow.IsShow;
                res.RoleID = sysRoleRow.RoleID;
                res.RoleName = sysRoleRow.RoleName;

                SysRoleMapPermissionCollection_Base sysRoleMap = new SysRoleMapPermissionCollection_Base(CSystems.ProcessID);
                var sysRoleMaprow = sysRoleMap.GetByRoleID(roleID);
                sysRoleMap.Dispose();
                if (sysRoleMaprow.Length != 0)
                {
                    res.PermissionCheck = (from q in sysRoleMaprow
                                           select new SysRoleMapPermissionData { PermissionID = q.PermissionID, RoleID = q.RoleID }).ToList();
                }

            }
            return res;
        }

        //public ManageUser ViewManageUser(int processID, string userTypeID)
        //{
        //    ManageUser res = new ManageUser();

        //    try
        //    {
        //        UserTypeCollection_Base typeBase = new UserTypeCollection_Base(processID);
        //        UserTypeRow type = typeBase.GetByPrimaryKey(userTypeID);
        //        typeBase.Dispose();
        //        res.UserTypeID = userTypeID;
        //        res.UserTypeName = type.Name;

        //        SysModuleCollection_Base moduleBase = new SysModuleCollection_Base(processID);
        //        List<SqlParameter> param = new List<SqlParameter>();
        //        param.Add(new SqlParameter("@IsActive", System.Data.SqlDbType.Bit));
        //        param[0].Value = 1;
        //        SysModuleRow[] module = moduleBase.GetAsArray(param, "IsActive=@IsActive", "seqno asc");
        //        res.MappingUserType = new List<MappingUserType>();
        //        foreach (var data in module)
        //        {
        //            var ModuleID = data.ModuleID;
        //            UserTypeSysModuleMappingCollection_Base mapBase = new UserTypeSysModuleMappingCollection_Base(processID);
        //            List<SqlParameter> para = new List<SqlParameter>();
        //            para.Add(new SqlParameter("@UserTypeID", System.Data.SqlDbType.VarChar));
        //            para[0].Value = userTypeID;
        //            para.Add(new SqlParameter("@ModuleID", System.Data.SqlDbType.Int));
        //            para[1].Value = ModuleID;
        //            UserTypeSysModuleMappingRow[] map = mapBase.GetAsArray(para, "UserTypeID=@UserTypeID AND ModuleID=@ModuleID", "");
        //            mapBase.Dispose();

        //            foreach (var item in map)
        //            {
        //                MappingUserType mapping = new MappingUserType();
        //                mapping.ModuleID = item.ModuleID;
        //                mapping.UserTypeID = item.UserTypeID;

        //                SysModuleCollection_Base sysBase = new SysModuleCollection_Base(processID);
        //                SysModuleRow sys = sysBase.GetByPrimaryKey(mapping.ModuleID);
        //                sysBase.Dispose();

        //                mapping.Title = sys.Title;

        //                res.MappingUserType.Add(mapping);

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        DalBase.ExceptEngine.ThrowException(processID, ex);
        //    }

        //    return res;
        //}
        public bool EditUserPermission(UserPermissionDataRequest req)
        {
            DalBase dal = new DalBase();
            try
            {
                UserMapPermissionCollection_Base userMapPermission = new UserMapPermissionCollection_Base(CSystems.ProcessID);
                userMapPermission.DeleteByUserID(req.UserID);
                var dt = dal.GetSqlNow(CSystems.ProcessID);
                if (req.PermissionData != null)
                {
                    foreach (var item in req.PermissionData)
                    {
                        userMapPermission.Insert(new UserMapPermissionRow
                        {
                            //AssignID = req.AssignByUserID,
                            PermissionID = item,
                            UserID = req.UserID,
                            ModifiedDate = dt
                        });
                    }
                }
                userMapPermission.Dispose();

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return true;
        }


        public UserData ViewMy(int processID, int userID, CultureInfo cultureInfo, CultureInfo culture, string format)
        {
            UserData ret = new UserData();
            try
            {
                UserCollection_Base userBase = new UserCollection_Base(processID);
                UserRow user = userBase.GetByPrimaryKey(userID);
                userBase.Dispose();
                ret.UserID = user.UserID;
                ret.UserName = user.UserName;
                ret.FirstName = user.FirstName;
                ret.LastName = user.LastName;
                ret.Gender = user.Gender; 
                ret.CardID = user.CardID;
                ret.DateOfBirthStr = Helpers.Utility.ConvertDateToThaiLongDate(user.DateOfBirth);// user.DateOfBirth.ToString("yyyy-MM-dd", cultureInfo);
                ret.Email = user.Email;
                ret.PhoneNumber = user.PhoneNumber;
                ret.UserTypeID = user.UserTypeID;
                ret.UserStatusID = user.UserStatusID;
                ret.IsVerifyByEmail = user.IsVerifyByEmail;
                ret.UpdateDateStr = user.UpdateDate.ToString(format, culture);

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }

            return ret;
        }

        //public PagingUser GetListUser(int processID, string firstname, string userTypeID, int startRowRankPage, int plim, CultureInfo culture, string format, string formatDate)
        //{
        //    PagingUser ret = new PagingUser();
        //    try
        //    {
        //        string query = "";
        //        List<SqlParameter> parameter = new List<SqlParameter>();
        //        if (!string.IsNullOrEmpty(userTypeID))
        //        {
        //            parameter.Add(new SqlParameter("@userTypeID", System.Data.SqlDbType.VarChar));
        //            parameter[0].Value = "%" + userTypeID + "%";

        //            query = "userTypeID like @userTypeID";
        //        }

        //        if (!string.IsNullOrEmpty(firstname))
        //        {
        //            int paraLen = parameter.Count;
        //            parameter.Add(new SqlParameter("@firstname", System.Data.SqlDbType.NVarChar));
        //            parameter[paraLen].Value = "%" + firstname + "%";

        //            query += (query.Length == 0 ? "" : " and ") + "firstname like @firstname";
        //        }

        //        UserCollection_Base userBase = new UserCollection_Base(processID);
        //        UserItemsPaging row = userBase.GetUserPagingAsArray(parameter, query, startRowRankPage, plim, "UserID DESC");
        //        userBase.Dispose();

        //        ret.TotalPage = row.totalPage;
        //        ret.TotalRow = row.totalRow;
        //        ret.ListUser = new List<User>();

        //        foreach (UserItems item in row.userItems)
        //        {
        //            User ur = new User();
        //            ur.UserID = item.UserID;
        //            ur.Name = item.FirstName + " " + item.LastName;
        //            ur.RowRank = item.RowRank;
        //            ur.IsVerify = item.IsVerifyByEmail;
        //            ur.CreateDate = item.RegistDate.ToString(formatDate, culture);


        //            UserTypeCollection_Base typeBase = new UserTypeCollection_Base(processID);
        //            UserTypeRow type = typeBase.GetByPrimaryKey(item.UserTypeID);
        //            typeBase.Dispose();
        //            ur.UserType = type.Name;

        //            UserStatusCollection_Base tusBase = new UserStatusCollection_Base(processID);
        //            UserStatusRow status = tusBase.GetByPrimaryKey(item.UserStatusID);
        //            tusBase.Dispose();
        //            ur.UserStatus = status.Description;

        //            ret.ListUser.Add(ur);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        DalBase.ExceptEngine.ThrowException(processID, ex);
        //    }

        //    return ret;
        //}

        public bool Edit(UserDataRequest req)
        {
            bool status = false;
            int processID = CSystemsAsync.ProcessID;
            try
            {
                if (req.UserID > 0)
                {
                    UserCollection_Base userbase = new UserCollection_Base(processID);
                    UserRow userRow = userbase.GetByPrimaryKey(req.UserID);
                    userbase.Dispose();

                    if (userRow != null)
                    {

                        //Check email change
                        if (userRow.Email.Equals(req.Email, StringComparison.InvariantCultureIgnoreCase))
                        {
                            userRow.FirstName = req.FirstName;
                            userRow.LastName = req.LastName;
                            userRow.Gender = req.Gender;
                            userRow.CardID = req.CardID;
                            //if (!string.IsNullOrWhiteSpace(birthDate) && Helpers.Utility.DateValidateInput(DateTime.ParseExact(birthDate, "yyyy-MM-dd", cultureInfo)))
                            //{
                            //    userRow.DateOfBirth = DateTime.ParseExact(birthDate, "yyyy-MM-dd", cultureInfo);
                            //}
                            userRow.Email = req.Email;
                            userRow.PhoneNumber = req.PhoneNumber;
                            if (!string.IsNullOrEmpty(req.UserTypeID)) userRow.UserTypeID = req.UserTypeID;
                            if (req.UserStatusID != 0) userRow.UserStatusID = req.UserStatusID;
                            if (userRow.UserStatusID == 1)
                            {
                                userRow.IsVerifyByEmail = true;
                            }
                            userbase = new UserCollection_Base(processID);
                            userbase.UpdateOnlyPlainText(userRow);
                            userbase.Dispose();
                            SaveSignature(req.UserID, req.IMGbase64);
                        }
                        else
                        {
                            userbase = new UserCollection_Base(processID);
                            List<SqlParameter> parameter = new List<SqlParameter>();
                            SqlParameter sqlpara = new SqlParameter("@Email", System.Data.SqlDbType.VarChar) { Value = req.Email };
                            parameter.Add(sqlpara);
                            sqlpara = new SqlParameter("@UserID", System.Data.SqlDbType.Int) { Value = userRow.UserID };
                            parameter.Add(sqlpara);
                            UserRow[] user = userbase.GetAsArray(parameter, "Email=@Email AND UserID <> @UserID", "");
                            if (user.Length == 0)
                            {
                                userRow.FirstName = req.FirstName;
                                userRow.LastName = req.LastName;
                                userRow.Gender = req.Gender;
                                userRow.Email = req.Email;
                                userRow.CardID = req.CardID;
                                userRow.PhoneNumber = req.PhoneNumber;
                                if (!string.IsNullOrEmpty(req.UserTypeID)) userRow.UserTypeID = req.UserTypeID;
                                if (req.UserStatusID != 0) userRow.UserStatusID = req.UserStatusID;
                                if (userRow.UserStatusID == 1)
                                { 
                                    userRow.IsVerifyByEmail = true; 
                                }
                                userbase = new UserCollection_Base(processID);
                                userbase.UpdateOnlyPlainText(userRow);
                                userbase.Dispose();
                                SaveSignature(req.UserID, req.IMGbase64);
                            }
                            else
                            {
                                userRow.FirstName = req.FirstName;
                                userRow.LastName = req.LastName;
                                userRow.Gender = req.Gender;
                                userRow.CardID = req.CardID;
                                userRow.PhoneNumber = req.PhoneNumber;
                                if (!string.IsNullOrEmpty(req.UserTypeID)) userRow.UserTypeID = req.UserTypeID;
                                if (req.UserStatusID != 0) userRow.UserStatusID = req.UserStatusID;
                                if (userRow.UserStatusID == 1)
                                {
                                    userRow.IsVerifyByEmail = true;
                                }
                                userbase = new UserCollection_Base(processID);
                                userbase.UpdateOnlyPlainText(userRow);
                                userbase.Dispose();
                                SaveSignature(req.UserID, req.IMGbase64);
                            }
                        }
                    }
                }
                status = true;
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }

            return status;
        }
        private bool SaveSignature(int userID,string base64)
        {
            bool Ispass = false;
            UserAdditionalCollection_Base obj = new UserAdditionalCollection_Base(CSystems.ProcessID);
            var row = obj.GetByPrimaryKey(userID);
            obj.Dispose();
            if(row != null)
            {
                row.ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID);
                row.Signature = base64;
                obj = new UserAdditionalCollection_Base(CSystems.ProcessID);
                obj.Update(row);
                obj.Dispose();
                Ispass = true;
            }
            return Ispass;
        }
        public ResponseResult EditUserName(int processID, int userID, string userName)
        {
            ResponseResult res = new ResponseResult();
            DalBase dal = new DalBase();
            try
            {
                UserCollection_Base userBase = new UserCollection_Base(processID);
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlpara = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar) { Value = userName.Trim() };
                parameter.Add(sqlpara);
                UserRow[] user = userBase.GetAsArray(parameter, "UserName=@UserName", "");
                if (user.Length == 0)
                {
                    userBase = new UserCollection_Base(processID);
                    var userRow = userBase.GetByPrimaryKey(userID);
                    if (userRow != null)
                    {
                        userRow.UserName = userName.Trim();
                        userBase.UpdateOnlyPlainText(userRow);
                    }
                    res.Status = true;
                }
                else
                {
                    res.Message = "มีชื่อผู้ใช้งานนี้อยู่่ในระบบแล้ว";
                }
                userBase.Dispose();
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }

            return res;
        }

        public List<UserTypeData> GetUserType(int processID)
        {
            List<UserTypeData> ret = new List<UserTypeData>();
            try
            {
                UserTypeCollection_Base typeBase = new UserTypeCollection_Base(processID);
                UserTypeRow[] type = typeBase.GetAll();
                typeBase.Dispose();
                foreach (var item in type)
                {
                    UserTypeData urtype = new UserTypeData();
                    urtype.UserTypeID = item.UserTypeID;
                    urtype.Name = item.Name;

                    ret.Add(urtype);
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }
            return ret;
        }

        public List<UserStatusData> GetUserStatus(int processID)
        {
            List<UserStatusData> ret = new List<UserStatusData>();
            try
            {
                UserStatusCollection_Base statusBase = new UserStatusCollection_Base(processID);
                UserStatusRow[] status = statusBase.GetAll();
                statusBase.Dispose();
                foreach (var item in status)
                {
                    ret.Add(new UserStatusData
                    {
                        Description = item.Description,
                        UserStatusID = item.UserStatusID
                    });
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }

            return ret;
        }
        public UserDataResponse LoginVerification(int processID, string username, string pw)
        {

            UserDataResponse curr = null;
            try
            {

                List<SqlParameter> para = new List<SqlParameter>
                {
                    new SqlParameter("@UserName", System.Data.SqlDbType.VarChar)
                };
                para[0].Value = username;
                para.Add(new SqlParameter("@Password", System.Data.SqlDbType.VarChar));
                para[1].Value = Maze.Cypher(pw);
                //para[1].Value = "504f008c8fcf8b2ed5dfcde752fc5464ab8ba064215d9c5b5fc486af3d9ab8c81b14785180d2ad7cee1ab792ad44798c";

                UserCollection_Base user = new UserCollection_Base(processID);
                UserRow[] userRow = user.GetAsArray(para, "UserName=@UserName and PassWord=@Password", "");
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

                    if (userRow[0].IsVerifyByEmail && !userRow[0].IsRenewAccount)
                    {
                        userRow[0].LastLoginDate = new DalBase().GetSqlNow(processID);
                        user = new UserCollection_Base(processID);
                        user.UpdateOnlyPlainText(userRow[0]);
                        user.Dispose();

                        curr.Login = true;
                    }
                    else
                    {
                        List<SqlParameter> param = new List<SqlParameter>
                        {
                            new SqlParameter("@userID", System.Data.SqlDbType.Int)
                        };
                        param[0].Value = userRow[0].UserID;
                        param.Add(new SqlParameter("@token", System.Data.SqlDbType.VarChar));
                        param[1].Value = Maze.Cypher(pw);

                        string query = @"userid=@userID and token=@token and getdate() < expiredate";

                        UserRenewTicketCollection_Base userRenewBase = new UserRenewTicketCollection_Base(processID);
                        UserRenewTicketRow[] userRenewRow = userRenewBase.GetAsArray(param, query, "ticketid desc");
                        userRenewBase.Dispose();

                        if (userRenewRow.Length > 0)
                        {
                            curr.Login = false;
                            curr.RefToken = userRenewRow[0].TicketID;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }
            return curr;
        }

        public bool ConfirmAction(int processID, int refToken, int userID, string data)
        {
            bool ret = false;
            try
            {

                UserCollection_Base userBase = new UserCollection_Base(processID);
                UserRow userRow = userBase.GetByPrimaryKey(userID);
                userBase.Dispose();

                if (userRow != null)
                {
                    if (Maze.Cypher(userRow.Password) != Maze.Cypher(data))
                    {
                        userRow.IsVerifyByEmail = true;
                        userRow.IsRenewAccount = false;
                        userRow.RenewTicketID = refToken;
                        userRow.UpdateDate = new DalBase().GetSqlNow(processID);
                        userRow.UpdateBy = userRow.UserID;
                        userRow.Password = Maze.Cypher(data);

                        userBase = new UserCollection_Base(processID);
                        userBase.UpdateOnlyPlainText(userRow);
                        userBase.Dispose();

                        ret = true;

                    }

                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }

            return ret;
        }
        public void SetUserRole(int userID, int assingUserID, int roleID)
        {

            DalBase dal = new DalBase();
            try
            {
                UserMapRoleCollection_Base userMapRole = new UserMapRoleCollection_Base(CSystems.ProcessID);
                userMapRole.DeleteByUserID(userID);
                userMapRole.Insert(new UserMapRoleRow
                {
                    UserID = userID,
                    RoleID = roleID,
                    AssignID = assingUserID,
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                });
                userMapRole.Dispose();

                UserMapPermissionCollection_Base userMapPermission = new UserMapPermissionCollection_Base(CSystems.ProcessID);
                userMapPermission.DeleteByUserID(userID);
                SysRoleMapPermissionCollection_Base sysRoleMapPermission = new SysRoleMapPermissionCollection_Base(CSystems.ProcessID);
                var sysRoleMapPermissionRow = sysRoleMapPermission.GetByRoleID(roleID);
                sysRoleMapPermission.Dispose();
                foreach (var item in sysRoleMapPermissionRow)
                {
                    userMapPermission.Insert(new UserMapPermissionRow
                    {
                        PermissionID = item.PermissionID,
                        UserID = userID,
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                    });
                }
                userMapPermission.Dispose();
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
        }

        //public List<Module> GetListModule(int processID, string userType)
        //{
        //    List<Module> ret = new List<Module>();
        //    try
        //    {
        //        SysModuleCollection_Base moduleBase = new SysModuleCollection_Base(processID);
        //        SysModuleRow[] module = moduleBase.GetAsArray(new List<SqlParameter>(), "IsActive = 1", "seqno asc");
        //        moduleBase.Dispose();
        //        foreach (var item in module)
        //        {
        //            Module mo = new Module();
        //            mo.ModuleID = item.ModuleID;
        //            mo.Title = item.Title;

        //            UserTypeSysModuleMappingCollection_Base mappingBase = new UserTypeSysModuleMappingCollection_Base(processID);
        //            List<SqlParameter> para = new List<SqlParameter>();
        //            para.Add(new SqlParameter("@ModuleID", System.Data.SqlDbType.Int));
        //            para[0].Value = mo.ModuleID;
        //            para.Add(new SqlParameter("@UserTypeID", System.Data.SqlDbType.VarChar));
        //            para[1].Value = userType;
        //            string query = "ModuleID=@ModuleID AND UserTypeID=@UserTypeID";
        //            UserTypeSysModuleMappingRow[] mapp = mappingBase.GetAsArray(para, query, "");
        //            mappingBase.Dispose();
        //            if (mapp.Length > 0)
        //            {
        //                foreach (var data in mapp)
        //                {
        //                    mo.UserType = data.UserTypeID;
        //                    ret.Add(mo);
        //                }

        //            }
        //            else
        //            {
        //                ret.Add(mo);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        DalBase.ExceptEngine.ThrowException(processID, ex);
        //    }

        //    return ret;
        //}

        //public bool SaveModuleMapping(int processID, string userTypeID, List<MappingUserType> mappingData)
        //{
        //    bool status = false;
        //    DalBase dal = new DalBase();
        //    dal.DbBeginTransaction(processID);
        //    try
        //    {
        //        UserTypeSysModuleMappingCollection_Base mappBase = new UserTypeSysModuleMappingCollection_Base(processID);
        //        List<SqlParameter> para = new List<SqlParameter>();
        //        para.Add(new SqlParameter("@UserTypeID", System.Data.SqlDbType.VarChar));
        //        para[0].Value = userTypeID;
        //        UserTypeSysModuleMappingRow[] mapp = mappBase.GetAsArray(para, "UserTypeID=@UserTypeID", "");
        //        mappBase.Dispose();
        //        foreach (var item in mapp)
        //        {
        //            UserTypeSysModuleMappingCollection_Base usrMapBase = new UserTypeSysModuleMappingCollection_Base(processID);
        //            usrMapBase.DeleteByPrimaryKey(userTypeID, item.ModuleID);
        //            usrMapBase.Dispose();
        //        }

        //        foreach (var data in mappingData)
        //        {
        //            if (data.ModuleID != 0)
        //            {
        //                UserTypeSysModuleMappingRow row = new UserTypeSysModuleMappingRow();
        //                row.ModuleID = data.ModuleID;
        //                row.UserTypeID = data.UserTypeID;

        //                UserTypeSysModuleMappingCollection_Base mapBase = new UserTypeSysModuleMappingCollection_Base(processID);
        //                mapBase.InsertOnlyPlainText(row);
        //                mapBase.Dispose();
        //            }

        //        }
        //        status = true;
        //        dal.DbCommit(processID);
        //    }
        //    catch (Exception ex)
        //    {
        //        dal.DbRollBack(processID);
        //        DalBase.ExceptEngine.ThrowException(processID, ex);
        //    }
        //    return status;
        //}




        //user api
        public ResponseResult ResetAccount(int processID, int userID, string email, int crUserID, string mailToken)
        {
            //bool ret = false;
            //string mailToken = Membership.GeneratePassword(8, 1);
            string name = string.Empty;
            DalBase trns = new DalBase();
            // UserRenewTicketData ret
            ResponseResult ret = new ResponseResult();
            try
            {
                UserRenewTicketRow ticketData = new UserRenewTicketRow
                {
                    Email = email,
                    IssueDate = trns.GetSqlNow(processID)
                };
                ticketData.ExpireDate = ticketData.IssueDate.AddDays(1);
                ticketData.IssueBy = crUserID;
                ticketData.UserID = userID;
                ticketData.Token = Maze.Cypher(mailToken);
                ticketData.RenewType = "resetacc";

                UserRenewTicketCollection_Base ticketBase = new UserRenewTicketCollection_Base(processID);
                ticketBase.InsertOnlyPlainText(ticketData);
                ticketBase.Dispose();

                UserCollection_Base userBase = new UserCollection_Base(processID);
                UserRow userRow = userBase.GetByPrimaryKey(userID);
                userBase.Dispose();

                userRow.IsRenewAccount = true;
                userRow.UpdateBy = ticketData.IssueBy;
                userRow.UpdateDate = ticketData.IssueDate;
                userRow.Password = ticketData.Token;

                userBase = new UserCollection_Base(processID);
                userBase.UpdateOnlyPlainText(userRow);
                userBase.Dispose();

                name = userRow.FirstName + " " + userRow.LastName;

                ret.Data = name;
                ret.Ref1 = mailToken;
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }

            //--sent email
            //string template = System.IO.File.ReadAllText(HostingEnvironment.MapPath("/EmailTemplate/template_reset_verify_pw.html"));
            //template = template.Replace("[[name]]", name).Replace("[[code]]", mailToken).
            //Replace("[[img]]", ConfigurationManager.AppSettings["URL"] + "/Images/GHB_500x260.png");

            //MailCommon mail = new MailCommon();
            //bool sentStatus = mail.Sent(processID, email, "Reset Password by Admin ", template);

            return ret;
        }

        public bool MyChange(int processID, string data, int userID)
        {
            bool ret = false;
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    UserCollection_Base userBase = new UserCollection_Base(processID);
                    UserRow userRow = userBase.GetByPrimaryKey(userID);
                    userBase.Dispose();

                    if (!userRow.Password.Equals(Maze.Cypher(data)))
                    {

                        userRow.UpdateDate = new DalBase().GetSqlNow(processID);
                        userRow.UpdateBy = userRow.UserID;
                        userRow.Password = Maze.Cypher(data);

                        userBase = new UserCollection_Base(processID);
                        userBase.UpdateOnlyPlainText(userRow);
                        userBase.Dispose();

                        ret = true;
                    }
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }

            return ret;
        }

        public int Add(int processID, string userName, string firstName, string lastName, int gender, int createbyUserID,
            string birthDate, string email, string tel, string userType, int userStatus, string verifyToken, string culture)
        {
            int ret = 0;
            DalBase dal = new DalBase();
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
            try
            {
                UserCollection_Base userBase = new UserCollection_Base(processID);
                List<SqlParameter> para = new List<SqlParameter>();
                para.Add(new SqlParameter("@UserName", System.Data.SqlDbType.NVarChar));
                para[0].Value = userName.Trim();
                para.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar));
                para[1].Value = email.Trim();

                UserRow[] user = userBase.GetAsArray(para, "UserName=@UserName OR email=@Email", "");
                userBase.Dispose();
                if (user.Length == 0)
                {
                    //verifyToken = Membership.GeneratePassword(8, 1);
                    UserRow userRow = new UserRow();
                    userRow.UserName = userName;
                    userRow.AliasName = userName;
                    userRow.Password = Maze.Cypher(verifyToken);
                    userRow.FirstName = firstName;
                    userRow.LastName = lastName;
                    userRow.Gender = gender;
                    if (!string.IsNullOrWhiteSpace(birthDate) && Helpers.Utility.DateValidateInput(DateTime.ParseExact(birthDate, "dd/MM/yyyy", cultureInfo)))
                    {
                        userRow.DateOfBirth = DateTime.ParseExact(birthDate, "dd/MM/yyyy", cultureInfo);
                    }
                    //userRow.DateOfBirth = DateTime.ParseExact(birthDate, "yyyy-MM-dd", cultureInfo);
                    userRow.Email = email;
                    userRow.PhoneNumber = tel;
                    userRow.UserTypeID = userType;
                    userRow.UserStatusID = userStatus;
                    userRow.IsVerifyByEmail = false;

                    UserCollection_Base usrBase = new UserCollection_Base(processID);
                    int userID = usrBase.InsertOnlyPlainText(userRow);
                    usrBase.Dispose();

                    //--SET Ticket and Send Verify Email
                    UserRenewTicketRow ticketData = new UserRenewTicketRow();
                    ticketData.Email = email;
                    ticketData.IssueDate = dal.GetSqlNow(processID);
                    ticketData.ExpireDate = ticketData.IssueDate.AddDays(1);
                    ticketData.IssueBy = createbyUserID;
                    ticketData.UserID = userID;
                    ticketData.Token = userRow.Password;
                    ticketData.RenewType = "verify";

                    UserRenewTicketCollection_Base ticketBase = new UserRenewTicketCollection_Base(processID);
                    ticketBase.InsertOnlyPlainText(ticketData);
                    ticketBase.Dispose();


                    ret = userID;

                }

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }
            return ret;
        }


        public void LogUserLogin(int userID, string ip, string deviceType)
        {
            DalBase dal = new DalBase();
            try
            {
                UserLoginHistoryCollection_Base userLoginHistory = new UserLoginHistoryCollection_Base(CSystems.ProcessID);
                userLoginHistory.InsertOnlyPlainText(new UserLoginHistoryRow
                {
                    UserID = userID,
                    DeviceType = deviceType,
                    IP = ip,
                    LoginDate = dal.GetSqlNow(CSystems.ProcessID)
                });
                userLoginHistory.Dispose();

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }

        }

    }
}
