namespace MassivePixel.Common.Services.Navigation
{
    /// <summary>
    /// Defines a method called after navigating to the page.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INavigateable<in T>
    {
        void Accept(T param);
    }

    /// <summary>
    /// Defines a method called after navigating to the page.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public interface INavigateable<in T1, in T2>
    {
        void Accept(T1 param1, T2 param2);
    }

    /// <summary>
    /// Defines a method called after navigating to the page.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public interface INavigateable<in T1, in T2, in T3>
    {
        void Accept(T1 param1, T2 param2, T3 param3);
    }
}
