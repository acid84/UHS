using System.Windows;
using System.Windows.Controls;

namespace Utgiftshantering.View
{
    /// <summary>
    /// Interaction logic for RegistreraFöretagVy.xaml
    /// </summary>
    public partial class RegistrateCompanyView
    {
    	public RegistrateCompanyView()
        {
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			InitializeTextbox();
		}

        private void textBox1_GotFocus(object sender, RoutedEventArgs e)
        {
        	TextBox txtBox = sender as TextBox;

			if(txtBox != null)
			{
				txtBox.SelectAll();
			}
        }

		private void InitializeTextbox()
		{
			textBox1.Text = "MyCompany";
			textBox1.Focus();
		}
    }
}
