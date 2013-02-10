
using System.Web.Mvc;
using Autofac;
using FluentAssertions;
using Informedica.GenPres.Application.IoC.Modules;
using Informedica.GenPres.DataAcess;
using Informedica.GenPres.DataAcess.RavenDb;
using NUnit.Framework;
using Raven.Client;
using TypeMock.ArrangeActAssert;

namespace Application.Unit.Tests.IoC
{
    public class DatabaseSessionShould : IoCTestBase
    {
        private RavenDbTestContext _ravenDbContext;

        [SetUp]
        public void SetUp()
        {
            var builder = new ContainerBuilder();

            _ravenDbContext = Isolate.Fake.Instance<RavenDbTestContext>(Members.ReturnRecursiveFakes);
            
            builder.RegisterInstance(_ravenDbContext).As<IDatabaseContext>().SingleInstance();

            builder.Register(x => x.Resolve<IDatabaseContext>().OpenSession()).As<IDocumentSession>();
            
            base.BuildAndCreateTestDependencyResolver(builder);
        }

        [Test]
        public void BeResolvable()
        {
            var session = DependencyResolver.Current.GetService<IDocumentSession>();
            session.Should().NotBeNull();
        }

        [Test]
        public void BeSameInCurrentScope()
        {
            var session1 = DependencyResolver.Current.GetService<IDocumentSession>();
            var session2 = DependencyResolver.Current.GetService<IDocumentSession>();
            session1.Should().BeSameAs(session2);
        }

        [Test]
        public void CallDatabaseContextToCreateASession()
        {
            var session = DependencyResolver.Current.GetService<IDocumentSession>();
            Isolate.Verify.WasCalledWithAnyArguments(() => _ravenDbContext.OpenSession());
        }
    }
}
