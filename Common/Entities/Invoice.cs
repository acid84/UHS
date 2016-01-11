using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Entities
{
	[DataContract]
	public class Invoice
	{
		//public Invoice()
		//{
		//    InvoiceRows = new List<InvoiceRow>();
		//}

		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string InvoiceName { get; set; }
		
		[DataMember]
		public DateTime Date { get; set; }

		[DataMember]
		public List<InvoiceRow> InvoiceRows { get; set; }
	}
}
