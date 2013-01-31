using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Informedica.GenPres.Application.Bootstrap;
using Informedica.GenPres.Business.Entities;
using NUnit.Framework;
using Raven.Client.Embedded;
using Raven.Database.Server;
using Shared.TestBase;

namespace Repositories.Integration.Tests
{
    [TestFixture]
    public class ThatUserRepository
    {
        private EmbeddableDocumentStore _documentStore ;
        private const string Username = "admin";
        private const string PasswordHash = "590489053890";

        [SetUp]
        public void SetUpFixture()
        {
            _documentStore = new EmbeddableDocumentStore
            {
                RunInMemory = true
            };

            _documentStore.Configuration.AnonymousUserAccessMode = AnonymousUserAccessMode.All;
            _documentStore.Initialize();
            Bootstrap.Initialize(_documentStore.OpenSession());
        }

        [TearDown]
        public void TearDown()
        {
            Bootstrap.Finalize();
        }

        [Test]
        public void ShouldBeAbleToCreateANewUser()
        {
            var userRepository = new UserRepository();
            userRepository.CreateUser(Username, PasswordHash);

            var session = Bootstrap.GetSession();
            var getUser = session.Query<User>().Single(user => user.Username == Username);
            getUser.Username.Should().NotBeEmpty();
        }

        [Test]
        public void ShouldBeAbleToRetrieveAUser()
        {
            var user = new User { Username = Username, PasswordHash = PasswordHash};
            var session = Bootstrap.GetSession();
            session.Store(user);
            session.SaveChanges();

            var userRepository = new UserRepository();
            var getUser = userRepository.GetUser(Username);
            
            AssertAll.Succeed(
                () => Assert.IsNotNullOrEmpty(getUser.PasswordHash, "password should be retrieved"),
                () => Assert.IsNotNullOrEmpty(getUser.Username, "username should have been retrieved")
            );
        }
    }
}
