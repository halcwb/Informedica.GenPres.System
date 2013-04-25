using System;
using System.Collections.Generic;
using System.Linq;
using Informedica.GenPres.Business.Entities;
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
            if (userToCheck == null)
            {
                throw new AuthenticationFailureException("Authentication failed.");
            }
            return userToCheck != null;
        }

        public IEnumerable<LogicalUnitDto> GetLogicalUnits()
        {
            var logicalUnitDtos = (from i in _entityRepository.GetAll<LogicalUnit>() select new LogicalUnitDto(i));
            if (logicalUnitDtos.Count() == 0)
            {
                throw new EmptyCollectionViolationException("The system has found an empty logical unit collection when at least one logical unit should be available.");
            }
            return logicalUnitDtos;
        }
    }

    public class AuthenticationFailureException : Exception
    {
        public AuthenticationFailureException(string s): base(s) 
        {
        }
    }

    public class EmptyCollectionViolationException : Exception
    {
        public EmptyCollectionViolationException(string s) : base(s)
        {
            
        }
    }
}
