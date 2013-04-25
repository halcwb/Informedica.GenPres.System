using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informedica.Data.Repositories;
using Informedica.GenPres.Business.Entities;
using Raven.Client;

namespace Service.Tests
{
    public class TestRepository : EntityRepository
    {
        public TestRepository(IDocumentSession session) : base(session)
        {

        }

        public static void SaveEntities(IDocumentSession session, List<Entity> entities )
        {
            var repo = new TestRepository(session);
            foreach (var entity in entities)
            {
                repo.Save(entity);   
            }
        }
    }
}
