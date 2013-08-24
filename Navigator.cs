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

            var sb = new StringBuilder();
            sb.Append(pageName);
            if (parameters != null)
            {
                sb.Append("?");
                foreach (var navigationParameter in parameters)
                {
                    sb.Append(navigationParameter.Parameter);
                    sb.Append("=");
                    sb.Append(Uri.EscapeDataString(navigationParameter.Value));
                    sb.Append("&");
                }
            }
            _rootFrame.Navigate(new Uri(sb.ToString(), UriKind.Relative));
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