using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Linkage;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class GovernmentDataService
    {

        public View_ApplicantInspectRow GetData(int inspectID, int applicantID)
        {
            View_ApplicantInspectCollection_Base obj = new View_ApplicantInspectCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@applicantID", System.Data.SqlDbType.Int) { Value = applicantID };
            parameter.Add(sqlpara);
            sqlpara = new SqlParameter("@InspectID", System.Data.SqlDbType.Int) { Value = inspectID };
            parameter.Add(sqlpara);
            string whereSql = "[InspectID] = @InspectID AND [ApplicantID] = @applicantID";
            var row = obj.GetRow(parameter, whereSql);
            obj.Dispose();
            return row;
        }
        public View_ApplicantInspectRow GetData(int applicantID)
        {
            View_ApplicantInspectCollection_Base obj = new View_ApplicantInspectCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@applicantID", System.Data.SqlDbType.Int) { Value = applicantID };
            parameter.Add(sqlpara);
            string whereSql = "[InspectID] IN (9,23) AND [ApplicantID] = @applicantID";
            var row = obj.GetRow(parameter, whereSql);
            obj.Dispose();
            return row;
        }
        /// <summary>
        /// เรียกรายการข้อมูลสำหรับรับรองรายการบุคคลจากฐานข้อมูลการทะเบียนของสำนักทะเบียนกลาง
        /// </summary>
        /// <param name="applicantID">รหัสผู้ขอ</param>
        /// <returns></returns>
        public CitizenRegistrationDataResponse GetCitizenData(int applicantID)
        {
            CitizenRegistrationDataResponse registrationDataResponse = new CitizenRegistrationDataResponse();
            View_ApplicantInspectCollection_Base obj = new View_ApplicantInspectCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@applicantID", System.Data.SqlDbType.Int) { Value = applicantID };
            parameter.Add(sqlpara);
            string whereSql = "[ApplicantID] = @applicantID AND InspectID IN(9,17,23,29)";
            var rows = obj.GetAsArray(parameter, whereSql, "InspectID ASC");
            obj.Dispose();
            foreach (var item in rows)
            {
                if (item.InspectID == 9)
                {
                    //บัตรประจำตัวประชาชน
                    registrationDataResponse.personal = JsonConvert.DeserializeObject<PersonalData>(item.Result);
                }
                else if (item.InspectID == 23)
                {
                    //ภาพใบหน้า
                    registrationDataResponse.personalImage = JsonConvert.DeserializeObject<PersonalImageData>(item.Result);
                }
                else if (item.InspectID == 29)
                {
                    //ทะเบียนราษฎร
                    registrationDataResponse.civilRegistration = JsonConvert.DeserializeObject<CivilRegistrationData>(item.Result);
                }
                else if(item.InspectID == 17)
                {
                    registrationDataResponse.houseParticular = JsonConvert.DeserializeObject<HouseParticularData>(item.Result);
                }
            }
            return registrationDataResponse;
        }
        /// <summary>
        /// เรียกรายการตรวจสอบข้อมูล ที่แสดงข้อมูล  มี/ไม่มี,เคย/ไม่เคย,เป็น/ไม่เป็น  เท่านั้น
        /// </summary>
        /// <param name="applicantID">รหัสผู้ขอ</param>
        /// <returns>List<PersonalInspectDataResponse></returns>
        public List<PersonalInspectDataResponse> GetInspectData(int applicantID)
        {
            List<PersonalInspectDataResponse> res = new List<PersonalInspectDataResponse>();
            View_ApplicantInspectCollection_Base obj = new View_ApplicantInspectCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@applicantID", System.Data.SqlDbType.Int) { Value = applicantID };
            parameter.Add(sqlpara);
            string whereSql = "[ApplicantID] = @applicantID AND InspectValueType <> 4";
            var rows = obj.GetAsArray(parameter, whereSql, "SortOrder ASC");
            obj.Dispose();
            if (rows.Length != 0)
            {
                res = (from q in rows
                       select new PersonalInspectDataResponse
                       {
                           InspectID = q.InspectID,
                           InspectName = q.InspectName,
                           InspectValue =q.InspectValueListName
                       }).ToList();
            }
            return res;
        }

        public int SaveData(int inspectID, int applicantID, string jsonData)
        {
            int inspectValueListID = 0;
            InspectCollection_Base obj = new InspectCollection_Base(CSystems.ProcessID);
            var row = obj.GetByPrimaryKey(inspectID);
            obj.Dispose();
            if (row != null)
            {
                inspectValueListID = SaveJsonData(row, applicantID, jsonData);
            }
            return inspectValueListID;
        }

        /// <summary>
        /// InspectValueTypeID	InspectValueTypeName
        ///1	มี/ไม่มี
        ///2	เคย/ไม่เคย
        ///3	เป็น/ไม่เป็น
        ///4	แสดงข้อมูล
        /// </summary>
        /// <param name="Inspect"></param>
        /// <param name="applicantID"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        private int SaveJsonData(InspectRow Inspect, int applicantID, string jsonData)
        {
            int inspectValueListID = 0;
            DalBase dal = new DalBase();
            try
            {
                inspectValueListID = QueryJsonResult(Inspect.InspectID, Inspect.InspectValueType, jsonData);
                //กรณีที่ยังไม่ได้ลงทะเบียนให้ข้ามการบันทึกข้อมูลออกไป
                if (applicantID != 0)
                {

                    ApplicantInspectCollection_Base obj = new ApplicantInspectCollection_Base(CSystems.ProcessID);
                    obj.DeleteByPrimaryKey(applicantID, Inspect.InspectID);
                    obj.Dispose();
                    ApplicantInspectRow row = new ApplicantInspectRow
                    {
                        InspectID = Inspect.InspectID,
                        ApplicantID = applicantID,
                        Status = true,
                        Result = jsonData,
                        ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                        InspectValueListID = inspectValueListID,// inspectValueListID = QueryJsonResult(Inspect.InspectID, Inspect.InspectValueType, jsonData)
                    };
                    obj = new ApplicantInspectCollection_Base(CSystems.ProcessID);
                    obj.Insert(row);
                    obj.Dispose();
                }

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return inspectValueListID;
        }
        private int QueryJsonResult(int inspectID, int inspectValueType, string json)
        {
            if (IsValidJson(json))
            {
                JToken t1 = JToken.Parse(json);
                switch (inspectID)
                {
                    case (int)InspectServiceID.Poor:
                        if (t1.Type.ToString() == "Object")
                        {
                            dynamic Result = JObject.Parse(json);
                            if ((string)Result["result"] == "NO")
                            {
                                json = "";
                            }
                        }
                        break;
                    case (int)InspectServiceID.Drug:
                    case (int)InspectServiceID.JuvenileOffender:
                    case (int)InspectServiceID.Seize:
                        if (t1.Type.ToString() == "Array")
                        {
                            dynamic Results = JArray.Parse(json);
                            if (Results.Count == 0)
                            {
                                json = "";
                            }
                        }
                        break;
                    //case (int)InspectServiceID.WorkforceDevelopment:
                    //    if (t1.Type.ToString() == "Object")
                    //    {
                    //        dynamic Result = JObject.Parse(json);
                    //        if ((string)Result["result"] == "NO")
                    //        {
                    //            json = "";
                    //        }
                    //    }
                    //    break;
                    default:
                        //NULL
                        break;
                }
            }
            else
            {
                json = json.Replace(" ", "");
                if (json.Equals("datanotfound", StringComparison.OrdinalIgnoreCase))
                {
                    json = "";
                }
                else if (json.Equals("00404", StringComparison.OrdinalIgnoreCase))
                {
                    json = "";
                }
            }
            int InspectValueListID = 4;
            switch (inspectValueType)
            {
                case 1:
                    InspectValueListID = !string.IsNullOrWhiteSpace(json) ? 1 : 2;
                    break;
                case 2:
                    InspectValueListID = !string.IsNullOrWhiteSpace(json) ? 3 : 4;
                    break;
                case 3:
                    InspectValueListID = !string.IsNullOrWhiteSpace(json) ? 5 : 6;
                    break;
                default:
                    InspectValueListID = 7;
                    break;
            }
            return InspectValueListID;
        }
        private static bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, jex);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string GetImage(int applicantID, bool mineType = true)
        {
            string imagbase64 = "";
            ApplicantInspectCollection_Base obj = new ApplicantInspectCollection_Base(CSystems.ProcessID);
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@applicantID", System.Data.SqlDbType.Int) { Value = applicantID };
            parameter.Add(sqlpara);
            var row = obj.GetRow(parameter, "applicantID = @applicantID AND InspectID=23");
            obj.Dispose();
            if (row != null)
            {
                JToken t1 = JToken.Parse(row.Result);
                if (t1.Type.ToString() == "Object")
                {
                    dynamic Result = JObject.Parse(row.Result);
                    if (mineType)
                    {
                        imagbase64 = (string)Result["mineType"] + "," + (string)Result["image"];
                    }
                    else
                    {
                        imagbase64 = (string)Result["image"];
                    }
                }
                else
                {
                    imagbase64 = "";
                }
            }
            return imagbase64;

        }
        //มี/ไม่
        private int Has()
        {
            return 1;
        }
        //เป็น/ไม่เป็น
        private int Be()
        {
            return 1;
        }

        //เคย/ไม่เคย
        private int Use()
        {
            return 1;
        }
      
    }
}
