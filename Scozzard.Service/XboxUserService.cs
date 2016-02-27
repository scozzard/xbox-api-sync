using System.Collections.Generic;
using Scozzard.Model;
using Scozzard.Respository.Infrastructure;
using Scozzard.Respository.Repositories;
using Scozzard.Service.Interfaces;

namespace Scozzard.Service
{
    public class XboxUserService : IXboxUserService
    {
        private readonly IXboxUserRepository xboxUsersRepository;
        private readonly IUnitOfWork unitOfWork;

        public XboxUserService(IXboxUserRepository XboxUsersRepository, IUnitOfWork unitOfWork)
        {
            this.xboxUsersRepository = XboxUsersRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<XboxUser> GetXboxUsers()
        {
            var XboxUsers = xboxUsersRepository.GetAll();
            return XboxUsers;
        }

        public XboxUser GetXboxUser(long id)
        {
            var XboxUser = xboxUsersRepository.GetById(id);
            return XboxUser;
        }

        public XboxUser GetXboxUser(string gamertag)
        {
            var XboxUser = xboxUsersRepository.Get(x => x.GamerTag == gamertag);
            return XboxUser;
        }

        public void CreateXboxUser(XboxUser XboxUser)
        {
            xboxUsersRepository.Add(XboxUser);
        }

        public void UpdateXboxUser(XboxUser xboxUser)
        {
            xboxUsersRepository.Update(xboxUser);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}
