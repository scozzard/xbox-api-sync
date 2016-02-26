using System.Collections.Generic;
using Scozzard.Model;
using Scozzard.Respository.Infrastructure;
using Scozzard.Respository.Repositories;
using Scozzard.Service.Interfaces;

namespace Scozzard.Service
{
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
