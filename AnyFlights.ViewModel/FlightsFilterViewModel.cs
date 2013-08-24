using System;
using AnyFlights.ViewModel.Commands;
using AnyFlights.ViewModel.Components;

namespace AnyFlights.ViewModel
{
    public class FlightsFilterViewModel : ViewModelBase
    {
        private readonly RelayCommand _flightsSearchCommand;
        private readonly INavigator _navigator;

        private DateTime _departureDate;
        private string _departureCode;
        private string _arrivalCode;
        private string _serviceClass;
        private int _fullPassengersCount;
        private int _childPassengersCount;

        public DateTime DepartureDate
        {
            get { return _departureDate; }
            set
            {
                _departureDate = value;
                OnPropertyChanged("DepartureDate");
                _flightsSearchCommand.RaiseCanExecuteChanged();
            }
        }

        public string DepartureCode
        {
            get { return _departureCode; }
            set
            {
                _departureCode = value;
                OnPropertyChanged("DepartureCode");
                _flightsSearchCommand.RaiseCanExecuteChanged();
            }
        }

        public string ArrivalCode
        {
            get { return _arrivalCode; }
            set
            {
                _arrivalCode = value;
                OnPropertyChanged("ArrivalCode");
                _flightsSearchCommand.RaiseCanExecuteChanged();
            }
        }

        public string ServiceClass
        {
            get { return _serviceClass; }
            set
            {
                _serviceClass = value;
                OnPropertyChanged("ServiceClass");
                _flightsSearchCommand.RaiseCanExecuteChanged();
            }
        }


        public int FullPassengersCount
        {
            get { return _fullPassengersCount; }
            set
            {
                _fullPassengersCount = value;
                OnPropertyChanged("FullPassengersCount");
                _flightsSearchCommand.RaiseCanExecuteChanged();
            }
        }

        public int ChildPassengersCount
        {
            get { return _childPassengersCount; }
            set
            {
                _childPassengersCount = value;
                OnPropertyChanged("ChildPassengersCount");
                _flightsSearchCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand FlightsSearchCommand
        {
            get { return _flightsSearchCommand; }
        }

        public FlightsFilterViewModel(INavigator navigator)
        {
            if (navigator == null) throw new ArgumentNullException("navigator");

            _navigator = navigator;
            _flightsSearchCommand = new RelayCommand(SearchAirlines, ValidateFilter);

            _departureDate = DateTime.Now;
            _departureCode = "MOW";
            _fullPassengersCount = 1;
            _serviceClass = "E";
        }

        private bool ValidateFilter()
        {
            return !string.IsNullOrEmpty(_departureCode) &&
                   !string.IsNullOrEmpty(_arrivalCode) &&
                   !string.IsNullOrEmpty(_serviceClass) &&
                   _fullPassengersCount > 0;
        }

        private void SearchAirlines()
        {
            var filter = new FlightsFilter(departureDate: _departureDate,
                                           departureCode: _departureCode,
                                           arrivalCode: _arrivalCode,
                                           fullPassengersCount: _fullPassengersCount,
                                           childPassengersCount: _childPassengersCount,
                                           serviceClass: _serviceClass);

            _navigator.GoToPage(Pages.AirlinesPage, filter.ToParameterList());
        }
    }
}