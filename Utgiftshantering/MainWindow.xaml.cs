using System.Windows;
using Utgiftshantering.View;
using System;
using Utgiftshantering.ViewModel;

namespace Utgiftshantering
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		private readonly MainViewModel _mainViewModel = new MainViewModel();

		public MainWindow()
		{
			InitializeComponent();

			DataContext = _mainViewModel;
			UpdateraStatusBar("UHS started..");
			_buttonHome_Click(this, null);

			var loginView = new LoginView { DataContext = _mainViewModel.LoginViewModel};
			Navigate(loginView);
		}

		private void Navigate(Object obj)
		{
			_frame.Navigate(obj);
		}
		
		private void _buttonHome_Click(object sender, RoutedEventArgs e)
		{
			var view = new MainPageView();
			Navigate(view);
		}

		private void _buttonInspekteraUtgift_Click(object sender, RoutedEventArgs e)
		{
			_mainViewModel.InvoiceViewModel.Update();
			var view = new InvoiceView {DataContext = _mainViewModel.InvoiceViewModel};
			Navigate(view);
		}

		private void _buttonRegistreraFöretag_Click(object sender, RoutedEventArgs e)
		{
			_mainViewModel.RegistrateCompanyViewModel.Update();
			var view = new RegistrateCompanyView {DataContext = _mainViewModel.RegistrateCompanyViewModel};
			Navigate(view);
		}

		private void _buttonRegistreraUtgift_Click(object sender, RoutedEventArgs e)
		{
			_mainViewModel.RegisterInvoiceViewModel.Update();
			var view = new RegistrateInvoiceView(_mainViewModel.RegisterInvoiceViewModel);
			Navigate(view);
		}

		private void UpdateraStatusBar(string text)
		{
			_statusBar.Items.Clear();
			_statusBar.Items.Add(text);
		}

		private void _buttonRegistreraPerson_Click(object sender, RoutedEventArgs e)
		{
			_mainViewModel.RegistratePersonViewModel.Update();
			var personView = new RegistratePersonView {DataContext = _mainViewModel.RegistratePersonViewModel};
			Navigate(personView);
		}
	}
}
