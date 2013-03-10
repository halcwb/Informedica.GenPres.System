using System.Linq;
using FluentAssertions;
using Informedica.GenPres.Business.Entities;
using NUnit.Framework;
using Raven.Client;
using Raven.Client.Embedded;
using Shared.Test;

namespace Informedica.Data.Repositories.Integration.Tests
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

        [TearDown]
        public void TearDown()
        {
            _session.Dispose();
            _documentStore.Dispose();
        }

        [Test]
        public void ShouldBeAbleToSaveAUser()
        {
            var userRepository = new UserRepository(_session);
            var user = User.Create(Username, PasswordHash);
            userRepository.Save(user);
            user.Id.Should().NotBeEmpty();
        }

        [Test]
        public void ShouldBeAbleToRetrieveAUser()
        {
            var user = User.Create(Username, PasswordHash);
            _session.Store(user);
            _session.SaveChanges();

            var userRepository = new UserRepository(_session);
            var getUser = userRepository.Get(Username);
            
            AssertAll.Succeed(
                () => Assert.IsNotNullOrEmpty(getUser.Id, "Id should be retrieved"),
                () => Assert.IsNotNullOrEmpty(getUser.PasswordHash, "Password should be retrieved"),
                () => Assert.IsNotNullOrEmpty(getUser.Username, "Username should have been retrieved")
            );
        }

        [Test]
        public void ShouldBeToGetAllUsers()
        {
            var user1 = User.Create(Username, PasswordHash);
            var user2 = User.Create(Username, PasswordHash);
            _session.Store(user1);
            _session.Store(user2);
            _session.SaveChanges();

            var userRepository = new UserRepository(_session);
            var users = userRepository.GetAll();
            users.Count.Should().Be(2);
        }

        [Test]
        public void SavingAnExistingUserShouldNotChangeId()
        {
            var user = User.Create(Username, PasswordHash);
            _session.Store(user);
            _session.SaveChanges();

            var userRepository = new UserRepository(_session);
            var userGet = userRepository.Get(Username);
            userRepository.Save(userGet);
            userGet.Id.Should().Be(user.Id);
        }
    }
}
