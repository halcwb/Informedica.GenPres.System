using System.Collections.Generic;
using System.Linq;
using Informedica.GenPres.Business.Entities;
using Informedica.GenPres.Business.Logic;
using Informedica.Data.Repositories;

namespace Informedica.Service.Presentation
{
    public class LoginService : ILoginService
    {
        private IEntityRepository _entityRepository;
        
        public LoginService(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public bool AuthenticateUser(string username, string password)
        {
            var userToCheck = _entityRepository.GetSingleOrDefault<User>(x=>x.Username == username && x.PasswordHash == password);
            return userToCheck != null;
        }

        public IEnumerable<LogicalUnitDto> GetLogicalUnits()
        {
            return (from i in _entityRepository.GetAll<LogicalUnit>() select new LogicalUnitDto(i));
        }
    }
}
