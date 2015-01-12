using Chipotle.Data.Mapping;
using Repository.Providers.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipotle.Data
{
    public class ChipotleContext : DataContext
    {
        public ChipotleContext () :
            base("ChipotleContext")
        {
            Database.SetInitializer<ChipotleContext>(null);
            Configuration.ProxyCreationEnabled = false;
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating ( DbModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );

            modelBuilder.Configurations.Add( new UserMap() );
            modelBuilder.Configurations.Add( new RoleMap() );

        }
    }
}
