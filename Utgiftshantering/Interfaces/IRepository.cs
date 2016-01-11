using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Utgiftshantering.Interfaces
{
	public interface IRepository<T> : IDisposable where T : class
	{
		IQueryable<T> GetQuery();
		IEnumerable<T> GetAll();
		IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
		T Single(Expression<Func<T, bool>> predicate);
		T First(Expression<Func<T, bool>> predicate);
		void Add(T entity);
		void Delete(T entity);
		void Attach(T entity);
		void SaveChanges();
		void SaveChanges(System.Data.Objects.SaveOptions options);
	}
}