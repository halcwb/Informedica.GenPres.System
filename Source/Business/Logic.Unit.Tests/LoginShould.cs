using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Informedica.GenPres.Business.Logic;
using NUnit.Framework;

namespace Logic.Unit.Tests
{
    public class LoginShould
    {
        [Test]
        public void ValidatePassword()
        {
            Login.ValidatePassword("user", "test").Should().BeTrue();
        }
    }
}
