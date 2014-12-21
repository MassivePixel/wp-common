using System.Windows;
using MassivePixel.Common;

namespace Common.Tests.DependencyObjectTests
{
    public class SampleDependencyObject : DependencyObject<SampleDependencyObject>
    {
        public static readonly DependencyProperty SampleProperty = Register(d => d.Sample);

        public object Sample
        {
            get { return GetValue(SampleProperty); }
            set { SetValue(SampleProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = Register(d => d.Text,
            (d, oldValue, newValue) => d.TextChanged(oldValue, newValue));

        private void TextChanged(string oldValue, string newValue)
        {
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}
