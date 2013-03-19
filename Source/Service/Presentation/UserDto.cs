using Informedica.GenPres.Business.Entities;

namespace Informedica.Service.Presentation
{
    public class UserDto : IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Id { get; set; }

        public UserDto()
        {

        }

        public UserDto(User user)
        {
            Username = user.Username;
            Password = user.PasswordHash;
            Id = user.Id;
        }

        public User Map()
        {
            var user = User.Create(Username, Password);
            user.Id = Id;
            return user;
        }
    }
}