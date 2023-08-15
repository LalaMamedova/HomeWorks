using Newtonsoft.Json;
using ProjectLib.Class;
using ProjectLib.Model.Class;
using ProjectLib.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace WhiteBoardProject.Service.ClientService
{
    public class ClientService
    {
        public string IPAddress { get; set; }
        public int Port { get; set; } = IpPath.Port;
        public TcpClient TcpClient { get; set; }
        public ClientService(string ipAddress, int port)
        {
            Port = port;
            IPAddress = ipAddress;
        }

        public T? Recive<T>(T? obj) where T : IWhiteboardcs
        {
            using TcpClient TcpClient = new TcpClient(IPAddress, Port);
            using StreamReader reader = new StreamReader(TcpClient.GetStream());
            string? jsonData = reader.ReadLine();
            return obj = JsonConvert.DeserializeObject<T>(jsonData);
        }


        public void PostToServer(object? obj)
        {
            if (obj != null)
            {
                using TcpClient client = new(IPAddress, Port);
                using MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, obj);


                using NetworkStream networkStream = client.GetStream();
                byte[] userBytes = memoryStream.ToArray();

                int bytesSent = 0;
                while (bytesSent < userBytes.Length)
                {
                    int bytesToSend = Math.Min(userBytes.Length - bytesSent, 1024);
                    networkStream.Write(userBytes, bytesSent, bytesToSend);
                    bytesSent += bytesToSend;
                }

            }
        }

        public void Post(object? obj)
        {
            if (obj != null)
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
            using StreamWriter writer = new StreamWriter(TcpClient.GetStream());
            writer.WriteLine(obj.GetType().Name);
            writer.Flush();
        }
        public void PostCommand(string command)
        {
            using TcpClient TcpClient = new TcpClient(IPAddress, Port);
            using StreamWriter writer = new StreamWriter(TcpClient.GetStream());
            writer.WriteLine(command);
            writer.Flush();
        }

    }
}
