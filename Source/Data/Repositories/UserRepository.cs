using System.Collections.Generic;
using System.Linq;
using Informedica.GenPres.Business.Entities;
using Raven.Client;

namespace Informedica.Data.Repositories
{
    public class UserRepository : RavenDbRepository<User>, IUserRepository
    {
        public UserRepository(IDocumentSession session)
            : base(session)
        {
            
        }

        public User Get(string username)
        {
            return Session.Query<User>().Single(user => user.Username == username);
        }

        public List<User> GetAll()
        {
            return Session.Query<User>().ToList();
        }

        public void Save(User user)
        {
            if (string.IsNullOrEmpty(user.Id))
            {
                Session.Store(user);
            }
            else
            {
                Session.Store(user, user.Id);
            }
            
            Session.SaveChanges();
        }

        public void Delete(User user)
        {
           user = Session.Load<User>(user.Id);
           Session.Delete(user);
           Session.SaveChanges();
        }
    }
}
