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
        FtpWebRequest? request;
        public string IP { get; set; }
        public string? DownloadPath { get; set; }
        public string? FileName { get; set; }

        public FtpServer(string Ip)
        {
            IP = Ip;
        }
        private string? Response()
        {
            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        public void Connection()
        {
            if (!string.IsNullOrEmpty(IP))
            {
                try
                {
                    request = (FtpWebRequest)WebRequest.Create($"ftp://{IP}");
                    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                    string allResponse = Response();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public UserArt? AddArt(string imgPath, UserArt userArt)
        {
            try
            {
                string path = Path.GetFileName(imgPath);
                
                userArt.ArtName = path;
               
                request = (FtpWebRequest)WebRequest.Create($"ftp://{IP}/{path}");
                request.Method = WebRequestMethods.Ftp.UploadFile;

                using FileStream fileStream = new FileStream(imgPath, FileMode.Create);

                byte[] fileContents = new byte[fileStream.Length];
                fileStream.Read(fileContents, 0, fileContents.Length);

                using Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);

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
                request = (FtpWebRequest)WebRequest.Create($"ftp://{IP}/{fileName}");
                request.Method = WebRequestMethods.Ftp.DeleteFile;

                using FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                using Stream stream = response.GetResponseStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
