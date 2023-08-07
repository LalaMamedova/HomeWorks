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

namespace WhiteBoardProject.Service.Classes
{
    public class ClientService
    {
        public TcpClient TcpClient { get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }


        public ClientService(string ipAddress, int port)
        {
            Port = port;
            IPAddress = ipAddress;
            TcpClient = new TcpClient(ipAddress, port);
        }

        public async Task Recive<T>(T obj)
        {
            StreamReader reader = new StreamReader(TcpClient.GetStream());

            string jsonData = reader.ReadLine();
            obj = JsonConvert.DeserializeObject<T>(jsonData);


            //NetworkStream networkStream = TcpClient.GetStream();
            //byte[] bytes = new byte[256];
            //networkStream.Read(bytes, 0, bytes.Length);
            //string message = Encoding.ASCII.GetString(bytes);
            //MessageBox.Show(message);

        }

        public void Post<T>(T? obj)
        {
            if (obj != null)
            {
                string jsonData = JsonConvert.SerializeObject(obj);
                StreamWriter writer = new StreamWriter(TcpClient.GetStream());
                writer.WriteLine(jsonData);
            }
        }

    }
}
