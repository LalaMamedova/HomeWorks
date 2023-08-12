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
using WhiteboardServer.Service.Classes;
using ProjectLib.Model.Interface;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace WhiteBoardProject.Service.ClientService
{
    public class UserService : IWhiteboardtService
    {
        private ClientService clientService;
        private string ipAdress = "192.168.2.9";

        public static User ActiveUser { get; set; }

        public UserService(User user)
        {
            ActiveUser = user;
            clientService = new(ipAdress, 9000);
        }
        public User? Load()
        {
            //clientService.TcpClient = new(ipAdress, 9000);
            using TcpClient tcpClient = new(ipAdress, 9000);
            using NetworkStream networkStream = tcpClient.GetStream();
            using MemoryStream memoryStream = new MemoryStream();

            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = networkStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                memoryStream.Write(buffer, 0, bytesRead);
            }

            memoryStream.Seek(0, SeekOrigin.Begin);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            User receivedUser = (User)binaryFormatter.Deserialize(memoryStream);
            return receivedUser;
        }

        public void SendToServer(string command)
        {
            clientService.PostNameOfClass(ActiveUser);
            clientService.PostCommand(command);
            clientService.Post(ActiveUser);
        }

        void IWhiteboardtService.Save(object[]? entity)
        {
            
        }
    }
}
