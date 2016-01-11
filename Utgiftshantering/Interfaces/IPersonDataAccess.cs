using System;
using System.Collections.Generic;
using Utgiftshantering.Entities;

namespace Utgiftshantering.Interfaces
{
	public interface IPersonDataAccess
	{
		void RemoveAllPersons();
		void SavePerson(Person person);
		Person LoadPerson(Guid id);
		List<Person> LoadAllPeople();
	}
}