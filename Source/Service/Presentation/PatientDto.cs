using Informedica.GenPres.Business.Entities;

namespace Informedica.Service.Presentation
{
    public class PatientDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LogicalUnitId { get; set; }
        public string Id { get; set; }

        public PatientDto()
        {

        }

        public PatientDto(Patient patient)
        {
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            LogicalUnitId = patient.LogicalUnitId;
            Id = patient.Id;
        }

        public Patient Map()
        {
            var patient = new Patient()
            {
                Id = Id,
                FirstName =  FirstName,
                LastName =  LastName,
                LogicalUnitId =  LogicalUnitId
            };
            
            return patient;
        }
    }
}