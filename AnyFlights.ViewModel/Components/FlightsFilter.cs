using System;
using System.Collections.Generic;
using System.Globalization;

namespace AnyFlights.ViewModel.Components
{
    public class FlightsFilter
    {
        public DateTime DepartureDate { get; private set; }
        public string DepartureCode { get; private set; }
        public string ArrivalCode { get; private set; }
        public int FullPassengersCount { get; private set; }
        public int ChildPassengersCount { get; private set; }
        public string ServiceClass { get; private set; }

        public FlightsFilter(DateTime departureDate,
                             string departureCode,
                             string arrivalCode,
                             int fullPassengersCount,
                             int childPassengersCount,
                             string serviceClass)
        {
            DepartureDate = departureDate;
            DepartureCode = departureCode;
            ArrivalCode = arrivalCode;
            FullPassengersCount = fullPassengersCount;
            ChildPassengersCount = childPassengersCount;
            ServiceClass = serviceClass;
        }

        public FlightsFilter(IDictionary<string, string> parameters)
        {
            if (parameters == null) throw new ArgumentNullException("parameters");

            string departureDateString;
            string departureCodetring;
            string arrivalCodeString;
            string fullPassengersCountString;
            string childPassengersCountString;
            string serviceClassString;

            parameters.TryGetValue(PropName.DepartureDate, out departureDateString);
            parameters.TryGetValue(PropName.DepartureCode, out departureCodetring);
            parameters.TryGetValue(PropName.ArrivalCode, out arrivalCodeString);
            parameters.TryGetValue(PropName.FullPassengersCount, out fullPassengersCountString);
            parameters.TryGetValue(PropName.ChildPassengersCount, out childPassengersCountString);
            parameters.TryGetValue(PropName.ServiceClass, out serviceClassString);
            
            DepartureDate = Convert.ToDateTime(departureDateString);
            DepartureCode = departureCodetring;
            ArrivalCode = arrivalCodeString;
            FullPassengersCount = Convert.ToInt32(fullPassengersCountString);
            ChildPassengersCount = Convert.ToInt32(childPassengersCountString);
            ServiceClass = serviceClassString;
        }

        public IEnumerable<NavigationParameter> ToParameterList()
        {
            return new List<NavigationParameter>
                {
                    new NavigationParameter(PropName.DepartureDate, DepartureDate.ToString(CultureInfo.InvariantCulture)),
                    new NavigationParameter(PropName.DepartureCode, DepartureCode.ToString(CultureInfo.InvariantCulture)),
                    new NavigationParameter(PropName.ArrivalCode, ArrivalCode.ToString(CultureInfo.InvariantCulture)),
                    new NavigationParameter(PropName.FullPassengersCount, FullPassengersCount.ToString(CultureInfo.InvariantCulture)),
                    new NavigationParameter(PropName.ChildPassengersCount, ChildPassengersCount.ToString(CultureInfo.InvariantCulture)),
                    new NavigationParameter(PropName.ServiceClass, ServiceClass.ToString(CultureInfo.InvariantCulture)),
                };
        }

        private static class PropName
        {
            public const string DepartureDate = "DepartureDate";
            public const string DepartureCode = "DepartureCode";
            public const string ArrivalCode = "ArrivalCode";
            public const string FullPassengersCount = "FullPassengersCount";
            public const string ChildPassengersCount = "ChildPassengersCount";
            public const string ServiceClass = "ServiceClass";
        }
    }
}