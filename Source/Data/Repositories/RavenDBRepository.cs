using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informedica.GenPres.Business.Entities;
using Raven.Client;
using Raven.Client.Document;

namespace Informedica.Data.Repositories
{
    public class RavenDbRepository
    {
        protected IDocumentSession Session;

        protected RavenDbRepository(IDocumentSession session)
        {
            Session = session;
        }

        public T GetSingleOrDefault<T>(Func<T, bool> func) where T : Entity
        {
            return Session.Query<T>().SingleOrDefault(func);
        }
    }
}
