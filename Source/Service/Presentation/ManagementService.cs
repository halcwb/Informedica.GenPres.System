using System.Collections.Generic;
using System.Linq;
using Informedica.Data.Repositories;
using Informedica.GenPres.Business.Entities;

namespace Informedica.Service.Presentation
{
    public class ManagementService : IMangementService
    {
        private IEntityRepository _entityRepository;
        private IPatientRepository _patientRepository;

        public ManagementService(IEntityRepository entityRepository, IPatientRepository patientRepository)
        {
            _entityRepository = entityRepository;
            _patientRepository = patientRepository;
        }

        public List<UserDto> GetUsers()
        {
            return (from i in _entityRepository.GetAll<User>() select new UserDto(i)).ToList();
        }

        public void AddUser(UserDto userDto)
        {
            _entityRepository.Save(userDto.Map());
        }

        public void DeleteUser(UserDto userDto)
        {
            _entityRepository.Delete(userDto.Map());
        }

        public List<LogicalUnitDto> GetLogicalUnits()
        {
            return (from i in _entityRepository.GetAll<LogicalUnit>() select new LogicalUnitDto(i)).ToList();
        }

        public void SaveLogicalUnit(LogicalUnitDto logicalUnit)
        {
            _entityRepository.Save(logicalUnit.Map());
        }

        public void DeleteLogicalUnit(LogicalUnitDto logicalUnit)
        {
            _entityRepository.Delete(logicalUnit.Map());
        }

        public List<PatientDto> GetPatients()
        {
            return (from i in _patientRepository.GetAll() select new PatientDto(i)).ToList();
        }

        public void SavePatient(PatientDto patientDto)
        {
            _patientRepository.Save(patientDto.Map());
        }

        public void DeletePatient(PatientDto patientDto)
        {
            _entityRepository.Delete(patientDto.Map());
        }
    }
}
