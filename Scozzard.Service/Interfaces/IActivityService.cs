using Scozzard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scozzard.Service.Interfaces
{
    public interface IActivityService
    {
        IEnumerable<Activity> GetActivities();
        IEnumerable<Activity> GetXboxUserActivities(long xboxUserId);
        Activity GetActivity(int id);
        void CreateActivity(Activity activity);
        void UpdateActivity(Activity activity);
        void Save();
    }
}
