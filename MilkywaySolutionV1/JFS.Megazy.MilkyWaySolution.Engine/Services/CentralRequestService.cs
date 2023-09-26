using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
   public  static class CentralRequestService
    {
        /// <summary>
        /// รับข้อมูลจากเว็บไซต์ และ Mobile Apps
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
//1	MSC	ศูนย์ให้บริการประชาชนกระทรวงยุติธรรม
//2	APPS แอปพลิเคชัน
//3	WEB เว็บไซต์กองทุนยุติธรรม
//4	CALLCENTER สายด่วน
//5	OTHER อื่นๆ
        public static bool CreateRequest(CaseApplicantRequestData data)
        {

            DalBase dal = new DalBase();
            try
            {
                dal.DbBeginTransaction(CSystems.ProcessID);

                CaseApplicantRequestCollection_Base caseApplicantRequest = new CaseApplicantRequestCollection_Base(CSystems.ProcessID);
                caseApplicantRequest.Insert(new CaseApplicantRequestRow
                {
                    ReferenceMSCID = data.ReferenceMSCID,
                    ReferenceMSCCode = data.ReferenceMSCCode,
                    ProvinceID = data.ProvinceID,
                    DepartmentID = data.DepartmentID,
                    Subject = data.Subject,
                    TelephoneNo = data.TelephoneNo,
                    Gender = data.Gender,
                    Title = data.Title,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    ProvinceName = data.ProvinceName,
                    PostCode = data.PostCode,
                    CardID = data.CardID,
                    Defactive = data.Defactive,
                    Remark = data.Remark,
                    CreateDate = dal.GetSqlNow(CSystems.ProcessID),
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                    StatusID = data.StatusID,
                    Central = data.Central,
                    ChannelID = data.ChannelID,
                    Email = data.Email
                });
                caseApplicantRequest.Dispose();

                dal.DbCommit(CSystems.ProcessID);

            }
            catch (Exception ex)
            {
                dal.DbRollBack(CSystems.ProcessID);
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return true;
        }
    }
}
