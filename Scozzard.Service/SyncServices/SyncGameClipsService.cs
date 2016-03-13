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
    public class SyncGameClipsService : ISyncGameClipsService
    {
        private readonly IXboxUserService xboxUserService;
        private readonly IGameClipService gameClipService;
        private readonly XboxApi xboxApi;

        public SyncGameClipsService( IXboxUserService xboxUserService, IGameClipService gameClipService, XboxApi xboxApi)
        {
            this.xboxUserService = xboxUserService;
            this.gameClipService = gameClipService;
            this.xboxApi = xboxApi;
        }

        public void SyncGameClips()
        {
            // get all xbox users that haven't been sync'ed in the last hour.
            var xboxUsers = xboxUserService.GetXboxUsers().Where(x => x.ActivitiesLastSyncedAtt < DateTime.UtcNow.AddMinutes(-5));

            foreach (var xboxUser in xboxUsers)
            {
                var apiXboxUserGameClips = xboxApi.GetUserGameClips(xboxUser.XboxUserID);
                var xboxUserGameClips = gameClipService.GetXboxUserGameClips(xboxUser.XboxUserID);

                foreach (var gameClip in apiXboxUserGameClips)
                {
                    var xboxUserGameClip = xboxUserGameClips.Where(x => x.XblID == gameClip.gameClipId).FirstOrDefault();

                    if (xboxUserGameClip != null)
                    {
                        xboxUserGameClip.State = gameClip.state;
                        xboxUserGameClip.DatePublished = gameClip.datePublished;
                        gameClipService.UpdateGameClip(xboxUserGameClip);
                    }
                    else
                    {
                        gameClipService.CreateGameClip(new GameClip()
                        {
                            XblID = gameClip.gameClipId,
                            DateRecorded = gameClip.dateRecorded,
                            DatePublished = gameClip.datePublished,
                            ClipUris = gameClip.gameClipUris.Select(x => new GameClipUri()
                            {
                                Uri = x.uri,
                                UriType = x.uriType,
                                Expiration = x.expiration,
                                FileSize = x.fileSize
                            }).ToList(),
                            Thumbnails = gameClip.thumbnails.Select(x => new GameClipThumbnail()
                            {
                                Uri = x.uri,
                                FileSize = x.fileSize,
                                ThumbnailType = x.thumbnailType
                            }).ToList(),
                            XboxUserID = xboxUser.XboxUserID,
                            XboxUser = xboxUser,
                            TitleName = gameClip.titleName,
                            DeviceType = gameClip.deviceType,
                            State = gameClip.state
                        });
                    }
                }

                gameClipService.Save();
            }
        }
    }
}
