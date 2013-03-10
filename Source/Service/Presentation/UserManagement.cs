using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informedica.Data.Repositories;

namespace Informedica.Service.Presentation
{
    public class UserManagement : IUserManagement
    {
        private IUserRepository _userRepository;

        public UserManagement(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDto> GetUsers()
        {
            var userDtos = new List<UserDto>();
            var users =_userRepository.GetAll();
            for (int i = 0; i < users.Count; i++)
            {
                userDtos.Add(new UserDto(users[i]));
            }
            return userDtos;
        }
 
        public void AddUser(UserDto userDto)
        {
            var user = userDto.Map();
            _userRepository.Save(user);
        }

        public void DeleteUser(UserDto userDto)
        {
            _userRepository.Delete(userDto.Map());
        }
    }
}
