using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informedica.GenPres.Business.Entities;
using Raven.Client;

namespace Informedica.Data.Repositories
{
    public class PatientRepository : EntityRepository, IPatientRepository
    {
        public PatientRepository(IDocumentSession session) : base(session)
        {
        }

        public Patient GetSingle(string id) 
        {
            var patient = Session.Load<Patient>(id);
            return patient;
        }

        public List<Patient> GetAll()
        {
            var patients = Session.Query<Patient>().ToList();
            return patients;
        }
    }
}
