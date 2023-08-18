using Newtonsoft.Json;
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
        public int Port { get; set; } 
        public TcpClient TcpClient { get; set; }
        public ClientService(string ipAddress, int port)
        {
            Port = port;
            IPAddress = ipAddress;
        }

        public async Task<T?> Recive<T>()
        {
            using TcpClient tcpClient = new(IPAddress, Port);
            using NetworkStream networkStream = tcpClient.GetStream();
            using MemoryStream memoryStream = new MemoryStream();

            byte[] buffer = new byte[1024];
            int bytesRead;

            do
            {
                bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);

                if (bytesRead > 0)
                    await memoryStream.WriteAsync(buffer, 0, bytesRead);
                else
                    break;

            } while (bytesRead>0);

            memoryStream.Seek(0, SeekOrigin.Begin);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            T? receivedUser = (T)binaryFormatter.Deserialize(memoryStream);
            return receivedUser;
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

      
     

    }
}
