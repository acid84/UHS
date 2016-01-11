using Utgiftshantering.ViewModel;

namespace Utgiftshantering.View
{
    /// <summary>
    /// Interaction logic for MainPageView.xaml
    /// </summary>
    public partial class MainPageView
    {
        public MainPageView()
        {
            InitializeComponent();

            DataContext = new MainPageViewModel();

            //TestSetValues();
        }

        private void TestSetValues()
        {
            //List<string> times = new List<string>();
            //times.Add("2010-06-31");
            //times.Add("2010-07-31");
            //times.Add("2010-08-31");
            //times.Add("2010-09-31");
            //times.Add("2010-10-31");
            //times.Add("2010-11-31");
            //times.Add("2010-12-31");

            //graph1.SetXAxisValues(times);

            //graph1.AddGraphLine(new GraphLineEntity("Line 1", Brushes.Green, new List<double>() { 2, 3, 2, 4,3.5 }));
            //graph1.AddGraphLine(new GraphLineEntity("Linje 2", Brushes.Blue, new List<double>() { -2, 4, 2, 2, 4.5,2,5 }));
            //graph1.AddGraphLine(new GraphLineEntity("My line 3", Brushes.Red, new List<double>() { 3, 1, 3, 2.50 }));
            //graph1.AddGraphLine(new GraphLineEntity("L 4", Brushes.Yellow, new List<double>() { 5, 2.5, -3.5 }));
        }
    }
}
