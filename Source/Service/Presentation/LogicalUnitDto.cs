using Informedica.GenPres.Business.Entities;

namespace Informedica.Service.Presentation
{
    public class LogicalUnitDto : IDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public LogicalUnitDto()
        {
        }

        public LogicalUnitDto(LogicalUnit logicalUnit)
        {
            Id = logicalUnit.Id;
            Name = logicalUnit.Name;
        }

        public LogicalUnit Map()
        {
            return new LogicalUnit()
            {
                Id = Id,
                Name = Name
            };
        }
    }
}