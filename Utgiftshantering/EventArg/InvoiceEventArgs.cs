using System;
using System.Collections.Generic;
using Utgiftshantering.Entities;


namespace Utgiftshantering.EventArg
{
    public class InvoiceEventArgs : EventArgs
    {
		public Invoice Invoice { get; private set; }

		public InvoiceEventArgs(Invoice invoice)
		{
			Invoice = invoice;
		}
    }
}
