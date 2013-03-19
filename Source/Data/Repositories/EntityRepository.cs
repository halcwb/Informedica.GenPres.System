using System;
using System.Collections.Generic;
using System.Linq;
using Informedica.GenPres.Business.Entities;
using Raven.Client;

namespace Informedica.Data.Repositories
{
    public class EntityRepository : RavenDbRepository, IEntityRepository
    {
        public EntityRepository(IDocumentSession session)
            : base(session)
        {
            
        }

        public T GetSingle<T>(Func<T, bool> func) where T:Entity
        {
            return Session.Query<T>().Single(func);
        }

        public T GetSingleOrDefault<T>(Func<T, bool> func) where T : Entity
        {
            return Session.Query<T>().SingleOrDefault(func);
        }

        public List<T> GetAll<T>()
        {
            return Session.Query<T>().ToList();
        }

        public void Save<T>(T entity) where T : Entity
        {
            if (string.IsNullOrEmpty(entity.Id))
            {
                Session.Store(entity);
            }
            else
            {
                Session.Store(entity, entity.Id);
            }
            
            Session.SaveChanges();
        }

        public void Delete<T>(T entity) where T:Entity
        {
            entity = Session.Load<T>(entity.Id);
            Session.Delete(entity);
            Session.SaveChanges();
        }
    }
}
