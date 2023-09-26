using System;
using System.Web.Mvc;
using JFS.Megazy.MilkyWaySolution.Engine.Services;
using System.Text;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Web.Routing;
namespace JFS.Megazy.MilkyWaySolution.Web.Front.Controllers
{
    [WebViewAuthorizeFilter]
    public class DownloadController : BaseController
    {
        // GET: Download
        [Route("download/projectresult")]
        public ActionResult ProjectResult(int caseID, int applicantID, int depID)
        {

            string handlefilename = "";
            //string signatureName = "", signaturePositionName = "";
            string folderPath = Server.MapPath("~/FormTemplate/");
            string cssstylePath = Server.MapPath("~/FormTemplate/wordStyleSheet.txt");
            string cssstyle = "";
            using (var sr = new StreamReader(cssstylePath))
            {
                cssstyle = sr.ReadToEnd();
            }
            CaseRegisterDataService service = new CaseRegisterDataService();
            CurrentUser currentUser = SiteSession.GetCurrentUser();
            string file = $"FormProjectResult.docx";
            handlefilename = "แบบรายงานผลการสนับสนุนโครงการให้ความรู้ทางกฎหมายแก่ประชาชน" + DateTime.Now.ToString("s") + ".docx";
            var CaseRegisterData = service.GetCaseRegisterDataResponse(caseID, applicantID, depID, currentUser.MemberID);
            var partialStr = PartailViewToString("_ProjectResultForm", new ViewDataDictionary { { "CaseRegisterData", CaseRegisterData } });
            folderPath += file;
            byte[] byteArray = new byte[0];//16 * 1024
            if (System.IO.File.Exists(folderPath))
            {
                //string formpath = HttpContext.Current.Server.MapPath("~/FormTemplate/ReportFocus.docx");
                using (FileStream fileStream = new FileStream(folderPath, FileMode.Open, FileAccess.Read))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        CopyStream(fileStream, memoryStream);
                        //fileStream.CopyTo(memoryStream);
                        using (WordprocessingDocument doc = WordprocessingDocument.Open(memoryStream, true))
                        {
                            MainDocumentPart mainPart = doc.MainDocumentPart;
                            int altChunkIdCounter = 1;
                            int blockLevelCounter = 1;
                            string mainhtml = "<html><head><style type='text/css'>";
                            mainhtml += cssstyle;
                            mainhtml += "</style></head><body style='font-family:TH SarabunPSK;font-size:1.15em;'>";
                            mainhtml += partialStr;
                            mainhtml += "</body></html>";

                            string altChunkId = String.Format("AltChunkId{0}", altChunkIdCounter++);

                            //Import data as html content using Altchunk
                            AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.Html, altChunkId);

                            using (Stream chunkStream = chunk.GetStream(FileMode.Create, FileAccess.Write))
                            {
                                using (StreamWriter stringWriter = new StreamWriter(chunkStream, Encoding.UTF8)) //Encoding.UTF8 is important to remove special characters
                                {
                                    stringWriter.Write(mainhtml);
                                }
                            }

                            AltChunk altChunk = new AltChunk();
                            altChunk.Id = altChunkId;

                            mainPart.Document.Body.InsertAt(altChunk, blockLevelCounter++);
                            mainPart.Document.Save();
                        }






                        memoryStream.Seek(0, SeekOrigin.Begin);//ใช้ Seek เพื่อให้ไฟล์เข้ารหัสป้องกันตัวหนังสืออ่านไม่ได้
                        byteArray = memoryStream.ToArray();
                    }
                }
                return File(byteArray, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", handlefilename);
            }
            else
            {
                return null;
            }

        }
        private void CopyStream(Stream source, Stream destination)
        {
            byte[] buffer = new byte[32768];
            int bytesRead;
            do
            {
                bytesRead = source.Read(buffer, 0, buffer.Length);
                destination.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);
        }
        public string PartailViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
        public ActionResult Document(string url)
        {
            var path = Server.MapPath(url);
            if (path == null || !System.IO.File.Exists(path))
            {
                ErrorUtility.RedirectPage("ไม่พบไฟล์ที่ดาวน์โหลด", 404);
                return null;

            }
            else
            {
               // byte[] byteArray = new byte[0];//16 * 1024
                var filename = Path.GetFileName(path);
                var mimetype = filename.Split(new char[] { '.' })[1];
                var FileType = ContentTypeExtensions.ToValue((ContentType)Enum.Parse(typeof(ContentType), mimetype.ToUpper()));
                if (!string.IsNullOrWhiteSpace(FileType))
                {
                    byte[] byteArray  = System.IO.File.ReadAllBytes(path);
                    return File(byteArray, FileType, DateTime.Now.ToString("yyyyMMddHHmmss")+ "_" + filename);
                }
            }
            return null;
        }




    }
}