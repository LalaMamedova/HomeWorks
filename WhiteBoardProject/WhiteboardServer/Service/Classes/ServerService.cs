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
        private string WhatCommandIRecived;
        private int Port;
        private UserArt userArt;
        private IUser? user;
        private IModelService saveService;

        public TcpListener Listener { get; set; }
        public WhiteboardContext WhiteboardContext { get; set; } = new();

        public ServerService(IPAddress address, int port)
        {
            Listener = new TcpListener(address, port);
            Listener.Start();
        }

        public async Task<object?> Recive(TcpClient client)
        {
            try
            {
                using NetworkStream networkStream = client.GetStream();
                using MemoryStream memoryStream = new MemoryStream();

                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await memoryStream.WriteAsync(buffer, 0, bytesRead);
                }
                memoryStream.Seek(0, SeekOrigin.Begin);

                BinaryFormatter? binaryFormatter = new BinaryFormatter();
                object deserializeObj = binaryFormatter.Deserialize(memoryStream);

                if (deserializeObj.GetType().Name == nameof(String))
                {
                    if ((string)deserializeObj == nameof(User) || (string)deserializeObj == nameof(UserArt) || (string)deserializeObj == nameof(UserDTO))
                        WhatClassIRecived = (string)deserializeObj;
                    else
                        WhatCommandIRecived = (string)deserializeObj;
                }
                else
                {
                    Console.WriteLine($"You recived {deserializeObj}");

                    if (deserializeObj is IWhiteboard iwhiteboard)
                    {
                        switch (iwhiteboard)
                        {
                            case UserDTO userDto:
                                user = userDto;
                                break;
                            case User userEntity:
                                user = userEntity;
                                break;
                            case UserArt userArtEntity:
                                userArt = userArtEntity;
                                break;
                        }
                    }

                    if (WhatClassIRecived == nameof(User) || WhatClassIRecived == nameof(UserDTO))
                    {
                        saveService = new UserServerService();
                        MethodInfo? method = GetMethod(WhatCommandIRecived);

                        if (method != null)
                        {
                            user = (User)method.Invoke(saveService, new object[] { user, WhiteboardContext });
                            return user;
                        }
                    }
                    else if (WhatClassIRecived == nameof(UserArt))
                    {
                        saveService = new ArtServerService();
                        MethodInfo? method = GetMethod(WhatCommandIRecived);

                        if (method != null)
                        {
                            userArt = (UserArt)method.Invoke(saveService, new object[] { userArt, WhiteboardContext });
                            WhiteboardContext.Entry(userArt).State = EntityState.Detached;
                            return userArt;
                        }
                    }
                    Console.WriteLine($"You {WhatCommandIRecived}ed {deserializeObj}");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { client.Close(); }
            return null;
        }
      
        public async Task PostMessage(TcpClient client,object message)
        {
            client = await Listener.AcceptTcpClientAsync();

            using MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, message);

            using NetworkStream networkStream = client.GetStream();
            byte[] userBytes = memoryStream.ToArray();

            int bytesSent = 0;
            while (bytesSent < userBytes.Length)
            {
                int bytesToSend = Math.Min(userBytes.Length - bytesSent, 1024); 
                await networkStream.WriteAsync(userBytes, bytesSent, bytesToSend);
                bytesSent += bytesToSend;
            }
            await Console.Out.WriteLineAsync($"You post: {message}") ;

        }

        private MethodInfo? GetMethod(string coomand)
        {
            Type? type = saveService.GetType();
            MethodInfo? method = type.GetMethod(coomand);
            return method;
        }
    }
}
