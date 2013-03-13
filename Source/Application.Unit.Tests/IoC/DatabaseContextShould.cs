using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using FluentAssertions;
using Informedica.GenPres.Application.IoC.Modules;
using Informedica.GenPres.DataAcess;
using NUnit.Framework;

namespace Application.Unit.Tests.IoC
{
    public class DatabaseContextShould : IoCTestBase
    {
        [SetUp]
        public void SetUp()
        {
            var builder = new ContainerBuilder();        
            builder.RegisterModule(new DatabaseTestContextModule());
            base.BuildAndCreateTestDependencyResolver(builder);
        }

        [Test]
        public void BeResolvable()
        {
            var dbCtx = DependencyResolver.Current.GetService<IDatabaseContext>();
            dbCtx.Should().NotBeNull();
        }

        [Test]
        public void BeASingleton()
        {
            var dbCtx1 = DependencyResolver.Current.GetService<IDatabaseContext>();
            var dbCtx2 = DependencyResolver.Current.GetService<IDatabaseContext>();
            dbCtx1.Should().Be(dbCtx2);
        }
    }
}
