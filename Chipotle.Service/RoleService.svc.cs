using Chipotle.Data;
using Chipotle.Entity.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Text;

namespace Chipotle.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Required)]
    public class RoleService : IRoleService
    {
        IUnitOfWork _unitOfWork = new UnitOfWork(new ChipotleContext());
        public List<Role> GetRoles ()
        {
            return _unitOfWork.Repository<Role>().Query().Get().ToList();
        }

        public Role GetRole ( string id )
        {
            int roleId = Convert.ToInt32( id );
            Role role = _unitOfWork.Repository<Role>().Query().Get().SingleOrDefault( r => r.RoleId == roleId );
            return role;
        }

        public void AddRole ( Entity.Models.Role role )
        {
            _unitOfWork.Repository<Role>().Insert( role );
            _unitOfWork.Save();
        }

        public void UpdateRole ( Entity.Models.Role role )
        {
            role.ObjectState = ObjectState.Modified;
            _unitOfWork.Repository<Role>().Update( role );
            _unitOfWork.Save();
        }

        public void DeleteRole ( string id )
        {
            int roleId = Convert.ToInt32( id );
            Role role = _unitOfWork.Repository<Role>().Query().Get().SingleOrDefault( r => r.RoleId == roleId );
            role.ObjectState = ObjectState.Deleted;
            _unitOfWork.Save();
        }
    }
}
