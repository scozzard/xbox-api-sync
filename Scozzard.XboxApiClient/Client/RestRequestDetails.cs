using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Scozzard.XboxApiClient.Client.Interfaces;

namespace Scozzard.XboxApiClient.Client
{
    public class RestRequestDetails : IRestRequestDetails
    {
        public HttpMethod Method { get; protected set; }
        public string ResourceUrl { get; protected set; }

        public RestRequestDetails(HttpMethod method, string resourceUrl)
        {
            if (string.IsNullOrEmpty(resourceUrl))
            {
                throw new ArgumentNullException("resourceUrl");
            }

            Method = method;
            ResourceUrl = resourceUrl;
        }

        public HttpRequestMessage ToHttpRequestMessage()
        {
            return new HttpRequestMessage(Method, ResourceUrl);
        }
    }
}
