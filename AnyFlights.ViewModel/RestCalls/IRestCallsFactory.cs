using AnyFlights.ViewModel.Components;

namespace AnyFlights.ViewModel.RestCalls
{
    public interface IRestCallsFactory
    {
        FaresSearchRequest CreateFaresSearchRequest(FlightsFilter filter);
        SearchStateRequest CreateSearchStateRequest(string faresSearchId);
        FlightsSearchResultRequest CreateFaresSearchResultRequest(string faresSearchId);
    }
}