using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.MSC
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    //สำหรับออกเลข MSC
    //URL: https://api.moj.go.th/msc/wsCreate.php/CreatePet
    //Description : Service ให้บริการสำหรับออกเลข MSC
    //Technology: RESTful Web Service
    //Method: POST
    //Content Type: JSON
    public class PETDataRequest : MSCSUsername
    {
        //public string username { get; set; }
        //public string password { get; set; }
        /// <summary>
        /// รหัสอ้างอิงของหน่วยงานที่ส่งเรื่อง
        /// </summary>
        public string refId { get; set; }
        /// <summary>
        /// เลขที่อ้างอิงของหน่วยงานที่ส่งเรื่อง
        /// </summary>
        public string refNo { get; set; }
        /// <summary>
        /// วันที่ผุ้ร้องยื่นเรื่อง YYYY-MM-DDo
        /// </summary>
        public string submitDate { get; set; }
        /// <summary>
        /// สถานะการดำเนินการผ่าน สยจ.  1=ไม่ผ่าน , 0= ผ่าน สยจ.
        /// </summary>
        public int ownFlag { get; set; } = 0;
        /// <summary>
        /// รหัสหน่วยงานเจ้าของเรื่อง อ้างอิงตาราง Department: DepartmentCode 5=สำนักงานกองทุนยุติธรรม
        /// </summary>
        public string divnIdOwn { get; set; } = "5";
        /// <summary>
        /// รหัส สยจ. ที่ดำเนินการ
        /// </summary>
        public string divnIdProv { get; set; }
        /// <summary>
        /// ช่องทางการติดต่อขอรบบริการ (สป.ยธ. จะเป็นผู้แจ้ง) wayTypeId= 21 ระบบ jfpetition.moj.go.th
        /// </summary>
        public int wayTypeId { get; set; } = 21;
        /// <summary>
        /// ประเภทเรื่อง (สป.ยธ.) 28:การขอกองทุนยุติธรรม
        /// </summary>
        public int petTypeId { get; set; } = 28;
        /// <summary>
        /// ชื่อเรื่อง
        /// </summary>
        public string petName { get; set; }
        public string petDetail { get; set; }
        /// <summary>
        /// process = ดำเนินการ, finished= เสร็จสิ้น
        /// </summary>
        public string petStatus { get; set; } = "process";
        /// <summary>
        /// วันที่เกิดเหตุ
        /// </summary>
        public string petStartDate { get; set; }
        /// <summary>
        /// วันที่สิ้นสุด
        /// </summary>
        public string petEndDate { get; set; }
        /// <summary>
        /// ช่วงเวลาที่เกิดเหตุ
        /// </summary>
        public string petAboutTime { get; set; }
        /// <summary>
        /// สถานที่เกิดเหตุ
        /// </summary>
        public string petPlace { get; set; }
        /// <summary>
        /// รหัสจังหวัดที่เกิดเหตุ 0=ไม่ระบุ Service provinceList
        /// </summary>
        public string petProv { get; set; } = "0";
        /// <summary>
        /// รหัสอำเภอที่เกิดเหตุ 0 = ไม่ระบุ Service provinceList
        /// </summary>
        public string petAmp { get; set; } = "0";
        /// <summary>
        /// รหัสตำบลที่เกิดเหตุ 0 = ไม่ระบุ Service provinceList
        /// </summary>
        public string petTamb { get; set; } = "0";
        /// <summary>
        /// หน่วยงานที่เคยคิดต่อ
        /// </summary>
        public string deptOtherContact { get; set; }
        /// <summary>
        /// 0= ไม่ระบุ,1=ใช่,2=ไม่ใช่
        /// </summary>
        public int processing { get; set; }
        /// <summary>
        /// เลขที่บัตรประชาชน
        /// </summary>
        public string citizenId { get; set; } = "1212121212121";
        /// <summary>
        /// male/female
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// คำนำหน้าชื่อ
        /// </summary>
        public string prename { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        /// <summary>
        /// 1=โสด 2=สมรส 3=หย่าร้าง 4=อยู่ด้วยกัน 5=ม่าย,หม้าย,0=ไม่ระบุ
        /// </summary>
        public string profileStatus { get; set; } = "0";
        public string birthday { get; set; }
        public string nationality { get; set; }
        public string religion { get; set; }
        /// <summary>
        /// 1=ต่ำกว่าปริญญาตรี 2= ปริญญาตรี 3=ปริญญาโท4=ปริญญาเอก 0=ไม่ระบุ
        /// </summary>
        public int education { get; set; } = 0;
     
        public double income { get; set; } = 0;
        /// <summary>
        /// 0=ไม่ระบุ 1=ต่อวัน 2=   ต่อเดือน 3=ต่อปี
        /// </summary>
        public int incomePer { get; set; }
        /// <summary>
        /// อาชีพ
        /// </summary>
        public string career { get; set; }
        /// <summary>
        /// อีเมล
        /// </summary>
        public string email { get; set; }
       /// <summary>
       /// เบอร์โทรศัพท์
       /// </summary>
        public string phoneNumber { get; set; }
        public string fax { get; set; }
        /// <summary>
        /// LINE id
        /// </summary>
        public string lineId { get; set; }
        /// <summary>
        /// บุคคลอ้างอิง
        /// </summary>
        public string peopleRef { get; set; }
        /// <summary>
        /// เบอร์ติดต่อบุคคลอ้างอิง
        /// </summary>
        public string peopleRefPhoneNum { get; set; }
        #region ภูมิลำเนา
        public string addrNo { get; set; }
        public string addrSoi { get; set; }
        public string addrRoad { get; set; }
        public int addrTambId { get; set; }
        public int addrAumphuId { get; set; }
        public int addrProvId { get; set; }
        public string addrZipCode { get; set; }
        public string addrCurSeem { get; set; }
        public string addrCurNo { get; set; }
        public string addrCurSoi { get; set; }
        public string addrCurRoad { get; set; }
        public string addrCurTambId { get; set; }
        public string addrCurAumphuId { get; set; }
        public string addrCurProvId { get; set; }
        public string addrCurZipCode { get; set; }
        #endregion
    }


}
