using System;
using System.Collections.Generic;

namespace Utgiftshantering.Entities
{
	[Serializable]
	public class Person
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

		public List<InvoiceRow> InvoiceRow { get; set; }
	}
}
