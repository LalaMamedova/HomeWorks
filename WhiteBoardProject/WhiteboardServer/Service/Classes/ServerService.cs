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
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using WhiteboardServer.Service.Interface;

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

        public ServerService(IPAddress address, int port)
        {
            IPAddress = address;
            Listener = new TcpListener(address, port);
            Listener.Start();
        }
        public TcpClient? Connection()
        {
            TcpClient client = Listener.AcceptTcpClient();

            //IPEndPoint? clientIPAddress = ((IPEndPoint)client.Client.RemoteEndPoint);
            //User user = new() { IPEndPoint = clientIPAddress };
            //Console.WriteLine("Клиент зашел");

            return client;
        }

        public object? ReciveMessage(TcpClient? client) 
        {
            try
            {
                using StreamReader reader = new StreamReader(client.GetStream());
                string? jsonData =  reader.ReadLine();

                if (jsonData== nameof(User) || jsonData == nameof(UserArt))
                    WhatClassIRecived = jsonData;

                else if (!jsonData.Contains('{'))
                {
                    WhatCommandIRecived = jsonData;
                }

                else if (!string.IsNullOrEmpty(jsonData))
                {
                    Console.WriteLine($"Received object from client: {jsonData}");

                    if (WhatClassIRecived == nameof(User))
                    {
                        saveService = new UserSaveService();

                        User user = JsonConvert.DeserializeObject<User>(jsonData)!;
                        Type? type = saveService.GetType();
                        MethodInfo? method = type.GetMethod(WhatCommandIRecived);

                        if (method != null)
                        {
                            client.Close();
                            return method.Invoke(saveService, new object[] { user, WhiteboardContext });
                        }
                    }

                    //else if (WhatClassIRecived == nameof(UserArt))
                    //{
                    //    saveService = new PictureSaveService();
                    //    Type? type = saveService.GetType();
                    //    MethodInfo? method = type.GetMethod(WhatCommandIRecived);
                    //    UserArt userArt = JsonConvert.DeserializeObject<UserArt>(jsonData)!;

                    //    if (method != null)
                    //    {
                    //        return method.Invoke(saveService, new object[] { userArt, WhiteboardContext });
                    //    }
                    //}
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            client.Close();
            return null;
        }



        public void PostMessage(TcpClient client,object message)
        {
            WhatCommandIRecived = "";
            client = Listener.AcceptTcpClient();
            using StreamWriter stream = new(client.GetStream());
            string jsonData = JsonConvert.SerializeObject(message);
            Console.WriteLine(message);
            stream.Write(jsonData);
        }
    }
}
