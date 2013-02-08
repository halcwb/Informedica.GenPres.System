

using Raven.Client;
using Raven.Client.Embedded;
using Raven.Database.Server;

namespace Informedica.GenPres.DataAcess.RavenDb
{
    public class RavenDbContext : IDatabaseContext
    {
        private readonly EmbeddableDocumentStore _store;

        protected RavenDbContext()
        {
            
        }

        public RavenDbContext(string connectionString)
        {
            _store = new EmbeddableDocumentStore
            {
                RunInMemory = true
            };

            _store.Configuration.AnonymousUserAccessMode = AnonymousUserAccessMode.All;
            //IndexCreation.CreateIndexes(assembly, _store);
        }

        public IDocumentSession OpenSession()
        {
            return _store.OpenSession();
        }

        public void Initialize()
        {
            _store.Initialize();
        }
    }
}
