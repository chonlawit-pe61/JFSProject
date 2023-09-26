using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class SMSService
    {
        /// <summary>
        /// ปิดส่วนนี้ไปก่อน เพราะยังไม่อนุมัติให้ใช้ระบบ SMS 
        /// </summary>
        /// <param name="caseID"></param>
        /// <param name="applicantID"></param>
        /// <param name="phonenumber"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<SMSDataResult> SendSMSAsync(int caseID, int applicantID, string phonenumber, string message)
        {
            SMSDataResult resData = new SMSDataResult();
            int processID = CSystemsAsync.ProcessID;
            try
            {
                //// ก่อน Deploy ให้มาปลดล็อคตรงนี้
#if DEBUG
                //    phonenumber = "0892792972";
#endif

                //PersonCollection_Base obj = new PersonCollection_Base(processID);
                //var personRow = obj.GetByPrimaryKey(personID);
                //obj.Dispose();
                //if (personRow != null)
                //{
                SMSApiService service = new SMSApiService();
                resData = await service.SendSMSAsync(phonenumber, message, "Smart-SMS").ConfigureAwait(true);





                // }


            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }
            return resData;
        }
        public static async Task<SMSDataResult> SendOTPAsync(string phoneNumber, string message, string OTP, int minutTimeout = 5)
        {
            SMSDataResult resData = new SMSDataResult();
            int processID = CSystemsAsync.ProcessID;
            try
            {
#if DEBUG
                phoneNumber = "0892792972";
#endif
                // var OTP = Helpers.Utility.RandomNumber(1000, 9999);
                if (string.IsNullOrWhiteSpace(OTP))
                {
                    OTP = Helpers.Utility.RandomNumber(1000, 9999).ToString();
                }
                var SenderName = "OTP_SMS";
                //string message = $"OTP เข้าใช้งานระบบกองทุน(JFS)คือ {OTP}";
                SMSApiService service = new SMSApiService();
                resData = await service.SendSMSAsync(phoneNumber, message, SenderName).ConfigureAwait(true); ;
                if (resData.Status == "0")
                {
                    //บันทึก Log เฉพาะ OTP
                    OTPLogCollection_Base obj = new OTPLogCollection_Base(processID);
                    obj.Insert(new OTPLogRow
                    {
                        MessageID = resData.Result.phone_number_list[0].message_id,
                        PhoneNumber = phoneNumber,
                        OTP = OTP,
                        ModifiedDate = DalBase.SqlNowIncludePd(processID),
                        ExpiryDate = DateTime.Now.AddMinutes(minutTimeout)//กำหนดหมดอายุภายใน 5 นาที
                    });
                    obj.Dispose();

                    //บันทึก Log รวม
                    ShortMessageLogCollection_Base logsms = new ShortMessageLogCollection_Base(processID);
                    logsms.Insert(new ShortMessageLogRow
                    {
                        MessageID = resData.Result.phone_number_list[0].message_id,
                        Phonenumber = phoneNumber,
                        ShortMessage = message,
                        SendStatus = "Delivery",
                        SenderName = SenderName,
                        UsedCredit = resData.Result.phone_number_list[0].used_credit,
                        RemainCredit = resData.Result.remaining_credit,
                        DateCreated = DalBase.SqlNowIncludePd(processID),
                        ModifiedDate = DalBase.SqlNowIncludePd(processID),
                    });
                    logsms.Dispose();
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }
            return resData;
        }

        public static async Task<SMSDataResult> SendOTPVerifyMobileAsync(string phoneNumber, int memberID, int minutTimeout = 5)
        {
            SMSDataResult resData = new SMSDataResult();
            int processID = CSystemsAsync.ProcessID;
            try
            {
#if DEBUG
                phoneNumber = "0892792972";
#endif
                var OTP = Helpers.Utility.RandomNumber(1000, 9999).ToString();

                var SenderName = "OTP_SMS";
                string message = $"OTP ระบบยื่นคำขอ(กองทุนยุติธรรม)คือ {OTP}";
                SMSApiService service = new SMSApiService();
                resData = await service.SendSMSAsync(phoneNumber, message, SenderName).ConfigureAwait(true);
                if (resData.Status == "0")
                {
                    MemberRenewCollection_Base obj = new MemberRenewCollection_Base(processID);
                    obj.Insert(new MemberRenewRow
                    {
                        Token = OTP,
                        VerificationType = "mobile",
                        MemberID = memberID,
                        ExpireDate = DateTime.Now.AddMinutes(minutTimeout)//กำหนดหมดอายุภายใน 5 นาที
                    });
                    obj.Dispose();

                    //บันทึก Log รวม
                    ShortMessageLogCollection_Base logsms = new ShortMessageLogCollection_Base(processID);
                    logsms.Insert(new ShortMessageLogRow
                    {
                        MessageID = resData.Result.phone_number_list[0].message_id,
                        Phonenumber = phoneNumber,
                        ShortMessage = message,
                        SendStatus = "Delivery",
                        SenderName = SenderName,
                        UsedCredit = resData.Result.phone_number_list[0].used_credit,
                        RemainCredit = resData.Result.remaining_credit,
                        DateCreated = DalBase.SqlNowIncludePd(processID),
                        ModifiedDate = DalBase.SqlNowIncludePd(processID),
                    });
                    logsms.Dispose();
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }
            return resData;
        }

        /// <summary>
        /// บันทึกข้อมูล Log สำหรับส่งแจ้งเตือนเกี่ยวกับสำนวน ผู้ขอรับความช่วยเหลือ
        /// </summary>
        /// <param name="req">SMSSendLogData</param>
        /// <returns></returns>
        public static int InsertSmsSendHistory(SMSSendLogData req)
        {
            int smsID = 0;
            DalBase dal = new DalBase();
            try
            {
                SMSSendLogCollection_Base obj = new SMSSendLogCollection_Base(CSystems.ProcessID);
                obj.Insert(new SMSSendLogRow
                {
                    MessageID = req.MessageID,
                    CaseID = req.CaseID,
                    ApplicantID = req.ApplicantID,
                    TelephoneNumber = req.TelephoneNumber,
                    SendTo = req.SendTo,
                    IsOTP = req.IsOTP,
                    Message = req.Message,
                    SendDate = dal.GetSqlNow(CSystems.ProcessID),
                    SendType = req.SendType,
                    SendStatus = req.SendStatus,
                    SendStatusName = req.SendStatusName,
                    UsedCredit = req.UsedCredit,
                    RemainCredit = req.RemainCredit,
                    SendNote = req.SendNote,
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)

                });
                obj.Dispose();
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return smsID;
        }
        public static bool UpdateSmsSendLogStatus(string messageID, bool sendStatus)
        {
            bool isPass = false;
            DalBase dal = new DalBase();
            try
            {
                SMSSendLogCollection_Base obj = new SMSSendLogCollection_Base(CSystems.ProcessID);
                var row = obj.GetByPrimaryKey(messageID);
                if (row != null)
                {
                    row.SendStatus = sendStatus;
                    row.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                    isPass = obj.Update(row);
                }
                obj.Dispose();
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return isPass;
        }



    }
}
