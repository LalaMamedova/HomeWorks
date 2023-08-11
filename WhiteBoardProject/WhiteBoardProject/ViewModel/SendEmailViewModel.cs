using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;
using WhiteBoardProject.Service.Classes;
using WhiteBoardProject.Service.Interface;

namespace WhiteBoardProject.ViewModel
{
    public class SendEmailViewModel:ViewModelBase
    {
        private IMessenger _messenger;
        private INavigate _navigation;
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; } 
        public string? ReciverEmail { get; set; } 
        public MailAddress UserMailAddress { get; set; }
        public MailAddress ReciverMailAddress { get; set; }
        public MailMessage MailMessage { get; set; } = new();
        public UserArt SenderArt { get; set; }

        public SendEmailViewModel(IMessenger messenger, INavigate navigation)
        {
            _messenger = messenger;
            _navigation = navigation;
            _messenger.Register<DataMessager>(this, message =>
            {
                if (message.Data.GetType().Name == nameof(User))
                {
                    User? User = message.Data as User;
                    UserEmail = User.Email;
                }
                else if (message.Data.GetType().Name == nameof(UserArt))
                {
                    SenderArt = message.Data as UserArt;
                    string path = Path.GetFileName(SenderArt.PicturePath);
                    MailMessage.Attachments.Add(new Attachment(path));
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
             
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
        
            });
        }

    }
}
