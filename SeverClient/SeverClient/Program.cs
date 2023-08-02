using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

TcpListener server = new(IPAddress.Any, 8080);

try
{
   
    server.Start();
    Console.WriteLine("Welcome to this programm");
    int i = 1;

    while (true)
    {
        TcpClient client = server.AcceptTcpClient();

        PostMessage(client);
        GetMessage(i,client);
        client.Close();
        i++;
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Bye bye");
    server.Stop();
}


void PostMessage(TcpClient client)
{
    NetworkStream stream = client.GetStream();
    byte[] buffer = Encoding.ASCII.GetBytes("SOMEBODY ONCE TOLD ME");
    stream.Write(buffer, 0, buffer.Length);
}

void GetMessage(int i, TcpClient client)
{
    StreamReader reader = new StreamReader(client.GetStream());
    string message = reader.ReadLine();
    Console.WriteLine($"Received message from client: {message}\n" +
                      $"Client quit this programm {i} time ");
}