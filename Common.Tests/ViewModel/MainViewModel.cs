using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace Common.Tests.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public List<SampleItem> Samples { get; private set; }

        public MainViewModel()
        {
            this.Samples = new List<SampleItem>
            {
                new SampleItem("IsVisible", "IsVisibleSampleView"),
                new SampleItem("Chaining converter", "ChainingConverterSampleView"),
            };
        }
    }
}