using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Common.Tests.SampleViews
{
    public class IsVisibleSampleViewModel : ViewModelBase
    {
        private bool isVisible;

        public bool IsVisible
        {
            get { return isVisible; }
            set { Set(ref isVisible, value); }
        }

        public RelayCommand ToggleVisibleCommand { get; set; }

        public IsVisibleSampleViewModel()
        {
            this.IsVisible = true;
            this.ToggleVisibleCommand = new RelayCommand(
                () => IsVisible = !IsVisible);
        }
    }
}
