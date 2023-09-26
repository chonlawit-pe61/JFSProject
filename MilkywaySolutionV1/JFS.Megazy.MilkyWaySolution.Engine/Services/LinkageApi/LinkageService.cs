using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.LinkageApi
{
   public static class LinkageService
    {
        /// <summary>
        /// ตรวจสอบข้อมูลผู้ใช้งานจากฐานข้อมูล
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static LinkageAccessTokenData GetLinkageUser(int userID)
        {
            LinkageAccessTokenData uData = null;
            LinkageAccessTokenCollection_Base obj = new LinkageAccessTokenCollection_Base(CSystems.ProcessID);
            var uRow = obj.GetByPrimaryKey(userID);
            obj.Dispose();
            if (uRow != null)
            {
                uData = new LinkageAccessTokenData
                {
                    CID = uRow.CID,
                    UserID = uRow.UserID,
                    TokenKey = uRow.TokenKey,
                    PID = uRow.PID
                };
            }
            return uData;
        
        }
        /// <summary>
        /// บันทึกหรือแก้ไขข้อมูล Linkage Token key
        /// </summary>
        /// <param name="req">LinkageAccessTokenData</param>
        /// <returns></returns>
        public static bool InsertOrUpdateLinkageUser(LinkageAccessTokenData req)
        {
            bool Ispass = false;
            DalBase dal = new DalBase();
            try
            {
                dal.DbBeginTransaction(CSystems.ProcessID);

                LinkageAccessTokenCollection_Base obj = new LinkageAccessTokenCollection_Base(CSystems.ProcessID);
                var uRow = obj.GetByPrimaryKey(req.UserID);
                obj.Dispose();
                obj = new LinkageAccessTokenCollection_Base(CSystems.ProcessID);
                if (uRow != null)
                {
                    uRow.CID = req.CID;
                    uRow.UserID = req.UserID;
                    uRow.TokenKey = req.TokenKey;
                    uRow.XKey = req.XKey;
                    //MatchKey = req.MatchKey,
                    uRow.EnvelopGMXs = req.EnvelopGMXs;
                    uRow.PID = req.PID;
                    uRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                    obj.Update(uRow);
                }
                else
                {
                    uRow = new LinkageAccessTokenRow
                    {
                        CID = req.CID,
                        UserID = req.UserID,
                        TokenKey = req.TokenKey,
                        MatchKey = req.MatchKey,
                        XKey = req.XKey,
                        EnvelopGMXs = req.EnvelopGMXs,
                        PID = req.PID,
                        DateCreated = dal.GetSqlNow(CSystems.ProcessID),
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                    };
                    obj.Insert(uRow);
                }
                obj.Dispose();
                Ispass = true;
                dal.DbCommit(CSystems.ProcessID);

            }
            catch (Exception ex)
            {
                dal.DbRollBack(CSystems.ProcessID);
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }           
            return Ispass;

        }
    }
}
