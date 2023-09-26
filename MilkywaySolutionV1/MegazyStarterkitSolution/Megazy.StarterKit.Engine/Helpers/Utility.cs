using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web;
namespace Megazy.StarterKit.Engine.Helpers
{
    public static class Utility
    {
        /// <summary>
        /// หาปีงบประมาณไทย
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetThaiFiscalYear(this DateTime date)
        {
            if (date.Month > 9)
            {
                return date.AddYears(1).Year + 543;
            }
            else
            {
                return date.Year + 543;
            }
        }
        public static int GetQuarter(this DateTime date)
        {
            if (date.Month >= 4 && date.Month <= 6)
                return 3;
            else if (date.Month >= 7 && date.Month <= 9)
                return 4;
            else if (date.Month >= 10 && date.Month <= 12)
                return 1;
            else
                return 2;
        }
        public static long GetExtraEpoch()
        {
            long epoch;
            epoch = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
            return epoch;
        }

        public static long ConvertToExtraEpoch(DateTime dateTime)
        {
            long epoch;
            epoch = (long)(DateTime.UtcNow.Subtract(dateTime)).TotalMilliseconds;
            return epoch;
        }

        public static string EncryptMd5(string toEncrypt)
        {
            byte[] hash;
            using (MD5 md5 = MD5.Create())
            {
                hash = md5.ComputeHash(Encoding.UTF8.GetBytes(toEncrypt));
                toEncrypt = Md5ByteToHex(hash, false);
            }

            return toEncrypt;
        }

        private static string Md5ByteToHex(byte[] bytes, bool upperCase)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

            return result.ToString();
        }
        public static double TwoDecimalPlaces(double val)
        {
            if (val > 0)
            {
                return Math.Truncate(val * 100) / 100;
            }
            else
            {
                return val;
            }
        }
        public static int TryParseToInt(string input)
        {
            int outnumber = 0;
            if (!string.IsNullOrEmpty(input))
            {
                bool result = Int32.TryParse(input, out outnumber);
            }
            return outnumber;
        }

        public static decimal TryParseToDecimal(string input)
        {
            decimal outnumber = 0;
            if (!string.IsNullOrEmpty(input))
            {
                bool result = Decimal.TryParse(input, out outnumber);
            }
            return outnumber;
        }
        public static double TryParseToDouble(string input)
        {
            double outnumber = 0;
            if (!string.IsNullOrEmpty(input))
            {
                bool result = Double.TryParse(input, out outnumber);
            }
            return outnumber;
        }
        public static double TryParseToFloat(string input)
        {
            float outnumber = 0;
            if (!string.IsNullOrEmpty(input))
            {
                bool result = float.TryParse(input, out outnumber);
            }
            return outnumber;
        }
        public static string DecryptMd5(string toDecrypt)
        {
            byte[] hash;
            using (MD5 md5 = MD5.Create())
            {
                hash = Md5HexToByte(toDecrypt);
                toDecrypt = Encoding.UTF8.GetString(hash, 0, hash.Length);
            }

            return toDecrypt;
        }

