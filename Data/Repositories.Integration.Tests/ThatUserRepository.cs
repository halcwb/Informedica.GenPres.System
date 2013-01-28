using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Informedica.GenPres.Application.Bootstrap;
using NUnit.Framework;
using Raven.Client.Embedded;
using Raven.Database.Server;

namespace Repositories.Integration.Tests
{
    [TestFixture]
    public class ThatUserRepository
    {
        private EmbeddableDocumentStore _documentStore ;

        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            _documentStore = new EmbeddableDocumentStore
            {
                DataDirectory = "Data",
                RunInMemory = true,
                UseEmbeddedHttpServer = true
            };

            _documentStore.Configuration.AnonymousUserAccessMode = AnonymousUserAccessMode.All;
            _documentStore.Initialize();

        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Bootstrap.Initialize(_documentStore.OpenSession());
        }


        [Test]
        public void ShouldCreateNewUser()
        {
            var userRepository = new UserRepository();
            var user = userRepository.CreateUser("admin", "genrpes");
            user.Username.Should().NotBeEmpty();
        }
    }
}
