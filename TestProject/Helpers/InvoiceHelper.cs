using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utgiftshantering.Entities;

namespace TestProject.Helpers
{
	public static class InvoiceHelper
	{
		public static List<Invoice> CreateInvoices(int nbrOfInvoices, int nbrOfRows)
		{
			var invoices = new List<Invoice>();

			//var companyMock = new Mock<IRepository<Company>>();
			//var personMock = new Mock<IRepository<.Person>>();

			//var compAccess = new CompanyDataAccess(companyMock.Object);
			//var persAccess = new PersonDataAccess(personMock.Object);

			for (int i = 1; i <= nbrOfInvoices; i++)
			{
				var invoice = new Invoice { Date = DateTime.Now, InvoiceName = "Invoice " + i, Id = i };

				for (int i2 = 1; i2 <= nbrOfRows; i2++)
				{
					//Company company = new Company { CompanyName = "Company " + i2};
					//compAccess.SaveCompany(company);

					//Person person = new Person { Name = "Person " + i2 };
					//persAccess.SavePerson(person);

					invoice.InvoiceRows.Add(new InvoiceRow
					{
						Id = i2,
						Sum = i2 * i,
						Comments = "Comment " + i2
						//PersonEntity = person,
						//CompanyEntity = company,
					});
				}

				invoices.Add(invoice);
			}

			return invoices;
		}

		public static void ValidateInvoice(Invoice source, Invoice repository)
		{
			Assert.IsNotNull(repository);
			Assert.AreEqual(source.Id, repository.Id);
			Assert.AreEqual(source.InvoiceName, repository.InvoiceName);

			//TODO Dont forget to fix this
			//Assert.AreEqual(source.Date, repository.Date);


			Assert.AreEqual(source.InvoiceRows.Count, repository.InvoiceRows.Count);

			foreach (InvoiceRow row in source.InvoiceRows)
			{
				InvoiceRow invoiceRow = repository.InvoiceRows.Find(rRow => rRow.Id == row.Id);

				Assert.IsNotNull(invoiceRow);
				Assert.AreEqual(row.Sum, invoiceRow.Sum);
				Assert.AreEqual(row.Comments, invoiceRow.Comments);

				//Person
				//Assert.IsNotNull(invoiceRow.PersonEntity);
				//Assert.AreEqual(row.PersonEntity.Id, invoiceRow.PersonEntity.Id);
				//Assert.AreEqual(row.PersonEntity.Name, invoiceRow.PersonEntity.Name);

				////Company
				//Assert.IsNotNull(invoiceRow.CompanyEntity);
				//Assert.AreEqual(row.CompanyEntity.Id, invoiceRow.CompanyEntity.Id);
				//Assert.AreEqual(row.CompanyEntity.CompanyName, invoiceRow.CompanyEntity.CompanyName);
			}

		}
	}
}
