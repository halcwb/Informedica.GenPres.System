using System.Linq;
using FluentAssertions;
using Informedica.GenPres.Business.Entities;
using NUnit.Framework;
using Raven.Client;
using Raven.Client.Embedded;
using Shared.Test;

namespace Repositories.Integration.Tests
{
    [TestFixture]
    public class ThatUserRepository
    {
        private const string Username = "admin";
        private const string PasswordHash = "590489053890";
        
        private IDocumentSession _session;
        private EmbeddableDocumentStore _documentStore;

        [SetUp]
        public void SetUp()
        {
            _documentStore = new EmbeddableDocumentStore
            {
                RunInMemory = true
            };

            _documentStore.Initialize();
            _session = _documentStore.OpenSession();
        }

        [Test]
        public void ShouldBeAbleToCreateANewUser()
        {
            var userRepository = new UserRepository(_session);
            userRepository.CreateUser(Username, PasswordHash);
            _session.SaveChanges();

            var getUser = _session.Query<User>().Single(user => user.Username == Username);
            getUser.Username.Should().NotBeEmpty();
        }

        [Test]
        public void ShouldBeAbleToRetrieveAUser()
        {
            var user = User.CreateUser(Username, PasswordHash);
            _session.Store(user);
            _session.SaveChanges();

            var userRepository = new UserRepository(_session);
            var getUser = userRepository.GetUser(Username);
            
            AssertAll.Succeed(
                () => Assert.IsNotNullOrEmpty(getUser.PasswordHash, "password should be retrieved"),
                () => Assert.IsNotNullOrEmpty(getUser.Username, "username should have been retrieved")
            );
        }
    }
}
