using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informedica.GenPres.Application.Bootstrap;
using Informedica.GenPres.Business.Entities;

namespace Repositories
{
    public class UserRepository
    {
        public User CreateUser(string username, string password)
        {
            var user = new User {Username = username};
            var session = Bootstrap.GetSession();
            session.Store(user);
            session.SaveChanges();
            return user;
        }

        public User GetUser(string username)
        {
            var session = Bootstrap.GetSession();
            return session.Query<User>().Single(user => user.Username == username);
        }
    }
}
