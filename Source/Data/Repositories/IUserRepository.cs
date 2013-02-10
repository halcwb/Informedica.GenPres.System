using Informedica.GenPres.Business.Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        User CreateUser(string username, string password);
        User GetUser(string username);
    }
}