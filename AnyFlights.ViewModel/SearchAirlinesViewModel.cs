using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using AnyFlights.Model;
using AnyFlights.ViewModel.Components;
using AnyFlights.ViewModel.Data;
using AnyFlights.ViewModel.Entities;
using AnyFlights.ViewModel.Processes;
using System.Linq;

namespace AnyFlights.ViewModel
{
    public class SearchAirlinesViewModel : ViewModelBase
    {
        private readonly IAsyncServiceExecutor _serviceExecutor;
        private readonly INavigator _navigator;
        private readonly FlightsFilter _filter;
        private readonly FaresSearchProcess _faresSearchProcess;
        private readonly ReadOnlyObservableCollection<AirlineEntity> _airlinesCollection;
        private readonly ObservableCollection<AirlineEntity> _airlinesInternalCollection;

        private ObservableCollection<AirlineEntity> AirlinesInternalCollection
        {
            get { return _airlinesInternalCollection; }
        }

        public IEnumerable<AirlineEntity> AirlinesCollection
        {
            get { return _airlinesCollection; }
        }

        public SearchAirlinesViewModel(
            IAsyncServiceExecutor serviceExecutor,
            INavigator navigator,
            FlightsFilter filter)
        {
            if (serviceExecutor == null) throw new ArgumentNullException("serviceExecutor");
            if (navigator == null) throw new ArgumentNullException("navigator");
            if (filter == null) throw new ArgumentNullException("filter");

            _serviceExecutor = serviceExecutor;
            _navigator = navigator;
            _filter = filter;
            _airlinesInternalCollection = new ObservableCollection<AirlineEntity>();
            _airlinesCollection = new ReadOnlyObservableCollection<AirlineEntity>(_airlinesInternalCollection);
            _faresSearchProcess = new FaresSearchProcess(_serviceExecutor);

            Initialize();
        }

        private void Initialize()
        {
            LoadAirlines();
        }

        private async void LoadAirlines()
        {
            IsBusy = true;

            try
            {
                AirlinesInternalCollection.Clear();
                var fares = await _faresSearchProcess.GetAirlines(_filter);
                fares.ForEach(fare => AirlinesInternalCollection.Add(CastAirlineModel(fare)));
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
                _navigator.GoBack();
            }
            catch (СommunicationException ex)
            {
                MessageBox.Show(ex.Message);
                _navigator.GoBack();
            }
            finally
            {
                IsBusy = false;
            }
        }

        private AirlineEntity CastAirlineModel(Airline fare)
        {
            var faresFull = fare.FaresFull
                .Select(CreateFaresFullEntity)
                .ToList()
                .AsReadOnly();

            var firstFare = fare.FaresFull.First();
            var firstDirection = firstFare.Directions.First();
            var firstSegment = firstDirection.Segments.First();
            var fareIsHasTrips = firstSegment.Trips.Count > 1;

            return new AirlineEntity(fare.Name, faresFull, fareIsHasTrips);
        }

        private FaresFullEntity CreateFaresFullEntity(FaresFull fareFull)
        {
            var firstDirection = fareFull.Directions.First();

            return new FaresFullEntity(
                fareFull.TotalAmount,
                firstDirection.Segments.Count);
        }
    }
}