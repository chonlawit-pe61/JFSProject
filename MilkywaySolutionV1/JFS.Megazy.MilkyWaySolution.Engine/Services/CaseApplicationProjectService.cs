using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class CaseApplicationProjectService
    {

        /// <summary>
        /// Insert Or Update CaseApplicant parameter CaseApplicantData data, int caseID, int JFCaseTypeID, int DepartmentID
        /// </summary>
        /// <param name="data"></param>
        /// <param name="caseID"></param>
        /// <param name="JFCaseTypeID"></param>
        /// <param name="DepartmentID"></param>
        /// <returns></returns>
        public CaseEscape InsertOrUpdateCaseApplicant(CaseApplicantData data, CaseApplicantExtensionData CaseExData, int caseID,int UserCreateCaseID, int JFCaseTypeID=0, int DepartmentID=0)
        {
            CaseEscape casedata = new CaseEscape();
            //INSERT ผู้ขอรับการช่วยเหลือ
            var applicantID = 0;
            CaseApplicantCollection_Base caseApplicant = new CaseApplicantCollection_Base(CSystems.ProcessID);
            CaseApplicantRow caseApplicantRow = caseApplicant.GetByPrimaryKey(data.ApplicantID);
            DalBase dal = new DalBase();
            if (caseApplicantRow != null)
            {
                caseApplicantRow.FirstName = data.FirstName;
                caseApplicantRow.LastName = data.LastName;
                caseApplicantRow.Title = data.Title;
                caseApplicantRow.Gender = data.Gender.ToUpper();
                if (data.RequestAmount > 0) {
                    caseApplicantRow.RequestAmount = data.RequestAmount;
                }
                //caseApplicantRow.HasProxy = data.HasProxy;
                caseApplicantRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                caseApplicant.Update(caseApplicantRow);
                casedata.ApplicantID = caseApplicantRow.ApplicantID;
                casedata.CaseID = caseID;
            }
            else
            {

                applicantID = caseApplicant.GetMaxID() + 1;
                caseApplicant.Insert(new CaseApplicantRow
                {
                    ApplicantID = applicantID,
                    CaseID = caseID,
                    //JFCaseNo = RunningServices.GetCaseRunning(JFCaseTypeID, DepartmentID),//comment by piak
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Gender = data.Gender.ToUpper(),
                    Title = data.Title,
                    RequestAmount = data.RequestAmount,
                    HasProxy = data.HasProxy,
                    CreateDate = dal.GetSqlNow(CSystems.ProcessID),
                    UserCreateCaseID = UserCreateCaseID,
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                });
                casedata.ApplicantID = applicantID;
                casedata.CaseID = caseID;
                data.ApplicantID = applicantID;
            }
            caseApplicant.Dispose();
            CaseApplicantExtensionCollection_Base caseEx = new CaseApplicantExtensionCollection_Base(CSystems.ProcessID);
            var caseExRow = caseEx.GetByPrimaryKey(data.ApplicantID);

            if (caseExRow == null)
            {
                if (Helpers.Utility.DateValidateInput(Helpers.Utility.ConvertStringToDate(CaseExData.DateOfBirthStr)))
                {
                    // Helpers.Age
                    CaseExData.Age = new Helpers.Age(Helpers.Utility.ConvertStringToDate(CaseExData.DateOfBirthStr)).Years;
                }
                caseEx.InsertOnlyPlainText(new CaseApplicantExtensionRow { 
                    ApplicantID = data.ApplicantID,
                    CardID = CaseExData.CardID,
                    CardType = CaseExData.CardType,
                    DateOfBirth = Helpers.Utility.ConvertStringToDate(CaseExData.DateOfBirthStr),
                    Age = CaseExData.Age,
                    ModifiedDate= DalBase.SqlNowIncludePd(CSystems.ProcessID)
                });
            }
            else
            {
                if (Helpers.Utility.DateValidateInput(Helpers.Utility.ConvertStringToDate(CaseExData.DateOfBirthStr)))
                {
                    // Helpers.Age
                    CaseExData.Age = new Helpers.Age(Helpers.Utility.ConvertStringToDate(CaseExData.DateOfBirthStr)).Years;
                }
                caseExRow.ApplicantID = data.ApplicantID;
                caseExRow.CardID = CaseExData.CardID;
                caseExRow.CardType = CaseExData.CardType;
                caseExRow.Age = CaseExData.Age;
                caseExRow.DateOfBirth = Helpers.Utility.ConvertStringToDate(CaseExData.DateOfBirthStr);
                caseExRow.ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID);
                caseEx.UpdateOnlyPlainText(caseExRow);
            }
            caseEx.Dispose();
            return casedata;
        }


        /// <summary>
        /// Insert Project Address parameter int caseID,int addressID,string email,string telephoneNo,string faxNo
        /// </summary>
        /// <param name="caseID"></param>
        /// <param name="addressID"></param>
        /// <param name="email"></param>
        /// <param name="telephoneNo"></param>
        /// <param name="faxNo"></param>
        //public void InsertProjectAddress(int caseID,int addressID,string email,string telephoneNo,string faxNo) {

        //    DalBase dal = new DalBase();
        //    ProjectAddressCollection_Base projectAddress = new ProjectAddressCollection_Base(CSystems.ProcessID);
        //    projectAddress.DeleteByPrimaryKey(caseID, addressID);

        //    projectAddress.InsertOnlyPlainText(new ProjectAddressRow{
        //        CaseID = caseID,
        //        AddressID = addressID,
        //        Email = email,
        //        TelephoneNo = telephoneNo,
        //        FaxNo = faxNo,
        //        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
        //    });
        //    projectAddress.Dispose();

        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactID"></param>
        /// <param name="addressID"></param>
        public void InsertContactAddress(int contactID, int addressID)
        {

            DalBase dal = new DalBase();
            CoordinatorAddressCollection_Base contactAddress = new CoordinatorAddressCollection_Base(CSystems.ProcessID);
            contactAddress.DeleteByPrimaryKey(contactID, addressID);

            contactAddress.InsertOnlyPlainText(new CoordinatorAddressRow
            {
                ContactID = contactID,
                AddressID = addressID,
                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
            });
            contactAddress.Dispose();

        }
        /// <summary>
        /// บันทึก สถานที่จัดโครงการ
        /// </summary>
        /// <param name="caseID"></param>
        /// <param name="addressID"></param>
        /// <param name="locationName"></param>
        /// <param name="processID"></param>
        public void InsertProjectLocation(int caseID, int addressID, string locationName,int processID)
        {
            DalBase dal = new DalBase();
            ProjectLocationCollection_Base projectloc = new ProjectLocationCollection_Base(processID);
            projectloc.DeleteByPrimaryKey(caseID);
            projectloc.InsertOnlyPlainText(new ProjectLocationRow
            {
                CaseID = caseID,
                AddressID = addressID,
                LocationName = locationName,
                ModifiedDate = dal.GetSqlNow(processID)
            });
            projectloc.Dispose();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="MapData"></param>
        /// <returns></returns>
        public CaseApplicationRow InsertOrUpdateCaseApplication(CaseApplicationData data, CaseMapCaseCategoryData MapData = null)
        {

            CaseApplicationRow res = new CaseApplicationRow();
            DalBase dal = new DalBase();
            try
            {

                CaseApplicationCollection_Base caseApplication = new CaseApplicationCollection_Base(CSystems.ProcessID);
                CaseApplicationRow caseapplicationrow = caseApplication.GetByPrimaryKey(data.CaseID);
                if (caseapplicationrow != null)
                {


                    caseapplicationrow.Subject = data.Subject;
                    caseapplicationrow.DepartmentID = data.DepartmentID;
                   // caseapplicationrow.CaseOwnerDepartmentID = data.DepartmentID;
                    caseapplicationrow.JFCaseTypeID = data.JFCaseTypeID;
                    caseapplicationrow.ChannelID = data.ChannelID;
                    caseapplicationrow.ReferenceMSCCODE = data.ReferenceMSCCODE;
                    caseapplicationrow.ReferenceMSCID = data.ReferenceMSCID;
                   // caseapplicationrow.StatusID = data.StatusID;//Fix 1:ดำเนินการ Ref Table CaseApplicationStatus
                    //caseapplicationrow.IsAppeal = false;//false ไม่ใช่อุทธรณ์
                   // caseapplicationrow.WorkStepID = data.WorkStepID;//Fix 1:รับเรื่อง Ref Table WorkStep
                    if (!string.IsNullOrWhiteSpace(data.RegisterDateStr))
                        caseapplicationrow.RegisterDate = Helpers.Utility.ConvertStringToDate(data.RegisterDateStr);
                    caseapplicationrow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                    //Get Province By DepartmentID
                    var provinceID = new DepartmentService().GetProvinceByDepartmentID(data.DepartmentID);
                    if (provinceID != 0)
                    {
                        caseapplicationrow.ProvinceID = provinceID;
                    }
                    caseApplication.Update(caseapplicationrow);
                    caseApplication.Dispose();

                    if (data.JFCaseTypeID != 4)
                    {
                        //INSERT เรื่องหลัก เรื่องรอง

                        CaseMapCaseCategoryCollection_Base caseMapCaseCategory = new CaseMapCaseCategoryCollection_Base(CSystems.ProcessID);
                        caseMapCaseCategory.DeleteByCaseID(data.CaseID);
                        caseMapCaseCategory.Insert(new CaseMapCaseCategoryRow
                        {
                            CaseID = MapData.CaseID,
                            CaseCategoryID = MapData.CaseCategoryID,
                            CaseSubCategoryID = MapData.CaseSubCategoryID,
                            OtherCategory = MapData.OtherCategory,
                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                        });
                        caseMapCaseCategory.Dispose();
                    }

                }
                else
                {
                    var provinceID = new DepartmentService().GetProvinceByDepartmentID(data.DepartmentID);
                    
                    caseapplicationrow = new CaseApplicationRow
                    {
                        Subject = data.Subject,
                        DepartmentID = data.DepartmentID,
                        JFCaseTypeID = data.JFCaseTypeID,
                        ChannelID = data.ChannelID,
                       // CaseOwnerDepartmentID = data.DepartmentID,
                        ProvinceID = provinceID,
                        ReferenceMSCCODE = data.ReferenceMSCCODE,
                        ReferenceMSCID = data.ReferenceMSCID,
                      //  StatusID = 1,//Fix 1:รอดำเนินการ Ref Table CaseApplicationStatus
                       // WorkStepID = 1,//Fix 1:ยื่นเรื่อง Ref Table WorkStep
                        RegisterDate = Helpers.Utility.ConvertStringToDate(data.RegisterDateStr),
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                        CreateDate = dal.GetSqlNow(CSystems.ProcessID)
                    };
                    int caseID = caseApplication.GetMaxID() + 1;
                    caseapplicationrow.CaseID = caseID;
                    caseApplication.Insert(caseapplicationrow);
                }

                res = caseapplicationrow;
                caseApplication.Dispose();
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }

            return res;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="caseID"></param>
        public void InsertOrUpdateCaseProjectCharacteristics(int caseID,CaseProjectCharacteristicsData[] data = null)
        {

            DalBase dal = new DalBase();
            CaseProjectCharacteristicsCollection_Base characteristics = new CaseProjectCharacteristicsCollection_Base(CSystems.ProcessID);
            characteristics.DeleteByCaseID((int)caseID);
            if(data != null)
            {
                if (data.Length > 0)
                {

                    foreach (var item in data)
                    {

                        CaseProjectCharacteristicsRow characteristicsRow = new CaseProjectCharacteristicsRow();
                        characteristicsRow.CharacteristicID = item.CharacteristicID;
                        characteristicsRow.CaseID = caseID;
                        if (!string.IsNullOrWhiteSpace(item.Remark))
                        {
                            characteristicsRow.Remark = item.Remark;
                        }
                        characteristicsRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                        characteristics.InsertOnlyPlainText(characteristicsRow);
                    }
                }
            }
            
            
            characteristics.Dispose();
           
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="caseID"></param>
        public void InsertOrUpdateCaseProjectDocumentCheck(CaseProjectDocumentCheckData[] data, int caseID)
        {

            DalBase dal = new DalBase();
            CaseProjectDocumentCheckCollection_Base docdumentCheck = new CaseProjectDocumentCheckCollection_Base(CSystems.ProcessID);
            docdumentCheck.DeleteByCaseID(caseID);
            if (data != null)
            {
                if (data.Length > 0)
                {
                    foreach (var item in data)
                    {
                        CaseProjectDocumentCheckRow docdumentCheckRow = new CaseProjectDocumentCheckRow();
                        docdumentCheckRow.DocumentID = item.DocumentID;
                        docdumentCheckRow.CaseID = caseID;
                        if (!string.IsNullOrWhiteSpace(item.Remark))
                        {
                            docdumentCheckRow.Remark = item.Remark;
                        }
                        docdumentCheckRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                        docdumentCheck.InsertOnlyPlainText(docdumentCheckRow);
                    }
                }
            }
            docdumentCheck.Dispose();
           
        }

        public void InsertOrUpdateCaseProjectMattersOfLawCheck(int[] data, int caseID ,int applicantID)
        {

            DalBase dal = new DalBase();
            CaseMattersOfLawCollection_Base obj = new CaseMattersOfLawCollection_Base(CSystems.ProcessID);
            obj.DeleteByAppicantID(applicantID);

            if (data.Length > 0)
            {
                foreach (var item in data)
                {

                    CaseMattersOfLawRow row = new CaseMattersOfLawRow();
                    obj.InsertOnlyPlainText(new CaseMattersOfLawRow
                    {
                        MattersOfLawID = item,
                        CaseID = caseID,
                        AppicantID = applicantID,
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                    });
                    
                }
                Engine.Services.TrackingService.Log(applicantID, "_MattersOfLaw");
            }
            obj.Dispose();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="caseID"></param>
        public bool InsertProjectReferencePerson(CaseProjectReferencePersonData[] data, int caseID)
        {

            DalBase dal = new DalBase();
            CaseProjectReferencePersonCollection_Base referencePerson = new CaseProjectReferencePersonCollection_Base(CSystems.ProcessID);
            referencePerson.DeleteByCaseID(caseID);
            bool status = false;
            if (data.Length > 0)
            {

                foreach (var item in data)
                {

                    CaseProjectReferencePersonRow referencePersonRow = new CaseProjectReferencePersonRow();
                    referencePersonRow.CaseID = caseID;
                    referencePersonRow.RefPersonName = item.RefPersonName;
                    referencePersonRow.RefPersonAddress = item.RefPersonAddress;
                    referencePersonRow.RefPersonTelephonNo = item.RefPersonTelephonNo;
                    referencePersonRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                    referencePerson.InsertOnlyPlainText(referencePersonRow);
                    status = true;
                }
            }
            referencePerson.Dispose();

            return status;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="caseID"></param>
        public void InsertCaseProjectSourceFund(int caseID,CaseProjectSourceFundData[] data = null)
        {

            DalBase dal = new DalBase();
            CaseProjectSourceFundCollection_Base sourcefund = new CaseProjectSourceFundCollection_Base(CSystems.ProcessID);
            sourcefund.DeleteByCaseID(caseID);

            if(data != null)
            {
                if (data.Length > 0)
                {

                    foreach (var item in data)
                    {
                        if (!string.IsNullOrWhiteSpace(item.SourceFundName) && item.Amount != 0)
                        {

                            CaseProjectSourceFundRow sourceFundRow = new CaseProjectSourceFundRow();
                            sourceFundRow.CaseID = caseID;
                            sourceFundRow.SourceFundName = item.SourceFundName;
                            sourceFundRow.Amount = item.Amount;
                            sourceFundRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                            sourcefund.InsertOnlyPlainText(sourceFundRow);
                        }

                    }
                }
            }
            
            sourcefund.Dispose();
        }


        /// <summary>
        /// caseID ref CaseApplication
        /// </summary>
        /// <param name="data"></param>
        /// <param name="caseID"></param>
        /// <returns></returns>
        public void InsertOrupdateCaseProject(CaseProjectData data, int caseID)
        {
          
            DalBase dal = new DalBase();
            CaseProjectCollection_Base caseProject = new CaseProjectCollection_Base(CSystems.ProcessID);
            CaseProjectRow caseProjectRow = caseProject.GetByPrimaryKey(caseID);

            if (caseProjectRow != null) {

                if (data.ProposerTypeID > 0)
                {
                    caseProjectRow.ProposerTypeID = data.ProposerTypeID;
                }
                if (!string.IsNullOrWhiteSpace(data.ProposerTypeOther)) {
                    caseProjectRow.ProposerTypeOther = data.ProposerTypeOther;
                }
                if (!string.IsNullOrWhiteSpace(data.ProjectTitle))
                {
                    caseProjectRow.ProjectTitle = data.ProjectTitle;
                }
                if (!string.IsNullOrWhiteSpace(data.ProposerEN))
                {
                    caseProjectRow.ProposerEN = data.ProposerEN;
                }
                if (!string.IsNullOrWhiteSpace(data.ObjectiveToHelp))
                {
                    caseProjectRow.ObjectiveToHelp = data.ObjectiveToHelp;
                }
                if (!string.IsNullOrWhiteSpace(data.ProjectInAction))
                {
                    caseProjectRow.ProjectInAction = data.ProjectInAction;
                }
                if (!string.IsNullOrWhiteSpace(data.Portfolio))
                {
                    caseProjectRow.Portfolio = data.Portfolio;
                }
                if (!string.IsNullOrWhiteSpace(data.ProjectObjective))
                {
                    caseProjectRow.ProjectObjective = data.ProjectObjective;
                }
                if (!string.IsNullOrWhiteSpace(data.ProjectResult))
                {
                    caseProjectRow.ProjectResult = data.ProjectResult;
                }
                if (!string.IsNullOrWhiteSpace(data.ProjectTarget))
                {
                    caseProjectRow.ProjectTarget = data.ProjectTarget;
                }
                caseProjectRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                caseProject.UpdateOnlyPlainText(caseProjectRow);
            }
            else {

                caseProject.InsertOnlyPlainText(new CaseProjectRow{
                    CaseID = caseID,
                    ProposerTypeID = data.ProposerTypeID,
                    ProposerTypeOther = data.ProposerTypeOther,
                    ProjectTitle = data.ProjectTitle,
                    ProposerEN = data.ProposerEN,
                    ObjectiveToHelp = data.ObjectiveToHelp,
                    ProjectInAction = data.ProjectInAction,
                    Portfolio = data.Portfolio,
                    ProjectObjective = data.ProjectObjective,
                    ProjectResult = data.ProjectResult,
                    ProjectTarget = data.ProjectTarget,
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                });
            }

            caseProject.Dispose();
 
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="caseID"></param>
        /// <returns></returns>
        public int InsertOrupdateProjectContactPerson(ProjectContactPersonData data, int caseID)
        {
            int contactPersonID = 0;
            ProjectContactPersonCollection_Base projectPerson = new ProjectContactPersonCollection_Base(CSystems.ProcessID);
            ProjectContactPersonRow projectContactRow = projectPerson.GetByPrimaryKey(data.ContactID);
            projectPerson.Dispose();
            if (projectContactRow != null)
            {

                projectContactRow.FirstName = data.FirstName;
                projectContactRow.LastName = data.LastName;
                projectContactRow.Email = data.Email;
                projectContactRow.TelephoneNo = data.TelephoneNo;
                projectContactRow.FaxNo = data.FaxNo;

                projectPerson = new ProjectContactPersonCollection_Base(CSystems.ProcessID);
                projectPerson.UpdateOnlyPlainText(projectContactRow);
                projectPerson.Dispose();

                contactPersonID = projectContactRow.ContactID;
            }
            else
            {
                projectPerson = new ProjectContactPersonCollection_Base(CSystems.ProcessID);
                contactPersonID = projectPerson.InsertOnlyPlainText(new ProjectContactPersonRow
                {
                    CaseID = caseID,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Email = data.Email,
                    TelephoneNo = data.TelephoneNo,
                    FaxNo = data.FaxNo
                });
                projectPerson.Dispose();
            }
            return contactPersonID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactID"></param>
        /// <param name="addressID"></param>
        public void InsertCoordinatorAddress(int contactID, int addressID)
        {
            DalBase dal = new DalBase();
            CoordinatorAddressCollection_Base coordinatorAddress = new CoordinatorAddressCollection_Base(CSystems.ProcessID);
            coordinatorAddress.DeleteByPrimaryKey(contactID, addressID);
            coordinatorAddress.Dispose();
            coordinatorAddress = new CoordinatorAddressCollection_Base(CSystems.ProcessID);
            coordinatorAddress.InsertOnlyPlainText(new CoordinatorAddressRow
            {
                ContactID = contactID,
                AddressID = addressID,
                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
            });
            coordinatorAddress.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="addressID"></param>
        /// <param name="caseID"></param>
        public void InsertProjectAddress(ProjectAddressData data,int addressID, int caseID)
        {
            DalBase dal = new DalBase();
            ProjectAddressCollection_Base projectAddress = new ProjectAddressCollection_Base(CSystems.ProcessID);
            projectAddress.DeleteByPrimaryKey(caseID, addressID);
            projectAddress.Dispose();
            projectAddress = new ProjectAddressCollection_Base(CSystems.ProcessID);
            projectAddress.InsertOnlyPlainText(new ProjectAddressRow
            {
                CaseID = caseID,
                AddressID = addressID,
                Email = data.Email,
                TelephoneNo = data.TelephoneNo,
                FaxNo = data.FaxNo,
                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
            });
            projectAddress.Dispose();
        }




        public ProjectContactPersonDataResponse GetCasepPojectContactPerson(int caseID) 
        {
            ProjectContactPersonDataResponse res = new ProjectContactPersonDataResponse();
            ProjectContactPersonCollection_Base projectContact = new ProjectContactPersonCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>();
            var personContactData = projectContact.GetRow(parameter, "CaseID=" + caseID);
            projectContact.Dispose();
            res.ProjectContactPerson = new ProjectContactPersonRow();

            if (personContactData != null) {
                parameter = new List<SqlParameter>();
                CoordinatorAddressCollection_Base coordinatorAddress = new CoordinatorAddressCollection_Base(CSystems.ProcessID);
                var coordinatorAddressData = coordinatorAddress.GetRow(parameter, "ContactID=" + personContactData.ContactID);
                coordinatorAddress.Dispose();
                res.Address = new AddressRow();
                if (coordinatorAddressData != null) 
                {
                    AddressCollection_Base address = new AddressCollection_Base(CSystems.ProcessID);
                    res.Address = address.GetByPrimaryKey(coordinatorAddressData.AddressID);
                    address.Dispose();
                }
                res.ProjectContactPerson = personContactData;
            }
            return res;
        }
        public CaseProjectReferencePersonRow[] CaseProjectReferencePerson(int caseID) 
        {
            CaseProjectReferencePersonCollection_Base caseProjectReference = new CaseProjectReferencePersonCollection_Base(CSystems.ProcessID);
            CaseProjectReferencePersonRow[] res = caseProjectReference.GetByCaseID(caseID);
            caseProjectReference.Dispose();
            return res;
        }


        public CaseProjectRow GetMainCasepPoject(int caseID)
        {            
            CaseProjectCollection_Base caseProject = new CaseProjectCollection_Base(CSystems.ProcessID);
            CaseProjectRow res = caseProject.GetByPrimaryKey(caseID);
            caseProject.Dispose();
            return res;
        }

        public void InsertCaseOwnerDepartment(int applicantID, int caseID, int depID)
        {
            var provinID = (Singleton.SingletonDepartment.Instance.DepartmentItem.Where(o => o.DepartmentID == depID).Select(c => c.ProvinceID).FirstOrDefault());
            DalBase dal = new DalBase();
            CaseOwnerDepartmentCollection_Base cod = new CaseOwnerDepartmentCollection_Base(CSystems.ProcessID);
            cod.InsertOnlyPlainText(new CaseOwnerDepartmentRow
            {
                CaseID = caseID,
                DepartmentID = depID,
                ProvinceID = provinID,
                StatusID = 1,
                WorkStepID = 1,
                IsAppeal = false,
                ModifiedDate = dal.GetSqlNow(provinID)
            });
            cod.Dispose();
            CaseApplicantMapOwnerDepartmentCollection_Base obj = new CaseApplicantMapOwnerDepartmentCollection_Base(CSystems.ProcessID);
            obj.InsertOnlyPlainText(new CaseApplicantMapOwnerDepartmentRow
            {
                ApplicantID = applicantID,
                DepartmentID = depID,
                ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
            });
            obj.Dispose();           

        }

    }
}
