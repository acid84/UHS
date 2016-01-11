using System.Collections.Generic;
using Utgiftshantering.Entities;

namespace Utgiftshantering.Interfaces
{
	public interface IInvoiceDataAccess
	{
		/// <summary>
		/// Adds a invoice to the repository and saves it
		/// </summary>
		/// <param name="invoice">Your invoice!</param>
		void SaveInvoice(Invoice invoice);

		/// <summary>
		/// Loads a specific invoice
		/// </summary>
		/// <param name="id">Id of the invoice</param>
		/// <returns></returns>
		Invoice LoadInvoice(int id);

		/// <summary>
		/// Loads all the invoices
		/// </summary>
		/// <returns>A list of invoices</returns>
		List<Invoice> LoadAllInvoices();
	}
}