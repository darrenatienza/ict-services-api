using API.Queries.Core.Domain;
using API.Queries.Core.Domain.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.EntityConfiguration
{
    public class UserConfiguration  : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.UserID)
            .IsRequired();

            Property(u => u.UserName)
            .IsRequired()
            
            .HasMaxLength(250);

            Property(u => u.FirstName)
             .IsRequired()
             .HasMaxLength(250);

            Property(u => u.MiddleName)
            .IsRequired()
            .HasMaxLength(250);

            Property(u => u.LastName)
             .IsRequired()
             .HasMaxLength(250);

            Property(u => u.Password)
              .IsRequired();

            Property(u => u.PasswordSalt)
             .IsRequired();

          

            HasMany(u => u.Permissions)
                .WithMany(p => p.Users)
                .Map(m =>
                {

                    m.ToTable("UserPermissions", "Auth");
                    m.MapLeftKey("UserID");
                    m.MapRightKey("PermissionID");
                });
        }

        
    }
}
