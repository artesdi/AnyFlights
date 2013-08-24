using Microsoft.Phone.Controls;

namespace AnyFlights.View
{
    public partial class FlightsFilterView : PhoneApplicationPage
    {
        public FlightsFilterView()
        {
            InitializeComponent();
            DataContext = ViewModelLocator.GetFlightsFilterViewModel();
        }
    }
}