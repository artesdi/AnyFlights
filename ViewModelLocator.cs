using AnyFlights.IoC;
using AnyFlights.ViewModel;
using AnyFlights.ViewModel.Components;
using AnyFlights.ViewModel.Data;
using Funq;

namespace AnyFlights
{
    public class ViewModelLocator
    {
        private static Container Container
        {
            get { return ContainerInstance.Current; }
        }

        public static ViewModelBase GetFlightsFilterViewModel()
        {
            return new FlightsFilterViewModel(Container.Resolve<INavigator>());
        }

        public static ViewModelBase GetSearchAirlinesViewModel(FlightsFilter filter)
        {
            return new SearchAirlinesViewModel(
                Container.Resolve<IAsyncServiceExecutor>(),
                Container.Resolve<INavigator>(),
                filter);
        }
    }
}