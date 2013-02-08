using Informedica.GenPres.Business.Logic;
using Repositories;

namespace Presentation
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
            return Login.ValidatePassword(password, "key");
        }
    }
}
