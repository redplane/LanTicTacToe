using System;
using System.Globalization;
using System.Windows.Data;

namespace ClientLayer.Converters
{
    /// <summary>
    ///     This converter is for converting boolean reversely.
    /// </summary>
    internal class ReverseBooleanConverter : IValueConverter
    {
        /// <summary>
        /// This function is for converting value reversly.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inputValue = (bool) value;

            if (inputValue)
                return false;

            return true;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}