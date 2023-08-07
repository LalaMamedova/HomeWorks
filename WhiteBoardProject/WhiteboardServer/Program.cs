using System.Net;
using System.Net.Sockets;
using WhiteboardServer.Service.Classes;

ServerService serverService = new(IPAddress.Parse("192.168.2.9"), 9000);
while (true)
{
    try
    {
        // Ожидание подключения клиента
        TcpClient client = serverService.Connection();

        string message = serverService.ReciveMessage<String>(client);
        client.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}