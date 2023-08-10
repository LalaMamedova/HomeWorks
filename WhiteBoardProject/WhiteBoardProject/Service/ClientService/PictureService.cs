using Newtonsoft.Json;
using ProjectLib.Model.Class;
using ProjectLib.Model.Interface;
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
using WhiteBoardProject.ViewModel;

namespace WhiteBoardProject.Service.ClientService
{
    public class PictureService :IClientService
    {
        string ipAdress = "192.168.2.9";
        private UserArt? userArt;
        private FtpServer FtpServer;
        private InkCanvas? inkCanvas;
        private ClientService clientService;
        private User ownerUser;

        public PictureService(object[]? entity)
        {
            FtpServer = new(ipAdress+":8900");
            clientService = new(ipAdress, 9000);
            inkCanvas = (InkCanvas)entity[0];
            userArt = (UserArt)entity[1];
            ownerUser = (User)entity[2];
        }

        public void Save()
        {
            if (userArt != null && inkCanvas != null)
            {
                BitmapSource bitmapSource = MyInkArtConvert.ConvertToBitmapSource(inkCanvas, userArt);
                string tempImagePath = ImgToImgPathConverter.SaveTempImage(bitmapSource, userArt.ArtName);
                userArt = FtpServer.AddArt(tempImagePath, userArt);
                userArt.UserId = ownerUser.Id;
            }

        }

        public void SendToServer(string command)
        {
            Save();
            using MemoryStream memoryStream = new();
            using GZipStream gzipStream = new(memoryStream, CompressionMode.Compress);
            gzipStream.Write(userArt.Content, 0, userArt.Content.Length);

            gzipStream.Flush();
            gzipStream.Close();
            byte[] compressedBytes = memoryStream.ToArray();

            userArt.Content = compressedBytes;
            clientService.PostNameOfClass(userArt);
            clientService.PostCommand(command);
            clientService.Post(userArt);

            MessageBox.Show("Изображения удачно сохранено)");
        }

        //public IWhiteboardcs? Load() 
        //{
        //    return clientService.Recive<UserArt>(new UserArt[] {userArt});
        //    return null;
        //}

        User? IClientService.Load()
        {
            throw new NotImplementedException();
        }
    }
}
