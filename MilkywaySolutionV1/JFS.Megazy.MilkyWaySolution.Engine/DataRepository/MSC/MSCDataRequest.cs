using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.MSC
{
    public class MSCDataRequest
    {

        public string ReferenceMSCID { get; set; }
        public string ReferenceMSCCode { get; set; }
        public string TelephoneNo { get; set; }
        public string Subject { get; set; }
        public string Gender { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProvinceID { get; set; }
        public string ProvinceName { get; set; }
        public string PostCode { get; set; }
        public string CitizenID { get; set; }
        /// <summary>
        /// เป็นผู้พิการหรือไม่ (ไม่ได้ส่งมาแล้ว)
        /// </summary>
        public string Defactive { get; set; }
        public string CreateDate { get; set; }
        public string Remark { get; set; }
        // / <summary>
        /// รหัสจังหวัดเจ้าของเรื่อง (สยจ.)
        /// </summary>
        /// 
        public string DivnID { get; set; }
        /// <summary>
        /// เป็นของส่วนกลางหรือไม่ ทาง MSC ใช้งานเท่านั้น
        /// </summary>
        public string Central { get; set; }
        public string Race { get; set; }
        public string Religion { get; set; }
        public string Natinality { get; set; }
        public string Education { get; set; }
        public string DateOfBirth { get; set; }
        /// <summary>
        /// ข้อมูลส่วนเพิ่มเติมอื่นๆ ให้เพิ่มมในรูปแบบ Json format
        /// ข้อเพิ่มเติมในงวดงานปรับปรุงระบบ
        /// </summary>
        public string JsonAdditional { get; set; }
        /// <summary>
        /// ไฟล์แนบส่งมาแบบ array base 64
        /// </summary>
        public Attach[] Attach { get; set; }


    }

    [Serializable]
    public class MSCSUsername
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

    }

    public class Attach
    {
        [JsonProperty("file_type")]
        public string FileType { get; set; }

        [JsonProperty("file_name")]
        public string FileName { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }
    }


    [Serializable]
    public class MSCSstatusCase : MSCSUsername
    {
        
        [JsonProperty("pid")]

        public string Pid { get; set; }

        [JsonProperty("refId")]

        public string RefId { get; set; }

        [JsonProperty("refNo")]
        public string RefNo { get; set; }

        [JsonProperty("getInfo")]
        public string GetInfo { get; set; }

        [JsonProperty("getStatus")]
        public string GetStatus { get; set; } = "process";

        [JsonProperty("Central")]
        public string Central { get; set; } = "0";
        //[JsonProperty("divnId")]
        //public string OfficeID { get; set; }
    }




    [Serializable]
    public class MSCReportStatusCase : MSCSUsername
    {
        
        [JsonProperty("pid")]

        public string Pid { get; set; }

        [JsonProperty("reptStatus")] 

        public string ReptStatus { get; set; } = "report";

        [JsonProperty("reptPlainText")]
        public string ReptPlainText { get; set; }

        [JsonProperty("Central")]
        public string Central { get; set; } = "0";
        [JsonProperty("divnId")]
        public string OfficeID { get; set; }

    }
    [Serializable]
    public class MSCProvince : MSCSUsername
    {
        public string provName { get; set; }
    }








    }
