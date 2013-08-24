using System.Collections.Generic;
using AnyFlights.ViewModel.Components;

namespace AnyFlights.ViewModel
{
    public interface INavigator
    {
        void GoBack();
        bool CanGoBack();
        void GoToPage(string page, IEnumerable<NavigationParameter> parameters = null);
        void CleanNavigationStack();
    }

    public class NavigationParameter
    {
        public string Parameter { get; private set; }
        public string Value { get; private set; }

        public NavigationParameter(string parameter, string value)
        {
            Parameter = parameter;
            Value = value;
        }
    }
}