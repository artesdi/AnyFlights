using System;
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

        public ReadOnlyObservableCollection<AirlineEntity> AirlinesCollection
        {
            get { return _airlinesCollection; }
        }

        public SearchAirlinesViewModel(IAsyncServiceExecutor serviceExecutor,
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

        private static AirlineEntity CastAirlineModel(Airline fare)
        {
            return new AirlineEntity(fare.Name,
                                     fare.FaresFull.Select(fareFull => new FaresFullEntity(fareFull.TotalAmount,
                                                                                           fareFull.Directions.First().Segments.Count))
                                         .ToList()
                                         .AsReadOnly(),
                                     fare.FaresFull.First().Directions.First().Segments.First().Trips.Count > 1);
        }
    }
}