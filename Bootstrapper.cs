using System;
using AnyFlights.IoC;
using AnyFlights.Networking;
using AnyFlights.ViewModel;
using AnyFlights.ViewModel.Data;
using AnyFlights.ViewModel.RestCalls;
using Funq;
using Microsoft.Phone.Controls;

namespace AnyFlights
{
    public class Bootstrapper
    {
        public static void InitializeApplication(PhoneApplicationFrame rootFrame)
        {
            if (rootFrame == null) throw new ArgumentNullException("rootFrame");

            var container = ContainerInstance.Current;

            RegisterNavigationService(container, rootFrame);
            RegisterWebService(container);
            RegisterFactories(container);
            RegisterAsyncExecutor(container);
        }

        private static void RegisterNavigationService(Container container, PhoneApplicationFrame rootFrame)
        {
            container.Register<INavigator>(new Navigator(rootFrame));
        }

        private static void RegisterWebService(Container container)
        {
            container.Register<IWebService>(new WebService());
        }

        private static void RegisterFactories(Container container)
        {
            container.Register<IRestCallsFactory>(
                new RestCallsFactory(container.Resolve<IWebService>()));
        }

        private static void RegisterAsyncExecutor(Container container)
        {
            container.Register<IAsyncServiceExecutor>(
                new AsyncServiceExecutor(container.Resolve<IRestCallsFactory>()));
        }
    }
}