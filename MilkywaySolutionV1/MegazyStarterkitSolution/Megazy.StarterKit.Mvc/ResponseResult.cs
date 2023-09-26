using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Megazy.StarterKit.Mvc
{
    public class ResponseResult
    {
        public ResponseResult()
        {
            Status = false;
            Message = "";
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public int DataID { get; set; }
        public string Ref1 { get; set; }
        public Object Data { get; set; }
        public Exception Exception { get; set; }
    }
}