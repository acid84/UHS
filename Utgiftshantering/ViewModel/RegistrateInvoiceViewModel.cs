using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using Utgiftshantering.Entities;
using System.Windows.Input;
using Utgiftshantering.EventArg;
using Utgiftshantering.Extensions;
using Utgiftshantering.Interfaces;

namespace Utgiftshantering.ViewModel
{
	public class RegistrateInvoiceViewModel : BaseViewModel
	{
		#region Private members
		private readonly IInvoiceDataAccess _invoiceDataAccess;
		private readonly ICompanyDataAccess _companyDataAccess;
		private readonly IPersonDataAccess _personDataAccess;
		#endregion

		#region Commands
		public ICommand ClearCommand { get; set; }
		#endregion

		#region Events
		public event EventHandler<InvoiceEventArgs> InvoiceSaved;
		public event EventHandler Cleared;
		#endregion

		#region Public Properties
		public List<Company> Companies { get; set; }
		public List<Person> AllPeople { get; set; }
		public List<InvoiceRow> Invoices { get; set; }
		public string InvoiceName { get; set; }
		public string InvoiceDate { get; set; }
		#endregion

		#region Construction

		public RegistrateInvoiceViewModel(IInvoiceDataAccess invoiceDataAccess, ICompanyDataAccess companyDataAccess, IPersonDataAccess personDataAccess)
		{
			_invoiceDataAccess = invoiceDataAccess;
			_companyDataAccess = companyDataAccess;
			_personDataAccess = personDataAccess;
			InitializeViewModel();
		}

		private string GetDateTimeNow()
		{
			return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}

		#endregion

		#region Implementation
		public override void Save()
		{
			var invoice = new Invoice {Date = DateTime.Now, InvoiceName = InvoiceName};

			foreach (InvoiceRow row in Invoices)
			{
				invoice.InvoiceRows.Add(row);
			}

			_invoiceDataAccess.SaveInvoice(invoice);
			InvoiceSaved.SafeRaise(this, new InvoiceEventArgs(invoice));

			Clear();
		}

		public void Clear()
		{
			Update();
			Cleared.SafeRaise(this, null);
		}

		public override void Update()
		{
			InitializeViewModel();		
		}

		private void InitializeViewModel()
		{
			InvoiceName = string.Empty;
			InvoiceDate = GetDateTimeNow();
			Invoices = new List<InvoiceRow>();
			RaisePropertyChanged(() => Invoices);
			RaisePropertyChanged(() => InvoiceName);
			RaisePropertyChanged(() => InvoiceDate);

			Companies = new List<Company>();
			_companyDataAccess.LoadAllCompanies().ForEach(Companies.Add);

			AllPeople = new List<Person>();
			_personDataAccess.LoadAllPeople().ForEach(AllPeople.Add);

			SaveCommand = new RelayCommand(Save, () => true);
			ClearCommand = new RelayCommand(Clear, () => true);

			InvoiceDate = GetDateTimeNow();			
		}	
		#endregion
	}
}
