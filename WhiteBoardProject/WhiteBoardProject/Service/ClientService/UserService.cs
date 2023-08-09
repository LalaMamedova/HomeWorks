﻿using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WhiteBoardProject.Service.Interface;
using WhiteboardServer.Service.Classes;
using ProjectLib.Model.Interface;

namespace WhiteBoardProject.Service.ClientService
{
    public class UserService : IClientService
    {
        private ClientService clientService;
        private string ipAdress = "192.168.2.9";

        public static User ActiveUser { get; set; }
        public UserService(User user)
        {
            ActiveUser = user;
            clientService = new(ipAdress, 9000);
        }

        public void Save(object[]? entity)
        {
            User? user = (User)entity[0];
            //UserArt = (UserArt)entity[1];
        }
        public User? Load()
        {
            return clientService.Recive<User>(ActiveUser);
        }

        public void SendToServer(string command)
        {
            clientService.PostNameOfClass(ActiveUser);
            clientService.PostCommand(command);
            clientService.Post(ActiveUser);
        }
        
    }
}
