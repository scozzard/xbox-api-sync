using Scozzard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scozzard.Service.Interfaces
{
    public interface IGameClipService
    {
        IEnumerable<GameClip> GetGameClips();
        IEnumerable<GameClip> GetXboxUserGameClips(long xboxUserId);
        GameClip GetGameClip(int id);
        void CreateGameClip(GameClip gameClip);
        void UpdateGameClip(GameClip gameClip);
        void Save();
    }
}
