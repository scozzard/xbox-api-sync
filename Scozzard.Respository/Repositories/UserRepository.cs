using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scozzard.Model;
using Scozzard.Respository.Infrastructure;

namespace Scozzard.Respository.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

        public User Get(string email, string password)
        {
            var user = this.DbContext.Users.Where(x => x.Email == email && x.Password == password);

            return user.FirstOrDefault();
        }
    }
}
