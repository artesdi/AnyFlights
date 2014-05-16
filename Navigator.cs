using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyFlights.ViewModel;
using Microsoft.Phone.Controls;

namespace AnyFlights
{
    public class Navigator : INavigator
    {
        private readonly PhoneApplicationFrame _rootFrame;

        public Navigator(PhoneApplicationFrame rootFrame)
        {
            if (rootFrame == null) throw new ArgumentNullException("rootFrame");

            _rootFrame = rootFrame;
        }

        public void GoToPage(string pageName, IEnumerable<NavigationParameter> parameters = null)
        {
            if (pageName == null) throw new ArgumentNullException("pageName");

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(pageName);
            if (parameters != null)
            {
                stringBuilder.Append("?");
                foreach (var navigationParameter in parameters)
                {
                    stringBuilder.Append(navigationParameter.Parameter);
                    stringBuilder.Append("=");
                    stringBuilder.Append(Uri.EscapeDataString(navigationParameter.Value));
                    stringBuilder.Append("&");
                }
            }
            _rootFrame.Navigate(new Uri(stringBuilder.ToString(), UriKind.Relative));
        }

        public void CleanNavigationStack()
        {
            while (_rootFrame.BackStack.Any())
            {
                _rootFrame.RemoveBackEntry();
            }
        }

        public void GoBack()
        {
            _rootFrame.GoBack();
        }

        public bool CanGoBack()
        {
            return _rootFrame.CanGoBack;
        }
    }
}