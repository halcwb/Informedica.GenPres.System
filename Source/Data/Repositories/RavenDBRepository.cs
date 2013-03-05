using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Document;

namespace Informedica.Data.Repositories
{
    public class RavenDbRepository<T>
    {
        protected IDocumentSession Session;

        protected RavenDbRepository(IDocumentSession session)
        {
            Session = session;
        }
    }
}
