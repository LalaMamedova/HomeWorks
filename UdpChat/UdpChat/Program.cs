using System.Net;
using System.Net.Sockets;
using System.Text;


//CLIENT PART
int port = 12345;
string? name = null;
using UdpClient udpClient = new UdpClient();

try
{
    IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

    Console.Write("Введите свой ник: ");
    name = Console.ReadLine();

    IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 0);
    udpClient.Client.Bind(localEndPoint);
    udpClient.Send(GetByte(name), GetByte(name).Length, serverEndPoint);


    Task receiveThread = new(() =>
    {
        while (true)
        {
            byte[] data =  udpClient.Receive(ref serverEndPoint);
            string message = Encoding.UTF8.GetString(data);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    });

    receiveThread.Start();

    while (true)
    {
        string message = Console.ReadLine();

        if (!string.IsNullOrEmpty(message))
        {
            message = $"{name} {DateTime.Now.ToShortTimeString()}: {message}";
            udpClient.Send(GetByte(message), GetByte(message).Length, serverEndPoint);
        }
        else
        {
            Console.SetCursorPosition(Console.WindowHeight-1, Console.CursorTop - 2);
            continue;
        }
    }
}
catch (SocketException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}
finally
{
    udpClient.Close();
    udpClient.Send(GetByte($"{name} вышел из чата"), GetByte($"{name} вышел из чата").Length);
}

byte[] GetByte(string message)
{
    return Encoding.UTF8.GetBytes(message);
}