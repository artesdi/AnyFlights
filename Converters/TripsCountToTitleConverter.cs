using System;
using System.Globalization;
using System.Windows.Data;

namespace AnyFlights.Converters
{
    public class TripsCountToTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool) value
                       ? "Тарифы с пересадками"
                       : "Тарифы без пересадок";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}