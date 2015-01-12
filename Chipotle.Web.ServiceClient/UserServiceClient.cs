using Chipotle.Entity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipotle.Web.ServiceClient
{
    public class UserServiceClient : IServiceClient<User>
    {

        public List<User> Get ()
        {
            throw new NotImplementedException();
        }

        public User Get ( int id )
        {
            throw new NotImplementedException();
        }

        public string Add ( User t )
        {
            throw new NotImplementedException();
        }

        public string Update ( User t )
        {
            throw new NotImplementedException();
        }

        public string Delete ( int id )
        {
            throw new NotImplementedException();
        }
    }
}
