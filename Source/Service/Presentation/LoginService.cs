using Informedica.GenPres.Business.Logic;
using Informedica.Data.Repositories;

namespace Informedica.Service.Presentation
{
    public class LoginService : ILoginService
    {
        private IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AuthenticateUser(string username, string password)
        {
            var userToCheck = _userRepository.GetUser(username);
            return LoginScenario.ValidatePassword(userToCheck.PasswordHash, "key");
        }
    }
}
