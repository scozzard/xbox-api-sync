using Scozzard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scozzard.Service.Interfaces
{
    public interface IScreenshotService
    {
        IEnumerable<Screenshot> GetScreenshots();
        IEnumerable<Screenshot> GetXboxUserScreenshots(long xboxUserId);
        Screenshot GetScreenshot(int id);
        void CreateScreenshot(Screenshot screenshot);
        void UpdateScreenshot(Screenshot screenshot);
        void Save();
    }
}
