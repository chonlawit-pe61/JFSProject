using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using Banish.Treasure.Megazy;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Helpers;
using Newtonsoft.Json;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    interface IMemberService
    {
        int Register(MemberData req);
        bool Update();
        MemberDataResponse LoginVerification(string username, string passWordHash, string deviceType);
        bool CheckExist(string userName);
        bool CheckEmailExist(string email);
        View_MembersData GetInfo(int memberID);
    }
    public class MemberService : IMemberService
    {
        public bool CheckEmailExist(string email)
        {
            bool result = false;
            if (!string.IsNullOrWhiteSpace(email))
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter para = new SqlParameter("@email", System.Data.SqlDbType.VarChar) { Value = email };
                sqlParameters.Add(para);
                MemberCollection_Base obj = new MemberCollection_Base(CSystems.ProcessID);
                var row = obj.GetRow(sqlParameters, "Email = @email");
                obj.Dispose();
                if (row == null)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        public bool CheckExist(string userName)
        {
            bool result = false;
            if (!string.IsNullOrWhiteSpace(userName))
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter para = new SqlParameter("@membername", System.Data.SqlDbType.VarChar) { Value = userName };
                sqlParameters.Add(para);
                MemberCollection_Base obj = new MemberCollection_Base(CSystems.ProcessID);
                var row = obj.GetRow(sqlParameters, "MemberName = @membername");
                obj.Dispose();
                if (row == null)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        public View_MembersData GetInfo(int memberID)
        {
            View_MembersCollection_Base obj = new View_MembersCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@MemberID", System.Data.SqlDbType.Int) { Value = memberID };
            parameter.Add(sqlpara);
            string whereSql = "[MemberID] = @MemberID";
            var row = obj.GetRow(parameter, whereSql);
            obj.Dispose();
            string output = JsonConvert.SerializeObject(row);
            return JsonConvert.DeserializeObject<View_MembersData>(output);
        }

        public int Register(MemberData req)
        {
            int id = 0;
            MemberCollection_Base obj = new MemberCollection_Base(CSystems.ProcessID);
            var row = obj.GetByPrimaryKey(req.MemberID);
            obj.Dispose();
            if (row != null)
            {

            }
            else
            {
                obj = new MemberCollection_Base(CSystems.ProcessID);
                id = obj.InsertOnlyPlainText(new MemberRow
                {
                    MemberName = req.MemberName,
                    OrgName = string.IsNullOrEmpty(req.OrgName) ? null : req.OrgName,
                    Password = Maze.Cypher(req.Password),
                    FirstName = string.IsNullOrEmpty(req.FirstName) ? null : req.FirstName,
                    LastName = string.IsNullOrEmpty(req.LastName) ? null : req.LastName,
                    RegistDate = DalBase.SqlNowIncludePd(CSystems.ProcessID),
                    IsVerifyByEmail = false,
                    MemberStatusID = 1,
                    Email = req.Email,
                    PhoneNumber = req.PhoneNumber,
                    MemberTypeID = req.MemberTypeID,
                    UpdateDate = DalBase.SqlNowIncludePd(CSystems.ProcessID),
                });
                obj.Dispose();
            }
            return id;
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public MemberDataResponse LoginVerification(string username, string passWordHash, string deviceType)
        {


            MemberDataResponse result = new MemberDataResponse();
            try
            {

                passWordHash = Maze.Cypher(passWordHash);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter para = new SqlParameter("@membername", System.Data.SqlDbType.VarChar) { Value = username };
                sqlParameters.Add(para);
                para = new SqlParameter("@email", System.Data.SqlDbType.VarChar) { Value = username };
                sqlParameters.Add(para);
                para = new SqlParameter("@password", System.Data.SqlDbType.VarChar) { Value = passWordHash };
                sqlParameters.Add(para);
                MemberCollection_Base obj = new MemberCollection_Base(CSystems.ProcessID);
                var row = obj.GetRow(sqlParameters, "(MemberName = @membername or Email = @email) AND Password = @password AND MemberStatusID = 1");
                obj.Dispose();

                if (row != null)
                {
                    if (row.Email == username)
                    {
                        if (row.IsVerifyByEmail)
                        {
                            if (row.MemberTypeID == "1")
                            {
                                result.FirstName = row.FirstName;
                                result.LastName = row.LastName;
                                result.Gender = row.Gender;
                                result.DateOfBirthStr = Utility.ConvertDateToThaiLongDate(row.DateOfBirth);
                            }
                            else
                            {
                                result.OrgName = row.OrgName;
                            }
                            result.PhoneNumber = row.PhoneNumber;
                            result.Email = row.Email;
                            result.MemberStatusID = row.MemberStatusID;
                            result.RegistDateStr = Utility.ConvertDateToThaiLongDate(row.DateOfBirth);
                            result.IsLoginSuccess = true;
                            result.SessionID = Guid.NewGuid().ToString();
                            result.MemberTypeID = row.MemberTypeID;
                            result.MemberID = row.MemberID;


                            row.SessionID = result.SessionID;
                            row.DeviceType = deviceType;
                            row.LastLoginDate = DalBase.SqlNowIncludePd(CSystems.ProcessID);
                            obj = new MemberCollection_Base(CSystems.ProcessID);
                            obj.UpdateOnlyPlainText(row);
                            obj.Dispose();
                        }
                        else
                        {
                            result.Remark = "อีเมลนี้ยังไม่ได้รับการยืนยัน";
                            result.TypeOffailed = 1;
                        }
                    }
                    else
                    {
                        if (row.MemberTypeID == "1")
                        {
                            result.FirstName = row.FirstName;
                            result.LastName = row.LastName;
                            result.Gender = row.Gender;
                            result.DateOfBirthStr = Utility.ConvertDateToThaiLongDate(row.DateOfBirth);
                        }
                        else
                        {
                            result.OrgName = row.OrgName;
                        }
                        result.PhoneNumber = row.PhoneNumber;
                        result.Email = row.Email;
                        result.MemberStatusID = row.MemberStatusID;
                        result.RegistDateStr = Utility.ConvertDateToThaiLongDate(row.DateOfBirth);                       
                        result.MemberTypeID = row.MemberTypeID;
                        result.SessionID = Guid.NewGuid().ToString();
                        result.MemberID = row.MemberID;

                        if (row.IsVerifyPhone)//09/08/2565:edit by Piak
                        {
                            result.IsLoginSuccess = true;

                            row.SessionID = result.SessionID;
                            row.DeviceType = deviceType;
                            row.LastLoginDate = DalBase.SqlNowIncludePd(CSystems.ProcessID);
                            obj = new MemberCollection_Base(CSystems.ProcessID);
                            obj.UpdateOnlyPlainText(row);
                            obj.Dispose();
                        }
                        else
                        {
                            result.IsLoginSuccess = false;
                            result.Remark = "เบอร์โทรศัพท์นี้ยังไม่ได้รับการยืนยัน";
                            result.TypeOffailed = 3;
                        }
                    }
                }
                else
                {
                    result.TypeOffailed = 2;
                    result.Remark = "ไม่พบบัญชีผู้ใช้ โปรดตรวสอบชื่อผู้ใช้งาน/อีเมลและรหัสผ่าน";
                }
            }
            catch (Exception ex)
            {

                DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, ex);
            }
            return result;
        }

        public (bool,string) EditMembername(int memberID , string Membername)
        {
            bool result = false;
            string message = "";
            if (memberID > 0 && !string.IsNullOrEmpty(Membername))
            {
                MemberCollection_Base member = new MemberCollection_Base(CSystems.ProcessID);
                var checkusername = member.GetRow(new List<SqlParameter>(), $"MemberName = '{Membername}' AND MemberStatusID = 1");
                member.Dispose();
                if (checkusername != null)
                {
                    message = "ชื่อผู้ใช้งานนี้ได้ถูกใช้ไปแล้ว";
                }
                else
                {
                    member = new MemberCollection_Base(CSystems.ProcessID);
                    var memberrow = member.GetByPrimaryKey(memberID);
                    if (memberrow != null)
                    {
                        memberrow.MemberName = Membername;
                        member.UpdateOnlyPlainText(memberrow);
                        member.Dispose();
                        result = true;
                    }
                    else
                    {
                        message = "ไม่พบผู้ใช้งาน";
                    }
                }
            }
            else 
            {
                message = "ข้อมูลไม่ครบถ้วน กรุณาลองใหม่อีกครั้ง";
            }
            return (result,message);
        }
        public (bool, string) ChangePassword(int memberID, string Password)
        {
            bool result = false;
            string message = "";
            if (memberID > 0 && !string.IsNullOrEmpty(Password))
            {
                MemberCollection_Base member = new MemberCollection_Base(CSystems.ProcessID);
                var memberrow = member.GetByPrimaryKey(memberID);
                if (memberrow != null)
                {
                    memberrow.Password = Maze.Cypher(Password);
                    member.UpdateOnlyPlainText(memberrow);
                    member.Dispose();
                    result = true;
                }
                else
                {
                    message = "ไม่พบผู้ใช้งาน";
                }
            }
            else
            {
                message = "ข้อมูลไม่ครบถ้วน กรุณาลองใหม่อีกครั้ง";
            }
            return (result, message);
        }
        public (bool, string) SaveMemberData(MemberData data)
        {
            bool result = false;
            string message = "";
            if (data.MemberID > 0)
            {
                DalBase dal = new DalBase();
                MemberCollection_Base member = new MemberCollection_Base(CSystems.ProcessID);
                var memberrow = member.GetByPrimaryKey(data.MemberID);
                if (memberrow != null)
                {
                    memberrow.FirstName = data.FirstName;
                    memberrow.LastName = data.LastName;
                    memberrow.Email = data.Email;
                    memberrow.MemberStatusID = data.MemberStatusID;
                    memberrow.PhoneNumber = data.PhoneNumber.Replace("-","");
                    memberrow.UpdateDate = dal.GetSqlNow(CSystems.ProcessID);
                    member.UpdateOnlyPlainText(memberrow);
                    member.Dispose();
                    result = true;
                }
                else
                {
                    message = "ไม่พบผู้ใช้งาน";
                }
            }
            else
            {
                message = "ข้อมูลไม่ครบถ้วน กรุณาลองใหม่อีกครั้ง";
            }
            return (result, message);
        }
    }
}
