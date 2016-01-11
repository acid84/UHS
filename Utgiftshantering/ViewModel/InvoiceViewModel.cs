using System.Collections.Generic;
using Utgiftshantering.Entities;
using Utgiftshantering.Interfaces;

namespace Utgiftshantering.ViewModel
{
	public class InvoiceViewModel : BaseViewModel
	{
		private readonly IInvoiceDataAccess _invoiceDataAccess;
		public List<Invoice> Invoices { get; set; }
		
		public InvoiceViewModel(IInvoiceDataAccess invoiceDataAccess)
		{
			_invoiceDataAccess = invoiceDataAccess;
			Invoices = _invoiceDataAccess.LoadAllInvoices();
		}

		public override void Update()
		{
			Invoices = _invoiceDataAccess.LoadAllInvoices();
		}
	}
}
