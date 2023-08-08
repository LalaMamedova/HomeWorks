using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WhiteBoardProject.Service.Interface;

namespace WhiteBoardProject.Service.ClientService
{
    public class UserSendService : IClientService
    {
        string ipAdress = "192.168.2.9";
        UserArt UserArt { get; set; }
        User User { get; set; }

        public UserSendService(User user)
        {
            User = user;
        }

        public void Save(object[]? entity)
        {
            User? user = (User)entity[0];
            UserArt = (UserArt)entity[1];
        }
        public void Load(object[]? entity)
        {
            throw new NotImplementedException();
        }

        public void SendToServer()
        {
            ClientService clientService = new(ipAdress, 9000);
            clientService.PostNameOfClass(User);
            clientService.Post(User);
            clientService.TcpClient.Close();
        }

    }
}
