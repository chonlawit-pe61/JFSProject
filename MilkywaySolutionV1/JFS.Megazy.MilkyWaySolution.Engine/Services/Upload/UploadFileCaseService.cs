using JFS.Megazy.MilkyWaySolution.Engine.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class UploadFileCaseService : IUploadFile
    {
        string _filename;
        readonly int _caseID, _applicantID;
        public UploadFileCaseService(int caseID,int applicantID)
        {
            _applicantID = applicantID;
            _caseID = caseID; 
        }
        public string SaveFile(HttpPostedFileBase file)
        {
            throw new NotImplementedException();
        }
        public string SaveFile(HttpPostedFile file)
        {           
            try
            {
                if (file.ContentLength > 0)
                {
                    _filename = $"{Engine.Helpers.Utility.GetExtraEpoch().ToString()}{Path.GetExtension(file.FileName)}";
                    //string filepath = ConfigurationManager.AppSettings["FilePath"].ToString();
                    string _comPath = $"/filesupload/case/{_caseID}/{_applicantID}/{_filename}";
                    byte[] data;
                    using (Stream inputStream = file.InputStream)
                    {
                        if (!(inputStream is MemoryStream memoryStream))
                        {
                            memoryStream = new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }
                        data = memoryStream.ToArray();
                        Helpers.FileHelper.SaveFile(data, _comPath);
                    }
                    //    //Move file
                    //    if (System.IO.File.Exists(_uploadPath))
                    //    {
                    //        if (System.IO.File.Exists(_filePath))
                    //        {
                    //            System.IO.File.Delete(_filePath);
                    //            File.Move(_uploadPath, _filePath);
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return _filename;
        }

        public string SaveResultAttachFile(HttpPostedFile file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    _filename = $"{Engine.Helpers.Utility.GetExtraEpoch().ToString()}{Path.GetExtension(file.FileName)}";
                    //string filepath = ConfigurationManager.AppSettings["FilePath"].ToString();
                    string _comPath = $"/filesupload/transaction/{_caseID}/{_applicantID}/{_filename}";
                    byte[] data;
                    using (Stream inputStream = file.InputStream)
                    {
                        if (!(inputStream is MemoryStream memoryStream))
                        {
                            memoryStream = new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }
                        data = memoryStream.ToArray();
                        Helpers.FileHelper.SaveFile(data, _comPath);
                    }
                    //    //Move file
                    //    if (System.IO.File.Exists(_uploadPath))
                    //    {
                    //        if (System.IO.File.Exists(_filePath))
                    //        {
                    //            System.IO.File.Delete(_filePath);
                    //            File.Move(_uploadPath, _filePath);
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return _filename;
        }
        
        public string SaveResultAttachFileImage(string base64Img, string path)
        {
            var extension = "";
            string name = $"{Utility.GetExtraEpoch()}{Path.GetExtension(path)}";
            try
            {
                extension = FileType(base64Img);
                Image image = Base64ToImage(base64Img.Replace("data:image/" + extension + ";base64,", ""));


                Image img = image;
                img.Save(path + name + "." + extension);

                //ImageFactory imageFactory = new ImageFactory();
                //byte[] imageBytes = imageFactory.ResizingImageAsByte(image, "cover");
                //img = ByteToImage(imageBytes);
                //img.Save(path + name + "." + extension);
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, ex);
            }
            return name;
        }
        public string FileType(string base64Img)
        {
            string type = "";
            var lowerCase = base64Img.ToLower();
            if (lowerCase.IndexOf("data:image/png") != -1)
                type = "png";
            else if (lowerCase.IndexOf("data:image/gif") != -1)
                type = "gif";
            else if (lowerCase.IndexOf("data:image/jpg") != -1)
                type = "jpg";
            else //lowerCase.IndexOf("data:image/jpeg") != -1) 
                type = "jpeg";
            return type;
        }
        public Image Base64ToImage(string base64String)
        {

            byte[] imageBytes = Convert.FromBase64String(base64String);

            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        public Image ByteToImage(byte[] imageBytes)
        {

            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}

