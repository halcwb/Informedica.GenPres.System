using Informedica.GenPres.Business.Entities;

namespace Informedica.GenPres.Business.Logic.UserManagement
{
    public static class UserCrud
    {
        public static User CreateDefaultUser(string username, string password)
        {
            var userRepository = new Repositories.UserRepository();
            var user = userRepository.CreateUser(username, password);
            return user;
        }
    }
}
