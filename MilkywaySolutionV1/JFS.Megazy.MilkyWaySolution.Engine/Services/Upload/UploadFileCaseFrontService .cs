using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class UploadFileCaseFrontService  : IUploadFile
    {
        string _filename;
        readonly int _transactionID;
        public UploadFileCaseFrontService (int transactionID)
        {
            _transactionID = transactionID; 
        }
        public string SaveFile(HttpPostedFileBase file)
        {
            throw new NotImplementedException();
        }
        //รับไฟล์จากระบบ jfpettition.moj.go.th
        public string SaveFile(HttpPostedFile file)
        {           
            try
            {
                if (file.ContentLength > 0)
                {
                    _filename = $"{Engine.Helpers.Utility.GetExtraEpoch().ToString()}{Path.GetExtension(file.FileName)}";
                    string _comPath = $"/files/memberattachfile/{_transactionID}/{_filename}";
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
        

    }
}
