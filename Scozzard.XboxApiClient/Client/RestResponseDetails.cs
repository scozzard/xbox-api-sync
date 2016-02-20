using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Scozzard.XboxApiClient.Client.Interfaces;

namespace Scozzard.XboxApiClient.Client
{
    public class RestResponseDetails : IRestResponseDetails
    {
        public IRestRequestDetails RequestDetails { get; private set; }
        public HttpRequestMessage RequestMessage { get; private set; }
        public HttpResponseMessage ResponseMessage { get; private set; }
        public string ResponseContent { get; private set; }

        public RestResponseDetails(IRestRequestDetails requestDetails, HttpRequestMessage requestMessage, HttpResponseMessage responseMessage, string responseContent)
        {
            RequestDetails = requestDetails;
            RequestMessage = requestMessage;
            ResponseMessage = responseMessage;
            ResponseContent = ResponseContent;
        }
    }
}
