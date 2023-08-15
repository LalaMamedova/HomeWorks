using ProjectLib.Model.Class;
using System.IO;
using WhiteBoardProject.Service.Interface;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using WhiteBoardProject.Class;

namespace WhiteBoardProject.Service.ClientService
{
    public class UserService : IWhiteboardtService
    {
        private ClientService clientService;
        private string ipAdress = IpPath.Ip;
        private int port = IpPath.Port; 
        public static User ActiveUser { get; set; }

        public UserService() { }

        public UserService(User user)
        {
            ActiveUser = user;
            clientService = new(ipAdress, port);
        }



        public void  SendToServer(string command, object iWhiteboardobj)
        {
            clientService = new(ipAdress, port);
            clientService.PostToServer(iWhiteboardobj.GetType().Name);
            clientService.PostToServer(command);
            clientService.PostToServer(iWhiteboardobj);
        }

        public object? Recive()
        {
            using TcpClient tcpClient = new(ipAdress, port);
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

        void IWhiteboardtService.Save(object[]? entity)
        {

        }
    }
}
