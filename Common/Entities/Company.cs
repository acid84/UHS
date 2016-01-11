using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Entities
{
	[DataContract]
	public class Company
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public List<InvoiceRow> InvoiceRow { get; set; }
	}
}
