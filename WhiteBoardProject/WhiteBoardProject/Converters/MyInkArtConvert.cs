using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Windows.Threading;
using System.Windows;

namespace WhiteBoardProject.Converters
{
    public class MyInkArtConvert
    {
        public static BitmapSource ConvertToBitmapSource(InkCanvas Myink,UserArt userArt)
        {
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
                (int)Myink.ActualWidth,
                (int)Myink.ActualHeight,
                96d,
                96d,
                PixelFormats.Default);
            //Application.Current.Dispatcher.Invoke(() =>
            //{
            //    renderBitmap.Render(Myink);
            //});

            renderBitmap.Render(Myink);

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            var stream = BitmapSourceToBytes(renderBitmap);
            bitmapImage.StreamSource = new MemoryStream(stream);
            userArt.Content = stream;
            bitmapImage.EndInit();
            bitmapImage.Freeze();
            return bitmapImage;
        }

        private static byte[] BitmapSourceToBytes(BitmapSource bitmapSource)
        {
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

            using MemoryStream stream = new MemoryStream();
            encoder.Save(stream);
            return stream.ToArray();


        }
    }
}
