using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Utgiftshantering.Entities;
using Utgiftshantering.Interfaces;
using Utgiftshantering.ViewModel;

namespace TestProject.ViewModel
{
	[TestClass]
	public class RegistratePersonViewModelTest
	{
		[TestMethod]
		public void SaveTest()
		{
			var personToSave = new Person {Id = Guid.NewGuid(), Name = "Micke"};

			var personDataAccessMock = new Mock<IPersonDataAccess>();
			personDataAccessMock.Setup(pA => pA.LoadPerson(personToSave.Id)).Returns(personToSave);

			var viewModel = new RegistratePersonViewModel(personDataAccessMock.Object)
			                	{
			                		Pers =
			                			{
			                				Id = personToSave.Id,
			                				Name = personToSave.Name
			                			}
			                	};

			viewModel.Save();

			var loadedPerson = personDataAccessMock.Object.LoadPerson(personToSave.Id);

			Assert.AreEqual(personToSave.Id, loadedPerson.Id);
			Assert.AreEqual(personToSave.Name, loadedPerson.Name);
		}
	}
}
