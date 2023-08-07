using Newtonsoft.Json;
using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WhiteBoardProject.Converters;
using WhiteBoardProject.Service.Interface;
using WhiteBoardProject.View;

namespace WhiteBoardProject.Service.Classes
{
    public class PictureSaveService : ISaveService
    {
        string ipAdress = "192.168.2.9";
        UserArt? userArt;
        FtpServer FtpServer;
        public PictureSaveService()
        {
            FtpServer = new(ipAdress);
        }
        public void Save(object[]? entity)
        {
            InkCanvas? inkCanvas = (InkCanvas)entity[0];
            userArt = (UserArt)entity[1];

            if (userArt != null && inkCanvas != null)
            {
                BitmapSource bitmapSource = MyInkArtConvert.ConvertToBitmapSource(inkCanvas, userArt);
                string tempImagePath = ImgToImgPathConverter.SaveTempImage(bitmapSource, userArt.ArtName);

                if (FtpServer.AddArt(tempImagePath, userArt))
                {
                    MessageBox.Show("Изображения удачно сохранено)");
                    SendToServer();
                }
            }

        }

        public void SendToServer()
        {
            ClientService clientService = new(ipAdress,9000);
            clientService.Recive<UserArt>(userArt);
        }

       

        public void Load(object[]? entity) { }
    }
}
