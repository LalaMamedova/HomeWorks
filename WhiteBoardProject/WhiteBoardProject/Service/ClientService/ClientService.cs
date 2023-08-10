using Newtonsoft.Json;
using ProjectLib.Model.Class;
using ProjectLib.Model.Interface;
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

        public ClientService(string ipAddress, int port)
        {
            Port = port;
            IPAddress = ipAddress;
        }

        public T? Recive<T>(T? obj) where T : IWhiteboardcs
        {
            using TcpClient TcpClient = new TcpClient(IPAddress, Port);
            using StreamReader reader = new StreamReader(TcpClient.GetStream());
            string jsonData = reader.ReadLine();

            return obj = JsonConvert.DeserializeObject<T>(jsonData);

        }

        public void Post<T>(T? obj)
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
