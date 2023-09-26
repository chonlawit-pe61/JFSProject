using JFS.Megazy.MilkyWaySolution.Engine;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Services;
using MimeKit;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace JFS.Megazy.MilkyWaySolution.Web.Front
{
    public class MessageService
    {
       public static bool SendVerifyAccount(string mailTo, string firstName,string lastName, string verifyToken,int processID = 0)
        {
            string message = "";
            try
            {
               // string template = System.IO.File.ReadAllText(HostingEnvironment.MapPath("/EmailTemplate/verify_account.html"));
                message = ReadHtmlTemplate("verify_account.html");
                message = message.Replace("[[title]]", "เปลี่ยนรหัสผ่าน");
                message = message.Replace("[[name]]", firstName + " " + lastName).Replace("[[code]]", verifyToken);            
                //message = message.Replace("<!--#link-->", link);
            }
            catch (Exception ex)
            {
                if (processID == 0)
                {
                    processID = CSystems.ProcessID;
                }
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }

            //string sendTo = ConfigurationManager.AppSettings["NotifyEmail"].ToString();
            return SendEmailGMAIL(mailTo, "Verify Account", message);            
        }

        public static bool SendNotifyFinalApprove(string mailTo,string applicantName,int caseID,int applicantID,int departmentID,string jfCaseNo,int processID = 0)
        {
            string message = "", subject = "";
            try
            {
                var link = SiteConfig.Instance.GetWebSite() + string.Format("/applicant/details/{0}?caseid={1}&depid={2}", applicantID, caseID, departmentID);
                subject = "สำนวนรอการพิจารณา เลขที่" + jfCaseNo + ' ' + applicantName;
                message = ReadHtmlTemplate("officerfinalapprove.html");
                message = message.Replace("<!--#caseID-->", caseID.ToString());
                message = message.Replace("<!--#title-->", subject);
                message = message.Replace("<!--#applicantName-->", applicantName);
                message = message.Replace("<!--#jfCaseNo-->", jfCaseNo);
                message = message.Replace("<!--#link-->", link);
            }
            catch (Exception ex)
            {
                if (processID == 0)
                {
                    processID = CSystems.ProcessID;
                }
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }
            return SentMultiPart(mailTo,subject, message);
        }

        public static bool SendNotifyDecision(string mailTo, string applicantName, int caseID, int applicantID, int departmentID, string jfCaseNo, string opinionText, string decisionDate, int processID = 0)
        {
            string message = "", subject = "";
            try
            {
                // var link = SiteConfig.Instance.GetWebSite() + string.Format("/applicant/details/{0}?caseid={1}&depid={2}", applicantID, caseID, departmentID);
                subject = opinionText + " เลขที่ " + jfCaseNo + ' ' + applicantName;
                message = ReadHtmlTemplate("decisionresult.html");
                message = message.Replace("<!--#decisiondate-->", decisionDate.ToString());
                message = message.Replace("<!--#opiniontext-->", opinionText);
                message = message.Replace("<!--#title-->", subject);
                message = message.Replace("<!--#applicantName-->", applicantName);
                message = message.Replace("<!--#jfCaseNo-->", jfCaseNo);
                //message = message.Replace("<!--#link-->", link);
            }
            catch (Exception ex)
            {
                if (processID == 0)
                {
                    processID = CSystems.ProcessID;
                }
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }
            return SentMultiPart(mailTo, subject, message);
        }
        public async Task<bool> SendNotifyAssignment(string mailTo, string applicantName,string officername, int caseID, int applicantID, int departmentID, string jfCaseNo,int processID=0)
        {
            string message = "", subject = "";
            try
            {
                var link = SiteConfig.Instance.GetWebSite() + string.Format("/applicant/details/{0}?caseid={1}&depid={2}", applicantID, caseID, departmentID);
                subject = "สำนวนที่ได้รับมอบหมาย เลขที่" + jfCaseNo + ' ' + applicantName;
                message = ReadHtmlTemplate("assignment.html");
                message = message.Replace("<!--#caseID-->", caseID.ToString());
                message = message.Replace("<!--#officername-->", officername);
               // message = message.Replace("<!--#subject-->", subject);
                message = message.Replace("<!--#applicantName-->", applicantName);
                message = message.Replace("<!--#jfCaseNo-->", jfCaseNo);
                message = message.Replace("<!--#link-->", link);
            }
            catch (Exception ex)
            {
                if (processID == 0)
                    processID = CSystems.ProcessID;
                DalBase.ExceptEngine.ThrowException(processID, ex);
            }
           return  await SendAsynMail(mailTo, subject, message).ConfigureAwait(false);
        }

        public static void MailForgetPassword(string username, string email, string password,string filePath)
        {

            try
            {
                string message = "";
                message = ReadHtmlTemplate(filePath);
                message = message.Replace("<!--#username-->", username);
                message = message.Replace("<!--#password-->", password);

                string sendTo = email;
                SendAsyncMail(sendTo, "Forgot Password [STATERKIT]", message);
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }

        }
        //public static bool SendNewRegister(string firstname, string lastname, string email, string byteEmail)
        //{
        //    string message = "";            
        //    string url = ConfigurationManager.AppSettings["RootDomain"].ToString() + "/member/actionVerifiedEmail/?token=" + byteEmail + "";
        //    if (!url.Contains("http"))
        //    {
        //        url = "http:" + url;
        //    }
        //    //url = HttpServerUtility.UrlTokenDecode(url);
        //    try
        //    {
        //        message = ReadHtmlTemplate("register.html");
        //        //message = message.Replace("<!--#contactname-->", firstname + " " + lastname);
        //        message = message.Replace("<!--#contactname-->", email);
        //        message = message.Replace("<!--#email-->", email);
        //        message = message.Replace("<!--#url-->", url);

        //    }
        //    catch (Exception ex)
        //    {
        //        DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
        //    }

        //    //string sendTo = ConfigurationManager.AppSettings["NotifyEmail"].ToString();
        //    string sendTo = email;
        //    return SendEmailGMAIL(sendTo, "Thank you for register to [STATERKIT]", message); ;
        //}
        //public static bool SendForgetPassword(string username, string email, string password)
        //{
        //    string message = "";
        //    //password = Maze.Cypher(password);
        //    try
        //    {
        //        //var link = ConfigurationManager.AppSettings["RootDomain"].ToString() + "/member/renewpassword?m=" + memberID + "&t=" + token;
        //        //if (!link.Contains("http"))
        //        //{
        //        //    link = "http:" + link;
        //        //}
        //        message = ReadHtmlTemplate("forgotpassword.html");
        //        //message = message.Replace("<!--#contactname-->", firstname + " " + lastname);
        //        message = message.Replace("<!--#username-->", username);
        //        message = message.Replace("<!--#password-->", password);
        //        //message = message.Replace("<!--#link-->", link);
        //    }
        //    catch (Exception ex)
        //    {
        //        DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
        //    }

        //    //string sendTo = ConfigurationManager.AppSettings["NotifyEmail"].ToString();
        //    string sendTo = email;
        //    return SendEmailGMAIL(sendTo, "Forgot Password [STATERKIT]", message);            
        //}

            /// <summary>
            /// ส่งเมลแบบ Asysnc แก้ไขโดยเปี๊ยก
            /// </summary>
            /// <param name="recipient"></param>
            /// <param name="subject"></param>
            /// <param name="body"></param>
            /// <returns></returns>
       

        public static void SendAsyncMail(string sendTo, string subject, string body, System.Net.Mail.Attachment[] item = null)
        {

            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    SysMailConfigInfo mailConfig = SiteConfig.Instance.GetMailConfig();
                    mail.To.Add(sendTo);
                    mail.From = new MailAddress(mailConfig.UserName, "STARTERKIT");
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.SubjectEncoding = Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    if (item != null)
                    {
                        foreach (var obj in item)
                        {
                            mail.Attachments.Add(obj);
                        }
                    }

                    SmtpClient smtp = new SmtpClient("secure.emailsrvr.com", 587);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Timeout = 10000;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential
                         (mailConfig.UserName, mailConfig.Password); // ***use valid credentials***              
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = mailConfig.IsSsl;
                    smtp.Send(mail);
                    if (item != null)
                    {
                        foreach (Attachment attachment in item)
                        {
                            attachment.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
        }

        public static bool SendEmailGMAIL(string sendTo, string subject, string body, System.Net.Mail.Attachment[] item = null)
        {
            bool isSuccess = false;
            //var from = "tbexthailand@gmail.com";
            //string pwd = "$tbex2018";
            try
            {
                //ถ้าไม่ใช้ Using จะเกิด Error   it is being used by another process.

                using (MailMessage mail = new MailMessage())
                {
                    SysMailConfigInfo mailConfig = SiteConfig.Instance.GetMailConfig();

                    mail.To.Add(sendTo);
                    mail.From = new MailAddress(mailConfig.UserName, "STATERKIT");
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.SubjectEncoding = Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    if (item != null)
                    {
                        foreach (var obj in item)
                        {
                            mail.Attachments.Add(obj);
                        }
                    }

                    SmtpClient smtp = new SmtpClient("secure.emailsrvr.com", 587);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Timeout = 10000;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential
                         (mailConfig.UserName, mailConfig.Password); // ***use valid credentials***              
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = mailConfig.IsSsl;
                    smtp.Send(mail);
                    if (item != null)
                    {
                        foreach (Attachment attachment in item)
                        {
                            attachment.Dispose();
                        }
                    }
                }
                isSuccess = true;
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return isSuccess;
        }

        public static bool SentMultiPart(string recipient, string subject, string body,int processID = 0)
        {
            bool ret = false;
            try
            {
                if (processID == 0)
                    processID = CSystems.ProcessID;
                HelperService helperClient = new HelperService();
               // CSystems.SetClientCredential(helperClient.ClientCredentials);
                MailSetting mailSetting = helperClient.GetMailSetting(processID);
                if (mailSetting != null)
                {
                    string ipSmtp = mailSetting.IpSmtp;
                    string emailLogin = mailSetting.Email;
                    string password = mailSetting.Password;
                    int port = Convert.ToInt32(mailSetting.Port);
                    string sslStatus = mailSetting.SSlStatus;
                    bool sslState = sslStatus == "1" ? true : false;

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(emailLogin, emailLogin));
                    message.To.Add(new MailboxAddress(recipient, recipient));
                    message.Subject = subject;
                    var bodyMail = new TextPart("html") { Text = body };

                    var multiPart = new Multipart("mixed");
                    multiPart.Add(bodyMail);

                    message.Body = multiPart;

                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        client.Timeout = 5000;
                        //client.Connect(ipSmtp, port, sslState);
                        client.Connect(ipSmtp, port);
                        // Note: if we don't want MailKit to use a particular SASL mechanism, we can disable it like this:
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                        // Note: only needed if the SMTP server requires authentication
                        if (!string.IsNullOrEmpty(password))
                        {
                            client.Authenticate(new NetworkCredential(emailLogin, password));
                        }


                        client.Send(message);
                        client.Disconnect(true);
                    }
                }
            }
            catch (Exception ex)
            {
                //HelperClient helperClient = new HelperClient();
                //CSystems.SetClientCredential(helperClient.ClientCredentials);
                //helperClient.KeepLog(CSystems.ProcessID, ex.ToString());
                //helperClient.Close();

                throw ex;
            }

            return ret;

        }
        public async Task<bool> SendAsynMail(string recipient, string subject, string body,int processID = 0)
        {
            bool ret = false;
            try
            {
                if (processID == 0)
                    processID = CSystems.ProcessID;
                HelperService helperClient = new HelperService();
                // CSystems.SetClientCredential(helperClient.ClientCredentials);
                MailSetting mailSetting = helperClient.GetMailSetting(processID);
                if (mailSetting != null)
                {
                    string ipSmtp = mailSetting.IpSmtp;
                    string emailLogin = mailSetting.Email;
                    string password = mailSetting.Password;
                    int port = Convert.ToInt32(mailSetting.Port);
                    string sslStatus = mailSetting.SSlStatus;
                    bool sslState = sslStatus == "1" ? true : false;

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(emailLogin, emailLogin));
                    message.To.Add(new MailboxAddress(recipient, recipient));
                    message.Subject = subject;
                    var bodyMail = new TextPart("html") { Text = body };

                    var multiPart = new Multipart("mixed");
                    multiPart.Add(bodyMail);

                    message.Body = multiPart;

                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        client.Timeout = 5000;
                        //client.Connect(ipSmtp, port, sslState);
                        client.Connect(ipSmtp, port);
                        // Note: if we don't want MailKit to use a particular SASL mechanism, we can disable it like this:
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                        // Note: only needed if the SMTP server requires authentication
                        if (!string.IsNullOrEmpty(password))
                        {
                            client.Authenticate(new NetworkCredential(emailLogin, password));
                        }
                        await client.SendAsync(message);
                        client.Disconnect(true);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ret;

        }


        private static string ReadHtmlTemplate(string filename)
        {
            string emailtmp = "";
            try
            {   // Open the text file using a stream reader.
                //  byte[] imageBytes = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath(imgpath));
                //string path = FileHelper.GetFileFullPath("EmailTemplate/" + filename);
                //string path = @"D:\2K18Sally\UltraBoostSolution\JFS.Megazy.MilkyWaySolution.Web\EmailTemplate\forgotpassword.html";
                 string path = GetFileFullPath(HttpContext.Current.Server.MapPath("/EmailTemplate/" + filename));
                using (StreamReader sr = new StreamReader(path))
                {
                    // Read the stream to a string, and write the string to the console.
                    emailtmp = sr.ReadToEnd();
                    // Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return emailtmp;
        }
        public static string GetFileFullPath(string path)
        {
            string relName = path.StartsWith("~") ? path : path.StartsWith("/") ? string.Concat("~", path) : path;

            string filePath = relName.StartsWith("~") ? HostingEnvironment.MapPath(relName) : relName;

            return filePath;
        }

    }
}