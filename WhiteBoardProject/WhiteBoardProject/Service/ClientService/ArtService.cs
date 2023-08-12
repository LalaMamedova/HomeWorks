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
using System.Windows.Shapes;
using WhiteBoardProject.Converters;
using WhiteBoardProject.Service.Classes;
using WhiteBoardProject.Service.Interface;
using WhiteBoardProject.View;
using WhiteBoardProject.ViewModel;

namespace WhiteBoardProject.Service.ClientService
{
    public class ArtService :IWhiteboardtService
    {
        string ipAdress = "192.168.2.9";
        private UserArt? userArt;
        private FtpServer FtpServer;
        private InkCanvas? inkCanvas;
        private ClientService clientService;
        private User ownerUser;

        public ArtService(UserArt? userArt = null)
        {
            FtpServer = new(ipAdress+":8900");
            clientService = new(ipAdress, 9000);
            if (userArt != null)
            {
                this.userArt = userArt;
            }
        }

     
        public void Save(object[]? entity)
        {
            inkCanvas = (InkCanvas)entity[0];
            userArt = (UserArt)entity[1];
            ownerUser = (User)entity[2];

            if (userArt != null && inkCanvas != null)
            {
                if (string.IsNullOrEmpty(System.IO.Path.GetExtension(userArt.ArtName)))
                    userArt.ArtName = System.IO.Path.ChangeExtension(userArt.ArtName, ".png");
                
                BitmapSource bitmapSource = MyInkArtConvert.ConvertToBitmapSource(inkCanvas, userArt);
                string tempImagePath = ImgToImgPathConverter.SaveTempImage(bitmapSource, userArt.ArtName);
                userArt = FtpServer.AddArt(tempImagePath, userArt);
                userArt.UserId = ownerUser.Id;
            
                DownLoadArt(userArt);


            }

        }

        public void DownLoadArt(UserArt userArt)
        {
            string destinationFilePath = System.IO.Path.Combine(@"C:\FolderForYourArt", System.IO.Path.GetFileName(userArt.PicturePath));
            if (!File.Exists(destinationFilePath))
            {
                File.Move(userArt.PicturePath, destinationFilePath);
            }
            else
            {
                File.Replace(userArt.PicturePath,destinationFilePath,null);
            }
            userArt.PicturePath = destinationFilePath;
        }

        public void DeleteFromFtp()
        {
            FtpServer.DeleteArt(userArt.PicturePath);
        }

        public void SendToServer(string command)
        {
            using MemoryStream memoryStream = new();
            using GZipStream gzipStream = new(memoryStream, CompressionLevel.SmallestSize);
            gzipStream.Write(userArt.Content, 0, userArt.Content.Length);

            gzipStream.Flush();
            gzipStream.Close();
            byte[] compressedBytes = memoryStream.ToArray();

            userArt.Content = compressedBytes;

            try
            {
                clientService.PostNameOfClass(userArt);
                clientService.PostCommand(command);
                clientService.Post(userArt);
                Message(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    
        }

        private void Message(string message)
        {
            if(message == "Update")
            {
                MessageBox.Show("Изображение удачно изменено");
            }
            else if(message == "Add")
            {
                MessageBox.Show("Изображение удачно сохранено");
            }
            else if(message == "Delete")
            {
                MessageBox.Show("Изображение удачно удалено");
            }
        }

       
    }
}
