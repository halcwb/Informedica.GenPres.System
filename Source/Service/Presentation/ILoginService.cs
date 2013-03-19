using System.Collections.Generic;

namespace Informedica.Service.Presentation
{
    public interface ILoginService
    {
        bool AuthenticateUser(string username, string password);
        IEnumerable<LogicalUnitDto> GetLogicalUnits();
    }
}