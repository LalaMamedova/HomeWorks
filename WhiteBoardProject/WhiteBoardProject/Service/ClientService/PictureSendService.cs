using Newtonsoft.Json;
using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WhiteBoardProject.Converters;
using WhiteBoardProject.Service.Classes;
using WhiteBoardProject.Service.Interface;
using WhiteBoardProject.View;

namespace WhiteBoardProject.Service.ClientService
{
    public class PictureSendService : IClientService
    {
        string ipAdress = "192.168.2.9";
        UserArt? userArt;
        FtpServer FtpServer;
        public PictureSendService()
        {
            FtpServer = new(ipAdress);
        }

        public void Save(object[]? entity)
        {
            userArt = (UserArt)entity[1];
            InkCanvas? inkCanvas = (InkCanvas)entity[0];

            if (userArt != null && inkCanvas != null)
            {
                BitmapSource bitmapSource = MyInkArtConvert.ConvertToBitmapSource(inkCanvas, userArt);
                string tempImagePath = ImgToImgPathConverter.SaveTempImage(bitmapSource, userArt.ArtName);

                if (FtpServer.AddArt(tempImagePath, userArt))
                {
                    SendToServer();
                }
            }

        }

        public void SendToServer()
        {
            ClientService clientService = new(ipAdress, 9000);
            using MemoryStream memoryStream = new();
            using GZipStream gzipStream = new(memoryStream, CompressionMode.Compress);
            gzipStream.Write(userArt.Content, 0, userArt.Content.Length);

            gzipStream.Flush();
            gzipStream.Close();
            byte[] compressedBytes = memoryStream.ToArray();

            userArt.Content = compressedBytes;
            clientService.Post(userArt.GetType().Name);
            clientService.Post(userArt);

            MessageBox.Show("Изображения удачно сохранено)");
        }

        public void Load(object[]? entity) { }
    }
}
