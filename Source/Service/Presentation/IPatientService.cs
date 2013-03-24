using System.Collections.Generic;

namespace Informedica.Service.Presentation
{
    public interface IPatientService
    {
        List<PatientDto> GetPatientsByLogicalUnitId(string logicalUnitId);
    }
}