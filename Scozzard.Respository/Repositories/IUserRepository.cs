using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scozzard.Model;
using Scozzard.Respository.Infrastructure;

namespace Scozzard.Respository.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User Get(string email, string password);
        User GetById(int Id);
    }
}
