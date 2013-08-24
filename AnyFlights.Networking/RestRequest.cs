using System;
using System.Threading.Tasks;

namespace AnyFlights.Networking
{
    public abstract class RestRequest<T> where T : new()
    {
        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(40);
        private readonly string _baseUrl;
        private readonly IWebService _webService;
        
        public string Url
        {
            get
            {
                return _baseUrl + QueryString;
            }
        }
        
        protected string QueryString { get; set; }

        protected RestRequest(string baseUrl, IWebService webService)
        {
            if (baseUrl == null) throw new ArgumentNullException("baseUrl");
            if (webService == null) throw new ArgumentNullException("webService");

            _baseUrl = baseUrl;
            _webService = webService;
        }

        public Task<T> Execute()
        {
            return _webService.Get<T>(Url, _timeout);
        }
    }
}