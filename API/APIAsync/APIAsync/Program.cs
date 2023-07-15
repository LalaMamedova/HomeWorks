using APIAsync.Class;
using APIAsync.Service;
using Newtonsoft.Json;

DownLoadMovie downloadWeather = new DownLoadMovie();
Console.WriteLine("Напиши название фильма(на английском)");
string title = Console.ReadLine();

try
{
    await downloadWeather.Download(title);
  
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}