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
using Shared.Test;

namespace Repositories.Integration.Tests
{
    [TestFixture]
    public class ThatUserRepository
    {
        private const string Username = "admin";
        private const string PasswordHash = "590489053890";

        [SetUp]
        public void SetUpFixture()
        {
            Bootstrap.InitializeTest();
        }

        [TearDown]
        public void TearDown()
        {
            Bootstrap.EndSession();
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
            var user = User.CreateUser(Username, PasswordHash);
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
