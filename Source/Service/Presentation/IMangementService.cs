using System.Collections.Generic;

namespace Informedica.Service.Presentation
{
    public interface IMangementService
    {
        List<UserDto> GetUsers();
        void AddUser(UserDto userDto);
        void DeleteUser(UserDto userDto);
        List<LogicalUnitDto> GetLogicalUnits();
        void SaveLogicalUnit(LogicalUnitDto logicalUnit);
        void DeleteLogicalUnit(LogicalUnitDto logicalUnit);
        List<PatientDto> GetPatients();
        void SavePatient(PatientDto patientDto);
        void DeletePatient(PatientDto patientDto);
    }
}