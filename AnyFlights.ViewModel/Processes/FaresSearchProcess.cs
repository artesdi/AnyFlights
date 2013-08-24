using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AnyFlights.Model;
using AnyFlights.ViewModel.Components;
using AnyFlights.ViewModel.Data;

namespace AnyFlights.ViewModel.Processes
{
    public class FaresSearchProcess
    {
        private const string SearchCompleteCode = "100";
        private const int TimeoutBetweenRequest = 500;

        private readonly IAsyncServiceExecutor _serviceExecutor;

        public FaresSearchProcess(IAsyncServiceExecutor serviceExecutor)
        {
            if (serviceExecutor == null) throw new ArgumentNullException("serviceExecutor");

            _serviceExecutor = serviceExecutor;
        }

        public async Task<List<Airline>> GetAirlines(FlightsFilter filter)
        {
            var searchId = await _serviceExecutor.FaresSearchAsync(filter);
            if (searchId.Error != null)
            {
                throw new BusinessException(searchId.Error);
            }

            FaresSearchState searchState = null;
            var requestIndex = 0;
            while (searchState == null ||
                   searchState.Completed != SearchCompleteCode)
            {
                Thread.Sleep(TimeoutBetweenRequest);
                searchState = await _serviceExecutor.GetFaresSearchStateAsync(searchId.Id);
                if (searchState.Error != null)
                {
                    throw new BusinessException(searchState.Error);
                }
                if (requestIndex >= 40000/TimeoutBetweenRequest)
                {
                    throw new СommunicationException("Нет ответа, повторите попытку");
                }
                requestIndex++;
            }

            var resultFares = await _serviceExecutor.GetFaresSearchResultAsync(searchId.Id);
            if (resultFares.Error != null)
            {
                throw new BusinessException(resultFares.Error);
            }

            return resultFares.Airlines;
        }
    }
}