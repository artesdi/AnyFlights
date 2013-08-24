using System;
using System.Windows.Navigation;
using AnyFlights.IoC;
using AnyFlights.Networking;
using AnyFlights.ViewModel;
using AnyFlights.ViewModel.RestCalls;
using AnyFlights.ViewModel.Utils;
using Microsoft.Phone.Controls;

namespace AnyFlights
{
    public class Bootstrapper
    {
        public static void InitApplication(PhoneApplicationFrame rootFrame)
        {
            if (rootFrame == null) throw new ArgumentNullException("rootFrame");

            SmartDispatcher.Initialize();
            RegisterDependencies(rootFrame);
        }


        private static void RegisterDependencies(PhoneApplicationFrame rootFrame)
        {
            var ioc = ContainerInstance.Current;
            ioc.Register<INavigator>(new Navigator(rootFrame));
        } 
    }
}