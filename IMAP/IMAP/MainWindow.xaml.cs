using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Windows;
using Microsoft.Win32;
using MailKit.Net.Imap;
using MailKit;
using System.Collections.ObjectModel;
using MimeKit;
using HtmlAgilityPack;
using System.Windows.Controls;

namespace IMAP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string UserEmail { get; set; } 
        public string Password { get; set; } 
        public string ReciverEmail { get; set; } 
        public MailAddress UserMailAddress { get; set; }
        public MailAddress ReciverMailAddress { get; set; }
        public MailMessage MailMessage { get; set; }
        public ImapClient Client { get; set; } = new ImapClient();
        public ObservableCollection<MimeMessage> mimeMessages { get; set; } = new();

        bool isAttachment = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            UserMailAddress = new(UserEmail);
        }

        private void AttachmentsButton_Click(object sender, RoutedEventArgs e)
        {
             NewMessage();
             isAttachment = true;

            OpenFileDialog openFileDialog = new();
            openFileDialog.ShowDialog();
            MailMessage.Attachments.Add(new Attachment(openFileDialog.FileName));
        }

        private void SendMailButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isAttachment)
            {
                try
                {
                    NewMessage();
                    isAttachment = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            SmtpClient smtpClient = new("smtp.gmail.com", 587);

            try
            {
                smtpClient.Credentials = new NetworkCredential(UserEmail, Password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(MailMessage);

                MessageBox.Show($"Ваш Mail удачно доставлен {ReciverEmail}");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

        }
        void NewMessage()
        {
            ReciverMailAddress = new(ReciverEmail);
            MailMessage = new(UserMailAddress, ReciverMailAddress);
            MailMessage.IsBodyHtml = true;
            MailMessage.Subject = MailSubject.Text;
            MailMessage.Body = MailBody.Text;
        }

        void MyMails()
        {
            Client.Connect("imap.gmail.com", 993, true);
            Client.Authenticate(UserEmail, Password);
            Client.Inbox.Open(FolderAccess.ReadOnly);

         
            for (int i = 0; i < 15; i++)
            {
                mimeMessages.Add(Client.Inbox.GetMessage(i));
            }

            Client.Disconnect(true);
            Client.Dispose();
        }

       

        private void ReciveMyMailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserMailAddress != null)
            {
                MyMails();
            }
            else
                MessageBox.Show("В начале войдите в почту");
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string html = (string)button.CommandParameter;

            HTMLBody hTMLBody = new(html);
            hTMLBody.Show();
        }
    }
}
