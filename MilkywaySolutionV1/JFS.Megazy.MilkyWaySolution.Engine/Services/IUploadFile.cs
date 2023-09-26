using System.Web;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public interface IUploadFile
    {
        string SaveFile(HttpPostedFileBase file);
        string SaveFile(HttpPostedFile file);
    }
}
