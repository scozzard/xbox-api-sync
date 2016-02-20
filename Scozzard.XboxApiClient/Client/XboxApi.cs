using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Scozzard.XboxApiClient;
using Scozzard.Model;

namespace Scozzard.XboxApiClient.Client
{
    public class XboxApi : XboxApiClient
    {
        private const string apiResourceUrl = "https://xboxapi.com/v2/";

        // endpoints (https://xboxapi.com/documentation)
        // TODO: add endpoints here

        public virtual XboxUser GetUser(string gamerTag)
        {
            var requestDetails = new RestRequestDetails(HttpMethod.Get, apiResourceUrl + gamerTag + "/profile");

            return GetSingle<XboxUser>(requestDetails);
        }

        public virtual List<XboxUser> GetFriends(string gamerTag)
        {
            var requestDetails = new RestRequestDetails(HttpMethod.Get, apiResourceUrl + gamerTag + "/friends");

            return GetList<XboxUser>(requestDetails);
        }

        public virtual List<Activity> GetUserActivity(string gamerTag)
        {
            var requestDetails = new RestRequestDetails(HttpMethod.Get, apiResourceUrl + gamerTag + "/activity/recent");

            return GetList<Activity>(requestDetails);
        }
    }
}
