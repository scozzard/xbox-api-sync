using System.Collections.Generic;
using Scozzard.Model;
using Scozzard.Respository.Infrastructure;
using Scozzard.Respository.Repositories;
using Scozzard.Service.Interfaces;
using System.Linq;

namespace Scozzard.Service
{
    public class GameClipService : IGameClipService
    {
        private readonly IGameClipRepository gameClipRepository;
        private readonly IUnitOfWork unitOfWork;

        public GameClipService(IGameClipRepository gameClipRepository, IUnitOfWork unitOfWork)
        {
            this.gameClipRepository = gameClipRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<GameClip> GetGameClips()
        {
            var gameClips = gameClipRepository.GetAll();
            return gameClips;
        }

        public IEnumerable<GameClip> GetXboxUserGameClips(long xboxUserId)
        {
            var gameClips = gameClipRepository.GetAll().Where(x => x.XboxUserID == xboxUserId);
            return gameClips;
        }

        public GameClip GetGameClip(int id)
        {
            var gameClip = gameClipRepository.GetById(id);
            return gameClip;
        }

        public void CreateGameClip(GameClip gameClip)
        {
            gameClipRepository.Add(gameClip);
        }

        public void UpdateGameClip(GameClip gameClip)
        {
            gameClipRepository.Update(gameClip);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}
