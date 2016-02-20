using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Scozzard.XboxApiClient.Client.Interfaces
{
    public interface IRestRequestDetails
    {
        HttpMethod Method { get; }
        string ResourceUrl { get; }
    }
}
