using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using JFS.Megazy.MilkyWaySolution;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Globalization;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{

    public class CaseApplicattionService
    {
        public CaseDataResposne InsertOrUpdate(CaseApplicationDataRequest request ,int UserID) {

            int caseID = request.CaseApplicationData.CaseID;
            int applicantID = request.CaseApplicantData.ApplicantID;
            int departmentID = 0;
            CaseDataResposne res = new CaseDataResposne();
            DalBase dal = new DalBase();
            try
            {
                if (request.CaseApplicationData.CaseID == 0)
                {
                    //INSERT CaseApplication 
                    CaseApplicationCollection_Base caseApplication = new CaseApplicationCollection_Base(CSystems.ProcessID);
                    CaseApplicationRow caseapplicationrow = new CaseApplicationRow
                    {
                        Subject = request.CaseApplicationData.Subject,
                        DepartmentID = request.CaseApplicationData.DepartmentID,
                        JFCaseTypeID = request.CaseApplicationData.JFCaseTypeID,
                        ChannelID = request.CaseApplicationData.ChannelID,
                        //CaseOwnerDepartmentID = request.CaseApplicationData.CaseOwnerDepartmentID,
                        ReferenceMSCCODE = request.CaseApplicationData.ReferenceMSCCODE,
                        ReferenceMSCID = request.CaseApplicationData.ReferenceMSCID,
                        // StatusID = 1,//Fix 1:รอดำเนินการ Ref Table CaseApplicationStatus
                        // WorkStepID = 1,//Fix 1:ยื่นเรื่อง Ref Table WorkStep
                        // IsAppeal = false,//false ไม่ใช่อุทธรณ์
                        RegisterDate = Helpers.Utility.ConvertStringToDate(request.CaseApplicationData.RegisterDateStr),//วันที่ยื่นคำขอ
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                        CreateDate = dal.GetSqlNow(CSystems.ProcessID),//วันที่รับเรื่อง
                        

                    };
                    //Get Province By DepartmentID
                    departmentID = request.CaseApplicationData.DepartmentID;
                    var provinceID = new DepartmentService().GetProvinceByDepartmentID(request.CaseApplicationData.DepartmentID);
                    if (provinceID != 0)
                    {
                        caseapplicationrow.ProvinceID = provinceID;
                    }
                    caseID = caseApplication.GetMaxID() + 1;
                    caseapplicationrow.CaseID = caseID;
                    caseApplication.Insert(caseapplicationrow);
                    caseApplication.Dispose();

                    //INSERT หน่วยงานเจ้าของสำนวน,คดี
                    CaseOwnerDepartmentCollection_Base caseOwnerDepartment = new CaseOwnerDepartmentCollection_Base(CSystems.ProcessID);
                    caseOwnerDepartment.DeleteByPrimaryKey(caseID, request.CaseApplicationData.DepartmentID);
                    var caseOwnerDepartmentRow = new CaseOwnerDepartmentRow
                    {
                        CaseID = caseID,
                        DepartmentID = request.CaseApplicationData.DepartmentID,
                        ProvinceID = provinceID,
                        StatusID = 1,//Fix 1:รอดำเนินการ Ref Table CaseApplicationStatus
                        WorkStepID = 1,//Fix 1:ยื่นเรื่อง Ref Table WorkStep
                        IsAppeal = false,//false ไม่ใช่อุทธรณ์
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                    };
                    caseOwnerDepartment.Insert(caseOwnerDepartmentRow);
                    caseOwnerDepartment.Dispose();
                    if(request.ChannelData != null) { 
                    if (!String.IsNullOrEmpty(request.ChannelData.ChannelName))
                    {
                        CaseApplicationChannelCollection_Base channelObj = new CaseApplicationChannelCollection_Base(CSystems.ProcessID);
                        channelObj.DeleteByPrimaryKey(caseID);
                        channelObj.InsertOnlyPlainText(new CaseApplicationChannelRow
                        {
                            CaseID = caseID,
                            ChannelName = request.ChannelData.ChannelName,
                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                        });
                        channelObj.Dispose();
                    }
                    else
                    {
                        CaseApplicationChannelCollection_Base channelObj = new CaseApplicationChannelCollection_Base(CSystems.ProcessID);
                        channelObj.DeleteByPrimaryKey(caseID);
                        channelObj.Dispose();
                    }
                    }
                    //INSERT ผู้ขอรับการช่วยเหลือ
                    CaseApplicantCollection_Base caseApplicant = new CaseApplicantCollection_Base(CSystems.ProcessID);
                    applicantID = caseApplicant.GetMaxID() + 1;
                    caseApplicant.Insert(new CaseApplicantRow
                    {
                        ApplicantID = applicantID,
                        CaseID = caseID,
                        // JFCaseNo = RunningServices.GetCaseRunning(request.CaseApplicationData.JFCaseTypeID, request.CaseApplicationData.DepartmentID),
                        FirstName = request.CaseApplicantData.FirstName,
                        LastName = request.CaseApplicantData.LastName,
                        Title = request.CaseApplicantData.Title,
                        Gender = request.CaseApplicantData.Gender,
                        RequestAmount = request.CaseApplicantData.RequestAmount,
                        HasProxy = request.CaseApplicantData.HasProxy,
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                        CreateDate = dal.GetSqlNow(CSystems.ProcessID),
                        UserCreateCaseID = UserID,
                    });
                    caseApplicant.Dispose();

                    //INSERT CaseApplicantExtension
                    CaseApplicantExtensionCollection_Base caseApplicantExtension = new CaseApplicantExtensionCollection_Base(CSystems.ProcessID);
                    var caseApplicantExtensionRow = new CaseApplicantExtensionRow
                    {
                        ApplicantID = applicantID,
                        CardID = request.CaseApplicantExtensionData.CardID,
                        CardType = request.CaseApplicantExtensionData.CardType,
                        Gender = request.CaseApplicantExtensionData.Gender,
                        DateOfBirth = Helpers.Utility.ConvertStringToDate(request.CaseApplicantExtensionData.DateOfBirthStr),
                        NationalityID = request.CaseApplicantExtensionData.NationalityID,
                        RaceID = request.CaseApplicantExtensionData.RaceID,
                        ReligionID = request.CaseApplicantExtensionData.ReligionID,
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                    };

                    if (Helpers.Utility.DateValidateInput(caseApplicantExtensionRow.DateOfBirth))
                    {
                        // Helpers.Age
                        caseApplicantExtensionRow.Age = new Helpers.Age(caseApplicantExtensionRow.DateOfBirth).Years;
                    }
                    caseApplicantExtension.Insert(caseApplicantExtensionRow);
                    caseApplicantExtension.Dispose();



                    //INSERT เรื่องหลัก เรื่องรอง
                    if (request.CaseMapCaseCategoryData != null)
                    {
                        if (request.CaseMapCaseCategoryData.CaseCategoryID > 0)
                        {
                            CaseMapCaseCategoryCollection_Base caseMapCaseCategory = new CaseMapCaseCategoryCollection_Base(CSystems.ProcessID);
                            var caseMapCaseCategoryRow = new CaseMapCaseCategoryRow
                            {
                                CaseID = caseID,
                                CaseCategoryID = request.CaseMapCaseCategoryData.CaseCategoryID,
                                OtherCategory = request.CaseMapCaseCategoryData.OtherCategory,
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                            };
                            if (request.CaseMapCaseCategoryData.CaseSubCategoryID > 0)
                            {
                                caseMapCaseCategoryRow.CaseSubCategoryID = request.CaseMapCaseCategoryData.CaseSubCategoryID;
                            };
                            caseMapCaseCategory.Insert(caseMapCaseCategoryRow);
                            caseMapCaseCategory.Dispose();
                        }
                    }
                    
                    //INSERT การศึกษา
                    if (request.EducationData.EducationLevelID > 0)
                    {
                        ApplicantEducationLevelCollection_Base applicantEducation = new ApplicantEducationLevelCollection_Base(CSystems.ProcessID);
                        applicantEducation.Insert(new ApplicantEducationLevelRow
                        {
                            ApplicantID = applicantID,
                            EducationLevelID = request.EducationData.EducationLevelID,
                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                        });
                        applicantEducation.Dispose();

                        if (!string.IsNullOrEmpty(request.EducationData.EducationOther))
                        {
                            ApplicantEducationLevelOtherCollection_Base applicantEducationOther = new ApplicantEducationLevelOtherCollection_Base(CSystems.ProcessID);
                            applicantEducationOther.Insert(new ApplicantEducationLevelOtherRow
                            {
                                ApplicantID = applicantID,
                                Education = request.EducationData.EducationOther,
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                            });
                            applicantEducationOther.Dispose();
                        }

                    }
                    //INSERT ที่อยู่
                    // List<int> AddressID = new List<int>();
                    
                    foreach (var item in request.ApplicantAddressDataRequest)
                    {
                        AddressCollection_Base addressCollection = new AddressCollection_Base(CSystems.ProcessID);
                        var addressID = addressCollection.Insert(new AddressRow
                        {
                            Address1 = item.AddressRequest.Address1,
                            HouseNo = item.AddressRequest.HouseNo,
                            VillageNo = item.AddressRequest.VillageNo,
                            Street = item.AddressRequest.Street,
                            Soi = item.AddressRequest.Soi,
                            ProvinceID = item.AddressRequest.ProvinceID,
                            DisctrictID = item.AddressRequest.DisctrictID,
                            SubdistrictID = item.AddressRequest.SubdistrictID,
                            PostCode = item.AddressRequest.PostCode,
                            Createdate = dal.GetSqlNow(CSystems.ProcessID),
                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                        });

                        ApplicantAddressCollection_Base applicantAddress = new ApplicantAddressCollection_Base(CSystems.ProcessID);
                        applicantAddress.Insert(new ApplicantAddressRow
                        {
                            AddressID = addressID,
                            ApplicantID = applicantID,
                            AddressTypeID = item.AddressTypeID,
                            IsPresentAddress = item.IsPresentAddress,
                            IsPermanentAddress = item.IsPermanentAddress,
                            TelephoneNo = item.TelephoneNo,
                            Stay = item.Stay,
                            StayUnit = "Y",//Y =ปี
                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                        });
                        applicantAddress.Dispose();
                        addressCollection.Dispose();
                    }
                    //INSERT
                    CaseApplicantMapOwnerDepartmentCollection_Base caseApplicantMapOwnerDepartment = new CaseApplicantMapOwnerDepartmentCollection_Base(CSystems.ProcessID);
                    caseApplicantMapOwnerDepartment.InsertOnlyPlainText(new CaseApplicantMapOwnerDepartmentRow
                    {
                        ApplicantID = applicantID,
                        DepartmentID = departmentID,
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)

                    });
                    caseApplicantMapOwnerDepartment.Dispose();

                    request.CaseApplicantData.CaseID = caseID;
                    request.CaseApplicantData.ApplicantID = applicantID;

                }
                else
                {
                    //Update CaseApplication 
                    CaseApplicationCollection_Base caseApplication = new CaseApplicationCollection_Base(CSystems.ProcessID);
                    var caseapplicationrow = caseApplication.GetByPrimaryKey(request.CaseApplicationData.CaseID);
                    if (caseapplicationrow != null)
                    {
                        // caseapplicationrow.CaseOwnerDepartmentID = request.CaseApplicationData.CaseOwnerDepartmentID;
                        caseapplicationrow.Subject = request.CaseApplicationData.Subject;
                        caseapplicationrow.ChannelID = request.CaseApplicationData.ChannelID;
                        caseapplicationrow.RegisterDate = Helpers.Utility.ConvertStringToDate(request.CaseApplicationData.RegisterDateStr);
                        caseapplicationrow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                        departmentID = request.CaseApplicationData.DepartmentID;
                        var provinceID = new DepartmentService().GetProvinceByDepartmentID(request.CaseApplicationData.DepartmentID);
                        if (provinceID != 0)
                        {
                            caseapplicationrow.ProvinceID = provinceID;
                        }
                        caseApplication.UpdateOnlyPlainText(caseapplicationrow);
                        caseApplication.Dispose();

                        //INSERT หน่วยงานเจ้าของสำนวน,คดี
                        CaseOwnerDepartmentCollection_Base caseOwnerDepartment = new CaseOwnerDepartmentCollection_Base(CSystems.ProcessID);
                        var caseOwnerDepartmentRow = caseOwnerDepartment.GetByPrimaryKey(caseapplicationrow.CaseID, request.CaseApplicationData.DepartmentID);
                        if (caseOwnerDepartmentRow != null)
                        {
                            //caseOwnerDepartmentRow.DepartmentID = request.CaseApplicationData.DepartmentID;
                            caseOwnerDepartmentRow.ProvinceID = provinceID;
                            caseOwnerDepartmentRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                            caseOwnerDepartment.Update(caseOwnerDepartmentRow);
                        }
                        else
                        {
                            caseOwnerDepartment.Insert(new CaseOwnerDepartmentRow
                            {
                                CaseID = request.CaseApplicationData.CaseID,
                                DepartmentID = request.CaseApplicationData.DepartmentID,
                                ProvinceID = provinceID,
                                StatusID = 1,//Fix 1:รอดำเนินการ Ref Table CaseApplicationStatus
                                WorkStepID = 1,//Fix 1:ยื่นเรื่อง Ref Table WorkStep
                                IsAppeal = false,//false ไม่ใช่อุทธรณ์
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                            });
                        }                      
                        caseOwnerDepartment.Dispose();
                        if(request.ChannelData != null)
                        {
                            if (!String.IsNullOrEmpty(request.ChannelData.ChannelName))
                            {
                                CaseApplicationChannelCollection_Base channelObj = new CaseApplicationChannelCollection_Base(CSystems.ProcessID);
                                channelObj.DeleteByPrimaryKey(caseID);
                                channelObj.InsertOnlyPlainText(new CaseApplicationChannelRow
                                {
                                    CaseID = caseID,
                                    ChannelName = request.ChannelData.ChannelName,
                                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                });
                                channelObj.Dispose();
                            }
                            else
                            {
                                CaseApplicationChannelCollection_Base channelObj = new CaseApplicationChannelCollection_Base(CSystems.ProcessID);
                                channelObj.DeleteByPrimaryKey(caseID);
                                channelObj.Dispose();
                            }
                        }
                       

                        //UPDATE ผู้ขอรับการช่วยเหลือ
                        CaseApplicantCollection_Base caseApplicant = new CaseApplicantCollection_Base(CSystems.ProcessID);
                        var caseApplicantRow = caseApplicant.GetByPrimaryKey(request.CaseApplicantData.ApplicantID);
                        if (caseApplicantRow != null)
                        {
                            caseApplicantRow.FirstName = request.CaseApplicantData.FirstName;
                            caseApplicantRow.LastName = request.CaseApplicantData.LastName;
                            caseApplicantRow.Title = request.CaseApplicantData.Title;
                            caseApplicantRow.RequestAmount = request.CaseApplicantData.RequestAmount;
                            // caseApplicantRow.HasProxy = request.CaseApplicantData.HasProxy;
                            caseApplicantRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                            caseApplicant.UpdateOnlyPlainText(caseApplicantRow);
                        }
                        else {
                            //กรณีทีมาเป็นหมู่คณะ จะมีเลขที่ CaseID แต่  ApplicantID =0 (เพิ่มผู้ร้องขอใหม่)
                            caseApplicant = new CaseApplicantCollection_Base(CSystems.ProcessID);
                            applicantID = caseApplicant.GetMaxID() + 1;
                            caseApplicant.Insert(new CaseApplicantRow
                            {
                                ApplicantID = applicantID,
                                CaseID = request.CaseApplicantData.CaseID,
                                FirstName = request.CaseApplicantData.FirstName,
                                LastName = request.CaseApplicantData.LastName,
                                Title = request.CaseApplicantData.Title,
                                Gender = request.CaseApplicantData.Gender,
                                RequestAmount = request.CaseApplicantData.RequestAmount,
                                HasProxy = request.CaseApplicantData.HasProxy,
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                                CreateDate = dal.GetSqlNow(CSystems.ProcessID),
                                UserCreateCaseID = UserID
                            });
                            request.CaseApplicantData.ApplicantID = applicantID;// กำหนดค่า ApplicantID ให้ผู้ของใหม่(กรณีหมู่คณะ)
                        }
                        caseApplicant.Dispose();

                        //UPDATE CaseApplicantExtension
                        CaseApplicantExtensionCollection_Base caseApplicantExtension = new CaseApplicantExtensionCollection_Base(CSystems.ProcessID);
                        var caseApplicantExtensionRow = caseApplicantExtension.GetByPrimaryKey(request.CaseApplicantData.ApplicantID);
                        if (caseApplicantExtensionRow != null)
                        {
                            caseApplicantExtensionRow.CardID = request.CaseApplicantExtensionData.CardID;
                            caseApplicantExtensionRow.CardType = request.CaseApplicantExtensionData.CardType;
                            caseApplicantExtensionRow.Gender = request.CaseApplicantExtensionData.Gender;
                            caseApplicantExtensionRow.DateOfBirth = Helpers.Utility.ConvertStringToDate(request.CaseApplicantExtensionData.DateOfBirthStr);
                            caseApplicantExtensionRow.NationalityID = request.CaseApplicantExtensionData.NationalityID;
                            caseApplicantExtensionRow.RaceID = request.CaseApplicantExtensionData.RaceID;
                            caseApplicantExtensionRow.ReligionID = request.CaseApplicantExtensionData.ReligionID;
                            caseApplicantExtensionRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                            if (Helpers.Utility.DateValidateInput(caseApplicantExtensionRow.DateOfBirth))
                            {
                                caseApplicantExtensionRow.Age = new Helpers.Age(caseApplicantExtensionRow.DateOfBirth).Years;
                            }
                            caseApplicantExtension.Update(caseApplicantExtensionRow);
                        }
                        else {
                            //กรณีทีมาเป็นหมู่คณะ จะมีเลขที่ CaseID แต่  ApplicantID =0 (เพิ่มผู้ร้องขอใหม่)
                            caseApplicantExtension = new CaseApplicantExtensionCollection_Base(CSystems.ProcessID);
                            var caseApplicantExtensionRow2 = new CaseApplicantExtensionRow
                            {
                                ApplicantID = request.CaseApplicantData.ApplicantID,
                                CardID = request.CaseApplicantExtensionData.CardID,
                                CardType = request.CaseApplicantExtensionData.CardType,
                                Gender = request.CaseApplicantExtensionData.Gender,
                                DateOfBirth = Helpers.Utility.ConvertStringToDate(request.CaseApplicantExtensionData.DateOfBirthStr),
                                NationalityID = request.CaseApplicantExtensionData.NationalityID,
                                RaceID = request.CaseApplicantExtensionData.RaceID,
                                ReligionID = request.CaseApplicantExtensionData.ReligionID,
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                            };

                            if (Helpers.Utility.DateValidateInput(caseApplicantExtensionRow2.DateOfBirth))
                            {
                                // Helpers.Age
                                caseApplicantExtensionRow2.Age = new Helpers.Age(caseApplicantExtensionRow2.DateOfBirth).Years;
                            }
                            caseApplicantExtension.Insert(caseApplicantExtensionRow2);
                        }
                        caseApplicantExtension.Dispose();

                        //UPDATE เรื่องหลัก เรื่องรอง
                        if (request.CaseMapCaseCategoryData != null)
                        {
                            if (request.CaseMapCaseCategoryData.CaseCategoryID > 0)
                            {
                                CaseMapCaseCategoryCollection_Base caseMapCaseCategory = new CaseMapCaseCategoryCollection_Base(CSystems.ProcessID);
                                caseMapCaseCategory.DeleteByCaseID(request.CaseApplicationData.CaseID);
                                var caseMapCaseCategoryRow = new CaseMapCaseCategoryRow
                                {
                                    CaseID = request.CaseApplicationData.CaseID,
                                    CaseCategoryID = request.CaseMapCaseCategoryData.CaseCategoryID,
                                    OtherCategory = request.CaseMapCaseCategoryData.OtherCategory,
                                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)

                                };
                                if (request.CaseMapCaseCategoryData.CaseSubCategoryID > 0)
                                {
                                    caseMapCaseCategoryRow.CaseSubCategoryID = request.CaseMapCaseCategoryData.CaseSubCategoryID;
                                };
                                caseMapCaseCategory.Insert(caseMapCaseCategoryRow);
                                caseMapCaseCategory.Dispose();
                            }
                        }
                        //UPDATE การศึกษา
                        ApplicantEducationLevelCollection_Base applicantEducation = new ApplicantEducationLevelCollection_Base(CSystems.ProcessID);
                        applicantEducation.DeleteByApplicantID(request.CaseApplicantData.ApplicantID);
                        applicantEducation.Insert(new ApplicantEducationLevelRow
                        {
                            ApplicantID = request.CaseApplicantData.ApplicantID,
                            EducationLevelID = request.EducationData.EducationLevelID,
                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                        });
                        applicantEducation.Dispose();

                        if (!string.IsNullOrEmpty(request.EducationData.EducationOther))
                        {
                            ApplicantEducationLevelOtherCollection_Base applicantEducationOther = new ApplicantEducationLevelOtherCollection_Base(CSystems.ProcessID);
                            applicantEducationOther.DeleteByApplicantID(request.CaseApplicantData.ApplicantID);
                            applicantEducationOther.Insert(new ApplicantEducationLevelOtherRow
                            {
                                ApplicantID = request.CaseApplicantData.ApplicantID,
                                Education = request.EducationData.EducationOther,
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                            });
                            applicantEducationOther.Dispose();
                        }
                        else
                        {
                            ApplicantEducationLevelOtherCollection_Base applicantEducationOther = new ApplicantEducationLevelOtherCollection_Base(CSystems.ProcessID);
                            applicantEducationOther.DeleteByApplicantID(request.CaseApplicantData.ApplicantID);                           
                            applicantEducationOther.Dispose();
                        }

                        //UPDATE ที่อยู่
                       
                        foreach (var item in request.ApplicantAddressDataRequest)
                        {
                            ApplicantAddressCollection_Base applicantAddress = new ApplicantAddressCollection_Base(CSystems.ProcessID);
                            AddressCollection_Base addressCollection = new AddressCollection_Base(CSystems.ProcessID);
                            addressCollection = new AddressCollection_Base(CSystems.ProcessID);
                            if (item.AddressID != 0)
                            {
                                var addressRow = addressCollection.GetByPrimaryKey(item.AddressID);
                                if (addressRow != null)
                                {
                                    addressRow.Address1 = item.AddressRequest.Address1;
                                    addressRow.HouseNo = item.AddressRequest.HouseNo;
                                    addressRow.VillageNo = item.AddressRequest.VillageNo;
                                    addressRow.Street = item.AddressRequest.Street;
                                    addressRow.Soi = item.AddressRequest.Soi;
                                    addressRow.ProvinceID = item.AddressRequest.ProvinceID;
                                    addressRow.DisctrictID = item.AddressRequest.DisctrictID;
                                    addressRow.SubdistrictID = item.AddressRequest.SubdistrictID;
                                    addressRow.PostCode = item.AddressRequest.PostCode;
                                    addressRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                                    addressCollection.UpdateOnlyPlainText(addressRow);

                                }
                                applicantAddress = new ApplicantAddressCollection_Base(CSystems.ProcessID);
                                applicantAddress.GetByPrimaryKey(applicantID, item.AddressID);
                                applicantAddress.UpdateOnlyPlainText(new ApplicantAddressRow
                                {
                                    AddressID = item.AddressID,
                                    ApplicantID = request.CaseApplicantData.ApplicantID,
                                    AddressTypeID = item.AddressTypeID,
                                    IsPresentAddress = item.IsPresentAddress,
                                    IsPermanentAddress = item.IsPermanentAddress,
                                    TelephoneNo = item.TelephoneNo,
                                    Stay = item.Stay,
                                    StayUnit = item.StayUnit,
                                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                });
                                applicantAddress.Dispose();
                            }
                            else
                            {

                                //กรณีทีมาเป็นหมู่คณะ จะมีเลขที่ CaseID แต่  AddressID =0 (เพิ่มผู้ร้องขอใหม่)
                                var addressID = addressCollection.Insert(new AddressRow
                                {
                                    Address1 = item.AddressRequest.Address1,
                                    HouseNo = item.AddressRequest.HouseNo,
                                    VillageNo = item.AddressRequest.VillageNo,
                                    Street = item.AddressRequest.Street,
                                    Soi = item.AddressRequest.Soi,
                                    ProvinceID = item.AddressRequest.ProvinceID,
                                    DisctrictID = item.AddressRequest.DisctrictID,
                                    SubdistrictID = item.AddressRequest.SubdistrictID,
                                    PostCode = item.AddressRequest.PostCode,
                                    Createdate = dal.GetSqlNow(CSystems.ProcessID),
                                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                });
                                applicantAddress = new ApplicantAddressCollection_Base(CSystems.ProcessID);
                                applicantAddress.Insert(new ApplicantAddressRow
                                {
                                    AddressID = addressID,
                                    ApplicantID = request.CaseApplicantData.ApplicantID,
                                    AddressTypeID = item.AddressTypeID,
                                    IsPresentAddress = item.IsPresentAddress,
                                    IsPermanentAddress = item.IsPermanentAddress,
                                    TelephoneNo = item.TelephoneNo,
                                    Stay = item.Stay,
                                    StayUnit = item.StayUnit,
                                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                });
                                applicantAddress.Dispose();

                            }
                            addressCollection.Dispose();
                        }
                        
                        //Updata
                        CaseApplicantMapOwnerDepartmentCollection_Base caseApplicantMapOwnerDepartment = new CaseApplicantMapOwnerDepartmentCollection_Base(CSystems.ProcessID);
                        var caseApplicantMapOwnerDepartmentRow = caseApplicantMapOwnerDepartment.GetByPrimaryKey(request.CaseApplicantData.ApplicantID,request.CaseApplicationData.DepartmentID);
                        if (caseApplicantMapOwnerDepartmentRow != null)
                        {
                            caseApplicantMapOwnerDepartment.UpdateOnlyPlainText(new CaseApplicantMapOwnerDepartmentRow
                            {
                                ApplicantID = request.CaseApplicantData.ApplicantID,
                                DepartmentID = request.CaseApplicationData.DepartmentID,
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)

                            });
                        }
                        else
                        {
                            //กรณีหมู่คณะ
                            caseApplicantMapOwnerDepartment.InsertOnlyPlainText(new CaseApplicantMapOwnerDepartmentRow
                            {
                                ApplicantID = request.CaseApplicantData.ApplicantID,
                                DepartmentID = request.CaseApplicationData.DepartmentID,
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)

                            });
                        }                        
                        caseApplicantMapOwnerDepartment.Dispose();

                    }

                }
                res.ApplicantID = request.CaseApplicantData.ApplicantID;
                res.CaseID = request.CaseApplicantData.CaseID;
                res.ProxyID = 0;
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return res;

        }
        public bool DuplicateApplication(DuplicateDataRequest data)
        {
            bool isPass = false;
            DalBase dal = new DalBase();
            try
            {
                dal.DbBeginTransaction(CSystems.ProcessID);
                List<SqlParameter> listParameter = new List<SqlParameter>();
                string sql = "";
                SqlParameter parameter = new SqlParameter();
                parameter = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = data.CaseID };
                listParameter.Add(parameter);
                parameter = new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = data.ApplicantID };
                listParameter.Add(parameter);
                parameter = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = data.OldDepartmentID };
                listParameter.Add(parameter);
                sql = "CaseID = @CaseID AND ApplicantID = @ApplicantID AND DepartmentID = @DepartmentID";
                View_ApplicationCollection_Base v_app = new View_ApplicationCollection_Base(CSystems.ProcessID);
                var v_appRow = v_app.GetRow(listParameter, sql);
                v_app.Dispose();
                if (v_appRow != null)
                {
                    int nCaseID = 0;
                    int nApplicantID = 0;
                    //type4
                    if (v_appRow.JFCaseTypeID == 4)
                    {
                        CaseApplicationCollection_Base caseApplication = new CaseApplicationCollection_Base(CSystems.ProcessID);
                        CaseApplicationRow caseapplicationrow = caseApplication.GetByPrimaryKey(data.CaseID);
                        nCaseID = caseApplication.GetMaxID() + 1;
                        if (caseapplicationrow != null)
                        {

                            caseapplicationrow.CaseID = nCaseID;
                            caseapplicationrow.Subject = v_appRow.Subject + "(คัดลอก)";
                            caseapplicationrow.DepartmentID = data.DepartmentID;
                            // caseapplicationrow.CaseOwnerDepartmentID = data.DepartmentID;
                            caseapplicationrow.JFCaseTypeID = data.JFCaseTypeID;
                            caseapplicationrow.ChannelID = caseapplicationrow.ChannelID;
                            caseapplicationrow.ReferenceMSCCODE = v_appRow.ReferenceMSCCODE;
                            caseapplicationrow.ReferenceMSCID = v_appRow.ReferenceMSCID;
                            // caseapplicationrow.StatusID = data.StatusID;//Fix 1:ดำเนินการ Ref Table CaseApplicationStatus
                            //caseapplicationrow.IsAppeal = false;//false ไม่ใช่อุทธรณ์
                            // caseapplicationrow.WorkStepID = data.WorkStepID;//Fix 1:รับเรื่อง Ref Table WorkStep
                            caseapplicationrow.RegisterDate = Helpers.Utility.ConvertStringToDate(data.RegisterDateStr);
                            caseapplicationrow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                            //Get Province By DepartmentID
                            var provinceID = new DepartmentService().GetProvinceByDepartmentID(data.DepartmentID);
                            if (provinceID != 0)
                            {
                                caseapplicationrow.ProvinceID = provinceID;
                            }
                            caseApplication.Insert(caseapplicationrow);
                            caseApplication.Dispose();
                            CaseApplicationProjectService service = new CaseApplicationProjectService();
                            //inset case applicant
                            CaseApplicantCollection_Base caseApplicant = new CaseApplicantCollection_Base(CSystems.ProcessID);
                            nApplicantID = caseApplicant.GetMaxID() + 1;

                            caseApplicant.Insert(new CaseApplicantRow
                            {
                                ApplicantID = nApplicantID,
                                CaseID = caseapplicationrow.CaseID,
                                FirstName = v_appRow.FirstName,
                                LastName = v_appRow.LastName,
                                Gender = v_appRow.Gender == "N/A" ? "" : v_appRow.Gender.ToUpper(),
                                Title = v_appRow.Title,
                                RequestAmount = v_appRow.RequestAmount,
                                HasProxy = v_appRow.HasProxy,
                                CreateDate = dal.GetSqlNow(CSystems.ProcessID),
                                UserCreateCaseID = data.UserID,
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                            });
                            caseApplicant.Dispose();
                            CaseApplicantExtensionCollection_Base caseEx = new CaseApplicantExtensionCollection_Base(CSystems.ProcessID);
                            var caseExRow = caseEx.GetByPrimaryKey(nApplicantID);

                            if (caseExRow == null)
                            {
                                caseEx.InsertOnlyPlainText(new CaseApplicantExtensionRow
                                {
                                    ApplicantID = nApplicantID,
                                    CardID = v_appRow.CardID,
                                    CardType = v_appRow.CardType,
                                    DateOfBirth = v_appRow.DateOfBirth,
                                    Age = v_appRow.Age,
                                    ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID)
                                });
                            }

                            //insert case project
                            CaseProjectCollection_Base caseProject = new CaseProjectCollection_Base(CSystems.ProcessID);
                            CaseProjectRow caseProjectRow = caseProject.GetByPrimaryKey(data.CaseID);
                            caseProject.Dispose();
                            if (caseProjectRow != null)
                            {
                                service.InsertOrupdateCaseProject(new CaseProjectData
                                {
                                    CaseID = caseapplicationrow.CaseID,
                                    ProposerTypeID = caseProjectRow.ProposerTypeID,
                                    ProposerTypeOther = caseProjectRow.ProposerTypeOther,
                                    ProjectTitle = caseProjectRow.ProjectTitle,
                                    ProposerEN = caseProjectRow.ProposerEN,
                                    ObjectiveToHelp = caseProjectRow.ObjectiveToHelp,
                                    ProjectInAction = caseProjectRow.ProjectInAction,
                                    Portfolio = caseProjectRow.Portfolio,
                                    ProjectObjective = caseProjectRow.ProjectObjective,
                                    ProjectResult = caseProjectRow.ProjectResult,
                                    ProjectTarget = caseProjectRow.ProjectTarget,
                                }, caseapplicationrow.CaseID);
                            }

                            //แหล่งความช่วยเหลือที่ได้รับในปัจจุบัน
                            CaseProjectSourceFundCollection_Base sourcefund = new CaseProjectSourceFundCollection_Base(CSystems.ProcessID);
                            var CaseProjectSourceFundRow = sourcefund.GetByCaseID(data.CaseID);
                            sourcefund.Dispose();
                            if (CaseProjectSourceFundRow.Length > 0)
                            {
                                var CaseProjectSourceFundData = (from q in CaseProjectSourceFundRow
                                                                 select new CaseProjectSourceFundData
                                                                 {
                                                                     CaseID = q.CaseID,
                                                                     SourceFundName = q.SourceFundName,
                                                                     Amount = q.Amount
                                                                 }).ToArray();
                                service.InsertCaseProjectSourceFund(caseapplicationrow.CaseID, CaseProjectSourceFundData);

                            }

                            //ลักษณะโครงการที่ขอรับความช่วยเหลือเงินกองทุน
                            CaseProjectCharacteristicsCollection_Base characteristics = new CaseProjectCharacteristicsCollection_Base(CSystems.ProcessID);
                            var CaseProjectCharacteristicsRow = characteristics.GetByCaseID(data.CaseID);
                            characteristics.Dispose();
                            if (CaseProjectCharacteristicsRow.Length > 0)
                            {
                                var CaseProjectCharacteristicsData = (from q in CaseProjectCharacteristicsRow
                                                                      select new CaseProjectCharacteristicsData
                                                                      {
                                                                          CharacteristicID = q.CharacteristicID,
                                                                          CaseID = q.CaseID,
                                                                          Remark = q.Remark
                                                                      }).ToArray();
                                service.InsertOrUpdateCaseProjectCharacteristics(caseapplicationrow.CaseID, CaseProjectCharacteristicsData);

                            }

                            //ตรวจสอบเอกสาร
                            CaseProjectDocumentCheckCollection_Base docdumentCheck = new CaseProjectDocumentCheckCollection_Base(CSystems.ProcessID);
                            var CaseProjectDocumentCheckRow = docdumentCheck.GetByCaseID(data.CaseID);
                            docdumentCheck.Dispose();
                            if (CaseProjectDocumentCheckRow.Length > 0)
                            {
                                var CaseProjectDocumentCheckData = (from q in CaseProjectDocumentCheckRow
                                                                    select new CaseProjectDocumentCheckData
                                                                    {
                                                                        DocumentID = q.DocumentID,
                                                                        CaseID = q.CaseID,
                                                                        Remark = q.Remark
                                                                    }).ToArray();
                                service.InsertOrUpdateCaseProjectDocumentCheck(CaseProjectDocumentCheckData, caseapplicationrow.CaseID);
                            }

                            //รายชื่อบุคคลที่น่าเชื่อถือ
                            CaseProjectReferencePersonCollection_Base referencePerson = new CaseProjectReferencePersonCollection_Base(CSystems.ProcessID);
                            var CaseProjectReferencePersonRow = referencePerson.GetByCaseID(data.CaseID);
                            referencePerson.Dispose();
                            if (CaseProjectReferencePersonRow.Length > 0)
                            {
                                var CaseProjectReferencePersonData = (from q in CaseProjectReferencePersonRow
                                                                      select new CaseProjectReferencePersonData
                                                                      {
                                                                          RefPersonName = q.RefPersonName,
                                                                          CaseID = q.CaseID,
                                                                          RefPersonTelephonNo = q.RefPersonTelephonNo,
                                                                          RefPersonAddress = q.RefPersonAddress
                                                                      }).ToArray();
                                service.InsertProjectReferencePerson(CaseProjectReferencePersonData, caseapplicationrow.CaseID);

                            }

                            //สถานที่ยื่นโครงการ
                            service.InsertCaseOwnerDepartment(nApplicantID, caseapplicationrow.CaseID, caseapplicationrow.DepartmentID);


                            int projectAddressID = 0;
                            ProjectAddressCollection_Base projectAddress = new ProjectAddressCollection_Base(CSystems.ProcessID);
                            var projectAddressRow = projectAddress.GetRow(new List<SqlParameter>(), $"CaseID = {data.CaseID}");
                            projectAddress.Dispose();
                            if (projectAddressRow != null)
                            {
                                AddressCollection_Base addressCollection = new AddressCollection_Base(CSystems.ProcessID);
                                var addressRow = addressCollection.GetByPrimaryKey(projectAddressRow.AddressID);
                                if (addressRow != null)
                                {
                                    projectAddressID = addressCollection.Insert(new AddressRow
                                    {
                                        Address1 = addressRow.Address1,
                                        HouseNo = addressRow.HouseNo,
                                        VillageNo = addressRow.VillageNo,
                                        Street = addressRow.Street,
                                        Soi = addressRow.Soi,
                                        ProvinceID = addressRow.ProvinceID,
                                        DisctrictID = addressRow.DisctrictID,
                                        SubdistrictID = addressRow.SubdistrictID,
                                        PostCode = addressRow.PostCode,
                                        Createdate = dal.GetSqlNow(CSystems.ProcessID),
                                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                    });
                                }

                                addressCollection.Dispose();
                                service.InsertProjectAddress(new ProjectAddressData
                                {
                                    Email = projectAddressRow.Email,
                                    TelephoneNo = projectAddressRow.TelephoneNo,
                                    FaxNo = projectAddressRow.FaxNo
                                }, projectAddressID, caseapplicationrow.CaseID);
                            }

                            //ผู้ประสานงานโครงการ

                            ProjectContactPersonCollection_Base projectPerson = new ProjectContactPersonCollection_Base(CSystems.ProcessID);
                            var projectContactRow = projectPerson.GetRow(new List<SqlParameter>(), $"CaseID = {data.CaseID}");
                            projectPerson.Dispose();
                            int contactAddressID = 0;
                            int ProjectContactPersonID = 0;
                            if (projectContactRow != null)
                            {
                                CoordinatorAddressCollection_Base coordinatorAddress = new CoordinatorAddressCollection_Base(CSystems.ProcessID);
                                var coordinatorAddressRow = coordinatorAddress.GetRow(new List<SqlParameter>(), $"ContactID = {projectContactRow.ContactID}");
                                coordinatorAddress.Dispose();
                                if (coordinatorAddressRow != null)
                                {
                                    AddressCollection_Base addressCollection = new AddressCollection_Base(CSystems.ProcessID);
                                    var addressRow = addressCollection.GetByPrimaryKey(coordinatorAddressRow.AddressID);
                                    if (addressRow != null)
                                    {
                                        contactAddressID = addressCollection.Insert(new AddressRow
                                        {
                                            Address1 = addressRow.Address1,
                                            HouseNo = addressRow.HouseNo,
                                            VillageNo = addressRow.VillageNo,
                                            Street = addressRow.Street,
                                            Soi = addressRow.Soi,
                                            ProvinceID = addressRow.ProvinceID,
                                            DisctrictID = addressRow.DisctrictID,
                                            SubdistrictID = addressRow.SubdistrictID,
                                            PostCode = addressRow.PostCode,
                                            Createdate = dal.GetSqlNow(CSystems.ProcessID),
                                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                        });
                                    }

                                    addressCollection.Dispose();
                                }
                                ProjectContactPersonID = service.InsertOrupdateProjectContactPerson(new ProjectContactPersonData
                                {
                                    FirstName = projectContactRow.FirstName,
                                    LastName = projectContactRow.LastName,
                                    Email = projectContactRow.Email,
                                    TelephoneNo = projectContactRow.TelephoneNo,
                                    FaxNo = projectContactRow.FaxNo
                                }, caseapplicationrow.CaseID);
                                service.InsertCoordinatorAddress(ProjectContactPersonID, contactAddressID);
                            }

                        }
                    }
                    //else if (v_appRow.JFCaseTypeID == 5)
                    //{

                    //}
                    else
                    {
                        //INSERT CaseApplication 
                        CaseApplicationCollection_Base caseApplication = new CaseApplicationCollection_Base(CSystems.ProcessID);
                        CaseApplicationRow caseapplicationrow = caseApplication.GetByPrimaryKey(data.CaseID);
                        caseApplication.Dispose();
                        if (caseapplicationrow != null)
                        {
                            caseApplication = new CaseApplicationCollection_Base(CSystems.ProcessID);
                            caseapplicationrow = new CaseApplicationRow
                            {
                                Subject = v_appRow.Subject + "(คัดลอก)",//รับค่า
                                DepartmentID = data.DepartmentID,
                                JFCaseTypeID = data.JFCaseTypeID,
                                ChannelID = caseapplicationrow.ChannelID,
                                //CaseOwnerDepartmentID = request.CaseApplicationData.CaseOwnerDepartmentID,
                                ReferenceMSCCODE = v_appRow.ReferenceMSCCODE,
                                ReferenceMSCID = v_appRow.ReferenceMSCID,//กรณีคัดลอกสำนวนข้อควรระวังเมื่อปิดสำนวนแล้วแจ้งเรื่อง msc
                                RegisterDate = Helpers.Utility.ConvertStringToDate(data.RegisterDateStr),//วันที่ยื่นคำขอ
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                                CreateDate = dal.GetSqlNow(CSystems.ProcessID),//วันที่รับเรื่อง


                            };
                            //Get Province By DepartmentID
                            //departmentID = request.CaseApplicationData.DepartmentID;
                            var provinceID = new DepartmentService().GetProvinceByDepartmentID(data.DepartmentID);
                            if (provinceID != 0)
                            {
                                caseapplicationrow.ProvinceID = provinceID;
                            }
                            nCaseID = caseApplication.GetMaxID() + 1;
                            caseapplicationrow.CaseID = nCaseID;
                            caseApplication.Insert(caseapplicationrow);
                            caseApplication.Dispose();




                            //INSERT หน่วยงานเจ้าของสำนวน,คดี
                            CaseOwnerDepartmentCollection_Base caseOwnerDepartment = new CaseOwnerDepartmentCollection_Base(CSystems.ProcessID);
                            caseOwnerDepartment.DeleteByPrimaryKey(nCaseID, data.DepartmentID);
                            var caseOwnerDepartmentRow = new CaseOwnerDepartmentRow
                            {
                                CaseID = nCaseID,
                                DepartmentID = data.DepartmentID,
                                ProvinceID = provinceID,
                                StatusID = 1,//Fix 1:รอดำเนินการ Ref Table CaseApplicationStatus
                                WorkStepID = 1,//Fix 1:ยื่นเรื่อง Ref Table WorkStep
                                IsAppeal = false,//false ไม่ใช่อุทธรณ์
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                            };
                            caseOwnerDepartment.Insert(caseOwnerDepartmentRow);
                            caseOwnerDepartment.Dispose();
                            CaseApplicationChannelCollection_Base channelObj = new CaseApplicationChannelCollection_Base(CSystems.ProcessID);
                            var ChannelData = channelObj.GetByPrimaryKey(data.CaseID);
                            channelObj.Dispose();
                            if (ChannelData != null)
                            {
                                if (!String.IsNullOrEmpty(ChannelData.ChannelName))
                                {
                                    channelObj = new CaseApplicationChannelCollection_Base(CSystems.ProcessID);
                                    channelObj.DeleteByPrimaryKey(nCaseID);
                                    channelObj.InsertOnlyPlainText(new CaseApplicationChannelRow
                                    {
                                        CaseID = nCaseID,
                                        ChannelName = ChannelData.ChannelName,
                                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                    });
                                    channelObj.Dispose();
                                }
                                else
                                {
                                    channelObj = new CaseApplicationChannelCollection_Base(CSystems.ProcessID);
                                    channelObj.DeleteByPrimaryKey(nCaseID);
                                    channelObj.Dispose();
                                }
                            }
                            //INSERT ผู้ขอรับการช่วยเหลือ
                            CaseApplicantCollection_Base caseApplicant = new CaseApplicantCollection_Base(CSystems.ProcessID);
                            nApplicantID = caseApplicant.GetMaxID() + 1;
                            caseApplicant.Insert(new CaseApplicantRow
                            {
                                ApplicantID = nApplicantID,
                                CaseID = nCaseID,
                                FirstName = v_appRow.FirstName,
                                LastName = v_appRow.LastName,
                                Title = v_appRow.Title,
                                Gender = v_appRow.Gender == "N/A" ? "" : v_appRow.Gender,
                                RequestAmount = v_appRow.RequestAmount,
                                HasProxy = v_appRow.HasProxy,
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                                CreateDate = dal.GetSqlNow(CSystems.ProcessID),
                                UserCreateCaseID = data.UserID
                            });
                            caseApplicant.Dispose();

                            //INSERT CaseApplicantExtension
                            CaseApplicantExtensionCollection_Base caseApplicantExtension = new CaseApplicantExtensionCollection_Base(CSystems.ProcessID);
                            var caseApplicantExtensionRow = new CaseApplicantExtensionRow
                            {
                                ApplicantID = nApplicantID,
                                CardID = v_appRow.CardID,
                                CardType = v_appRow.CardType,
                                Gender = v_appRow.Gender == "N/A" ? "" : v_appRow.Gender,
                                DateOfBirth = v_appRow.DateOfBirth,
                                NationalityID = v_appRow.NationalityID,
                                RaceID = v_appRow.RaceID,
                                ReligionID = v_appRow.ReligionID,
                                Age = v_appRow.Age,
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                            };
                            caseApplicantExtension.Insert(caseApplicantExtensionRow);
                            caseApplicantExtension.Dispose();

                            //religionother
                            ApplicantReligionOtherCollection_Base religionOther = new ApplicantReligionOtherCollection_Base(CSystems.ProcessID);
                            var religionOtherRow = religionOther.GetByPrimaryKey(data.ApplicantID);
                            religionOther.Dispose();
                            if (religionOtherRow != null)
                            {
                                if (!string.IsNullOrWhiteSpace(religionOtherRow.ReligionOther))
                                {
                                    InsertApplicantReligionOther(nApplicantID, religionOtherRow.ReligionOther);
                                }
                                else if (string.IsNullOrWhiteSpace(religionOtherRow.ReligionOther))
                                {
                                    religionOther = new ApplicantReligionOtherCollection_Base(CSystems.ProcessID);
                                    religionOther.DeleteByApplicantID(nApplicantID);
                                    religionOther.Dispose();
                                }
                            }



                            //INSERT เรื่องหลัก เรื่องรอง
                            CaseMapCaseCategoryCollection_Base caseMapCaseCategory = new CaseMapCaseCategoryCollection_Base(CSystems.ProcessID);
                            listParameter = new List<SqlParameter>();
                            listParameter.Add(new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = data.CaseID });
                            var CaseMapCaseCategoryData = caseMapCaseCategory.GetRow(listParameter, "CaseID = @CaseID");
                            caseMapCaseCategory.Dispose();

                            if (CaseMapCaseCategoryData != null)
                            {
                                if (CaseMapCaseCategoryData.CaseCategoryID > 0)
                                {
                                    caseMapCaseCategory = new CaseMapCaseCategoryCollection_Base(CSystems.ProcessID);
                                    var caseMapCaseCategoryRow = new CaseMapCaseCategoryRow
                                    {
                                        CaseID = nCaseID,
                                        CaseCategoryID = CaseMapCaseCategoryData.CaseCategoryID,
                                        OtherCategory = CaseMapCaseCategoryData.OtherCategory,
                                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                    };
                                    if (CaseMapCaseCategoryData.CaseSubCategoryID > 0)
                                    {
                                        caseMapCaseCategoryRow.CaseSubCategoryID = CaseMapCaseCategoryData.CaseSubCategoryID;
                                    };
                                    caseMapCaseCategory.Insert(caseMapCaseCategoryRow);
                                    caseMapCaseCategory.Dispose();
                                }
                            }

                            //INSERT การศึกษา
                            ApplicantEducationLevelCollection_Base applicantEducation = new ApplicantEducationLevelCollection_Base(CSystems.ProcessID);
                            listParameter = new List<SqlParameter>();
                            listParameter.Add(new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = data.ApplicantID });
                            var EducationData = applicantEducation.GetRow(listParameter, "ApplicantID = @ApplicantID");
                            applicantEducation.Dispose();
                            if (EducationData.EducationLevelID > 0)
                            {
                                applicantEducation = new ApplicantEducationLevelCollection_Base(CSystems.ProcessID);
                                applicantEducation.Insert(new ApplicantEducationLevelRow
                                {
                                    ApplicantID = nApplicantID,
                                    EducationLevelID = EducationData.EducationLevelID,
                                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                });
                                applicantEducation.Dispose();
                                ApplicantEducationLevelOtherCollection_Base applicantEducationOther = new ApplicantEducationLevelOtherCollection_Base(CSystems.ProcessID);
                                var EducationOtherData = applicantEducationOther.GetByPrimaryKey(data.ApplicantID);
                                applicantEducationOther.Dispose();
                                if (EducationOtherData != null)
                                {
                                    if (!string.IsNullOrEmpty(EducationOtherData.Education))
                                    {
                                        applicantEducationOther = new ApplicantEducationLevelOtherCollection_Base(CSystems.ProcessID);
                                        applicantEducationOther.Insert(new ApplicantEducationLevelOtherRow
                                        {
                                            ApplicantID = nApplicantID,
                                            Education = EducationOtherData.Education,
                                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                        });
                                        applicantEducationOther.Dispose();
                                    }

                                }

                            }
                            //INSERT ที่อยู่
                            // List<int> AddressID = new List<int>();
                            View_ApplicantAddressCollection_Base V_applicantAddress = new View_ApplicantAddressCollection_Base(CSystems.ProcessID);
                            listParameter = new List<SqlParameter>();
                            listParameter.Add(new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = data.ApplicantID });
                            var ApplicantAddressDataRequest = V_applicantAddress.GetAsArray(listParameter, "ApplicantID = @ApplicantID", "");
                            if (ApplicantAddressDataRequest.Length > 0)
                            {
                                foreach (var item in ApplicantAddressDataRequest)
                                {
                                    AddressCollection_Base addressCollection = new AddressCollection_Base(CSystems.ProcessID);
                                    var addressID = addressCollection.Insert(new AddressRow
                                    {
                                        Address1 = item.Address1,
                                        HouseNo = item.HouseNo,
                                        VillageNo = item.VillageNo,
                                        Street = item.Street,
                                        Soi = item.Soi,
                                        ProvinceID = item.ProvinceID,
                                        DisctrictID = item.DisctrictID,
                                        SubdistrictID = item.SubdistrictID,
                                        PostCode = item.PostCode,
                                        Createdate = dal.GetSqlNow(CSystems.ProcessID),
                                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                    });

                                    ApplicantAddressCollection_Base applicantAddress = new ApplicantAddressCollection_Base(CSystems.ProcessID);
                                    applicantAddress.Insert(new ApplicantAddressRow
                                    {
                                        AddressID = addressID,
                                        ApplicantID = nApplicantID,
                                        AddressTypeID = item.AddressTypeID,
                                        IsPresentAddress = item.IsPresentAddress,
                                        IsPermanentAddress = item.IsPermanentAddress,
                                        TelephoneNo = item.TelephoneNo,
                                        Stay = item.Stay,
                                        StayUnit = "Y",//Y =ปี
                                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                    });
                                    applicantAddress.Dispose();
                                    addressCollection.Dispose();
                                }
                            }
                            //INSERT
                            CaseApplicantMapOwnerDepartmentCollection_Base caseApplicantMapOwnerDepartment = new CaseApplicantMapOwnerDepartmentCollection_Base(CSystems.ProcessID);
                            caseApplicantMapOwnerDepartment.InsertOnlyPlainText(new CaseApplicantMapOwnerDepartmentRow
                            {
                                ApplicantID = nApplicantID,
                                DepartmentID = data.DepartmentID,
                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)

                            });
                            caseApplicantMapOwnerDepartment.Dispose();

                            //บุคคลที่สามารถติดต่อได้
                            AddressCollection_Base address = new AddressCollection_Base(CSystems.ProcessID);
                            var addressRow = address.GetAsArray(new List<SqlParameter>(), $"AddressID in (select AddressID from dbo.ApplicantRelatedPerson where ApplicantID = {data.ApplicantID} AND CaseID = {data.CaseID})", "");
                            address.Dispose();
                            PersonCollection_Base person = new PersonCollection_Base(CSystems.ProcessID);
                            var personRow = person.GetAsArray(new List<SqlParameter>(), $"PersonID in (select ContactPersonID from Dbo.ApplicantRelatedPerson where ApplicantID = {data.ApplicantID} AND CaseID = {data.CaseID})", "");
                            person.Dispose();
                            ApplicantRelatedPersonCollection_Base relate = new ApplicantRelatedPersonCollection_Base(CSystems.ProcessID);
                            var relateRow = relate.GetByApplicantID(data.ApplicantID);
                            relate.Dispose();
                            if (addressRow.Length > 0 && personRow.Length > 0 && relateRow.Length > 0)
                            {
                                var req = (from t1 in relateRow
                                           join t2 in personRow on t1.ContactPersonID equals t2.PersonID
                                           join t3 in addressRow on t1.AddressID equals t3.AddressID
                                           select new ApplicantRelatedPersonDataResult
                                           {
                                               Address1 = t3.Address1,
                                               HouseNo = t3.HouseNo,
                                               Soi = t3.Soi,
                                               Street = t3.Street,
                                               VillageNo = t3.VillageNo,
                                               ProvinceID = t3.ProvinceID,
                                               DisctrictID = t3.DisctrictID,
                                               SubdistrictID = t3.SubdistrictID,
                                               PostCode = t3.PostCode,
                                               GenderCode = t2.GenderCode,
                                               Title = t2.Title,
                                               FirstName = t2.FirstName,
                                               LastName = t2.LastName,
                                               AddressID = t1.AddressID,
                                               ContactPersonID = t1.ContactPersonID,
                                               PersonRoleID = t1.PersonRoleID,
                                               ApplicantID = t1.ApplicantID,
                                               CaseID = t1.CaseID,
                                               RelatedAs = t1.RelatedAs,
                                               TelephoneNumber = t1.TelephoneNumber
                                           }).ToArray();

                                address = new AddressCollection_Base(CSystems.ProcessID);
                                PersonCollection_Base personBase = new PersonCollection_Base(CSystems.ProcessID);
                                ContractPersonCollection_Base contractPerson = new ContractPersonCollection_Base(CSystems.ProcessID);
                                ApplicantRelatedPersonCollection_Base relatePerson = new ApplicantRelatedPersonCollection_Base(CSystems.ProcessID);
                                listParameter = new List<SqlParameter>();
                                SqlParameter sqlpara = new SqlParameter("@CaseID", System.Data.SqlDbType.Int) { Value = nCaseID };
                                listParameter.Add(sqlpara);
                                sqlpara = new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = nApplicantID };
                                listParameter.Add(sqlpara);
                                string whereSql = "[CaseID] = @CaseID AND [ApplicantID] = @ApplicantID";
                                string orderbySql = "ContactPersonID ASC";
                                var relatePersonRow = relatePerson.GetAsArray(listParameter, whereSql, orderbySql);
                                relatePerson.DeleteByApplicantID(nApplicantID);
                                relatePerson.Dispose();
                                foreach (var item in relatePersonRow)
                                {
                                    address = new AddressCollection_Base(CSystems.ProcessID);
                                    address.DeleteByPrimaryKey(item.AddressID);
                                    address.Dispose();

                                    contractPerson = new ContractPersonCollection_Base(CSystems.ProcessID);
                                    contractPerson.DeleteByPersonID(item.ContactPersonID);
                                    contractPerson.Dispose();

                                    personBase = new PersonCollection_Base(CSystems.ProcessID);
                                    personBase.DeleteByPrimaryKey(item.ContactPersonID);
                                    personBase.Dispose();
                                }
                                foreach (var item in req)
                                {
                                    //เพิ่มข้อมูลที่อยู่
                                    address = new AddressCollection_Base(CSystems.ProcessID);
                                    var addressID = address.InsertOnlyPlainText(new AddressRow
                                    {
                                        Address1 = item.Address1,
                                        HouseNo = item.HouseNo,
                                        Soi = item.Soi,
                                        Street = item.Street,
                                        VillageNo = item.VillageNo,
                                        ProvinceID = item.ProvinceID,
                                        DisctrictID = item.DisctrictID,
                                        SubdistrictID = item.SubdistrictID,
                                        PostCode = item.PostCode,
                                        Createdate = dal.GetSqlNow(CSystems.ProcessID)
                                    });
                                    address.Dispose();

                                    //เพิ่มข้อมูลบุคคล
                                    //var personID = person.InsertPerson(item.PersonData);
                                    personBase = new PersonCollection_Base(CSystems.ProcessID);
                                    var personID = personBase.InsertOnlyPlainText(new PersonRow
                                    {
                                        GenderCode = item.GenderCode,
                                        Title = item.Title,
                                        FirstName = item.FirstName,
                                        LastName = item.LastName,
                                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                                    });
                                    personBase.Dispose();

                                    //เพิ่มข้อมูลผู้เกี่ยวข้อง
                                    relatePerson = new ApplicantRelatedPersonCollection_Base(CSystems.ProcessID);
                                    relatePerson.InsertOnlyPlainText(new ApplicantRelatedPersonRow
                                    {
                                        AddressID = addressID,
                                        ContactPersonID = personID,
                                        PersonRoleID = item.PersonRoleID,
                                        ApplicantID = nApplicantID,
                                        CaseID = nCaseID,
                                        RelatedAs = item.RelatedAs,
                                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                                        TelephoneNumber = item.TelephoneNumber,
                                    });

                                }
                            }

                            //Proxy
                            listParameter = new List<SqlParameter>();
                            listParameter.Add(new SqlParameter("@ApplicantID", System.Data.SqlDbType.Int) { Value = data.ApplicantID });
                            ProxyCollection_Base proxydetail = new ProxyCollection_Base(CSystems.ProcessID);
                            var proxydata = proxydetail.GetRow(listParameter, "ApplicantID=@ApplicantID");
                            proxydetail.Dispose();

                            if (proxydata != null)
                            {
                                proxydetail = new ProxyCollection_Base(CSystems.ProcessID);
                                int proxyid = GetMaxProxyID() + 1;
                                proxydetail.InsertOnlyPlainText(new ProxyRow
                                {
                                    ProxyID = proxyid,
                                    CaseID = nCaseID,
                                    ApplicantID = nApplicantID,
                                    Title = proxydata.Title,
                                    FirstName = proxydata.FirstName,
                                    LastName = proxydata.LastName,
                                    DateOfBirth = proxydata.DateOfBirth,
                                    CardID = proxydata.CardID,
                                    Gender = proxydata.Gender,
                                    ReligionID = proxydata.ReligionID,
                                    RaceID = proxydata.RaceID,
                                    IsAppeal = proxydata.IsAppeal,
                                    NationalityID = proxydata.NationalityID,
                                    RelatedAs = proxydata.RelatedAs,

                                });
                                proxydetail.Dispose();
                                View_ProxyAddressCollection_Base proxyadd = new View_ProxyAddressCollection_Base(CSystems.ProcessID);
                                var proxyrows = proxyadd.GetAsArray(new List<SqlParameter>(), $"[ProxyID] = {proxydata.ProxyID}", "");
                                proxyadd.Dispose();
                                if (proxyrows.Length > 0)
                                {
                                    AddressService addressproxy = new AddressService();
                                    int addressID = 0;
                                    foreach (var prox in proxyrows)
                                    {
                                        addressID = addressproxy.InsertOrUpdateAddress(new AddressRow
                                        {
                                            Address1 = prox.Address1,
                                            HouseNo = prox.HouseNo,
                                            VillageNo = prox.VillageNo,
                                            Soi = prox.Soi,
                                            Street = prox.Street,
                                            ProvinceID = prox.ProvinceID,
                                            DisctrictID = prox.DisctrictID,
                                            SubdistrictID = prox.SubdistrictID,
                                            PostCode = prox.PostCode
                                        });
                                        ProxyAddressCollection_Base obj = new ProxyAddressCollection_Base(CSystems.ProcessID);
                                        obj.InsertOnlyPlainText(new ProxyAddressRow
                                        {
                                            ProxyID = proxyid,
                                            AddressID = addressID,
                                            AddressTypeID = prox.AddressTypeID,
                                            Stay = prox.Stay,
                                            StayUnit = prox.StayUnit,
                                            TelephoneNo = prox.TelephoneNo,
                                            IsPermanentAddress = prox.IsPermanentAddress,
                                            IsPresentAddress = prox.IsPresentAddress,
                                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),

                                        });
                                        obj.Dispose();

                                    }
                                    ProxyReligionOtherCollection_Base ProxyreligionOther = new ProxyReligionOtherCollection_Base(CSystems.ProcessID);
                                    var ProxyreligionOtherRow = ProxyreligionOther.GetByPrimaryKey(proxyid);
                                    ProxyreligionOther.Dispose();
                                    if (ProxyreligionOtherRow != null)
                                    {
                                        if (!string.IsNullOrWhiteSpace(ProxyreligionOtherRow.ReligionOther))
                                        {
                                            ProxyreligionOther = new ProxyReligionOtherCollection_Base(CSystems.ProcessID);
                                            ProxyreligionOther.DeleteByProxyID(proxyid);
                                            ProxyreligionOther.InsertOnlyPlainText(new ProxyReligionOtherRow
                                            {
                                                ProxyID = proxyid,
                                                ReligionOther = ProxyreligionOtherRow.ReligionOther
                                            });

                                            religionOther.Dispose();
                                        }
                                    }

                                }

                            }

                            //Marital
                            if (v_appRow.JFCaseTypeID != 3)
                            {
                                ApplicantMaritalDataResponse response = new ApplicantMaritalDataResponse();
                                ApplicantMaritalCollection_Base obj = new ApplicantMaritalCollection_Base(CSystems.ProcessID);
                                var ApplicantMaritalrow = obj.GetByPrimaryKey(data.ApplicantID);
                                obj.Dispose();
                                if (ApplicantMaritalrow != null)
                                {
                                    ApplicantFamilyAddressCollection_Base applicantFamilyAddress = new ApplicantFamilyAddressCollection_Base(CSystems.ProcessID);
                                    ApplicantFamilyIncomeCollection_Base applicantFamilyIncome = new ApplicantFamilyIncomeCollection_Base(CSystems.ProcessID);
                                    AddressCollection_Base addressCollection = new AddressCollection_Base(CSystems.ProcessID);
                                    ApplicantFamilyCollection_Base familyCollection_Base = new ApplicantFamilyCollection_Base(CSystems.ProcessID);
                                    response.ApplicantMaritalData = new ApplicantMaritalData
                                    {
                                        ApplicantID = nApplicantID,
                                        MaritalStatusID = ApplicantMaritalrow.MaritalStatusID,
                                        AdditionalMaritalStatus = ApplicantMaritalrow.AdditionalMaritalStatus,
                                        NumberOfChild = ApplicantMaritalrow.NumberOfChild,
                                        ModifiedDate = ApplicantMaritalrow.ModifiedDate,
                                    };
                                    var familyRow = familyCollection_Base.GetByApplicantID(data.ApplicantID);
                                    familyCollection_Base.Dispose();
                                    List<ApplicantFamilyDataResponse> li = new List<ApplicantFamilyDataResponse>();
                                    foreach (var item in familyRow)
                                    {
                                        ApplicantFamilyDataResponse famData = new ApplicantFamilyDataResponse
                                        {
                                            AddressLine = item.AddressLine,
                                            Age = item.Age,
                                            ApplicantID = item.ApplicantID,
                                            Career = item.Career,
                                            FamilyID = item.FamilyID,
                                            GroupName = item.GroupName,
                                            Name = item.Name,
                                            TelephoneNo = item.TelephoneNo,
                                            ModifiedDate = item.ModifiedDate,
                                        };
                                        if (item.GroupName.Equals("SPOUSE"))
                                        {
                                            applicantFamilyIncome = new ApplicantFamilyIncomeCollection_Base(CSystems.ProcessID);
                                            var income = applicantFamilyIncome.GetByPrimaryKey(item.FamilyID);
                                            applicantFamilyIncome.Dispose();
                                            if (income != null)
                                            {
                                                response.ApplicantIncomeData = new ApplicantFamilyIncomeData
                                                {
                                                    FamilyID = income.FamilyID,
                                                    Income = income.Income,
                                                    IncomeUnit = income.IncomeUnit,
                                                    ModifiedDate = income.ModifiedDate
                                                };
                                            }
                                        }
                                        //GET Address
                                        var famAddrRow = applicantFamilyAddress.GetRow(new List<SqlParameter>(), "FamilyID=" + item.FamilyID);
                                        applicantFamilyAddress.Dispose();
                                        if (famAddrRow != null)
                                        {
                                            var addrRow = addressCollection.GetByPrimaryKey(famAddrRow.AddressID);
                                            addressCollection.Dispose();
                                            famData.AddressResponse = new AddressData
                                            {
                                                AddressID = addrRow.AddressID,
                                                Address1 = addrRow.Address1,
                                                HouseNo = addrRow.HouseNo,
                                                VillageNo = addrRow.VillageNo,
                                                Soi = addrRow.Soi,
                                                Street = addrRow.Street,
                                                ProvinceID = addrRow.ProvinceID,
                                                DisctrictID = addrRow.DisctrictID,
                                                SubdistrictID = addrRow.SubdistrictID,
                                                PostCode = addrRow.PostCode,
                                                ModifiedDate = addrRow.ModifiedDate,
                                            };
                                        }
                                        if (item.GroupName.Equals("SPOUSE"))
                                        {
                                            response.ApplicantFamilySpouseData = famData;
                                        }
                                        else
                                        {
                                            li.Add(famData);
                                        }
                                    }
                                    response.ApplicantFamilyChildData = li;
                                    if (data.JFCaseTypeID != 3)
                                    {
                                        obj = new ApplicantMaritalCollection_Base(CSystems.ProcessID);
                                        if (response.ApplicantMaritalData.MaritalStatusID == 1)
                                        {
                                            obj.Insert(new ApplicantMaritalRow
                                            {
                                                ApplicantID = nApplicantID,
                                                NumberOfChild = response.ApplicantMaritalData.NumberOfChild,
                                                MaritalStatusID = response.ApplicantMaritalData.MaritalStatusID,
                                                //AdditionalMaritalStatus = response.ApplicantMaritalData.AdditionalMaritalStatus,
                                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                            });
                                        }
                                        else
                                        {
                                            obj.Insert(new ApplicantMaritalRow
                                            {
                                                ApplicantID = nApplicantID,
                                                NumberOfChild = response.ApplicantMaritalData.NumberOfChild,
                                                MaritalStatusID = response.ApplicantMaritalData.MaritalStatusID,
                                                AdditionalMaritalStatus = response.ApplicantMaritalData.AdditionalMaritalStatus,
                                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                            });
                                        }

                                        applicantFamilyAddress = new ApplicantFamilyAddressCollection_Base(CSystems.ProcessID);
                                        applicantFamilyIncome = new ApplicantFamilyIncomeCollection_Base(CSystems.ProcessID);
                                        addressCollection = new AddressCollection_Base(CSystems.ProcessID);
                                        familyCollection_Base = new ApplicantFamilyCollection_Base(CSystems.ProcessID);
                                        familyRow = familyCollection_Base.GetByApplicantID(nApplicantID);
                                        familyCollection_Base.Dispose();
                                        if (familyRow.Length != 0)
                                        {
                                            var sqlFID = " FamilyID IN(" + string.Join(",", familyRow.Select(o => o.FamilyID).ToArray()) + ")";
                                            //DELETE FamilyID
                                            var famAddress = applicantFamilyAddress.GetAsArray(new List<SqlParameter>(), sqlFID, "");
                                            applicantFamilyAddress.Delete(sqlFID);
                                            applicantFamilyAddress.Dispose();

                                            applicantFamilyIncome.Delete(sqlFID);
                                            applicantFamilyIncome.Dispose();
                                            if (famAddress.Length != 0)
                                            {
                                                var sqlAID = " AddressID IN(" + string.Join(",", famAddress.Select(o => o.AddressID).ToArray()) + ")";
                                                addressCollection.Delete(sqlAID);
                                                addressCollection.Dispose();
                                            }
                                            familyCollection_Base = new ApplicantFamilyCollection_Base(CSystems.ProcessID);
                                            familyCollection_Base.Delete(sqlFID);
                                            familyCollection_Base.Dispose();

                                        }
                                        //INSERT
                                        if (response.ApplicantFamilyChildData != null && response.ApplicantFamilyChildData.Count != 0)
                                        {
                                            foreach (var item in response.ApplicantFamilyChildData)
                                            {
                                                if (item.Name != null)
                                                {
                                                    familyCollection_Base = new ApplicantFamilyCollection_Base(CSystems.ProcessID);
                                                    var familyID = familyCollection_Base.Insert(new ApplicantFamilyRow
                                                    {
                                                        ApplicantID = nApplicantID,
                                                        Age = item.Age,
                                                        Career = item.Career,
                                                        Name = item.Name,
                                                        TelephoneNo = item.TelephoneNo,
                                                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                                                        GroupName = item.GroupName,
                                                        AddressLine = item.AddressLine,
                                                    });
                                                    familyCollection_Base.Dispose();
                                                }

                                            }
                                        }
                                        if (response.ApplicantFamilySpouseData != null)
                                        {
                                            familyCollection_Base = new ApplicantFamilyCollection_Base(CSystems.ProcessID);
                                            var familyID = familyCollection_Base.Insert(new ApplicantFamilyRow
                                            {
                                                ApplicantID = nApplicantID,
                                                Age = response.ApplicantFamilySpouseData.Age,
                                                Career = response.ApplicantFamilySpouseData.Career,
                                                Name = response.ApplicantFamilySpouseData.Name,
                                                TelephoneNo = response.ApplicantFamilySpouseData.TelephoneNo,
                                                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                                                GroupName = response.ApplicantFamilySpouseData.GroupName,
                                                AddressLine = response.ApplicantFamilySpouseData.AddressLine,
                                            });
                                            familyCollection_Base.Dispose();
                                            addressCollection = new AddressCollection_Base(CSystems.ProcessID);
                                            if (response.ApplicantFamilySpouseData.AddressResponse != null)
                                            {
                                                int addredID = addressCollection.Insert(new AddressRow
                                                {
                                                    Address1 = response.ApplicantFamilySpouseData.AddressResponse.Address1,
                                                    HouseNo = response.ApplicantFamilySpouseData.AddressResponse.HouseNo,
                                                    VillageNo = response.ApplicantFamilySpouseData.AddressResponse.VillageNo,
                                                    Soi = response.ApplicantFamilySpouseData.AddressResponse.Soi,
                                                    Street = response.ApplicantFamilySpouseData.AddressResponse.Street,
                                                    ProvinceID = response.ApplicantFamilySpouseData.AddressResponse.ProvinceID,
                                                    DisctrictID = response.ApplicantFamilySpouseData.AddressResponse.DisctrictID,
                                                    SubdistrictID = response.ApplicantFamilySpouseData.AddressResponse.SubdistrictID,
                                                    PostCode = response.ApplicantFamilySpouseData.AddressResponse.PostCode,
                                                    Createdate = dal.GetSqlNow(CSystems.ProcessID),
                                                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                                                });

                                                applicantFamilyAddress = new ApplicantFamilyAddressCollection_Base(CSystems.ProcessID);
                                                applicantFamilyAddress.Insert(new ApplicantFamilyAddressRow
                                                {
                                                    AddressID = addredID,
                                                    FamilyID = familyID,
                                                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                                                });
                                                applicantFamilyAddress.Dispose();
                                            }
                                            addressCollection.Dispose();
                                            //กรณีเป็น สามี/ภรรยา ให้บันทึกรายได้
                                            if (response.ApplicantIncomeData != null && response.ApplicantIncomeData.Income != 0)
                                            {
                                                applicantFamilyIncome = new ApplicantFamilyIncomeCollection_Base(CSystems.ProcessID);
                                                applicantFamilyIncome.Insert(new ApplicantFamilyIncomeRow
                                                {
                                                    FamilyID = familyID,
                                                    Income = response.ApplicantIncomeData.Income,
                                                    IncomeUnit = response.ApplicantIncomeData.IncomeUnit,
                                                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                                                });
                                                applicantFamilyIncome.Dispose();
                                            }
                                        }
                                    }

                                }
                            }
                        }

                    }
                    ApplicantChangeHistoryCollection_Base history = new ApplicantChangeHistoryCollection_Base(CSystems.ProcessID);
                    history.Delete($"ApplicantID = {nApplicantID}");
                    history.Dispose();

                    TrackingService.SaveCaseChangeWorkStepHistory(new CaseChangeWorkStepHistoryRow { CaseID = nCaseID ,DepartmentID = data.DepartmentID,WorkStepID = 1,UserID = data.UserID ,ChangeDate = dal.GetSqlNow(CSystems.ProcessID),Comment = "คัดลอกสำนวน",ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)},CSystems.ProcessID);
                    dal.DbCommit(CSystems.ProcessID);
                    isPass = true;
                }
            }
            catch (Exception ex)
            {
                dal.DbRollBack(CSystems.ProcessID);
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return isPass;
        }
        public int GetMaxProxyID()
        {
            int id = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            ProxyCollection_Base obj = new ProxyCollection_Base(CSystems.ProcessID);
            var proxyID = obj.GetRow(parameters, "ProxyID IN (SELECT MAX(ProxyID) FROM [Proxy])");
            if (proxyID != null)
            {
                id = proxyID.ProxyID;
            }
            else
            {
                id = 1;
            }
            return id;
        }
        public int InsertOrUpdateApplicantAdditionalInfo(ApplicantAdditionalInfoData req)
        {
            if(req != null)
            {
                ApplicantAdditionalInfoCollection_Base obj = new ApplicantAdditionalInfoCollection_Base(CSystems.ProcessID);
                var row = obj.GetByPrimaryKey(req.ApplicantID, req.ApplicantAttrID);
                obj.Dispose();
                if (row != null)
                {
                    obj = new ApplicantAdditionalInfoCollection_Base(CSystems.ProcessID);
                    row.ApplicantAttrID = req.ApplicantAttrID;
                    row.ApplicantAttrVal = req.ApplicantAttrVal;
                    row.ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID);
                    obj.Update(row);
                    obj.Dispose();
                }
                else
                {
                    obj = new ApplicantAdditionalInfoCollection_Base(CSystems.ProcessID);
                    obj.Insert(new ApplicantAdditionalInfoRow
                    {
                        ApplicantID = req.ApplicantID,
                        ApplicantAttrVal = req.ApplicantAttrVal,
                        ApplicantAttrID = req.ApplicantAttrID,
                        ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID)
                    });

                    obj.Dispose();
                    if (req.ApplicantAttrID == 1)
                    {
                        //เหตุผลที่จะได้รับความช่วยเหลือ
                        Engine.Services.TrackingService.Log(req.ApplicantID, "_HelpReason");
                    }
                }
            }
            return req.ApplicantID;
        }
        public bool CaseUpdate(CaseDataRequest request)
        {
            if (request.CaseApplicationData.CaseID == 0)
            {
                throw new ArgumentNullException(nameof(request.CaseApplicationData.CaseID));
            }
            bool IsPass = false;
            DalBase dal = new DalBase();
            try
            {
                if (request.CaseApplicationData.CaseID != 0)
                {
                    //UPDATE CaseApplication 
                    CaseApplicationCollection_Base caseApplication = new CaseApplicationCollection_Base(CSystems.ProcessID);
                    CaseApplicationRow caseapplicationrow = caseApplication.GetByPrimaryKey(request.CaseApplicationData.CaseID);
                    caseapplicationrow.Subject = request.CaseApplicationData.Subject;
                    caseapplicationrow.DepartmentID = request.CaseApplicationData.DepartmentID;
                    //caseapplicationrow.CaseOwnerDepartmentID = request.CaseApplicationData.CaseOwnerDepartmentID;
                    caseapplicationrow.JFCaseTypeID = request.CaseApplicationData.JFCaseTypeID;
                    caseapplicationrow.ChannelID = request.CaseApplicationData.ChannelID;
                    caseapplicationrow.ReferenceMSCCODE = request.CaseApplicationData.ReferenceMSCCODE;
                    caseapplicationrow.ReferenceMSCID = request.CaseApplicationData.ReferenceMSCID;
                    // caseapplicationrow.StatusID = request.CaseApplicationData.StatusID;//Fix 1:ดำเนินการ Ref Table CaseApplicationStatus
                    // caseapplicationrow.WorkStepID = request.CaseApplicationData.WorkStepID;//Fix 1:รับเรื่อง Ref Table WorkStep
                    if (!string.IsNullOrWhiteSpace(request.CaseApplicationData.RegisterDateStr))
                        caseapplicationrow.RegisterDate = Helpers.Utility.ConvertStringToDate(request.CaseApplicationData.RegisterDateStr);
                    caseapplicationrow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                    //Get Province By DepartmentID
                    var provinceID = new DepartmentService().GetProvinceByDepartmentID(request.CaseApplicationData.DepartmentID);
                    if (provinceID != 0)
                    {
                        caseapplicationrow.ProvinceID = provinceID;
                    }
                    caseApplication.Update(caseapplicationrow);
                    caseApplication.Dispose();

                    if (request.CaseApplicationData.JFCaseTypeID != 4 && request.CaseApplicationData.JFCaseTypeID != 5)
                    {
                        //INSERT เรื่องหลัก เรื่องรอง
                        CaseMapCaseCategoryCollection_Base caseMapCaseCategory = new CaseMapCaseCategoryCollection_Base(CSystems.ProcessID);
                        caseMapCaseCategory.DeleteByCaseID(request.CaseApplicationData.CaseID);
                        var rowSubCate = new CaseMapCaseCategoryRow
                        {
                            CaseID = request.CaseMapCaseCategoryData.CaseID,
                            CaseCategoryID = request.CaseMapCaseCategoryData.CaseCategoryID,
                            OtherCategory = request.CaseMapCaseCategoryData.OtherCategory,
                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                        };
                        if (request.CaseMapCaseCategoryData.CaseSubCategoryID != 0)
                        {
                            rowSubCate.CaseSubCategoryID = request.CaseMapCaseCategoryData.CaseSubCategoryID;
                        }
                        caseMapCaseCategory.Insert(rowSubCate);
                        caseMapCaseCategory.Dispose();
                    }
                    IsPass = true;
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return IsPass;
        }
        /// <summary>
        /// บันทึกการแก้ไขสำนวน
        /// </summary>
        /// <param name="caseID"></param>
        /// <param name="statusID"></param>
        /// <param name="userID"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public bool ChangeStatus(int caseID,int departmentID, int statusID, int userID, string comment)
        {
            if (caseID == 0)
            {
                throw new ArgumentNullException(nameof(caseID));
            }
            bool IsPass = false;
            DalBase dal = new DalBase();
            try
            {
                if (caseID != 0)
                {
                    //UPDATE CaseApplication 
                    // CaseApplicationCollection_Base caseApplication = new CaseApplicationCollection_Base(CSystems.ProcessID);
                    // CaseApplicationRow caseapplicationrow = caseApplication.GetByPrimaryKey(caseID);
                    //// caseapplicationrow.StatusID = statusID;//Fix 1:ดำเนินการ Ref Table CaseApplicationStatus
                    // caseapplicationrow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                    // caseApplication.Update(caseapplicationrow);
                    // caseApplication.Dispose();
                    CaseOwnerDepartmentCollection_Base caseApplication = new CaseOwnerDepartmentCollection_Base(CSystems.ProcessID);
                    CaseOwnerDepartmentRow caseapplicationrow = caseApplication.GetByPrimaryKey(caseID,departmentID);
                    caseapplicationrow.StatusID = statusID;//Fix 1:ดำเนินการ Ref Table CaseApplicationStatus
                    caseapplicationrow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                    caseApplication.Update(caseapplicationrow);
                    caseApplication.Dispose();

                    CaseChangeHistoryCollection_Base caseChangeHistory = new CaseChangeHistoryCollection_Base(CSystems.ProcessID);
                    caseChangeHistory.Delete($"CaseID={caseID} AND CaseApplicationStatusID={statusID} AND UserID={userID} AND DepartmentID={departmentID}");
                    caseChangeHistory.Insert(new CaseChangeHistoryRow
                    {
                        CaseApplicationStatusID = statusID,
                        CaseID = caseID,
                        UserID = userID,
                        Comment = comment,
                        DepartmentID = departmentID,
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                        ChangeDate = dal.GetSqlNow(CSystems.ProcessID)
                    });
                    caseChangeHistory.Dispose();
                }
                IsPass = true;            
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return IsPass;
        }
        public void InsertApplicantReligionOther(int applicantID, string religionother)
        {
            ApplicantReligionOtherCollection_Base religionOther = new ApplicantReligionOtherCollection_Base(CSystems.ProcessID);
            religionOther.DeleteByApplicantID(applicantID);
            religionOther.InsertOnlyPlainText(new ApplicantReligionOtherRow {
                ApplicantID = applicantID,
                ReligionOther = religionother
            });
        }

        public void InsertOrUpdateCaseCounsel(int applicantID , CaseCounselRow req)
        {
            DalBase dal = new DalBase();
            try
            {
               CaseCounselCollection_Base obj = new CaseCounselCollection_Base(CSystems.ProcessID);
                obj.DeleteByPrimaryKey(applicantID);
                obj.InsertOnlyPlainText(new CaseCounselRow
                {
                    ApplicantID = applicantID,
                    CunselTime = req.CunselTime,
                    ConselSummary = req.ConselSummary,
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                });

                obj.Dispose();
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
           
        }
        public void InsertCaseApplicantMap(int appID ,int depID)
        {
            DalBase dal = new DalBase();
            try
            {
                CaseApplicantMapOwnerDepartmentCollection_Base obj = new CaseApplicantMapOwnerDepartmentCollection_Base(CSystems.ProcessID);
                obj.DeleteByPrimaryKey(appID, depID);
                obj.InsertOnlyPlainText(new CaseApplicantMapOwnerDepartmentRow
                {
                    ApplicantID = appID,
                    DepartmentID = depID,
                    JFCaseNo = "",
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                });

                obj.Dispose();
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);

            }
        }
        public void InsertApplicantChangeHistory(int appID, int depID, int userID)
        {
            DalBase dal = new DalBase();
            try
            {
            
                UserCollection_Base user = new UserCollection_Base(CSystems.ProcessID);
                var row = user.GetByPrimaryKey(userID);

                ApplicantChangeHistoryCollection_Base obj = new ApplicantChangeHistoryCollection_Base(CSystems.ProcessID);
                obj.InsertOnlyPlainText(new ApplicantChangeHistoryRow
                {
                    ApplicantID = appID,
                    UserID = userID,
                    ChangeDate = dal.GetSqlNow(CSystems.ProcessID),
                    Comment = row.Title + row.FirstName + "   " + row.LastName + "   " + "ให้คำปรึกษาแก่ผุ้ร้องขอความช่วยเหลือ",
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),


                });

                user.Dispose();
                obj.Dispose();



            }
            catch (Exception ex)
            {
                 DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
               
            }
        }
        public void InsertCaseOwnerDepartment(int caseID, int depID, int statusID, int workstepID)
        {
            DalBase dal = new DalBase();
            try
            {
                 DepartmentCollection_Base dep = new DepartmentCollection_Base(CSystems.ProcessID);
                var provinceID = dep.GetByPrimaryKey(depID).ProvinceID;
                dep.Dispose();
                CaseOwnerDepartmentCollection_Base obj = new CaseOwnerDepartmentCollection_Base(CSystems.ProcessID);
                obj.DeleteByPrimaryKey(caseID, depID);
                obj.InsertOnlyPlainText(new CaseOwnerDepartmentRow
                {
                    CaseID = caseID,
                    DepartmentID = depID,
                    ProvinceID = provinceID,
                    WorkStepID = workstepID,
                    StatusID = statusID,
                    IsAppeal = false,
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                });
                obj.Dispose();

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
        }
        public void InsertCaseOwner(int caseID,int depID,int userID,int applicantID)
        {
            DalBase dal = new DalBase();
            try
            {
           
                UserCollection_Base user = new UserCollection_Base(CSystems.ProcessID);
                var row = user.GetByPrimaryKey(userID);
                user.Dispose();
                CaseOwnerCollection_Base obj = new CaseOwnerCollection_Base(CSystems.ProcessID);
                var CaseOwnerRow = obj.GetByPrimaryKey(applicantID,caseID, depID, userID);
                if (CaseOwnerRow != null)
                {
                    CaseOwnerRow.ChangeDate = dal.GetSqlNow(CSystems.ProcessID);
                    CaseOwnerRow.Comment = row.Title + row.FirstName + "   " + row.LastName + "   " + "ให้คำปรึกษาแก่ผุ้ร้องขอความช่วยเหลือ";
                    obj.UpdateOnlyPlainText(CaseOwnerRow);
                }
                else
                {
                    obj.InsertOnlyPlainText(new CaseOwnerRow
                    {
                        CaseID = caseID,
                        ApplicantID =applicantID,
                        DepartmentID = depID,
                        UserID = userID,
                        ChangeDate = dal.GetSqlNow(CSystems.ProcessID),
                        Comment = row.Title + row.FirstName + "   " + row.LastName + "   " + "ให้คำปรึกษาแก่ผุ้ร้องขอความช่วยเหลือ",

                    });
                }

                obj.Dispose();

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
        }
        public void InsertCaseChangeHistory(int caseID,int depID,int status, int userID ,string comment)
        {
            DalBase dal = new DalBase();
            try
            {
                if(status == 2)
                {
                    comment = "ดำเนินการ";
                }
                
                CaseChangeHistoryCollection_Base obj = new CaseChangeHistoryCollection_Base(CSystems.ProcessID);
                obj.InsertOnlyPlainText(new CaseChangeHistoryRow
                {
                    CaseID = caseID,
                    DepartmentID = depID,
                    CaseApplicationStatusID = status,
                    UserID = userID,
                    Comment = comment,
                    ChangeDate = dal.GetSqlNow(CSystems.ProcessID),
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                });
                obj.Dispose();

            }
            catch (Exception ex)
            {
                 DalBase.ExceptEngine.ThrowException(CSystems.ProcessID,ex);
            }
        }
        public void CaseChangeWorkStepHistory(int caseID, int depID,int userID, int workstep)
        {
            DalBase dal = new DalBase();
            try
            {
                string comment = "";
                CaseChangeWorkStepHistoryCollection_Base obj;
                if (workstep == 13)
                {
                    comment = "ให้คำปรึกษา";
                    //กรณีให้คำปรึกษาพร้อมปิดสำนวนให้บันทึกรับเรื่องเพื่อออก KPI
                    obj = new CaseChangeWorkStepHistoryCollection_Base(CSystems.ProcessID);
                    obj.InsertOnlyPlainText(new CaseChangeWorkStepHistoryRow
                    {
                        CaseID = caseID,
                        DepartmentID = depID,
                        WorkStepID = 2,
                        UserID = userID,
                        Comment = "รับเรื่อง",
                        ChangeDate = dal.GetSqlNow(CSystems.ProcessID),
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                    });
                    obj.Dispose();
                }

                obj = new CaseChangeWorkStepHistoryCollection_Base(CSystems.ProcessID);
                obj.InsertOnlyPlainText(new CaseChangeWorkStepHistoryRow
                {
                    CaseID = caseID,
                    DepartmentID = depID,
                    WorkStepID = workstep,
                    UserID = userID,
                    Comment = comment,
                    ChangeDate = dal.GetSqlNow(CSystems.ProcessID),
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                });
                obj.Dispose();

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
        }


//        public void TranferCase(int caseID, int desDepID)        
//        {

        //            DalBase dal = new DalBase();
        //            try
        //            {
        //                dal.DbBeginTransaction(CSystems.ProcessID);

        //                CaseApplication
        //                    CaseApplicant
        //                    CaseApplicantExtension
        //                CaseMapCaseCategory
        //CaseMapCaseLevelCaseType
        //CaseProject
        //CaseProjectCharacteristics
        //CaseProjectDocumentCheck
        //                    CaseProjectReferencePerson




        //                dal.DbCommit(CSystems.ProcessID);

        //            }
        //            catch (Exception ex)
        //            {
        //                dal.DbRollBack(CSystems.ProcessID);
        //                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
        //            }


        //        }

    }

}
