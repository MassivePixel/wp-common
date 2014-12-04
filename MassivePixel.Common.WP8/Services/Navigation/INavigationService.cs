using System;
using System.Collections.Generic;
using System.Windows.Navigation;

namespace MassivePixel.Common.Services.Navigation
{
    interface INavigationService
    {
        IEnumerable<JournalEntry> BackStack { get; }
        bool CanGoBack { get; }
        bool CanGoForward { get; }
        Uri CurrentSource { get; }
        Uri Source { get; set; }

        event FragmentNavigationEventHandler FragmentNavigation;
        event EventHandler<JournalEntryRemovedEventArgs> JournalEntryRemoved;
        event NavigatedEventHandler Navigated;
        event NavigatingCancelEventHandler Navigating;
        event NavigationFailedEventHandler NavigationFailed;
        event NavigationStoppedEventHandler NavigationStopped;

        void GoBack();
        void GoForward();
        bool Navigate(Uri source);
        JournalEntry RemoveBackEntry();
        void StopLoading();
    }
}
