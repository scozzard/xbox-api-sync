using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Scozzard.XboxApiClient.Client.Interfaces
{
    public interface IRestResponseDetails
    {
        IRestRequestDetails RequestDetails { get; }
        HttpRequestMessage RequestMessage { get; }
        HttpResponseMessage ResponseMessage { get; }
        string ResponseContent { get; }
    }
}
