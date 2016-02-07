using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scozzard.Model;
using Scozzard.Respository.Infrastructure;
using Scozzard.Respository.Repositories;

namespace Scozzard.Service
{
    // operations you want to expose
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        User GetUser(string email, string password);
        void CreateUser(User User);
        void SaveUser();
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository UsersRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository UsersRepository, IUnitOfWork unitOfWork)
        {
            this.UsersRepository = UsersRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IUserService Members

        public IEnumerable<User> GetUsers()
        {
            var Users = UsersRepository.GetAll();
            return Users;
        }

        public User GetUser(int id)
        {
            var User = UsersRepository.GetById(id);
            return User;
        }

        public User GetUser(string email, string password)
        {
            var User = UsersRepository.Get(email, password);
            return User;
        }

        public void CreateUser(User User)
        {
            UsersRepository.Add(User);
        }

        public void SaveUser()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
