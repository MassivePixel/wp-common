namespace Common.Tests.SampleViews
{
    public partial class ChainingConverterSamplePage 
    {
        public ChainingConverterSamplePage()
        {
            InitializeComponent();

            DataContext = new ChainingConverterSampleViewModel();
        }
    }
}