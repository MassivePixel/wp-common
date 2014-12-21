using System.Windows;
using MassivePixel.Common;

namespace Common.Tests.DependencyObjectTests
{
    public class InheritedDependencyObject : SampleDependencyObject
    {
        public static readonly DependencyProperty AnotherPropertyProperty =
            From<InheritedDependencyObject>()
                .Register(d => d.AnotherProperty);

        public string AnotherProperty
        {
            get { return (string)GetValue(AnotherPropertyProperty); }
            set { SetValue(AnotherPropertyProperty, value); }
        }
    }
}
