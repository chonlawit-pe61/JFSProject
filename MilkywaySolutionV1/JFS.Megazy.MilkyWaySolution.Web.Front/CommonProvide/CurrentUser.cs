using System;
using System.Collections.Generic;
using System.Linq;
namespace JFS.Megazy.MilkyWaySolution.Web.Front
{ 
    //[Serializable] ต้องใส่ กรณีกำหนด IIS ส่วน session state : State Server
    [Serializable]
    public class CurrentUser
    {
        public int MemberID { get; set; }
        public string AliasName { get; set; }
        public string Avatar { get; set; }
        public string Provider { get; set; }
        public string MemberTypeID { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsLogin { get; set; }
        public bool IsAdmin { get; set; }
        public int ProvinceID { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Email { get; set; }
        public string CardID { get; set; } // = "3441000106595";
        public int RefToken { get; set; }
        public IEnumerable<int> Module { get; set; }
    }
}