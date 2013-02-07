using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Informedica.GenPres.Application.Bootstrap;
using Informedica.GenPres.Business.Logic.UserManagement;
using NUnit.Framework;
using Shared.Test;

namespace Logic.Integration.Tests.UserManagement
{
    public class UserCrudShould
    {
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
        public void CreateADefaultUser()
        {
            const string username = "admin";
            const string passsword = "genpres";

            var user = UserCrud.CreateDefaultUser(username, passsword);
            AssertAll.Succeed(
                () =>  user.Username.Should().NotBeEmpty(),
                () =>  user.PasswordHash.Should().NotBeEmpty()
            );
        }
    }
}
