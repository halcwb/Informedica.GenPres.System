using System.Collections.Generic;

namespace Informedica.Service.Presentation
{
    public interface IUserManagement
    {
        List<UserDto> GetUsers();
        void AddUser(UserDto userDto);
        void DeleteUser(UserDto userDto);
    }
}