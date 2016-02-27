using Scozzard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scozzard.Service.Interfaces
{
    public interface IXboxUserService
    {
        IEnumerable<XboxUser> GetXboxUsers();
        XboxUser GetXboxUser(int id);
        XboxUser GetXboxUser(string gamerTag);
        void CreateXboxUser(XboxUser xboxUser);
        void UpdateXboxUser(XboxUser xboxUser);
        void SaveXboxUser();
    }
}
