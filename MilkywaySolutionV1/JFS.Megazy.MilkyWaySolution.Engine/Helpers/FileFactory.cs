using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
namespace JFS.Megazy.MilkyWaySolution.Engine.Helpers
{ 
    public class FileFactory
    {
        /// <summary>
        /// Save File as path
        /// </summary>
        /// <param name="filePath">/foldername/file.pdf</param>
        /// <param name="saveAsPath">/destinationFolder/</param>
        /// <param name="saveAsFileName">Optional: filename.pdf</param>
        /// <returns></returns>
        public static FilesCollection SaveFileAs(string filePath, string saveAsPath, string saveAsFileName = "")
        {
            FilesCollection filecollect = new FilesCollection();
            if (!string.IsNullOrEmpty(filePath))
            {

                string fileName = Path.GetFileName(filePath);
                if (!string.IsNullOrEmpty(saveAsFileName))
                {
                    fileName = saveAsFileName + Path.GetExtension(fileName);
                }
                if (File.Exists(HttpContext.Current.Server.MapPath(filePath)))
                {
                    //For localpath
                    // string serverpath = HttpContext.Current.Server.MapPath("~" + tempFolderName);
                    try
                    {
                        byte[] fileBytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath(filePath));
                        string tempFolderName = saveAsPath;
                        string filepathName = "";
                        for (int i = 0; i < 2; i++)
                        {
                            if (i == 0)
                            {
                                filepathName = Path.Combine(tempFolderName, fileName);
                                FileHelper.SaveFile(fileBytes, filepathName);
                                filecollect.FileName = fileName;
                                filecollect.FileUrl = Path.Combine("" + tempFolderName, fileName);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                       // DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
                    }

                }

            }
            return filecollect;
        }

        public byte[] Base64ToFile(string base64String)
        {
            //// if the file extension is unknown
            //var extension = "";
            //// do something like this
            //var lowerCase = base64String.ToLower();
            //if (lowerCase.IndexOf("data:image/png") != -1)
            //    extension = "png";
            //else if (lowerCase.IndexOf("data:image/gif") != -1)
            //    extension = "gif";
            //else if (lowerCase.IndexOf("data:image/jpg") != -1)
            //    extension = "jpg";
            //else //lowerCase.IndexOf("data:image/jpeg") != -1) 
            //    extension = "jpeg";
            ////data:image/jpeg;base64,
            //base64String = base64String.Replace("data:image/" + extension + ";base64,", "");
            byte[] filbyte = Convert.FromBase64String(base64String);

            return filbyte;
        }


    }
    public class FilesCollection
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }

    }

    
}