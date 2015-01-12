using Chipotle.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Chipotle.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRoleService
    {

        [OperationContract]
        [WebGet(UriTemplate="/Roles", ResponseFormat=WebMessageFormat.Json)]
        List<Role> GetRoles ();

        [OperationContract]
        [WebGet( UriTemplate = "/Roles/{id}", ResponseFormat = WebMessageFormat.Json )]
        Role GetRole ( string id );

        [OperationContract]
        [WebInvoke( UriTemplate = "/Roles", RequestFormat = WebMessageFormat.Json, Method = "POST" )]
        void AddRole ( Role role );

        [OperationContract]
        [WebInvoke( UriTemplate = "/Roles", RequestFormat = WebMessageFormat.Json, Method = "PUT" )]
        void UpdateRole ( Role role );

        [OperationContract]
        [WebInvoke( UriTemplate = "/Roles/{id}", RequestFormat = WebMessageFormat.Json, Method = "DELETE" )]
        void DeleteRole ( string id );

        
    }


    
}
