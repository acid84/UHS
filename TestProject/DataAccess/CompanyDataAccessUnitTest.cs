using Moq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utgiftshantering.DataAccess;
using Utgiftshantering.Entities;
using Utgiftshantering.Interfaces;

namespace TestProject.DataAccess
{
	[TestClass]
	public class CompanyDataAccessUnitTest
	{
		[TestMethod]
		public void TestSaveOneCompany()
		{
			var company = new Company {Name = "Company1", Id = 1};

			var mock = new Mock<IRepository<Company>>();
			mock.Setup(repo => repo.SaveChanges());
			mock.Setup(repo => repo.GetQuery()).Returns(new List<Company> {company}.AsQueryable);
			
			var companyDataAccess = new CompanyDataAccess(mock.Object);

			companyDataAccess.SaveCompany(company);

			Company loadedCompany = companyDataAccess.LoadCompany(company.Id);

			Assert.IsNotNull(loadedCompany);
			Assert.AreEqual(loadedCompany.Id, company.Id);
			Assert.AreEqual(loadedCompany.Name, company.Name);
		}

		[TestMethod]
		public void TestSaveMultipleCompanies()
		{
			var c1 = new Company { Name = "Company1", Id = 1};
			var c2 = new Company { Name = "Company2", Id = 2};
			var c3 = new Company { Name = "Company3", Id = 3};
			var c4 = new Company { Name = "Company4", Id = 4};

			var mock = new Mock<IRepository<Company>>();
			mock.Setup(repo => repo.SaveChanges());
			mock.Setup(repo => repo.GetQuery()).Returns(new List<Company> { c1, c2, c3, c4 }.AsQueryable);

			var companyDataAccess = new CompanyDataAccess(mock.Object);
		
			companyDataAccess.SaveCompany(c1);
			companyDataAccess.SaveCompany(c2);
			companyDataAccess.SaveCompany(c3);
			companyDataAccess.SaveCompany(c4);

			Company loadedCompany = companyDataAccess.LoadCompany(c1.Id);
			Assert.IsNotNull(loadedCompany);
			Assert.AreEqual(loadedCompany.Id, c1.Id);
			Assert.AreEqual(loadedCompany.Name, c1.Name);

			loadedCompany = companyDataAccess.LoadCompany(c2.Id);
			Assert.IsNotNull(loadedCompany);
			Assert.AreEqual(loadedCompany.Id, c2.Id);
			Assert.AreEqual(loadedCompany.Name, c2.Name);

			loadedCompany = companyDataAccess.LoadCompany(c3.Id);
			Assert.IsNotNull(loadedCompany);
			Assert.AreEqual(loadedCompany.Id, c3.Id);
			Assert.AreEqual(loadedCompany.Name, c3.Name);

			loadedCompany = companyDataAccess.LoadCompany(c4.Id);
			Assert.IsNotNull(loadedCompany);
			Assert.AreEqual(loadedCompany.Id, c4.Id);
			Assert.AreEqual(loadedCompany.Name, c4.Name);
		}

		[TestMethod]
		public void TestLoadAllCompanies()
		{
			var c1 = new Company { Name = "Company1", Id = 1};
			var c2 = new Company { Name = "Company2", Id = 2};
			var c3 = new Company { Name = "Company3", Id = 3};
			var c4 = new Company { Name = "Company4", Id = 4};

			var mock = new Mock<IRepository<Company>>();
			mock.Setup(repo => repo.SaveChanges());
			mock.Setup(repo => repo.GetAll()).Returns(new List<Company> { c1, c2, c3, c4 }.AsQueryable);

			var companyDataAccess = new CompanyDataAccess(mock.Object);
		
			List<Company> companies = companyDataAccess.LoadAllCompanies();

			Assert.IsNotNull(companies);

			companyDataAccess.SaveCompany(c1);
			companyDataAccess.SaveCompany(c2);
			companyDataAccess.SaveCompany(c3);
			companyDataAccess.SaveCompany(c4);

			companies = companyDataAccess.LoadAllCompanies();
			
			Assert.IsNotNull(companies);
			Assert.AreEqual(4, companies.Count);
		}

		[TestMethod]
		public void TestLoadNotExistingCompany()
		{
			var c1 = new Company { Name = "Company1", Id = 1};

			var mock = new Mock<IRepository<Company>>();
			mock.Setup(repo => repo.SaveChanges());
			mock.Setup(repo => repo.GetAll()).Returns(new List<Company> { c1 }.AsQueryable);

			var companyDataAccess = new CompanyDataAccess(mock.Object);
			companyDataAccess.SaveCompany(c1);

			Company loadedCompany = companyDataAccess.LoadCompany(-1);

			Assert.IsNull(loadedCompany);
		}

		[TestMethod]
		public void TestLoadNotExistingCompany2()
		{
			var mock = new Mock<IRepository<Company>>();

			var companyDataAccess = new CompanyDataAccess(mock.Object);
			Company loadedCompany = companyDataAccess.LoadCompany(-1);

			Assert.IsNull(loadedCompany);
		}
	}
}
