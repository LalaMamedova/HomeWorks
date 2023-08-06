using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WhiteboardServer.Service.Classes
{
    public class ServerService
    {
        public TcpListener Listener { get; set; }
        public IPAddress IPAddress { get; set; }
        public int Port { get; set; }   
        public static List<User> OnlineUsers { get; set; }

        public ServerService(IPAddress address, int port)
        {
            Port = port;
            IPAddress = address;
            Listener = new TcpListener(address, port);
        }
        public void Connection()
        {
            TcpClient client = new TcpClient();
            IPEndPoint? clientIPAddress = ((IPEndPoint)client.Client.RemoteEndPoint);
            User? user = OnlineUsers.FirstOrDefault(u => u.IPEndPoint.Equals(clientIPAddress));

            if (user == null)
            {
                client.Connect(IPAddress, Port);
                user.IPEndPoint = clientIPAddress;
                OnlineUsers.Add(user);
                PostMessage(client, "Клиент зашел в сервер");
            }
        }

        public string ReciveMessage(TcpClient client) 
        {
            StreamReader reader = new StreamReader(client.GetStream());
            string message = reader.ReadLine();
            return message;
        }

        public void PostMessage(TcpClient client,string message)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);

        }
    }
}