        private static byte[] Md5HexToByte(string hex)
        {
            //int NumberChars = hex.Length;
            //byte[] bytes = new byte[NumberChars / 2];
            //for (int i = 0; i < NumberChars; i += 2)
            //    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);


            byte[] bytes = new byte[hex.Length / 2];
            for (int index = 0; index < bytes.Length; ++index)
                bytes[index] = Convert.ToByte(hex.Substring(index * 2, 2), 16);

            return bytes;
        }
        public static string GetLocalIPAddress()
        {
            //var host = Dns.GetHostEntry(Dns.GetHostName());

            //foreach (var ip in host.AddressList)
            //{
            //    if (ip.AddressFamily == AddressFamily.InterNetwork)
            //    {
            //        return ip.ToString();
            //    }
            //}
            //throw new Exception("Local IP Address Not Found!");



            HttpContext context = HttpContext.Current;
            //string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            //if (!string.IsNullOrEmpty(ipAddress))
            //{
            //    string[] addresses = ipAddress.Split(',');
            //    if (addresses.Length != 0)
            //    {
            //        return addresses[0];
            //    }

            //}
            //else
            //{
            return context.Request.UserHostAddress;
            //}

            //return "";
        }
        public static string ConvertToThaiNumerals(this string input)
        {
            if (input != null)
            {
                CultureInfo cultureInfo = new CultureInfo("th-TH");// Thread.CurrentThread.CurrentCulture;
                return input.Replace("0", cultureInfo.NumberFormat.NativeDigits[0])
                               .Replace("1", cultureInfo.NumberFormat.NativeDigits[1])
                               .Replace("2", cultureInfo.NumberFormat.NativeDigits[2])
                               .Replace("3", cultureInfo.NumberFormat.NativeDigits[3])
                               .Replace("4", cultureInfo.NumberFormat.NativeDigits[4])
                               .Replace("5", cultureInfo.NumberFormat.NativeDigits[5])
                               .Replace("6", cultureInfo.NumberFormat.NativeDigits[6])
                               .Replace("7", cultureInfo.NumberFormat.NativeDigits[7])
                               .Replace("8", cultureInfo.NumberFormat.NativeDigits[8])
                               .Replace("9", cultureInfo.NumberFormat.NativeDigits[9]);
            }
            else
            {
                return "";
            }
        }
        public static string ThaiBaht(decimal txt)
        {
            string bahtTxt, n, bahtTH = "";
            double amount;
            try { amount = Convert.ToDouble(txt); }
            catch { amount = 0; }
            bahtTxt = amount.ToString("####.00");
            string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
            string[] temp = bahtTxt.Split('.');
            string intVal = temp[0];
            string decVal = temp[1];
            if (Convert.ToDouble(bahtTxt) == 0)
                bahtTH = "-";
            else
            {
                for (int i = 0; i < intVal.Length; i++)
                {
                    n = intVal.Substring(i, 1);
                    if (n != "0")
                    {
                        if ((i == (intVal.Length - 1)) && (n == "1"))
                            bahtTH += "เอ็ด";
                        else if ((i == (intVal.Length - 2)) && (n == "2"))
                            bahtTH += "ยี่";
                        else if ((i == (intVal.Length - 2)) && (n == "1"))
                            bahtTH += "";
                        else
                            bahtTH += num[Convert.ToInt32(n)];
                        bahtTH += rank[(intVal.Length - i) - 1];
                    }
                }
                bahtTH += "บาท";
                if (decVal == "00")
                    bahtTH += "ถ้วน";
                else
                {
                    for (int i = 0; i < decVal.Length; i++)
                    {
                        n = decVal.Substring(i, 1);
                        if (n != "0")
                        {
                            if ((i == decVal.Length - 1) && (n == "1"))
                                bahtTH += "เอ็ด";
                            else if ((i == (decVal.Length - 2)) && (n == "2"))
                                bahtTH += "ยี่";
                            else if ((i == (decVal.Length - 2)) && (n == "1"))
                                bahtTH += "";
                            else
                                bahtTH += num[Convert.ToInt32(n)];
                            bahtTH += rank[(decVal.Length - i) - 1];
                        }
                    }
                    bahtTH += "สตางค์";
                }
            }
            return bahtTH;
        }
        enum thaiText { ศูนย์ = 0, หนึ่ง = 1, สอง = 2, สาม = 3, สี่ = 4, ห้า = 5, หก = 6, เจ็ด = 7, แปด = 8, เก้า = 9 };

        public static string ThaiNumberToText(int txt)
        {
            string re = "";
            char[] chararr = txt.ToString().ToCharArray();
            for (int i = 0; i < chararr.Length; i++)
            {
                try { re += ((thaiText)Enum.Parse(typeof(thaiText), chararr[i].ToString())).ToString(); }
                catch { re += chararr[i]; };
            }
            return re;
        }
        public static string ConvertDateToString(DateTime dt)
        {
            return DateValidateInput(dt) ? string.Format("{0:0000}", dt.Year) + "." + string.Format("{0:00}", dt.Month) + "." + string.Format("{0:00}", dt.Day) : "";
        }

