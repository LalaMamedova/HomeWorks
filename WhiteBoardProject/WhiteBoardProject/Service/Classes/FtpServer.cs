using Microsoft.Win32;
using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Path = System.IO.Path;

namespace WhiteBoardProject.Service.Classes
{
    public class FtpServer
    {
        public string IP { get; set; }
        public string? DownloadPath { get; set; }
        public string? FileName { get; set; }
        public FtpServer(string Ip) =>IP = Ip;
        


        public UserArt? AddArt(UserArt userArt)
        {
            try
            {
                string ftpUrl = $"ftp://{IP}/{userArt.ArtName}";

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(); // Замените на свои учетные данные

                using FileStream fileStream = new FileStream(userArt.PicturePath, FileMode.Open);
                using Stream requestStream = request.GetRequestStream();

                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }

                CreateAFolder(); 

                return userArt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public void CreateAFolder()
        {
            string folderPath = @"C:\FolderForYourArt";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public void DeleteArt(string fileName)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://{IP}/{fileName}");
                request.Method = WebRequestMethods.Ftp.DeleteFile;

                using FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                using Stream stream = response.GetResponseStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void UpdateArt(UserArt userArt)
        {
            try
            {
                string ftpUrl = $"ftp://{IP}/{userArt.ArtName}";

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(); // Замените на свои учетные данные

                using FileStream fileStream = new FileStream(userArt.PicturePath, FileMode.Open);
                using Stream requestStream = request.GetRequestStream();

                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



    }
}
