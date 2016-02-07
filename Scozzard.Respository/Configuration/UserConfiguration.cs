using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scozzard.Model;

namespace Scozzard.Respository.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("User");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.Password).IsRequired();
            Property(g => g.Email).IsRequired();
            Property(g => g.XboxUserID).IsRequired();
        }
    }
}
