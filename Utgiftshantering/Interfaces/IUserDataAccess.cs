using Utgiftshantering.Entities;

namespace Utgiftshantering.Interfaces
{
	public interface IUserDataAccess
	{
		User GetUserByName(string name);		
	}
}
