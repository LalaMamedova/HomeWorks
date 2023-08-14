using ProjectLib.Model.Class;
using ProjectLib.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteBoardProject.Service.Interface
{
    public interface IWhiteboardtService
    {
        public void Save(object[]? entity);
        public object? Recive();
        public void SendToServer(string command, object iWhiteBoardobj);
    }
}
