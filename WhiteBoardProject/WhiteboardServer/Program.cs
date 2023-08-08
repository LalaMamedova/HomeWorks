using System.Net;
using System.Net.Sockets;
using WhiteboardServer.Service.Classes;

ServerService serverService = new(IPAddress.Any, 9000);
while (true)
{
    try
    {
        TcpClient client = serverService.Connection();

        await Task.Run(() => serverService.ReciveMessage(client));
        client.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}