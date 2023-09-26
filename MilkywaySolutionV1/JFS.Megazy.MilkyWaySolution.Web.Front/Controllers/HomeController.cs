using JFS.Megazy.MilkyWaySolution.Engine;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Services;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JFS.Megazy.MilkyWaySolution.Web.Front.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {

            return Redirect("/login");
        }
        [Route("login")]
        public ActionResult Login()
        {
#if DEBUG
            ViewBag.Username = "Username1234";
            ViewBag.Pwd = "1234";
#endif
            return View();
        }
        [Route("signup")]
        public ActionResult Signup()
        {
            return View();
        }
        //ให้ลิงค์ไปโหลดโปรแกรม กองทุน
        //  public ActionResult Download()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}
        [Route("logout")]
        public ActionResult Logout()
        {
            SiteSession.ResetUser();
            return Redirect("login");
        }
        [Route("tracking/{caseno?}")]
        public ActionResult Tracking(string caseno)
        {
            SetMetaHtml(new ComponentHead{Title = "ติดตามความช่วยเหลือ",MetaDescription = "ติดตามช่วยเหลือ กองทุนยุติธรรม"});

            return View();
        }
        [WebViewAuthorizeFilter]
        [Route("searchingcase/{caseno?}")]
        [Route("searchingcliam/{caseno?}")]
        public ActionResult SearchingCase(string caseno)
        {
            ViewBag.IsSearchCase = false;
            if (Request.Url.AbsolutePath.Contains("searchingcase"))
            {
                ViewBag.IsSearchCase = true;
                SetMetaHtml(new ComponentHead { Title = "ค้นหาสำนวน" });
            }
            else {

                SetMetaHtml(new ComponentHead { Title = "ค้นหารายการขอสิทธิ์ยืนยันรายงานผลโครงการที่ไม่ได้ยื่นออนไลน์" });

            }
            return View();
        }
        [WebViewAuthorizeFilter]
        [Route("getcase")]
        public JsonResult GetCase(string caseNo, string phoneNumber)
        {
            ResponseResult res = new ResponseResult();
            CurrentUser currentUser = SiteSession.GetCurrentUser();
            try
            {
                if (!string.IsNullOrWhiteSpace(caseNo))
                {
                    List<SqlParameter> parameter = new List<SqlParameter>();
                    SqlParameter sqlpara = new SqlParameter("@JFCaseNo", System.Data.SqlDbType.VarChar) { Value = caseNo };
                    parameter.Add(sqlpara);

                    View_ApplicationCollection_Base obj = new View_ApplicationCollection_Base(CSystems.ProcessID);
                    var row = obj.GetRow(parameter, "JFCaseNo = @JFCaseNo");
                    obj.Dispose();
                    if (row != null)
                    {
                        CaseApplicationMemberMappingCollection_Base mapping = new CaseApplicationMemberMappingCollection_Base(CSystems.ProcessID);
                        var rowmapping = mapping.GetByPrimaryKey(row.CaseID, currentUser.MemberID);
                        mapping.Dispose();
                        if (rowmapping != null)
                        {
                            res.DataID = 3;
                            res.Data = row;
                            res.Status = true;
                        }
                        else
                        {
                            CaseClaimRequestCollection_Base claimreq = new CaseClaimRequestCollection_Base(CSystems.ProcessID);
                            var claimrow = claimreq.GetByPrimaryKey(row.CaseID, currentUser.MemberID);
                            claimreq.Dispose();
                            if (claimrow != null)
                            {
                                if (claimrow.ClaimStatusID == 3)
                                {
                                    res.DataID = 4;//รอตรวจสอบ
                                    res.Data = row;
                                    res.Status = true;
                                }
                                else if (claimrow.ClaimStatusID == 2)
                                {
                                    res.DataID = 3;//อ้างสิทธิ์แล้ว
                                    res.Data = row;
                                    res.Status = true;
                                }
                                res = GetResult(row, phoneNumber);
                            }
                            else
                            {
                                res = GetResult(row, phoneNumber);
                            }

                        }
                    }
                    else
                    {
                        res.Message = "ไม่พบรายการที่ค้นหา";
                    }
                }
                else
                {
                    res.Message = "กรุณากรอกข้อมูลเพื่อค้นหา";
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return Json(res, JsonRequestBehavior.DenyGet);
        }
        private ResponseResult GetResult(View_ApplicationRow row,string phoneNumber)
        {
            ResponseResult res = new ResponseResult();
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@caseid", System.Data.SqlDbType.VarChar) { Value = row.CaseID };
            parameter.Add(sqlpara);
            ProjectAddressCollection_Base pjaddress = new ProjectAddressCollection_Base(CSystems.ProcessID);
            var pjrow = pjaddress.GetRow(parameter, "[CaseID] = @caseid");
            pjaddress.Dispose();
            if (pjrow != null)
            {
                res.Data = row;
                res.Status = true;
                if (pjrow.TelephoneNo == phoneNumber)
                {
                    res.DataID = 1;//เบอร์โทรตรงกับที่ลงในสำนวน
                }
                else
                {
                    res.DataID = 2;//เบอร์โทรไม่ตรงกับที่ลงในสำนวน
                }

            }
            else
            {
                res.Message = "ไม่พบรายการที่ค้นหา";
                res.Status = false;
            }
            return res;
        }
        [WebViewAuthorizeFilter]
        [Route("claimcase")]
        public JsonResult ClaimCase(int caseID, int applicantID , string type)
        {
            ResponseResult res = new ResponseResult();
            var currentUser = SiteSession.GetCurrentUser();
            try
            {
                if (type == "C")
                {
                    CaseApplicationMemberMappingCollection_Base mapping = new CaseApplicationMemberMappingCollection_Base(CSystems.ProcessID);
                    mapping.DeleteByPrimaryKey(caseID, currentUser.MemberID);
                    mapping.InsertOnlyPlainText(new CaseApplicationMemberMappingRow
                    {
                        MemberID = currentUser.MemberID,
                        CaseID = caseID,
                        ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID)
                    });
                    mapping.Dispose();
                }
                else
                {
                    CaseClaimRequestCollection_Base ClaimReq = new CaseClaimRequestCollection_Base(CSystems.ProcessID);
                    ClaimReq.DeleteByPrimaryKey(caseID, currentUser.MemberID);
                    ClaimReq.InsertOnlyPlainText(new CaseClaimRequestRow
                    {
                        MemberID = currentUser.MemberID,
                        CaseID = caseID,
                        ClaimStatusID = 3,
                        RequestDate = DalBase.SqlNowIncludePd(CSystems.ProcessID),
                        ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID)
                    });
                    ClaimReq.Dispose();

                }


                res.Status = true;
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }

            return Json(res, JsonRequestBehavior.DenyGet);
        }
        [Route("api/gettrackingresult")]
        public JsonResult GetTrackingResult(string id)
        {
            ResponseResult res = new ResponseResult();
            try
            {


                View_ApplicationCollection_Base obj = new View_ApplicationCollection_Base(CSystems.ProcessID);
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlpara = new SqlParameter("@JFCaseNo", System.Data.SqlDbType.VarChar) { Value = id };
                parameter.Add(sqlpara);
                // sqlpara = new SqlParameter("@StatusID", System.Data.SqlDbType.VarChar) { Value = id };
                //parameter.Add(sqlpara);
                string whereSql = "[JFCaseNo] = @JFCaseNo AND StatusID <> 6";
               // string orderbySql = "Seq Asc";
                var row = obj.GetRow(parameter, whereSql);
                obj.Dispose();
                if (row != null)
                {
                    var rows = Engine.Services.TrackingService.GetCaseHistoryForRequestor(row.CaseID, row.ApplicantID,row.DepartmentID);
                    if (rows != null)
                    {
                        res.Data = rows;
                    }

                    res.Status = true;
                }
                else {

                    res.Message = "ไม่พบข้อมูล";
                }
               

                //int number = 0;
                //if (!string.IsNullOrEmpty(page))
                //{
                //    bool result = int.TryParse(page, out number);
                //}
                //StringBuilder query = new StringBuilder();
                //List<SqlParameter> listParameter = new List<SqlParameter>();
                //string sql = ConvertCompenentFiltersToWheresql(filters, ref listParameter);
                //int startRowIndex = (CSystems.ItemPerPage * (number - 1));
                //if (startRowIndex < 0)
                //    startRowIndex = 0;
                //res.Data = GetPages(startRowIndex, listParameter, sql);
                //res.Status = true;
            }
            catch (Exception ex)
            {
            //  DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, ex);
            }
            return Json(new { Result = res }, JsonRequestBehavior.DenyGet);
        }
        [Route("contact")]
        public ActionResult Contact()
        {
            SetMetaHtml(new ComponentHead { Title = "ติดต่อ กองทุนยุติธรรม", MetaDescription = "ติดต่อ กองทุนยุติธรรม" });
            return View();
        }

        [Route("register")]
        [HttpPost]
        public JsonResult Register(MemberData data)
        {
            ResponseResult res = new ResponseResult();
            try
            {
                MemberService servics = new MemberService();
                bool chkusername = servics.CheckExist(data.MemberName);
                bool chkemail = servics.CheckEmailExist(data.Email);
                if (chkusername && chkemail)
                {
                    res.DataID = servics.Register(data);
                    res.Status = true;
                }
                else
                {
                    if (!chkusername && chkemail)
                    {
                        res.DataID = 1;
                        res.Message = "Username ถูกใช้งานแล้ว";
                    }
                    else if(chkusername && !chkemail)
                    {
                        res.DataID = 2;
                        res.Message = "Email ถูกใช้งานแล้ว";
                    }
                    else
                    {
                        res.DataID = 3;
                        res.Message = "Username และ Email ถูกใช้งานแล้ว";
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, ex);
            }
            return Json(res, JsonRequestBehavior.DenyGet);
        }

        [Route("loginverify")]
        [HttpPost]
        public JsonResult LoginVerify(string username ,string password)
        {
            ResponseResult res = new ResponseResult();
            try
            {
                MemberService servics = new MemberService();
                if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                {
                    string deviceType = HttpContext.Request.Browser.Browser;
                    var data = servics.LoginVerification(username, password, deviceType);
                    if (data != null)
                    {
                        if (data.IsLoginSuccess)
                        {
                            res.Data = data;
                            res.Status = data.IsLoginSuccess;
                            CurrentUser crr = new CurrentUser();
                            if(data.MemberTypeID == "1")
                            {
                                crr.AliasName = data.FirstName + " " + data.LastName;
                            }
                            else
                            {
                                crr.AliasName = data.OrgName;
                            }
                            crr.MemberTypeID = data.MemberTypeID;
                            crr.MemberID = data.MemberID;
                            crr.IsLogin = data.IsLoginSuccess;
                            crr.PhoneNumber = data.PhoneNumber;
                            crr.Email = data.Email;
                            SiteSession.SetUser(crr);
                            SiteSession.SetClientAuthen();

                        }
                        else
                        {
                            //สร้าง Session แต่กำหนด IsLogin=false
                            CurrentUser crr = new CurrentUser();
                            if (data.MemberTypeID == "1")
                            {
                                crr.AliasName = data.FirstName + " " + data.LastName;
                            }
                            else
                            {
                                crr.AliasName = data.OrgName;
                            }
                            crr.MemberTypeID = data.MemberTypeID;
                            crr.MemberID = data.MemberID;
                            crr.IsLogin = data.IsLoginSuccess;
                            crr.PhoneNumber = data.PhoneNumber;
                            crr.Email = data.Email;
                            SiteSession.SetUser(crr);
                            SiteSession.SetClientAuthen();
                            res.Status = data.IsLoginSuccess;
                            res.Message = data.Remark;
                            res.DataID = data.TypeOffailed;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, ex);
            }
            return Json(res, JsonRequestBehavior.DenyGet);
        } 

        [Route("verifymobile")]
        public ActionResult VerifyMobile()
        {

            var currentUser = SiteSession.GetCurrentUser();
            if (!currentUser.IsLogin && currentUser.PhoneNumber != null)
            {
                return View();
            }
            else
            {

                return Redirect("/");
            }

        }  
        /// <summary>
        /// ขอ OTP
        /// </summary>
        /// <returns></returns>
        [Route("getotp")]
        [HttpPost]
        public async Task<JsonResult> GetOTPAsync()
        {
            ResponseResult res = new ResponseResult();
            try
            {
               var cr =   SiteSession.GetCurrentUser();
                _ = await SMSService.SendOTPVerifyMobileAsync(cr.PhoneNumber, cr.MemberID).ConfigureAwait(true);
                res.Status = true;
            }
            catch (Exception ex)
            {
                //throw ex;
                DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, ex);
            }
            return Json(res, JsonRequestBehavior.DenyGet);
        } 
        /// <summary>
        /// ตรวจสอบ OTP
        /// </summary>
        /// <returns></returns>
        [Route("verifyotp")]
        [HttpPost]
        public JsonResult VerifyOTP(string otp,string verificationType)
        {
            ResponseResult res = new ResponseResult();
            try
            {
               var cr =   SiteSession.GetCurrentUser();
                MemberRenewCollection_Base obj = new MemberRenewCollection_Base(CSystems.ProcessID);
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlpara = new SqlParameter("@MemberID", System.Data.SqlDbType.Int) { Value = cr.MemberID };
                parameter.Add(sqlpara);
                sqlpara = new SqlParameter("@Token", System.Data.SqlDbType.VarChar) { Value = otp };
                parameter.Add(sqlpara);
                sqlpara = new SqlParameter("@VerificationType", System.Data.SqlDbType.VarChar) { Value = verificationType };
                parameter.Add(sqlpara);
                string whereSql = "[Token] = @Token AND [MemberID] = @MemberID AND [VerificationType] = @VerificationType";
                string orderbySql = "ExpireDate DESC";
                var row = obj.GetTopAsArray(1,parameter, whereSql, orderbySql);
                obj.Dispose();
                if (row != null && row.Length != 0)
                {
                    DateTime startTime = DateTime.Now;
                    DateTime endTime = row[0].ExpireDate;
                    TimeSpan span = endTime.Subtract(startTime);
                    if (span.Minutes <= 5)
                    {
                        MemberService servics = new MemberService();
                        string deviceType = HttpContext.Request.Browser.Browser;
                        MemberCollection_Base objMember = new MemberCollection_Base(CSystems.ProcessID);
                        var rowMember = objMember.GetByPrimaryKey(cr.MemberID);
                        rowMember.IsVerifyPhone = true;
                        objMember.Update(rowMember);
                        objMember.Dispose();
                        //กำหนดให้ IsLogin=true เพื่อให้เข้าระบบได้
                        cr.IsLogin = true;
                        SiteSession.SetUser(cr);
                        res.Status = true;
                    }
                    else
                    {
                        res.Status = false;
                        res.Message = "รหัส OTP หมดอายุ";
                    }
                }
                else
                {
                    res.Status = false;
                    res.Message = "รหัสไม่ถูกต้อง";
                }
               
            }
            catch (Exception ex)
            {
                //throw ex;
                DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, ex);
            }
            return Json(res, JsonRequestBehavior.DenyGet);
        } 

    }
}