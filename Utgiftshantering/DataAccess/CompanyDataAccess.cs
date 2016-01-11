using System.Collections.Generic;
using System.Linq;
using Utgiftshantering.Entities;
using Utgiftshantering.Interfaces;

namespace Utgiftshantering.DataAccess
{
	/// <summary>
	/// The company data access used for work against your repository
	/// </summary>
    public class CompanyDataAccess : GeneralDataAccess<Company>, ICompanyDataAccess
    {
    	#region CompanyDataAccess Construction
		/// <summary>
		/// Create me!
		/// </summary>
		/// <param name="repo">The company repository</param>
		public CompanyDataAccess(IRepository<Company> repo) : base(repo) {}
		#endregion

		#region Public Methods
		/// <summary>
		/// Saves a company to the repository
		/// </summary>
		/// <param name="company">The company you want to save</param>
		public void SaveCompany(Company company)
		{
			_repository.Add(company);
			_repository.SaveChanges();
		}

		/// <summary>
		/// Loads a specific company
		/// </summary>
		/// <param name="id">Id of the company</param>
		/// <returns>The company or null</returns>
		public Company LoadCompany(int id)
		{
			var comp = _repository.GetQuery().Where(c => c.Id == id).FirstOrDefault();
			return comp;
		}


		/// <summary>
		/// Loads all the companies
		/// </summary>
		/// <returns>A list of all your companies</returns>
		public List<Company> LoadAllCompanies()
		{
			return _repository.GetAll().ToList();
		}
		#endregion
	}
}
