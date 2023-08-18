using Humanizer;
using ProjectLib.Model.Class;
using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WhiteBoardProject.Class;
using WhiteBoardProject.Converters;
using WhiteBoardProject.Service.Classes;
using WhiteBoardProject.Service.Interface;
using Path = System.IO.Path;

namespace WhiteBoardProject.Service.ClientService
{
    public class ArtService : IWhiteboardtClientService
    {
        private string ipAdress = IpPath.Ip;
        private int port = IpPath.Port;
        private UserArt? userArt;
        private User ownerUser;
        public FtpServer FtpServer;
        private ClientService clientService;
        private string tempImagePath;

        public ArtService(UserArt? userArt = null)
        {
            FtpServer = new(ipAdress +":8900");
            clientService = new(ipAdress, port);
            if (userArt != null)
            {
                this.userArt = userArt;
            }
        }

        public ArtService(object[]? entity)
        {
            FtpServer = new(ipAdress + ":8900");
            clientService = new(ipAdress, port);

            InkCanvas inkCanvas = (InkCanvas)entity[0];
            userArt = (UserArt)entity[1];
            ownerUser = (User)entity[2];

            if (userArt != null && inkCanvas != null)
            {
                if (string.IsNullOrEmpty(Path.GetExtension(userArt.ArtName)))
                {
                    userArt.ArtName = Path.ChangeExtension(userArt.ArtName, ".png");
                }

                BitmapSource bitmapSource = MyInkArtConvert.ConvertToBitmapSource(inkCanvas, userArt);
                tempImagePath = ImgToImgPathConverter.SaveTempImage(bitmapSource, userArt.ArtName);
                userArt.UserId = ownerUser.Id;
            }
        }

        public async Task<T> ReciveAsync<T>()
        {
            return await clientService.Recive<T>();
        }
        
        public void SendToServer(string command, object iWhiteBoardObj)
        {
            //if (command == "Update" || command == "Add")
            //{
            //    using MemoryStream memoryStream = new();
            //    using GZipStream gzipStream = new(memoryStream, CompressionLevel.SmallestSize);
            //    gzipStream.Write(userArt.Content, 0, userArt.Content.Length);

            //    gzipStream.Flush();
            //    gzipStream.Close();
            //    byte[] compressedBytes = memoryStream.ToArray();

            //    userArt.Content = compressedBytes;
            //}

            clientService.PostToServer(iWhiteBoardObj.GetType().Name);
            clientService.PostToServer(command);
            clientService.PostToServer(iWhiteBoardObj);
            Message(command);

        }

        public UserArt? SaveInAllPlace(UserArt? isThisNameExist,bool isRedact, bool isSaved)
        {
            if (isThisNameExist == null && !isSaved)
            {
                if(isRedact)
                {
                    UserArt newUserArt = userArt.Clone() as UserArt;
                    userArt = newUserArt;
                }
                DownLoadArt(userArt, tempImagePath);
                SendToServer("Add", userArt);
                FtpServer.AddArt(userArt);
            }
            else
            {
                if (!isSaved)
                {
                    MessageBoxResult mboxRes = MessageBox.Show("Картинка с таким названием уже существует.\nХотите изменить?", "предупреждение", MessageBoxButton.YesNo);
                    if (mboxRes == MessageBoxResult.Yes)
                        DownloadAndUpdate();
                }
                else
                    DownloadAndUpdate();
            }
            return userArt;
        }


        
        private void  DownLoadArt(UserArt userArt, string tempFile)
        {
            string destinationFilePath = @"C:\FolderForYourArt\" + userArt.ArtName;
            userArt.PicturePath = destinationFilePath;
            if (!File.Exists(destinationFilePath))
            {
                File.Copy(tempFile, destinationFilePath);
            }
            else
            {
                using FileStream fileStream = new(userArt.PicturePath, FileMode.Open, FileAccess.Write);
                fileStream.Write(userArt.Content, 0, userArt.Content.Length);
                
            }

        }

        public void DeleteFromFtp()
        {
            FtpServer.DeleteArt(userArt.ArtName);
        }

      
        private void DownloadAndUpdate()
        {
            userArt.DateTime = DateTime.Now;
            DownLoadArt(userArt, tempImagePath);
            SendToServer("Update", userArt);
            FtpServer.UpdateArt(userArt);
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



        public BitmapImage FromByteToImage(UserArt userArt)
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memoryStream = new MemoryStream(userArt.Content))
            {
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
            }

            return bitmapImage;

        }

       
    }
}
