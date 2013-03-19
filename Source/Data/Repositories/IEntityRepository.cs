using System;
using System.Collections.Generic;
using Informedica.GenPres.Business.Entities;

namespace Informedica.Data.Repositories
{
    public interface IEntityRepository
    {
        T GetSingle<T>(Func<T, bool> func) where T:Entity;
        List<T> GetAll<T>();
        void Save<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T:Entity;
        T GetSingleOrDefault<T>(Func<T, bool> func) where T : Entity;
    }
}