using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Raven.Client;
using Utgiftshantering.Interfaces;

namespace Utgiftshantering.Repositories
{
	public class RavenRepository<T> : IRepository<T> where T : class
	{
		private readonly IDocumentStore _store;
		private readonly IDocumentSession _session;

		public RavenRepository(IDocumentStore store)
		{
			_store = store;
			_session = store.OpenSession();
		}

		public void Dispose()
		{
			_session.Dispose();
			_store.Dispose();
		}

		public IQueryable<T> GetQuery()
		{
			return _session.Query<T>();
		}

		public IEnumerable<T> GetAll()
		{
			return GetQuery().AsEnumerable();
		}

		public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
		{
			return _session.Query<T>().Where(predicate);
		}

		public T Single(Expression<Func<T, bool>> predicate)
		{
			return _session.Query<T>().Single();
		}

		public T First(Expression<Func<T, bool>> predicate)
		{
			return _session.Query<T>().First();
		}

		public void Add(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException();
			}

			_session.Store(entity);
		}

		public void Delete(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException();
			}
			
			_session.Delete<T>(entity);
		}

		public void Attach(T entity)
		{
			throw new NotImplementedException("This repository do not support attach.");
		}

		public void SaveChanges()
		{
			_session.SaveChanges();
		}

		public void SaveChanges(SaveOptions options)
		{
			SaveChanges();
		}
	}
}
