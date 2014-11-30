using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace MassivePixel.Common.Converters
{
    [ContentProperty("Converter")]
    public class ParameterizedConverterWrapper : DependencyObject, IValueConverter
    {
        #region Converter dependency property
        public static readonly DependencyProperty ConverterProperty = DependencyProperty.Register(
            "Converter", typeof(IValueConverter), typeof(ParameterizedConverterWrapper), new PropertyMetadata(default(IValueConverter)));

        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(ConverterProperty); }
            set { SetValue(ConverterProperty, value); }
        }
        #endregion

        #region Parameter dependency property
        public static readonly DependencyProperty ParameterProperty = DependencyProperty.Register(
            "Parameter", typeof(object), typeof(ParameterizedConverterWrapper), new PropertyMetadata(default(object)));

        public object Parameter
        {
            get { return GetValue(ParameterProperty); }
            set { SetValue(ParameterProperty, value); }
        }
        #endregion

        #region DefaultReturnValue dependency property
        public static readonly DependencyProperty DefaultReturnValueProperty = DependencyProperty.Register(
            "DefaultReturnValue", typeof(object), typeof(ParameterizedConverterWrapper), new PropertyMetadata(default(object)));

        public object DefaultReturnValue
        {
            get { return GetValue(DefaultReturnValueProperty); }
            set { SetValue(DefaultReturnValueProperty, value); }
        }
        #endregion

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Converter != null)
                return Converter.Convert(value, targetType, Parameter ?? parameter, culture);
            return DefaultReturnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Converter != null)
                return Converter.ConvertBack(value, targetType, Parameter ?? parameter, culture);
            return DefaultReturnValue;
        }
    }
}
