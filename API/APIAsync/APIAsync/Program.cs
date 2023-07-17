using APIAsync.Class;
using APIAsync.Service;
using Newtonsoft.Json;

DownloadFact downloadFact = new DownloadFact();

try
{
    await downloadFact.Download(2);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}