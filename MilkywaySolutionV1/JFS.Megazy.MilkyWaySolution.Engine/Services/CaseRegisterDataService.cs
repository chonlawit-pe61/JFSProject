using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Singleton;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class CaseRegisterDataService
    {
        public CaseRegisterDataResponse GetCaseRegisterDataResponse(int caseID, int applicantID, int depID, int memberID = 0)
        {
            CaseRegisterDataResponse result = new CaseRegisterDataResponse();
            List<SqlParameter> listParameter = new List<SqlParameter>();
            SqlParameter sqlParameter = new SqlParameter("@caseID", System.Data.SqlDbType.Int) { Value = caseID };
            listParameter.Add(sqlParameter);
            sqlParameter = new SqlParameter("@applicantID", System.Data.SqlDbType.Int) { Value = applicantID };
            listParameter.Add(sqlParameter);
            sqlParameter = new SqlParameter("@depID", System.Data.SqlDbType.Int) { Value = depID };
            listParameter.Add(sqlParameter);
            string wheresql = "";
            if(memberID != 0)
            {
                wheresql = $"[CaseID] = @caseID AND [ApplicantID] = @applicantID AND [DepartmentID] = @depID AND [MemberID] = {memberID}";
            }
            else
            {
                wheresql = $"[CaseID] = @caseID AND [ApplicantID] = @applicantID AND [DepartmentID] = @depID";
            }
            View_CaseApplicationMemberMapping2Collection_Base casemapmember = new View_CaseApplicationMemberMapping2Collection_Base(CSystems.ProcessID);
            var casemapmemberRow = casemapmember.GetRow(listParameter, wheresql);
            casemapmember.Dispose();
            if (casemapmemberRow != null)
            {
                CaseProjectDataRequest projectDataRequest = new CaseProjectDataRequest();

                listParameter = new List<SqlParameter>();
                sqlParameter = new SqlParameter("@caseID", System.Data.SqlDbType.Int) { Value = caseID };
                listParameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@applicantID", System.Data.SqlDbType.Int) { Value = applicantID };
                listParameter.Add(sqlParameter);
                CaseExpenseExtensionCollection_Base caseExpense = new CaseExpenseExtensionCollection_Base(CSystems.ProcessID);
                var caseExpenseRow = caseExpense.GetAsArray(listParameter, $"[CaseID] = @caseID AND [ApplicantID] = @applicantID", "");
                caseExpense.Dispose();
                result.CaseExpenseEx = (from q in caseExpenseRow
                                        select new CaseExpenseExtensionData
                                        {
                                            CaseID = q.CaseID,
                                            ApplicantID = q.ApplicantID,
                                            ExpenseID = q.ExpenseID,
                                            Amount = q.Amount,
                                            Unit = q.Unit,
                                            PriceThreshold = q.PriceThreshold
                                        }).ToList();
                CaseApplicantRequestRow requestRow = new CaseApplicantRequestRow();
                requestRow.FirstName = casemapmemberRow.FirstName;
                requestRow.LastName = casemapmemberRow.LastName;
                requestRow.Title = casemapmemberRow.Title;
                requestRow.Subject = casemapmemberRow.Subject;
                CaseApplicationData caseApplication = new CaseApplicationData { DepartmentID = depID };
                CaseApplicantData caseApplicant = new CaseApplicantData { ApplicantID = applicantID };
                projectDataRequest.CaseApplicantData = caseApplicant;
                projectDataRequest.CaseApplicationData = caseApplication;

                listParameter = new List<SqlParameter>();
                sqlParameter = new SqlParameter("@caseID", System.Data.SqlDbType.Int) { Value = caseID };
                listParameter.Add(sqlParameter);
                ProjectAddressCollection_Base projectAddress = new ProjectAddressCollection_Base(CSystems.ProcessID);
                var projectAddressRow = projectAddress.GetRow(listParameter, "[CaseID]=@caseID");
                projectAddress.Dispose();
                if (projectAddressRow != null)
                {
                    ProjectAddressDataRequest addressDataRequest = new ProjectAddressDataRequest();
                    ProjectAddressData projectAddressData = new ProjectAddressData();
                    AddressRowRes addressRowRes = new AddressRowRes();
                    projectAddressData.AddressID = projectAddressRow.AddressID;
                    projectAddressData.Email = projectAddressRow.Email;
                    projectAddressData.TelephoneNo = projectAddressRow.TelephoneNo;
                    AddressCollection_Base address = new AddressCollection_Base(CSystems.ProcessID);
                    var addressRow = address.GetByPrimaryKey(projectAddressRow.AddressID);
                    address.Dispose();
                    if (addressRow != null)
                    {

                        addressRowRes.SubdistrictName = SingletonProvince.Instance.SubdistrictRow.Where(p => p.SubdistrictID == addressRow.SubdistrictID).FirstOrDefault().SubdistrictName;
                        addressRowRes.DisctrictName = SingletonProvince.Instance.DistrictRow.Where(p => p.DistrictID == addressRow.DisctrictID).FirstOrDefault().DistrictName;
                        addressRowRes.ProvinceName = SingletonProvince.Instance.ProvinceRow.Where(p => p.ProvinceID == addressRow.ProvinceID).FirstOrDefault().ProvinceName;
                        addressRowRes.ProvinceID = addressRow.ProvinceID;
                        addressRowRes.DisctrictID = addressRow.DisctrictID;
                        addressRowRes.SubdistrictID = addressRow.SubdistrictID;
                    }
                    addressDataRequest.AddressRow = addressRowRes;
                    addressDataRequest.ProjectAddress = projectAddressData;
                    projectDataRequest.ProjectAddressData = addressDataRequest;
                }

                listParameter = new List<SqlParameter>();
                sqlParameter = new SqlParameter("@caseID", System.Data.SqlDbType.Int) { Value = caseID };
                listParameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@applicantID", System.Data.SqlDbType.Int) { Value = applicantID };
                listParameter.Add(sqlParameter);
                sqlParameter = new SqlParameter("@depID", System.Data.SqlDbType.Int) { Value = depID };
                listParameter.Add(sqlParameter);
                CaseApplicationCollection_Base application = new CaseApplicationCollection_Base(CSystems.ProcessID);
                var applicationRow = application.GetByPrimaryKey(caseID);
                application.Dispose();
                if (applicationRow != null)
                {
                    requestRow.ChannelID = applicationRow.ChannelID;
                    //result.caseApplicant.ChannelName = SingletonComplaintChannel.Instance.ComplaintChannelItem.Where(p => p.ChannelID == applicationRow.ChannelID).FirstOrDefault().ChannelName;
                }
                result.caseApplicant = requestRow;
                CaseProjectCharacteristicsCollection_Base characteristics = new CaseProjectCharacteristicsCollection_Base(CSystems.ProcessID);
                var characteristicsRow = characteristics.GetByCaseID(caseID);
                characteristics.Dispose();
                CaseProjectCharacteristicsData[] caseProjectCharacteristics = new CaseProjectCharacteristicsData[characteristicsRow.Length];
                CaseProjectData caseProjectData = new CaseProjectData();
                caseProjectData.CaseID = caseID;
                if (characteristicsRow.Length > 0)
                {
                    caseProjectCharacteristics = (from q in characteristicsRow
                                                  select new CaseProjectCharacteristicsData
                                                  {
                                                      CaseID = caseID,
                                                      CharacteristicID = q.CharacteristicID,
                                                      Remark = q.Remark
                                                  }).ToArray();
                }
                CaseProjectCollection_Base caseproject = new CaseProjectCollection_Base(CSystems.ProcessID);
                var caseprojectRow = caseproject.GetByPrimaryKey(caseID);
                caseproject.Dispose();
                if (caseprojectRow != null)
                {
                    caseProjectData.ProjectObjective = caseprojectRow.ProjectObjective;
                    caseProjectData.ProjectResult = caseprojectRow.ProjectResult;
                }
                projectDataRequest.CaseProjectData = caseProjectData;
                projectDataRequest.CaseProjectCharacteristicsData = caseProjectCharacteristics;
                ProjectLocationCollection_Base projectLocation = new ProjectLocationCollection_Base(CSystems.ProcessID);
                var projectLocationRow = projectLocation.GetByPrimaryKey(caseID);
                projectLocation.Dispose();
                if (projectLocationRow != null)
                {
                    ProjectLocationAddressDataRequest locationAddressDataRequest = new ProjectLocationAddressDataRequest();
                    ProjectLocationData projectLocationData = new ProjectLocationData();
                    AddressRowRes addressRowRes = new AddressRowRes();
                    projectLocationData.LocationName = projectLocationRow.LocationName;
                    AddressCollection_Base address = new AddressCollection_Base(CSystems.ProcessID);
                    var addressRow = address.GetByPrimaryKey(projectLocationRow.AddressID);
                    address.Dispose();
                    addressRowRes.SubdistrictName = SingletonProvince.Instance.SubdistrictRow.Where(p => p.SubdistrictID == addressRow.SubdistrictID).FirstOrDefault().SubdistrictName;
                    addressRowRes.DisctrictName = SingletonProvince.Instance.DistrictRow.Where(p => p.DistrictID == addressRow.DisctrictID).FirstOrDefault().DistrictName;
                    addressRowRes.ProvinceName = SingletonProvince.Instance.ProvinceRow.Where(p => p.ProvinceID == addressRow.ProvinceID).FirstOrDefault().ProvinceName;
                    addressRowRes.PostCode = addressRow.PostCode;
                    addressRowRes.SubdistrictID = addressRow.SubdistrictID;
                    addressRowRes.DisctrictID = addressRow.DisctrictID;
                    addressRowRes.ProvinceID = addressRow.ProvinceID;
                    locationAddressDataRequest.ProjectLocation = projectLocationData;
                    locationAddressDataRequest.AddressRow = addressRowRes;

                    projectDataRequest.ProjectLocation = locationAddressDataRequest;
                }
                // result.caseMetaData

                CaseProjectMetaData caseProjectMetaData = new CaseProjectMetaData();
                CaseProjectMetaCollection_Base caseProjectMeta = new CaseProjectMetaCollection_Base(CSystems.ProcessID);
                var caseProjectMetaRow = caseProjectMeta.GetByCaseID(caseID);
                caseProjectMeta.Dispose();
                if (caseProjectMetaRow != null)
                {
                    result.caseMetaData = (from q in caseProjectMetaRow
                                           select new CaseProjectMetaData
                                           {
                                               MetaID = q.MetaID,
                                               CaseID = q.CaseID,
                                               MetaKey = q.MetaKey,
                                               MetaValue = q.MetaValue
                                           }).ToList();
                }
                result.caseProjectData = projectDataRequest;
                return result;
            }
            else
            {
                return result = null;
            }
        }

    }
}
