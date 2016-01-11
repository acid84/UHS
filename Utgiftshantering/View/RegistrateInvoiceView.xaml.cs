using System;
using Utgiftshantering.EventArg;
using Utgiftshantering.Extensions;
using Utgiftshantering.ViewModel;

namespace Utgiftshantering.View
{
	/// <summary>
	/// Interaction logic for RegistreraUtgift.xaml
	/// </summary>
	public partial class RegistrateInvoiceView : IDisposable
	{
		public event EventHandler<InvoiceEventArgs> InvoiceCreated;
		private readonly RegistrateInvoiceViewModel _viewModel;

		public RegistrateInvoiceView(RegistrateInvoiceViewModel viewModel)
		{
			InitializeComponent();

			_viewModel = viewModel;
			DataContext = _viewModel;
			_viewModel.InvoiceSaved += _viewModel_InvoiceSaved;
			datagridComboBoxFöretag.ItemsSource = _viewModel.Companies;
			datagridComboBoxKostnadPo.ItemsSource = _viewModel.AllPeople;
		}

		private void _viewModel_InvoiceSaved(object sender, InvoiceEventArgs e)
		{
			InvoiceCreated.SafeRaise(sender, e);
		}

		public void Dispose()
		{
			_viewModel.InvoiceSaved -= _viewModel_InvoiceSaved;
		}
	}
}
