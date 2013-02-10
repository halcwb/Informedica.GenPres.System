using System.Linq;
using Informedica.GenPres.Business.Entities;
using Raven.Client;

namespace Repositories
{
    public class UserRepository : RavenDbRepository<User>, IUserRepository
    {
        public UserRepository(IDocumentSession session)
            : base(session)
        {
            
        }

        public User CreateUser(string username, string password)
        {
            var user = User.CreateUser(username, password);
            Session.Store(user);
            return user;
        }

        public User GetUser(string username)
        {
            return Session.Query<User>().Single(user => user.Username == username);
        }
    }
}
