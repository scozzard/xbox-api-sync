using Scozzard.Model;
using Scozzard.Service.Interfaces;
using Scozzard.XboxApiClient.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scozzard.Service
{
    public class SyncActivityService : ISyncActivityService
    {
        private readonly IXboxUserService xboxUserService;
        private readonly IActivityService activityService;
        private readonly XboxApi xboxApi;

        public SyncActivityService( IXboxUserService xboxUserService, IActivityService activityService, XboxApi xboxApi)
        {
            this.xboxUserService = xboxUserService;
            this.activityService = activityService;
            this.xboxApi = xboxApi;
        }

        public void SyncActivity()
        {
            // get all xbox users that haven't been sync'ed in the last hour.
            var xboxUsers = xboxUserService.GetXboxUsers().Where(x => x.ActivitiesLastSyncedAtt < DateTime.UtcNow.AddMinutes(-5));

            foreach (var xboxUser in xboxUsers)
            {
                var apiXboxUserActivities = xboxApi.GetUserActivities(xboxUser.XboxUserID);

                var lastRecoredUserActivity = activityService.GetXboxUserActivities(xboxUser.XboxUserID).OrderByDescending(x => x.StartTime).FirstOrDefault();

                foreach (var activity in apiXboxUserActivities.Where(x => lastRecoredUserActivity == null || x.startTime > lastRecoredUserActivity.StartTime))
                {
                    activityService.CreateActivity(new Activity()
                    {
                        StartTime = activity.startTime,
                        EndTime = activity.endTime,
                        SessionDurationInMinutes = activity.sessionDurationInMinutes,
                        Description = activity.description,
                        ImageUrl = activity.itemImage,
                        XboxUserID = xboxUser.XboxUserID,
                        Platform = activity.platform,
                        ContentType = activity.contentType,
                        XboxUser = xboxUser
                    });
                }

                xboxUser.ActivitiesLastSyncedAtt = DateTime.UtcNow;
            }

            activityService.Save();
        }
    }
}
