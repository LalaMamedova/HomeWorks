using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Win32;
using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using WhiteBoardProject.Service.Classes;
using WhiteBoardProject.Service.Interface;

namespace WhiteBoardProject.ViewModel
{
    public class SendEmailViewModel:ViewModelBase
    {
        private IMessenger _messenger;
        private bool isAttachment = false;
        private User? User;
        private INavigate _navigation;
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? ReciverEmail { get; set; } 
        public MailAddress UserMailAddress { get; set; }
        public MailAddress ReciverMailAddress { get; set; }
        public MailMessage MailMessage { get; set; } = new();
        public UserArt? SenderArt { get; set; }
        public SendEmailViewModel(IMessenger messenger, INavigate navigation)
        {
            _messenger = messenger;
            _navigation = navigation;
            _messenger.Register<DataMessager>(this, message =>
            {
                if (message.Data.GetType().Name == nameof(User))
                {
                    User = message.Data as User;
                    UserEmail = User.Email;
                }
                else if (message.Data.GetType().Name == nameof(UserArt))
                {
                    SenderArt = message.Data as UserArt;

                    if (isAttachment == false && SenderArt.PicturePath!=null)
                    {
                        isAttachment = Attach(SenderArt.PicturePath);
                    }
                }
            });
        }

     
        public RelayCommand SendMessage
        {
            get => new(() => 
            {
                try
                {
                    UserMailAddress = new(UserEmail);
                    ReciverMailAddress = new(ReciverEmail);
                    MailMessage.From = UserMailAddress;
                    MailMessage.To.Add(ReciverMailAddress);

                    SmtpClient smtpClient = new("smtp.gmail.com", 587);

                    try
                    {
                        smtpClient.Credentials = new NetworkCredential(UserEmail, UserPassword);
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(MailMessage);

                        MessageBox.Show($"Ваш Mail удачно доставлен {ReciverEmail}");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        
            });
        }

        public RelayCommand<ItemsControl> AttachFile
        {
            get => new((itemControl) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();

                Attach(openFileDialog.FileName);
                itemControl.Items.Add(openFileDialog.FileName);
            });
        }
        private bool Attach(string? senderFile)
        {
            if (!string.IsNullOrEmpty(senderFile))
            {
                string? tempImagePath = Path.Combine(Path.GetTempPath(), Path.GetFileName(senderFile));

                using WebClient ftpClient = new WebClient();
                ftpClient.Credentials = new NetworkCredential();
                ftpClient.DownloadFile(senderFile, tempImagePath);
                ftpClient.Dispose();

                MailMessage.Attachments.Add(new Attachment(tempImagePath));
                return true;
            }
            return false;
        }

        public RelayCommand ToMainMenu
        {
            get => new(() =>
            {
                _navigation.NavigateTo<HomeViewModel>(User);
            });
        }

    }
}
