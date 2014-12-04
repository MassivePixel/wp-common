using System.Windows;
using System.Windows.Markup;

namespace MassivePixel.Common.Converters
{
    [ContentProperty("Value")]
    public class EnumValueMapping : DependencyObject
    {
        #region Enum dependency property
        public static readonly DependencyProperty EnumProperty = DependencyProperty.Register(
            "Enum", typeof(string), typeof(EnumValueMapping), new PropertyMetadata(default(string)));

        public string Enum
        {
            get { return (string)GetValue(EnumProperty); }
            set { SetValue(EnumProperty, value); }
        } 
        #endregion

        #region Value dependency property
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(object), typeof(EnumValueMapping), new PropertyMetadata(default(object)));

        public object Value
        {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        } 
        #endregion
    }
}
