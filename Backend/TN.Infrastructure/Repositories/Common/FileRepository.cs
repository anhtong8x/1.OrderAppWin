using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using TN.Infrastructure.Interfaces;

namespace TN.Infrastructure.Repositories
{

    public class FileRepository : IFileRepository
    {
        //public virtual async Task ResizeImageAsync(IFormFile file, string pathFile, ImageFormat imgType, int width, int height = 0)
        //{
        //    int newWidth;
        //    int newHeight;
        //    Image image = Image.FromStream(file.OpenReadStream());
        //    int BaseWidth = image.Width;
        //    int BaseHeight = image.Height;
        //    if (BaseWidth > width && width > 0)
        //    {
        //        var typeSave = imgType;
        //        string FileType = Path.GetExtension(pathFile).ToLower();

        //        double dblCoef = (double)width / (double)BaseWidth;
        //        if (height > 0)
        //        {
        //            newWidth = width;
        //            newHeight = height;
        //        }
        //        else
        //        {
        //            newWidth = Convert.ToInt32(dblCoef * BaseWidth);
        //            newHeight = Convert.ToInt32(dblCoef * BaseHeight);
        //        }

        //        Image ReducedImage;
        //        Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);
        //        ReducedImage = image.GetThumbnailImage(newWidth, newHeight, callb, IntPtr.Zero);
        //        ReducedImage.Save(pathFile, typeSave);
        //    }
        //    else
        //    {
        //        using (FileStream fs = File.Create(pathFile))
        //        {
        //            await file.CopyToAsync(fs);
        //            fs.Flush();
        //        }
        //    }
        //}
        public bool ThumbnailCallback()
        {
            return false;
        }
        public void SettingsUpdate(string map, object a)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(a, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(map, output);
        }
    }
}