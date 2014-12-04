using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace MassivePixel.Common.Converters
{
    [ContentProperty("Converters")]
    public class ChainingConverter : IValueConverter
    {
        private Collection<IValueConverter> values;

        public Collection<IValueConverter> Converters
        {
            get
            {
                // Defer creating collection until needed
                if (null == values)
                {
                    values = new Collection<IValueConverter>();
                }
                return values;
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var converter in Converters)
            {
                value = converter.Convert(value, targetType, parameter, culture);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var converter in Converters)
            {
                value = converter.ConvertBack(value, targetType, parameter, culture);
            }

            return value;
        }
    }
}