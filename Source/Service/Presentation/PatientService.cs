using System.Collections.Generic;
using System.Linq;
using Informedica.Data.Repositories;

namespace Informedica.Service.Presentation
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;
        
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public List<PatientDto> GetPatientsByLogicalUnitId(string logicalUnitId)
        {
            return (from i in _patientRepository.GetByLogicalUnitId(logicalUnitId) select new PatientDto(i)).ToList();
        } 
    }
}
