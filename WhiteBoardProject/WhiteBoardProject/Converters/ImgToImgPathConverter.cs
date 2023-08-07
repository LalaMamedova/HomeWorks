using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WhiteBoardProject.Converters
{
    public class ImgToImgPathConverter
    {
        public static string SaveTempImage(BitmapSource bitmapSource,string picture_name)
        {
           
            string tempDirectory = Path.Combine(Path.GetTempPath(), "TempImages");

            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }

            string tempImagePath = Path.Combine(tempDirectory, picture_name);

            using FileStream fileStream = new FileStream(tempImagePath, FileMode.OpenOrCreate);

            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            encoder.Save(fileStream);

            return tempImagePath;
        }
    }
}
