using System;
using System.Collections.Generic;
using System.Windows.Navigation;

namespace MassivePixel.Common.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly System.Windows.Navigation.NavigationService navigationService;

        public IEnumerable<JournalEntry> BackStack
        {
            get { return navigationService.BackStack; }
        }

        public bool CanGoBack
        {
            get { return navigationService.CanGoBack; }
        }

        public bool CanGoForward
        {
            get { return navigationService.CanGoForward; }
        }

        public Uri CurrentSource
        {
            get { return navigationService.CurrentSource; }
        }

        public Uri Source
        {
            get { return navigationService.Source; }
            set { navigationService.Source = value; }
        }

        public NavigationService(System.Windows.Navigation.NavigationService navigationService)
        {
            this.navigationService = navigationService;

            navigationService.FragmentNavigation += navigationService_FragmentNavigation;
            navigationService.JournalEntryRemoved += navigationService_JournalEntryRemoved;
            navigationService.Navigated += navigationService_Navigated;
            navigationService.Navigating += navigationService_Navigating;
            navigationService.NavigationFailed += navigationService_NavigationFailed;
            navigationService.NavigationStopped += navigationService_NavigationStopped;
        }

        void navigationService_FragmentNavigation(object sender, FragmentNavigationEventArgs e)
        {
            if (FragmentNavigation != null)
                FragmentNavigation(this, e);
        }

        void navigationService_JournalEntryRemoved(object sender, JournalEntryRemovedEventArgs e)
        {
            if (JournalEntryRemoved != null)
                JournalEntryRemoved(this, e);
        }

        void navigationService_Navigated(object sender, NavigationEventArgs e)
        {
            if (Navigated != null)
                Navigated(this, e);
        }

        void navigationService_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (Navigating != null)
                Navigating(this, e);
        }

        void navigationService_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (NavigationFailed != null)
                NavigationFailed(this, e);
        }

        void navigationService_NavigationStopped(object sender, NavigationEventArgs e)
        {
            if (NavigationStopped != null)
                NavigationStopped(this, e);
        }

        public event FragmentNavigationEventHandler FragmentNavigation;
        public event EventHandler<JournalEntryRemovedEventArgs> JournalEntryRemoved;
        public event NavigatedEventHandler Navigated;
        public event NavigatingCancelEventHandler Navigating;
        public event NavigationFailedEventHandler NavigationFailed;
        public event NavigationStoppedEventHandler NavigationStopped;

        public void GoBack()
        {
            navigationService.GoBack();
        }

        public void GoForward()
        {
            navigationService.GoForward();
        }

        public bool Navigate(Uri source)
        {
            return navigationService.Navigate(source);
        }

        public JournalEntry RemoveBackEntry()
        {
            return navigationService.RemoveBackEntry();
        }

        public void StopLoading()
        {
            navigationService.StopLoading();
        }
    }
}
