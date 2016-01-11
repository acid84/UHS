using System.Collections.Generic;
using Common.Entities;

namespace Common.Interfaces
{
	public interface IPersonDataAccess
	{
		void RemoveAllPersons();
		void SavePerson(Person person);
		Person LoadPerson(int id);
		List<Person> LoadAllPeople();
	}
}