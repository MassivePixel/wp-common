using System;
using System.Linq.Expressions;

#if WINRT
using Windows.UI.Xaml;
#else
using System.Windows;
#endif

namespace MassivePixel.Common
{
    public class DependencyObject<TDependencyClass> : DependencyObject
        where TDependencyClass : DependencyObject
    {
        public static DependencyProperty Register<TDependencyPropertyType>(
            Expression<Func<TDependencyClass, TDependencyPropertyType>> propertyExpression,
            TDependencyPropertyType defaultValue = default(TDependencyPropertyType))
        {
            return DependencyProperty.Register(
                Member<TDependencyClass>.Name(propertyExpression),
                typeof(TDependencyPropertyType),
                typeof(TDependencyClass),
                new PropertyMetadata(defaultValue)
                );
        }

        public static DependencyProperty Register<TDependencyPropertyType>(
            Expression<Func<TDependencyClass, TDependencyPropertyType>> propertyExpression,
            Action<TDependencyClass, TDependencyPropertyType, TDependencyPropertyType> callback,
            TDependencyPropertyType defaultValue = default(TDependencyPropertyType))
        {
            return DependencyProperty.Register(
                Member<TDependencyClass>.Name(propertyExpression),
                typeof(TDependencyPropertyType),
                typeof(TDependencyClass),
                new PropertyMetadata(defaultValue,
                    (o, args) =>
                    {
                        if (callback != null)
                            callback((TDependencyClass)o,
                                (TDependencyPropertyType)args.OldValue,
                                (TDependencyPropertyType)args.NewValue);
                    })
                );
        }
    }
}
