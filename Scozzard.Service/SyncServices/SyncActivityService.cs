using Scozzard.Model;
using Scozzard.Service.Interfaces;
using Scozzard.Service.SyncServices.Interfaces;
using Scozzard.XboxApiClient.Client;
using System;
using System.Linq;

namespace Scozzard.Service.SyncServices
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
                var xboxdUserActivities = activityService.GetXboxUserActivities(xboxUser.XboxUserID);
                var fiveyearsago = DateTime.Now.AddYears(-5);

                foreach (var activity in apiXboxUserActivities)
                {
                    var xboxUserActivity = xboxdUserActivities.Where(x => TrimMilliseconds(x.Date.Value) == TrimMilliseconds(activity.date)).FirstOrDefault();

                    if (xboxUserActivity != null)
                    {
                        xboxUserActivity.StartTime = activity.startTime;
                        xboxUserActivity.EndTime = activity.endTime;
                        xboxUserActivity.ActivityItemType = activity.activityItemType;
                        xboxUserActivity.SessionDurationInMinutes = activity.sessionDurationInMinutes;
                        xboxUserActivity.Description = activity.description;
                        xboxUserActivity.ImageUrl = activity.itemImage;
                        xboxUserActivity.Platform = activity.platform;
                        xboxUserActivity.ContentType = activity.contentType;

                        activityService.UpdateActivity(xboxUserActivity);
                    }
                    else
                    {
                        activityService.CreateActivity(new Activity()
                        {
                            Date = activity.date,
                            StartTime = activity.startTime,
                            EndTime = activity.endTime,
                            ActivityItemType = activity.activityItemType,
                            SessionDurationInMinutes = activity.sessionDurationInMinutes,
                            Description = activity.description,
                            ImageUrl = activity.itemImage,
                            Platform = activity.platform,
                            ContentType = activity.contentType,
                            XboxUserID = xboxUser.XboxUserID,
                            XboxUser = xboxUser
                        });
                    }
                }

                xboxUser.ActivitiesLastSyncedAtt = DateTime.UtcNow;
            }

            activityService.Save();
        }

        private DateTime TrimMilliseconds(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, 0);
        }
    }
}
