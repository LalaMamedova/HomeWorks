using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Interface
{
    public interface IClient
    {
        public List<IRequest> Myrequest { get; set; }

    }
}
