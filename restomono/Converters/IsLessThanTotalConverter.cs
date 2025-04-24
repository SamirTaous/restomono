using System;
using System.Globalization;
using restomono;

namespace restomono.Converters;

public class IsLessThanTotalConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int current = (int)value;
        int total = AppData.MenuVM.TotalPages;
        return current < total;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
