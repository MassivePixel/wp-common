using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MassivePixel.Common.Converters
{
    public class BooleanToObjectConverter : DependencyObject, IValueConverter
    {
        #region TrueValue dependency property
        public static readonly DependencyProperty TrueValueProperty = DependencyProperty.Register(
            "TrueValue", typeof(object), typeof(BooleanToObjectConverter), new PropertyMetadata(default(object)));

        public object TrueValue
        {
            get { return GetValue(TrueValueProperty); }
            set { SetValue(TrueValueProperty, value); }
        }
        #endregion

        #region FalseValue dependency property
        public static readonly DependencyProperty FalseValueProperty = DependencyProperty.Register(
            "FalseValue", typeof(object), typeof(BooleanToObjectConverter), new PropertyMetadata(default(object)));

        public object FalseValue
        {
            get { return GetValue(FalseValueProperty); }
            set { SetValue(FalseValueProperty, value); }
        }
        #endregion

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool && (bool)value
                ? TrueValue
                : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
