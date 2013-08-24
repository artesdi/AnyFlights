using AnyFlights.IoC;
using AnyFlights.Networking;
using AnyFlights.ViewModel;
using AnyFlights.ViewModel.Components;
using AnyFlights.ViewModel.Data;
using AnyFlights.ViewModel.RestCalls;
using Funq;

namespace AnyFlights
{
    public class ViewModelLocator
    {
        private static Container Cont
        {
            get { return ContainerInstance.Current; }
        }

        public static ViewModelBase GetFlightsFilterViewModel()
        {
            return new FlightsFilterViewModel(Cont.Resolve<INavigator>());
        }
        public static ViewModelBase GetSearchAirlinesViewModel(FlightsFilter filter)
        {
            return new SearchAirlinesViewModel(new AsyncServiceExecutor(new RestCallsFactory(new WebService())),
                                              Cont.Resolve<INavigator>(),
                                              filter);
        }
    }
}