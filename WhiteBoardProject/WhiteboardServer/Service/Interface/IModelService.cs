using ProjectLib.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteboardServer.Service.Interface
{
    public interface IModelService
    {
        public object? Add(object? entity,WhiteboardContext whiteboardContext);
        public object? Update(object? entity, WhiteboardContext whiteboardContext);
        public object? Delete(object? entity, WhiteboardContext whiteboardContext);
        public object? Exist(object? entity, WhiteboardContext whiteboardContext);
    }
}
