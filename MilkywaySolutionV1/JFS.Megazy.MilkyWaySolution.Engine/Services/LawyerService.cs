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
using JFS.Megazy.MilkyWaySolution.Engine.Helpers;
using System.Data;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class LawyerService
    {

        private int GetMaxLawyerID()
        {
            int id = 0;
            LawyerCollection_Base objLawyer = new LawyerCollection_Base(CSystems.ProcessID);
            id = objLawyer.GetMaxID();
            objLawyer.Dispose();
            return id;
        }


        private int GetMaxLawyerOfficeID()
        {
            int id = 0;
            LawyerOfficeCollection_Base objLawyer = new LawyerOfficeCollection_Base(CSystems.ProcessID);
            id = objLawyer.GetMaxID();
            objLawyer.Dispose();
            return id;
        }


        public int InsertOrUpdateLawyer(LawyerEditableResponse data, DalBase dal)
        {
            int id = 0;

            if (data != null)
            {


                LawyerCollection_Base obj = new LawyerCollection_Base(CSystems.ProcessID);
                LawyerRow lawyerRow = new LawyerRow();
                lawyerRow = obj.GetByPrimaryKey(data.LawyerID);
                if (lawyerRow != null)
                {

                    lawyerRow.LawyerTypeID = (int)data.LawyerTypeID;
                    lawyerRow.Title = data.Title;
                    lawyerRow.FirstName = data.FirstName;
                    lawyerRow.LastName = data.LastName;
                    lawyerRow.CardID = data.CardID;
                    lawyerRow.Gender = data.Gender.GenderType;
                    lawyerRow.LicenseNo = data.LicenseNo;
                    if (Utility.ConvertStringToDate(data.IssueDate) != DateTime.MinValue)
                    {
                        lawyerRow.IssueDate = Utility.ConvertStringToDate(data.IssueDate);
                    }

                    if (Utility.ConvertStringToDate(data.ExprieDate) != DateTime.MinValue)
                    {
                        lawyerRow.ExprieDate = Utility.ConvertStringToDate(data.ExprieDate);

                    }

                    lawyerRow.Email = data.Email;
                    lawyerRow.MobileNo = data.MobileNo;
                    lawyerRow.Education = data.Education;
                    lawyerRow.Remark = data.Remark;
                    lawyerRow.NumberOfConductCase = data.NumberOfConductCase;
                    lawyerRow.YearsExperience = data.YearsExperience;
                    if (Utility.ConvertStringToDate(data.RegisterDate) != DateTime.MinValue)
                    {
                        lawyerRow.RegisterDate = Utility.ConvertStringToDate(data.RegisterDate);

                    }
                    if (Utility.ConvertStringToDate(data.DateOfBirth) != DateTime.MinValue)
                    {
                        lawyerRow.DateOfBirth = Utility.ConvertStringToDate(data.DateOfBirth);

                    }
                    lawyerRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                    lawyerRow.LawyerStatusID = data.LawyerStatusID;
                    obj.UpdateOnlyPlainText(lawyerRow);
                    id = lawyerRow.LawyerID;
                }
                else
                {
                    lawyerRow = new LawyerRow();
                    lawyerRow.LawyerID = (GetMaxLawyerID() + 1);
                    lawyerRow.LawyerTypeID = (int)data.LawyerTypeID;
                    lawyerRow.Title = data.Title;
                    lawyerRow.FirstName = data.FirstName;
                    lawyerRow.LastName = data.LastName;
                    lawyerRow.CardID = data.CardID;
                    lawyerRow.Gender = data.Gender.GenderType;
                    lawyerRow.LicenseNo = data.LicenseNo;
                    if (Utility.ConvertStringToDate(data.IssueDate) != DateTime.MinValue)
                    {
                        lawyerRow.IssueDate = Utility.ConvertStringToDate(data.IssueDate);
                    }

                    if (Utility.ConvertStringToDate(data.ExprieDate) != DateTime.MinValue)
                    {
                        lawyerRow.ExprieDate = Utility.ConvertStringToDate(data.ExprieDate);

                    }

                    lawyerRow.Email = data.Email;
                    lawyerRow.MobileNo = data.MobileNo;
                    lawyerRow.Education = data.Education;
                    lawyerRow.Remark = data.Remark;
                    lawyerRow.NumberOfConductCase = data.NumberOfConductCase;
                    lawyerRow.YearsExperience = data.YearsExperience;
                    lawyerRow.RegisterDate = dal.GetSqlNow(CSystems.ProcessID);
                    lawyerRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                    if (Utility.ConvertStringToDate(data.DateOfBirth) != DateTime.MinValue)
                    {
                        lawyerRow.DateOfBirth = Utility.ConvertStringToDate(data.DateOfBirth);

                    }
                    lawyerRow.LawyerStatusID = data.LawyerStatusID;
                    obj.InsertOnlyPlainText(lawyerRow);
                    id = lawyerRow.LawyerID;
                }
                obj.Dispose();
            }

            return id;
        }


        public LawyerEditableResponse GetProfileEditable(int lawyerID)
        {
            LawyerEditableResponse res = null;
            try
            {

                View_LawyerCollection_Base obj = new View_LawyerCollection_Base(CSystems.ProcessID);
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlpara = new SqlParameter("@LawyerID", SqlDbType.Int) { Value = lawyerID };
                parameter.Add(sqlpara);
                string whereSql = "[LawyerID] = @LawyerID";
                var row = obj.GetRow(parameter, whereSql);
                obj.Dispose();
                if (row != null)
                {
                    res = new LawyerEditableResponse
                    {
                        CardID = row.CardID,
                        Education = row.Education,
                        Email = row.Email,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        Title = row.Title,
                        Gender = new Gender { GenderType = row.Gender },
                        LawyerStatus = row.LawyerStatusName,
                        LawyerStatusID = row.LawyerStatusID,
                        LawyerID = row.LawyerID,
                        LicenseNo = row.LicenseNo,
                        LicenseType = row.LicenseType,
                        MobileNo = row.MobileNo,
                        NumberOfConductCase = row.NumberOfConductCase,
                        Remark = row.Remark,
                        YearsExperience = row.YearsExperience,
                        IssueDate = Utility.ConvertDateToENString(row.IssueDate),
                        ExprieDate = Utility.ConvertDateToENString(row.ExprieDate),
                        DateOfBirth = Utility.ConvertDateToENString(row.DateOfBirth),
                        RegisterDate = Utility.ConvertDateToENString(row.RegisterDate),
                        ModifiedDate = Utility.ConvertDateToENString(row.ModifiedDate),
                        LawyerTypeID = row.LawyerTypeID,
                        LawyerTypeName = row.LawyerTypeName
                    };

                    View_LawyerAddressCollection_Base address = new View_LawyerAddressCollection_Base(CSystems.ProcessID);
                    parameter = new List<SqlParameter>();
                    sqlpara = new SqlParameter("@LawyerID", System.Data.SqlDbType.Int) { Value = row.LawyerID };
                    parameter.Add(sqlpara);
                    whereSql = "[LawyerID] = @LawyerID";
                    var addrRow = address.GetRow(parameter, whereSql);
                    res.Address = new LawyerAddressEditable();
                    address.Dispose();
                    if (addrRow != null)
                    {

                        res.Address.AddressID = addrRow.AddressID;
                        res.Address.AddressLine1 = addrRow.Address1;
                        res.Address.AddressTypeID = row.AddressTypeID;
                        res.Address.ProvinceID = addrRow.ProvinceID;
                        res.Address.ProvinceName = addrRow.ProvinceName;
                        res.Address.DistrictID = addrRow.DisctrictID;
                        res.Address.DistrictName = addrRow.DistrictName;
                        res.Address.SubDistrictID = addrRow.SubdistrictID;
                        res.Address.SubDistrictName = addrRow.SubdistrictName;
                        res.Address.AddressType = addrRow.TypeName;
                        res.Address.Country = addrRow.CountryCode;
                        res.Address.PostCode = addrRow.PostCode;
                        res.Address.TelephoneNo = addrRow.TelephoneNo;
                        res.Address.IsPrimary = addrRow.IsPrimary;
                        res.Address.FaxNo = addrRow.FaxNo;
                        res.Address.IsActive = addrRow.IsActive;

                    }
                    if (row.Territory != null)
                    {
                        res.Territory = JsonConvert.DeserializeObject<List<Territory>>(row.Territory);
                    }

                    LawyerEnrollmentCollection_Base lawyerEnrollment = new LawyerEnrollmentCollection_Base(CSystems.ProcessID);
                    var lawyerEnrollmentRow = lawyerEnrollment.GetByLawyerID(lawyerID);


                    res.Enrollment = (from q in lawyerEnrollmentRow
                                      select new LawyerEnrollment
                                      {
                                          EnrollmentYear = q.EnrollmentYear,
                                          EnrollmentDate = q.EnrollmentDate
                                      }).OrderBy(c => c.EnrollmentYear).ToArray();

                    LawyerSpecialtyCollection_Base lawyerSpecialty = new LawyerSpecialtyCollection_Base(CSystems.ProcessID);
                    string whereSqlSpecialty = $"[LawyerID] = {row.LawyerID}";
                    res.Specialty = lawyerSpecialty.GetAsArray(new List<SqlParameter>(), whereSqlSpecialty, "");

                }

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }

            return res;
        }


        public AttachFileRow InsertOrUpdateAttachFile(AttachFileRow attachFileRow, DalBase dal)
        {

            AttachFileRow fileRow = new AttachFileRow();

            AttachFileCollection_Base obj = new AttachFileCollection_Base(CSystems.ProcessID);
            fileRow = obj.GetByPrimaryKey(attachFileRow.AttachFileID);

            if (fileRow != null)
            {

                if (!string.IsNullOrWhiteSpace(attachFileRow.FileName))
                {
                    fileRow.FileName = attachFileRow.FileName;
                    fileRow.FileType = attachFileRow.FileType;
                }

                fileRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                obj.UpdateOnlyPlainText(fileRow);
            }
            else
            {

                fileRow = new AttachFileRow();
                fileRow.FileName = attachFileRow.FileName;
                fileRow.FileType = attachFileRow.FileType;
                fileRow.SortOrder = 1;
                fileRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                fileRow.AttachFileID = obj.InsertOnlyPlainText(fileRow);
            }
            obj.Dispose();
            return fileRow;
        }



        public void InsertLawyerAttachFile(int lawyerID, int attachFileID, string docsNmae, DalBase dal)
        {

            LawyerAttachFileCollection_Base obj = new LawyerAttachFileCollection_Base(CSystems.ProcessID);
            obj.DeleteByPrimaryKey(lawyerID, attachFileID);

            obj = new LawyerAttachFileCollection_Base(CSystems.ProcessID);
            obj.InsertOnlyPlainText(new LawyerAttachFileRow
            {
                AttachFileID = attachFileID,
                LawyerID = lawyerID,
                Title = docsNmae,
                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
            });
            obj.Dispose();

        }



        /// <summary>
        ///  Insert Or Update lawyer Address
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool InsertOrUpdatelawyerAddress(LawyerAddressRow data, DalBase dal)
        {
            bool isPass = false;
            LawyerAddressCollection_Base obj = new LawyerAddressCollection_Base(CSystems.ProcessID);
            obj.Delete($"LawyerID={data.LawyerID} AND AddressTypeID={data.AddressTypeID}");//ทนายมีได้แค่  1 ประเภทที่อยุ่เท่านั้น
            obj.Dispose();
            //insert
            if (data.AddressID != 0 && data.LawyerID != 0)
            {
                obj = new LawyerAddressCollection_Base(CSystems.ProcessID);
                obj.InsertOnlyPlainText(new LawyerAddressRow
                {
                    AddressID = data.AddressID,
                    LawyerID = data.LawyerID,
                    IsPrimary = true,
                    IsActive = true,
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                    AddressTypeID = data.AddressTypeID,
                    FaxNo = data.FaxNo,
                    TelephoneNo = data.TelephoneNo
                });
                isPass = true;
                obj.Dispose();
            }
            return isPass;
        }

        /// <summary>
        /// Insert Or Update Address
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int InsertOrUpdateAddress(AddressRow data, DalBase dal)
        {

            int id = 0;

            AddressCollection_Base objAddress = new AddressCollection_Base(CSystems.ProcessID);
            AddressRow addressRow = objAddress.GetByPrimaryKey(data.AddressID);
            if (addressRow != null)
            {
                //update
                addressRow.Address1 = data.Address1;
                addressRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                addressRow.ProvinceID = data.ProvinceID;
                addressRow.DisctrictID = data.DisctrictID;
                addressRow.SubdistrictID = data.SubdistrictID;
                addressRow.PostCode = data.PostCode;
                objAddress.UpdateOnlyPlainText(addressRow);
                id = addressRow.AddressID;
            }
            else
            {

                //insert
                id = objAddress.InsertOnlyPlainText(new AddressRow
                {

                    Address1 = data.Address1,
                    ProvinceID = data.ProvinceID,
                    DisctrictID = data.DisctrictID,
                    SubdistrictID = data.SubdistrictID,
                    PostCode = data.PostCode,
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                    Createdate = dal.GetSqlNow(CSystems.ProcessID)
                });


            }
            objAddress.Dispose();
            return id;
        }


        public int InsertOrUpdateLawyerOffice(LawyerOfficeRow data, DalBase dal)
        {

            int id = 0;
            LawyerOfficeCollection_Base objOffice = new LawyerOfficeCollection_Base(CSystems.ProcessID);
            LawyerOfficeRow lawyerOfficeRow = objOffice.GetByPrimaryKey(data.LawyerOfficeID);
            if (lawyerOfficeRow != null)
            {
                //update
                lawyerOfficeRow.LawyerFirmName = data.LawyerFirmName;
                lawyerOfficeRow.TelephoneNo = data.TelephoneNo;
                lawyerOfficeRow.FaxNo = data.FaxNo;
                lawyerOfficeRow.Email = data.Email;
                lawyerOfficeRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                lawyerOfficeRow.IsActive = true;

                objOffice.UpdateOnlyPlainText(lawyerOfficeRow);
                id = lawyerOfficeRow.LawyerOfficeID;
            }
            else
            {

                var maxID = (GetMaxLawyerOfficeID() + 1);
                //insert
                objOffice.InsertOnlyPlainText(new LawyerOfficeRow
                {
                    LawyerOfficeID = maxID,
                    LawyerFirmName = data.LawyerFirmName,
                    TelephoneNo = data.TelephoneNo,
                    FaxNo = data.FaxNo,
                    Email = data.Email,
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                    IsActive = true
                });

                id = maxID;
            }
            objOffice.Dispose();
            return id;
        }
        public void InsertLawyerOfficeAddress(int lawyerOfficeID, int addressID, DalBase dal)
        {
            LawyerOfficeAddressCollection_Base objOfficeAddress = new LawyerOfficeAddressCollection_Base(CSystems.ProcessID);
            objOfficeAddress.DeleteByLawyerOfficeID(lawyerOfficeID);
            objOfficeAddress.InsertOnlyPlainText(new LawyerOfficeAddressRow
            {
                LawyerOfficeID = lawyerOfficeID,
                AddressID = addressID,
                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
            });
            objOfficeAddress.Dispose();
        }
        public void InsertLawyerMapOffice(int lawyerID, int lawyerOfficeID, DalBase dal)
        {
            LawyerMapOfficeCollection_Base objMapOffice = new LawyerMapOfficeCollection_Base(CSystems.ProcessID);
            objMapOffice.DeleteByPrimaryKey(lawyerID, lawyerOfficeID);
            objMapOffice.InsertOnlyPlainText(new LawyerMapOfficeRow
            {
                LawyerOfficeID = lawyerOfficeID,
                LawyerID = lawyerID,
                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
            });
            objMapOffice.Dispose();
        }
        public bool DeleteLawyerQueue(int queueVersion)
        {
            //ลบสถานะคิวที่ยังไม่ได้ Process เท่านั้น หาก Process แล้วจะไม่ลบให้เก็บสถานะไว้ไว้ตรวจสอบการทำงาน
            if (queueVersion != 0)
            {  //ลบเฉพาะรายการที่มีสถานะที่รอคิวเท่านั้น เพือสลับตำแหน่ง
                var sql = "QueueVersionID=" + queueVersion + " AND QueueStatusID=1";
                var obj = new LawyerQueueCollection_Base(CSystems.ProcessID);
                obj.Delete(sql);
                obj.Dispose();
            }
            return true;
        }
        public int InsertLawyerQueue(int queueVersion, LawyerQueueData[] lawyerQueues)
        {
            //ลบสถานะคิวที่ยังไม่ได้ Process เท่านั้น หาก Process แล้วจะไม่ลบให้เก็บสถานะไว้ไว้ตรวจสอบการทำงาน
            if (queueVersion != 0)
            {  //ลบเฉพาะรายการที่มีสถานะที่รอคิวเท่านั้น เพือสลับตำแหน่ง
                var sql = "QueueVersionID=" + queueVersion + " AND QueueStatusID=1";
                var obj = new LawyerQueueCollection_Base(CSystems.ProcessID);
                obj.Delete(sql);
                obj.Dispose();
            }
            LawyerQueueCollection_Base lawyerQueue = new LawyerQueueCollection_Base(CSystems.ProcessID);
            var dt = lawyerQueue.CreateDataTable();
            lawyerQueue.Dispose();
            if (lawyerQueues != null)
            {
                for (int i = 0; i < lawyerQueues.Length; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["QueueID"] = i;
                    dr["QueueVersionID"] = queueVersion;
                    dr["LawyerID"] = lawyerQueues[i].LawyerID;
                    dr["Priority"] = lawyerQueues[i].Priority;
                    dr["ModifiedDate"] = DateTime.Now;
                    dr["QueueStatusID"] = 1;
                    dt.Rows.Add(dr);
                }
            }
            else 
            {
                DataRow dr = dt.NewRow();
                dr["QueueID"] = 0;
                dr["QueueVersionID"] = queueVersion;
                dr["LawyerID"] = 0;
                dr["Priority"] = 0;
                dr["QueueStatusID"] = 1;
                dr["ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
            }

            string connection = CSystems.ConnString;
            SqlConnection con = new SqlConnection(connection);
            //create object of SqlBulkCopy which help to insert  
            SqlBulkCopy objbulk = new SqlBulkCopy(con);

            //assign Destination table name  
            objbulk.DestinationTableName = "LawyerQueue";

            objbulk.ColumnMappings.Add("QueueVersionID", "QueueVersionID");
            objbulk.ColumnMappings.Add("LawyerID", "LawyerID");
            objbulk.ColumnMappings.Add("Priority", "Priority");
            objbulk.ColumnMappings.Add("QueueStatusID", "QueueStatusID");

            con.Open();
            //insert bulk Records into DataBase.  
            objbulk.WriteToServer(dt);
            con.Close();
            return queueVersion;

        }
        public int InsertOrUpdateQueueVertion(QueueVersionData req)
        {
            int qversion = 0;
            DalBase dal = new DalBase();
            try
            {
               bool IsResetQueue = false;
                _ = new QueueVersionCollection_Base(CSystems.ProcessID);
                QueueVersionCollection_Base queueVersionBase;
                if (req.QueueVersionID == 0)
                {
                    queueVersionBase = new QueueVersionCollection_Base(CSystems.ProcessID);
                    req.QueueVersionID = queueVersionBase.Insert(new QueueVersionRow
                    {
                        QueueName = req.QueueName,
                        QueueYear = req.QueueYear,
                        IsActive = req.IsActive,
                        ProvinceID = req.ProvinceID,
                        CreateDate = DalBase.SqlNowIncludePd(CSystems.ProcessID)
                    });
                    queueVersionBase.Dispose();
                }
                else
                {
                    queueVersionBase = new QueueVersionCollection_Base(CSystems.ProcessID);
                    var row = queueVersionBase.GetByPrimaryKey(req.QueueVersionID);
                    if (row != null)
                    {
                        if (req.QueueYear != row.QueueYear)
                        {
                            IsResetQueue = true;
                        }
                        row.QueueName = req.QueueName;
                        row.IsActive = req.IsActive;
                        row.ProvinceID = req.ProvinceID;
                        row.QueueYear = req.QueueYear;
                        queueVersionBase.Update(row);

                    }
                    //ลบเฉพาะรายการที่มีสถานะที่รอคิวเท่านั้น เพือสลับตำแหน่ง
                    if (IsResetQueue)
                    {
                        var sql = "QueueVersionID=" + req.QueueVersionID;
                        var obj = new LawyerQueueCollection_Base(CSystems.ProcessID);
                        obj.Delete(sql);
                        obj.Dispose();
                    }

                }
                queueVersionBase.Dispose();
                qversion = req.QueueVersionID;
            
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return qversion;
        }

        public bool UpdateLawyerQueueNote(LawyerQueueData data)
        {
            bool isPass = false;
            LawyerQueueCollection_Base lawyerQueue = new LawyerQueueCollection_Base(CSystems.ProcessID);
            var row = lawyerQueue.GetByPrimaryKey(data.QueueID);
            if (row != null)
            {
                row.QueueNote = data.QueueNote;
                row.ModifiedDate = new DalBase().GetSqlNow(CSystems.ProcessID);
                lawyerQueue.Update(row);
                isPass = true;
            }
            lawyerQueue.Dispose();
            return isPass;
        }
    }
}
