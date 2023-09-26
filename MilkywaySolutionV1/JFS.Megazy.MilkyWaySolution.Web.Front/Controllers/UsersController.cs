using JFS.Megazy.MilkyWaySolution.Engine;
using JFS.Megazy.MilkyWaySolution.Engine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JFS.Megazy.MilkyWaySolution.Web.Front.Controllers
{
    [RoutePrefix("usr")]
    public class UsersController : BaseController
    {
        // GET: usr/
        //[WebViewAuthorizeFilter]
        [Route("")]
        [WebViewAuthorizeFilter]
        public ActionResult Index()
        {
            SetMetaHtml(new ComponentHead { Title = "จัดการบัญชี" });
            CurrentUser currentUser = SiteSession.GetCurrentUser();
            //Coding here.
            // IMemberService service1 = new MemberService();
            MemberService service = new MemberService();
            //UserID = MemberID หรือสามารถแก้ไขชื่อให้ตรงกันได้
            return View(service.GetInfo(currentUser.MemberID));
        }
        // GET: usr/changpwd
        [WebViewAuthorizeFilter]
        [Route("changepwd")]
        public ActionResult ChangePwd()
        {
            SetMetaHtml(new ComponentHead { Title = "เปลี่ยนรหัส่าน" });
            CurrentUser currentUser = SiteSession.GetCurrentUser();
            //Coding here.
            // IMemberService service1 = new MemberService();
            //MemberService service = new MemberService();
            //service.GetInfo(currentUser.MemberID);//UserID = MemberID หรือสามารถแก้ไขชื่อให้ตรงกันได้
            
            return View();
        }
        // POST: /usr/changepassword
        /// <summary>
        /// เปลี่ยนรหัสผ่าน  
        /// </summary>
        /// <param name="Password"></param>
        /// <returns></returns>
        [WebViewAuthorizeFilter]
        [Route("changepassword")]
        public JsonResult ChangePassword(string Password)
        {           
            CurrentUser currentUser = SiteSession.GetCurrentUser();
            ResponseResult res = new ResponseResult();
            MemberService service = new MemberService();
            (res.Status, res.Message) = service.ChangePassword(currentUser.MemberID, Password);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}