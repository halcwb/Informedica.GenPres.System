using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Informedica.Data.Repositories;
using Informedica.GenPres.Application;
using Informedica.GenPres.Application.IoC.Modules;
using Informedica.GenPres.Business.Entities;
using Informedica.GenPres.DataAcess;
using Informedica.Service.Presentation;
using NUnit.Framework;

namespace Service.Tests
{
    public class LoginServiceShould
    {
        protected void BuildAndCreateTestDependencyResolver(ContainerBuilder builder)
        {
            var container = builder.Build();
            var lifetimeScopeProvider = new StubLifetimeScopeProvider(container);
            var resolver = new AutofacDependencyResolver(container, lifetimeScopeProvider);
            DependencyResolver.SetResolver(resolver);
        }

        [SetUp]
        public void SetUp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DatabaseTestContextModule());
            builder.RegisterModule(new DatabaseSessionModule());
            builder.RegisterType<LoginService>().As<ILoginService>().InstancePerHttpRequest();
            builder.RegisterType<EntityRepository>().As<IEntityRepository>().InstancePerHttpRequest();
            BuildAndCreateTestDependencyResolver(builder);
        }

        [Test]
        public void ReturnAListOfLogicalUnits()
        {
            using (var dbCtx = DependencyResolver.Current.GetService<IDatabaseContext>())
            using(var session = dbCtx.OpenSession())
            {
                TestRepository.SaveEntities(session, new List<Entity>()
                {
                   new LogicalUnit {Name = "Test1"},
                   new LogicalUnit {Name = "Test2"}
                });

                var loginService = DependencyResolver.Current.GetService<ILoginService>();
                var logicalUnits = loginService.GetLogicalUnits();
                Assert.IsTrue(logicalUnits.Count() == 2);
            }
        }

        [Test]
        public void RetrieveALogicUnitFromTheDatabase()
        {
            using (var dbCtx = DependencyResolver.Current.GetService<IDatabaseContext>())
            using (var session = dbCtx.OpenSession())
            {
                TestRepository.SaveEntities(session, new List<Entity>(){new LogicalUnit {Name = "Test1"}});
                var loginService = DependencyResolver.Current.GetService<ILoginService>();
                var logicalUnits = loginService.GetLogicalUnits();
                Assert.IsTrue(logicalUnits.ElementAt(0).Name == "Test1");
            }
        }

        [Test]
        public void ThrowAnExceptionWhenNoLogicalUnitsAreAvailabe()
        {
            var loginService = DependencyResolver.Current.GetService<ILoginService>();
            Assert.Throws<EmptyCollectionViolationException>(() => loginService.GetLogicalUnits());
        }

        [Test]
        public void AuthenticateAUserFromTheDatabase()
        {
            using (var dbCtx = DependencyResolver.Current.GetService<IDatabaseContext>())
            using (var session = dbCtx.OpenSession())
            {
                TestRepository.SaveEntities(session, new List<Entity>(){User.Create("Peter", "Test")});
                var loginService = DependencyResolver.Current.GetService<ILoginService>();
                Assert.IsTrue(loginService.AuthenticateUser("Peter", "Test"));
            }
        }

        [Test]
        public void ThrowAnAuthenticationErrorWhenAUserCanNotBeAuthenticated()
        {
            var loginService = DependencyResolver.Current.GetService<ILoginService>();
            Assert.Throws<AuthenticationFailureException>(() => loginService.AuthenticateUser("Peter", "Test"));
        }
    }
}
