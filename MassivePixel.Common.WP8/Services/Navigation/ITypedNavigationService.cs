using Microsoft.Phone.Controls;

namespace MassivePixel.Common.Services.Navigation
{
    public interface ITypedNavigationService
    {
        void Navigate<TPage>() where TPage : PhoneApplicationPage;

        void Navigate<TPage, TParam>(TParam param) where TPage : PhoneApplicationPage;

        void Navigate<TPage, TParam1, TParam2>(TParam1 param1, TParam2 param2) where TPage : PhoneApplicationPage;

        void Navigate<TPage, TParam1, TParam2, TParam3>(TParam1 param1, TParam2 param2, TParam3 param3) where TPage : PhoneApplicationPage;
    }
}
