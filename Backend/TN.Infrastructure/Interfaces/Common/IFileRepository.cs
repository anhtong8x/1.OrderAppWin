using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace TN.Infrastructure.Interfaces
{
    public interface IFileRepository
    {
      //  Task ResizeImageAsync(IFormFile file, string pathFile, ImageFormat imgType, int width, int height = 0);
        void SettingsUpdate(string map, object a);
    }
}
