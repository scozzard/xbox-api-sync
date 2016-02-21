using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Scozzard.XboxApiClient;
using Scozzard.XboxApiClient.Model;

namespace Scozzard.XboxApiClient.Client
{
    public class XboxApi : XboxApiClient
    {
        private const string apiResourceUrl = "https://xboxapi.com/v2/";

        // endpoints (https://xboxapi.com/documentation)
        // TODO: add endpoints here

        public virtual xbox_user GetUser(string gamerTag)
        {
            var requestDetails = new RestRequestDetails(HttpMethod.Get, apiResourceUrl + gamerTag + "/profile");

            return GetSingle<xbox_user>(requestDetails);
        }

        public virtual List<xbox_user> GetFriends(string gamerTag)
        {
            var requestDetails = new RestRequestDetails(HttpMethod.Get, apiResourceUrl + gamerTag + "/friends");

            return GetList<xbox_user>(requestDetails);
        }

        public virtual List<recent_activity> GetUserActivity(string gamerTag)
        {
            var requestDetails = new RestRequestDetails(HttpMethod.Get, apiResourceUrl + gamerTag + "/activity/recent");

            return GetList<recent_activity>(requestDetails);
        }
    }
}
