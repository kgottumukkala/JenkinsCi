using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Chipotle.Entity.Models;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Chipotle.Web.ServiceClient
{
    public class RoleServiceClient  : IServiceClient<Role>
    {
        public Role Get (int id)
        {
            var httpResponse = ServiceUtil.GetEntities( Properties.Settings.Default.JsonRoleService, id.ToString() );

            DataContractJsonSerializer obj =
                         new DataContractJsonSerializer( typeof( Role ) );
            Role role = obj.ReadObject( httpResponse ) as Role;
            return role;
        }

        public string Add (Role role)
        {
            DataContractJsonSerializer dataContractSerializer =
                    new DataContractJsonSerializer( typeof( Role ) );
            MemoryStream mem = new MemoryStream();
            dataContractSerializer.WriteObject( mem, role );
            string data =
                Encoding.UTF8.GetString( mem.ToArray(), 0, ( int )mem.Length );
            return ServiceUtil.PostEntity( Properties.Settings.Default.JsonRoleService, data );

        }

        public string Update (Role role)
        {
            DataContractJsonSerializer dataContractSerializer =
                    new DataContractJsonSerializer( typeof( Role ) );
            MemoryStream mem = new MemoryStream();
            dataContractSerializer.WriteObject( mem, role );
            string data =
                Encoding.UTF8.GetString( mem.ToArray(), 0, ( int )mem.Length );
            return ServiceUtil.PostEntity( Properties.Settings.Default.JsonRoleService, data, "PUT" );
        }

        public string Delete (int id)
        {
            return ServiceUtil.PostEntity( serviceUrl: Properties.Settings.Default.JsonRoleService, method: "DELETE", entityId: id.ToString() );
        }



        public List<Role> Get ()
        {
            var httpResponse = ServiceUtil.GetEntities( Properties.Settings.Default.JsonRoleService );

            DataContractJsonSerializer obj =
                         new DataContractJsonSerializer( typeof( List<Role> ) );
            List<Role> roles = obj.ReadObject( httpResponse ) as List<Role>;
            return roles;
            
        }


       
    }
}
