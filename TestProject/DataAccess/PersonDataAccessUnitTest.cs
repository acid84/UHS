using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utgiftshantering.DataAccess;
using Utgiftshantering.Entities;
using Moq;
using Utgiftshantering.Interfaces;

namespace TestProject.DataAccess
{
	[TestClass]
	public class PersonDataAccessUnitTest
	{
		[TestMethod]
		public void TestSavePerson()
		{
			Person p = CreatePersons(1)[0];

			var mock = new Mock<IRepository<Person>>();
			mock.Setup(repo => repo.SaveChanges());
			mock.Setup(repo => repo.GetQuery()).Returns(new List<Person> { p }.AsQueryable);

			var personDataAccess = new PersonDataAccess(mock.Object);
			personDataAccess.SavePerson(p);

			Person loadedPerson = personDataAccess.LoadPerson(p.Id);
			ValidatePerson(p, loadedPerson);
		}

		[TestMethod]
		public void TestSaveMultiplePersons()
		{
			List<Person> personList = CreatePersons(100);

			var mock = new Mock<IRepository<Person>>();
			mock.Setup(repo => repo.SaveChanges());
			mock.Setup(repo => repo.GetQuery()).Returns(personList.AsQueryable);

			var personDataAccess = new PersonDataAccess(mock.Object);

			foreach(Person person in personList)
			{
				personDataAccess.SavePerson(person);				
			}

			foreach(Person person in personList)
			{
				Person loadedPerson = personDataAccess.LoadPerson(person.Id);				
				ValidatePerson(person, loadedPerson);
			}
		}

		[TestMethod]
		public void TestLoadPersons()
		{
			const int nbrOfPersons = 150;
			List<Person> personList = CreatePersons(nbrOfPersons);

			var mock = new Mock<IRepository<Person>>();
			mock.Setup(repo => repo.SaveChanges());
			mock.Setup(repo => repo.GetAll()).Returns(personList.AsQueryable);

			var personDataAccess = new PersonDataAccess(mock.Object);

			foreach (Person person in personList)
			{
				personDataAccess.SavePerson(person);
			}

			List<Person> persons = personDataAccess.LoadAllPeople();
			Assert.AreEqual(nbrOfPersons, persons.Count);
		}

		[TestMethod]
		public void TestLoadEmptyPersons()
		{
			var mock = new Mock<IRepository<Person>>();
			mock.Setup(repo => repo.SaveChanges());
			mock.Setup(repo => repo.GetAll()).Returns(new List<Person>());

			var personDataAccess = new PersonDataAccess(mock.Object);
			List<Person> persons = personDataAccess.LoadAllPeople();
			Assert.AreEqual(0, persons.Count);
		}

		#region Help Methods
		private List<Person> CreatePersons(int nbrOfPersons)
		{
			var persons = new List<Person>();

			for(int i = 1; i <= nbrOfPersons; i++)
			{
				persons.Add(new Person { Name = "Name" + i, Id = Guid.NewGuid()});
			}

			return persons;
		}

		private void ValidatePerson(Person source, Person loadedPerson)
		{
			Assert.IsNotNull(loadedPerson);
			Assert.AreEqual(source.Id, loadedPerson.Id);
			Assert.AreEqual(source.Name, loadedPerson.Name);
		}
		#endregion
	}
}
