﻿using System;
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

namespace IMAP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string UserEmail { get; set; }
        public string Password { get; set; } = "uuigrirzmshxjtlu";
        public string ReciverEmail { get; set; } 
        public MailAddress UserMailAddress { get; set; }
        public MailAddress ReciverMailAddress { get; set; }
        public MailMessage MailMessage { get; set; }
        public ImapClient Client { get; set; } = new ImapClient();
        public ObservableCollection<Mail> mimeMessages { get; set; } = new();

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

            int count = Client.Inbox.Count;

     
            for (int i = 1; i < 10; i++)
            {
                Mail mail = new Mail()
                {
                    Subject = Client.Inbox.GetMessage(i).Subject,
                    Body = Client.Inbox.GetMessage(i).TextBody,
                    HtmlBody = Client.Inbox.GetMessage(i).HtmlBody,
                    From = Client.Inbox.GetMessage(i).From.ToString(),
                };

                //mail.HtmlBody = ConvertHtmlToText(mail.HtmlBody);
                mimeMessages.Add(mail);
            }

            Client.Disconnect(true);
            Client.Dispose();
        }

        string ConvertHtmlToText(string html)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            return htmlDocument.DocumentNode.InnerText;
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
    }
}