using System.Collections.Generic;
using Scozzard.Model;
using Scozzard.Respository.Infrastructure;
using Scozzard.Respository.Repositories;
using Scozzard.Service.Interfaces;

namespace Scozzard.Service
{
    public class XboxUserService : IXboxUserService
    {
        private readonly IXboxUserRepository XboxUsersRepository;
        private readonly IUnitOfWork unitOfWork;

        public XboxUserService(IXboxUserRepository XboxUsersRepository, IUnitOfWork unitOfWork)
        {
            this.XboxUsersRepository = XboxUsersRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IXboxUserService Members

        public IEnumerable<XboxUser> GetXboxUsers()
        {
            var XboxUsers = XboxUsersRepository.GetAll();
            return XboxUsers;
        }

        public XboxUser GetXboxUser(int id)
        {
            var XboxUser = XboxUsersRepository.GetById(id);
            return XboxUser;
        }

        public XboxUser GetXboxUser(string gamertag)
        {
            var XboxUser = XboxUsersRepository.Get(x => x.GamerTag == gamertag);
            return XboxUser;
        }

        public void CreateXboxUser(XboxUser XboxUser)
        {
            XboxUsersRepository.Add(XboxUser);
        }

        public void SaveXboxUser()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
