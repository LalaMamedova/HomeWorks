using ProjectLib.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteboardServer.Service.Interface
{
    public interface ISaveService
    {
        public bool Save(object? entity,WhiteboardContext whiteboardContext);
    }
}
