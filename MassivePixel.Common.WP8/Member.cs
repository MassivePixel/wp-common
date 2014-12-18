using System;
using System.Linq.Expressions;

namespace MassivePixel.Common
{
    public static class Member<TClass>
    {
        public static string Name<TReturn>(Expression<Func<TClass, TReturn>> propertySelector)
        {
            if (propertySelector == null)
                throw new ArgumentNullException("propertySelector");

            var memberExpression = propertySelector.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("Parameter must be MemberExpression", "propertySelector");

            return memberExpression.Member.Name;
        }
    }


    public static class Member
    {
        public static string Name<T>(Expression<Func<T>> propertySelector)
        {
            if (propertySelector == null)
                throw new ArgumentNullException("propertySelector");

            var memberExpression = propertySelector.Body as MemberExpression;
            if (memberExpression != null)
                return memberExpression.Member.Name;

            var newExpression = propertySelector.Body as NewExpression;
            if (newExpression != null)
                return newExpression.Type.Name;

            throw new ArgumentException("Parameter must be MemberExpression", "propertySelector");
        }
    }
}
