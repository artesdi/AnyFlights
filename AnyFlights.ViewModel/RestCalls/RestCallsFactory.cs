using AnyFlights.Networking;
using AnyFlights.ViewModel.Components;

namespace AnyFlights.ViewModel.RestCalls
{
    public class RestCallsFactory : IRestCallsFactory
    {
        private const string ApiUrl = "http://api.anywayanyday.com/api/";
        private const string SerializeFormat = "&_Serialize=JSON";

        private readonly IWebService _webService;

        public RestCallsFactory(IWebService webService)
        {
            _webService = webService;
        }

        public FaresSearchRequest CreateFaresSearchRequest(FlightsFilter filter)
        {
            var query = string.Format("NewRequest/?Route={0}{1}{2}&AD={3}&CN={4}&CS={5}&Partner=testapic{6}",
                                      filter.DepartureDate.Date.ToString("ddMM"),
                                      filter.DepartureCode,
                                      filter.ArrivalCode,
                                      filter.FullPassengersCount,
                                      filter.ChildPassengersCount,
                                      filter.ServiceClass,
                                      SerializeFormat);

            return new FaresSearchRequest(ApiUrl,
                                          query,
                                          _webService);
        }

        public SearchStateRequest CreateSearchStateRequest(string faresSearchId)
        {
            var query = string.Format("RequestState/?R={0}{1}",
                                      faresSearchId,
                                      SerializeFormat);

            return new SearchStateRequest(ApiUrl,
                                          query,
                                          _webService);
        }

        public FlightsSearchResultRequest CreateFaresSearchResultRequest(string faresSearchId)
        {
            var query = string.Format("Fares/?R={0}&V=Matrix&VB=true&L=ru{1}",
                                      faresSearchId,
                                      SerializeFormat);

            return new FlightsSearchResultRequest(ApiUrl,
                                                  query,
                                                  _webService);
        }
    }
}