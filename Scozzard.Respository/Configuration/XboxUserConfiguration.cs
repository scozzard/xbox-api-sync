using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scozzard.Model;

namespace Scozzard.Respository.Configuration
{
    public class XboxUserConfiguration : EntityTypeConfiguration<XboxUser>
    {
        public XboxUserConfiguration()
        {
            ToTable("XboxUser")
            .HasMany(x => x.Friends)
            .WithMany()
            .Map(x =>
            {
                x.MapLeftKey("XboxUserID");
                x.MapRightKey("XboxFriendUserID");
                x.ToTable("XboxUserFriends");
            });
        }
    }
}
