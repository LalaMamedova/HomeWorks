using Newtonsoft.Json;
using ProjectLib.Model.Class;
using ProjectLib.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WhiteBoardProject.Service.Classes
{
    public class RememberMeService
    {
        static string projectFolderPath = AppDomain.CurrentDomain.BaseDirectory;
        static string fileName = "SavedUser.json";
        public RememberMeService() { }

        public static void RememberMe(IUser user)
        {
            string jsonData = JsonConvert.SerializeObject(user);
            string filePath = Path.Combine(projectFolderPath, fileName);
            File.WriteAllText(filePath, jsonData);
        }

        public static User? LoadRememberedUser()
        {
            string filePath = Path.Combine(projectFolderPath, fileName);

            try
            {
                if (File.Exists(filePath) && !string.IsNullOrEmpty(File.ReadAllText(filePath)))
                {
                    string jsonContent = File.ReadAllText(filePath);
                    User deserializedUser = JsonConvert.DeserializeObject<User>(jsonContent);

                    return deserializedUser;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public static void DeleteRememberedUser()
        {
            string filePath = Path.Combine(projectFolderPath, fileName);
            if(File.Exists(filePath) && !string.IsNullOrEmpty(File.ReadAllText(filePath)))
            {
                File.Open(filePath,FileMode.Truncate);
            }
            
        }
    }
}
