using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scozzard.Model;
using Scozzard.Respository.Infrastructure;

namespace Scozzard.Respository.Repositories
{
    public class ActivityRepository : RepositoryBase<Activity>, IActivityRepository
    {
        public ActivityRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }
    }
}
