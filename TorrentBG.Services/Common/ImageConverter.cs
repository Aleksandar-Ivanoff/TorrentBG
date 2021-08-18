namespace TorrentBG.Services.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ImageConverter
    {
       public static string GetImagePathToShow(string image)
        {
            if (image is null)
            {
                return "noImage.jpg";
            }
            var filePath = Path.GetFileName(image);

            return filePath;
        }
    }
}
