using System.Threading.Tasks;
using System.Web;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public interface IUploadFileAsync
    {
        Task<string> SaveFileAsync(HttpPostedFileBase file);
        Task<string> SaveFileAsync(HttpPostedFile file);
    }
}
