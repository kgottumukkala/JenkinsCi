#region Imports

using System.Data.Entity.ModelConfiguration;
using Chipotle.Entity.Models;

#endregion


namespace Chipotle.Data.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            // Primary Key
            HasKey( t => t.RoleId );

            // Properties
            Property( t => t.RoleId )
                .IsRequired();
            Property( t => t.Title )
                .IsRequired()
                .HasMaxLength( 20 );
            Property( t => t.IsEnabled )
                .IsRequired();
            Property( t => t.Description )
                .IsOptional()
                .HasMaxLength( 500 );

            // Table & Column Mappings
            ToTable( "Roles" );
            Property( t => t.RoleId ).HasColumnName( "RoleId" );
            Property( t => t.Title ).HasColumnName( "Title" );
            Property( t => t.IsEnabled ).HasColumnName( "IsEnabled" );
                
        }
        
           
    }
}
