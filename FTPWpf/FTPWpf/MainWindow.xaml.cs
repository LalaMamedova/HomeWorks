using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FTPWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FtpWebRequest request;
        public ObservableCollection<string> FilesName { get; set; } = new();
        public string IP { get; set; } = "192.168.2.8";
        public string Res { get; set; }
        public string DownloadPath { get; set; }
        public string FileName { get; set; }

        public MainWindow()
        {
            InitializeComponent();
           
        }



        private string? Response()
        {
            request.Method = WebRequestMethods.Ftp.ListDirectory;

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

     

 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(IP))
            {
                try
                {
                    request = (FtpWebRequest)WebRequest.Create($"ftp://{IP}");
                    string allResponse = Response();

                    if (FilesName.Count > 0)
                    {
                        FilesName.Clear();
                        Res = "";
                    }
                    FilesName.Add(allResponse);
                    Res = allResponse;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

       

        private void DownLoadButton_Click(object sender, RoutedEventArgs e)
        {
            request = (FtpWebRequest)WebRequest.Create($"ftp://{IP}/{FileName}");
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            using FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using Stream stream = response.GetResponseStream();
            using FileStream fileStream = new($"{DownloadPath}/{FileName}", FileMode.Create);
            stream.CopyTo(fileStream);
        }

        private void AddButton(object sender, RoutedEventArgs e)
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
    }
}
