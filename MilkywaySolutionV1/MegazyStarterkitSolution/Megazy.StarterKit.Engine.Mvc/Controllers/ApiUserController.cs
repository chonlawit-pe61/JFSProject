using Microsoft.Web.Http;
using System;
using System.Web.Http;

namespace Megazy.StarterKit.Engine.Mvc.Controllers
{
    /// <summary>
    /// Important: เรียกใช้งานโดยใช้ TOKEN
    /// </summary>
    [RoutePrefix("api")]
    [ApiVersion("1.0")]
    public class ApiUserController : ApiController
    {
        //ใช้สำหรับ API เรียกเข้ามาทำนั้น 
        [Route("v{version:apiVersion}/msc/signin")]
        [APIAuthenFilter]
        [HttpPost]
        public ResponseResult MSCSignin()
        {
            ResponseResult res = new ResponseResult();
            try
            {
                //Coding                
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return res;
        }

    }
}