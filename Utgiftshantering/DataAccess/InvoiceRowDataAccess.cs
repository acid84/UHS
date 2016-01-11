using System.Linq;
using Utgiftshantering.Entities;
using Utgiftshantering.Interfaces;

namespace Utgiftshantering.DataAccess
{
	/// <summary>
	/// Data Access for working against the invoice rows.
	/// </summary>
	public class InvoiceRowDataAccess : GeneralDataAccess<InvoiceRow>
	{
		#region Construction
		/// <summary>
		/// Create me!
		/// </summary>
		/// <param name="repo">The repository you want me to work against</param>
		public InvoiceRowDataAccess(IRepository<InvoiceRow> repo) : base(repo) { }
		#endregion

		#region Public Methods
		/// <summary>
		/// Loads all the rows for a invoice. This method is called for if LazyLoading is used.
		/// </summary>
		/// <param name="invoiceId"></param>
		public void LoadAllRowsForInvoice(int invoiceId)
		{
			// Method used for lazy loading usage.
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
			_repository.GetQuery().Where(i => i.InvoiceId == invoiceId).ToList();
// ReSharper restore ReturnValueOfPureMethodIsNotUsed

		}
		#endregion
	}
}
