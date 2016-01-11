using System;
using System.Collections.Generic;

namespace Utgiftshantering.Entities
{
	[Serializable]
	public partial class Invoice
	{
		public Invoice()
		{
			InvoiceRows = new List<InvoiceRow>();
		}

		public int Id { get; set; }
		public string InvoiceName { get; set; }
		public DateTime Date { get; set; }

		public List<InvoiceRow> InvoiceRows { get; set; }
	}

	#region Override of the partial class for calculation
	public partial class Invoice
	{
		public List<SumPerson> Accountable
		{
			get
			{
				var dictionary = new Dictionary<Person, SumPerson>();

				foreach(InvoiceRow row in InvoiceRows)
				{
					var person = row.Person;

					if (!dictionary.ContainsKey(person))
					{
						dictionary.Add(person, new SumPerson { Name = person.Name });
					}

					dictionary[person].Sum += row.Sum;
				}

				return new List<SumPerson>(dictionary.Values);
			}
		}
	}

	public class SumPerson
	{
		public string Name { get; set; }
		public double Sum { get; set; }
	}
	#endregion
}
