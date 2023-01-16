using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace CryptoExplorer.Converters
{
    //CryptoExplorer.Converters.NumberConverter
    public class NumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? valueString = value as string;

            if (!string.IsNullOrEmpty(valueString))
            {
                valueString = valueString.Substring(0, valueString.LastIndexOf('.') + 3);
            }
            else
            {
                valueString = string.Empty;
            }

            return valueString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
