using System.Collections.Generic;
using Informedica.GenPres.Business.Entities;

namespace Informedica.Data.Repositories
{
    public interface IUserRepository
    {
        User Get(string username);
        List<User> GetAll();
        void Save(User user);
        void Delete(User user);
    }
}