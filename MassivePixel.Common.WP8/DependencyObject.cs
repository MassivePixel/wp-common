using System;
using System.Linq.Expressions;
using Expression = System.Windows.Expression;
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
        public class DependencyPropertyHelper<TOwner>
            where TOwner : DependencyObject
        {
            private static DependencyPropertyHelper<TOwner> _default;

            public static DependencyPropertyHelper<TOwner> Default
            {
                get { return _default = _default ?? new DependencyPropertyHelper<TOwner>(); }
            }

            public DependencyProperty Register<TDependencyPropertyType>(
                Expression<Func<TOwner, TDependencyPropertyType>> propertyExpression,
                TDependencyPropertyType defaultValue = default(TDependencyPropertyType))
            {
                return DependencyProperty.Register(
                    Member<TOwner>.Name(propertyExpression),
                    typeof(TDependencyPropertyType),
                    typeof(TOwner),
                    new PropertyMetadata(defaultValue)
                    );
            }

            public DependencyProperty Register<TDependencyPropertyType>(
                Expression<Func<TOwner, TDependencyPropertyType>> propertyExpression,
                Action<TOwner, TDependencyPropertyType, TDependencyPropertyType> callback,
                TDependencyPropertyType defaultValue = default(TDependencyPropertyType))
            {
                return DependencyProperty.Register(
                    Member<TOwner>.Name(propertyExpression),
                    typeof(TDependencyPropertyType),
                    typeof(TOwner),
                    new PropertyMetadata(defaultValue,
                        (o, args) =>
                        {
                            if (callback != null)
                                callback((TOwner)o,
                                    (TDependencyPropertyType)args.OldValue,
                                    (TDependencyPropertyType)args.NewValue);
                        })
                    );
            }
        }

        public static DependencyProperty Register<TDependencyPropertyType>(
            Expression<Func<TDependencyClass, TDependencyPropertyType>> propertyExpression,
            TDependencyPropertyType defaultValue = default(TDependencyPropertyType))
        {
            return From<TDependencyClass>()
                .Register(propertyExpression, defaultValue);
        }

        public static DependencyProperty Register<TDependencyPropertyType>(
            Expression<Func<TDependencyClass, TDependencyPropertyType>> propertyExpression,
            Action<TDependencyClass, TDependencyPropertyType, TDependencyPropertyType> callback,
            TDependencyPropertyType defaultValue = default(TDependencyPropertyType))
        {
            return From<TDependencyClass>()
                .Register(propertyExpression, callback, defaultValue);
        }

        public static DependencyPropertyHelper<TOwnerType> From<TOwnerType>()
            where TOwnerType : DependencyObject
        {
            return DependencyPropertyHelper<TOwnerType>.Default;
        }
    }
}