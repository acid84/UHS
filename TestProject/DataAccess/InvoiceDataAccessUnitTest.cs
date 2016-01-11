using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Utgiftshantering.DataAccess;
using Utgiftshantering.Entities;
using Utgiftshantering.Interfaces;
using TestProject.Helpers;

namespace TestProject.DataAccess
{
	[TestClass]
	public class InvoiceDataAccessUnitTest
	{
		[TestMethod]
		public void TestSaveInvoice()
		{
			Invoice invoice = InvoiceHelper.CreateInvoices(1, 5)[0];

			var mock = new Mock<IRepository<Invoice>>();
			mock.Setup(repo => repo.SaveChanges());
			mock.Setup(repo => repo.GetQuery()).Returns(new List<Invoice> { invoice }.AsQueryable);

			var invoiceDataAccess = new InvoiceDataAccess(mock.Object, null);

			invoiceDataAccess.SaveInvoice(invoice);

			Invoice repoInvoice = invoiceDataAccess.LoadInvoice(invoice.Id);
			InvoiceHelper.ValidateInvoice(invoice, repoInvoice);
		}

		[TestMethod]
		public void TestSaveMultipleInvoice()
		{
			List<Invoice> invoices = InvoiceHelper.CreateInvoices(150, 35);

			var mock = new Mock<IRepository<Invoice>>();
			mock.Setup(repo => repo.SaveChanges());
			mock.Setup(repo => repo.GetQuery()).Returns(invoices.AsQueryable);

			var invoiceDataAccess = new InvoiceDataAccess(mock.Object, null);

			invoices.ForEach(invoiceDataAccess.SaveInvoice);
			invoices.ForEach(i =>
			                    {
									Invoice repoInvoice = invoiceDataAccess.LoadInvoice(i.Id);
									InvoiceHelper.ValidateInvoice(i, repoInvoice);
			                    });
		}

		[TestMethod]
		public void LoadAllInvoices()
		{
			const int nbrOfInvoice = 150;
			List<Invoice> invoices = InvoiceHelper.CreateInvoices(nbrOfInvoice, 35);

			var mock = new Mock<IRepository<Invoice>>();
			mock.Setup(repo => repo.SaveChanges());
			mock.Setup(repo => repo.GetAll()).Returns(invoices.AsQueryable);

			var mockInvoiceRows = new Mock<IRepository<InvoiceRow>>();

			var invoiceDataAccess = new InvoiceDataAccess(mock.Object, mockInvoiceRows.Object);

			invoices.ForEach(invoiceDataAccess.SaveInvoice);

			List<Invoice> repoInvoices = invoiceDataAccess.LoadAllInvoices();

			Assert.AreEqual(nbrOfInvoice, repoInvoices.Count);
			
			invoices.ForEach(source =>
			                 	{
			                 		Invoice inv = repoInvoices.Find(i => i.Id == source.Id);
									InvoiceHelper.ValidateInvoice(source, inv);
			                 		repoInvoices.Remove(inv);
			                 	});

			Assert.AreEqual(0, repoInvoices.Count);
		}

		[TestMethod]
		public void LoadAllInvoicesWhenEmpty()
		{
			var mock = new Mock<IRepository<Invoice>>();
			mock.Setup(repo => repo.SaveChanges());

			var invoiceDataAccess = new InvoiceDataAccess(mock.Object, null);
			
			List<Invoice> repoInvoices = invoiceDataAccess.LoadAllInvoices();
			Assert.AreEqual(0, repoInvoices.Count);
		}

		#region Help Methods
		
		#endregion
	}
}
