using System.Collections.Generic;
using Informedica.GenPres.Business.Entities;

namespace Informedica.Data.Repositories
{
    public interface IPatientRepository : IEntityRepository
    {
        Patient GetSingle(string id);
        List<Patient> GetAll();
    }
}