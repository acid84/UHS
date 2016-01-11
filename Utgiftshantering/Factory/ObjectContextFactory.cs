using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Utgiftshantering.ObjectContext;

namespace Utgiftshantering.Factory
{
	public static class ObjectContextFactory
	{
		private static UHSContext _objectContext;

		public static System.Data.Objects.ObjectContext GetObjectContext()
		{
			return _objectContext ?? (_objectContext = new UHSContext());
		}

		private static IDocumentStore _document;
		public static IDocumentStore GetStore()
		{
			if (_document == null)
			{
				_document = new EmbeddableDocumentStore {RunInMemory = true};
				_document.Initialize();
			}

			return _document;
		}
	}
}
