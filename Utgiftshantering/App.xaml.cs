using System.IO;
using System.Windows;

namespace Utgiftshantering
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		public App()
		{
			this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
		}

		void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
		{
			using(var writer = new StreamWriter("errorLog.txt"))
			{
				writer.Write(e.Exception.ToString());
			}

			MessageBox.Show(e.Exception.ToString());
		}
    }
}
