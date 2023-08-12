using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectLib.Model.Class;
using ProjectLib.Model.Context;
using ProjectLib.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using WhiteboardServer.Service.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WhiteboardServer.Service.Classes
{
    public class ServerService
    {
        private string WhatClassIRecived;
        private string WhatCommandIRecived = "Add";

        private IModelService saveService;
        public TcpListener Listener { get; set; }
        public IPAddress IPAddress { get; set; }
        public WhiteboardContext WhiteboardContext { get; set; } = new();
        public int Port { get; set; }
        UserArt userArt;
        User user;
        public ServerService(IPAddress address, int port)
        {
            IPAddress = address;
            Port = port;
            Listener = new TcpListener(address, port);
            Listener.Start();

        }
        public object? ReciveMessage(TcpClient? client) 
        {
            try
            {
                using StreamReader reader = new StreamReader(client.GetStream());
                string? jsonData =  reader.ReadLine();

                if (jsonData == nameof(User) || jsonData == nameof(UserArt))
                    WhatClassIRecived = jsonData;

                else if (jsonData == "Add" || jsonData == "Update" || jsonData == "Delete" || jsonData == "Exist")
                    WhatCommandIRecived = jsonData;
                

                else if (!string.IsNullOrEmpty(jsonData))
                {
                    Console.WriteLine($"Received object from client: {jsonData}");

                    if (WhatClassIRecived == nameof(User))
                    {
                        saveService = new UserServerService();
                       
                        user = JsonConvert.DeserializeObject<User>(jsonData)!;
                        Type? type = saveService.GetType();
                        MethodInfo? method = type.GetMethod(WhatCommandIRecived);
                       
                        if (method != null)
                        {
                            user = (User)method.Invoke(saveService, new object[] { user, WhiteboardContext });
                            return user;
                        }
                    }

                    else if (WhatClassIRecived == nameof(UserArt))
                    {
                        saveService = new ArtServerService();
                        userArt = JsonConvert.DeserializeObject<UserArt>(jsonData)!;
                        Type? type = saveService.GetType();
                        MethodInfo? method = type.GetMethod(WhatCommandIRecived);

                        if (method != null)
                        {
                            userArt = (UserArt)method.Invoke(saveService, new object[] { userArt, WhiteboardContext });
                            return userArt;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { client.Close(); } 

            return null;
        }



        public void PostMessage(TcpClient client,object message)
        {
            client = Listener.AcceptTcpClient();
            //var jsonSettings = new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //};
            //string jsonData = JsonConvert.SerializeObject(message, jsonSettings);
            //string jsonData = JsonConvert.SerializeObject(message);

            //using StreamWriter stream = new(client.GetStream());
            //Console.WriteLine($"You post a: {message}");

            using MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            if (WhatClassIRecived == nameof(User))
            {
                binaryFormatter.Serialize(memoryStream, user);
            }
            else
                binaryFormatter.Serialize(memoryStream, userArt);

            using NetworkStream networkStream = client.GetStream();
            byte[] userBytes = memoryStream.ToArray();

            int bytesSent = 0;
            while (bytesSent < userBytes.Length)
            {
                int bytesToSend = Math.Min(userBytes.Length - bytesSent, 1024); 
                networkStream.Write(userBytes, bytesSent, bytesToSend);
                bytesSent += bytesToSend;
            }

            //if (WhatClassIRecived == nameof(UserArt))
            //    stream.Write(userArt);

            //else
            //    stream.Write(user);

            //stream.Write(jsonData);
        }
    }
}
