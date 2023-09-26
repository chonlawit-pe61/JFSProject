using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Hosting;
using System.Drawing;
using System.Drawing.Imaging;
namespace Megazy.StarterKit.Mvc.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// บันทึกแบบ byte[]  
        /// ข้อดีคือได้ไฟล์ภาพขนาดเท่าที่อัพโหลด 
        /// ข้อเสียคือเวลาเปิดภาพใน โปรแกรมตกแต่งจะไม่สามารถเปิดได้
        /// </summary>
        /// <param name="content">byte[] </param>
        /// <param name="path"></param>
        public static void SaveFile(byte[] content, string path)
        {
            string filePath = GetFileFullPath(path);
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }

            //Save file
            using (FileStream str = File.Create(filePath))
            {
                str.Write(content, 0, content.Length);
            }
        }
        /// <summary>
        /// บันทึกรูปแบบคุณภาพรูปสูง  100L
        /// </summary>
        /// <param name="image">Image Type</param>
        /// <param name="path">/image/folder/imag.jpg</param>
        /// <param name="ImageCodecInfo">ImageCodecInfo</param>
        public static void SaveFile(Image image, string path, ImageCodecInfo ImageCodecInfo)
        {
            string filePath = GetFileFullPath(path);
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            //Save file
            image.Save(filePath, ImageCodecInfo, myEncoderParameters);
           
        }
        /// <summary>
        /// บันทึกรูปแบบคุณภาพรูปต่ำ
        /// </summary>
        /// <param name="image">Image Type</param>
        /// <param name="path">/image/folder</param>
        /// <param name="ImageFormat">ImageFormat</param>
        public static void SaveFile(Image image, string path, ImageFormat ImageFormat)
        {
            string filePath = GetFileFullPath(path);
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }          
            //Save file
            image.Save(filePath, ImageFormat);

        }
        public static string GetFileFullPath(string path)
        {
            string relName = path.StartsWith("~") ? path : path.StartsWith("/") ? string.Concat("~", path) : path;

            string filePath = relName.StartsWith("~") ? HostingEnvironment.MapPath(relName) : relName;

            return filePath;
        }

        public static bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    /*TODO: You must process this exception.*/
                    result = false;
                }
            }
            return result;
        }
        public static void DeleteFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
         
    public static double GetLastUpdateTotalMinutes(string path)
        {
            DateTime start = File.GetLastWriteTime(path);
            TimeSpan span = DateTime.Now - start;
            return span.TotalMinutes;
        }
      
    }
}