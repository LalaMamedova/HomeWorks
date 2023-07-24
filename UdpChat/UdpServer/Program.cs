using System.Net.Sockets;
using System.Net;
using System.Text;
using UdpServer;

int port = 12345;
using UdpClient udpServer = new UdpClient(port);
List<User> clientsList = new();

Console.WriteLine($"Сервер чата начался на порте {port}...");

try
{
    while (true)
    {
        IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
        byte[] data = udpServer.Receive(ref clientEndPoint);
        string message = Encoding.UTF8.GetString(data);
        User? thisclient = Find(clientEndPoint);


        if (thisclient != null)
        {
            Console.WriteLine($"Received from: {message}");

            foreach (var client in clientsList)
            {
                if (client.IPEndPoint != clientEndPoint) udpServer.Send(data, data.Length, client.IPEndPoint);
            }
        }
       


        else
        {
            clientsList.Add(new User()
            {
                IPEndPoint = clientEndPoint,
                Username = message
            });

            Console.WriteLine($"New client connected: {clientsList.Last().Username}");
            byte[] newClientMessage = Encoding.UTF8.GetBytes($"В чат добавился: {clientsList.Last().Username}");

            foreach (var client in clientsList)
            {
                if (client.IPEndPoint != clientEndPoint) udpServer.Send(newClientMessage, newClientMessage.Length, client.IPEndPoint);
                
            }
        }
    }
}
catch (SocketException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}



User? Find(IPEndPoint iPEndPoint)
{
    User? user =  clientsList.Where(x => x.IPEndPoint.Equals(iPEndPoint)).FirstOrDefault();
    if(user != null)
        return user;
    return null;

}
