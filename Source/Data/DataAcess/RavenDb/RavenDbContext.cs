

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

        public RavenDbContext(string url, string databaseName)
        {
            _store = new DocumentStore()
            {
                Url = url,
                DefaultDatabase = databaseName
            };

            _store.Conventions.DocumentKeyGenerator = (dbname, commands, entity) => _store.Conventions.GetTypeTagName(entity.GetType()) + "/";
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
