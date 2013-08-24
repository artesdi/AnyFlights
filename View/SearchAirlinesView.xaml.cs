using System.Windows.Navigation;
using AnyFlights.ViewModel.Components;
using Microsoft.Phone.Controls;

namespace AnyFlights.View
{
    public partial class SearchAirlinesView : PhoneApplicationPage
    {
        public SearchAirlinesView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.NavigationMode != NavigationMode.Back)
            {
                DataContext = ViewModelLocator.GetSearchAirlinesViewModel(new FlightsFilter(NavigationContext.QueryString));
            }
        }
    }
}