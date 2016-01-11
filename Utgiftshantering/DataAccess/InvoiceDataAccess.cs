using System.Collections.Generic;
using System.Linq;
using Utgiftshantering.Entities;
using Utgiftshantering.Interfaces;

namespace Utgiftshantering.DataAccess
{
	/// <summary>
	/// Data access class for managing your invoices in the repository
	/// </summary>
	public class InvoiceDataAccess : GeneralDataAccess<Invoice>, IInvoiceDataAccess
	{
		#region Private Methods
		/// <summary>
		/// Data access for the invoice rows
		/// </summary>
		private readonly InvoiceRowDataAccess _invoiceRowDataAccess;
		#endregion

		#region Construction
		/// <summary>
		/// Create me!
		/// </summary>
		/// <param name="invoiceRepo">The repository for the Invoice</param>
		/// <param name="invoiceRowRepo">The repository for the InvoiceRows</param>
		public InvoiceDataAccess(IRepository<Invoice> invoiceRepo, IRepository<InvoiceRow> invoiceRowRepo) : base(invoiceRepo)
		{
			_invoiceRowDataAccess = new InvoiceRowDataAccess(invoiceRowRepo);
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Adds a invoice to the repository and saves it
		/// </summary>
		/// <param name="invoice">Your invoice!</param>
		public void SaveInvoice(Invoice invoice)
		{
			_repository.Add(invoice);
			_repository.SaveChanges();
		}

		/// <summary>
		/// Loads a specific invoice
		/// </summary>
		/// <param name="id">Id of the invoice</param>
		/// <returns></returns>
		public Invoice LoadInvoice(int id)
		{
			var invoice = _repository.GetQuery().Where(inv => inv.Id == id).FirstOrDefault();
			return invoice;
		}

		/// <summary>
		/// Loads all the invoices
		/// </summary>
		/// <returns>A list of invoices</returns>
		public List<Invoice> LoadAllInvoices()
		{
			var invoices = _repository.GetAll().ToList();

			foreach (Invoice invoice in invoices)
			{
				// Lazy loading fix.
				_invoiceRowDataAccess.LoadAllRowsForInvoice(invoice.Id);
			}

			return invoices;
		}
		#endregion
	}
}

