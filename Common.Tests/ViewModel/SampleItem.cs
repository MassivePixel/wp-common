using System;
using GalaSoft.MvvmLight.Command;

namespace Common.Tests.ViewModel
{
    public struct SampleItem
    {
        public string Name { get; private set; }
        public Uri Uri { get; private set; }

        public RelayCommand GoToPageCommand { get; set; }

        public SampleItem(string name, string viewName)
            : this()
        {
            this.Name = name;
            this.Uri = new Uri(string.Format("/SampleViews/{0}.xaml", viewName), UriKind.Relative);

            this.GoToPageCommand = new RelayCommand(GoToPage);
        }

        private void GoToPage()
        {
            App.RootFrame.Navigate(Uri);
        }
    }
}
