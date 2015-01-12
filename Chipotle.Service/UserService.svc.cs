using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Chipotle.Entity.Models;
using Repository;
using Chipotle.Data;

namespace Chipotle.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        IUnitOfWork _unitOfWork = new UnitOfWork( new ChipotleContext() );
        public List<User> GetUsers ()
        {
            return _unitOfWork.Repository<User>().Query().Get().ToList(); 
        }

        public User GetUser ( string id )
        {
            int userId = Convert.ToInt32( id );
            return _unitOfWork.Repository<User>().Query().Get().SingleOrDefault( u => u.UserId == userId );
        }

        public void AddUser ( User user )
        {
            _unitOfWork.Repository<User>().Insert( user );
            _unitOfWork.Save();
        }

        public void UpdateUser ( User user )
        {
            _unitOfWork.Repository<User>().Update( user );
            _unitOfWork.Save();
        }

        public void DeleteUser ( string id )
        {
            int userId = Convert.ToInt32( id );
            User user = _unitOfWork.Repository<User>().Query().Get().SingleOrDefault( u => u.UserId == userId );
            _unitOfWork.Repository<User>().Delete( user );
            _unitOfWork.Save();
        }
    }
}
