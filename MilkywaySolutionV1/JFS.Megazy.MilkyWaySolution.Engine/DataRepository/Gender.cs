using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class Gender
    {
        public string GenderType { get; set; }
        public virtual string ToGenderString()
        {
            var gender = "ไม่ระบุ";
            if (GenderType.ToLower() == "m")
            {
                gender = "ชาย";
            }
            else if (GenderType.ToLower() == "f")
            {
                gender = "หญิง";
            }

            return gender;
        }
    }
   
}
