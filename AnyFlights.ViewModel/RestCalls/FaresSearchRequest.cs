using AnyFlights.Model;
using AnyFlights.Networking;

namespace AnyFlights.ViewModel.RestCalls
{
    public class FaresSearchRequest : RestRequest<FaresSearchId>
    {
        public FaresSearchRequest(string baseUrl, string queryString, IWebService webService)
            : base(baseUrl, webService)
        {
            QueryString = queryString;
        } 
    }
}