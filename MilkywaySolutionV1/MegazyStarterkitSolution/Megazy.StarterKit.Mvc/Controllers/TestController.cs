using Megazy.StarterKit.Mvc.Transaction.Dal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Megazy.StarterKit.Mvc.Controllers
{
    public class TestController : BaseController
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Department()
        {
            UserCollection_Base obj = new UserCollection_Base(CSystems.ProcessID);
            var row = obj.GetAll();
            obj.Dispose();

            return View(row);
        }

        #region Address
        public ActionResult UserList()
        {
            UserCollection_Base obj = new UserCollection_Base(CSystems.ProcessID);
            var row = obj.GetAll();
            obj.Dispose();
            return View(row);
        }
        public ActionResult AddUsers()
        {
            return View();
        } 
        public ActionResult EditUsers(int userID)
        {
            return View();
        }
        /// <summary>
        /// รายการผู้ใช้งาน
        /// </summary>
        /// <param name="userID">รหัสผู้ใช้งาน เช่น userID=9</param>
        /// <returns></returns>
        public ActionResult UserDetail(int? userID)
        {
            if (userID != null)
            {
                UserCollection_Base obj = new UserCollection_Base(CSystems.ProcessID);
                var row = obj.GetByPrimaryKey((int)userID);
                obj.Dispose();
                return View(row);
            }
            else
            {
                return RedirectToAction("UserList");
            }
            
        }
        public JsonResult SaveUsers()
        {
            return Json(new { });
        }
        /// <summary>
        /// ลบข้อมูลผู้ใช้งานโดยส่ง userID
        /// </summary>
        /// <param name="id">userID</param>
        /// <returns>ResponseResult</returns>
        [HttpPost]
        public JsonResult DeleteUserbyID(int id)
        {
            ResponseResult res = new ResponseResult();
            DalBase dal = new DalBase();
            try
            {
                dal.DbBeginTransaction(CSystems.ProcessID);

                UserCollection_Base user = new UserCollection_Base(CSystems.ProcessID);
                user.DeleteByPrimaryKey(id);
                user.Dispose();
                res.Status = true;

                dal.DbCommit(CSystems.ProcessID);

            }
            catch (Exception ex)
            {
                dal.DbRollBack(CSystems.ProcessID);
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return Json(res,JsonRequestBehavior.DenyGet);
        }
        #endregion

    }
}