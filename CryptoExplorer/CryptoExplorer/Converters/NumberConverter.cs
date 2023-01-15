using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace CryptoExplorer.Converters
{
    public class NumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? valueString = value as string;

            if (!string.IsNullOrEmpty(valueString))
            {
                valueString = valueString.Substring(valueString.LastIndexOf('.') + 2);
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
