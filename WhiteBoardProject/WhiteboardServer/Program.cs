using System.Net;
using WhiteboardServer.Service.Classes;

ServerService serverService = new(IPAddress.Parse("192.168.2.1"), 9000);
while (true)
{
    serverService.Connection();
}