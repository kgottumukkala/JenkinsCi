#region Imports

using System.Data.Entity.ModelConfiguration;
using Chipotle.Entity.Models; 

#endregion


namespace Chipotle.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap ()
        {
            // Primary Key
            this.HasKey( t => t.UserId );

            // Properties
            Property( t => t.FirstName )
                .IsRequired()
                .HasMaxLength( 50 );
            Property( t => t.LastName )
                .IsRequired()
                .HasMaxLength( 50 );
            Property( t => t.EmailId )
                .IsRequired()
                .HasMaxLength( 100 );
            // Table & Column Mappings
            ToTable("Users");
            Property( t => t.UserId ).HasColumnName("UserId");
            Property( t => t.EmailId ).HasColumnName("EmailId");
            Property( t => t.FirstName ).HasColumnName("FirstName");
            Property( t => t.LastName ).HasColumnName( "LastName" );
            Property( t => t.IsActive ).HasColumnName( "IsActive" );
            Property( t => t.IsLoggedIn ).HasColumnName( "IsLoggedIn" );
            Property( t => t.RoleId ).HasColumnName( "RoleId" );
            this.HasRequired( t => t.Role )
                .WithMany( t => t.Users )
                .HasForeignKey( r => r.RoleId );
           
        }
    }
}
