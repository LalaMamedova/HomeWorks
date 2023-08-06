using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteboardServer.Service.Interface
{
    public interface ISaveService
    {
        public T Save<T>(T entity);
    }
}
