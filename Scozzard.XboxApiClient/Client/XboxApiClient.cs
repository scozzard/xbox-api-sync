using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Polly;

namespace Scozzard.XboxApiClient.Client
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class XboxApiClient
    {
        public XboxApiClient()
        {
        }

        public T GetSingle<T>(RestRequestDetails requestDetails) where T : new()
        {
            var result = ExecuteAsync<T>(requestDetails).Result;

            return result;
        }

        public List<T> GetList<T>(RestRequestDetails requestDetails) where T : new()
        {
            var result = ExecuteAsync<List<T>>(requestDetails).Result;

            return result ?? new List<T>();
        }

        public async Task<T> ExecuteAsync<T>(RestRequestDetails requestDetails) where T : new()
        {
            var policy = Policy.Handle<Exception>().RetryAsync();

            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = null;

            return await policy.ExecuteAsync(() =>
            {
                var requestMessage = requestDetails.ToHttpRequestMessage();

                // move to config
                requestMessage.Headers.Add("X-AUTH", "fa0b97bb037d0decef75cf9c9693ffb5d5878118");

                httpResponseMessage = client.SendAsync(requestMessage).Result;
                var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;

                return httpResponseMessage.Content.ReadAsAsync<T>(new MediaTypeFormatter[]
                    { CreateMediaTypeFormatter() });

            }).ConfigureAwait(false);
        }

        private JsonMediaTypeFormatter CreateMediaTypeFormatter()
        {
            var mediaTypeFormatterForRequest = new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Include
                }
            };

            return mediaTypeFormatterForRequest;
        }
    }
}
