using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipotle.Web.ServiceClient
{
    public interface IServiceClient<T>
    {
        List<T> Get ();
        T Get (int id);
        string Add (T t);
        string Update (T t);
        string Delete (int id);
    }
}
