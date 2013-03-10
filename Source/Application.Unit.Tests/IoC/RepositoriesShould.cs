using System.Web.Mvc;
using Autofac;
using FluentAssertions;
using Informedica.GenPres.Application.IoC.Modules;
using Informedica.GenPres.DataAcess;
using NUnit.Framework;
using Raven.Client;
using Informedica.Data.Repositories;
using Rhino.Mocks;

namespace Application.Unit.Tests.IoC
{
    public class RepositoriesShould : IoCTestBase
    {
        [SetUp]
        public void SetUp()
        {
            var builder = new ContainerBuilder();

            var stubDocumentSession = MockRepository.GenerateStub<IDocumentSession>();

            builder.RegisterInstance(stubDocumentSession).As<IDocumentSession>();

            builder.RegisterModule<RepositoriesModule>();

            base.BuildAndCreateTestDependencyResolver(builder);
        }

        [Test]
        public void UserRepositoryToBeResolvable()
        {
            var session = DependencyResolver.Current.GetService<IUserRepository>();
            session.Should().NotBeNull();
        }

        [Test]
        public void UserRepositoryToBeSameInCurrentScope()
        {
            var userRep1 = DependencyResolver.Current.GetService<IUserRepository>();
            var userRep2 = DependencyResolver.Current.GetService<IUserRepository>();
            userRep1.Should().BeSameAs(userRep2);
        }
    }
}
