using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SandO.GoodVariration.Interface
{
    public interface IPublisher
    {
        public void Publish(params INotify[] message);
    }
}
