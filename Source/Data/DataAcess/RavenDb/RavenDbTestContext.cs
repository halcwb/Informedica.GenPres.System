

using Raven.Client;
using Raven.Client.Embedded;
using Raven.Database.Server;

namespace Informedica.GenPres.DataAcess.RavenDb
{
    public class RavenDbTestContext : IDatabaseContext
    {
        private readonly EmbeddableDocumentStore _store;

        public RavenDbTestContext()
        {
            _store = new EmbeddableDocumentStore
            {
                RunInMemory = true
            };

            _store.Configuration.AnonymousUserAccessMode = AnonymousUserAccessMode.All;
            //IndexCreation.CreateIndexes(assembly, _store);
        }
        
        public void Initialize()
        {
            _store.Initialize();
        }
        
        public IDocumentSession OpenSession()
        {
            return _store.OpenSession();
        }
    }
}