        /// <summary>
        /// วว//ดด/ปปปป
        /// </summary>
        /// <param name="dt">Datetime คศ</param>
        /// <returns></returns>
        public static string ConvertDateToThaiString(DateTime dt)
        {
            return DateValidateInput(dt) ? dt.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("th-TH")) : "";
        }
        /// <summary>
        /// วว//ดด/ปปปป
        /// </summary>
        /// <param name="dt">Datetime คศ</param>
        /// <returns></returns>
        public static string ConvertDateToENString(DateTime dt)
        {
            return DateValidateInput(dt) ? dt.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")) : "";
        }
        /// <summary>
        /// รูปบบการ 31 พฤษภาคม 2560"
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ConvertDateToThaiLongDate(DateTime dt)
        {
            return DateValidateInput(dt) ? dt.ToString("d MMMM yyyy", CultureInfo.CreateSpecificCulture("th-TH")) : "";

        }
        public static string ConvertDateTimeToThaiLongDate(DateTime dt)
        {
            return DateValidateInput(dt) ? dt.ToString("d MMMM yyyy HH:mm", CultureInfo.CreateSpecificCulture("th-TH")) : "";

        }
        /// <summary>
        /// รองรับปี ค.ศ. เท่านั้น "24/01/2013"
        /// "24/1/2013"
        /// "4/12/2013" //4 December 2013
        /// "04/12/2013"
        /// </summary>
        /// <param name="dMyyyy"></param>
        /// <returns></returns>
        public static DateTime ConvertStringToDate(string dMyyyy)
        {
            DateTime dt;
            if (DateTime.TryParseExact(dMyyyy,
                                        "d/M/yyyy",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                out dt))
            {
                //valid date

            }
            else
            {
                //invalid date
                dt = DateTime.Now;
            }
            return dt;
        }
        /// <summary>
        /// รองรับปี ค.ศ. เท่านั้น "1970-03-31"
        /// </summary>
        /// <param name="yyyy-MM-dd"></param>
        /// <returns></returns>
        public static DateTime ConvertYYYYMMDDStringToDate(string dMyyyy)
        {
            DateTime dt;
            if (DateTime.TryParseExact(dMyyyy,
                                        "yyyy-MM-dd",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                out dt))
            {
                //valid date

            }
            else
            {
                //invalid date
                dt = DateTime.Now;
            }
            return dt;
        }
        public static bool DateValidateInput(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public static string DateValidateNull(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return "";
            }
            else
            {
                return ConvertDateToENString(date);
            }

        }

        public static int GetThaiYear(DateTime date = new DateTime())
        {
            ThaiBuddhistCalendar cal = new ThaiBuddhistCalendar();
            if (date == DateTime.MinValue)
            {
                date = DateTime.Now;
            }
            return cal.GetYear(date);
        }

        public static string ConvertDateToLongDate(DateTime dt)
        {
           // CultureInfo.CurrentCulture = new CultureInfo("th-TH");
           //var curinfo = Thread.CurrentThread.CurrentCulture.Name;
            return DateValidateInput(dt) ? dt.ToString("d MMMM yyyy", CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name)) : "";

        }
        public static string ConvertDateToLongDateTime(DateTime dt)
        {
            //CultureInfo.CurrentCulture.Name;
            return DateValidateInput(dt) ? dt.ToString("d MMMM yyyy HH:mm", CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name)) : "";
        }






        public static string DefaultBlank(string text, bool isDash = false)
        {
            return string.IsNullOrWhiteSpace(text) ? (isDash ? "-" : "") : text;
        }
        public static string CalculateAge(DateTime birthDate, DateTime compareDate = new DateTime())
        {
            Age age = new Age(birthDate, compareDate);
            return age.AgeString;
        }

        public static string BlankForm(string text)
        {
            return string.IsNullOrWhiteSpace(text) ? "" : text;
        }


        public static string CalculateDays(DateTime startDate, DateTime endDate = new DateTime())
        {
            double count = 0;
            if (startDate != DateTime.MinValue && endDate != DateTime.MinValue)
            {

                TimeSpan ts = endDate.Subtract(startDate);
                count = ts.TotalDays; //Math.Abs(ts.Days);
            }
            return count <= 0 ? "-" : count.ToString();
        }
        public static string GetGender(string sex)
        {
            string gender = "N/A";
            if (!string.IsNullOrWhiteSpace(sex))
            {
                sex = sex.ToLower();
                if (sex == "m")
                {
                    gender = "ชาย";
                }
                else if (sex == "f")
                {
                    gender = "หญิง";
                }
            }
            return gender;
        }
        public static string ChangeMonth(int month)
        {
            string StringMonth;
            switch (month)
            {
                case 1:
                    StringMonth = "มกราคม";
                    break;
                case 2:
                    StringMonth = "กุมภาพันธ์";
                    break;
                case 3:
                    StringMonth = "มีนาคม";
                    break;
                case 4:
                    StringMonth = "เมษายน";
                    break;
                case 5:
                    StringMonth = "พฤษภาคม";
                    break;
                case 6:
                    StringMonth = "มิถุนายน";
                    break;
                case 7:
                    StringMonth = "กรกฎาคม";
                    break;
                case 8:
                    StringMonth = "สิงหาคม";
                    break;
                case 9:
                    StringMonth = "กันยายน";
                    break;
                case 10:
                    StringMonth = "ตุลาคม";
                    break;
                case 11:
                    StringMonth = "พฤศจิกายน";
                    break;
                case 12:
                    StringMonth = "ธันวาคม";
                    break;
                default:
                    StringMonth = "";
                    break;
            }
            return StringMonth;
        }
        public static int ChangeYeryThai(int year)
        {
            if (year >= 0)
            {
                year += 543;
            }
            return year;
        }
        public static int DifferenceInMonth(DateTime startDate, DateTime endDate)
        {
            return ((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month;
        }
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static string CardIDFormat(string CardID)
        {
            string cardformat = CardID;
            cardformat = cardformat.Insert(1, "-");
            cardformat = cardformat.Insert(6, "-");
            cardformat = cardformat.Insert(12, "-");
            cardformat = cardformat.Insert(15, "-");
            return cardformat;
        }
        public static string UnitDMY(string unit)
        {
            string changunit = "";
            if (!string.IsNullOrWhiteSpace(unit))
            {
                changunit = unit;
                if (changunit.ToUpper() == "D")
                {
                    changunit = "วัน";
                }
                else if (changunit.ToUpper() == "M")
                {
                    changunit = "เดือน";
                }
                else if (changunit.ToUpper() == "Y")
                {
                    changunit = "ปี";
                }
            }
            return changunit;
        }
        public static string CalculateAgeYear(DateTime birthDate, DateTime compareDate = new DateTime())
        {
            Age age = new Age(birthDate, compareDate);
            return age.Years.ToString();
        }
        /// <summary>
        /// ค.ศ.Ex:"25500330" to "30 มีนาคม 2550"
        /// </summary>
        /// <param name="dateStr">25500330</param>
        /// <returns>30 มีนาคม 2550</returns>
        public static string IDCardDateToDateThai(string dateStr)
        {
            string mm="", yyyy="", monthtext = "";
            int dd = 0;
            int len = dateStr.Length;
            if (len == 8)
            {
                yyyy = dateStr.Substring(0, 4);
                mm = dateStr.Substring(4, 2);
                monthtext = ChangeMonth(Convert.ToInt32(mm));
                dd = Convert.ToInt32(dateStr.Substring(6, 2));
            }
            else if (len == 6)
            {
                yyyy = dateStr.Substring(0, 4);
                mm = dateStr.Substring(0, 2);
                monthtext = ChangeMonth(Convert.ToInt32(mm));
            }
            else if (len == 4)
            {
                yyyy = dateStr.Substring(0, 4);
            }
            return DefaultBlank(dd.ToString()) + "  " + DefaultBlank(monthtext) + "  " + DefaultBlank(yyyy);
        }
        /// <summary>
        /// พ.ศ.Ex: "2550/03/30" to "30/03/2007
        /// </summary>
        /// <param name="dateStr">2550/03/30</param>
        /// <returns>30/03/2007</returns>
        public static string IDCardDateThaiToDateEN(string dateStr)
        {
            string mm = "", dd = "";
            int yyyy = 0;
            int len = dateStr.Length;
            if (len == 8)
            {
                yyyy = Convert.ToInt32(dateStr.Substring(0, 4)) - 543;
                mm = dateStr.Substring(4, 2);
                dd = dateStr.Substring(6, 2);
            }
            else if (len == 6)
            {
                yyyy = Convert.ToInt32(dateStr.Substring(0, 4)) - 543;
                mm = dateStr.Substring(4, 2);
            }
            else if (len == 4)
            {
                yyyy = Convert.ToInt32(dateStr.Substring(0, 4)) - 543;
            }
            return DefaultBlank(dd) + '/' + DefaultBlank(mm) + '/' + DefaultBlank(yyyy.ToString());
        }
        public static string ChangApplicantStatus(string type)
        {
            var retype = "";
            if (!string.IsNullOrWhiteSpace(type))
            {
                if (type.ToUpper() == "PL")
                {
                    retype = " โจทก์";
                }
                else
                {
                    retype = "จำเลย";
                }
            }
            return retype;
        }
    }
}