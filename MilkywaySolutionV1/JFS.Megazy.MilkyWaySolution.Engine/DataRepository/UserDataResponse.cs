using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class UserDataResponse : UserData
    {
        public bool Login { get; set; }
        public int RefToken { get; set; }
        public bool IsAdmin { get; set; }
        public int DepartmentID { get; set; }
        public int[] Module { get; set; }
        public string DepartmentName { get; set; }
        public int ProvinceID { get; set; }
    }
    public class UserDataRequest : UserData
    {
        public bool IsAdmin { get; set; }
        public int DepartmentID { get; set; }
        public int RoleID { get; set; }
        public bool IsSetAdmin { get; set; }
        public string IMGbase64 { get; set; }
    }

    public class UserAPIDataRequest
    {
        public string username { get; set; }
        public string token { get; set; }
        public string title { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int gender { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public int depid { get; set; }
        public string cardid { get; set; }
        public int roleid { get; set; }
        public string repath { get; set; } = "https://jf.moj.go.th/";

    }
    public class OTPRequest
    {
        public string token { get; set; }
        public string telephoneno { get; set; }
        public string otp { get; set; }
    }


}
