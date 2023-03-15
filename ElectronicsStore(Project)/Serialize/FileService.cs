using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace Serialize;
public  static class FileService
{
    public static void Write(string json, string path)
    {
        using FileStream fs = new(path, FileMode.OpenOrCreate);
        using StreamWriter streamWriter = new(fs);
        streamWriter.Write(json);   
    }

    public static bool CheckNull(string path)
    {
        using FileStream fs = new(path, FileMode.OpenOrCreate);
        using StreamReader streamReader = new(fs);
        var text = streamReader.ReadToEnd();

       if (!string.IsNullOrEmpty(text))  return true; return false;
    }

    public static void Truncate(string? path)
    {
        FileStream fileStream = new(path, FileMode.Truncate);
        fileStream.Close();
    }
    public static string? Read(string? path)
    {
        if(CheckNull(path)) return File.ReadAllText(path);
        return null;
        
    }
   
}
