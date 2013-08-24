using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AnyFlights.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var invert = parameter as string;

            return invert == "Invert"
                       ? ((bool)value) ? Visibility.Collapsed : Visibility.Visible
                       : ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}