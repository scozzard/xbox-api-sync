using Scozzard.Model;
using Scozzard.Respository.Repositories;
using Scozzard.Service.Interfaces;
using Scozzard.XboxApiClient.Client;
using Scozzard.XboxApiClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scozzard.Service
{
    public class SyncXboxUsersService : ISyncXboxUsersService
    {
        private readonly XboxApi xboxApi;
        private readonly IXboxUserService xboxUserService;
        private readonly IUserService userService;

        public SyncXboxUsersService(XboxApi xboxApi, IXboxUserService xboxUserService, IUserService userService)
        {
            this.xboxApi = xboxApi;
            this.xboxUserService = xboxUserService;
            this.userService = userService;
        }

        public void SyncXboxUsers()
        {
            // get all xbox users that haven't been sync'ed in the last hour.
            var xboxUsers = xboxUserService.GetXboxUsers().Where(x => x.ProfileLastSyncedAt < DateTime.UtcNow.AddHours(-1));

            // get all xbox users linked with an account
            var userXboxUserIds = userService.GetUsers().Select(x => x.XboxUserID);

            foreach (var xboxUser in xboxUsers)
            {
                //--------------------------------------------//
                // -- update xbox user general information -- //
                //--------------------------------------------//

                var apiXboxUser = xboxApi.GetUser(xboxUser.XboxUserID);

                xboxUser.Gamerscore = apiXboxUser.Gamerscore;
                xboxUser.AccountTier = apiXboxUser.AccountTier;
                xboxUser.GameDisplayName = apiXboxUser.GameDisplayName;
                xboxUser.GameDisplayPicRaw = apiXboxUser.GameDisplayPicRaw;
                xboxUser.PreferredColor = apiXboxUser.PreferredColor;
                xboxUser.AccountTier = apiXboxUser.AccountTier;
                xboxUser.XboxOneRep = apiXboxUser.XboxOneRep;
                xboxUser.ProfileLastSyncedAt = DateTime.UtcNow;

                //----------------------------------------------------------------------//
                // -- refresh xbox user friends --(for linked xbox user accounts only)--//
                //----------------------------------------------------------------------//

                if (userXboxUserIds.Contains(xboxUser.XboxUserID))
                {
                    var apiXboxUserFriends = xboxApi.GetFriends(xboxUser.XboxUserID);

                    // remove xbox users that are no longer friends
                    xboxUser.Friends.RemoveAll(x => !apiXboxUserFriends.Select(y => y.id).Contains(x.XboxUserID));

                    // refresh information for existing friends
                    var apiXboxUserFriendsDic = apiXboxUserFriends.ToDictionary(x => x.id);

                    foreach (var xboxUserFriend in xboxUser.Friends)
                    {
                        xboxUserFriend.Gamerscore = apiXboxUserFriendsDic[xboxUserFriend.XboxUserID].Gamerscore;
                        xboxUserFriend.AccountTier = apiXboxUserFriendsDic[xboxUserFriend.XboxUserID].AccountTier;
                        xboxUserFriend.GameDisplayName = apiXboxUserFriendsDic[xboxUserFriend.XboxUserID].GameDisplayName;
                        xboxUserFriend.GameDisplayPicRaw = apiXboxUserFriendsDic[xboxUserFriend.XboxUserID].GameDisplayPicRaw;
                        xboxUserFriend.PreferredColor = apiXboxUserFriendsDic[xboxUserFriend.XboxUserID].PreferredColor;
                        xboxUserFriend.AccountTier = apiXboxUserFriendsDic[xboxUserFriend.XboxUserID].AccountTier;
                        xboxUserFriend.XboxOneRep = apiXboxUserFriendsDic[xboxUserFriend.XboxUserID].XboxOneRep;
                        xboxUserFriend.ProfileLastSyncedAt = DateTime.UtcNow;
                        xboxUserFriend.ActivitiesLastSyncedAtt = xboxUserFriend.ActivitiesLastSyncedAtt;
                    }

                    // add new friends :)
                    xboxUser.Friends.AddRange(apiXboxUserFriends.Where(x => !xboxUser.Friends.Select(c => c.XboxUserID).Contains(x.id)).Select(x => new XboxUser()
                    {
                        XboxUserID = x.id,
                        GamerTag = x.Gamertag,
                        GameDisplayName = x.GameDisplayName,
                        Gamerscore = x.Gamerscore,
                        GameDisplayPicRaw = x.GameDisplayPicRaw,
                        AccountTier = x.AccountTier,
                        XboxOneRep = x.XboxOneRep,
                        TenureLevel = x.TenureLevel,
                        PreferredColor = x.PreferredColor,
                        ProfileLastSyncedAt = DateTime.UtcNow,
                        ActivitiesLastSyncedAtt = DateTime.UtcNow.AddHours(-1)
                    }));
                }

                xboxUserService.UpdateXboxUser(xboxUser);
            }

            xboxUserService.Save();
        }
    }
}
