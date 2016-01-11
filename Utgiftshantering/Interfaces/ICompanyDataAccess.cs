using System.Collections.Generic;
using Utgiftshantering.Entities;

namespace Utgiftshantering.Interfaces
{
	public interface ICompanyDataAccess
	{
		void SaveCompany(Company company);
		Company LoadCompany(int id);
		List<Company> LoadAllCompanies();
	}
}