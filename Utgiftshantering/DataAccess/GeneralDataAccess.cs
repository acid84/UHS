using Utgiftshantering.Interfaces;

namespace Utgiftshantering.DataAccess
{
	/// <summary>
	/// Baseclass used for DataAccess with repositories
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class GeneralDataAccess<T> where T : class
	{
		/// <summary>
		/// The repository for your POCO Object
		/// </summary>
		protected readonly IRepository<T> _repository;

		/// <summary>
		/// Create me!
		/// </summary>
		/// <param name="repository"></param>
		protected GeneralDataAccess(IRepository<T> repository)
		{
			_repository = repository;
		}
	}
}
