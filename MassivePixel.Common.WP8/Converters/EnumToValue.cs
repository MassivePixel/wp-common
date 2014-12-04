using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace MassivePixel.Common.Converters
{
    [ContentProperty("Mappings")]
    public class EnumToValue : DependencyObject, IValueConverter
    {
        #region Mappings
        public static readonly DependencyProperty MappingsProperty = DependencyProperty.Register(
            "Mappings", typeof(List<EnumValueMapping>), typeof(EnumToValue), new PropertyMetadata(new List<EnumValueMapping>()));

        public List<EnumValueMapping> Mappings
        {
            get { return (List<EnumValueMapping>)GetValue(MappingsProperty); }
            set { SetValue(MappingsProperty, value); }
        }
        #endregion

        #region DefaultReturnValue
        public static readonly DependencyProperty DefaultReturnValueProperty = DependencyProperty.Register(
            "DefaultReturnValue", typeof(object), typeof(EnumToValue), new PropertyMetadata(default(object)));

        public object DefaultReturnValue
        {
            get { return GetValue(DefaultReturnValueProperty); }
            set { SetValue(DefaultReturnValueProperty, value); }
        }
        #endregion

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return DefaultReturnValue;

            foreach (var mapping in Mappings)
            {
                if (mapping.Enum == value.ToString())
                    return mapping.Value;
            }

            return DefaultReturnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
