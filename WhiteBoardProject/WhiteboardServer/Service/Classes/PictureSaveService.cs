using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteboardServer.Service.Interface;

namespace WhiteboardServer.Service.Classes
{
    public class PictureSaveService : ISaveService
    {
        T ISaveService.Save<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
