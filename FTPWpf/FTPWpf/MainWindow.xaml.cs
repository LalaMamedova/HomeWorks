using System;
using System.IO;
using System.Net;
using System.Windows;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using Ookii.Dialogs.Wpf;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Shapes;
using System.Drawing;
using Cake.Core.IO;

namespace FTPWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FtpWebRequest request;
        bool isConnect = false;

        public ObservableCollection<FtpFileInfo> FilesInfo { get; set; } = new();
        public string IP { get; set; } = "192.168.2.8";
        public string DownloadPath { get; set; }
        public string FileName { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }


        public void ParseListing(string listing)
        {
            //Content = "{Binding Path=DataContext.Res,ElementName = Main}"
 
            string[] lines = listing.Split(new[] { "\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries);
          
            foreach (string line in lines)
            {
                string[] oneLine = line.Split(new[] { "\t"," " }, StringSplitOptions.RemoveEmptyEntries);

                string name = oneLine[3];
                long size = long.Parse(oneLine[2]);
                if (oneLine.Length > 4) name += oneLine[4];

                FilesInfo.Add(new FtpFileInfo { Name = name, Size = size / 1024 });
            }
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

     

 

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(IP) && isConnect==false)
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

       

        private void DownLoadButton_Click(object sender, RoutedEventArgs e)
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

        private void AddButton(object sender, RoutedEventArgs e)
        {
            if (isConnect == true)
            {
                var fileDialog = new OpenFileDialog();
                fileDialog.ShowDialog();

                request = (FtpWebRequest)WebRequest.Create($"ftp://{IP}/{fileDialog.SafeFileName}");
                request.Method = WebRequestMethods.Ftp.AppendFile;

                using FileStream fileStream = new FileStream(fileDialog.FileName, FileMode.Open);

                byte[] fileContents = new byte[fileStream.Length];
                fileStream.Read(fileContents, 0, fileContents.Length);

                using Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
            }
            else
                MessageBox.Show("Подключитесь в начале");

        }

        private void ChoiceButton(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog folder = new();
            folder.ShowDialog();
            DownloadPath = folder.SelectedPath;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            request = (FtpWebRequest)WebRequest.Create($"ftp://{IP}");

            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            string allResponse = Response();

            try
            {
                if (FilesInfo.Count > 0)
                {
                    FilesInfo.Clear();
                    ParseListing(allResponse);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            request = (FtpWebRequest)WebRequest.Create($"ftp://{IP}/{FileName}");
            request.Method = WebRequestMethods.Ftp.DeleteFile;

            using FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using Stream stream = response.GetResponseStream();

            
        }
    }
}
