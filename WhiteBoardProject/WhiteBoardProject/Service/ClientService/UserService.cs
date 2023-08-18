using ProjectLib.Model.Class;
using System.IO;
using WhiteBoardProject.Service.Interface;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using WhiteBoardProject.Class;
using System.Threading.Tasks;

namespace WhiteBoardProject.Service.ClientService
{
    public class UserService : IWhiteboardtClientService
    {
        private ClientService clientService;
        private string ipAdress = IpPath.Ip;
        private int port = IpPath.Port; 

        public static User ActiveUser { get; set; }

        public UserService() { }
        public UserService(User user)
        {
            ActiveUser = user;
            clientService = new(ipAdress, port);
        }


        public void  SendToServer(string command, object iWhiteboardobj)
        {
            clientService = new(ipAdress, port);
            clientService.PostToServer(iWhiteboardobj.GetType().Name);
            clientService.PostToServer(command);
            clientService.PostToServer(iWhiteboardobj);
        }

        public async Task<T?> ReciveAsync<T>()
        {
            return await clientService.Recive<T>();
        }

    }
}
