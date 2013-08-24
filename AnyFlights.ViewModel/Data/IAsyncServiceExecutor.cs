using System.Threading.Tasks;
using AnyFlights.Model;
using AnyFlights.ViewModel.Components;

namespace AnyFlights.ViewModel.Data
{
    public interface IAsyncServiceExecutor
    {
        Task<FaresSearchId> FaresSearchAsync(FlightsFilter filter);

        Task<FaresSearchState> GetFaresSearchStateAsync(string faresSearchId);

        Task<FlightsFull> GetFaresSearchResultAsync(string faresSearchId);
    }
}