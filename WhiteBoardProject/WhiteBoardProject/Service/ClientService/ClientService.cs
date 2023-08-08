using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace WhiteBoardProject.Service.ClientService
{
    public class ClientService
    {
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public TcpClient TcpClient;

        public ClientService(string ipAddress, int port)
        {
            Port = port;
            IPAddress = ipAddress;
            TcpClient = new TcpClient(IPAddress, Port);
        }

        public async Task Recive<T>(T obj)
        {
            using TcpClient TcpClient = new TcpClient(IPAddress, Port);
            using StreamReader reader = new StreamReader(TcpClient.GetStream());
            string jsonData = reader.ReadLine();
            obj = JsonConvert.DeserializeObject<T>(jsonData);

        }

        public void Post<T>(T? obj)
        {
            if (obj != null && TcpClient.Connected)
            {
                using TcpClient TcpClient = new TcpClient(IPAddress, Port);
                using StreamWriter writer = new StreamWriter(TcpClient.GetStream());
                string jsonData = JsonConvert.SerializeObject(obj);
                writer.WriteLine(jsonData);
                writer.Flush(); 

            }
        }

        public void PostNameOfClass(object obj)
        {
            using TcpClient TcpClient = new TcpClient(IPAddress, Port);
            using NetworkStream stream = TcpClient.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(obj.GetType().Name);
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

    }
}
