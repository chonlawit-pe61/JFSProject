using Newtonsoft.Json.Schema.Generation;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;

//QR Code
using QRCoder;
using static QRCoder.PayloadGenerator;
using System.Drawing;
using System.Drawing.Imaging;

namespace JFS.Megazy.MilkyWaySolution.Web.Front
{
    public class Utility
    {
        private readonly string[] ThaiNum = new string[] { "๐", "๑", "๒", "๓", "๔", "๕", "๖", "๗", "๘", "๙" };
        
        /// <summary>
        /// แปลงค่าจาก Integer เป็นเลขไทย
        /// </summary>
        /// <param name="num">int</param>
        public static string ChangeArabicIntToThai(int num)
        {
            char[] convert = num.ToString().ToArray();
            string _num = string.Format("{0:#,###0}", num).Replace("0", "๐");
            _num = _num.Replace("1", "๑");
            _num = _num.Replace("2", "๒");
            _num = _num.Replace("3", "๓");
            _num = _num.Replace("4", "๔");
            _num = _num.Replace("5", "๕");
            _num = _num.Replace("6", "๖");
            _num = _num.Replace("7", "๗");
            _num = _num.Replace("8", "๘");
            _num = _num.Replace("9", "๙");

            return _num;
        }
        public static string ChangeArabicIntToThai(long num)
        {
            char[] convert = num.ToString().ToArray();
            string _num = string.Format("{0:#,###0}", num).Replace("0", "๐");
            _num = _num.Replace("1", "๑");
            _num = _num.Replace("2", "๒");
            _num = _num.Replace("3", "๓");
            _num = _num.Replace("4", "๔");
            _num = _num.Replace("5", "๕");
            _num = _num.Replace("6", "๖");
            _num = _num.Replace("7", "๗");
            _num = _num.Replace("8", "๘");
            _num = _num.Replace("9", "๙");

            return _num;
        }

        /// <summary>
        /// แปลงค่าจาก stirng arabic เป็นเลขไทย
        /// </summary>
        /// <param name="num">string</param>
        public static string ChangeArabicStringToThai(string num)
        {
            string _num = num;
            _num = _num.Replace("0", "๐");
            _num = _num.Replace("1", "๑");
            _num = _num.Replace("2", "๒");
            _num = _num.Replace("3", "๓");
            _num = _num.Replace("4", "๔");
            _num = _num.Replace("5", "๕");
            _num = _num.Replace("6", "๖");
            _num = _num.Replace("7", "๗");
            _num = _num.Replace("8", "๘");
            _num = _num.Replace("9", "๙");

            return _num;
        }

        /// <summary>
        /// get ค่า Device Type จาก Request.UserAgent
        /// </summary>
        /// <param name="agent">ใช้ Request.UserAgent เพื่อ get ค่าสำหรับตัวแปลนี้</param>
        public static string GetPlatform(string agent)
        {
            string ret = string.Empty;

            if (agent.ToLower().Contains("android"))
            {
                ret = "android";
            }
            else if (agent.ToLower().Contains("window"))
            {
                ret = "window";
            }
            else
            {
                ret = "ios";
            }

            return ret;
        }

        /// <summary>
        /// สร้าง File Json Schema สำหรับส่งให้ Mobile Application นำไปใช้คู่กับ Mobile API Service 
        /// , File ที่สร้างแล้วจะอยูที่ Folder Model ของ Project
        /// </summary>
        /// <param name="type">ใช้ typeof(XxxBbb) เพื่อ get ค่าสำหรับตัวแปลนี้ , XxxBbb คือชื่อ Model Class ที่แต่ละ Service จะ Response กลับไป</param>
        public static void GenerateJsonSchema(Type type)
        {
            if (ConfigurationManager.AppSettings["IsGenSchema"].Equals("true"))
            {
                var genSchema = new JSchemaGenerator();
                var schema = genSchema.Generate(type);
                string path = HttpContext.Current.Server.MapPath("/Models/");

                string actionName = string.Empty;
                string controllerName = string.Empty;
                RouteValueDictionary routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;
                if (routeValues != null)
                {
                    if (routeValues.ContainsKey("action"))
                    {
                        actionName = routeValues["action"].ToString();
                    }
                    if (routeValues.ContainsKey("controller"))
                    {
                        controllerName = routeValues["controller"].ToString();
                    }

                }
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, controllerName+"_"+actionName + "_" + type.Name + "_schema.json"), false))
                {
                    outputFile.WriteLine(schema.ToString());
                }
            }
        }

        /// <summary>
        /// Random รหัสที่ประกอบไปด้วย UppperCase LowerCase และตัวเลข
        /// </summary>
        public static string RandomPassword()
        {
            Random random = new Random();
            int length = 1;
            int lengthlow = 3;
            int lengthAlphabet = 2;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowChars = "abcdefghijklmnopqrstuvwxyz";
            const string alphabet = "!@#$";
            string password = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray()) +
                new string(Enumerable.Repeat(lowChars, lengthlow)
                .Select(s => s[random.Next(s.Length)]).ToArray()) +
                random.Next(00, 99).ToString() +
                new string(Enumerable.Repeat(alphabet, lengthAlphabet)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            if (RegexUtility.PasswordRegex(password))
            {
                return password;
            }
            else
            {
                return RandomPassword();
            }
        }

        public string GetAuthIP(string ip)
        {
            string authIP = ip;

            string[] ipStr = ip.Split('.');
            if (ipStr != null && ipStr.Length > 1)
            {
                authIP = string.Join(".", ipStr, 0, 3);
            }
            else
            {
                authIP = ip;
            }

            return authIP;
        }

        public static string GenPwToken(int length)
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            string data = result.ToString();

            return data;
        }
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static Bitmap GenURLQRCodeAsBitmap(string url)
        {
            Url generator = new Url(url);
            string payload = generator.ToString();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            return qrCode.GetGraphic(20);
            // var qrCodeAsBitmap = qrCode.GetGraphic(20);


            // Bitmap bitmap = new Bitmap(400, 400);
            //QRCode qrCode = new QRCode(qrCodeData);
            // Bitmap qrCodeImage = qrCode.GetGraphic(5);
            // qrCodeAsBitmap.Save(Server.MapPath("/") + @"GeneratedQRCode.bmp");

        }
        public static Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}