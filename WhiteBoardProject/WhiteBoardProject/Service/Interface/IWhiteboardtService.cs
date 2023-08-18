using ProjectLib.Model.Class;
using ProjectLib.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteBoardProject.Service.Interface
{
    public interface IWhiteboardtClientService
    {
        Task<T?> ReciveAsync<T>();
        void SendToServer(string command, object iWhiteboardobj);
    }
}
