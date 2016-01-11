using System;
using System.Collections.Generic;
using Utgiftshantering.Interfaces;
using Utgiftshantering.Repositories;

namespace Utgiftshantering.Factory
{
	public static class RepositoryFactory<T> where T : class
	{
// ReSharper disable StaticFieldInGenericType
		private static readonly Dictionary<Type, IRepository<T>> _repositories = new Dictionary<Type, IRepository<T>>();
// ReSharper restore StaticFieldInGenericType

		public static IRepository<T> GetRepository()
		{
			if(!_repositories.ContainsKey(typeof(T)))
			{
				var repo = new RavenRepository<T>(ObjectContextFactory.GetStore());
				_repositories.Add(typeof(T), repo);
			}

			return _repositories[typeof(T)];
		}
	}
}
