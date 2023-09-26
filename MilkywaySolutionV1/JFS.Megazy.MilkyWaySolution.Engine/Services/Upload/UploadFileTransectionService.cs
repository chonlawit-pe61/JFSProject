using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.Upload
{
    public class UploadFileTransectionService
    {
        public bool InsertFileToMemberAttachFile(int fileid , ProjectAttachfile projectAttachfile) 
        {
            if (fileid != 0 && projectAttachfile != null)
            {

                TransactionAttachfileCollection_Base caseAttachFile = new TransactionAttachfileCollection_Base(CSystems.ProcessID);
                caseAttachFile.DeleteByPrimaryKey(fileid, projectAttachfile.TransactionID);
                caseAttachFile.Dispose();
                var caseAttachFileRow = new TransactionAttachfileRow
                {
                    TransactionID = projectAttachfile.TransactionID,
                    AttachFileID = fileid,
                    LableFile = projectAttachfile.LableFile,
                    Description = projectAttachfile.Description,
                    ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID)
                };
                caseAttachFile = new TransactionAttachfileCollection_Base(CSystems.ProcessID);
                caseAttachFile.InsertOnlyPlainText(caseAttachFileRow);
                caseAttachFile.Dispose();

                return true;
            }
            else
            {
                return false;
            }  
        }

    }
}
