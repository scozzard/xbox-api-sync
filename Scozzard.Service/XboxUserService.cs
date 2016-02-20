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
    public interface IXboxUserService
    {
        IEnumerable<XboxUser> GetXboxUsers();
        XboxUser GetXboxUser(int id);
        XboxUser GetXboxUser(string gamerTag);
        void CreateXboxUser(XboxUser XboxUser);
        void SaveXboxUser();
    }

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
