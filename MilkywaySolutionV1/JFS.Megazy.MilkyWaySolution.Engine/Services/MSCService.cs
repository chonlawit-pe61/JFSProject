using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.MSC;
using JFS.Megazy.MilkyWaySolution.Engine.Helpers;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Extensions;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class MSCService
    {


        private static readonly string MSCUrl = ConfigurationManager.AppSettings["MSCUrl"].ToString();
        private static readonly string MSCUsername = ConfigurationManager.AppSettings["MSCUsername"].ToString();
        private static readonly string MSCPassword = ConfigurationManager.AppSettings["MSCPassword"].ToString();
        private static readonly bool SendMSC = ConfigurationManager.AppSettings["SendToMSC"].ToString() == "1";
        private readonly HttpClient _httpClient;
        public MSCService() : this(null) { }
        public MSCService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

        public static int InsertMSCCase(MSCDataRequest data)
        {

            
            int id = 0;
            if (!string.IsNullOrWhiteSpace(data.ReferenceMSCID) && !string.IsNullOrWhiteSpace(data.ReferenceMSCCode))
            {

                DalBase dal = new DalBase();
                CaseApplicantRequestCollection_Base caseApplicantTemp = new CaseApplicantRequestCollection_Base(CSystems.ProcessID);
                int departmentID = 2; //กองทุนยุติธรรม ส่วนกลาง
                //msc department
                DepartmentCollection_Base department = new DepartmentCollection_Base(CSystems.ProcessID);
                var departmentRow = department.GetRow(new List<System.Data.SqlClient.SqlParameter>(), $"DepartmentCode='{data.DivnID}' AND IsActive=1");
                department.Dispose();
                if (departmentRow != null)
                {
                    departmentID = departmentRow.DepartmentID;
                }
                CaseApplicantRequestRow ret = new CaseApplicantRequestRow();
                var row = new CaseApplicantRequestRow
                {
                    ReferenceMSCID = int.Parse(data.ReferenceMSCID),
                    ReferenceMSCCode = data.ReferenceMSCCode,
                    Subject = data.Subject,
                    TelephoneNo = data.TelephoneNo.Length <= 20 ? data.TelephoneNo : data.TelephoneNo.Substring(0, 19),
                    Gender = data.Gender == "2" ? "f" : "m",
                    Title = data.Title,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    ProvinceID = int.Parse(data.ProvinceID),//รหัสจังหวัดจากระบบ MSC
                    DepartmentID = departmentID,//รหัสหน่วยงานสำนักงานยุติธรรมจากระบบ MSC นำมา Mapping กับรหัส DepartmentID ของกองทุน
                    ProvinceName = data.ProvinceName,
                    PostCode = data.PostCode,
                    CardID = data.CitizenID,
                    ChannelID = 10002,//10002= MSC
                                      //Defactive = data.Defactive == "T" ? true : false,
                    Remark = data.Remark,
                    CreateDate = Utility.ConvertStringToDate(data.CreateDate),
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                    StatusID = 1,
                    Central = data.Central
                };
                var raceID = Utility.TryParseToInt(data.Race);
                var educationLeveID = Utility.TryParseToInt(data.Education);
                var religionID = Utility.TryParseToInt(data.Religion);
                var nationalityID = Utility.TryParseToInt(data.Natinality);
                if (raceID > 0)
                    row.RaceID = raceID;
                if (educationLeveID > 0)
                    row.EducationLevel = educationLeveID;
                if (religionID > 0)
                    row.ReligionID = religionID;
                if (nationalityID > 0)
                    row.NationalityID = nationalityID;
                if (!string.IsNullOrEmpty(data.DateOfBirth))
                    row.DateOfBirth = Utility.ConvertYYYYMMDDStringToDate(data.DateOfBirth);
                id = caseApplicantTemp.InsertOnlyPlainText(row);
                caseApplicantTemp.Dispose();

                //#STARTบันทึกลงตาราง เพิ่มเติมข้อมูลส่วนที่เป็นที่อยุ่ เชื้อชาติ ศาสนา
                if (!string.IsNullOrWhiteSpace(data.JsonAdditional))
                {
                    FormRequestService requestService = new FormRequestService();
                    requestService.InsInsertOrUpdateRequestExtension(id, data.JsonAdditional);
                }

            }
            

            return id;
        }

        public static CaseApplicantRequestRow UpdateStatusCaseChange(int transactionId, int status)
        {

            CaseApplicantRequestRow caseTemp = null;
            CaseApplicantRequestCollection_Base caseApplicantTemp = new CaseApplicantRequestCollection_Base(CSystems.ProcessID);
            caseTemp = caseApplicantTemp.GetByPrimaryKey(transactionId);
            DalBase dal = new DalBase();
            if (caseTemp != null)
            {
                caseTemp.StatusID = status;
                caseTemp.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                caseApplicantTemp.UpdateOnlyPlainText(caseTemp);
            }
            caseApplicantTemp.Dispose();
            return caseTemp;
        }



        #region Send to MSC

        private static async Task<bool> SendToMSCAsync(string jsonStr, string sendType)
        {
            if (SendMSC)
            {
                try
                {
                    var client = new RestClient($"{MSCUrl}/{sendType}");
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddParameter("application/json", jsonStr, ParameterType.RequestBody);
                    IRestResponse response = await client.ExecutePostAsync(request).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    DalBase.ExceptEngine.KeepLogOnly(CSystemsAsync.ProcessID, ex);
                }

            }
            return true;
        }


        /// <summary>
        /// อัปเดท ข้อมูล รหัส เลขรับเรื่อง ไปยัง msc http://api.moj.go.th/msc/ws.php/getPetByWS
        /// Async แบบที่ 1
        /// </summary>
        /// <param name="mSCSstatus"></param>
        public static async Task UpdateStatusCase(MSCSstatusCase mSCSstatus)
        {
            if (mSCSstatus != null)
            {
                mSCSstatus.Username = MSCUsername;
                mSCSstatus.Password = MSCPassword;
                var jsonStr = JsonConvert.SerializeObject(mSCSstatus);
                await SendToMSCAsync(jsonStr, "getPetByWS").ConfigureAwait(false);
            }
        }

        /// <summary> 
        /// ส่งสถานะกลับไปยัง MSC เมื่อมีการเปลี่ยนสถานะ http://api.moj.go.th/msc/ws.php/getReport
        /// Async แบบที่ 2
        /// </summary>
        /// <param name="mSCSstatus"></param>
        public static async Task ReportStatusCase(MSCReportStatusCase mSCSstatus)
        {
            if (mSCSstatus != null)
            {
                mSCSstatus.Username = MSCUsername;
                mSCSstatus.Password = MSCPassword;
                var jsonStr = JsonConvert.SerializeObject(mSCSstatus);
                // _ = SendToMSCAsync(jsonStr, "getReport");
                await SendToMSCAsync(jsonStr, "getReport").ConfigureAwait(false);
            }
        }

        #endregion

        #region GET MSC
        /// <summary>
        /// บริการข้อมูลจังหวัด https://api.moj.go.th/msc/ws.php/provinceList
        /// </summary>
        /// <param name="provinceName"></param>
        /// <returns></returns>
        public async Task<MSCAmpherResult> GetProvinceListAsync(MSCProvince mSCProvince)
        {
            if (mSCProvince == null)
            {
                throw new ArgumentNullException(nameof(mSCProvince));
            }
            mSCProvince.Username = MSCUsername;
            mSCProvince.Password = MSCPassword;
            var requestUrl = new StringBuilder();
            requestUrl.Append($"https://api.moj.go.th/msc/ws.php/provinceList");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;//Fix สำหรับแก้ไขปัญหา: The request was aborted: Could not create SSL/TLS secure channel.
            var httpClient = _httpClient ?? new HttpClient();
            var jsonStr = JsonConvert.SerializeObject(mSCProvince);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent httpContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestUrl.ToString(), httpContent)
                                           .ConfigureAwait(false);
            var contents = await response.Content.ReadAsStringAsync()
                                        .ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage =
                    $"Failed to retrieve a MSC result. Status Code: {response.StatusCode}. Message: {contents}";
                return new MSCAmpherResult
                {
                    Status = response.StatusCode.ToString(),
                    ErrorMessage = errorMessage,
                };
            }
            // Get content from json into rich object model.
            var resData = JsonConvert.DeserializeObject<List<AmpherDataResponse>>(contents);
            return new MSCAmpherResult
            {
                Status = response.StatusCode.ToString(),
                Result = resData
            };
        }
        /// <summary>
        /// Service ให้าบริการสำหรับออกเลข MSC UR:https://api.moj.go.th/msc/wsCreate.php/CreatePet
        /// </summary>
        /// <param name="dataRequest">PETDataRequest</param>
        /// <returns></returns>
        public async Task<MSCPETResult> CreatePET(PETDataRequest dataRequest)
        {
            if (dataRequest == null)
            {
                throw new ArgumentNullException(nameof(dataRequest));
            }
            if (string.IsNullOrWhiteSpace(dataRequest.submitDate))
            {
                throw new ArgumentNullException(nameof(dataRequest.submitDate));
            }
            if (string.IsNullOrWhiteSpace(dataRequest.submitDate))
            {
                throw new ArgumentNullException(nameof(dataRequest.submitDate));
            }
            if (string.IsNullOrWhiteSpace(dataRequest.petName))
            {
                throw new ArgumentNullException(nameof(dataRequest.petName));
            }
            //if (string.IsNullOrWhiteSpace(dataRequest.petDetail))
            //{
            //    throw new ArgumentNullException(nameof(dataRequest.petDetail));
            //}
            if (string.IsNullOrWhiteSpace(dataRequest.citizenId))
            {
                throw new ArgumentNullException(nameof(dataRequest.citizenId));
            }
            if (string.IsNullOrWhiteSpace(dataRequest.gender))
            {
                throw new ArgumentNullException(nameof(dataRequest.gender));
            }
            if (string.IsNullOrWhiteSpace(dataRequest.firstName))
            {
                throw new ArgumentNullException(nameof(dataRequest.firstName));
            }
            if (string.IsNullOrWhiteSpace(dataRequest.prename))
            {
                throw new ArgumentNullException(nameof(dataRequest.prename));
            }
            if (string.IsNullOrWhiteSpace(dataRequest.lastName))
            {
                throw new ArgumentNullException(nameof(dataRequest.lastName));
            }
            dataRequest.Username = MSCUsername;
            dataRequest.Password = MSCPassword;
            var requestUrl = new StringBuilder();
            requestUrl.Append($"https://api.moj.go.th/msc/wsCreate.php/CreatePet");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;//Fix สำหรับแก้ไขปัญหา: The request was aborted: Could not create SSL/TLS secure channel.
            var httpClient = _httpClient ?? new HttpClient();
            var jsonStr = JsonConvert.SerializeObject(dataRequest);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent httpContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestUrl.ToString(), httpContent)
                                           .ConfigureAwait(false);
            var contents = await response.Content.ReadAsStringAsync()
                                        .ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage =   $"Failed to retrieve a MSC result. Status Code: {response.StatusCode}. Message: {contents}";
                return new MSCPETResult
                {
                    Status = response.StatusCode.ToString(),
                    ErrorMessage = errorMessage,
                };
            }

            List<PETDataResponse> resData = new List<PETDataResponse>();
            try
            {
                resData = JsonConvert.DeserializeObject<List<PETDataResponse>>(contents);
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystemsAsync.ProcessID, ex);
            }
           
            return new MSCPETResult
            {
                Status = response.StatusCode.ToString(),
                Result = resData
            };

        }
        #endregion

    }
}
