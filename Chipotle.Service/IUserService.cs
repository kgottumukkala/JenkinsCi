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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebGet(UriTemplate="/Users", ResponseFormat = WebMessageFormat.Json)]
        List<User> GetUsers ();

        [OperationContract]
        [WebGet( UriTemplate = "/Users/{id}", ResponseFormat = WebMessageFormat.Json )]
        User GetUser ( string id );

        [OperationContract]
        [WebInvoke( UriTemplate = "/Users", RequestFormat = WebMessageFormat.Json, Method="POST" )]
        void AddUser ( User user );

        [OperationContract]
        [WebInvoke( UriTemplate = "/Users", RequestFormat = WebMessageFormat.Json, Method = "PUT" )]
        void UpdateUser ( User user );

        [OperationContract]
        [WebInvoke( UriTemplate = "/Users/{id}", RequestFormat = WebMessageFormat.Json, Method = "DELETE" )]
        void DeleteUser ( string id );


    }
}
