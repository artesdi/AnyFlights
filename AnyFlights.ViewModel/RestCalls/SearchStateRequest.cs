using AnyFlights.Model;
using AnyFlights.Networking;

namespace AnyFlights.ViewModel.RestCalls
{
    public class SearchStateRequest : RestRequest<FaresSearchState>
    {
        public SearchStateRequest(string baseUrl, string queryString, IWebService webService)
            : base(baseUrl, webService)
        {
            QueryString = queryString;
        } 
    }
}