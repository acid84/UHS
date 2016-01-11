using System.Data.Objects;
using Utgiftshantering.Entities;

namespace Utgiftshantering.ObjectContext
{
	public class UHSContext : System.Data.Objects.ObjectContext
	{
		#region ObjectSets
		private readonly ObjectSet<Person> _persons;
		private readonly ObjectSet<Company> _companies;
		private readonly ObjectSet<InvoiceRow> _invoiceRows;
		private readonly ObjectSet<Invoice> _invoices;
		#endregion

		#region Construction
		public UHSContext(): base("name=UHSEntities", "UHSEntities")
		{
            _persons = CreateObjectSet<Person>();
			_companies = CreateObjectSet<Company>();
			_invoiceRows = CreateObjectSet<InvoiceRow>();
			_invoices = CreateObjectSet<Invoice>();
        }
		#endregion

		#region Propeties
		public ObjectSet<Person> Persons
        {
            get { return _persons; }
        }

		public ObjectSet<Company> Companies
		{
			get { return _companies; }
		}

		public ObjectSet<Invoice> Invoices
		{
			get { return _invoices; }
		}

		public ObjectSet<InvoiceRow> InvoiceRows
		{
			get { return _invoiceRows; }
		}
		#endregion
    }
}
