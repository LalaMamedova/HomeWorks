﻿using Microsoft.Win32;
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

namespace WhiteBoardProject.Service.Classes
{
    public class FtpServer
    {
        FtpWebRequest? request;
        bool isConnect = false;
        public string IP { get; set; } 
        public string? DownloadPath { get; set; }
        public string? FileName { get; set; }
        public ObservableCollection<UserArt> UsersArt { get; set; } = new();

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
            if (!string.IsNullOrEmpty(IP) && isConnect == false)
            {
                try
                {
                    request = (FtpWebRequest)WebRequest.Create($"ftp://{IP}");
                    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                    string allResponse = Response();
                    isConnect = true;
                    ParseListing(allResponse);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void ParseListing(string listing)
        {
            string[] lines = listing.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string[] oneLine = line.Split(new[] { "\t", " " }, StringSplitOptions.RemoveEmptyEntries);

                int id = int.Parse(oneLine[0]);
                long size = long.Parse(oneLine[2]);
                string name = oneLine[3];
                string picturepath = oneLine[5];

                if (oneLine.Length > 4) name += oneLine[4];

                UsersArt.Add(new UserArt { Id = id, ArtName = name, PicturePath = picturepath });
            }
        }

        public void DownLoadArt()
        {
            if (isConnect == true)
            {
                request = (FtpWebRequest)WebRequest.Create($"ftp://{IP}/{FileName}");
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                using FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                using Stream stream = response.GetResponseStream();

                using FileStream fileStream = new($"{DownloadPath}/{FileName}", FileMode.Create);
                stream.CopyTo(fileStream);
            }
            else
                MessageBox.Show("Подключитесь в начале");
        }
        public bool AddArt(string imgPath,UserArt userArt)
        {
            try
            {
                string path = System.IO.Path.GetFileName(imgPath);
                userArt.PicturePath = path;

                request = (FtpWebRequest)WebRequest.Create($"ftp://{IP}/{path}");
                request.Method = WebRequestMethods.Ftp.UploadFile;

                using FileStream fileStream = new FileStream(imgPath, FileMode.OpenOrCreate);

                byte[] fileContents = new byte[fileStream.Length];
                fileStream.Read(fileContents, 0, fileContents.Length);

                using Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;


        }
        public void DeleteArt()
        {
            request = (FtpWebRequest)WebRequest.Create($"ftp://{IP}/{FileName}");
            request.Method = WebRequestMethods.Ftp.DeleteFile;

            using FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using Stream stream = response.GetResponseStream();


        }

    }
}
