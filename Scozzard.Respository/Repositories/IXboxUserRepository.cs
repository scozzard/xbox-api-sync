using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scozzard.Model;
using Scozzard.Respository.Infrastructure;

namespace Scozzard.Respository.Repositories
{
    public interface IXboxUserRepository : IRepository<XboxUser>
    {
        XboxUser GetById(long id);
        List<XboxUser> GetAll();
    }
}
