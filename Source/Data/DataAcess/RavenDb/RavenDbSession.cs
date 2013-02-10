using System;
using Raven.Client;
using Raven.Client.Document;

namespace Informedica.GenPres.DataAcess.RavenDb
{
    public class RavenDbSession : IDatabaseSession, IDisposable
    {
        private IDocumentSession _session;

        public RavenDbSession(IDocumentStore store)
        {
            _session = store.OpenSession();
        }

        public IDocumentSession GetSession()
        {
            return _session;
        }

        public void Dispose()
        {
            if (_session == null) return;

            _session.Dispose();
            _session = null;
        }

    }
}
