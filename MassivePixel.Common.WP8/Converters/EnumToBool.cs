using System;
using System.Globalization;
using System.Windows.Data;

namespace MassivePixel.Common.Converters
{
    public class EnumToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            return value.ToString().Equals(parameter as string, StringComparison.InvariantCultureIgnoreCase);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumValues = Enum.GetValues(targetType);

            foreach (var enumValue in enumValues)
            {
                if (enumValue.ToString().Equals(parameter as string, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (value is bool && (bool)value)
                        return enumValue;
                }
            }

            return null;
        }
    }
}
