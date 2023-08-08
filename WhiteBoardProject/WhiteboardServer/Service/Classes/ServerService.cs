using Newtonsoft.Json;
using ProjectLib.Model.Class;
using ProjectLib.Model.Context;
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
        public int Port { get; set; }   
        public TcpListener Listener { get; set; }
        public IPAddress IPAddress { get; set; }
        public WhiteboardContext WhiteboardContext { get; set; }
        public static List<User> OnlineUsers { get; set; } = new();  

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

            if (user == null)
            {
                user = new() {IPEndPoint = clientIPAddress};
                OnlineUsers.Add(user);
                Console.WriteLine("Клиент зашел");
            }
            
            return client;
        }

        public async Task ReciveMessage(TcpClient? client) 
        {
            try
            {
                using StreamReader reader = new StreamReader(client.GetStream());
                string? jsonData = await reader.ReadLineAsync();

                if (jsonData == nameof(User))
                {
                    Console.WriteLine("Lol");
                }

                else if (!string.IsNullOrEmpty(jsonData))
                {
                    object receivedObject = JsonConvert.DeserializeObject(jsonData)!;
                    Console.WriteLine("Received object from client: ");
                    Console.Write(receivedObject.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                client.Close();
            }

        }

        public void PostMessage<T>(TcpClient client,T message)
        {
            using NetworkStream stream = client.GetStream();
            string jsonData = JsonConvert.SerializeObject(message);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonData);
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
