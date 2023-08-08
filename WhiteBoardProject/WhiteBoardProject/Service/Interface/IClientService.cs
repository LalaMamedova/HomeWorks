using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteBoardProject.Service.Interface
{
    public interface IClientService
    {
        public void Save(object[]? entity);
        public void SendToServer();
        public void Load(object[]? entity);
    }
}
