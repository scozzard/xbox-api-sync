using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scozzard.Model;
using Scozzard.Respository.Infrastructure;

namespace Scozzard.Respository.Repositories
{
    public class GadgetRepository : RepositoryBase<Gadget>, IGadgetRepository
    {
        public GadgetRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }
    }
}
