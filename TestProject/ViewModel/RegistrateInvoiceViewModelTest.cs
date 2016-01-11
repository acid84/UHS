using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestProject.Helpers;
using Utgiftshantering.Entities;
using Utgiftshantering.Interfaces;
using Utgiftshantering.ViewModel;

namespace TestProject.ViewModel
{
	[TestClass]
	public class RegistrateInvoiceViewModelTest
	{
		[TestMethod]
		public void SaveTest()
		{
			var invoiceToSave = InvoiceHelper.CreateInvoices(1, 1)[0];

			var personDataAccessMock = new Mock<IPersonDataAccess>();
			var companyDataAccessMock = new Mock<ICompanyDataAccess>();
			var invoiceDataAccessMock = new Mock<IInvoiceDataAccess>();

			invoiceDataAccessMock.Setup(iA => iA.LoadInvoice(invoiceToSave.Id)).Returns(invoiceToSave);
			companyDataAccessMock.Setup(cA => cA.LoadAllCompanies()).Returns(new List<Company>());
			personDataAccessMock.Setup(pA => pA.LoadAllPeople()).Returns(new List<Person>());

			var viewModel = new RegistrateInvoiceViewModel(invoiceDataAccessMock.Object, companyDataAccessMock.Object, personDataAccessMock.Object) {InvoiceName = invoiceToSave.InvoiceName};
			viewModel.Invoices.AddRange(invoiceToSave.InvoiceRows);
			viewModel.Save();

			var loadedInvoice = invoiceDataAccessMock.Object.LoadInvoice(invoiceToSave.Id);
			
			InvoiceHelper.ValidateInvoice(invoiceToSave, loadedInvoice);
		}
	}
}

