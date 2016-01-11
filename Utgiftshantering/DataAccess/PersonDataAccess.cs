using System;
using System.Collections.Generic;
using System.Linq;
using Utgiftshantering.Entities;
using Utgiftshantering.Interfaces;
using Utgiftshantering.ObjectContext;

namespace Utgiftshantering.DataAccess
{ 
	/// <summary>
	/// Data Access class for working against persons in a repository
	/// </summary>
	public class PersonDataAccess : GeneralDataAccess<Person>, IPersonDataAccess
	{
		#region Construction
		/// <summary>
		/// Creates the data acess layer. 
		/// </summary>
		/// <param name="repo">The repository we are going to use</param>
		public PersonDataAccess(IRepository<Person> repo) : base(repo) {}
		#endregion

		#region Public Methods
		/// <summary>
		/// This method deletes a person from the repository
		/// </summary>
		public void RemoveAllPersons()
		{
			foreach(Person person in _repository.GetAll())
			{
				_repository.Delete(person);
			}

			_repository.SaveChanges();
		}

		/// <summary>
		/// Adds a person to the repository and call save
		/// </summary>
		/// <param name="person">The person you want to save</param>
		public void SavePerson(Person person)
		{
			_repository.Add(person);
			_repository.SaveChanges();
		} 

		/// <summary>
		/// Loads a specific person from your repository
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Person LoadPerson(Guid id)
		{
			return _repository.GetQuery().FirstOrDefault(p => p.Id == id);
		}

		/// <summary>
		/// Loads all people from the repository
		/// </summary>
		/// <returns></returns>
		public List<Person> LoadAllPeople()
		{
			return _repository.GetAll().ToList();
		}
		#endregion
	}
}
