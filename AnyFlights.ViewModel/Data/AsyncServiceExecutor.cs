using System;
using System.Threading.Tasks;
using AnyFlights.Model;
using AnyFlights.ViewModel.Components;
using AnyFlights.ViewModel.RestCalls;

namespace AnyFlights.ViewModel.Data
{
    public class AsyncServiceExecutor : IAsyncServiceExecutor
    {
        private readonly IRestCallsFactory _restCallsFactory;

        public AsyncServiceExecutor(IRestCallsFactory restCallsFactory)
        {
            if (restCallsFactory == null) throw new ArgumentNullException("restCallsFactory");

            _restCallsFactory = restCallsFactory;
        }
        
        public async Task<FaresSearchId> FaresSearchAsync(FlightsFilter filter)
        {
            return await _restCallsFactory.CreateFaresSearchRequest(filter).Execute();
        }

        public async Task<FaresSearchState> GetFaresSearchStateAsync(string faresSearchId)
        {
            return await _restCallsFactory.CreateSearchStateRequest(faresSearchId).Execute();
        }

        public async Task<FlightsFull> GetFaresSearchResultAsync(string faresSearchId)
        {
            return await _restCallsFactory.CreateFaresSearchResultRequest(faresSearchId).Execute();
        }
    }
}