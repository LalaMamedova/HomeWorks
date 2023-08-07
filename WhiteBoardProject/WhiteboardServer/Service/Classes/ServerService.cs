using Newtonsoft.Json;
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
        public static List<User> OnlineUsers { get; set; } = new List<User>();  

        public ServerService(IPAddress address, int port)
        {
            Port = port;
            IPAddress = address;
            Listener = new TcpListener(address, port);
            Listener.Start();
        }
        public TcpClient? Connection()
        {
            TcpClient client = Listener.AcceptTcpClient();
            IPEndPoint? clientIPAddress = ((IPEndPoint)client.Client.RemoteEndPoint);

            User? user = OnlineUsers.FirstOrDefault(u => u.IPEndPoint.Equals(clientIPAddress));
            if (user != null)
            {
                client.Connect(IPAddress, Port);
                user.IPEndPoint = clientIPAddress;
                OnlineUsers.Add(user);
                PostMessage(client, "Клиент зашел в сервер");
            }

            return client;
        }

        public T? ReciveMessage<T>(TcpClient? client) 
        {
            //if (client.Connected)
            //{
            //    StreamReader reader = new StreamReader(client.GetStream());
            //    string message = reader.ReadLine();
            //    Console.WriteLine(message);
            //    return message;
            //}
            if (client.Connected)
            {
                StreamReader reader = new StreamReader(client.GetStream());
                string jsonData = JsonConvert.SerializeObject(message);
                byte[] buffer = Encoding.UTF8.GetBytes(jsonData);
                
                Console.WriteLine(jsonData);
                return message;
            }
            throw new ArgumentNullException($"{nameof(client)} is null");
        }

        public void PostMessage<T>(TcpClient client,T message)
        {
            NetworkStream stream = client.GetStream();
            string jsonData = JsonConvert.SerializeObject(message);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonData);
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
