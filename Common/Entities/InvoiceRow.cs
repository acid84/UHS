using System.Runtime.Serialization;

namespace Common.Entities
{
	[DataContract]
	public class InvoiceRow
	{
		[DataMember]
		public int Id { get; set; }
		
		[DataMember]
		public int InvoiceId { get; set; }

		[DataMember]
		public double Sum { get; set; }

		[DataMember]
		public string Comments { get; set; }

		[DataMember]
		public Company Company { get; set; }

		[DataMember]
		public Person Person { get; set; }

		[DataMember]
		public Invoice Invoice { get; set; }
	}
}
