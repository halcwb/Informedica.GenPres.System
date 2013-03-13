

using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Database.Server;

namespace Informedica.GenPres.DataAcess.RavenDb
{
    public class RavenDbContext : IDatabaseContext
    {
        private readonly DocumentStore _store;

        protected RavenDbContext()
        {
            
        }

        public RavenDbContext(string connectionString)
        {
            _store = new DocumentStore()
            {
                ConnectionStringName = "http://localhost:8080"
            };
            
            //_store.Configuration.AnonymousUserAccessMode = AnonymousUserAccessMode.All;
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
