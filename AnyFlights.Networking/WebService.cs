using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnyFlights.Networking
{
    public class WebService : IWebService
    {
        private readonly JsonDeserializer _deserializer = new JsonDeserializer();

        public async Task<T> Get<T>(string url, TimeSpan timeout, bool usingNetworkStackCache = false) where T : new()
        {
            if (!usingNetworkStackCache)
            {
                UniqableQuery(ref url);
            }

            using (var handler = new HttpClientHandler())
            {
                using (var httpClient = new HttpClient(handler))
                {
                    httpClient.Timeout = timeout;
                   
                    var request = new HttpRequestMessage(HttpMethod.Get, url);                    
                    if (handler.SupportsTransferEncodingChunked())
                    {
                        request.Headers.TransferEncodingChunked = true;
                    }

                    HttpResponseMessage response = await httpClient.SendAsync(request);

                    var stringResponse = await response.Content.ReadAsStringAsync();

                    return _deserializer.Deserialize<T>(stringResponse);
                }
            }
        }

        private void UniqableQuery(ref string ulr)
        {
            ulr += string.Format("&QueryGuid={0}", Guid.NewGuid());
        }
    }
}