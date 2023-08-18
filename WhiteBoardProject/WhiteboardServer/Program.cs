using ProjectLib.Model.Class;
using System.Net;
using System.Net.Sockets;
using WhiteboardServer.Service.Classes;

ServerService serverService = new(IPAddress.Any, IpPath.Port);

while (true)
{
    try
    {
        TcpClient client = serverService.Listener.AcceptTcpClient();
        object? postObject = await Task.Run(()=> serverService.Recive(client));

        if (postObject != null)
        {
            await Task.Run(()=>serverService.PostMessage(client, postObject));
            client.Close();
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}