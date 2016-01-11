using System;
using System.Collections.Generic;

namespace Utgiftshantering.Entities
{
	[Serializable]
	public class InvoiceRow
	{
		public int Id { get; set; }
		public int InvoiceId { get; set; }

		public double Sum { get; set; }
		public string Comments { get; set; }

		public Company Company { get; set; }
		public Person Person { get; set; }

		public Invoice Invoice { get; set; }
	}
}
