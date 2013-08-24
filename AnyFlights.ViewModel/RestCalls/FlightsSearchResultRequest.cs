using AnyFlights.Model;
using AnyFlights.Networking;

namespace AnyFlights.ViewModel.RestCalls
{
    public class FlightsSearchResultRequest : RestRequest<FlightsFull>
    {
        public FlightsSearchResultRequest(string baseUrl, string queryString, IWebService webService)
            : base(baseUrl, webService)
        {
            QueryString = queryString;
        }
    }
}