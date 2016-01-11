using System;
using System.Linq;
using Utgiftshantering.Entities;
using Utgiftshantering.Interfaces;

namespace Utgiftshantering.DataAccess
{
	public class UserDataAccess :  GeneralDataAccess<User>, IUserDataAccess
	{
		public UserDataAccess(IRepository<User> repo) : base(repo) {}

		public User GetUserByName(string name)
		{
			return _repository.Find(u => u.UserName == name).FirstOrDefault();
		}

		public void AddUser(string userName, string password)
		{
			_repository.Add(new User { Id = Guid.NewGuid(), UserName = userName, Password = password});
			_repository.SaveChanges();
		}
	}
}
