using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;

namespace Informedica.GenPres.Application.Bootstrap
{
    public static class Bootstrap
    {
        public static IDocumentSession Session;

        public static void Initialize(IDocumentSession openSession)
        {
            Session = openSession;
        }

        public static IDocumentSession GetSession()
        {
            return Session;
        }

        public static void Finalize()
        {
            Session.Dispose();
        }
    }
}
