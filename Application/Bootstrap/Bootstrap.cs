using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Database.Server;

namespace Informedica.GenPres.Application.Bootstrap
{
    public static class Bootstrap
    {
        public static IDocumentSession Session;

        public static void Initialize(IDocumentSession openSession)
        {
            Session = openSession;
        }

        public static void InitializeTest()
        {
            var documentStore = new EmbeddableDocumentStore
            {
                RunInMemory = true
            };

            documentStore.Configuration.AnonymousUserAccessMode = AnonymousUserAccessMode.All;
            documentStore.Initialize();
            Session = documentStore.OpenSession();
        }

        public static IDocumentSession GetSession()
        {
            if (Session == null)
            {
                throw new NullReferenceException("Session is not initialized or disposed.");
            }
            return Session;
        }

        public static void EndSession()
        {
            Session.Dispose();
        }
    }
}
