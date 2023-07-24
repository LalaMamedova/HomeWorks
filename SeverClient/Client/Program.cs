using System.Net.Sockets;
using System.Text;

try
{
    TcpClient client = new TcpClient("127.0.0.1",8080);

    NetworkStream networkStream = client.GetStream();
    byte[] bytes = new byte[256];
    networkStream.Read(bytes, 0, bytes.Length);
    string message = Encoding.ASCII.GetString(bytes);
    Console.WriteLine(message);

    StreamWriter writer = new StreamWriter(client.GetStream());
    string message2 = "Bye, server!";
    writer.WriteLine(message2);
    writer.Close();
    client.Close();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}