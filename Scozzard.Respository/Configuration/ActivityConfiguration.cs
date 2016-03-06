using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scozzard.Model;

namespace Scozzard.Respository.Configuration
{
    public class ActivityConfiguration : EntityTypeConfiguration<Activity>
    {
        public ActivityConfiguration()
        {
            ToTable("Activity");
            Property(g => g.XboxUserID).IsRequired();
            Property(g => g.Description).IsRequired();
            Property(g => g.EndTime).IsOptional();
            Property(g => g.SessionDurationInMinutes).IsOptional();
        }
    }
}
