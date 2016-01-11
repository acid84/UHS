using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Utgiftshantering.Entities;
using Utgiftshantering.Interfaces;
using Utgiftshantering.ViewModel;

namespace TestProject.ViewModel
{
	[TestClass]
	public class RegistrateCompanyViewModelTest
	{
		[TestMethod]
		public void SaveTest()
		{
			var companyToSave = new Company {Id = 1, Name = "Company1"};

			var companyDataAccessMock = new Mock<ICompanyDataAccess>();
			companyDataAccessMock.Setup(cA => cA.LoadCompany(companyToSave.Id)).Returns(companyToSave);

			var viewModel = new RegistrateCompanyViewModel(companyDataAccessMock.Object) { Comp = { Id = companyToSave.Id, Name = companyToSave.Name } };
			viewModel.Save();

			var loadedCompany = companyDataAccessMock.Object.LoadCompany(companyToSave.Id);

			Assert.AreEqual(companyToSave.Id, loadedCompany.Id);
			Assert.AreEqual(companyToSave.Name, loadedCompany.Name);
		}
	}
}
