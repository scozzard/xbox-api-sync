using AutoMapper;
using Scozzard.Model;
using Scozzard.Service.Interfaces;
using Scozzard.Service.SyncServices.Interfaces;
using Scozzard.XboxApiClient.Client;
using Scozzard.XboxApiClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scozzard.Service.SyncServices
{
    public class SyncScreenshotsService : ISyncScreenshotsService
    {
        private readonly IXboxUserService xboxUserService;
        private readonly IScreenshotService screenshotService;
        private readonly XboxApi xboxApi;

        public SyncScreenshotsService( IXboxUserService xboxUserService, IScreenshotService screenshotService, XboxApi xboxApi)
        {
            this.xboxUserService = xboxUserService;
            this.screenshotService = screenshotService;
            this.xboxApi = xboxApi;
        }

        public void SyncScreenshots()
        {
            // get all xbox users that haven't been sync'ed in the last hour.
            var xboxUsers = xboxUserService.GetXboxUsers().Where(x => x.ActivitiesLastSyncedAtt < DateTime.UtcNow.AddMinutes(-5));

            foreach (var xboxUser in xboxUsers)
            {
                var apiXboxUserScreenshots = xboxApi.GetUserScreenshots(xboxUser.XboxUserID);
                var xboxUserScreenshots = screenshotService.GetXboxUserScreenshots(xboxUser.XboxUserID);

                foreach (var screenshot in apiXboxUserScreenshots)
                {
                    var xboxUserScreenshot = xboxUserScreenshots.Where(x => x.XblID == screenshot.screenshotId).FirstOrDefault();

                    if (xboxUserScreenshot != null)
                    {
                        xboxUserScreenshot.State = screenshot.state;
                        xboxUserScreenshot.DatePublished = screenshot.datePublished;
                        screenshotService.UpdateScreenshot(xboxUserScreenshot);
                    }
                    else
                    {
                        screenshotService.CreateScreenshot(new Screenshot()
                        {
                            XblID = screenshot.screenshotId,
                            DateTaken = screenshot.dateTaken,
                            DatePublished = screenshot.datePublished,
                            ScreenshotUris = screenshot.screenshotUris.Select(x => new ScreenshotUri()
                            {
                                Uri = x.uri,
                                UriType = x.uriType,
                                Expiration = x.expiration,
                                FileSize = x.fileSize
                            }).ToList(),
                            Thumbnails = screenshot.thumbnails.Select(x => new ScreenshotThumbnail()
                            {
                                Uri = x.uri,
                                FileSize = x.fileSize,
                                ThumbnailType = x.thumbnailType
                            }).ToList(),
                            XboxUserID = xboxUser.XboxUserID,
                            XboxUser = xboxUser,
                            TitleName = screenshot.titleName,
                            DeviceType = screenshot.deviceType,
                            State = screenshot.state
                        });
                    }
                }

                screenshotService.Save();
            }
        }
    }
}
